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
                        <asp:Image ID="imgTripDetails" runat="server" class='card-img-top col-sm-4 thumbnail' style='width: 400px; height: 400px;margin-right:20px;'/>
                        <%--<img class='card-img-top col-sm-4 thumbnail' src="" style='width: 400px; height: 400px;' />--%>
                        <h3 id="country" class='card-title bold'>
                            <asp:Label ID="lblCn" runat="server" Text=""></asp:Label>
                        </h3>
                        <p class='card-text'>
                            <h4>Description:</h4>
                            <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label>
                        </p>
                        <h4>Date:</h4>
                        <p class='card-text'>
                            Date of Departure: <asp:Label ID="lblSD" runat="server" Text=""></asp:Label>
                        </p>
                        <p class='card-text'>
                            Date of Arrival: <asp:Label ID="lblED" runat="server" Text=""></asp:Label>
                        </p>
                        <h4>Cost:</h4>
                        <p class='card-text'>
                            Price: $<asp:Label ID="lblPrc" runat="server" Text=""></asp:Label>
                        </p>
                        <br />
                        <asp:Button class='btn btn-primary float-right' runat='server' Text='Register' OnClick="Unnamed1_Click"/>
                        <%--<asp:Button class='btn btn-primary float-right' runat='server' Text='Download Itenerary' />--%>
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>