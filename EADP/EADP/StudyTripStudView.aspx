<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="StudyTripStudView.aspx.cs" Inherits="EADP.StudyTripStudView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
        .jumbotron {
            background-image: url("Images/wallpaper.jpg");
            background-size: cover;
            background-repeat: no-repeat;
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <hgroup>
                    <h1>Study Trips</h1>

                    <%--                    <h1 class="display-4">
                        <asp:Label ID="Lbl_title" runat="server">Trips</asp:Label>
                    </h1>--%>
                </hgroup>
                <p class="lead">
                    <asp:Label ID="Lbl_description" runat="server">Discover your next great adventure</asp:Label>
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
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
            <ul class="nav nav-tabs" id="myTab" role="tablist">
              <li class="nav-item"><a class="nav-link" id="home-tab" href="TripStudentView.aspx">All trips</a></li>
              <li class="nav-item"><a class="nav-link active" id="study-tab" href="#">Study Trips </a></li>
              <li class="nav-item"><a class="nav-link" id="immersion-tab" href="ImmTripStudView.aspx">Immersion Trips </a></li>                       
            </ul>
            <%--            <div class="col-sm-2">
                <div class="card">
                    <div class="card-body">
                        <a href="StudReg.aspx" class="btn btn-primary float-right" onclick="BtnRedirect_Click">Register For Trip</a><br />
                        <br />
                        <a href="#" class="btn btn-primary text-center">Download Itinerary</a>
                    </div>
                </div>
            </div>--%>
        </div>
        <br />
        <%--        <div class="row">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Special title treatment</h5>
                        <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                        <a href="#" class="btn btn-primary">Register</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Special title treatment</h5>
                        <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                        <a href="#" class="btn btn-primary">Register</a>
                    </div>
                </div>
            </div>
        </div>--%>
        <%--        <asp:PlaceHolder ID="PHTripDetails" runat="server" />--%>
        <asp:ListView ID="TripList" runat="server" DataKeyNames="TripID" ItemType="EADP.DAL.trip" OnItemCommand="TripList_ItemCommand">
            <ItemTemplate>
<%--                <div class="col-sm-4">
                    <table>
                        <tr>
                            <td>
                                <img src="<%# Eval("Image") %>" style='width: 325px; height: 250px;' /></td>
                        </tr>
                        <tr>
                            <td>
                                <h3><%# Eval("Country") %></h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="descrip" runat="server"><%# Eval("Description") %></asp:Label>
                                <%--<p><%# Eval("Description") %></p>--%>
                            <%--</td>
                        </tr>
                        <tr>
                            <td>
                                <p>Price: $<%# Eval("ETripPrice") %></p>
                            </td>
                        </tr>
                        <asp:Button class='btn btn-primary float-right' runat='server' Text='More Details' CommandName="moreDetails" CommandArgument='<%#Eval("TripID") %>' />
                    </table>
                </div>--%>
                <div class='col-sm-6'>
                    <div class='card'>
                        <div class='card-body'>
                            <img runat="server" id="imgTrip" class='card-img-top col-sm-4' src='<%#Eval("Image")%>' style='width: 325px; height: 250px;' />
                            <h3 id="country" class='card-title bold'>
                                <%#Eval("Country")%>
                            </h3>
                            <p class='card-text'>
                                <%#Eval("Description")%>
                                <%--<%#:Item.Description%>--%>
                            </p>
                            <p class='card-text'>
                                Price: $<%#Eval("ETripPrice")%>
                            </p>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <%--<asp:Button class='btn btn-primary float-right' runat='server' Text='More Details' OnClick='btnDetails_Click' />--%>
                            <asp:Button class='btn btn-primary float-right' runat='server' Text='More Details' CommandName="moreDetails" CommandArgument='<%#Eval("TripID") %>' />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <%--<asp:Button runat="server" class='btn btn-primary float-right' Text="More Details" onclick='btnDetails_Click'/>--%>
    </div>
</asp:Content>

