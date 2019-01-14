<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="EADP.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
      .center {
          display: block;
          margin-left: auto;
          margin-right: auto;          
        }
      .auto-style1 {
            width: 1336px;
            height: 50px;
        }
      .auto-style2 {
          width: 200px;
          height: 50px;         
      }
      .profile {
  margin: 20px 0;
}

/* Profile sidebar */
.profile-sidebar {
  padding: 20px 0 10px 0;
  background: #fff;
}

.profile-userpic img {
  float: none;
  margin: 0 auto;
  width: 50%;
  height: 50%;
  -webkit-border-radius: 50% !important;
  -moz-border-radius: 50% !important;
  border-radius: 50% !important;
}

.profile-usertitle {
  text-align: center;
  margin-top: 20px;
}

.profile-usertitle-name {
  color: #5a7391;
  font-size: 16px;
  font-weight: 600;
  margin-bottom: 7px;
}

.profile-usertitle-job {
  text-transform: uppercase;
  color: #5b9bd1;
  font-size: 12px;
  font-weight: 600;
  margin-bottom: 15px;
}

.profile-userbuttons {
  text-align: center;
  margin-top: 10px;
}

.profile-userbuttons .btn {
  text-transform: uppercase;
  font-size: 11px;
  font-weight: 600;
  padding: 6px 15px;
  margin-right: 5px;
}

.profile-userbuttons .btn:last-child {
  margin-right: 0px;
}

.profile-usermenu {
  margin-top: 30px;
}

.profile-usermenu ul li {
  border-bottom: 1px solid #f0f4f7;
}

.profile-usermenu ul li:last-child {
  border-bottom: none;
}

.profile-usermenu ul li a {
  color: #93a3b5;
  font-size: 14px;
  font-weight: 400;
}

.profile-usermenu ul li a i {
  margin-right: 8px;
  font-size: 14px;
}

.profile-usermenu ul li a:hover {
  background-color: #fafcfd;
  color: #5b9bd1;
}

.profile-usermenu ul li.active {
  border-bottom: none;
}

.profile-usermenu ul li.active a {
  color: #5b9bd1;
  background-color: #f6f9fb;
  border-left: 2px solid #5b9bd1;
  margin-left: -2px;
}

/* Profile Content */
.profile-content {
  padding: 20px;
  background: #fff;
  min-height: 460px;
}
 .file-upload {                      
            visibility: hidden;                        
        }     
  </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />


        <br />
        <br />
        <br />
        <div class="row profile">
		<div class="col-md-3" >
			<div class="profile-sidebar">				
				<div class="profile-usertitle">
					<div class="profile-usertitle-name">
						
					</div>
				</div>
                <div class="profile-usermenu">
					<ul class="nav">
						<li>
							<a href="UpdateParticulars.aspx">
							
							Update Particulars </a>
						</li>
						<li >
							<a href="Password.aspx">
							
							Change password </a>
						</li>
                        <li>
							<a href="ProfilePic.aspx">
							
							Change Profile Picture</a>
						</li>
					</ul>
				</div>
            </div>
            </div>
                <div class="col-md-9">
                <asp:Image runat="server" Height="150" Width="150" CssClass="center profile-pic" ID="idProfile"></asp:Image>
                          
                      
                
            <br />
            <table style="border:0px;background-color:white;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="Full Name" Font-Bold="True"></asp:Label>
                
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="tdName" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2"> 
                        <asp:Label runat="server" Text="Admin Number" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="PEM Group" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="Nationality" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="Mobile Number" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="Diet Constraint" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label runat="server" Text="Medical History" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
            </div>
            

        <script>
</script>
</asp:Content>
