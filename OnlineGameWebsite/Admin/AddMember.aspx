<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AddMember.aspx.vb" Inherits="Admin_AddMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
    <!-- Main Content -->
    <div id="content">
        <!-- Begin Page Content -->
        <div class="container-fluid">

            <!-- Page Heading -->
            <h1 class="h3 mb-2 text-gray-800">Add Member</h1>

            <!-- DataTales Example -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Add New Member</h6>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>User ID</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtUserID" runat="server" placeholder="User ID" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Password</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtPassword" runat="server" placeholder="Password" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Email</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtEmail" runat="server" placeholder="Email" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Phone No.</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtPhone" runat="server" placeholder="Phone No." TextMode="Phone" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Full Name</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtFullName" runat="server" placeholder="Full Name" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Birthday</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtBirthday" runat="server" TextMode="Date" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Member Level</label>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="cmbLevel" AutoPostBack="True" runat="server" placeholder="">
                                        <asp:ListItem Value="0">Registered</asp:ListItem>
                                        <asp:ListItem Value="1">New Member</asp:ListItem>
                                        <asp:ListItem Value="2">Normal</asp:ListItem>
                                        <asp:ListItem Value="3">Bronze</asp:ListItem>
                                        <asp:ListItem Value="4">Bronze+</asp:ListItem>
                                        <asp:ListItem Value="5">Silver</asp:ListItem>
                                        <asp:ListItem Value="6">Silver+</asp:ListItem>
                                        <asp:ListItem Value="7">Gold</asp:ListItem>
                                        <asp:ListItem Value="8">Gold+</asp:ListItem>
                                        <asp:ListItem Value="9">Platinum</asp:ListItem>
                                        <asp:ListItem Value="10">Platinum+</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <label>Status</label>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnabled" AutoPostBack="True" runat="server" placeholder="">
                                        <asp:ListItem Value="True">Enabled</asp:ListItem>
                                        <asp:ListItem Value="False">Disabled</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Referral Code</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtRegRefCode" runat="server" placeholder="Referral Code"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>Remarks</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <hr />
                            <div class="col-sm-3 ml-auto">
                                <asp:Button class="btn btn-primary btn-user btn-block" ID="btnSubmit" runat="server" Text="Confirm Add" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.container-fluid -->

    </div>
    <!-- End of Main Content -->

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

