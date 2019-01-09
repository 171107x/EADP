<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListofStud.aspx.cs" Inherits="EADP.ListofStud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />

    <div class="container">
        <div class="container" style="text-align:center;">
        <asp:Label runat="server" style="" ID="ProgCode"></asp:Label> 
            </div>
        <asp:Label ID="studsearchLb" runat="server" Text="Enter Student Admin Number" Font-Size="Small"></asp:Label>
        <asp:TextBox ID="tbstudsearch" runat="server"></asp:TextBox>
        <asp:Button ID="studsearchbtn" runat="server" Text="Search" OnClick="studsearchbtn_Click"/>
        <br />
        <br />
        <asp:GridView runat="server" ID="GridViewTD" CssClass="table table-striped" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewTD_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="StudentAdmin" HeaderText="Student Admin" />
            <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="school" HeaderText="Diploma" />
            <asp:BoundField DataField="PEMGroup" HeaderText="PEM Group" />
            <asp:CommandField SelectText="More Details" ShowSelectButton="True" />
        </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Download to Excel" Width="154px" OnClick="Button1_Click" />
    </div>
    
    
      
</asp:Content>
