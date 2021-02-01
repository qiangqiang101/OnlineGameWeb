<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Promotions.aspx.vb" Inherits="Admin_Promotions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Promotion</h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Promotions</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:table cssclass="table table-bordered table-hover" id="dataTable" clientidmode="Static" width="100%" cellspacing="0" runat="server">
                            <asp:TableHeaderRow TableSection="TableHeader">
                                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Promotion</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Image</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Index</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Value</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Max Payout</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:table>
                </div>
                <hr />
                <div class="form-group row">
                    <div class="col-sm-2 ml-auto">
                        <asp:button class="btn btn-primary btn-user btn-block" id="btnAddPromo" runat="server" text="Add Promotion" />
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

