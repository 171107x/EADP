<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wrong.aspx.cs" Inherits="EADP.wrong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                Select Image File : 
            </td>
            <td>
                <asp:FileUpload ID="FU1" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
            </td>
        </tr>
    </table>        
    <asp:Panel ID="panCrop" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <asp:Image ID="imgUpload" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCrop" runat="server" Text="Crop & Save" OnClick="btnCrop_Click" />
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
        <table style="width:100%;text-align:center;">
            <tr>
                <td> <img id="blah" width='100' height='100' src="http://placehold.it/180" alt="your image" /></td>
            </tr>
            <tr>
                <td> <input type='file' name='imageupload' onchange="readURL(this);" /></td>
            </tr>
        </table>
        <script>
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#blah')
                    .attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
        }
    </script>
    </form>
</body>
</html>
