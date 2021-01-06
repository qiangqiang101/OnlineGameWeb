<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="GeneralSettings.aspx.vb" Inherits="Admin_GeneralSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
    <!-- Main Content -->
    <div id="content">
        <!-- Begin Page Content -->
        <div class="container-fluid">

            <!-- Page Heading -->
            <h1 class="h3 mb-2 text-gray-800">Settings</h1>

            <!-- DataTales Example -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">General</h6>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Company Name</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtCompany" runat="server" placeholder="Company Name" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Logo</label>
                                    <table width="100%" cellspacing="0">
                                    <tbody>
                                        <tr>
                                            <td colspan="2"><asp:FileUpload ID="fileUpload" runat="server" /></td>
                                            <td colspan="2"><asp:Image ID="imgLogo" runat="server" height="50px" /></td>
                                        </tr>
                                    </tbody>
                                </table>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Recommend Bonus Percentage</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtRecBonusPercent" runat="server" placeholder="0.1" required="Required" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Recommend Bonus Minimum Amount</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtRecBonusMinAmount" runat="server" placeholder="10.0" required="Required" TextMode="Number"></asp:TextBox>
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

