<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TripStudentView.aspx.cs" Inherits="EADP.TripStudentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h1 class="display-4">
                    <asp:label id="Lbl_title" runat="server">Study Trip</asp:label>
                </h1>
                <p class="lead">
                    <asp:label id="Lbl_description" runat="server">Discover your next great adventure</asp:label>
                </p>
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
                        <a href="StudReg.aspx" class="btn btn-primary float-right" onclick="BtnRedirect_Click">Register For Trip</a><br />
                        <br />
                        <a href="#" class="btn btn-primary text-center">Download Itinerary</a>
                    </div>
                </div>
            </div>
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
        <asp:PlaceHolder ID = "PHTripDetails" runat="server" />
    </div>
</asp:Content>
