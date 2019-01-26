<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TripStatus.aspx.cs" Inherits="EADP.TripStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <h1 style="text-align:center;">Status</h1>
    <%--<div class="container" style="text-align:center;">
        <h1 style="text-align:center;">Status</h1>
        <div class="row">
          <div class="col-xs-6 col-sm-4 col-lg-2">
              <asp:Image runat="server"></asp:Image>

          </div>
          <div class="col-xs-6 col-sm-4 col-lg-2">
              <asp:Label runat="server" ID="lblCountry" >Country</asp:Label>
          </div>
          <div class="col-xs-6 col-sm-4 col-lg-2">
              <asp:Label runat="server" ID="lblStatus">Pending</asp:Label>
          </div>
        </div>
    </div>--%>
    <div class="container">
        <asp:GridView ID="GVStatus" ItemType="EADP.DAL.StudentStatus" runat="server" AutoGenerateColumns="False" ShowHeader="False" Width="100%" CssClass="auto-style2" OnRowCommand="GVStatus_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemStyle Width="200px" />
                    <ItemTemplate>                        
                        <asp:Image ID="TripImg" Height="125px" Width="125px" runat="server" ImageUrl='<%# Item.Image %>' ImageAlign="Middle" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Country" ReadOnly="True"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TripStatus" ReadOnly="True"><ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemStyle Width="200px" />
                    <ItemTemplate>                                               
                            <asp:Button ID="btnCancel" CommandName="Cancel Trip" Text="Cancel Trip" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn"/>                     
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
</asp:Content>
