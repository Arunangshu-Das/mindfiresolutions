<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Document.ascx.cs" Inherits="DemoUserManagaement.Document" %>

<!DOCTYPE html>
<div class="">
    <%--<textarea runat="server" class="form-control" placeholder="Leave a comment here" id="Textarea1" style="height: 100px;"></textarea>--%>
    <label for="formFileMultiple" class="form-label">Upload Files</label>
    <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" AllowMultiple="true" />
</div>


<asp:UpdatePanel ID="CurrentSelectPanel" runat="server">
    <ContentTemplate>
        <asp:Label runat="server" CssClass="form-label star-mark required" AssociatedControlID="ddlSelectDocumentTypeFor">Enter Your Document</asp:Label>
        <div class="input-group">
            <span class="input-group-text"><i class="bi bi-geo-alt-fill"></i></span>
            <asp:DropDownList runat="server" ClientIDMode="Static" ID="ddlSelectDocumentTypeFor" CssClass="form-select"
                DataToggle="tooltip" Title="Select your country" DataLabel="Country">
                <asp:ListItem Text="--Select Your ID--" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlSelectDocumentTypeFor"
            ErrorMessage="Please select your ID" ForeColor="Red"></asp:RequiredFieldValidator>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlCurrentCountryName" EventName="SelectedIndexChanged" />
    </Triggers>

</asp:UpdatePanel>
<div class="d-grid gap-2 d-md-flex justify-content-center">
    <asp:Button CssClass="btn btn-primary mt-3 " class="mt-3" ID="Button3" runat="server" Text="Upload" OnClick="InsertButton" CausesValidation="false" />
</div>

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
                    <asp:HyperLink ID="Label1" Target="_blank" runat="server" Text='<%# Bind("DocumentOriginalName") %>' NavigateUrl='<%# "Download.ashx?file=" + Eval("DocumentGuidName") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Name">

                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DocumentTypeName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("DocumentTypeName") %>'></asp:Label>
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
