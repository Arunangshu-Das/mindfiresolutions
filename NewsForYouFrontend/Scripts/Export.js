$(document).ready(function () {
    checkCookie();
});
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
        startDate: startDate,
        endDate: endDate
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

function exportHtml(data) {
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

function exportPdf() {
    startDate = $("#startDate").val(),
        endDate = $("#endDate").val()
    if (endDate < startDate) {
        alert("Can't procced");
        $('#productTable').DataTable().clear().draw();
        return;
    }
    var payload = {
        startDate: startDate,
        endDate: endDate
    }
    $.ajax({
        url: 'https://localhost:7235/api/generatepdf',
        type: 'POST',
        data: JSON.stringify(payload),
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            var reportContent = `<h3>Generated Report</h3>`;

            reportContent += `<div><table id="reporttable">
            <tr>
                <th>Agency Name</th>
                <th>News Title</th>
                <th>Click Count</th>
            </tr>`;

            for (var i = 0; i < result.report.length; i++) {
                var entry = result.report[i];
                reportContent += `<tr>
                    <td>${entry.agencyName}</td>
                    <td>${entry.newsTitle}</td>
                    <td>${entry.clickCount}</td>
                </tr>`;
            }

            reportContent += `</table></div>`;

            var pdf = new jsPDF();

            pdf.fromHTML(reportContent, 15, 30);

            pdf.save('exported_report.pdf');
        },
        error: function () {
            alert('Error while making the AJAX call.');
        }
    });
}

// Check for the presence of the "credential" cookie
function checkCookie() {
    var cookies = document.cookie.split(';');
    var isLoggedIn = cookies.some(cookie => cookie.trim().startsWith('credential='));
    if (isLoggedIn) {
        document.getElementById("logoutLink").style.display = "block";
    } else {
        document.getElementById("loginLink").style.display = "block";
        document.getElementById("signupLink").style.display = "block";
    }
}

// Function to logout
function logout() {
    // Clear the credential cookie
    document.cookie = "credential=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    // Redirect to login page
    window.location.href = "login.html";
}
