<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Practice.aspx.cs" Inherits="practiceWebApp1.Practice" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
        <div>  
            <asp:Label ID="labelId" runat="server">User Name</asp:Label>  
<asp:TextBox ID="UserName" runat="server" ToolTip="Enter User Name"></asp:TextBox>  
        </div>  
        <p>  
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" />  
        </p>  
        <br />   

</asp:Content>