<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="EADP.Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />        
        <br />
        <h2 style="text-align:center;"> Change Of Student Password</h2>
        <div class="form-horizontal">
            <div class="form-group ">
                <label class="control-label col-sm-4" for="email">Admission Number:</label>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbAdminNo" Enabled="False" ></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-4" for="pwd">Current Password:</label>
                <div class="col-sm-8"> 
                    <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control" TextMode="Password"></asp:TextBox> 
                </div>
            </div> 
            <div class="form-group">
                <label class="control-label col-sm-4" for="pwd">New Password:</label>
                <div class="col-sm-8"> 
                    <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" TextMode="Password"></asp:TextBox> 
                </div>
            </div>  
            <div class="form-group">
                <label class="control-label col-sm-4" for="pwd">Confirm New Password:</label>
                <div class="col-sm-8"> 
                    <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" TextMode="Password"></asp:TextBox> 
                </div>
            </div>
            <div class="col-sm-4">               
            </div>
            <div class="col-sm-8">
                <asp:label runat="server" ID="errorMsg" ForeColor="Red"></asp:label>
            </div>
            
        </div>   
        <div style="text-align:center;" draggable="auto">
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-light" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn btn-light" CausesValidation="False" OnClick="Button2_Click" />
        </div>
    </div>    
</asp:Content>
