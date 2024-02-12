<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notes.ascx.cs" Inherits="DemoUserManagaement.Notes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-floating">
            <textarea runat="server" class="form-control" placeholder="Leave a comment here" id="Textarea1" style="height: 100px"></textarea>
            <label for="floatingTextarea2">Notes</label>
        </div>
        <asp:Button ID="Button3" runat="server" Text="Insert" OnClick="InsertButton" />
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
                DataKeyNames="NoteID"
                OnRowEditing="GridView1_RowEditing"
                OnRowDeleting="GridView1_RowDeleting"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
                     
                    <asp:TemplateField HeaderText="NoteID" SortExpression="NoteID">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox0" runat="server" Text='<%# Bind("NoteID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label0" runat="server" Text='<%# Bind("NoteID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="NoteText" SortExpression="NoteText">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NoteText") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NoteText") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="TimeStamp" SortExpression="TimeStamp">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TimeStamp") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <%--<asp:BoundField DataField="StudentID" HeaderText="ID" SortExpression="StudentID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Salaryamt" HeaderText="Salary" SortExpression="Salaryamt" />--%>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
