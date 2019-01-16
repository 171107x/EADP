<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="EADP.StudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 342px;
            height: 73px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="Container" style="text-align:center;">
        <asp:Label runat="server" style="" ID="ProgCode"></asp:Label> 
    </div>
    
    <div class="container">
        <table class="table">
            <tr>
                <td class="auto-style2">Student Admin:</td>
                <td>
                    <asp:Label ID="LblAdmin" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Student Name :</td>
                <td>                    
                    <asp:Label ID="LblStudname" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Gender</td>
                <td>
                    <asp:Label ID="LblGender" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">School</td>
                <td>

                    <asp:Label ID="LblSchool" runat="server"></asp:Label>
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style2">PEMGroup</td>
                <td>
                    <asp:Label ID="LblPEMGroup" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Nationality</td>
                <td>
                    <asp:Label ID="LblNationality" Text="" runat="server"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td class="auto-style2">Passport NO</td>
                <td>
                    <asp:Label ID="Label3" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Passport Expiry</td>
                <td>
                    <asp:Label ID="Label4" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Diet Constraint</td>
                <td>
                    <asp:Label ID="Label5" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Medical History</td>
                <td>
                    <asp:Label ID="Label6" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">FAS scheme</td>
                <td>
                    <asp:Label ID="Label7" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Remarks</td>
                <td>
                    <asp:Label ID="Remarks" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
        </div>
</asp:Content>
