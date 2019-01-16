<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="regStudList.aspx.cs" Inherits="EADP.regStudList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <h3>Registered Students</h3>
        <asp:GridView ID="GVStudList" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TripID" HeaderText="Trip ID" />
                <asp:BoundField DataField="StudentAdmin" HeaderText="Admin Number" />
                <asp:BoundField DataField="PassportNO" HeaderText="Passport Number" />
                <asp:BoundField DataField="PassportExpiry" HeaderText="PassportExpiry" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
