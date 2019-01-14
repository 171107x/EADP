<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="EADP.Statistics" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <div class="form-group">
             <asp:Label ID="LblPercent" runat="server" Text="Survey results for Students preference in trip location  "></asp:Label>
             <asp:Chart ID="Chart1" runat="server" >
             <Titles>  
                    <asp:Title ShadowOffset="3" Name="Items" />  
                </Titles>  
                <Legends>  
                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />  
                </Legends>  
                <Series>  
                    <asp:Series Name="Default" ChartType="Pie" />  
                </Series>  
                <ChartAreas>  
                    <asp:ChartArea Name="ChartArea1" BorderWidth="1" />  
                </ChartAreas>  
        </asp:Chart>
             <asp:Button ID="BtnSurvey" runat="server" OnClick="BtnSurvey_Click" Text="Do Survey" />
             </div>
        </div>
        
             
    <asp:TextBox ID="TxtCity" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Get Weather Information" OnClick="GetWeatherInfo" />
    <table id="tblWeather" runat="server" border="0" cellpadding ="0" cellspacing="0" visible="false">
        <tr>
            <th colspan="2">
                Weather Information
            </th>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Image ID="imgWeathericon" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity_Country" runat="server" />
                <asp:Image ID="imgCountryflag" runat="server" />
                <asp:Label ID="lblDescription" runat="server" />
                Humidity
                <asp:Label ID="lblHumidity" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Temperature: (Min:
                <asp:Label ID="lblTempmin" runat="server" />
                Max:
                <asp:Label ID="lblTempmax" runat="server" />
                Day:
                <asp:Label ID="lblTempday" runat="server" />
                Night:
                <asp:Label ID="lblTempnight" runat="server" />
            </td>
        </tr>
    </table>
        
             
</asp:Content>
