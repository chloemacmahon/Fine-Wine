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
                        <asp:RadioButtonList ID="radlistWineOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem>Insert</asp:ListItem>
                            <asp:ListItem>Update</asp:ListItem>
                            <asp:ListItem>Delete</asp:ListItem>
                            <asp:ListItem>Summary</asp:ListItem>
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
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnMainDelete1" runat="server" CssClass="btn" OnClick="btnMainUpdate_Click" Text="Back to Main View" />
                    </asp:View>
                    <br />
                    <asp:View ID="View2" runat="server">
                        <div>
                            <br />
                            Select wine record to update:<asp:GridView ID="GridViewUpdate" runat="server" HorizontalAlign="Center">
                                <Columns>
                                   <asp:CommandField ButtonType="Button" CausesValidation="False" HeaderText="Select" ShowSelectButton="True">
                                    <ControlStyle BackColor="#CCCCCC" BorderStyle="None" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        &nbsp;<br />&nbsp;<asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Select Field to Update:"></asp:Label>
                        <asp:DropDownList ID="ddlField" runat="server" CssClass="txt">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Name</asp:ListItem>
                            <asp:ListItem Value="Wine_Type">Wine Type</asp:ListItem>
                            <asp:ListItem Value="Description">Wine Description</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Enter Changes:"></asp:Label>
                        &nbsp;<asp:TextBox ID="txtChange" runat="server" CssClass="txt"></asp:TextBox>
                        &nbsp;<br />&nbsp;&nbsp;<br />&nbsp;<asp:Button ID="btnUpdate" runat="server" CssClass="btn" OnClick="btnUpdate_Click" Text="Update" Visible="False" />
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnMainDelete0" runat="server" CssClass="btn" OnClick="btnMainUpdate_Click" Text="Back to Main View" />
                    </asp:View>
                     <asp:View ID="View3" runat="server">
                         <br />
                         Select wine record to delete:<asp:GridView ID="GridViewDelete" runat="server" HorizontalAlign="Center" >
                            <Columns>
                                <asp:CommandField ButtonType="Button" CausesValidation="False" HeaderText="Select" ShowSelectButton="True">
                                    <ControlStyle BackColor="#CCCCCC" BorderStyle="None" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn" />
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnMainDelete" runat="server" CssClass="btn" OnClick="btnMainUpdate_Click" Text="Back to Main View" />
                    </asp:View>

                    <asp:View ID="Summary" runat="server">
                        <td>
                            SUMMARY
                        </td>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblSuccess" runat="server" Text="Data successfully saved to database!" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                        <asp:ListBox ID="lbxWineSummary" runat="server" Height="225px" Width="818px" CssClass="txt"></asp:ListBox>
                        <br />
                        &nbsp;<br />&nbsp; &nbsp;
                        <br />
&nbsp;
                        <asp:Label ID="lblExit" runat="server" Text="Have a FineWine day!" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="btnMainSummary" runat="server" Text="Back to Main View" OnClick="btnMainSummary_Click" CssClass="btn" />
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
