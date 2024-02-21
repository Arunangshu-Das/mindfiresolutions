<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Document.ascx.cs" Inherits="DemoUserManagaement.Document" %>

<div class="">
    <label for="formFileMultiple" class="form-label">Upload Files</label>
    <input type="hidden" id="id" >
    <input type="file" class="form-control upload mt-3" id="inputfile" name="fileResume" multiple data-validate="validate" data-take="input">
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
    <asp:Button CssClass="btn btn-primary mt-3 " class="mt-3" ID="Button3" runat="server" Text="Upload" OnClientClick="InsertDocument()" CausesValidation="false" />
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



    <script type="text/javascript">
        $(document).ready(function () {
            updateDropDown();
            var urlParams = new URLSearchParams(window.location.search);
            document.getElementById("id").Text = urlParams.get('id');
        });

        function updateDropDown() {
            var dropdown = $("#selectDropDown");

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Register.aspx/GetAllOptions",
                data: JSON.stringify({ }), // send the note as a property
                dataType: 'json',
                success: function (result) {
                    dropdown.empty();
                    console.log(result);
                    $.each(result.d, function (index, item) {
                        dropdown.append($("<option></option>").val(item.Id).html(item.Name));
                    });

                    $("#selectDropDown")[0][0].selected = true;
                },
                error: function (xhr, status, error) {
                    console.log("error", xhr, status, error);
                }
            });
        }

        function InsertDocument() {
            var fileInput = document.querySelectorAll('#inputfile');
            var files = fileInput.files;

            for (var i = 0; i < fileInput[0].files.length; i++) {

                var filename = uuidv4();
                uploadFiles(fileInput[0].files[i], filename);
                var selected = document.getElementById("selectDropDown").value;
                var uploaddocumentobject = {
                    ObjectID: parseInt(document.getElementById("id").Text),
                    DocumentType: selected,
                    DocumentOriginalName: fileInput[0].files[0].name,
                    DocumentGuidName: filename + "." + fileInput[0].files[i].name.split('.').pop(),
                };
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Register.aspx/DocumentSave",
                    data: JSON.stringify({ Document: uploaddocumentobject }), // send the note as a property
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

        //function submit() {
        //    var jsonObject = {};
        //    fileInput = document.getElementById('FileUpload1');
        //    filename = uuidv4();

        //    uploadFile(fileInput, filename);
        //    jsonObject["DocumentOriginalName"] = fileInput;
        //    jsonObject["DocumentGuidName"] = filename;
        //    jsonObject["DocumentType"] = $("#selectDropDown").val();
        //    var jsonData = JSON.stringify(jsonObject);
        //    PageMethods.DocumentSave(jsonData, onSucess, onError);
        //    function onSucess(result) {
        //    }

        //    function onError(result) {
        //    }
        //}

        function uploadFiles(fileInput, filename) {
            var file = fileInput;

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
