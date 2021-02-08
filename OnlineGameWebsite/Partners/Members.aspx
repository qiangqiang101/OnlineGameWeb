<%@ Page Title="" Language="VB" MasterPageFile="~/Partners/PartnersMaster.master" AutoEventWireup="true" CodeFile="Members.aspx.vb" Inherits="Partners_Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Member Enquiry</h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Members</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered table-hover" ID="dataTable" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Date Created</asp:TableHeaderCell>
                            <asp:TableHeaderCell>User ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Full Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Contact No.</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->

    <!-- Bootstrap core JavaScript-->
    <script src="../Admin/vendor/jquery/jquery.min.js"></script>
    <script src="../Admin/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../Admin/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../Admin/js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="../Admin/vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="../Admin/vendor/datatables/dataTables.bootstrap4.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="../Admin/js/demo/datatables-demo.js"></script>
</asp:Content>

