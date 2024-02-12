<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DemoUserManagaement.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">    body {        font-family: 'Verdana', sans-serif;        font-size: 12px;        margin: 0;        padding: 0;        background-color: #f5f5f5;    }    .myGridStyle {        border-collapse: collapse;        width: 100%;        margin-top: 20px;    }    .myGridStyle th, .myGridStyle td {        padding: 12px;        text-align: left;        border: 1px solid #dddddd;    }    .myGridStyle th {        background-color: #4CAF50;        color: white;    }    .myGridStyle tr:nth-child(even) {        background-color: #E1FFEF;    }    .myGridStyle tr:nth-child(odd) {        background-color: #00C157;    }</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1"
            runat="server"
            AutoGenerateColumns="False"
            AllowSorting="True"
            AllowPaging="True"
            AllowCustomPaging="True"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            OnSorting="SortingGridView"
            PageSize="1"
            DataKeyNames="UserID"
            OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            CssClass="myGridStyle"
            >
            <Columns>

                <asp:TemplateField HeaderText="ID" SortExpression="StudentID">

                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox0" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label0" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">

                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="LastName" SortExpression="LastName">

                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email" SortExpression="Email">

                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ContactNumber" SortExpression="ContactNumber">

                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ContactNumber") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ContactNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hobbies" SortExpression="Hobbies">

                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Hobbies") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Hobbies") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--<asp:BoundField DataField="StudentID" HeaderText="ID" SortExpression="StudentID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Salaryamt" HeaderText="Salary" SortExpression="Salaryamt" />--%>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
