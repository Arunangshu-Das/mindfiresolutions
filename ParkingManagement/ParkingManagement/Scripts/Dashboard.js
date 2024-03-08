$(document).ready(function () {
    fetchAllData();
});

function fetchAllData() {
    $('#parkingTable tbody').empty();
    $.ajax({
        url: '/Dashboard/FetchAllData',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $.each(data, function (index, item) {
                var statusClass = item.Availability === 'occupied' ? 'occupied' : 'vacant';
                var RegistrationNumber = item.RegistrationNumber == null ? "" : item.RegistrationNumber;
                var newRow = '<tr>' +
                    '<td>' + item.ParkingSpaceTitle + '</td>' +
                    '<td class="' + statusClass + '">' + item.Availability + '</td>' +
                    '<td>' + RegistrationNumber + '</td>' +
                    '</tr>';
                $('#parkingTable tbody').append(newRow);
            });
        },
        error: function (error) {
            console.log('Error fetching data: ', error);
        }
    });
}

$('#showAll').on('click', function () {
    showAllData();
});

$('#deleteAll').on('click', function () {
    $.ajax({
        url: '/Dashboard/DeleteAllTransaction',
        type: 'POST',
        dataType: 'json',
        success: function (result) {
            if (result.success) {
                alert('Data Deleted successfully!');
            } else {
                alert('Failed to Delete');
            }
        },
        error: function () {
            alert('Failed to delete');
        }
    });
    fetchAllData();
});

function showAllData() {
    $('#parkingTable tbody tr').each(function () {
        $(this).show();
    });
}

function filterSpaces() {
    var selectedZone = $('#filterZone option:selected').text();

    $('#parkingTable tbody tr').each(function () {
        var spaceTitle = $(this).find('td:first').text();
        var showRow = spaceTitle.startsWith(selectedZone);

        if (showRow) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
}

function bookSpace() {
    var registrationNumber = $('#registrationNumber').val();
    var indianVehicleNumberPattern = /^[A-Z]{2}\s\d{1,2}\s[A-Z0-9]{1,4}\s\d{1,4}$/;

    // Check if the registrationNumber matches the pattern
    if (indianVehicleNumberPattern.test(registrationNumber)) {

        $.ajax({
            url: '/Dashboard/BookParkingSpace',
            type: 'POST',
            data: { vehicleRegistrationNumber: registrationNumber },
            dataType: 'json',
            success: function (result) {
                if (result.success) {
                    alert('Car booked successfully!');
                    $('#registrationNumber').val("");
                } else {
                    alert('Failed to book parking space.');
                }
            },
            error: function () {
                alert('Error while making the AJAX call.');
            }
        });
    } else {
        alert('Not a valid Registration Number')
    }
    fetchAllData();
}

function releaseSpace() {
    var registrationNumber = $('#releaseRegistrationNumber').val();
    $.ajax({
        url: '/Dashboard/FreeParkingSpace',
        type: 'POST',
        data: { vehicleRegistrationNumber: registrationNumber },
        dataType: 'json',
        success: function (result) {
            if (result.success) {
                alert('Car released successfully!');
                $('#releaseRegistrationNumber').val("");
            } else {
                alert('Failed to release parking space.');
            }
        },
        error: function () {
            alert('Error while making the AJAX call.');
        }
    });
    fetchAllData();
}