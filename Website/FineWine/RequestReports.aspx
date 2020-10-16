﻿<%@ Page Language="C#" MasterPageFile="~/FineWines.Master" AutoEventWireup="true" CodeBehind="RequestReports.aspx.cs" Inherits="FineWine.RequestReports" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    
    <p>
        <br />
        <asp:RadioButtonList ID="radSortBy" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>Alphabetically</asp:ListItem>
            <asp:ListItem>Actual Production</asp:ListItem>
            <asp:ListItem>Estimated Production</asp:ListItem>
            <asp:ListItem>Percentage produced</asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p>
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
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </p>

    
</asp:Content>