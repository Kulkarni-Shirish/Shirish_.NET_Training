<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YourProjectNamespace._Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Notifications Panel</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Notifications Panel</h2>

        <!-- Panel styled as a notification box -->
        <asp:Panel ID="NotificationPanel" runat="server" 
                   BackColor="#f9f9f9" 
                   BorderColor="#cccccc"
                   BorderStyle="Solid" 
                   BorderWidth="2px" 
                   Height="180px" 
                   Width="350px" 
                   ScrollBars="Vertical">

            <!-- Title inside panel -->
            <asp:Label ID="lblTitle" runat="server" 
                       Text="Latest Notifications"
                       Font-Bold="true" 
                       Font-Size="Large" 
                       ForeColor="#333333"></asp:Label>
            <hr />

            <!-- Notifications will be added dynamically -->
            <asp:BulletedList ID="NotificationList" runat="server" 
                              BulletStyle="Disc" 
                              Font-Names="Arial" 
                              Font-Size="Medium"
                              ForeColor="#444444">
            </asp:BulletedList>
        </asp:Panel>

        <br />

        <!-- Refresh button to add more messages -->
        <asp:Button ID="btnLoad" runat="server" Text="Load Notifications" OnClick="btnLoad_Click" />

    </form>
</body>
</html>
