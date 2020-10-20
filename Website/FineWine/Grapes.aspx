<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="Grapes.aspx.cs" Inherits="FineWine.Grapes" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h2>Grapes</h2>
    <table style="width:100%;">
       <tr>
            <td>&nbsp;</td>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View4" runat="server">
                        <asp:RadioButtonList ID="radlistGrapeOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem>Insert</asp:ListItem>
                            <asp:ListItem>Update</asp:ListItem>
                            <asp:ListItem>Delete</asp:ListItem>
                            <asp:ListItem>Summary</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </asp:View>
                    <asp:View ID="Summary" runat="server">
                        <td>SUMMARY </td>
                        <br />
                        <br />
                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="true" Text="Data successfully saved to database!"></asp:Label>
                        <br />
                        <br />
                        <asp:ListBox ID="lbxGrapeSummary" runat="server" Height="222px" Width="818px" CssClass="txt"></asp:ListBox>
                        <br />
                        &nbsp;<br />&nbsp; &nbsp;
                        <br />
                        &nbsp;
                        <asp:Label ID="lblExit" runat="server" Font-Bold="true" Text="Have a FineWine day!"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btnMainSummary" runat="server" Text="Back to Main View" CssClass="btn" OnClick="btnMainSummary_Click" />
                    </asp:View>
                    <br />
                    <asp:View ID="View1" runat="server">
                        <br />
                        Enter Grape Details:<br />
                        <br />
                        <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Name"></asp:Label>
                        &nbsp;&nbsp;<asp:TextBox ID="txtGrapeName" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGrapeName" CssClass="validator" ErrorMessage="Please enter a grape name"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Type of Wine:"></asp:Label>
                        <asp:TextBox ID="txtType" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtType" CssClass="validator" ErrorMessage="Please enter a grape type"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Description"></asp:Label>
                        &nbsp;<asp:TextBox ID="txtDescription" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please enter a grape description " CssClass="validator"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" CssClass="btn" />
                        &nbsp;<asp:Button ID="btnMainSummary0" runat="server" CausesValidation="False" CssClass="btn" OnClick="btnMainSummary0_Click" Text="Back to Main View" />
                    </asp:View>
                    <br />
                    <asp:View ID="View2" runat="server">
                        <div>
                            <br />
                            Select grape record to update:<asp:GridView ID="GridViewUpdate" runat="server" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewUpdate_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" CausesValidation="False" HeaderText="Select" ShowSelectButton="True">
                                     <ControlStyle BackColor="#CCCCCC" BorderStyle="None" />
                            </asp:CommandField>
                        </Columns>
                            </asp:GridView>
                            <br />
                        </div>
                        <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Select Field to Update:"></asp:Label>
&nbsp;
                        <asp:DropDownList ID="ddlField" runat="server" CssClass="txt">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Name</asp:ListItem>
                            <asp:ListItem Value="Grape_Type">Grape Type</asp:ListItem>
                            <asp:ListItem Value="Description">Grape Description</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Enter Changes:"></asp:Label>
&nbsp;<asp:TextBox ID="txtChange" runat="server" CssClass="txt"></asp:TextBox>
                        <br />
                        &nbsp;<br />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn" />
                        &nbsp;<asp:Button ID="btnMainSummary1" runat="server" CausesValidation="False" CssClass="btn" OnClick="btnMainSummary0_Click" Text="Back to Main View" />
                        <br />
                    </asp:View>
                    <br />
                    <asp:View ID="View3" runat="server">
                        <br />
                        Select grape record to delete:<asp:GridView ID="GridViewDelete" runat="server" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewDelete_SelectedIndexChanged" >
                            <Columns>
                                    <asp:CommandField ButtonType="Button" CausesValidation="False" HeaderText="Select" ShowSelectButton="True">
                                     <ControlStyle BackColor="#CCCCCC" BorderStyle="None" />
                            </asp:CommandField>
                        </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn" />
                        &nbsp;<asp:Button ID="btnMainSummary2" runat="server" CausesValidation="False" CssClass="btn" OnClick="btnMainSummary0_Click" Text="Back to Main View" />
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
    </asp:Content>
