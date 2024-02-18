<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoUserManagaement.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <script type="text/javascript">   
        function HandleIT() {
            var name = document.getElementById('email').value;
            var address = document.getElementById('password').value;

            PageMethods.ProcessIT(name, address, onSucess, onError);

            function onSucess(result) {
                if (result !== "") {
                    // Parse the JSON string to get roles
                    var roles = JSON.parse(result);

                    // Access roles as needed
                    console.log(roles);

                    // Redirect to Home.aspx or perform other actions based on roles
                    if (roles[0]["Id"] == 1)
                    {
                        window.location.href = "Home.aspx";
                    }
                    else
                    {
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
    </script>

    <div class="container">
        <div class="form-group">
            <label for="exampleInputEmail1">Email address</label>
            <input type="email" class="form-control" ID="email" aria-describedby="emailHelp" placeholder="Enter email"></input>

        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Password</label>
            <input type="password" class="form-control" ID="password" placeholder="Password"></input>
        </div>
        <button type="submit" class="btn btn-primary" onclick="HandleIT(); return false;">Submit</button>
    </div>
</asp:Content>


