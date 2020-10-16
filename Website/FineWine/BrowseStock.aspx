<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="BrowseStock.aspx.cs" Inherits="FineWine.BrowseStock" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h2>Stock</h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" CssClass="gridview" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  >
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSelect" CssClass="gridview" runat="server" AutoPostBack="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="View Cart" />
</p>
    <p>&nbsp;</p>
</asp:Content>


