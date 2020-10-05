<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="FineWine.PlaceOrder" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h4>Place Order</h4>
<p>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
    </asp:CheckBoxList>
</p>
<p>
    <asp:Button ID="Button1" runat="server" Text="Place Order" OnClick="Button1_Click" CssClass="btn" />
</p>
</asp:Content>


