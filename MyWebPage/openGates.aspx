﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="openGates.aspx.cs" Inherits="MyWebPage.openGates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title>Home - OpenGates</title>
    <link rel="stylesheet" href="bootstrap.min.css">
    <link rel="stylesheet" href="openGates.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat:400,700">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Kaushan+Script">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-dark navbar-expand-lg fixed-top bg-dark" id="mainNav">
        <div class="container"><a class="navbar-brand" href="#">OpenGates</a>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="nav navbar-nav ml-auto text-uppercase">
                    <li class="nav-item" role="presentation"><a class="nav-link js-scroll-trigger" href="classes.aspx">Classes</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link js-scroll-trigger" href="search.aspx">Search</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link js-scroll-trigger" href="about_page.aspx">About</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link js-scroll-trigger" href="logout.aspx">Logout</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container" style="margin-top: 25%;">
        <div class="text" style="font-size: 50px; font-weight: 900; outline: inherit; text-decoration-style: doted;
        color:antiquewhite;"></div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.min.js"></script>
    <script src="agency.js"></script>
    </form>
</body>
</html>
