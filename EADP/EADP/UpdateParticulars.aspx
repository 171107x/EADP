<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="UpdateParticulars.aspx.cs" Inherits="EADP.StudReg" %>
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
        </table> 
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Citizenship"></asp:Label>                    
                    <br />
                    <asp:DropDownList ID="DdlCountry" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem>Singaporean</asp:ListItem>
                        <asp:ListItem>Malaysian</asp:ListItem>
                        <asp:ListItem>Indonesian</asp:ListItem>
                        <asp:ListItem>China</asp:ListItem>
                        <asp:ListItem>India</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>                                                                   
                    </asp:DropDownList>                    
                    </div>           
         
               <div class="form-group">
                
                    <asp:Label ID="Label8" runat="server" Text="Mobile No"></asp:Label>
                            
                    <asp:TextBox runat="server" ID="tbMobileNo" CssClass="form-control"></asp:TextBox>                
                       
          </div>
           <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Diet Constraint"></asp:Label>                   
                    <asp:TextBox runat="server" ID="tbDiet"  CssClass="form-control"></asp:TextBox>                
                </div>
            <div class="form-group">
                    <asp:Label ID="Label12" runat="server" Text="Medical Condition"></asp:Label>                                   
                    <asp:TextBox runat="server" ID="tbMedical" CssClass="form-control"></asp:TextBox>                
                </div>                     
        <div style="text-align:center;" draggable="auto">
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn" />
            </div>
       <asp:Label runat="server" ID="lblResult" ForeColor="Red"></asp:Label>
        
    </div>
    
</asp:Content>


