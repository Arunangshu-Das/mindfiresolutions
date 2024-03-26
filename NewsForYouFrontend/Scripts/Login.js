$(document).ready(function () {
    checkCookie();
});

function login() {
    if (document.getElementById("emailid").value == "" || document.getElementById("password").value == "") {
        alert("Enter all value to proceed");
        return;
    }
    var payload = {
        Email: document.getElementById("emailid").value,
        Password: document.getElementById("password").value
    }
    $.ajax({
        url: 'https://localhost:7235/api/login',
        type: 'POST',
        data: JSON.stringify(payload),
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            if (result.authenticate) {
                sessionStorage.setItem("credential", result.jwtToken);
                var expirationDate = new Date();
                expirationDate.setTime(expirationDate.getTime() + (2 * 60 * 60 * 1000)); 
                document.cookie = `credential=${result.jwtToken};expires=${expirationDate.toUTCString()};path=/`;
                alert("Login Done");
                window.location.href = 'Startup.html';
            } else {
                alert("Invalid credential");
            }
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
