<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="EADP.StudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Container" style="text-align:center;">
        <asp:Label runat="server" style="" ID="ProgCode"></asp:Label> 
    </div>
    
    <div class="container">
        <table class="table">
            <tr>
                <td class="auto-style1">Student Admin:</td>
                <td>
                    <asp:Label ID="LblCustId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Student Name :</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    <asp:Label ID="LblCustname" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Gender</td>
                <td>
                    <asp:Label ID="LblAcno" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">School</td>
                <td>

                    <asp:Label ID="LblPrincipal" runat="server"></asp:Label>
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style1">PEMGroup</td>
                <td>
                    <asp:Label ID="LblMaturedDte" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Nationality</td>
                <td>
                    <asp:Label ID="LblMaturedAmt" Text="" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td class="auto-style1">Passport NO</td>
                <td>
                    <asp:Label ID="Label3" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Passport Expiry</td>
                <td>
                    <asp:Label ID="Label4" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Diet Constraint</td>
                <td>
                    <asp:Label ID="Label5" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Medical History</td>
                <td>
                    <asp:Label ID="Label6" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">FAS scheme</td>
                <td>
                    <asp:Label ID="Label7" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Remarks</td>
                <td>
                    <asp:Label ID="Remarks" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
        </div>
</asp:Content>
