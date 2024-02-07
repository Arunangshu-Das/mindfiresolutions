<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sum.aspx.cs" Inherits="practiceWebApp1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">First value</td>
                        <td>
                            <asp:TextBox ID="firstvalue" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Second value</td>
                        <td>
                            <asp:TextBox ID="secondvalue" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Sum</td>
                        <td>
                            <asp:TextBox ID="total" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2"></td>
                        <td>
                            <br />
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sum" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
