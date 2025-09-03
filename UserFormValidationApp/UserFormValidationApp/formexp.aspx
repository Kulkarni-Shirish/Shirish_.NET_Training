<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formexp.aspx.cs" Inherits="FormExperienceApp.formexp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Experience Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>User Experience Form</h2>

        <!-- Username -->
        <asp:Label ID="lblUsername" runat="server" Text="Username: " />
        <asp:TextBox ID="txtUsername" runat="server" />
        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
            ErrorMessage="Username is required" ForeColor="Red" />

        <br /><br />

        <!-- Address -->
        <asp:Label ID="lblAddress" runat="server" Text="Address: " />
        <asp:TextBox ID="txtAddress" runat="server" />
        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
            ErrorMessage="Address is required" ForeColor="Red" />

        <br /><br />

        <!-- Date -->
        <asp:Label ID="lblDate" runat="server" Text="Date: " />
        <asp:TextBox ID="txtDate" runat="server" />
        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDate"
            ErrorMessage="Date is required" ForeColor="Red" />
        <asp:RangeValidator ID="rangeDate" runat="server" ControlToValidate="txtDate"
            ErrorMessage="Date must be between 01/01/1900 and 01/01/2090"
            MinimumValue="01/01/1900" MaximumValue="01/01/2090" Type="Date" ForeColor="Red" />

        <br /><br />

        <!-- Nationality -->
        <asp:Label ID="lblNationality" runat="server" Text="Nationality: " />
        <asp:TextBox ID="txtNationality" runat="server" />
        <asp:RequiredFieldValidator ID="rfvNationality" runat="server" ControlToValidate="txtNationality"
            ErrorMessage="Nationality is required" ForeColor="Red" />

        <br /><br />

        <!-- Country Preferred (Dropdown) -->
        <asp:Label ID="lblCountry" runat="server" Text="Preferred Country: " />
        <asp:DropDownList ID="ddlCountry" runat="server">
            <asp:ListItem Text="--Select--" Value="" />
            <asp:ListItem>India</asp:ListItem>
            <asp:ListItem>USA</asp:ListItem>
            <asp:ListItem>UK</asp:ListItem>
            <asp:ListItem>Canada</asp:ListItem>
            <asp:ListItem>Australia</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
            InitialValue="" ErrorMessage="Please select a country" ForeColor="Red" />

        <br /><br />

        <!-- Skills -->
        <asp:Label ID="lblSkills" runat="server" Text="Skill Sets: " />
        <asp:TextBox ID="txtSkills" runat="server" />
        <asp:RequiredFieldValidator ID="rfvSkills" runat="server" ControlToValidate="txtSkills"
            ErrorMessage="Skill sets are required" ForeColor="Red" />

        <br /><br />

        <!-- Submit -->
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

        <br /><br />

        <!-- Output -->
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
    </form>
</body>
</html>