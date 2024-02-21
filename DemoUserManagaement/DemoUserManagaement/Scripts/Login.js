function HandleIT() {
    var name = document.getElementById('email').value;
    var address = document.getElementById('password').value;

    PageMethods.Authenticate(name, address, onSucess, onError);

    function onSucess(result) {
        if (result !== "") {
            // Parse the JSON string to get roles
            var roles = JSON.parse(result);

            // Access roles as needed
            console.log(roles);

            // Redirect to Home.aspx or perform other actions based on roles
            if (roles[0]["Id"] == 1) {
                window.location.href = "Home.aspx";
            }
            else {
                window.location.href = "Users.aspx";
            }
        } else {
            alert('Login failed. Check your credentials.');
        }
    }

    function onError(result) {
        alert('Something wrong.');
    }
}