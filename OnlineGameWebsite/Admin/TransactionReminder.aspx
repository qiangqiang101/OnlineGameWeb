<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="false" CodeFile="TransactionReminder.aspx.vb" Inherits="Admin_TransactionReminder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="refresh" content="60" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">
        <audio id="depositAlert" runat="server"></audio>
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Transaction Alert</h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Transactions</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered table-hover" ID="dataTable" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell>User ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Payment Method</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" Style="text-align: right !important;">Credit</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" Style="text-align: right !important;">Debit</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Action</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>
        </div>

        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Transfers</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered table-hover" ID="dataTable2" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell>User ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>From Product</asp:TableHeaderCell>
                            <asp:TableHeaderCell>To Product</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" Style="text-align: right !important;">Amount</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Action</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
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
    <%--<script src="js/demo/datatables-demo.js"></script>--%>

    <script type="text/javascript" defer="defer">
        $(document).ready(function () {
            $("table[id^='dataTable']").DataTable({
                "scrollCollapse": true,
                "searching": true,
                "paging": true,
                "language": {
                    "lengthMenu": "<td>Display &nbsp</td><td> _MENU_ </td><td>&nbsp records</td>",
                    "search": "<td>Search &nbsp</td><td> _INPUT_ </td>"
                },
                "lengthMenu": [[10, 20, 50, 100, 150, 200, -1], [10, 20, 50, 100, 150, 200, "All"]],
                "order": [[0, "desc"]]
            });
        });
    </script>
</asp:Content>

