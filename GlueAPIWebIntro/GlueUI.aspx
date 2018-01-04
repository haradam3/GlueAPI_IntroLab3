<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlueUI.aspx.cs" Inherits="GlueAPIWebIntro.GlueUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Glue API Web Intro</title>
    <style type="text/css">
        #form1
        {
            height: 171px;
            width: 657px;
        }
        body
        {
            background-color:#e6e0f1; 
        }
        h1
        {
            color:#2a2e74; /*orange*/  
            text-align: center;
        }
        #iframeGlue
        {
            height: 442px;
            width: 561px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>My First Glue API</h1>
    </div>
        User Name&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxUserName" runat="server" Width="400px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" Width="80px" />
        &nbsp;<br />
        <br />
        Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="400px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonLogout" runat="server" Text="Logout" Width="80px" Enabled="False" OnClick="ButtonLogout_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />

        <div style="width: 659px">
            Project&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:DropDownList ID="DropDownListProjects" runat="server" Width="400px" OnSelectedIndexChanged="DropDownListProjects_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonProject" runat="server" OnClick="ButtonProject_Click" Text="Project" Width="80px" />
            <br />
            <br />
            Model&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownListModels" runat="server" Width="400px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp; <asp:Button ID="ButtonModel" runat="server" OnClick="ButtonModel_Click" Text="Model" Width="80px" />
            <br />
            &nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="LabelRequest" runat="server" Text="Request"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxRequest" runat="server" Height="50px" TextMode="MultiLine" Width="600px"></asp:TextBox>
            <br />
            <br />
            Response&nbsp;&nbsp;&nbsp; <asp:Label ID="LabelStatus" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxResponse" runat="server" Height="100px" Width="600px" TextMode="MultiLine"></asp:TextBox>
        </div>

        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonView" runat="server" OnClick="ButtonView_Click" Text="View" Width="80px" />
        <br />
        <iframe id="iframeGlue" title="BIM 360 Glue Display Component" src="" runat="server"></iframe>

    </form>
</body>
</html>
 