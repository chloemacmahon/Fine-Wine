<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="FineWine.PlaceOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle3 {
            font-family: "Bahnschrift Light";
            background-image: url('Pictures/WineCorks3.jpg');
            color: #FFFFFF;
            background-repeat: no-repeat;
        }
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: 50pt;
            font-weight: normal;
        }
    </style>
</head>
<body class="newStyle3">
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1"><span class="auto-style2">Place Order</span><br />
            </h1>
        </div>
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" Width="1043px">
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
