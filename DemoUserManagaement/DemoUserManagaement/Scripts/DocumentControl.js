$(document).ready(function () {
    updateDropDown();
    var urlParams = new URLSearchParams(window.location.search);
    document.getElementById("id").Text = urlParams.get('id');
    var url = window.location.pathname;
    var pagename = url.substring(url.lastIndexOf('/') + 1);
    pagename = pagename.replace('.aspx', '');
    if (pagename == "Register") {
        document.getElementById("documentobjecttype").Text = 1;
    }
});

function updateDropDown() {
    var dropdown = $("#selectDropDown");

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "Register.aspx/GetAllOptions",
        data: JSON.stringify({}), // send the note as a property
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
            ObjectType: parseInt(document.getElementById("documentobjecttype").Text),
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