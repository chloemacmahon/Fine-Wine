<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="FineWine.PlaceOrder" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <p>
    <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
        <br />
        <asp:View ID="ReviewOrder" runat="server">

            <h2>Confirm Order</h2><br />

        </asp:View>
    </asp:MultiView>
    </p>
<p>
    &nbsp;</p>
</asp:Content>


