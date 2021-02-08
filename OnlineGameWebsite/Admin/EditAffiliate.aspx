<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditAffiliate.aspx.vb" Inherits="Admin_EditAffiliate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800" id="h1" runat="server">Affiliate</h1>

        <!-- DataTales Example -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Affiliate</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>User ID</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtUserName" runat="server" placeholder="User ID" required="Required"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label>Password</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtPassword" runat="server" placeholder="Password" required="Required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Code</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtCode" runat="server" placeholder="Code" required="Required"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label>Full Name</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtFullName" runat="server" placeholder="Full Name" required="Required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Phone No.</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtPhoneNo" runat="server" placeholder="Phone No." required="Required"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label>Email</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtEmail" runat="server" placeholder="Email" required="Required" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                <label>Calculation</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbCalculation" AutoPostBack="True" runat="server" placeholder="">
                                    <asp:ListItem Value="0">Profit</asp:ListItem>
                                    <asp:ListItem Value="1">Deposit</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4">
                                <label>Commission Percentage</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtPercentage" runat="server" placeholder="Commission Percentage" required="Required" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label>Status</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnabled" AutoPostBack="True" runat="server" placeholder="">
                                    <asp:ListItem Value="True">Enabled</asp:ListItem>
                                    <asp:ListItem Value="False">Disabled</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-2 ml-auto">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnSubmit" runat="server" Text="Update" />
                            </div>
                            <div class="col-sm-2">
                                <input type="button" class="btn btn-primary btn-user btn-block" onclick="window.location = 'Affiliates.aspx'" value="Go Back" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="js/demo/datatables-demo.js"></script>
</asp:Content>

