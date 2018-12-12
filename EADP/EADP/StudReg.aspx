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
                                
                    <asp:TextBox runat="server" ID="tbNationality" CssClass="form-control"></asp:TextBox> 
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
       
        
    </div>
    
</asp:Content>


