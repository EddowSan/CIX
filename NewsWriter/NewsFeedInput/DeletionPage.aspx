<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeletionPage.aspx.cs" Inherits="NewsFeedInput.DeletionPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Article Page</title>
    <script type="text/javascript">
        function pressed() {
            var element = document.getElementById("btnDelete");
            element.style.backgroundColor = "#2354A9";
        }

        function released() {
            var element = document.getElementById("btnDelete");
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
                    Welcome to the Article Deletion page.<br />
                    Here you can delete any article in any<br />
                    Channel. All you need to do is select<br />
                    desired Channel. Then select the desired<br />
                    article. Then click the delete button<br />
                    and that article will be gone forever.
                </p>
            </div>
            <p>
                <asp:Label ID="lblChannels" runat="server" Text="Select Channel: " />
                <asp:DropDownList ID="drpChannels" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpChannels_SelectedIndexChanged" />
            </p>
            <p>
                <asp:Label ID="lblIntro" runat="server" Text="Select an Item to Delete:" /></p>
            <p>
                <asp:ListBox ID="listItems" runat="server" Height="150px" Width="200px" />
            </p>
            <p>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" onmousedown="pressed()" onmouseup="released()" onmouseout="released()"/>
            </p>
        </div>
        </form>
    </div>
</body>
</html>
