<%@ Page Title="" Language="VB" MasterPageFile="~/Partners/PartnersMaster.master" AutoEventWireup="true" CodeFile="AdjustTransfer.aspx.vb" Inherits="Partners_AdjustTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Adjustment</h1>

        <!-- DataTales Example -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Transfer Adjustment</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>User ID</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtUserID" runat="server" placeholder="User ID" required="Required" list="userIdList"></asp:TextBox>
                                <datalist id="userIdList" runat="server" ClientIDMode="Static">
                                </datalist>
                            </div>
                            <div class="col-sm-6">
                                <label>Amount</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtAmount" runat="server" placeholder="0.00" required="Required" TextMode="Number"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>From Product</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbFromProduct" AutoPostBack="True" runat="server" placeholder="">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                                <label>To Product</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbToProduct" AutoPostBack="True" runat="server" placeholder="">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-2 ml-auto">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnSubmit" runat="server" Text="Submit" />
                            </div>
                            <div class="col-sm-2">
                                <input type="button" class="btn btn-primary btn-user btn-block" onclick="window.location = 'Transfers.aspx'" value="Go Back" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- End of Main Content -->

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

