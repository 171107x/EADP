<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="EADP.Survey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <div class="form-group" style="margin-top:50px;">
            <asp:Label ID="LblAdmin" runat="server" Text="Admin No"></asp:Label>       
             :
             <asp:Label ID="LblNo" runat="server"></asp:Label>
        </div>

    
    <div class="form-group">
            <asp:Label ID="LblQ1" runat="server" Text="Q1: Which of the following Countries would you like to travel to?"></asp:Label><br />
            <asp:TextBox ID="tbQ1" runat="server" Width="236px"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblQ2" runat="server" Text="Q2: Which season would you prefer when travelling on a school trip?"></asp:Label>
            <br />
            <asp:TextBox ID="tbQ2" runat="server" Width="236px"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblQ3" runat="server" Text="Q3: How much would you be willing to pay for a trip overseas?"></asp:Label>
            <br />
            <asp:TextBox ID="tbQ3" runat="server" Width="236px"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblQ4" runat="server" Text="Q4: If you wanted to know more information about the school trip, would you prefer contacting the teacher or a F.A.Q? "></asp:Label>
            <br />
            <asp:TextBox ID="tbQ4" runat="server" Width="236px"></asp:TextBox>
        </div>
         <div style="text-align:center;" draggable="auto">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn" OnClick="submitBtn_Click" />
            <asp:Button ID="resetBtn" runat="server" Text="Reset" CssClass="btn" OnClick="resetBtn_Click1" />
            </div>
        </div>
        

        </asp:Content>
