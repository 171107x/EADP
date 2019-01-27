<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="EADP.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />  
    <div class="container">
      <div class="jumbotron">
        <h1>Oh no!</h1><br />
        <h4>The page you're looking for doesn't exist..</h4><br />        
        <h4>Oops! You have probably entered the url wrongly and that's why you're seeing this page! Click <a style="font-weight:900; font-size:110%;" href="TripStudentView.aspx"> here </a> to go to homepage</h4><br />
        <h4>Sorry for the Inconvenience.</h4>
      </div>
    </div>
</asp:Content>
