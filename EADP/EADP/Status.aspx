<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="EADP.Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="text-align:center;">
        <h1 style="text-align:center;">Status</h1>
        <div class="row">
          <div class="col-xs-6 col-sm-4 col-lg-2">
              <asp:Image runat="server"></asp:Image>

          </div>
          <div class="col-xs-6 col-sm-4 col-lg-2">
              <asp:Label runat="server" ID="lblCountry" >Country</asp:Label>
          </div>
          <div class="col-xs-6 col-sm-4 col-lg-2">
              <asp:Label runat="server" ID="lblStatus">Pending</asp:Label>
          </div>
        </div>
    </div>
</asp:Content>
