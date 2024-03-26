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
