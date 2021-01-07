<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditBank.aspx.vb" Inherits="Admin_EditBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
    <!-- Main Content -->
    <div id="content">
        <!-- Begin Page Content -->
        <div class="container-fluid">

            <!-- Page Heading -->
            <h1 class="h3 mb-2 text-gray-800">Bank Edit</h1>

            <!-- DataTales Example -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Bank</h6>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Bank</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtBank" runat="server" placeholder="Maybank" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Name</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtName" runat="server" placeholder="Ilham Global Trading" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Account No.</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtAccNo" runat="server" placeholder="1144 5555 3333" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Website</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtWebsite" runat="server" placeholder="https://www.maybank2u.com.my/home/m2u/common/login.do" required="Required" TextMode="Url"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Minimum Credit</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtMinCredit" runat="server" placeholder="30.00" TextMode="Number" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Maximum Credit</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtMaxCredit" runat="server" placeholder="50000.00" TextMode="Number" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Minimum Debit</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtMinDebit" runat="server" placeholder="50.00" TextMode="Number" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Maximum Debit</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtMaxDebit" runat="server" placeholder="50000.00" TextMode="Number" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Status</label>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnabled" AutoPostBack="True" runat="server" placeholder="">
                                        <asp:ListItem Value="1">Enabled</asp:ListItem>
                                        <asp:ListItem Value="0">Disabled</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <hr />
                            <div class="col-sm-3 ml-auto">
                                <asp:Button class="btn btn-primary btn-user btn-block" ID="btnSubmit" runat="server" Text="Update" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->

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

