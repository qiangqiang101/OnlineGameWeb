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
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <table width="100%" cellspacing="0">
                                    <tbody>
                                        <tr>
                                            <td>ID</td>
                                            <td>
                                                <label id="lblID" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Product</td>
                                            <td>
                                                <label id="lblProduct" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Product User Name</td>
                                            <td>
                                                <label id="lblProductUsername" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>User ID</td>
                                            <td>
                                                <label id="lblUserID" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Name</td>
                                            <td>
                                                <label id="lblFullName" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>IP</td>
                                            <td>
                                                <label id="lblIpAddress" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Time</td>
                                            <td>
                                                <label id="lblTime" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr class="bordered">
                                            <td>Amount</td>
                                            <td>
                                                <asp:Label ID="lblAmount" runat="server" ForeColor="Red" Font-Size="Larger" Font-Bold="True"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Affiliate</td>
                                            <td>
                                                <label id="lblAffiliate" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Status</td>
                                            <td>
                                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                        </tr>
                                    </tbody>
                                </table>
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
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <table width="100%" cellspacing="0">
                                    <tbody>
                                        <tr>
                                            <td>Payment Method</td>
                                            <td>
                                                <label id="lblMethod" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Account Name</td>
                                            <td>
                                                <label id="lblAccName" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Account No.</td>
                                            <td>
                                                <label id="lblAccNo" runat="server"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Remarks</td>
                                            <td>
                                                <label id="lblRemarks" runat="server"></label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
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
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbPaymentMethod" AutoPostBack="True" runat="server" placeholder="">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <label>Reject Reason</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbRejectReason" AutoPostBack="True" runat="server" placeholder="">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:TextBox class="form-control form-control-user" ID="txtRemarks" runat="server" TextMode="MultiLine" Height="145px"></asp:TextBox>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <label>Confirm User</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtConfirmUser" runat="server" ReadOnly="true" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <label>Confirm Date</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtConfirmDate" runat="server" ReadOnly="true" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnApprove" runat="server" Text="Approve" />
                            </div>
                            <div class="col-sm-4">
                                <asp:Button class="btn btn-danger btn-user btn-block" ID="btnReject" runat="server" Text="Reject" />
                            </div>
                            <div class="col-sm-4">
                                <asp:Button class="btn btn-primary btn-user btn-block" ID="btnCancel" runat="server" Text="Cancel" />
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

