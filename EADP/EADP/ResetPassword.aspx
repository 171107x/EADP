<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="EADP.ResetPassword" %>

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
    <nav class="navbar nav-tabs navbar-inverse" style="left: 0; right: 0; top: 0; height: 50px">
              <div class="container-fluid">                
                  <div style="margin-top:-10px;" class="navbar-header">                                               
                        <img class="auto-style1" src="ProfilePic/nyp.png" /><a style="float:none;" class="navbar-brand" href="Home.aspx"><span></span>Trip Management System</a>                   
                  </div>                              
              </div>
            </nav>
        </header>
    <div class="container">
        <div class="jumbotron">
        <h2>Email: </h2>
            <div id="form-group">
                <div class="row">
                    <div class="col-md-8"> 
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="col-md-4"></div>
                </div>
            </div>
             <h2>New Password: </h2>
            <div id="form-group">
                <div class="row">
                    <div class="col-md-8"> 
                        <asp:TextBox ID="tbpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-md-4"></div>
                </div>
            </div>
            <h2>Confirm New Password: </h2>
            <div id="form-group">
                <div class="row">
                    <div class="col-md-8"> 
                        <asp:TextBox ID="tbconfirm" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col-md-4"></div>
                </div>
            </div><br/><asp:Button runat="server" Text="Submit" ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"></asp:Button>
        </div>
        <asp:Label ID="status" runat="server" ></asp:Label>
    </div>
    </form>
</body>
</html>
