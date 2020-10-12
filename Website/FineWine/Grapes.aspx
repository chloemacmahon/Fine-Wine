<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="Grapes.aspx.cs" Inherits="FineWine.Grapes" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h2>Grapes</h2>
    <p>
        <asp:RadioButtonList ID="radlistGrapeOptions" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1">
            <asp:ListItem>Insert</asp:ListItem>
            <asp:ListItem>Update</asp:ListItem>
            <asp:ListItem>Delete</asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <table style="width:100%;">
       <tr>
            <td>&nbsp;</td>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <br />
                    <asp:View ID="View1" runat="server">
                        Name:&nbsp;
                        <asp:TextBox ID="txtGrapeName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGrapeName" ErrorMessage="Please enter a grape name"></asp:RequiredFieldValidator>
                        <br />
                        Type:
                        <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtType" ErrorMessage="Please enter a grape type"></asp:RequiredFieldValidator>
                        <br />
                        Description:
                        <asp:TextBox ID="txtDescrption" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescrption" ErrorMessage="Please enter a grape description "></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                        &nbsp;<asp:Label ID="lblError" runat="server"></asp:Label>
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
                        <asp:TextBox ID="txtDescrption0" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <br />
                    </asp:View>
                    <br />
                    <asp:View ID="View3" runat="server">
                        <asp:GridView ID="GridViewDelete" runat="server" AutoGenerateSelectButton="True">
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
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
            height: 233px;
        }
    </style>
</asp:Content>
