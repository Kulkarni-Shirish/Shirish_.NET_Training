<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdRotatorDemo._Default" %>
<!DOCTYPE html>
<html>
<body>
    <form id="form1" runat="server">
        <h2>ASP.NET Ad Rotator Example</h2>

        <!-- AdRotator control -->
        <asp:AdRotator 
            ID="AdRotator1" 
            runat="server" 
            AdvertisementFile="~/Ads.xml" 
            Target="_blank" 
            Width="300px" 
            Height="200px" />
    </form>
</body>
</html>
