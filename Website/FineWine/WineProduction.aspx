<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="WineProduction.aspx.cs" Inherits="FineWine.WineProduction" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="Editview" runat="server">
            <br />
            <asp:Label ID="lblHarvestID" runat="server" Text="Choose harvest to display below:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlHarvestID" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblEstimatedWineProduction" runat="server" Text="Enter The Estimated Wine Production:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtWineProduction" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnDisplayWineProd" runat="server" Text="Display Estimated Wine Production" OnClick="btnDisplayWineProd_Click" />
            <br />
            <br />
            <asp:GridView ID="gvWineProduction" runat="server" OnSelectedIndexChanged="gvWineProduction_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit To Summary" OnClick="btnSubmit_Click"/>
        </asp:View>
        <asp:View ID="Summary" runat="server">
            <br />
            <asp:Label ID="lblSummary" runat="server" Text="SUMMARY OF WINE PRODUCTION" Font-Bold="true" Font-Underline="true"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblHarvest" runat="server" Text="Estimated Wine Production Received From Harvests"></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="lbSummaryWineProduction" runat="server" Height="300px" Width="560px"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnEdit" runat="server" Text="Edit Wine Production" OnClick="btnEditView_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="btnHarvest" runat="server" Text="View Harvest Form" Width="220px" />
            <br />
        </asp:View>
    </asp:MultiView>
</asp:Content>



