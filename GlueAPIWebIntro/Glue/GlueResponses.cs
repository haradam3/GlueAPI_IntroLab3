#region Copyright
//
// Copyright (C) 2013-2018 by Autodesk, Inc.
//
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
#endregion // Copyright

using System;
using System.Collections.Generic;

namespace GlueAPIIntro
{
    // These classes are to parse a response body. 
    // Strongly typed mapping. You may choose to use other utilities. 
    // These are same as two SDK samples (with minor modifications to make it simpler).  

    //=================================================================
    // For Login response
    // Doc
    // http://b4.autodesk.com/api/security/v1/login/doc
    //=================================================================

    [Serializable]
  public class LoginResponse
  {
     public string auth_token { get; set; }
     public string user_id { get; set; }
  }

  //=================================================================
  // For Project List 
  // Doc
  // http://b4.autodesk.com/api/project/v1/list/doc
  //=================================================================

  [Serializable]
  public class ProjectListResponse
  {
    public List<Project> project_list { get; set; }

    // General Description of result set
    public int page { get; set; }
    public int page_size { get; set; }
    public int total_result_size { get; set; }
    public int more_pages { get; set; }

    // The list of project info 
    //public project_info_response_v1[] project_list;
  }

  public class Project
  {
     public string project_id { get; set; }
     public string project_name { get; set; }
     public string company_id { get; set; }
     public string created_date { get; set; }
     public string modify_date { get; set; }
     public string modify_user { get; set; }
     public string start_date { get; set; }
     public string end_date { get; set; }
     public string thumbnail_modified_date { get; set; }
     public string has_views { get; set; }
     public string has_markups { get; set; }
     public string has_clashes { get; set; }
     public string last_activity_date { get; set; }
  }

  //=================================================================
  // For Model List
  // (This isn't in the two SDK samples.)
  // Doc
  // http://b4.autodesk.com/api/model/v1/list/doc
  //=================================================================

  [Serializable]
  public class ModelListResponse
  {
    // The user list for the project
    public List<ModelInfo> model_list { get; set;}     
     
    // General Description of result set
    public int page { get; set; }
    public int page_size { get; set; }
    public int total_result_size { get; set; }
    public int more_pages { get; set; }

  }

  [Serializable]
  public class ModelInfo
  {
    // This is the model_file information for the BIM 360 Glue Model
    //public string action_id { get; set; }
    public string company_id { get; set; }
    public string project_id { get; set; }
    public string model_id { get; set; }
    public int model_version { get; set; }
    public string model_version_id { get; set; }
    public string model_name { get; set; }
    public string created_by { get; set; }
    public string created_date { get; set; }
    public string modified_by { get; set; }
    public string modified_date { get; set; }
    public string parent_folder_id { get; set; }
    // public int is_folder { get; set; }
    public int file_parsed_status { get; set; }

    // Support for merged model streaming
    //public int merged_model_available { get; set; }
    //public string merged_model_parsing_status { get; set; }

    // Other General Info
    public int is_merged_model { get; set; }
    public int is_folder { get; set; }
    public int is_deleted { get; set; }
    public int metadata_version { get; set; }
    public string file_units { get; set; }
    public int published { get; set; }

    //public glue_folder_node[] merged_submodels { get; set; }

    // Version Information
    //public model_history[] version_history;

    // Clash reports for the project
    //public model_clash_report[] clash_reports { get; set; }

    // Views/Markups for the model
    //public model_view_node[] view_tree { get; set; }
  }

}
