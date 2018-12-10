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
        <div class="form-group">
            <asp:Label ID="LabelCourse" runat="server" Text="Study Diploma"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="30px" Width="450px" >
                <asp:ListItem>DIT</asp:ListItem>
                <asp:ListItem>DBI</asp:ListItem>
                <asp:ListItem>DFI</asp:ListItem>
                <asp:ListItem>DBA</asp:ListItem>
                <asp:ListItem>DIS</asp:ListItem>
                <asp:ListItem>DCS</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Admin No"></asp:Label>
                
            <asp:TextBox ID="tbAdmin" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">                
                    <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>                
                    <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
               
            <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Gender"></asp:Label>
                                 
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Height="30px" Width="450px">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:RadioButtonList>                    
                </div>
            <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Date Of Birth"></asp:Label>
                                 
                    <asp:TextBox runat="server" ID="TextBoxDB" CssClass="form-control" TextMode="Date"></asp:TextBox>             
               </div>
            <div class="form-group">
                
                    <asp:Label ID="Label6" runat="server" Text="PEM Group"></asp:Label>
                               
                    <asp:TextBox runat="server" ID="tbPEM" CssClass="form-control"></asp:TextBox>                
               </div>
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
                             
                   <asp:TextBox runat="server" ID="tdPassportE" CssClass="form-control" TextMode="Date"></asp:TextBox> 
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
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn" />
            </div>
       
        
    </div>
    
</asp:Content>


