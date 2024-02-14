<%@ Page Title="Users Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DemoUserManagaement.Users" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        body {
            font-family: 'Verdana', sans-serif;
            font-size: 12px;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
        }

        .myGridStyle {
            border-collapse: separate;
            border-spacing: 0;
            width: 100%;
            margin-top: 20px;
            font-family: 'Roboto', sans-serif; /* Choose a futuristic font */
        }

            .myGridStyle th, .myGridStyle td {
                padding: 12px;
                text-align: left;
                border: 1px solid transparent; /* Remove border */
            }

            .myGridStyle th {
                background-color: #2E2E2E; /* Dark background for header */
                color: #FFFFFF;
                border-bottom: 2px solid #00C157; /* Add bottom border */
            }

            .myGridStyle tr:nth-child(even) {
                background-color: #353535; /* Dark background for even rows */
            }

            .myGridStyle tr:nth-child(odd) {
                background-color: #2E2E2E; /* Dark background for odd rows */
            }

            .myGridStyle tr:hover {
                transition: background-color 0.3s ease;
                background-color: #2f2f2f;
                cursor:pointer;
            }
            .myGridStyle{
                color:white;
            }
    </style>
    <asp:GridView ID="GridView1"
        runat="server"
        AutoGenerateColumns="False"
        AllowSorting="True"
        AllowPaging="True"
        AllowCustomPaging="True"
        OnPageIndexChanging="GridView1_PageIndexChanging"
        OnSorting="SortingGridView"
        PageSize="2"
        DataKeyNames="UserID"
        OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowCancelingEdit="GridView1_RowCancelingEdit"
        CssClass="myGridStyle">
        <Columns>

            <asp:TemplateField HeaderText="ID" SortExpression="UserID">

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

            <asp:TemplateField HeaderText="ProfilePhoto" SortExpression="ProfilePhoto">

                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProfilePhoto") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="Label5" Target="_blank" runat="server" Text='<%# Bind("ProfilePhoto") %>' NavigateUrl='<%# "~/upload/" + Eval("GuidProfilePhoto") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:BoundField DataField="StudentID" HeaderText="ID" SortExpression="StudentID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Salaryamt" HeaderText="Salary" SortExpression="Salaryamt" />--%>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
