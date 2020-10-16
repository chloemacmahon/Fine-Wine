<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="FineWine.PlaceOrder" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <p>
    <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
        <asp:View ID="ConfirmOrderView" runat="server">
            <h2>Confirm Order Details</h2>
            <asp:ListBox ID="ListBox1" runat="server" Height="68px" Width="690px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Confirm Order" />
        </asp:View>
        <br />
        <asp:View ID="ReviewOrder" runat="server">

            <h2>Confirm Order</h2><br />

        </asp:View>
    </asp:MultiView>
    </p>
<p>
    &nbsp;</p>
</asp:Content>


