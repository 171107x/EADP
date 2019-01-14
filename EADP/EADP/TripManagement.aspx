<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TripManagement.aspx.cs" Inherits="EADP.TripManament" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
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
                    FooterStyle-Width="10%" />
                <asp:BoundField DataField="StaffName" HeaderText="Staff In Charge" />
                <asp:TemplateField HeaderText="Student List">
                    <ItemTemplate>
                        <asp:LinkButton ID="studList" runat="server">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" HeaderText="Update" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="tripDelete" runat="server" OnClientClick="return confirm('Delete?')" OnClick="tripDelete_Click">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <%--<HeaderStyle BackColor="white" Font-Bold="true" ForeColor="White" />--%>
        </asp:GridView>
        <asp:Button runat="server" class="btn btn-primary" Text="Add Trip" ID="btnClr" OnClick="btnClr_Click" />
        <br /><hr />
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
            </Columns>
            <%--<HeaderStyle BackColor="#282639" Font-Bold="true" ForeColor="White" />--%>
        </asp:GridView>

        <hr />
        <br />
    </div>
    <!--container end-->
</asp:Content>
