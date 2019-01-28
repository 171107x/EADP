<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeFile="AddCountry.aspx.cs" Inherits="EADP.AddCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <center><h1>Update Countries</h1></center>
    <br />
    <br />
    <div class="container">
        <asp:Label ID="lblCountry" runat="server" Text="Enter Country:"></asp:Label>
        <asp:TextBox ID="textboxCountry" runat="server" class="form-control"></asp:TextBox>
        <asp:Button ID="btnInsert" runat="server" Text="Insert" class="btn btn-primary" OnClick="btnInsert_Click"  />
        <asp:Label ID="lberror" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
        <br />
        <asp:GridView ID="GridViewCountry" runat="server" Width="1137px" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewCountry_PageIndexChanging" CssClass="table table-bordered" OnSelectedIndexChanged="GridViewCountry_SelectedIndexChanged"  DataKeyNames="CountryID" OnRowCancelingEdit="GridViewCountry_RowCancelingEdit" OnRowEditing="GridViewCountry_RowEditing" OnRowUpdating="GridViewCountry_RowUpdating" OnRowDeleting="GridViewCountry_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Country ID">
                    <ItemTemplate>
                        <asp:Label ID="lbCountryID" runat="server" Text='<%# Eval("CountryID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <asp:Label ID="lbCountryName" runat="server" Text='<%# Eval("CountryName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbCountryName" runat="server" Text='<%# Eval("CountryName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Edit Country">
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" width="80" CommandName="Edit" />
                        </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button Text="Update" ID="btnupdate" runat="server" width="80" CommandName="Update" />
                        <asp:Button Text="Cancel" ID="btncancel" runat="server" width="80" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Delete Country" ShowDeleteButton="true" runat="server" />
            </Columns>
        </asp:GridView>
        </div>
</asp:Content>
 	