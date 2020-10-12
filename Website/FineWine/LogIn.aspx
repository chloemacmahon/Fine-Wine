<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="FineWine.LogIn" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h2>Login</h2>
<table class="auto-style1">
    <tr>
        <td class="td">Business Name:</td>
        <td class="auto-style3">
            <asp:TextBox ID="txtBusinessName" runat="server" CssClass="txt" Width="254px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="td">Password:</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtBusinessPassword" runat="server" CssClass="txt" Width="256px"></asp:TextBox>
        </td>
        <td class="auto-style6"></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="btn">
            <asp:Button ID="btnLogIn" runat="server" BackColor="White" BorderColor="White" CssClass="btn" OnClick="btnLogIn_Click" Text="Log in " />
            <br />
            <br />
            <asp:Button ID="btnRegister" runat="server" BackColor="White" CssClass="btn" OnClick="btnRegister_Click" Text="Register Business" />
        </td>
        <td>
            <asp:Label ID="lblError" runat="server" BackColor="Red" Enabled="False" ForeColor="White"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">


.td
{
    font-size:20px;
    text-align:right;
    font:bold;
}

    .auto-style3 {
        width: 292px;
    }
    .auto-style5 {
        width: 292px;
        height: 33px;
    }
    .auto-style6 {
        height: 33px;
    }
    .auto-style2 {
        width: 231px;
    }
    
.btn
{
    font-size:20px;
    align-content:center;
    width:200px;
}

</style>
</asp:Content>


