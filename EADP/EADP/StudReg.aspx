<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="StudReg.aspx.cs" Inherits="EADP.StudReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 229px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="text-align:center;">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    <div class="container">        
        <table class="table">
            <tr>
                <td class="auto-style1">Study Diploma</td>
                <td>
                    <asp:Label ID="LblDiploma" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="table">
            <tr>
                <td class="auto-style1">Admin No</td>
                <td>
                    <asp:Label ID="Label14" runat="server"></asp:Label>
                </td>
            </tr>
        </table>        
         <table class="table">
            <tr>
                <td class="auto-style1">Name</td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table> 
        <table class="table">
            <tr>
                <td class="auto-style1">Gender</td>
                <td>
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
        </table> 
        <table class="table">
            <tr>
                <td class="auto-style1">Date of Birth</td>
                <td>
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
        </table>                 
        <table class="table">
            <tr>
                <td class="auto-style1">PEM Group</td>
                <td>
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
            </tr>
        </table> 
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Nationality"></asp:Label>                                
                    
                    <asp:DropDownList ID="DdlCountry" runat="server">
                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem>Algerian</asp:ListItem>
                        <asp:ListItem>American</asp:ListItem>
                        <asp:ListItem>Argentinean </asp:ListItem>
                        <asp:ListItem>Australian </asp:ListItem>
                        <asp:ListItem>Austrian </asp:ListItem>
                        <asp:ListItem>Bangladeshi </asp:ListItem>
                        <asp:ListItem>Belgian </asp:ListItem>
                        <asp:ListItem>British </asp:ListItem>
                        <asp:ListItem>Bruneian </asp:ListItem>
                        <asp:ListItem>Burmese </asp:ListItem>
                        <asp:ListItem>Cambodian </asp:ListItem>
                        <asp:ListItem>Canadian </asp:ListItem>
                        <asp:ListItem>Chinese </asp:ListItem>
                        <asp:ListItem>Czech </asp:ListItem>
                        <asp:ListItem>Danish </asp:ListItem>
                        <asp:ListItem>Dutch </asp:ListItem>
                        <asp:ListItem>Egyptian </asp:ListItem>
                        <asp:ListItem>Filipino </asp:ListItem>
                        <asp:ListItem>French </asp:ListItem>
                        <asp:ListItem>German </asp:ListItem>
                        <asp:ListItem>Hungarian </asp:ListItem>
                        <asp:ListItem>Indian </asp:ListItem>
                        <asp:ListItem>Indonesian </asp:ListItem>
                        <asp:ListItem>Italian </asp:ListItem>
                        <asp:ListItem>Japanese </asp:ListItem>
                        <asp:ListItem>Jordanian </asp:ListItem>
                        <asp:ListItem>Laotian </asp:ListItem>
                        <asp:ListItem>Malaysian </asp:ListItem>
                        <asp:ListItem>Mexican </asp:ListItem>
                        <asp:ListItem>Mongolian </asp:ListItem>
                        <asp:ListItem>Moroccan </asp:ListItem>
                        <asp:ListItem>Nepalese </asp:ListItem>
                        <asp:ListItem> New Zealander</asp:ListItem>
                        <asp:ListItem>Nigerian </asp:ListItem>
                        <asp:ListItem>Pakistani </asp:ListItem>
                        <asp:ListItem>Portuguese</asp:ListItem>
                        <asp:ListItem>Russian </asp:ListItem>
                        <asp:ListItem>Saudi</asp:ListItem>
                        <asp:ListItem>Serbian</asp:ListItem>
                        <asp:ListItem>Singaporean</asp:ListItem>
                        <asp:ListItem>Spanish</asp:ListItem>
                        <asp:ListItem>Taiwanese</asp:ListItem>
                        <asp:ListItem>Thai </asp:ListItem>
                        <asp:ListItem>Turkish </asp:ListItem>
                        <asp:ListItem>Vietnamese</asp:ListItem>                        
                    </asp:DropDownList>                    
                    </div>           
         
               <div class="form-group">
                
                    <asp:Label ID="Label8" runat="server" Text="Mobile No"></asp:Label>
                            
                    <asp:TextBox runat="server" ID="tbMobileNo" CssClass="form-control"></asp:TextBox>                
                       
          </div>
           <div class="form-group">
                    <asp:Label ID="Label9" runat="server" Text="Passport No"></asp:Label>
                            
                    <asp:TextBox runat="server" ID="tbPassport" CssClass="form-control"></asp:TextBox>                
              </div> 
            <div class="form-group">
                    <asp:Label ID="Label10" runat="server" Text="Passport Expiry"></asp:Label>
                             
                   <asp:TextBox runat="server" ID="tbPassportE" CssClass="form-control" TextMode="Date"></asp:TextBox> 
                </div>
           <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Diet Constraint"></asp:Label>                   
                    <asp:TextBox runat="server" ID="tbDiet" Height="73px" TextMode="MultiLine" Width="219px" CssClass="form-control"></asp:TextBox>                
                </div>
            <div class="form-group">
                    <asp:Label ID="Label12" runat="server" Text="Medical Background"></asp:Label>                                   
                    <asp:TextBox runat="server" ID="tbMedical" Height="73px" TextMode="MultiLine" Width="219px" CssClass="form-control"></asp:TextBox>                
                </div>
            <div class="form-group">
                <asp:Label ID="Label13" runat="server" Text="Remarks"></asp:Label>
                                    
                <asp:TextBox runat="server" ID="tbRemarks" CssClass="form-control"></asp:TextBox> 
                
                </div>         
        <div style="text-align:center;" draggable="auto">
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn" />
            </div>
       <asp:Label runat="server" ID="lblResult"></asp:Label>
        
    </div>
    
</asp:Content>


