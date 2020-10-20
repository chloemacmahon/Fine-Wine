<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="RegisterBusiness.aspx.cs" Inherits="FineWine.RegisterBusiness" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1" >
        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <asp:View ID="BusinessView" runat="server">
                <h1>Register Business</h1>
                <p>
                    <asp:Label ID="lblBusinessName" runat="server" CssClass="lbl" Text="Business Name:"></asp:Label>
                    <asp:TextBox ID="txtBusinessName" runat="server" CssClass="txt" ToolTip="This will be your account name used to log in "></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="#FFCCCC" ControlToValidate="txtBusinessName" CssClass="validator" ErrorMessage="Please enter business name" ForeColor="Maroon"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblBStreetName" runat="server" CssClass="lbl" Text="Street Name:"></asp:Label>
                    <asp:TextBox ID="txtStreetName" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" BackColor="#FFCCCC" ControlToValidate="txtStreetName" CssClass="validator" ErrorMessage="Please enter street name" ForeColor="Maroon"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblBStreetNumber" runat="server" CssClass="lbl" Text="Street Number:"></asp:Label>
                    <asp:TextBox ID="txtStreetNumber" runat="server" CssClass="txt" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" BackColor="#FFCCCC" ControlToValidate="txtStreetNumber" CssClass="validator" ErrorMessage="Please enter a valid number" ForeColor="Maroon" ValidationExpression="\d{3}"></asp:RegularExpressionValidator>
                </p>
                <p>
                    <asp:Label ID="lblCountry" runat="server" CssClass="lbl" Text="Country:"></asp:Label>
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" CssClass="txt" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" ToolTip="Please select a country where you reside">
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="lblBRegion" runat="server" CssClass="lbl" Text="Region/State/Province:"></asp:Label>
                    <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="True" CssClass="txt" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" ToolTip="After selecting your country please select the region where your business operates ">
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="lblBCityTown" runat="server" CssClass="lbl" Text="City/Town:"></asp:Label>
                    <asp:DropDownList ID="ddlCityTown" runat="server" CssClass="txt" ToolTip="Please select your city after you have selectedd your country and region">
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="lblBZipCode" runat="server" CssClass="lbl" Text="Zip Code:"></asp:Label>
                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" BackColor="#FFCCCC" ControlToValidate="txtZipCode" CssClass="validator" ErrorMessage="Please enter a valid zip code" ForeColor="Maroon" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                </p>
                <p>
                    <asp:Label ID="lblBPassword" runat="server" CssClass="lbl" Text="Password:"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" BorderStyle="Inset" CssClass="txt" OnTextChanged="txtPassword_TextChanged" TextMode="Password" ToolTip="Please enter a strong password that unique to this account"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" CssClass="validator" ErrorMessage="Please enter a password"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblBConfirmPass" runat="server" CssClass="lbl" Text="Confirm Password:"></asp:Label>
                    <asp:TextBox ID="txtRepeatPassword" runat="server" CssClass="txt" OnTextChanged="txtRepeatPassword_TextChanged" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtRepeatPassword" CssClass="validator" ErrorMessage="CompareValidator">Passwords don&#39;t match</asp:CompareValidator>
                </p>
                <p>
                    <asp:Button ID="btnRegister" runat="server" BackColor="White" CssClass="btn" OnClick="btnRegister_Click" Text="Register Business" />
                    <asp:Label ID="lblError" runat="server" BackColor="Red" Enabled="False" ForeColor="White"></asp:Label>
                </p>
            </asp:View>
            <asp:View ID="AdminView" runat="server">
                <h1>Register Admin</h1>
                <p>
                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="User Name:"></asp:Label>
                    <asp:TextBox ID="txtAUserName" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAUserName" CssClass="validator" ErrorMessage="RequiredFieldValidator">Please enter user name</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Password:"></asp:Label>
                    <asp:TextBox ID="txtAPassword" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAPassword" CssClass="validator" ErrorMessage="RequiredFieldValidator">Please enter password</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="Label3" runat="server" Text="Confirm Password:"></asp:Label>
                    <asp:TextBox ID="txtAConfirm" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtAPassword" ControlToValidate="txtAConfirm" CssClass="validator" ErrorMessage="CompareValidator">Passwords don&#39;t match</asp:CompareValidator>
                </p>
                <p>
                    <asp:Button ID="btnARegister" runat="server" CssClass="btn" OnClick="btnARegister_Click" Text="Register" />
                </p>
            </asp:View>
        </asp:MultiView>
    
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">

    .validator
{
    font-size:20px;
    align-content:flex-start;
}

    </style>
</asp:Content>


