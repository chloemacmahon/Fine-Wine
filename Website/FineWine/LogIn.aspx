<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="FineWine.LogIn" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h2>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="BusinessView" runat="server">
            <h2>Business Login</h2>
            <p>
                <asp:Image ID="Image1" runat="server" Height="140px" ImageUrl="~/Pictures/user.png" Width="175px" />
            </p>
            <table class="auto-style1">
                <tr>
                    <td class="td">Business Name:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtBusinessName" runat="server" CssClass="txt" Width="254px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBusinessName" CssClass="validator" ErrorMessage="RequiredFieldValidator">Please enter a business name</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td">Password:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtBusinessPassword" runat="server" CssClass="txt" Width="256px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBusinessPassword" CssClass="validator" ErrorMessage="RequiredFieldValidator">Please enter password</asp:RequiredFieldValidator>
                    </td>
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
                        <asp:Label ID="lblError" runat="server" BackColor="Red" Enabled="False" ForeColor="White" CssClass="lbl"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:View>
        <br />
        <asp:View ID="AdminView" runat="server">
            Admin Login<br />
            <asp:Image ID="Image2" runat="server" Height="140px" Width="175px" ImageUrl="~/Pictures/adminuser.png" />
            <br />
            <br />
            <asp:Label ID="lblAUserName" runat="server" CssClass="lbl" Text="User Name:"></asp:Label>
            <asp:TextBox ID="txtAUserName" runat="server" CssClass="txt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAUserName" CssClass="validator" ErrorMessage="RequiredFieldValidator">Please enter a user name</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblAPassword" runat="server" CssClass="lbl" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtAPassword" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAPassword" CssClass="validator" ErrorMessage="RequiredFieldValidator">Please enter password</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnALogIn" runat="server" CssClass="btn" OnClick="btnALogIn_Click" Text="Log In" />
            <asp:Label ID="lblError0" runat="server" BackColor="Red" CssClass="lbl" Enabled="False" ForeColor="White"></asp:Label>
        </asp:View>
    </asp:MultiView>
</h2>
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


