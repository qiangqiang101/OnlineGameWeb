<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="false" CodeFile="Contacts.aspx.vb" Inherits="Admin_Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Contact</h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Contacts</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered" ID="dataTable" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Website URL</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Icon</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
                <hr />
                <div class="form-group row">
                    <div class="col-sm-2 ml-auto">
                        <asp:Button class="btn btn-primary btn-user btn-block" ID="btnAddContact" runat="server" Text="Add Contact" />
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

