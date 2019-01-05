<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ConfirmParticulars.aspx.cs" Inherits="EADP.ConfirmParticulars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 229px;
        }
        .auto-style2 {
            width: 184px;
            height: 73px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container" style="text-align:center;">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <p>Click Confirm if all is correct/Click on update to update your particulars</p>
    </div>
    <div class="container">        
        <table class="table">
            <tr>
                <td class="auto-style2">Study Diploma</td>
                <td>
                    <asp:Label ID="LblDiploma" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Admin No</td>
                <td>
                    <asp:Label ID="Label14" runat="server"></asp:Label>
                </td>
            </tr>        
            <tr>
                <td class="auto-style2">Name</td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Gender</td>
                <td>
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>       
            <tr>
                <td class="auto-style2">Date of Birth</td>
                <td>
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">PEM Group</td>
                <td>
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Citizenship</td>
                <td>
                    <asp:Label ID="tdCountry" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Mobile No</td>
                <td>
                    <asp:Label ID="tdMobileNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Diet Constraint</td>
                <td>
                    <asp:Label ID="tdDiet" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">Medical Condition</td>
                <td>
                    <asp:Label ID="tdMedical" runat="server"></asp:Label>
                </td>
            </tr>
        </table>                 
        <div style="text-align:center;" draggable="auto">
            <asp:Button ID="Button1" runat="server" Text="Confirm" CssClass="btn" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Update" CssClass="btn" />

        </div>       
        
    </div>
</asp:Content>
