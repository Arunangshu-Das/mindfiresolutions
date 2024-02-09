<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostBack.aspx.cs" Inherits="practiceWebApp1.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="font-family: Arial">
    <tr>
        <td colspan = "2"><b>Employee Details Form</b></td>
    </tr>
    <tr>
        <td>First Name: </td>
        <td> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td>Last Name: </td>
        <td> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> </td>
    </tr>
    <tr>
        <td>City:</td>
        <td>
            <asp:DropDownList ID="ddlCity" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Register Employee" />
        </td>
    </tr>
</table>
    </form>
</body>
</html>
