<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListofStud.aspx.cs" Inherits="EADP.ListofStud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="container" style="text-align:center;">
        <asp:Label runat="server" style="" ID="ProgCode"></asp:Label> 
            </div>       
        <asp:GridView runat="server" ID="GridViewTD" CssClass="table table-striped" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StudentAdmin" HeaderText="Student Admin" />
            <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="diploma" HeaderText="Diploma" />
            <asp:BoundField DataField="PEMGroup" HeaderText="PEM Group" />
            <asp:CommandField SelectText="More Details" ShowSelectButton="True" />
        </Columns>
        </asp:GridView>
    </div>
    
</asp:Content>
