<%@ Page Title="Trips" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TripStudentView.aspx.cs" Inherits="EADP.TripStudentView" %>

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
                    <h1><%: Page.Title %></h1>

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
        <asp:ListView ID="TripList" runat="server" DataKeyNames="TripID" ItemType="EADP.DAL.trip">
            <ItemTemplate>
                <div class='col-sm-6'>
                    <div class='card'>
                        <div class='card-body'>
                            <img class='card-img-top col-sm-4' src='<%#:Item.Image%>' style='width: 325px; height: 250px;'>
                            <h3 id="country" class='card-title bold'>
                                <%#:Item.Country%>
                            </h3>
                            <p class='card-text'>
                                <%#:Item.Description%>
                            </p>
                            <p class='card-text'>
                                Price: $<%#:Item.ETripPrice%>
                            </p>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Button class='btn btn-primary float-right' runat='server' Text='More Details' OnClick='btnDetails_Click' />
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
