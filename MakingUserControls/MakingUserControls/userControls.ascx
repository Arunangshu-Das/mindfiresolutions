<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userControls.ascx.cs" Inherits="MakingUserControls.userControls" %>


<form id="form1" runat="server">
    <div class="form-floating">
        <textarea runat="server" class="form-control" placeholder="Leave a comment here" id="Textarea1" style="height: 100px"></textarea>
        <label for="floatingTextarea2">Notes</label>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="InsertButton" />


    <asp:GridView ID="GridView1"
                runat="server"
                AutoGenerateColumns="False"
                AllowSorting="True"
                AllowPaging="True"
                AllowCustomPaging="True"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                OnSorting="SortingGridView"
                PageSize="3"
                DataKeyNames="id"
                OnRowEditing="GridView1_RowEditing"
                OnRowDeleting="GridView1_RowDeleting"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>

                    <asp:TemplateField HeaderText="Note" SortExpression="note">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("note") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("note") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Object Id" SortExpression="noteid">

                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("noteid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date" SortExpression="datetimes">

                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("datetimes") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    

                    <%--<asp:BoundField DataField="StudentID" HeaderText="ID" SortExpression="StudentID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Salaryamt" HeaderText="Salary" SortExpression="Salaryamt" />--%>
                    <%--<asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />--%>
                    
                </Columns>
            </asp:GridView>


</form>



