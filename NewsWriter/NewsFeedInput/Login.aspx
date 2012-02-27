<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NewsFeedInput.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <script type="text/javascript">
        function pressed() {
            var element = document.getElementById("btnSubmit");
            element.style.backgroundColor = "#2354A9";
        }

        function released() {
            var element = document.getElementById("btnSubmit");
            element.style.backgroundColor = "#3465BA";
        }
    </script>
</head>
<body>
    <div class="app">
        <div class="header">
            <img src="Images/logo.png" alt="Coleman Logo" />
            <h1 runat="server" id="headerTag">Coleman University<br />Welcome to the News Writer!</h1>
        </div>
        <form id="form1" runat="server">
            <div class="content">
                <p>
                    <asp:Label ID="lblUserName" runat="server" Text="Username: "/>
                    <asp:TextBox ID="txtUserName" runat="server" />
                    <asp:RequiredFieldValidator ID="valUserName" runat="server" 
                        ErrorMessage="Username Needed!" ControlToValidate="txtUserName" />
                </p>
                <p>
                    <asp:Label ID="lblPassword" runat="server"  Text="Password: " />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="valPassword" runat="server" 
                        ErrorMessage="Password Needed!" ControlToValidate="txtPassword" />
                </p>
                <p>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" onmousedown="pressed()" onmouseup="released()" onmouseout="released()" />
                </p>
            </div>
        </form>
    </div>
</body>
</html>
