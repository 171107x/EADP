<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListofStud.aspx.cs" Inherits="EADP.ListofStud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 90px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />

    <div class="container">
        <div class="container" style="text-align:center;">
        <asp:Label runat="server" style="" ID="ProgCode"></asp:Label> 
            </div>
        <asp:Label ID="studsearchLb" runat="server" Text="Enter Student Admin Number" Font-Size="Small"></asp:Label>
        <asp:TextBox ID="tbstudsearch" runat="server"></asp:TextBox>
        <asp:Button ID="studsearchbtn" runat="server" Text="Search" OnClick="studsearchbtn_Click"/>
        <br />
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Accepted students: "></asp:Label>
                </td>
                <td class="auto-style2" style="text-align:center;">
                    <asp:Label ID="lbStudent" runat="server"></asp:Label>
                </td>
            </tr>           
        </table>
        <asp:GridView runat="server" ID="GridViewTD" CssClass="table" AutoGenerateColumns="False" OnRowCommand="GridViewTD_RowCommand" OnSelectedIndexChanged="GridViewTD_SelectedIndexChanged">
        <Columns>            
            <asp:TemplateField>   
                <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StudentAdmin" HeaderText="Student Admin" />
            <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="school" HeaderText="Diploma" />
            <asp:BoundField DataField="PEMGroup" HeaderText="PEM Group" />
            <asp:CommandField SelectText="More Details" ShowSelectButton="True" />
            <%--<asp:CommandField ButtonType="Button" EditText="Accept" ShowEditButton="True" />--%>
            <%--<ItemTemplate>
                <asp:Button ID="btnEdit" Text="Edit" runat="server" />
                <asp:Button ID="btnDelete" Text="Delete" runat="server"/>
             </ItemTemplate>--%>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:Button ID="btnAccept" CommandName="Accept" Text="Accept" runat="server" CommandArgument="<%# Container.DataItemIndex %>"/>
                <asp:Button ID="btnReject" CommandName="Reject" Text="Reject" runat="server" CommandArgument="<%# Container.DataItemIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Download to Excel" Width="154px" OnClick="Button1_Click" />
    </div>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    
    
    
      
</asp:Content>
