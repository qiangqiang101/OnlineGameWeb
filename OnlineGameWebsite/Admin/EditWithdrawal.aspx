<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditWithdrawal.aspx.vb" Inherits="Admin_EditWithdrawal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800" id="h1" runat="server">Debit Transaction</h1>

        <!-- DataTales Example -->
        <div class="row">

            <div class="col-lg-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary" id="h6Title" runat="server">Transaction</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-5 mb-3 mb-sm-0">
                                <label>ID</label><br />
                                <label>Product</label><br />
                                <label>Product User Name</label><br />
                                <label>User ID</label><br />
                                <label>Name</label><br />
                                <label>IP</label><br />
                                <label>Time</label><br />
                                <h4>
                                    <label>Amount</label></h4>
                                <hr />
                                <label>Affiliate</label><br />
                                <label>Status</label>
                            </div>
                            <div class="col-sm-7">
                                <label id="lblID" runat="server">#99999</label><br />
                                <label id="lblProduct" runat="server">#Product</label><br />
                                <label id="lblProductUsername" runat="server">#ProductUsername</label><br />
                                <label id="lblUserID" runat="server">#UserID</label><br />
                                <label id="lblFullName" runat="server">#FullName</label><br />
                                <label id="lblIpAddress" runat="server">#127.0.0.1</label><br />
                                <label id="lblTime" runat="server">#1990-01-01 00:00:00</label><br />
                                <h4><b>
                                    <label id="lblAmount" runat="server" style="text-decoration: underline;">#100.00</label></b></h4>
                                <hr />
                                <label id="lblAffiliate" runat="server">#Affiliate</label><br />
                                <label id="lblStatus" runat="server">#New</label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Bank Data</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-5 mb-3 mb-sm-0">
                                <label>Payment Method</label><br />
                                <label>Account Name</label><br />
                                <label>Account No.</label><br />
                                <label>Remarks</label>
                            </div>
                            <div class="col-sm-7">
                                <label id="lblMethod" runat="server">#Maybank</label><br />
                                <label id="lblAccName" runat="server">#Tan Ah Beng</label><br />
                                <label id="lblAccNo" runat="server">#112233445566</label><br />
                                <label id="lblRemarks" runat="server">#Remarks</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Other Data</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <label>Payment Method</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbPaymentMethod" autopostback="True" runat="server" placeholder="">
                                    </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <label>Reject Reason</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbRejectReason" autopostback="True" runat="server" placeholder="">
                                    </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:textbox class="form-control form-control-user" id="txtRemarks" runat="server" textmode="MultiLine" height="60px"></asp:textbox>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <label>Confirm User</label>
                                <asp:textbox class="form-control form-control-user" id="txtConfirmUser" runat="server" readonly="true" textmode="SingleLine"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <label>Confirm Date</label>
                                <asp:textbox class="form-control form-control-user" id="txtConfirmDate" runat="server" readonly="true" textmode="SingleLine"></asp:textbox>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                <asp:button class="btn btn-success btn-user btn-block" id="btnApprove" runat="server" text="Approve" />
                            </div>
                            <div class="col-sm-4">
                                <asp:button class="btn btn-danger btn-user btn-block" id="btnReject" runat="server" text="Reject" />
                            </div>
                            <div class="col-sm-4">
                                <asp:button class="btn btn-primary btn-user btn-block" id="btnCancel" runat="server" text="Cancel" />
                            </div>
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
    <script src="js/demo/datatables-demo.js"></script>

    <script type="text/javascript" defer="defer">
        $(document).ready(function () {
            $("table[id^='dataTable']").DataTable({
                "scrollCollapse": true,
                "searching": true,
                "paging": true
            });
        });
    </script>
</asp:Content>

