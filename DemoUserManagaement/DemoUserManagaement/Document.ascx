<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Document.ascx.cs" Inherits="DemoUserManagaement.Document" %>

<!DOCTYPE html>
<div class="row mt-5 mb-5">
    <div class="col-xs-12 col-sm-6">
        <div class="form-floating">
            <%--<textarea runat="server" class="form-control" placeholder="Leave a comment here" id="Textarea1" style="height: 100px;"></textarea>--%>
            <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" AllowMultiple="true" />    
            <label for="floatingTextarea2">Documnts Upload</label>
        </div>
        <div class="d-grid gap-2 d-md-flex justify-content-center">
            <asp:Button CssClass="btn btn-primary mt-3 " class="mt-3" ID="Button3" runat="server" Text="Upload" OnClick="InsertButton" CausesValidation="false" />
        </div>
    </div>
    <div class="col-xs-12 col-sm-6">
        <div>
            <h3>ALL Documents</h3>
            <asp:GridView ID="GridView1"
                runat="server"
                AutoGenerateColumns="False"
                AllowSorting="True"
                OnSorting="SortingGridView"
                AllowPaging="True"
                AllowCustomPaging="True"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                PageSize="2"
                DataKeyNames="DocumentID"
                CssClass="table table-striped table-bordered table-hover">
                <Columns>

                    <asp:TemplateField HeaderText="DocumentID" SortExpression="DocumentID">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox0" runat="server" Text='<%# Bind("DocumentID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label0" runat="server" Text='<%# Bind("DocumentID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DocumentName" SortExpression="DocumentOriginalName">

                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DocumentOriginalName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="Label1" Target="_blank" runat="server" Text='<%# Bind("DocumentOriginalName") %>' NavigateUrl='<%# "~/upload/" + Eval("DocumentGuidName") %>'></asp:HyperLink>
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
        </div>
    </div>
</div>