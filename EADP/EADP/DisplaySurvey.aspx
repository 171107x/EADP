<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DisplaySurvey.aspx.cs" Inherits="EADP.DisplaySurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <br />
    <br />
    <style>
        #ContentPlaceHolder1_BtnSurvey {
            margin-left:50%;
        }
    </style>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="Click_Delete" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="SurveyQID" HeaderText="SurveyQID" />
            <asp:CommandField HeaderText="Update" SelectText="Update" ShowSelectButton="True" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnSurvey" runat="server" Text="Create Survey" />

</asp:Content>
