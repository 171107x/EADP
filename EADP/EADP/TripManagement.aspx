<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TripManagement.aspx.cs" Inherits="EADP.TripManament" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>StudyTrip</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.2.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>    
    <style>
        .jumbotron{
            background-image: url("Images/london.jpg");
            background-size: cover;
            color: white;
        }
        footer{
            height: 20%;
            width: 100%;
            background-color: lightgrey;
            text-align:center;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h1 class="display-4"><asp:Label ID="Lbl_title" runat="server">Study Trip</asp:Label></h1>
                <p class="lead"><asp:Label ID="Lbl_description" runat="server">Discover your next great adventure</asp:Label></p>
            </div>
        </div>
        <div class="row">
          <div class="col-sm-10">
            <div class="card">
              <div class="card-body">
                <h4 class="card-title">Purpose</h4>
                <p class="card-text">
                    For students to immerse in a suitable environment, 
                    in order to improve their English proficiency in the shortest time possible;
                    To allow the students to experience a different culture and develop a better understanding of Singapore;
                    To allow the students to get to know other students from various countries, interact and learn from one another Ultimately,
                     it is to enable students to be able to learn while in a relaxed and enjoyable manner.
                </p>
              </div>
            </div>
          </div>
          <div class="col-sm-2">
            <div class="card">
              <div class="card-body">
                <a href="#" class="btn btn-primary float-right">Register For Trip</a><br /><br />
                <a href="#" class="btn btn-primary text-center">Download Itinerary</a>
              </div>
            </div>
          </div>
        </div>
        <br />
        <!--Event info-->
        <form runat="server">
          <h4>Trips available</h4>
          <asp:GridView ID="GridViewTrip" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
              <Columns>
                  <asp:BoundField DataField="TripID" HeaderText="Trip" />
                  <asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HeaderText="Date of departure" />
                  <asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HeaderText="Date of arrival" />
                  <asp:BoundField DataField="Country" HeaderText="Country" />
                  <asp:BoundField DataField="ETripPrice" DataFormatString="{0:C2}" HeaderText="Price" />
              </Columns>
            </asp:GridView>

        <hr />
        <!--Visible only to staff-->
        <h4>Add trip:</h4>

          <div class="form-row">
            <div class="col-md-4 mb-3">
              <label for="validationDefault01">Trip ID</label>
              <asp:TextBox class="form-control" ID="tbTripID" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 mb-3">
              <label>Date of Departure</label>
              <asp:TextBox class="form-control" ID="tbStartDate" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 mb-3">
              <label>Date of Arrival</label>
                <asp:TextBox class="form-control" ID="tbEndDate" runat="server"></asp:TextBox>
            </div>
          </div>
          <div class="form-row">
            <div class="col-md-6 mb-3">
              <label>Country</label>
              <asp:TextBox class="form-control" ID="tbCountry" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3 mb-3">
              <label>Price</label>
              <asp:TextBox class="form-control" ID="tbETripPrice" runat="server"></asp:TextBox>
            </div>
          </div>
          <asp:Button class="btn btn-primary" ID="BtnConfirm" runat="server" Text="Confirm" OnClick="BtnConfirm_Click"/>
        </form><br />
        <hr />
        <h4>Accommodation for Students:</h4>
        <ul>
            <li>Home-stay</li>
            <li>Dorm room</li>
        </ul><hr />
        <!--<h4>Pictures</h4>
        <div class="row">
            <div class="col-sm-4">
                <a href="#"><img src="Images/schTrip.jpg" class="img-rounded img-thumbnail " height="200" width="200"/></a>
            </div>
            <div class="col-sm-4">
                <a href="#"><img src="Images/lesson.jpg" class="img-rounded img-thumbnail " height="250" width="200"/></a>
            </div>
            <div class="col-sm-4">
                <a href="#"><img src="Images/lesson2.jpg" class="img-rounded img-thumbnail " height="200" width="200"/></a>
            </div>
        </div>-->
        <br />
    </div><!--container end-->
<footer>
    <p>Footer</p>
</footer>
</body>
</html>
