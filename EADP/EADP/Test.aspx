<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EADP.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <br />
         <div class="form-group">
            <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Enter your Email"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        </div>
         <div style="text-align:center;" draggable="auto">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn" OnClick="submitBtn_Click" />
            <asp:Button ID="resetBtn" runat="server" Text="Reset" CssClass="btn" />
            </div>
       
        <asp:Label ID="status" runat="server" ></asp:Label>
        </div>
        

        
        

        </asp:Content>
