<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditTrip.aspx.cs" Inherits="EADP.EditTrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <h3 style="text-align: center">Add Trip</h3><br />
        <asp:Label ID="lblValid" runat="server" Text="" style="text-align:center;" ForeColor="Red"></asp:Label>
        <div class="form-group">
            <label for="tbProgCode">ProgCode</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbProgCode" ErrorMessage="ProgCode is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator id="CustomValidator1" runat="server" ControlToValidate="tbProgCode" ErrorMessage="" OnServerValidate="ValidateProgCode"></asp:CustomValidator>
            <asp:textbox ID="tbProgCode" runat="server" class="form-control" placeholder="Eg.Korea2017"></asp:textbox>
        </div>
        <div class="form-group">
            <label for="tbProgYear">Start Date</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbProgYear" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbProgYear" runat="server" class="form-control" placeholder="DD-MM-YYYY" Type="date"></asp:textbox>
            <%--<input type="email" class="form-control" id="exampleFormControlInput1" placeholder="DD-MM-YYYY" />--%>
        </div>
        <div class="form-group">
            <label for="tbEndDate">End Date</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEndDate" ErrorMessage="Date is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbEndDate" runat="server" class="form-control" placeholder="DD-MM-YYYY" Type="date"></asp:textbox>
        </div>
        <div class="form-group">
            <label for="tbCountry">Country</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbCountry" ErrorMessage="Country is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbCountry" runat="server" class="form-control" placeholder="Country"></asp:textbox>
        </div>
        <div class="form-group">
            <label for="tbLeadStaff">Lead Staff ID</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbLeadStaff" ErrorMessage="Lead Staff required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbLeadStaff" runat="server" class="form-control" placeholder="Staff ID" Type="number" min="0"></asp:textbox>
        </div>
        <div class="form-group">
            <label for="taDesc">Description</label>
            <textarea class="form-control" id="taDesc" name="taDesc" rows="3" placeholder="Description"></textarea>
        </div>
        <div class="form-group">
            <label for="tbMaxStud">Maximum Student Intake</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbMaxStud" ErrorMessage="This field is required" ForeColor="Red" ></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="MaxStud" runat="server" ControlToValidate="tbMaxStud" ErrorMessage="Student intake (10-60)" MaximumValue="60" MinimumValue="10" Type="Integer" ForeColor="Red"></asp:RangeValidator>
            <asp:textbox id="tbMaxStud" runat="server" class="form-control" placeholder="Student Intake" Type="number" min="0"></asp:textbox>
        </div>
        <div class="form-group">
            <label for="tbPrice">Price</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbPrice" ErrorMessage="Price is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:textbox id="tbPrice" runat="server" class="form-control" placeholder="Price" Type="number" min="0" step="0.01"></asp:textbox>
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
                    <asp:Button ID="btnUpload" runat="server" CausesValidation="False" OnClick="btnUpload_Click1" Text="Upload" />
            <%--<asp:fileupload id="imgUpload" runat="server" class="custom-file-input"></asp:fileupload>--%>
        </div>
        <asp:button runat="server" class="btn btn-primary" text="Clear" id="btnClear" onclick="btnClear_Click" />
        <asp:button runat="server" class="btn btn-primary" type="submit" text="Submit" id="btnSubmit" onclick="btnSubmit_Click" />
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
