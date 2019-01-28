<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Createsurvey.aspx.cs" Inherits="EADP.Createsurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-group">
    <h3 style="margin-top:50px;">Questionnaire</h3>
    <h4>Add your questions below.</h4>
            </div>
    <div class="form-group">
            <asp:Label ID="LblCountry" runat="server" Text="Q1"></asp:Label>
            <asp:TextBox ID="TextBoxq1" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field is required!" ControlToValidate="TextBoxq1" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="LblSeason" runat="server" Text="Q2"></asp:Label>
            <asp:TextBox ID="TextBoxq2" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This field is required!" ControlToValidate="TextBoxq2" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="LblCost" runat="server" Text="Q3"></asp:Label>
            <asp:TextBox ID="TextBoxq3" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="This field is required!" ControlToValidate="TextBoxq3" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="LblReach" runat="server" Text="Q4 "></asp:Label>
            <asp:TextBox ID="TextBoxq4" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This field is required!" ControlToValidate="TextBoxq4" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
         <div style="text-align:center;" draggable="auto">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn" OnClick="submitBtn_Click" />
            <asp:Button ID="resetBtn" runat="server" Text="Reset" CssClass="btn" OnClick="resetBtn_Click" />
            </div>
        </div>
        

</asp:Content>
