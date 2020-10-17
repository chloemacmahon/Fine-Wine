<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="Harvest.aspx.cs" Inherits="FineWine.Harvest" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="Review" runat="server">
            <br />
            <asp:Label ID="lblSummary" runat="server" Text="SUMMARY OF HARVESTS" Font-Underline="true" ForeColor="Black" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblSuccess" runat="server" Text="Harvests For FineWine Distributors"></asp:Label>
            <br />
            <br />
            <br />
            <asp:ListBox ID="lbHarvests" runat="server" Height="256px" Width="836px"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add To Harvest" OnClick="btnAddView_Click" Width="121px"/>
            &nbsp;&nbsp;
            <asp:Button ID="btnEdit" runat="server" Text="Edit Harvest" />
            &nbsp; &nbsp;<asp:Button ID="btnWineProduction" runat="server" Text="View Wine Production Form" />
&nbsp;
            <br />
        </asp:View>
        <asp:View ID="Addview" runat="server">
            <br />
            <asp:Label ID="lblGrapeID" runat="server" Text="Select a GrapeID in the list:" ForeColor="Black"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlGrapeID" runat="server" >        
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblPlantedAmount" runat="server" Text="Enter The Amount Planted:" ForeColor="Black"></asp:Label>
            &nbsp;<asp:TextBox ID="txtAmountPlanted" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnDisplayAdd" runat="server" Text="Display Estimated Harvest Time" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
            <asp:Button ID="btnAdd0" runat="server" Height="30px" Text="Add To Harvest" />
            &nbsp;&nbsp;
            <asp:Button ID="btnEdit0" runat="server" Height="30px" Text="Edit Harvest" OnClick="btnEditView_Click" style="margin-top: 7px"/>
            &nbsp;&nbsp;
            <asp:Button ID="btnSummary0" runat="server" Text="Submit To Summary" Height="30px" />
        </asp:View>
        <asp:View ID="Editview" runat="server">
            <br />
            <asp:Label ID="lblHarvestID" runat="server" Text="Select a HarvestID in the list:" ForeColor="White"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlHarvestID" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblHarvestAmount" runat="server" Text="Enter The Actual Harvest Amount:" ForeColor="White"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnDisplayEdit" runat="server" Text="Display Harvests" OnClick="btnDisplayAll_Click"/>
            <br />
            <br />
            <br />
            <asp:GridView ID="gvHarvests" runat="server">
            </asp:GridView>
            <br />
            <br />
            &nbsp;
            <asp:Button ID="btnAdd1" runat="server" Height="30px" OnClick="btnAdd1_Click" Text="Add To Harvest" Width="121px" />
            &nbsp;&nbsp;
            <asp:Button ID="btnEdit1" runat="server" Height="30px" OnClick="btnEditView_Click" style="margin-top: 7px" Text="Edit Harvest" />
            &nbsp;&nbsp;
            <asp:Button ID="btnSUmmary1" runat="server" Text="Submit To Summary" Height="30px" />
            <br />
        </asp:View>
    </asp:MultiView>
</asp:Content>



