﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstForm.aspx.cs" Inherits="practiceWebApp1.FirstForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col">
                <asp:Button  runat="server" type="button" onclick="Button1_Click" class="btn btn-primary" Text="Go to Second page by Response.Redirect"></asp:Button>
            </div>
            <div class="col">
                <asp:Button  runat="server" type="button" onclick="Button2_Click" class="btn btn-primary" Text="Go to Second Page by Server.Transfer"></asp:Button>
            </div>
             <div class="col">
                 <asp:Button  runat="server" type="button" onclick="Button3_Click" class="btn btn-primary" Text="Go to Google Page by Server.Transfer"></asp:Button>
             </div>
             <div class="col">
     <asp:Button  runat="server" type="button" onclick="Button4_Click" class="btn btn-primary" Text="Go to Custom Page by RR"></asp:Button>
 </div>
        </div>
    </form>
</body>
</html>
