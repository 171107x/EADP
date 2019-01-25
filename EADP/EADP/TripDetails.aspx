<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TripDetails.aspx.cs" Inherits="EADP.TripDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <div class='col-sm-12'>
            <div class='card'>
                <div class='card-body'>
                    <img class='card-img-top col-sm-4 thumbnail' src='tripImg/thailand.jpg' style='width: 400px; height: 400px;'/>
                    <h3 id="country" class='card-title bold'>Thailand
                    </h3>
                    <p class='card-text'>
                        <h4>Description:</h4>
                        It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. 
                        The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. 
                        Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.
                         Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
                    </p>
                    <h4>Date:</h4>
                    <p class='card-text'>
                        Start Date: 21 Jan 2019
                    </p>
                    <p class='card-text'>
                        Start Date: 10 Feb 2019
                    </p>
                    <h4>Cost:</h4>
                    <p class='card-text'>
                        Price: $1500
                    </p>

                    <br />
                    <asp:Button class='btn btn-primary float-right' runat='server' Text='Register' OnClick="Unnamed1_Click"/>
                    <asp:Button class='btn btn-primary float-right' runat='server' Text='Download Itenerary'/>
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
