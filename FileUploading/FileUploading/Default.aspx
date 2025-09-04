<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUploading._Default" %>
<!--Page settings-->

<!DOCTYPE html>
<html>
<body>
    <!--Server-side form-->
    <form id="form1" runat="server">

        <!--File upload box-->
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br /><br />

        <!--Upload button-->
        <asp:Button ID="UploadButton" runat="server" Text="Upload File" OnClick="UploadButton_Click" />
        <br /><br />

        <!--Status message-->
        <asp:Label ID="StatusLabel" runat="server" Text="" ForeColor="Green" />
    </form>
</body>
</html>
