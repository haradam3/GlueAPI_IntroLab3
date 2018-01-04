#region Copyright
//
// Copyright (C) 2013-2018 by Autodesk, Inc.
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//
// Written by M.Harada 
#endregion // Copyright

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
// Reuse the Glue web services calls
using GlueAPIIntro;
// Added for RestSharp. 
using RestSharp;

/// Welcome to Glue API Intro labs. 
/// 
/// This is the minimum web application using Glue API. 
/// No error checking, fancy style sheet for code readability.  
/// This simply does the following: 
/// login >> get a list of projects. choose an arbitrary one 
/// >> get a list of models. choose an arbitrary model. >> display 
/// 

namespace GlueAPIWebIntro
{
    public partial class GlueUI : System.Web.UI.Page
    {
        //====================================================
        // WebForm Start/End
        //====================================================
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //==========================================================
        // Login/Logout
        //==========================================================
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            // Glue Login call here. 
            string authToken = Glue.Login(TextBoxUserName.Text, TextBoxPassword.Text);

            // If success, change the button to logout
            if (!string.IsNullOrEmpty(authToken))
            {
                // If success, change the button to logout.
                ButtonLogin.Enabled = false;
                ButtonLogout.Enabled = true;

                // Save autoToken for this session 
                Session["authToken"] = authToken;
            }

            // Show the request and response in the form. 
            // This is for learning purpose. 
            ShowRequestResponse();
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            string authToken = Session["authToken"] as string;

            // Here is the main call to Field API. 
            bool result = Glue.Logout(authToken);

            Session["authToken"] = "";

            ButtonLogin.Enabled = true;
            ButtonLogout.Enabled = false;

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse();
        }

        //===========================================================
        // Helper Functions 
        //===========================================================
        // Show the request and response in the form.
        // This is for learning purpose.
        protected void ShowRequestResponse()
        {
            IRestResponse response = Glue.m_lastResponse;
            TextBoxRequest.Text = response.ResponseUri.AbsoluteUri;
            LabelStatus.Text = "Status: " + response.StatusCode.ToString();
            TextBoxResponse.Text = response.Content;
        }

        //============================================================
        // Projects  
        //============================================================
        protected void ButtonProject_Click(object sender, EventArgs e)
        {
            string authToken = Session["authToken"] as string;
            List<Project> proj_list = Glue.ProjectList(authToken);

            ShowRequestResponse();

            if (proj_list == null) { return; }

            // Set up a project list
            proj_list = proj_list.OrderBy(x => x.project_name).ToList();
            DropDownListProjects.DataSource = proj_list;
            DropDownListProjects.DataTextField = "project_name";
            DropDownListProjects.DataValueField = "project_id";
            DropDownListProjects.DataBind();
            DropDownListProjects.SelectedIndex = 0;
        }

        // If you don't see this is called, check AutoPostBack="True" property of DropDownList in your .aspx page. 
        // https://stackoverflow.com/questions/4905406/dropdownlists-selectedindexchanged-event-not-firing
        protected void DropDownListProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear models
            DropDownListModels.DataSource = null;
            DropDownListModels.Items.Clear(); 
        }

        //=========================================================
        //  Models 
        //=========================================================
        protected void ButtonModel_Click(object sender, EventArgs e)
        {
            string authToken = Session["authToken"] as string;
            string project_id = DropDownListProjects.SelectedValue; 

            List<ModelInfo> model_list = Glue.ModelList(authToken, project_id);

            ShowRequestResponse();

            if (model_list == null) { return; }

            // Set up a model list
            model_list = model_list.OrderBy(x => x.model_name).ToList();
            DropDownListModels.DataSource = model_list;
            DropDownListModels.DataTextField = "model_name";
            DropDownListModels.DataValueField = "model_id";
            DropDownListModels.DataBind();
            DropDownListModels.SelectedIndex = 0;
        }

        //=========================================================
        // Viewer
        // July 2016: deplicated.  
        // https://fieldofviewblog.wordpress.com/2015/05/06/google-chrome-drops-npapi-plugin-support/ 
        // TBD: maybe in future we will extend this portion to use Forge Viewer. 
        // If we do, however, it will be an advanced lab and not as intro. 
        //=========================================================
        protected void ButtonView_Click(object sender, EventArgs e)
        {
            string authToken = Session["authToken"] as string;
            string project_id = DropDownListProjects.SelectedValue;
            string model_id = DropDownListModels.SelectedValue;

            string url = Glue.View(authToken, project_id, model_id);

            // Show the request and response in the form. 
            TextBoxRequest.Text = url;
            TextBoxResponse.Text = "displaying model...";

            // embed a viewer in iframe 
            iframeGlue.Src = url;
        }

    }
}