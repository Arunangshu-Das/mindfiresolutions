<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserControl.aspx.cs" Inherits="practiceWebApp1.WebForm4" %>

<%@ Register TagPrefix="arun" TagName="ad" Src="WebUserControl1.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <arun:ad id="hi" runat="server"/>
</asp:Content>
