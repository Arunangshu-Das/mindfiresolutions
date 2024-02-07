<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataListExample.aspx.cs" Inherits="practiceWebApp1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="StudentID" DataSourceID="SqlDataSource1" Height="449px" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" Width="496px">
            <ItemTemplate>
                StudentID:
                <asp:Label ID="StudentIDLabel" runat="server" Text='<%# Eval("StudentID") %>' />
                <br />
                Name:
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:crudConnectionString2 %>" ProviderName="<%$ ConnectionStrings:crudConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [Student]"></asp:SqlDataSource>
    
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
    </form>
</body>
</html>
