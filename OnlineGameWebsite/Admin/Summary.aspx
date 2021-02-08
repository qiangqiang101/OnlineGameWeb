<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Summary.aspx.vb" Inherits="Admin_Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Summary</h1>

        <div class="form-group row">
            <div class="col-sm-12 mb-3 mb-sm-0">
                <div class="table-responsive">
                    <table id="searchTable">
                        <tbody>
                            <tr>
                                <td>Date </td>
                                <td style="padding-left: 10px;">
                                    <asp:TextBox class="form-control form-control-user" ID="txtDateFrom" runat="server" TextMode="DateTimeLocal"></asp:TextBox></td>
                                <td style="padding-left: 10px;">- </td>
                                <td style="padding-left: 10px;">
                                    <asp:TextBox class="form-control form-control-user" ID="txtDateTo" runat="server" TextMode="DateTimeLocal"></asp:TextBox></td>
                                <td style="padding-left: 10px;">
                                    <asp:LinkButton ID="p1d" runat="server" Text="+1D" /></td>
                                <td style="padding-left: 10px;">
                                    <asp:LinkButton ID="n1d" runat="server" Text="-1D" /></td>
                                <td style="padding-left: 10px;">
                                    <asp:LinkButton ID="n7d" runat="server" Text="-7D" /></td>
                                <td style="padding-left: 10px;">
                                    <asp:LinkButton ID="mtl" runat="server" Text="MTL" /></td>
                                <td style="padding-left: 10px;">
                                    <asp:LinkButton ID="all" runat="server" Text="ALL" /></td>
                                <td style="padding-left: 10px;">
                                    <asp:LinkButton ID="today" runat="server" Text="Today" /></td>
                                <td style="padding-left: 10px;">
                                    <asp:Button class="btn btn-success btn-user btn-block" ID="btnRefresh" runat="server" Text="Refresh" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Summary</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered" ID="tableSummary" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader" ID="tableSummaryHeader" runat="server">
                            <asp:TableHeaderCell>Member</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>
        </div>

        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" id="h1" runat="server">Report</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered table-hover" ID="dataTable" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Member</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" style="text-align: right !important;">Credit</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" style="text-align: right !important;">Debit</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" style="text-align: right !important;">Promotion</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Game Accounts Left</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-4">
                <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" id="h2" runat="server">Transaction</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered" ID="transTable" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Transaction</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" style="text-align: right !important;">Amount</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>
        </div>
            </div>
            <div class="col-lg-8">
                <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" id="h3" runat="server">Affiliate</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered table-hover" ID="dataTable2" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>Code</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Calculation</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" style="text-align: right !important;">Rate</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Transaction</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right" style="text-align: right !important;">Comission</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
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
                "lengthMenu": [[20, 40, 60, 100, 150, 200, -1], [20, 40, 60, 100, 150, 200, "All"]],
                "order": [[0, "desc"]]
            });
        });
    </script>
</asp:Content>

