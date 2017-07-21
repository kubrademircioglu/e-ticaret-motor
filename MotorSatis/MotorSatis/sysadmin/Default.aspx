﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="sysadmin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Admin paneli</title>
    <style type="text/css" media="all">
        @import url("css/style.css");
        @import url("css/jquery.wysiwyg.css");
        @import url("css/facebox.css");
        @import url("css/visualize.css");
        @import url("css/date_input.css");
    </style>
    <!--[if IE]><meta http-equiv="X-UA-Compatible" content="IE=7" /><![endif]-->
    <!--[if lt IE 8]><style type="text/css" media="all">@import url("css/ie.css");</style><![endif]-->
    <!--[if IE]><script type="text/javascript" src="js/excanvas.js"></script><![endif]-->
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/jquery.img.preload.js"></script>
    <script type="text/javascript" src="js/jquery.filestyle.mini.js"></script>
    <script type="text/javascript" src="js/jquery.wysiwyg.js"></script>

    <script type="text/javascript" src="js/ajaxupload.js"></script>
    <script type="text/javascript" src="js/jquery.pngfix.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
</head>
<body>
    <div id="hld">
        <div class="wrapper">
            <!-- wrapper begins -->
            <div class="block small center login">
                <div class="block_head">
                    <div class="bheadl">
                    </div>
                    <div class="bheadr">
                    </div>
                    <h2>
                        Login</h2>
                </div>
                <!-- .block_head ends -->
                <div class="block_content">
                    <div runat="server" id="notify">
                    </div>
                    <form method="post" runat="server">
                    <p>
                        <label>
                            Username:</label>
                        <br />
                        <asp:TextBox ID="txtuser" CssClass="text" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <label>
                            Password:</label>
                        <br />
                        <asp:TextBox ID="txtsifre" CssClass="text" TextMode="Password" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <a href="/Default.aspx">Siteye Git</a>
                        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" class="butonlar" />
                    </p>
                    </form>
                </div>
                <!-- .block_content ends -->
                <div class="bendl">
                </div>
                <div class="bendr">
                </div>
            </div>
            <!-- .login ends -->
        </div>
        <!-- wrapper ends -->
    </div>
    <!-- #hld ends -->
</body>
</html>
