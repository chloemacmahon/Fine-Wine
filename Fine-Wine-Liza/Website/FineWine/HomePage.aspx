<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FineWine.HomePage" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="AdminHomeView" runat="server">
                            <asp:Label ID="lblWelcome" runat="server"></asp:Label>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />
                            <asp:ImageButton ID="ImageButton2" runat="server" CssClass="img" ImageUrl="~/Pictures/Grape.gif" OnClick="ImageButton2_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton4" runat="server" CssClass="img" ImageUrl="~/Pictures/Harvest1.gif" OnClick="ImageButton4_Click" />
                            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="img" ImageUrl="~/Pictures/Wine1.gif" OnClick="ImageButton3_Click" />
                            <br />
                            <br />
                            <asp:ImageButton ID="ImageButton5" runat="server" CssClass="img" ImageUrl="~/Pictures/Production.gif" OnClick="ImageButton5_Click" />
&nbsp;
                            <asp:ImageButton ID="ImageButton6" runat="server" CssClass="img" ImageUrl="~/Pictures/custom-reports-icon.png" OnClick="ImageButton6_Click" />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                        </asp:View>
                        <asp:View ID="View1" runat="server">
                            Fine wine is a emerging wine in the global wine circuit. The company was started in 2013 and started with a production of sweet red wines , the company in 2016 then started to produce a variety of white and rose wines. Fine wine was originally sold locally but in 2017 started to export to surrounding countries which then progressed to other continents such as Europe and Asia. The wine continues to be sold at the wine farm where the public can sample and buy wines and where the reserve wine is held.
                        </asp:View>
                    </asp:MultiView>
                    </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .newStyle1 {
        background-image: url('Pictures/Wine bottles 1.jpg');
    }
    .newStyle2 {
        background-image: url('Pictures/Wine bottles 1.jpg');
    }
</style>
</asp:Content>



