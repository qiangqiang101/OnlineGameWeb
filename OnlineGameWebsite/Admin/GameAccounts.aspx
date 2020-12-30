<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="GameAccounts.aspx.vb" Inherits="Admin_GameAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
    <!-- Main Content -->
    <div id="content">
        <!-- Begin Page Content -->
        <div class="container-fluid">

            <!-- Page Heading -->
            <h1 class="h3 mb-2 text-gray-800">Game Accounts</h1>

            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Import</h6>
                </div>
                <div class="card-body">
                    <table width="100%" cellspacing="0">
                        <tbody>
                            <tr>
                                <td colspan="2">Select File</td>
                                <td colspan="2"><asp:FileUpload ID="fileUploader" runat="server" /></td>
                                <td colspan="2"><asp:Button class="btn btn-warning btn-user btn-block" ID="btnUpload" runat="server" Text="Import" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <!-- DataTales Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">All Game Accounts</h6>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:Table CssClass="table table-bordered" ID="dataTable" ClientIDMode="Static" width="100%" cellspacing="0" runat="server">
                            <asp:TableHeaderRow TableSection="TableHeader">
                                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Date Created</asp:TableHeaderCell>
                                <asp:TableHeaderCell>User Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Password</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Member</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
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

