<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="WineProduction.aspx.cs" Inherits="FineWine.WineProduction" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="SelectView" runat="server">Wine Production<br />
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem>Insert</asp:ListItem>
                <asp:ListItem>Update</asp:ListItem>
                <asp:ListItem>Summary</asp:ListItem>
            </asp:RadioButtonList>
        </asp:View>
        <asp:View ID="AddView" runat="server">Add New Production<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Select Wine Used:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlWines" runat="server" CssClass="txt">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Select Harvest:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlHarvest" runat="server" CssClass="txt">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Enter Maturation Period (in months):"></asp:Label>
            <asp:TextBox ID="txtMaturation" runat="server" CssClass="txt" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Button ID="btnInsert" runat="server" CssClass="btn" Text="Add" />
            &nbsp;&nbsp;
            <asp:Button ID="btnGoEdit" runat="server" CssClass="auto-style1" Text="Go To Update Records" OnClick="btnGoEdit_Click" Width="219px" />
            &nbsp; &nbsp;<asp:Button ID="btnSummaryGo" runat="server" CssClass="btn" Text="Go To Summary" OnClick="btnSummaryGo_Click" />
        </asp:View>
        <asp:View ID="Editview" runat="server">
            Select Wine Production Record to be Update:<br />
            <asp:GridView ID="gvWineProduction" runat="server" OnSelectedIndexChanged="gvWineProduction_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                    <asp:CommandField ButtonType="Button" CausesValidation="False" HeaderText="Select" ShowSelectButton="True">
                        <ControlStyle BackColor="#CCCCCC" BorderStyle="None" />
                    </asp:CommandField>
                </Columns>
                </asp:GridView>
            <br />
            <asp:Label ID="lblField" runat="server" CssClass="lbl" Text="Select Field to Update:"></asp:Label>
            <asp:DropDownList ID="ddlField" runat="server" CssClass="txt" OnSelectedIndexChanged="ddlField_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="Wine_ID">Wine ID</asp:ListItem>
                <asp:ListItem Value="Harvest_ID">Harvest ID</asp:ListItem>
                <asp:ListItem Value="Actual_Production">Actual Production</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblEstimatedWineProduction" runat="server" CssClass="lbl" Text="Enter/Select Changes:"></asp:Label>
            <asp:TextBox ID="txtWineProduction" runat="server" CssClass="txt" Visible="False" TextMode="Number"></asp:TextBox>
            <asp:DropDownList ID="ddlChanges" runat="server" CssClass="txt" Visible="False">
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnEdit1" runat="server" CssClass="btn" OnClick="btnEdit1_Click" Text="Update" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Go To Summary" OnClick="btnSubmit_Click" CssClass="btn"/>
        </asp:View>
        <asp:View ID="Summary" runat="server">
            <br />
            <asp:Label ID="lblSummary" runat="server" Text="SUMMARY OF WINE PRODUCTION" Font-Bold="true" Font-Underline="true"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblHarvest" runat="server" Text="Estimated Wine Production Received From Harvests"></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="lbSummaryWineProduction" runat="server" Height="300px" Width="745px" CssClass="auto-style2"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnEdit" runat="server" Text="Update Production" OnClick="btnEditView_Click" CssClass="btn"/>
            &nbsp;&nbsp;
            <asp:Button ID="btnHarvest" runat="server" Text="Go To Main" Width="220px" CssClass="btn" OnClick="btnHarvest_Click" />
            <br />
        </asp:View>
    </asp:MultiView>
</asp:Content>



<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            font-size: 20px;
            align-content: center;
        }
        .auto-style2 {
            font-size: 22px;
        }
    </style>
</asp:Content>




