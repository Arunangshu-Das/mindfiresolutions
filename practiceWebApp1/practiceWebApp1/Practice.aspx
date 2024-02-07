<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practice.aspx.cs" Inherits="practiceWebApp1.Practice" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Click here" OnClick="Button1_Click" />
        </div>
        <asp:RadioButton ID="RadioButton1" runat="server" Checked="true" Text="Male" GroupName="gender" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="FeMale" GroupName="gender" />

        <br />
        <h2>Select Date from the Calender</h2>
        <div>
            <asp:Calendar ID="Calendar1" runat="server"
                OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="J2SE" />
        <asp:CheckBox ID="CheckBox2" runat="server" Text="J2EE" />
        <asp:CheckBox ID="CheckBox3" runat="server" Text="Spring" />
        <div>
            <p>It is a hyperlink style button</p>
        </div>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">javatpoint</asp:LinkButton>
        <p>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <%--<div>
            <p>Browse to Upload File</p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Upload File" OnClick="Button1_Click" />
        </p>--%>

        <div>    
            <h3>Upload Multiple Files</h3>    
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />    
        </div>    
        <p>    
            <asp:Button ID="Button3" runat="server" Text="Upload File" OnClick="Button1_Click" />    
        </p>    

        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Select Brand Preferences"></asp:Label>  
        <br />  
        <br />  
        <asp:CheckBox ID="apple" runat="server" Text="Apple" />  
        <br />  
        <asp:CheckBox ID="dell" runat="server" Text="Dell" />  
        <br />  
        <asp:CheckBox ID="lenevo" runat="server" Text="Lenevo" />  
        <br />  
        <asp:CheckBox ID="acer" runat="server" Text="Acer" />  
        <br />  
        <asp:CheckBox ID="sony" runat="server" Text="Sony" />  
        <br />  
        <asp:CheckBox ID="wipro" runat="server" Text="Wipro" />  
        <br />  
        <br />  
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Submit" />  
        <p>  
            <asp:Label ID="Label5" runat="server"></asp:Label>  
        </p>  

    </form>
    <br />
    <asp:Label ID="Label1" runat="server" Font-Strikeout="True" Font-Size="30" Font-Names="Poppins" ForeColor="Green"></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" Text="JavaTpoint" Target="_blank" NavigateUrl="https://www.arunangshu.in"></asp:HyperLink>
    <asp:Label runat="server" ID="ShowDate"></asp:Label>
    Courses Selected:
    <asp:Label runat="server" ID="ShowCourses"></asp:Label>
    <asp:Label runat="server" ID="FileUploadStatus"></asp:Label>
     <asp:Label runat="server" ID="Label3"></asp:Label>  

</body>
</html>
