<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FineWine.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>"Home"</title>
    <link rel="stylesheet" type ="text/css" href="CSS files/HomePageStyle.css" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .newStyle2 {
            background-image: url('Pictures/Background8.jpg');
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-position: center center;
        }
    </style>
</head>
    <body class="newStyle2">
    <form id="form1" runat="server">
        <div>
                <div class="auto-style1">
                    <h1>
                        Fine Wine</h1>
            </div>
                <table style="width:100%;" >
                    <tr>
                        <td>&nbsp;</td>
                        <td style="text-align: right">
                            <asp:Button ID="btnLogIn" runat="server" Text="Log In" CssClass="buttonstyle" Height="31px" Width="82px" />
                        </td>
                        <td style="text-align: right">&nbsp;
                            &nbsp;
                            <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="buttonstyle" Height="29px" Width="111px" />
&nbsp; </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                        <td class="auto-style1 backwhite">Fine wine is a emerging wine in the global wine circuit. The company was started in 2013 and started with a production of sweet red wines , the company in 2016 then started to produce a variety of white and rose wines. Fine wine was originally sold locally but in 2017 started to export to surrounding countries which then progressed to other continents such as Europe and Asia. The wine continues to be sold at the wine farm where the public can sample and buy wines and where the reserve wine is held.</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
            </h1>
        </div>
    </form>
</body>
</html>
