<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ExtraStudentDetails.aspx.cs" Inherits="EADP.ExtraStudentDetails" %>
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
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Willing to be on wait list?"></asp:Label>                    
                    <br />
                    <asp:DropDownList ID="DdlWait" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>                        
                        <asp:ListItem>No</asp:ListItem>                                                                   
                    </asp:DropDownList>                    
                    </div>           
         
               <div class="form-group">
                
                    <asp:Label ID="Label8" runat="server" Text="Passport No"></asp:Label>
                            
                    <asp:TextBox runat="server" ID="tbPassportNo" CssClass="form-control"></asp:TextBox>                
                       
          </div>
           <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Passport Expiry Date"></asp:Label>                   
                    <asp:TextBox runat="server" ID="tbDate"  CssClass="form-control" TextMode="Date"></asp:TextBox>                
                </div>
        <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="PSEA Balance $"></asp:Label>                   
                    <asp:TextBox runat="server" ID="TextBox1"  CssClass="form-control" TextMode="Number"></asp:TextBox>                
                </div>
            <div class="form-group">
                    <asp:Label ID="Label12" runat="server" Text="Are you applying for financial assistance (FASOP) to pay for part of the trip cost? "></asp:Label>     <br />                              
                    <asp:DropDownList ID="DdlFAS" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>                        
                        <asp:ListItem>No</asp:ListItem>                                                                   
                    </asp:DropDownList>                  
                </div>                     
        <div style="text-align:center;" draggable="auto">
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn" />
            </div>
       <asp:Label runat="server" ID="lblResult" ForeColor="Red"></asp:Label>
        
    </div>
</asp:Content>
