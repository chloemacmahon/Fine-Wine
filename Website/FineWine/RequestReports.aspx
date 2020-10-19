<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="RequestReports.aspx.cs" Inherits="FineWine.RequestReports" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:MultiView ID="MultiView1" runat="server">
            <br />
            <asp:View ID="View1" runat="server">
                <asp:RadioButtonList ID="radReport" runat="server">
                    <asp:ListItem>Production Reports</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
            </asp:View>
            <br />
            <br />
            <asp:View ID="View2" runat="server">
                <asp:RadioButtonList ID="radSortBy" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem>Alphabetically</asp:ListItem>
                    <asp:ListItem>Actual Production</asp:ListItem>
                    <asp:ListItem>Estimated Production</asp:ListItem>
                    <asp:ListItem>Percentage produced</asp:ListItem>
                    <asp:ListItem>Net produced</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                <br />
                <br />
                <asp:ListBox ID="ListBoxReport" runat="server"></asp:ListBox>
                <br />
                <br />
                <asp:Chart ID="Chart1" runat="server" EnableViewState="True" ImageStorageMode="UseImageLocation">
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <br />
                <br />
                <asp:Chart ID="Chart2" runat="server">
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <br />
                <br />
            </asp:View>
            <br />
            <br />
            <asp:View ID="View3" runat="server">
            </asp:View>
            <br />
        </asp:MultiView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>

    
</asp:Content>