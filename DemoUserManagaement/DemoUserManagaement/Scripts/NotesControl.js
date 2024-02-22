$(document).ready(function () {
    var urlParams = new URLSearchParams(window.location.search);
    document.getElementById("noteid").Text = urlParams.get('id');
    var url = window.location.pathname;
    var pagename = url.substring(url.lastIndexOf('/') + 1);
    pagename = pagename.replace('.aspx', '');
    if (pagename == "Register") {
        document.getElementById("noteobjecttype").Text = 1;
    }
});
function Insert() {
    var textarea = document.getElementById("Textarea1").value;

    var note = {
        NoteText: textarea,
        ObjectID: parseInt(document.getElementById("noteid").Text),
        ObjectType: parseInt(document.getElementById("noteobjecttype").Text)
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