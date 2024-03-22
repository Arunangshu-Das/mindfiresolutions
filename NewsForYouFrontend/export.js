function formatDate(date) {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
}

const currentDate = new Date();

document.getElementById('startDate').value = formatDate(currentDate);
document.getElementById('endDate').value = formatDate(currentDate);

function exportData() {
    startDate = $("#startDate").val(),
    endDate = $("#endDate").val()
    if (endDate < startDate) {
        alert("Can't procced");
        $('#productTable').DataTable().clear().draw();
        return;
    }
    var payload = {
        startDate:startDate,
        endDate:endDate
    }
    $.ajax({
        url: 'https://localhost:7235/api/generatepdf',
        type: 'POST',
        data: JSON.stringify(payload),
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            exportHtml(result.report)
        },
        error: function () {
            alert('Error while making the AJAX call.');
        }
    });
}

function exportHtml(data){
    $('#productTable').DataTable().clear().draw();
    $.each(data, function (index, product) {
        $('#productTable').DataTable().row.add([
            product.agencyName,
            product.newsTitle,
            product.clickCount,
        ]).draw(false);
    });

    var dataTable = $('#productTable').DataTable();
    // Disable default sorting
    dataTable.order([]).draw();
}