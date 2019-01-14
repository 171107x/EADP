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
            <asp:label runat="server" id="lblProgCode"></asp:label>
        </div>
        <div class="form-group">
            <label for="tbStartDateUD">Start Date</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbStartDateUD" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbStartDateUD" runat="server" class="form-control" placeholder="DD-MM-YYYY" Type="date"></asp:textbox>
            <%--<input type="email" class="form-control" id="exampleFormControlInput1" placeholder="DD-MM-YYYY" />--%>
        </div>
        <div class="form-group">
            <label for="tbEndDateUD">End Date</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEndDateUD" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbEndDateUD" runat="server" class="form-control" placeholder="DD-MM-YYYY" Type="date"></asp:textbox>
        </div>
        <div class="form-group">
            <label for="tbCountryUD">Country</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbCountryUD" ErrorMessage="Country is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbCountryUD" runat="server" class="form-control" placeholder="Country"></asp:textbox>
        </div>
        <div class="form-group">
            <label for="tbIDUD">Lead Staff ID</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbIDUD" ErrorMessage="Lead Staff required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbIDUD" runat="server" class="form-control" placeholder="Staff ID" Type="number" min="0"></asp:textbox>
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbMaxStudUD" ErrorMessage="This field is required" ForeColor="Red" ></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="MaxStud" runat="server" ControlToValidate="tbMaxStudUD" ErrorMessage="Student intake (10-60)" MaximumValue="60" MinimumValue="10" Type="Integer" ForeColor="Red"></asp:RangeValidator>
            <asp:textbox id="tbMaxStudUD" runat="server" class="form-control" placeholder="Student Intake" Type="number" min="0"></asp:textbox>
        </div>
        <div class="form-group">
            <label for="tbPriceUD">Price</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbPriceUD" ErrorMessage="Price is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbPriceUD" runat="server" class="form-control" placeholder="Price" Type="number" min="0" step="0.01"></asp:textbox>
        </div>
        <div class="custom-file">
            <label>Image</label>
            <asp:fileupload id="imgUploadUD" runat="server" class="custom-file-input"></asp:fileupload>
        </div>
        <asp:button runat="server" class="btn btn-primary" text="Clear" id="btnClr" onclick="btnClr_Click" CausesValidation="False" />
        <asp:button runat="server" class="btn btn-primary" type="submit" text="Update" id="btnUpdate" onclick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:button runat="server" class="btn btn-primary" text="Back" id="btnBack" OnClick="btnBack_Click" CausesValidation="False"/>
    </div>
    <br />
</asp:Content>
