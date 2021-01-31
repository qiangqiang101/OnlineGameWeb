<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditRemark.aspx.vb" Inherits="Admin_EditRemark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
        <!-- Begin Page Content -->
        <div class="container-fluid">

            <!-- Page Heading -->
            <h1 class="h3 mb-2 text-gray-800">Remark</h1>

            <!-- DataTales Example -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Remark</h6>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Name</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtName" runat="server" placeholder="Name" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Status</label>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnabled" AutoPostBack="True" runat="server" placeholder="">
                                        <asp:ListItem Value="True">Enabled</asp:ListItem>
                                        <asp:ListItem Value="False">Disabled</asp:ListItem>
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

