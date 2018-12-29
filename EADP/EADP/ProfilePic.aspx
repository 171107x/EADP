<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ProfilePic.aspx.cs" Inherits="EADP.ProfilePic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">          
    <link href="Content/jquery.Jcrop.css" rel="stylesheet" />
    <script src="scripts/jquery.min.js"></script>
    <script src="scripts/jquery.Jcrop.js"></script>
    <script>
        $(document).ready(function () {
                    $('#<%=imgUpload.ClientID%>').Jcrop({
                        onSelect: SelectCropArea,
                        aspectRatio: 1,
                        boxWidth: 300,
                        boxHeight: 300,
                        setSelect:   [50, 0, 300,300],
                        allowResize: false
                    });
                });
                function SelectCropArea(c) {
                    $('#<%=X.ClientID%>').val(parseInt(c.x));
                    $('#<%=Y.ClientID%>').val(parseInt(c.y));
                    $('#<%=W.ClientID%>').val(parseInt(c.w));
                    $('#<%=H.ClientID%>').val(parseInt(c.h));
                }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />        
    <br />
    <div class="container">
    <table style="text-align:center;">
        <tr>
            <td>
                Select Image File : 
            </td>
            <td>
                <asp:FileUpload ID="FU1" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnUpload" runat="server" cssClass="btn btn-secondary" Text="Upload" OnClick="btnUpload_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
            </td>
        </tr>
    </table>        
    <asp:Panel ID="panCrop" runat="server" Visible="false">
        <table style="text-align:center;">
            <tr>
                <td>
                    <asp:Image ID="imgUpload" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCrop" runat="server" cssClass="btn btn-secondary" Text="Crop & Save" OnClick="btnCrop_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <%-- Hidden field for store cror area --%>
                    <asp:HiddenField ID="X" runat="server" />
                    <asp:HiddenField ID="Y" runat="server" />
                    <asp:HiddenField ID="W" runat="server" />
                    <asp:HiddenField ID="H" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
        </div>
</asp:Content>
