<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="BrowseStock.aspx.cs" Inherits="FineWine.BrowseStock" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h2>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="Browse" runat="server">
                <h2>Stock</h2>
                <p>
                    <asp:GridView ID="GridView1" runat="server" CssClass="gridview" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ButtonType="Button" CausesValidation="False" HeaderText="Select" ShowSelectButton="True">
                            <ControlStyle BackColor="#CCCCCC" BorderStyle="None" />
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </p>
                <p>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="View Cart" />
                </p>
            </asp:View>
            <asp:View ID="ConfirmOrderView" runat="server">
                <h2>Confirm Order Details</h2>
                <asp:ListBox ID="ListBox1" runat="server" Height="160px" Width="864px"></asp:ListBox>
                <br />
                <br />
                <asp:Table ID="Table1" runat="server" Height="69px" HorizontalAlign="Center" Width="664px">
                </asp:Table>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Confirm Order" />
            </asp:View>
        </asp:MultiView>
    </h2>
    <p>&nbsp;</p>
</asp:Content>


