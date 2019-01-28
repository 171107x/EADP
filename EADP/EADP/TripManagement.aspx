<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TripManagement.aspx.cs" Inherits="EADP.TripManament" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">
    <style>
        body {
            font-family: "Lato", sans-serif;
        }

        .sidenav {
            height: 100%;
            width: 250px;
            position: fixed;
            z-index: 1;
            top: 0;
            left: 0;
            background-color: #282639;
            overflow-x: hidden;
            padding-top: 90px;
        }

            .sidenav a {
                /*border-top: 0.5px purple solid;*/
                padding: 15px 20px 15px 20px;
                text-decoration: none;
                color: #818181;
                display: block;
            }

                .sidenav a:hover {
                    background-color: lightslategrey;
                    color: lightblue;
                }

        .active {
            background-color: #171623;
            color: lightblue !important;
        }

        .main {
            margin-left: 300px;
            padding: 0px 10px;
        }

        @media screen and (max-height: 450px) {
            .sidenav {
                padding-top: 15px;
            }

                .sidenav a {
                    font-size: 18px;
                }
        }

        @media screen and (max-width: 1024px) {
            .sidenav {
                display: none !important;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sidenav">
        <a href="#" class="active"><i class="fas fa-home"></i>&nbsp;&nbsp;Trip Management</a>
        <a href="studyTrip.aspx" onclick="BtnRedirect_Click"><i class="fas fa-book"></i>&nbsp;&nbsp;&nbsp;Study Trips</a>
        <a href="ImmersionTrip.aspx"><i class="fas fa-atlas"></i>&nbsp;&nbsp;&nbsp;Immersion Trips</a>
        
    </div>
    <div class="container main">
        <br />
        <br />
        <br />
        <h1>Trip Management</h1>
        <%--        <div class="row">
            <div class="col-xs-6 col-md-3">
                <h4 class="thumbnail">
                    Number of Trips Avilable: <span class="label label-info">3</span>
                </h4>
            </div>
            <div class="col-xs-6 col-md-3">
                <h4 class="thumbnail">
                    Students registered: <span class="label label-info">123</span>
                </h4>
            </div>
            <div class="col-xs-6 col-md-3">
                <h4 class="thumbnail">
                   Pending requests: <span class="label label-info">59</span>
                </h4> 
            </div>
            <div class="col-xs-6 col-md-3">
                <h4 class="thumbnail">
                   Students registered: <span class="label label-info">123</span>
                </h4>
            </div>
        </div>--%>
        <hr />
        <h3>Current/Future Trips</h3>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GridViewTrip" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewTrip_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="TripID" HeaderText="ProgCode" />
                <asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HeaderText="Start Date" />
                <asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HeaderText="End Date" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="ETripPrice" DataFormatString="{0:C2}" HeaderText="Price" />
                <asp:BoundField DataField="Duration" HeaderText="Duration" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="MaxStudent" HeaderText="Maximum Student Intake" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                    FooterStyle-Width="10%" >
<FooterStyle Width="10%"></FooterStyle>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Width="10%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="StaffName" HeaderText="Staff In Charge" />
                <asp:TemplateField HeaderText="Student List">
                    <ItemTemplate>
                        <asp:LinkButton ID="studList" runat="server" OnClick="studList_Click">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" HeaderText="Update" SelectText="Update" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="tripDelete" runat="server" OnClientClick="return confirm('Delete?')" OnClick="tripDelete_Click">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <%--<HeaderStyle BackColor="white" Font-Bold="true" ForeColor="White" />--%>
        </asp:GridView>
        <asp:Button runat="server" class="btn btn-primary" Text="Add Trip" ID="btnClr" OnClick="btnClr_Click" />
        <br />
        <hr />
        <h3>Trips History</h3>
        <asp:GridView ID="GridViewHist" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" HeaderStyle-Width="10%" ItemStyle-Width="10%"
            FooterStyle-Width="10%">
            <Columns>
                <asp:BoundField DataField="TripID" HeaderText="ProgCode" />
                <asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HeaderText="Start Date" />
                <asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HeaderText="End Date" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="ETripPrice" DataFormatString="{0:C2}" HeaderText="Price" />
                <asp:BoundField DataField="Duration" HeaderText="Duration" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="MaxStudent" HeaderText="Maximum Student Intake" />
                <asp:BoundField DataField="StaffName" HeaderText="Staff In Charge" />
                <asp:TemplateField HeaderText="Student List">
                    <ItemTemplate>
                        <asp:LinkButton ID="studList" runat="server" OnClick="studList_Click">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <%--<HeaderStyle BackColor="#282639" Font-Bold="true" ForeColor="White" />--%>
        </asp:GridView>

        <hr />
        <br />
    </div>
    <!--container end-->
</asp:Content>
