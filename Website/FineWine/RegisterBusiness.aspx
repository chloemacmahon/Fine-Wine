<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="RegisterBusiness.aspx.cs" Inherits="FineWine.RegisterBusiness" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h3>Register Business</h3>
    <table class="auto-style1">
        <tr>
            <td class="auto-style7">Business Name:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtBusinessName" runat="server" CssClass="txt">*</asp:TextBox>
            </td>
            <td class="validator">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="#FFCCCC" ControlToValidate="txtBusinessName" ErrorMessage="Please enter business name" ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Password:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="txt"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Repeat Password:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtRepeatPassword" runat="server" CssClass="txt"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Street Name:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtStreetName" runat="server" CssClass="txt">*</asp:TextBox>
            </td>
            <td class="validator">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" BackColor="#FFCCCC" ControlToValidate="txtStreetName" ErrorMessage="Please enter street name" ForeColor="Maroon"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Street Number:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtStreetNumber" runat="server" CssClass="txt" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
            </td>
            <td class="validator">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" BackColor="#FFCCCC" ControlToValidate="txtStreetNumber" ErrorMessage="Please enter a valid number" ForeColor="Maroon" ValidationExpression="\d"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">City/Town:</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlCityTown" runat="server" CssClass="txt">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Suburb:</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlSuburb" runat="server" CssClass="txt">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Zip Code:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="txt"></asp:TextBox>
            </td>
            <td class="validator">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" BackColor="#FFCCCC" ControlToValidate="txtZipCode" ErrorMessage="Please enter a valid zip code" ForeColor="Maroon" ValidationExpression="\d"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style6">
                <asp:Button ID="btnRegister" runat="server" BackColor="White" CssClass="btn" OnClick="btnRegister_Click" Text="Register Business" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Maroon" ForeColor="White" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" BackColor="Maroon" ForeColor="White" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" BackColor="Maroon" ForeColor="White" />
                <asp:ValidationSummary ID="ValidationSummary4" runat="server" BackColor="Maroon" ForeColor="White" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">

    .auto-style7 {
        font-size: 20px;
        text-align: right;
        width: 228px;
    }
    .auto-style5 {
        height: 33px;
        width: 286px;
    }
    
.validator
{
    font-size:20px;
    align-content:flex-start;
}

    .auto-style6 {
        width: 286px;
    }
    .auto-style4 {
        width: 228px;
    }
    </style>
</asp:Content>


