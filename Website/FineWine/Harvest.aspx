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
            <asp:ListBox ID="lbHarvests" runat="server" Height="256px" Width="836px" CssClass="txt"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add To Harvest" OnClick="btnAddView_Click" CssClass="btn"/>
            &nbsp;&nbsp;
            <asp:Button ID="btnEdit" runat="server" Text="Edit Harvest" OnClick="btnEdit_Click" CssClass="btn" />
            &nbsp; &nbsp;&nbsp;&nbsp;<br />
        </asp:View>
        <asp:View ID="Addview" runat="server">
            <br />
            <asp:Label ID="lblGrapeID" runat="server" Text="Select a Grape:" ForeColor="Black" CssClass="lbl"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="ddlGrape" runat="server" CssClass="txt" >        
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGrape" CssClass="validator" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblPlantedAmount" runat="server" Text="Enter The Amount Planted:" ForeColor="Black" CssClass="lbl"></asp:Label>
            &nbsp;<asp:TextBox ID="txtAmountPlanted" runat="server" TextMode="Number" CssClass="txt">10000</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmountPlanted" CssClass="validator" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            <asp:Button ID="btnAdd0" runat="server" Height="30px" Text="Add To Harvest" OnClick="btnAdd0_Click" CssClass="btn" />
            &nbsp;&nbsp;
            <asp:Button ID="btnEdit0" runat="server" Height="30px" Text="Edit Harvest" OnClick="btnEditView_Click" style="margin-top: 7px" CausesValidation="False" CssClass="btn"/>
            &nbsp;&nbsp;
            <asp:Button ID="btnSummary0" runat="server" Text="Go To Summary" Height="30px" CausesValidation="False" OnClick="btnSummary0_Click" CssClass="btn" />
        </asp:View>
        <asp:View ID="Editview" runat="server">
            <br />
            &nbsp; Enter Actual Harvest<br />
            <br />
            <asp:GridView ID="gvHarvests" runat="server" HorizontalAlign="Center" OnSelectedIndexChanged="gvHarvests_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Button" CausesValidation="False" HeaderText="Select" ShowSelectButton="True">
                     <ControlStyle BackColor="#CCCCCC" BorderStyle="None" />
                     </asp:CommandField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Select Field to Update:"></asp:Label>
            <asp:DropDownList ID="ddlField" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="ddlField_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="Amount_Planted">Amount Planted</asp:ListItem>
                <asp:ListItem Value="Date_Planted">Date Planted</asp:ListItem>
                <asp:ListItem Value="Estimated_Harvest">Estimated Harvest</asp:ListItem>
                <asp:ListItem Value="Actual_Harvest">Actual Harvest</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Enter Changes:"></asp:Label>
            <asp:TextBox ID="txtChange" runat="server" CssClass="txt"></asp:TextBox>
            <br />
            <br />
&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Height="30px" OnClick="btnUpdate_Click" Text="Update" CssClass="btn" />
            &nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Button ID="btnSUmmary1" runat="server" Height="30px" Text="Go To Summary" OnClick="btnSUmmary1_Click" CssClass="btn" />
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
    </style>
</asp:Content>




