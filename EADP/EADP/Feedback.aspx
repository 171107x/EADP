<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="EADP.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <div class="form-group" style="margin-top:50px;">
             <h2> Feedback Form</h2>
            <asp:Label ID="LblAdmin" runat="server" Text="Admin No:"></asp:Label>  &nbsp     <asp:Label ID="Lblno" runat="server"></asp:Label>
             <br />
             <asp:Label ID="LblTrip" runat="server" Text="Trip Code:"></asp:Label> &nbsp     <asp:Label ID="Lblcode" runat="server"></asp:Label>   
             <br />

        </div>

    
        <div class="form-group">
            <asp:Label ID="LblRate" runat="server" Text="From a scale of 1 - 10, how much would you rate your trip??(1 being unenjoyable, 10 being very enjoyable)"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>--SELECT--</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="form-group">
            <asp:Label ID="LblComments" runat="server" Text="Do you have any comments about the trip?"></asp:Label>
            <asp:TextBox ID="tbComments" runat="server" CssClass="form-control" Width="194px"></asp:TextBox>
        </div>
         <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Would you recommend your friends/classmates for this trip?"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" Height="30px" Width="450px" >
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </div>
         <div style="text-align:center;" draggable="auto">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn" OnClick="submitBtn_Click"/>
            <asp:Button ID="resetBtn" runat="server" Text="Reset" CssClass="btn" />
            </div>
        </div>
</asp:Content>
