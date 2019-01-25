<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditTrip.aspx.cs" Inherits="EADP.EditTrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <h3 style="text-align: center">Add Trip</h3>
        <br />
        <asp:Label ID="lblValid" runat="server" Text="" Style="text-align: center;" ForeColor="Red"></asp:Label>
        <div class="form-group">
            <label for="tbProgCode">ProgCode</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbProgCode" ErrorMessage="ProgCode is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="tbProgCode" ErrorMessage="" OnServerValidate="ValidateProgCode"></asp:CustomValidator>
            <asp:TextBox ID="tbProgCode" runat="server" class="form-control" placeholder="Eg.Korea2017"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbProgYear">Start Date</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbProgYear" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbProgYear" runat="server" class="form-control" placeholder="DD-MM-YYYY" Type="date"></asp:TextBox>
            <%--<input type="email" class="form-control" id="exampleFormControlInput1" placeholder="DD-MM-YYYY" />--%>
        </div>
        <div class="form-group">
            <label for="tbEndDate">End Date</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEndDate" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbEndDate" runat="server" class="form-control" placeholder="DD-MM-YYYY" Type="date"></asp:TextBox>
        </div>
        <%--        <div class="form-group">
            <label for="tbCountry">Country</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbCountry" ErrorMessage="Country is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbCountry" runat="server" class="form-control" placeholder="Country"></asp:TextBox>
        </div>--%>
        <div class="form-group">
            <label for="ddlCountry">Country</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="-1" ErrorMessage="Please select a country." ForeColor="Red" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlCountry" runat="server" class="form-control">
                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                <asp:ListItem Value="Australia">Australia</asp:ListItem>
                <asp:ListItem Value="China">China</asp:ListItem>
                <asp:ListItem Value="Dubai">Dubai</asp:ListItem>
                <asp:ListItem Value="Germany">Germany</asp:ListItem>
                <asp:ListItem Value="Japan">Japan</asp:ListItem>
                <asp:ListItem Value="Korea">Korea</asp:ListItem>
                <asp:ListItem Value="New Zealand">New Zealand</asp:ListItem>
                <asp:ListItem Value="Thailand">Thailand</asp:ListItem>
                <asp:ListItem Value="Vietnam">Vietnam</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--        <div class="form-group">
            <label for="tbLeadStaff">Lead Staff ID</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbLeadStaff" ErrorMessage="Lead Staff required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbLeadStaff" runat="server" class="form-control" placeholder="Staff ID" Type="number" min="0"></asp:TextBox>
        </div>--%>
        <div class="form-group">
            <label for="ddlStaff">Lead Staff</label>
            <asp:Label ID="lblStaff" runat="server" Text="" Style="text-align: center;" ForeColor="Red"></asp:Label>
            <asp:DropDownList ID="ddlStaff" runat="server" class="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="taDesc">Description</label>
            <textarea class="form-control" id="taDesc" name="taDesc" rows="3" placeholder="Description"></textarea>
        </div>
        <div class="form-group">
            <label for="tbMaxStud">Maximum Student Intake</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbMaxStud" ErrorMessage="This field is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="MaxStud" runat="server" ControlToValidate="tbMaxStud" ErrorMessage="Student intake (10-60)" MaximumValue="60" MinimumValue="10" Type="Integer" ForeColor="Red"></asp:RangeValidator>
            <asp:TextBox ID="tbMaxStud" runat="server" class="form-control" placeholder="Student Intake" Type="number" min="0"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbPrice">Price</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbPrice" ErrorMessage="Price is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbPrice" runat="server" class="form-control" placeholder="Price" Type="number" min="0" step="0.01"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ddlTripType">Trip Type</label>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="-1" ErrorMessage="Please select a trip type." ForeColor="Red" ControlToValidate="ddlTripType"></asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlTripType" runat="server" class="form-control">
                <asp:ListItem Value="-1">--Select--</asp:ListItem>
                <asp:ListItem Value="Study Trip">Study Trip</asp:ListItem>
                <asp:ListItem Value="Immersion Trip">Immersion Trip</asp:ListItem>
                <asp:ListItem Value="Internship">Internship</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="custom-file">
            <label>Image</label><asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="175px" ImageUrl='<%# Eval("path") %>' Width="265px" />
                </ItemTemplate>
            </asp:DataList>
            <br />
            <asp:FileUpload ID="imgUpload" runat="server" />
            <br />
            <asp:Button ID="btnUpload" runat="server" CausesValidation="False" OnClick="btnUpload_Click1" Text="Upload" /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <%--<asp:fileupload id="imgUpload" runat="server" class="custom-file-input"></asp:fileupload>--%>
        </div>
        <asp:Button runat="server" class="btn btn-primary" Text="Clear" ID="btnClear" OnClick="btnClear_Click" />
        <asp:Button runat="server" class="btn btn-primary" type="submit" Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <%--<asp:button runat="server" class="btn btn-primary" text="Back" id="btnBack" OnClick="btnBack_Click"/>--%>
    </div>
    <br />
</asp:Content>
