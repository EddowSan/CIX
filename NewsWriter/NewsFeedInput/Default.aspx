<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsFeedInput._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>News Feed Updater</title>
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
                    Welcome to the News Writer. Let me<br /> 
                    explain how to use it. The Channel is<br /> 
                    where you will write your news article to.<br /> 
                    Each Channel has an intended audience. So,<br /> 
                    you should choose your Channel accordingly.<br />
                    <br />
                    The headline will be the title of your news<br />
                    article. The description will be the body.<br />
                    <br />
                    When you are done writing your news article<br />
                    click the Publish button. 

               </p>
            </div>
            <p>
                <asp:Label ID="lblChannels" runat="server" Text="Select Channel: " />
                <asp:DropDownList ID="drpChannels" runat="server" /><br />
                <asp:Label ID="lblChannelError" runat="server" Text="" />
            </p>
            <p>
                <asp:Label ID="lblHeadline" runat="server" Text="Article Headline:" />
                <asp:TextBox ID="txtHeadline" runat="server" /><br />
                <asp:Label ID="lblTitleError" runat="server" Text="" />
            </p>
            <p>
                <asp:Label ID="lblDescription" runat="server" Text="Article Description:" />
                <br />
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" /><br />
                <asp:Label ID="lblDescriptionError" runat="server" Text=""/>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Publish" onmousedown="pressed()" onmouseup="released()" onmouseout="released()" />
            </p>
            
        </div>
        </form>
    </div>
</body>
</html>
