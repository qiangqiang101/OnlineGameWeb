<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Transfers.aspx.vb" Inherits="Admin_Transfers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Transfer Enquiry</h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Transfers</h6>
            </div>
            <div class="card-body">
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
                    <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered table-hover" ID="dataTable" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell>User ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>From Product</asp:TableHeaderCell>
                            <asp:TableHeaderCell>To Product</asp:TableHeaderCell>
                            <asp:TableHeaderCell HorizontalAlign="Right">Amount</asp:TableHeaderCell>
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
    <script src="js/demo/datatables-demo.js"></script>
</asp:Content>

