
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxTimeDemo.aspx.cs" Inherits="AjaxDemo.AjaxTimeDemo" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>ASP.NET AJAX Demo</title>
</head>
<body>
    <form id="form1" runat="server">

        <!-- Step 1: Add ScriptManager -->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <!-- Step 2: Wrap content in UpdatePanel -->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblMessage" runat="server" Text="Click the button"></asp:Label>
                <br /><br />
                <asp:Button ID="btnUpdate" runat="server" Text="Update Time" OnClick="btnUpdate_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
