<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViews.aspx.cs" Inherits="practiceWebApp1.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>STUDENT TABLE</h1>
            <asp:GridView ID="GridView1"
                runat="server"
                AutoGenerateColumns="False"
                AllowSorting="True"
                AllowPaging="True"
                AllowCustomPaging="True"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                OnSorting="SortingGridView"
                PageSize="3"
                DataKeyNames="StudentID"
                OnRowEditing="GridView1_RowEditing"
                OnRowDeleting="GridView1_RowDeleting"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>

                    <asp:TemplateField HeaderText="ID" SortExpression="StudentID">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox0" runat="server" Text='<%# Bind("StudentID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label0" runat="server" Text='<%# Bind("StudentID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name" SortExpression="Name">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email" SortExpression="Email">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Salaryamt" SortExpression="Salaryamt">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Salaryamt") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Salaryamt") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:BoundField DataField="StudentID" HeaderText="ID" SortExpression="StudentID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Salaryamt" HeaderText="Salary" SortExpression="Salaryamt" />--%>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <div>
                <label>Name</label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <label>Email</label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <label>Salaryamt</label>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="InsertButton" />
                <%--                <asp:Button ID="Button3" runat="server" Text="Update" OnClick="UpdateButton" />
                <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="DeleteButton" />--%>
                <asp:Button ID="Button2" runat="server" Text="Reset" OnClick="ResetButton" />
            </div>
        </div>
    </form>
</body>
</html>
