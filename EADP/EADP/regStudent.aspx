<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="regStudent.aspx.cs" Inherits="EADP.regStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">
    <style>
        body {
            font-family: "Lato", sans-serif;
        }

        .sidenav {
            height: 100%;
            width: 250px;
            position: fixed;
            z-index: 1;
            top: 0;
            left: 0;
            background-color: #282639;
            overflow-x: hidden;
            padding-top: 90px;
        }

            .sidenav a {
                /*border-top: 0.5px purple solid;*/
                padding: 15px 20px 15px 20px;
                text-decoration: none;
                color: #818181;
                display: block;
            }

                .sidenav a:hover {
                    background-color: lightslategrey;
                    color: lightblue;
                }

        .active {
            background-color: #171623;
            color: lightblue !important;
        }

        .main {
            margin-left: 300px;
            padding: 0px 10px;
        }

        @media screen and (max-height: 450px) {
            .sidenav {
                padding-top: 15px;
            }

                .sidenav a {
                    font-size: 18px;
                }
        }

        @media screen and (max-width: 1024px) {
            .sidenav {
                display: none !important;
            }
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sidenav">
        <a href="TripManagement.aspx" class="active"><i class="fas fa-home"></i>&nbsp;&nbsp;Trip Management</a>
        <a href="#StudyTrips"><i class="fas fa-book"></i>&nbsp;&nbsp;&nbsp;Study Trips</a>
        <a href="#ImmersionTrips"><i class="fas fa-atlas"></i>&nbsp;&nbsp;&nbsp;Immersion Trips</a>
        <a href="#Internships"><i class="fas fa-suitcase"></i>&nbsp;&nbsp;&nbsp;Internships</a>
    </div>
    <br />
    <br />
    <br />
    <div class="container main">
        <h1>Trip Management</h1>
        <hr />
        <h3>Students Registered</h3>
        <asp:Label ID="lblNoStud" runat="server" Text="" ></asp:Label>
        <asp:GridView ID="GVStudList" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="StudentAdmin" HeaderText="Admin Number" />
                <asp:BoundField DataField="TripID" HeaderText="ProgCode" />
                <asp:BoundField DataField="PassportNO" HeaderText="Passport Number" />
                <asp:BoundField DataField="PassportExpiry" DataFormatString="{0:d}" HeaderText="Passport Expiry" />
            </Columns>
        </asp:GridView>
        <asp:Button runat="server" class="btn btn-primary" Text="Back" ID="btnBack" OnClick="btnBack_Click" />
    </div>
</asp:Content>
