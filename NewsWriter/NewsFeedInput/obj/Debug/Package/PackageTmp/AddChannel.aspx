<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddChannel.aspx.cs" Inherits="NewsFeedInput.AddChannel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Channel Page</title>
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
        <div class="siteMap">
            <ul>
                <li><img src="Images/icon_typewriter.png" alt="Type Writer" /><a href="Default.aspx">News Writer</a></li>
                <li><img src="Images/tv.png" alt="TV" /><a href="AddChannel.aspx">Add Channel</a></li>
                <li><img src="Images/101.png" alt="X" /><a href="DeletionPage.aspx">Delete Article</a></li>
            </ul>
        </div>
        <div class="content">
            <div class="howTo">
                <p>
                    The Add Channel page creates channels <br /> 
                    that will have a collection of articles.The title<br />  
                    will be what the Channel is known by.<br /> 
                    The Description will be a brief description<br /> 
                    of what the Channel should be used for.<br />
                    <br />
                    When finished click create and you will<br />
                    be able to see the Channel next time you<br />
                    visit the News Writer.
                </p>
            </div>
            <p>
                <asp:Label ID="lblTitle" runat="server" Text="Channel Title: " />
                <asp:TextBox ID="txtTitle" runat="server" EnableViewState="False" /><br />
                <asp:Label ID="lblTitleError" runat="server" Text="" />
            </p>
            <p>
                <asp:Label ID="lblDescription" runat="server" Text="Channel Description:" />
                <br />
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" /><br />
                <asp:Label ID="lblDescriptionError" runat="server" Text="" />
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Create" onmousedown="pressed()" onmouseup="released()" onmouseout="released()"/>
            </p>
        </div>
        </form>
    </div>
</body>
</html>
