<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="Wine.aspx.cs" Inherits="FineWine.Wine" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <p>&nbsp;</p>
    <table style="width:100%;">
       <tr>
            <td>&nbsp;</td>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View4" runat="server">
                        <h2 class="auto-style2">Wines</h2>
                        <asp:RadioButtonList ID="radlistGrapeOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1">
                            <asp:ListItem>Insert</asp:ListItem>
                            <asp:ListItem>Update</asp:ListItem>
                            <asp:ListItem>Delete</asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:View>
                    <asp:View ID="InsertView" runat="server">
                        Insert New Wine<br />
                        <br />
                        <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Choose a grape type:"></asp:Label>
                        <asp:DropDownList ID="ddlGrapeName" runat="server" CssClass="btn">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Enter Wine Name:"></asp:Label>
                        <asp:TextBox ID="txtInsertName" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="validator" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtInsertName"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Enter Wine Type:"></asp:Label>
                        <asp:TextBox ID="txtInsertType" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="validator" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtInsertType"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Enter Wine Description:"></asp:Label>
                        <asp:TextBox ID="txtInsertDescription" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="validator" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtInsertDescription"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Button ID="btnInsert" runat="server" CssClass="btn" OnClick="btnInsert_Click1" Text="Insert" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnInsertSummary" runat="server" CssClass="btn" OnClick="btnInsertSummary_Click" Text="Go To Summary" />
                    </asp:View>
                    <br />
                    <asp:View ID="View2" runat="server">
                        <div>
                            <asp:GridView ID="GridViewUpdate" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbSelect" CssClass="gridview" runat="server" OnCheckedChanged="cbSelect_CheckedChanged" AutoPostBack="False" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        &nbsp;<asp:Label ID="lblUpdateName" runat="server" CssClass="lbl" Text="Name:&nbsp;" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtGrapeName0" runat="server" CssClass="txt" Visible="False"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblUpdateType" runat="server" Text="Type:" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="txtType0" runat="server" CssClass="txt"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblUpdateDescription" runat="server" Text="Description:" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="txtDescription0" runat="server" CssClass="txt" Visible="False"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="False" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdateSummary" runat="server" Text="Go To Summary" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnMainUpdate" runat="server" Text="Back to Main View" OnClick="btnMainUpdate_Click" />
                        <br />
                    </asp:View>
                    <br />
                    <asp:View ID="View3" runat="server">
                        <asp:GridView ID="GridViewDelete" runat="server" AutoGenerateSelectButton="True">
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDeleteSummary" runat="server" Text="Go To Summary" OnClick="btnMainDelete_Click" />
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
                        <asp:ListBox ID="lbxWineSummary" runat="server" Height="118px" Width="818px"></asp:ListBox>
                        <br />
                        &nbsp;<br />&nbsp; &nbsp;
                        <br />
&nbsp;
                        <asp:Label ID="lblExit" runat="server" Text="Have a FineWine day!" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="btnMainSummary" runat="server" Text="Back to Main View" OnClick="btnMainSummary_Click" />
                        <br />
                    </asp:View>
                </asp:MultiView>
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
