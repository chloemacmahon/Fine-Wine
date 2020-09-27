<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterBusiness.aspx.cs" Inherits="FineWine.RegisterBusiness" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle3 {
            font-family: "Bahnschrift Light";
            background-image: url('Pictures/Wine bottles 1.jpg');
        }
        .auto-style1 {
            font-weight: normal;
        }
        .auto-style2 {
            width: 187px;
        }
        .auto-style3 {
            margin-bottom: 6px;
        }
        .auto-style4 {
            width: 202px;
        }
        .auto-style5 {
            width: 187px;
            height: 29px;
        }
        .auto-style6 {
            width: 202px;
            height: 29px;
        }
        .auto-style7 {
            height: 29px;
        }
        .auto-style8 {
            width: 187px;
            height: 41px;
        }
        .auto-style9 {
            width: 202px;
            height: 41px;
        }
        .auto-style10 {
            height: 41px;
        }
        .auto-style11 {
            height: 35px;
        }
        .auto-style12 {
            width: 202px;
            height: 35px;
        }
    </style>
</head>
<body class="newStyle3">
    <form id="form1" runat="server" >
        <div>
            <h1><span class="auto-style1">Register Business</span></h1>
            <p>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style2">Business name:</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtBusinessName" runat="server">*</asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="#FFCCCC" ControlToValidate="txtBusinessName" ErrorMessage="Please enter business name" ForeColor="Maroon"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Password:<br />
                            </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                        <td class="auto-style8">

                            Repeat Password:</td>
                        <td class="auto-style9">
                            <asp:TextBox ID="txtRepeatPassword" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style10">&nbsp;</td>
                    <tr>
                        <td class="auto-style2">Street Number:<br />
                            </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtStreetNumber" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                            <br />
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" BackColor="#FFCCCC" ControlToValidate="txtStreetNumber" ErrorMessage="Please enter a valid number" ForeColor="Maroon" ValidationExpression="\d"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">Street Name:</td>
                        <td class="auto-style12">
                            <asp:TextBox ID="txtStreetName" runat="server" CssClass="auto-style3">*</asp:TextBox>
                        </td>
                        <td class="auto-style11">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" BackColor="#FFCCCC" ControlToValidate="txtStreetName" ErrorMessage="Please enter street name" ForeColor="Maroon"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Subburb:</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtSubburb" runat="server" OnTextChanged="TextBox7_TextChanged">*</asp:TextBox>
                            </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" BackColor="#FFCCCC" ControlToValidate="txtSubburb" ErrorMessage="Please enter subburb" ForeColor="Maroon"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>City/ Town:</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtCity" runat="server">*</asp:TextBox>
                            </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" BackColor="#FFCCCC" ControlToValidate="txtCity" ErrorMessage="Please enter city/town" ForeColor="Maroon"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Zip Code:</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                            </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" BackColor="#FFCCCC" ControlToValidate="txtZipCode" ErrorMessage="Please enter a valid zip code" ForeColor="Maroon" ValidationExpression="\d"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                        </td>
                        <td class="auto-style4">
                            <asp:Button ID="btnRegister" runat="server" BackColor="White" OnClick="btnRegister_Click" Text="Register Business" />
                        </td>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Maroon" ForeColor="White" />
                        </td>
                    </tr>
                </table>
            </p>
            <p>
                &nbsp;</p>
        </div>
    </form>
</body>
</html>
