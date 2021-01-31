<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditMember.aspx.vb" Inherits="Admin_EditMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800" id="h1" runat="server">Member Edit</h1>

        <!-- DataTales Example -->
        <div class="row">
            <div class="col-lg-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">General</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>User ID</label>
                                <asp:textbox class="form-control form-control-user" id="txtUserID" runat="server" placeholder="User ID" readonly="true"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Password</label>
                                <asp:textbox class="form-control form-control-user" id="txtPassword" runat="server" placeholder="Password"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Email</label>
                                <asp:textbox class="form-control form-control-user" id="txtEmail" runat="server" placeholder="Email"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Phone No.</label>
                                <asp:textbox class="form-control form-control-user" id="txtPhone" runat="server" placeholder="Phone No." textmode="Phone"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Full Name</label>
                                <asp:textbox class="form-control form-control-user" id="txtFullName" runat="server" placeholder="Full Name"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Birthday</label>
                                <asp:textbox class="form-control form-control-user" id="txtBirthday" runat="server" textmode="Date"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Member Level</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbLevel" autopostback="True" runat="server" placeholder="">
                                        <asp:ListItem Value="0">Registered</asp:ListItem>
                                        <asp:ListItem Value="1">New Member</asp:ListItem>
                                        <asp:ListItem Value="2">Normal</asp:ListItem>
                                        <asp:ListItem Value="3">Bronze</asp:ListItem>
                                        <asp:ListItem Value="4">Bronze+</asp:ListItem>
                                        <asp:ListItem Value="5">Silver</asp:ListItem>
                                        <asp:ListItem Value="6">Silver+</asp:ListItem>
                                        <asp:ListItem Value="7">Gold</asp:ListItem>
                                        <asp:ListItem Value="8">Gold+</asp:ListItem>
                                        <asp:ListItem Value="9">Platinum</asp:ListItem>
                                        <asp:ListItem Value="10">Platinum+</asp:ListItem>
                                    </asp:dropdownlist>
                            </div>
                            <div class="col-sm-6">
                                <label>Status</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbEnabled" autopostback="True" runat="server" placeholder="">
                                        <asp:ListItem Value="True">Enabled</asp:ListItem>
                                        <asp:ListItem Value="False">Disabled</asp:ListItem>
                                    </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Bank</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbBank" autopostback="True" runat="server" placeholder="">
                                        <asp:ListItem Value="-1">---</asp:ListItem>
                                        <asp:ListItem Value="0">Maybank</asp:ListItem>
                                        <asp:ListItem Value="1">CIMB Bank</asp:ListItem>
                                        <asp:ListItem Value="2">Public Bank</asp:ListItem>
                                        <asp:ListItem Value="3">RHB Bank</asp:ListItem>
                                        <asp:ListItem Value="4">Hong Leong Bank</asp:ListItem>
                                        <asp:ListItem Value="5">AmBank</asp:ListItem>
                                        <asp:ListItem Value="6">UOB Bank</asp:ListItem>
                                        <asp:ListItem Value="7">Bank Rakyat</asp:ListItem>
                                        <asp:ListItem Value="8">OCBC Bank</asp:ListItem>
                                        <asp:ListItem Value="9">HSBC Bank</asp:ListItem>
                                        <asp:ListItem Value="10">Affin Bank</asp:ListItem>
                                        <asp:ListItem Value="11">Bank Islam</asp:ListItem>
                                        <asp:ListItem Value="12">Standard Chartered Bank</asp:ListItem>
                                        <asp:ListItem Value="13">CitiBank</asp:ListItem>
                                        <asp:ListItem Value="14">Bank Simpanan Malaysia</asp:ListItem>
                                        <asp:ListItem Value="15">Bank Muamalat</asp:ListItem>
                                        <asp:ListItem Value="16">Alliance Bank</asp:ListItem>
                                        <asp:ListItem Value="17">Agrobank</asp:ListItem>
                                        <asp:ListItem Value="18">Al-Rajhi</asp:ListItem>
                                        <asp:ListItem Value="19">MBSB Bank</asp:ListItem>
                                        <asp:ListItem Value="20">Co-op Bank Pertama</asp:ListItem>
                                    </asp:dropdownlist>
                            </div>
                            <div class="col-sm-6">
                                <label>Bank Account</label>
                                <asp:textbox class="form-control form-control-user" id="txtAccNo" runat="server" placeholder=""></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Remarks</label>
                            <asp:textbox class="form-control form-control-user" id="txtRemarks" runat="server" textmode="MultiLine" height="95px"></asp:textbox>
                        </div>
                        <hr />
                        <div class="col-sm-3 ml-auto">
                            <asp:button class="btn btn-primary btn-user btn-block" id="btnSubmit" runat="server" text="Update" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Member Details</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-5 mb-3 mb-sm-0">
                                <label>Total Deposit</label><br />
                                <label>Total Withdrawal</label><br />
                                <label>Total Promotion</label>
                                <hr />
                                <label>Register</label><br />
                                <label>First Deposit</label><br />
                                <label>Last Deposit</label><br />
                                <label>First Withdrawal</label><br />
                                <label>Last Withdrawal</label><br />
                                <label>Last Modified</label>
                                <hr />
                                <label>Referral Code</label><br />
                                <label>Register Ref Code</label>
                                <hr />
                                <label>Register IP</label><br />
                                <label>Last Login IP</label><br />
                                <label>Last Deposit IP</label><br />
                                <label>Last Withdrawal IP</label><br />
                                <label>Last Transfer IP</label>
                            </div>
                            <div class="col-sm-7">
                                <label id="lblTotalDeposit" runat="server">$0.00 (0)</label><br />
                                <label id="lblTotalWithdrawal" runat="server">$0.00 (0)</label><br />
                                <label id="lblTotalPromotion" runat="server">$0.00 (0)</label>
                                <hr />
                                <label id="lblRegisterDate" runat="server">1990-01-01 00:00:00</label><br />
                                <label id="lbl1stDepDate" runat="server">1990-01-01 00:00:00</label><br />
                                <label id="lblLstDepDate" runat="server">1990-01-01 00:00:00</label><br />
                                <label id="lbl1stWtdDate" runat="server">1990-01-01 00:00:00</label><br />
                                <label id="lblLstWtdDate" runat="server">1990-01-01 00:00:00</label><br />
                                <label id="lblLastModified" runat="server">1990-01-01 00:00:00</label>
                                <hr />
                                <label id="lblRefCode" runat="server">-</label><br />
                                <label id="lblRegRefCode" runat="server">-</label>
                                <hr />
                                <label id="lblRegisterIP" runat="server">127.0.0.1</label><br />
                                <label id="lblLastLoginIP" runat="server">127.0.0.1</label><br />
                                <label id="lblLastDepIP" runat="server">127.0.0.1</label><br />
                                <label id="lblLastWtdIP" runat="server">127.0.0.1</label><br />
                                <label id="lblLastTrfIP" runat="server">127.0.0.1</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Products</h6>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:table cssclass="table table-bordered" id="dataTable1" clientidmode="Static" width="100%" cellspacing="0" runat="server">
                                    <asp:TableHeaderRow TableSection="TableHeader">
                                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>User Name</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Password</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Transactions</h6>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:table cssclass="table table-bordered" id="dataTable3" clientidmode="Static" width="100%" cellspacing="0" runat="server">
                                    <asp:TableHeaderRow TableSection="TableHeader">
                                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Transaction Date</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>User Name</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Method</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Debit</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Credit</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:table>
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

