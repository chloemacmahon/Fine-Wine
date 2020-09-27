<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="FineWine.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .backgroundImage {
            background-image: url('Pictures/Wine bottles 1.jpg');
            font-family: "Bahnschrift Light";
        }
        .auto-style1 {
            width: 151px;
        }
        .auto-style2 {
            width: 151px;
            text-align: right;
        }
    </style>
</head>
<body class="backgroundImage">
    <form id="form1" runat="server">
        <div>
            <h1>
                <br />
                Log In<br />
            </h1>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">Business name:</td>
                    <td>
                        <asp:TextBox ID="txtBusinessName" runat="server" Width="254px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Password:</td>
                    <td>
                        <asp:TextBox ID="txtBusinessPassword" runat="server" Width="256px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnLogIn" runat="server" BackColor="White" BorderColor="White" Text="Log in " />
&nbsp;<asp:Button ID="btnRegister" runat="server" BackColor="White" OnClick="btnRegister_Click" Text="Register Business" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
