<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notes.ascx.cs" Inherits="DemoUserManagaement.Notes" %>

<div class="w-100">
    <label for="floatingTextarea2" class="form-label">Notes</label>
    <textarea runat="server" class="form-control" placeholder="Leave a comment here" id="Textarea1" cols="40"></textarea>
</div>
<div class="d-grid gap-2 d-md-flex justify-content-center">
    <button type="button" class="btn btn-primary mt-3" id="Button3" onclick="InsertButton()">Insert</button>
</div>
<div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h3>ALL NOTES</h3>
            <asp:GridView ID="GridView1"
                runat="server"
                AutoGenerateColumns="False"
                AllowSorting="True"
                OnSorting="SortingGridView"
                AllowPaging="True"
                AllowCustomPaging="True"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                PageSize="3"
                DataKeyNames="NoteID"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                CssClass="table table-striped table-bordered table-hover">
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
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("TimeStamp", "{0:dd/MM/yyyy hh:mm tt}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <%--<asp:BoundField DataField="StudentID" HeaderText="ID" SortExpression="StudentID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Salaryamt" HeaderText="Salary" SortExpression="Salaryamt" />--%>
                    <%--<asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />--%>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<script>
    function InsertButton() {
        var jsonObject = {};
        jsonObject['NoteText'] = $("#Textarea1").val();
        var urlParams = new URLSearchParams(window.location.search);

        // Replace "id" with the name of your parameter
        var parameterValue = urlParams.get('id');
        jsonObject['ObjectID'] = parameterValue;
        PageMethods.NoteSave(jsonData, onSucess, onError);

        function onSucess(result) {
        }

        function onError(result) {
        }
    }
</script>
