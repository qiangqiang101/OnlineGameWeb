<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditUser.aspx.vb" Inherits="Admin_EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800" id="h1" runat="server">User</h1>

        <!-- DataTales Example -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">User</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>User ID</label>
                                <asp:textbox class="form-control form-control-user" id="txtUserName" runat="server" placeholder="User ID" required="Required"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Password</label>
                                <asp:textbox class="form-control form-control-user" id="txtPassword" runat="server" placeholder="Password" required="Required"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Full Name</label>
                                <asp:textbox class="form-control form-control-user" id="txtFullName" runat="server" placeholder="Full Name" required="Required"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Email</label>
                                <asp:textbox class="form-control form-control-user" id="txtEmail" runat="server" placeholder="Email" required="Required" textmode="Email"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Role</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbCategory" autopostback="True" runat="server" placeholder="">
                                        <asp:ListItem Value="0">Customer Service</asp:ListItem>
                                        <asp:ListItem Value="1">Agent/Affiliate</asp:ListItem>
                                        <asp:ListItem Value="2">Administrator</asp:ListItem>
                                        <asp:ListItem Value="3">Full Administrator</asp:ListItem>
                                    </asp:dropdownlist>
                            </div>
                            <div class="col-sm-6">
                                <label>Status</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbEnabled" autopostback="True" runat="server" placeholder="">
                                        <asp:ListItem Value="True">Enabled</asp:ListItem>
                                        <asp:ListItem Value="False">Disabled</asp:ListItem>
                                    </asp:dropdownlist>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-2 ml-auto">
                                <asp:button class="btn btn-success btn-user btn-block" id="btnSubmit" runat="server" text="Update" />
                            </div>
                            <div class="col-sm-2">
                                <input type="button" class="btn btn-primary btn-user btn-block" onclick="window.location = 'Users.aspx'" value="Go Back" />
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

