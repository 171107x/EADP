<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EADP.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <div class="form-group">
            <asp:Label ID="LblAdmin" runat="server" Text="Admin No"></asp:Label>       
            <asp:TextBox ID="tbAdmin" runat="server" CssClass="form-control" Width="194px"></asp:TextBox>
        </div>

    
    <div class="form-group">
            <asp:Label ID="LblCountry" runat="server" Text="Q1:"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Vertical" Height="30px" Width="450px" >
                <asp:ListItem>Japan</asp:ListItem>
                <asp:ListItem>China</asp:ListItem>
                <asp:ListItem>Korea</asp:ListItem>
                <asp:ListItem>New Zealand</asp:ListItem>
                <asp:ListItem>France</asp:ListItem>
                <asp:ListItem>Germany</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="form-group">
            <asp:Label ID="LblSeason" runat="server" Text="Q2: Which season would you prefer when travelling on a school trip?"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Vertical" Height="30px" Width="450px" >
                <asp:ListItem>Spring</asp:ListItem>
                <asp:ListItem>Summer</asp:ListItem>
                <asp:ListItem>Autumn</asp:ListItem>
                <asp:ListItem>Winter</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="form-group">
            <asp:Label ID="LblCost" runat="server" Text="Q3: How much would you be willing to pay for a trip overseas?"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Vertical" Height="30px" Width="450px" >
                <asp:ListItem>500</asp:ListItem>
                <asp:ListItem>1000</asp:ListItem>
                <asp:ListItem>1500</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="form-group">
            <asp:Label ID="LblReach" runat="server" Text="Q4: If you wanted to know more information about the school trip, would you prefer contacting the teacher or a F.A.Q? "></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Vertical" Height="30px" Width="450px" >
                <asp:ListItem>Teacher</asp:ListItem>
                <asp:ListItem>F.A.Q</asp:ListItem>
                <asp:ListItem>Both</asp:ListItem>
            </asp:RadioButtonList>
        </div>
         <div style="text-align:center;" draggable="auto">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn" />
            <asp:Button ID="resetBtn" runat="server" Text="Reset" CssClass="btn" />
            </div>
        </div>
        

        </asp:Content>
