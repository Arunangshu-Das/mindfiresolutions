<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Document.ascx.cs" Inherits="DemoUserManagaement.Document" %>

<!DOCTYPE html>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
<div class="">
    <%--<textarea runat="server" class="form-control" placeholder="Leave a comment here" id="Textarea1" style="height: 100px;"></textarea>--%>
    <label for="formFileMultiple" class="form-label">Upload Files</label>
    <%--<asp:FileUpload ID="FileUpload1" class="form-control" runat="server" AllowMultiple="true" />--%>
    <input type="file" class="form-control upload mt-3" id="FileUpload1" name="fileResume" multiple data-validate="validate" data-take="input">
</div>



<label cssclass="form-label star-mark required">Enter Your Document</label>
<div class="input-group">
    <span class="input-group-text"><i class="bi bi-geo-alt-fill"></i></span>
    <select id="selectDropDown" class="form-select" name="selectCurrentCountry" data-name="CurrentCountry" data-take="input">
        <option value="India">India</option>
        <option value="USA">USA</option>
        <option value="UK">UK</option>
        <option value="Singapore">Singapore</option>
    </select>
</div>
<div class="d-grid gap-2 d-md-flex justify-content-center">
    <asp:Button CssClass="btn btn-primary mt-3 " class="mt-3" ID="Button3" runat="server" Text="Upload" OnClientClick="submit()" CausesValidation="false" />
</div>



<div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>



    <script>
        $(document).ready(function () {
            updateDropDown();
        });

        function updateDropDown() {
            var dropdown = $("#selectDropDown");

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Document.ascx/GetAllOptions",
                success: function (result) {
                    dropdown.empty();
                    console.log(result);
                    $.each(result, function (index, item) {
                        dropdown.append($("<option></option>").val(item.Id).html(item.Name));
                    });
                },
                error: function (result) {
                    alert(result);
                }
            });
        }


        //function updateDropDown() {
        //    var dropdown = $("#selectDropDown");
        //    PageMethods.GetAllOptions(onSucess, onError);

        //    function onSucess(result) {
        //        dropdown.empty()
        //        console.log(result);
        //        $.each(result, function (index, item) {
        //            dropdown.append($("<option></option>").val(item.Id).html(item.Name));
        //        });
        //    }
        //    function onError(result) {
        //        alert('Something wrong.');
        //    }
        //}

        function submit() {
            var jsonObject = {};
            fileInput = document.getElementById('FileUpload1');
            filename = uuidv4();

            uploadFile(fileInput, filename);
            jsonObject["DocumentOriginalName"] = fileInput;
            jsonObject["DocumentGuidName"] = filename;
            jsonObject["DocumentType"] = $("#selectDropDown").val();
            var jsonData = JSON.stringify(jsonObject);
            PageMethods.DocumentSave(jsonData, onSucess, onError);
            function onSucess(result) {
            }

            function onError(result) {
            }
        }

        function uploadFile(fileInput, filename) {
            var file = fileInput.files[0];

            if (file) {
                var formData = new FormData();
                formData.append('image', file);
                formData.append('name', filename);

                $.ajax({
                    url: '/Upload.ashx',
                    type: 'POST',
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (response) {
                        // Handle the response from the server, e.g., update UI or display a message
                        return response;
                    },
                    error: function (error) {
                        return error;
                    }
                });
            } else {
                console.error('No file selected.');
            }
        }

        function uuidv4() {
            return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
                (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
            );
        }

    </script>
</div>
