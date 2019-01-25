<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="UpdateTrip.aspx.cs" Inherits="EADP.UpdateTrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <h3 style="text-align: center">Update Trip</h3>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div class="form-group">
            <label for="tbStartDateUD">ProgCode</label>
            <asp:Label runat="server" ID="lblProgCode"></asp:Label>
        </div>
        <div class="form-group">
            <label for="tbStartDateUD">Start Date</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbStartDateUD" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbStartDateUD" runat="server" class="form-control" placeholder="DD-MM-YYYY" Type="date"></asp:TextBox>
            <%--<input type="email" class="form-control" id="exampleFormControlInput1" placeholder="DD-MM-YYYY" />--%>
        </div>
        <div class="form-group">
            <label for="tbEndDateUD">End Date</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEndDateUD" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbEndDateUD" runat="server" class="form-control" placeholder="DD-MM-YYYY" Type="date"></asp:TextBox>
        </div>
        <%--        <div class="form-group">
            <label for="tbCountryUD">Country</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbCountryUD" ErrorMessage="Country is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbCountryUD" runat="server" class="form-control" placeholder="Country"></asp:TextBox>
        </div>--%>
        <div class="form-group">
            <label for="ddlCountryUD">Country</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="-1" ErrorMessage="Please select a country." ForeColor="Red" ControlToValidate="ddlCountryUD"></asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlCountryUD" runat="server" class="form-control">
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
            <label for="tbIDUD">Lead Staff ID</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbIDUD" ErrorMessage="Lead Staff required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbIDUD" runat="server" class="form-control" placeholder="Staff ID" Type="number" min="0"></asp:TextBox>
        </div>--%>
        <div class="form-group">
            <label for="ddlStaffUD">Lead Staff</label>
            <asp:Label ID="lblStaff" runat="server" Text="" Style="text-align: center;" ForeColor="Red"></asp:Label>
            <asp:DropDownList ID="ddlStaffUD" runat="server" class="form-control"></asp:DropDownList>
        </div>
        <%--        <div class="form-group">
            <label for="exampleFormControlSelect1">Example select</label>
            <select class="form-control" id="exampleFormControlSelect1">
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
            </select>
        </div>--%>
        <div class="form-group">
            <label for="taDescUP">Description</label>
            <textarea class="form-control" id="taDescUP" name="taDescUP" rows="3" placeholder="Description"></textarea>
        </div>
        <div class="form-group">
            <label for="tbMaxStudUD">Maximum Student Intake</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbMaxStudUD" ErrorMessage="This field is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="MaxStud" runat="server" ControlToValidate="tbMaxStudUD" ErrorMessage="Student intake (10-60)" MaximumValue="60" MinimumValue="10" Type="Integer" ForeColor="Red"></asp:RangeValidator>
            <asp:TextBox ID="tbMaxStudUD" runat="server" class="form-control" placeholder="Student Intake" Type="number" min="0"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="tbPriceUD">Price</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbPriceUD" ErrorMessage="Price is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbPriceUD" runat="server" class="form-control" placeholder="Price" Type="number" min="0" step="0.01"></asp:TextBox>
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
            <label>Image</label>
            <asp:FileUpload ID="imgUploadUD" runat="server" class="custom-file-input"></asp:FileUpload>
        </div>
        <asp:Button runat="server" class="btn btn-primary" Text="Clear" ID="btnClr" OnClick="btnClr_Click" CausesValidation="False" />
        <asp:Button runat="server" class="btn btn-primary" type="submit" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" class="btn btn-primary" Text="Back" ID="btnBack" OnClick="btnBack_Click" CausesValidation="False" />
    </div>
    <br />
</asp:Content>
