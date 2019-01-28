<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expire.aspx.cs" Inherits="EADP.Expire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 80px;
            height: 73px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>                  
        <%--<nav class="navbar nav-tabs navbar-inverse navbar-fixed-top" style="left: 0; right: 0; top: 0; height: 50px">
                <div class="container-fluid">
                    <div style="margin-top:-10px;" class="navbar-header">                                               
                        <img class="auto-style1" src="ProfilePic/nyp.png" /><a style="float:none;" class="navbar-brand" href="Home.aspx"><span></span>Trip Management System</a>                   
                    </div>
                </div>
            </nav>--%>
            <nav class="navbar nav-tabs navbar-inverse" style="left: 0; right: 0; top: 0; height: 50px">
              <div class="container-fluid">                
                  <div style="margin-top:-10px;" class="navbar-header">                                               
                        <img class="auto-style1" src="ProfilePic/nyp.png" /><a style="float:none;" class="navbar-brand" href="LoginStudent.aspx"><span></span>Trip Management System</a>                   
                  </div>                              
              </div>
            </nav>
        </header>
    <div class="container">
        <div class="jumbotron">
            <h1>The token has expire pls request a new one</h1>
            <h3>Click <a href="ForgotPassword.aspx">here</a> to request a new one</h3>
        </div>
        <asp:Label ID="status" runat="server" ></asp:Label>
    </div>
    </form>
</body>
</html>
