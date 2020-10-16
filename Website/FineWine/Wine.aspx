<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="Wine.aspx.cs" Inherits="FineWine.Wine" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h2>&nbsp;</h2>
    <p>&nbsp;</p>
    <table style="width:100%;">
       <tr>
            <td>&nbsp;</td>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <br />
                    <asp:View ID="View4" runat="server">
                        <h2 class="auto-style2">Wines</h2>
                        <asp:RadioButtonList ID="radlistGrapeOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1">
                            <asp:ListItem>Insert</asp:ListItem>
                            <asp:ListItem>Update</asp:ListItem>
                            <asp:ListItem>Delete</asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:View>
                    <br />
                    <br />
                    <asp:View ID="View1" runat="server">
                        <h2 class="auto-style2">Wines</h2>
                        <asp:GridView ID="GridViewInsert" runat="server" AutoGenerateSelectButton="True">
                        </asp:GridView>
                        <br />
                        Please select the grape used to produce this wine
                        <br />
                        Name:&nbsp;
                        <asp:TextBox ID="txtGrapeName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGrapeName" ErrorMessage="Please enter a grape name"></asp:RequiredFieldValidator>
                        <br />
                        Type:
                        <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtType" ErrorMessage="Please enter a grape type"></asp:RequiredFieldValidator>
                        <br />
                        Description:
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescrption" ErrorMessage="Please enter a grape description "></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                        &nbsp;<asp:Label ID="lblError" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnMainInsert" runat="server" Text="Back to Main View" OnClick="btnMainInsert_Click" />
                    </asp:View>
                    <br />
                    <asp:View ID="View2" runat="server">
                        <div>
                            <asp:GridView ID="GridViewUpdate" runat="server" AutoGenerateSelectButton="True">
                            </asp:GridView>
                        </div>
                        Name:&nbsp;
                        <asp:TextBox ID="txtGrapeName0" runat="server"></asp:TextBox>
                        <br />
                        Type:
                        <asp:TextBox ID="txtType0" runat="server"></asp:TextBox>
                        <br />
                        Description:
                        <asp:TextBox ID="txtDescription0" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnMainUpdate" runat="server" Text="Back to Main View" OnClick="btnMainUpdate_Click" />
                        <br />
                    </asp:View>
                    <br />
                    <asp:View ID="View3" runat="server">
                        <asp:GridView ID="GridViewDelete" runat="server" AutoGenerateSelectButton="True">
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Button ID="btnMainDelete" runat="server" Text="Submit" OnClick="btnMainDelete_Click" />
                    </asp:View>
                    <br />
                    <asp:View ID="Summary" runat="server">
                        <br />
                        <td>
                            SUMMARY
                        </td>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblSuccess" runat="server" Text="Data successfully saved to database!" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblInsert" runat="server" Text="Summary For Insert" Font-Italic="true" Font-Underline="true"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblSummaryGrapeNameInsert" runat="server" Text="Grape Name:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblGrapeNameInsert" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblSummaryTypeInsert" runat="server" Text="Type:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblTypeInsert" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblSummaryDescriptionInsert" runat="server" Text="Description:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblDescriptionInsert" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblUpdate" runat="server" Text="Summary For Update" Font-Italic="true" Font-Underline="true"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblSummaryGrapeNameUpdate" runat="server" Text="Grape Name:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblGrapeNameUpdate" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblSummaryTypeUpdate" runat="server" Text="Type:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblTypeUpdate" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblSummaryDescriptionUpdate" runat="server" Text="Description:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblDescriptionUpdate" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblDelete" runat="server" Text="Summary For Delete" Font-Italic="true" Font-Underline="true"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblSummaryGrapeNameDelete" runat="server" Text="Grape Name:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblGrapeNameDelete" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblSummaryTypeDelete" runat="server" Text="Type:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblTypeDelete" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblSummaryDescriptionDelete" runat="server" Text="Description:"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblDescriptionDelete" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblExit" runat="server" Text="Have a FineWine day!" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="btnMainSummary" runat="server" Text="Back to Main View" OnClick="btnMainSummary_Click" />
                        <br />
                    </asp:View>
                </asp:MultiView>
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            font-weight: normal;
        }
    </style>
</asp:Content>
