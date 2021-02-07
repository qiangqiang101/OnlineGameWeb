<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="BankRecords.aspx.vb" Inherits="Admin_BankRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Bank Records</h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Bank Records</h6>
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
                    <asp:table cssclass="table table-bordered" id="dataTable" clientidmode="Static" width="100%" cellspacing="0" runat="server">
                            <asp:TableHeaderRow TableSection="TableHeader">
                                <asp:TableHeaderCell>Record ID</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Transaction ID</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Description</asp:TableHeaderCell>
                                <asp:TableHeaderCell HorizontalAlign="Right">Credit</asp:TableHeaderCell>
                                <asp:TableHeaderCell HorizontalAlign="Right">Debit</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:table>
                </div>
                <hr />
                <div class="form-group row">
                    <div class="col-sm-2 ml-auto">
                        <asp:button class="btn btn-success btn-user btn-block" id="btnCredit" runat="server" text="Add Credit" />
                    </div>
                    <div class="col-sm-2">
                        <asp:button class="btn btn-danger btn-user btn-block" id="btnDebit" runat="server" text="Add Debit" />
                    </div>
                    <div class="col-sm-2">
                        <asp:button class="btn btn-warning btn-user btn-block" id="btnTransfer" runat="server" text="Add Transfer" />
                    </div>
                    <div class="col-sm-2">
                        <input type="button" class="btn btn-primary btn-user btn-block" onclick="window.location = 'BankSummary.aspx'" value="Go Back" />
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

