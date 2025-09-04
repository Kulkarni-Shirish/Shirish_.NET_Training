<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="FlowerSelector._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flower Selection</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial; padding:20px;">

            <!-- RadioButtonList showing flowers in two columns -->
            <asp:RadioButtonList 
                ID="rblFlower" 
                runat="server" 
                RepeatColumns="2" 
                RepeatDirection="Horizontal">
                <asp:ListItem>Rose</asp:ListItem>
                <asp:ListItem>Lily</asp:ListItem>
                <asp:ListItem>Sunflower</asp:ListItem>
                <asp:ListItem>Jasmine</asp:ListItem>
                <asp:ListItem>Orchid</asp:ListItem>
                <asp:ListItem>Tulip</asp:ListItem>
            </asp:RadioButtonList>

            <br />

            <!-- Button triggers showing the selected flower -->
            <asp:Button ID="btnShowSelection" runat="server" 
                        Text="Show Selected Flower" 
                        OnClick="btnShowSelection_Click" />

            <br /><br />

            <!-- Label displays result -->
            <asp:Label ID="lblResult" runat="server" 
                       Font-Bold="true" ForeColor="DarkBlue"></asp:Label>
        </div>
    </form>
</body>
</html>
