<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notes.ascx.cs" Inherits="DemoUserManagaement.Notes" %>

<div>
    <div class="w-100">
        <label for="floatingTextarea2" class="form-label">Notes</label>
        <textarea class="form-control" placeholder="Leave a comment here" id="Textarea1" cols="40"></textarea>
        <input type="hidden" id="noteid" >
    </div>
    <div class="d-grid gap-2 d-md-flex justify-content-center">
        <button id="Button1" class="btn btn-primary mt-3" onclick="Insert()">Insert</button>
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
        $(document).ready(function () {
            var urlParams = new URLSearchParams(window.location.search);
            document.getElementById("noteid").Text = urlParams.get('id');
        });
        function Insert() {
            var textarea = document.getElementById("Textarea1").value;

            var note = {
                NoteText: textarea,
                ObjectID: parseInt(document.getElementById("noteid").Text)
            };

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Register.aspx/SaveNotes",
                data: JSON.stringify({ note: note }), // send the note as a property
                dataType: 'json',
                success: function (result) {
                    console.log("success", result);
                    location.reload();
                },
                error: function (xhr, status, error) {
                    console.log("error", xhr, status, error);
                }
            });
        }


    </script>
</div>
