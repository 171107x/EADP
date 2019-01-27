<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeFile="AddCountry.aspx.cs" Inherits="EADP.AddCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
        <asp:TextBox ID="textboxCountry" runat="server" class="form-control"></asp:TextBox>
        <asp:Button ID="btnInsert" runat="server" Text="Insert" class="btn btn-primary" OnClick="btnInsert_Click"  />
        </div>
</asp:Content>
