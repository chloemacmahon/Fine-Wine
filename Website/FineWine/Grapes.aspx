<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="Grapes.aspx.cs" Inherits="FineWine.Grapes" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h2>Grapes</h2>
    <p>&nbsp;</p>
    <table style="width:100%;">
       <tr>
            <td>&nbsp;</td>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View4" runat="server">
                        <asp:RadioButtonList ID="radlistGrapeOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1">
                            <asp:ListItem>Insert</asp:ListItem>
                            <asp:ListItem>Update</asp:ListItem>
                            <asp:ListItem>Delete</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </asp:View>
                    <br />
                    <br />
                    <asp:View ID="View1" runat="server">
                        <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Name"></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="txtGrapeName" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGrapeName" ErrorMessage="Please enter a grape name" CssClass="validator"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Type of Wine:"></asp:Label>
                        <asp:TextBox ID="txtType" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtType" ErrorMessage="Please enter a grape type" CssClass="validator"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Description"></asp:Label>
&nbsp;<asp:TextBox ID="txtDescrption" runat="server" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescrption" ErrorMessage="Please enter a grape description " CssClass="validator"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" CssClass="btn" />
                        &nbsp;<asp:Label ID="lblError" runat="server" CssClass="lbl"></asp:Label>
                    </asp:View>
                    <br />
                    <asp:View ID="View2" runat="server">
                        <div>
                            <asp:GridView ID="GridViewUpdate" runat="server" AutoGenerateSelectButton="True">
                            </asp:GridView>
                        </div>
                        <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Name:"></asp:Label>
&nbsp;
                        <asp:TextBox ID="txtGrapeName0" runat="server" CssClass="txt"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Type:"></asp:Label>
&nbsp;<asp:TextBox ID="txtType0" runat="server" CssClass="txt"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Description:"></asp:Label>
&nbsp;<asp:TextBox ID="txtDescrption0" runat="server" CssClass="txt"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn" />
                        <br />
                    </asp:View>
                    <br />
                    <asp:View ID="View3" runat="server">
                        <asp:GridView ID="GridViewDelete" runat="server" AutoGenerateSelectButton="True" >
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
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
