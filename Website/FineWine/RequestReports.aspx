<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="RequestReports.aspx.cs" Inherits="FineWine.RequestReports" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <br />
            <asp:View ID="View1" runat="server">
            </asp:View>
            <br />
            <asp:View ID="View2" runat="server">
                <asp:RadioButtonList ID="radSortBy" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem>Alphabetically</asp:ListItem>
                    <asp:ListItem>Actual Production</asp:ListItem>
                    <asp:ListItem>Estimated Production</asp:ListItem>
                    <asp:ListItem>Percentage produced</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="btnGenerateReports" runat="server" OnClick="Button1_Click" Text="Generate reports" />
                <br />
                <br />
                <asp:ListBox ID="ListBox1" runat="server" Height="160px" Width="829px"></asp:ListBox>
                <br />
                <br />
                <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="681px">
                    <series>
                        <asp:Series ChartType="StackedColumn" Name="Series1">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </chartareas>
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
            </asp:View>
            <br />
            <asp:View ID="View3" runat="server">
                <asp:ListBox ID="ListBox2" runat="server" Width="600px"></asp:ListBox>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
            </asp:View>
            <br />
        </asp:MultiView>
    </p>

    
</asp:Content>