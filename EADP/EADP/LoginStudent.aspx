﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginStudent.aspx.cs" Inherits="EADP.LoginStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.2.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>    
    <style>        
        body{
          background-image:url('Images/wallpaper2.jpg')
      }        
        .auto-style14 {
            padding: 120px 100px 80px 100px;
            margin: 35px auto 100px auto;
            background-image: url('Images/panel.png');
            width: 267px;
            height: 286px;
        }
        .login-form {
		width: 340px;
    	margin: 50px auto;
	}
         .form1 {
    	    margin-bottom: 15px;
            background: #f7f7f7;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            padding: 30px;
        }
        .login-form h2 {
            margin: 0 0 15px;
        }
        .form-control, .btn {
            min-height: 38px;
            border-radius: 2px;
        }
        .btn {        
            font-size: 15px;
            font-weight: bold;
        }
    </style>
</head>
    <%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">--%>
<body>
    <form id="form1" runat="server">    
        <div class="login-form"> 
            <div class="form1">    
                <h2 class="text-center">Log in</h2>       
                <div class="form-group">                    
                    <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" placeholder="Email"></asp:TextBox>                     
                  
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control" placeholder="Password"></asp:TextBox> 
                </div>
                <div class="form-group">                    
                    <asp:Button runat="server" cssClass="btn btn-primary btn-block" Text="Log in"></asp:Button>
                </div>
                <div class="clearfix">
                    <label class="pull-left checkbox-inline"><input type="checkbox"> Remember me</label>
                    <a href="#" class="pull-right">Forgot Password?</a>
                </div>                   
            <p class="text-center"><a href="#">Login As Staff</a></p>
          </div>    
    </div> 
    
    </form>
    
</body>


</html>