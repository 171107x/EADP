﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditSurvey.aspx.cs" Inherits="EADP.EditSurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-group">
    <h3 style="margin-top:50px;">Questionnaire</h3>
    <h4>Edit your questions below.</h4>
            </div>
    <div class="form-group">
            <asp:Label ID="LblCountry" runat="server" Text="Q1"></asp:Label>
            <asp:TextBox ID="TextBoxq1" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblSeason" runat="server" Text="Q2"></asp:Label>
            <asp:TextBox ID="TextBoxq2" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblCost" runat="server" Text="Q3"></asp:Label>
            <asp:TextBox ID="TextBoxq3" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblReach" runat="server" Text="Q4 "></asp:Label>
            <asp:TextBox ID="TextBoxq4" runat="server"></asp:TextBox>         
        </div>
         <div style="text-align:center;" draggable="auto">
            <asp:Button ID="updateBtn" runat="server" Text="Update" CssClass="btn" OnClick="updateBtn_Click" />
            <asp:Button ID="resetBtn" runat="server" Text="Reset" CssClass="btn" />
             <BR />
             <asp:Label ID="Label2" runat="server" ForeColor="#FF3300"></asp:Label>
            </div>
        </div>
</asp:Content>