<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="RequestReports.aspx.cs" Inherits="FineWine.RequestReports" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    
    <p>
        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <br />
            <asp:View ID="View1" runat="server">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>Production</asp:ListItem>
                    <asp:ListItem>Top 10 Sales</asp:ListItem>
                </asp:RadioButtonList>
            </asp:View>
            <br />
            <asp:View ID="View2" runat="server">
                Choose report format:<br />
                <br />
                <asp:RadioButtonList ID="radSortBy" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatLayout="Flow">
                    <asp:ListItem>Alphabetically</asp:ListItem>
                    <asp:ListItem>Actual Production</asp:ListItem>
                    <asp:ListItem>Estimated Production</asp:ListItem>
                    <asp:ListItem>Percentage produced</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <br />
                <asp:Button ID="btnGenerateReports" runat="server" OnClick="Button1_Click" Text="Generate reports" CssClass="btn" />
                <br />
                <br />
                <asp:ListBox ID="ListBox1" runat="server" Height="308px" Width="869px"></asp:ListBox>
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
                <br />
                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="Top 10 Sales Report" />
                <br />
            </asp:View>
            <br />
            <asp:View ID="View3" runat="server">
                <br />
                <h1>Top 10 Sales</h1>
                <br />
                <asp:ListBox ID="ListBox2" runat="server" Width="796px" Height="257px" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged" CssClass="txt"></asp:ListBox>
                <br />
                <br />
            </asp:View>
            <br />
        </asp:MultiView>
    </p>

    
</asp:Content>