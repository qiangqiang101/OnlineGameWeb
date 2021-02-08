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
            <div class="col-lg-12">
                <ul class="nav nav-tabs" id="myTab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="genTab" data-toggle="tab" href="#general" role="tab" aria-controls="general" aria-selected="true">General</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="pdtTab" data-toggle="tab" href="#product" role="tab" aria-controls="product" aria-selected="false">Product</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="transTab" data-toggle="tab" href="#transaction" role="tab" aria-controls="transaction" aria-selected="false">Transaction</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="tranfTab" data-toggle="tab" href="#transfer" role="tab" aria-controls="transfer" aria-selected="false">Transfer</a>
                    </li>
                </ul>
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="general" role="tabpanel" aria-labelledby="genTab">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="card shadow mb-4">
                                    <div class="card-body">
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                <label>User ID</label>
                                                <asp:TextBox class="form-control form-control-user" ID="txtUserID" runat="server" placeholder="User ID" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6">
                                                <label>Password</label>
                                                <asp:TextBox class="form-control form-control-user" ID="txtPassword" runat="server" placeholder="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                <label>Email</label>
                                                <asp:TextBox class="form-control form-control-user" ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6">
                                                <label>Phone No.</label>
                                                <asp:TextBox class="form-control form-control-user" ID="txtPhone" runat="server" placeholder="Phone No." TextMode="Phone"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                <label>Full Name</label>
                                                <asp:TextBox class="form-control form-control-user" ID="txtFullName" runat="server" placeholder="Full Name"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6">
                                                <label>Birthday</label>
                                                <asp:TextBox class="form-control form-control-user" ID="txtBirthday" runat="server" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                <label>Member Level</label>
                                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbLevel" AutoPostBack="True" runat="server" placeholder="">
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
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6">
                                                <label>Status</label>
                                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnabled" AutoPostBack="True" runat="server" placeholder="">
                                                    <asp:ListItem Value="True">Enabled</asp:ListItem>
                                                    <asp:ListItem Value="False">Disabled</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                <label>Bank</label>
                                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbBank" AutoPostBack="True" runat="server" placeholder="">
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
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6">
                                                <label>Bank Account</label>
                                                <asp:TextBox class="form-control form-control-user" ID="txtAccNo" runat="server" placeholder=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Remarks</label>
                                            <asp:TextBox class="form-control form-control-user" ID="txtRemarks" runat="server" TextMode="MultiLine" Height="116px"></asp:TextBox>
                                        </div>
                                        <hr />
                                        <div class="form-group row">
                                            <div class="col-sm-3 ml-auto">
                                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnSubmit" runat="server" Text="Update" />
                                            </div>
                                            <div class="col-sm-3">
                                                <input type="button" class="btn btn-primary btn-user btn-block" onclick="window.location = 'Members.aspx'" value="Go Back" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-6">
                                <div class="card shadow mb-4">
                                    <div class="card-body">
                                        <div class="form-group row">
                                            <div class="col-sm-12 mb-3 mb-sm-0">
                                                <table id="transTable1" width="100%" cellspacing="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>Total Deposit</td>
                                                            <td>
                                                                <label id="lblTotalDeposit" runat="server">$0.00 (0)</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Withdrawal</td>
                                                            <td>
                                                                <label id="lblTotalWithdrawal" runat="server">$0.00 (0)</label></td>
                                                        </tr>
                                                        <tr class="bordered">
                                                            <td>Total Promotion</td>
                                                            <td>
                                                                <label id="lblTotalPromotion" runat="server">$0.00 (0)</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Register</td>
                                                            <td>
                                                                <label id="lblRegisterDate" runat="server">1990-01-01 00:00:00</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Login</td>
                                                            <td>
                                                                <label id="lblLastLoginDate" runat="server">1990-01-01 00:00:00</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>First Deposit</td>
                                                            <td>
                                                                <label id="lbl1stDepDate" runat="server">1990-01-01 00:00:00</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Deposit</td>
                                                            <td>
                                                                <label id="lblLstDepDate" runat="server">1990-01-01 00:00:00</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>First Withdrawal</td>
                                                            <td>
                                                                <label id="lbl1stWtdDate" runat="server">1990-01-01 00:00:00</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Withdrawal</td>
                                                            <td>
                                                                <label id="lblLstWtdDate" runat="server">1990-01-01 00:00:00</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Product Request</td>
                                                            <td>
                                                                <label id="lblLastGADate" runat="server">1990-01-01 00:00:00</label></td>
                                                        </tr>
                                                        <tr class="bordered">
                                                            <td>Last Modified</td>
                                                            <td>
                                                                <label id="lblLastModified" runat="server">1990-01-01 00:00:00</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Referral Code</td>
                                                            <td>
                                                                <label id="lblRefCode" runat="server">-</label></td>
                                                        </tr>
                                                        <tr class="bordered">
                                                            <td>Register Ref Code</td>
                                                            <td>
                                                                <label id="lblRegRefCode" runat="server">-</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Register IP</td>
                                                            <td>
                                                                <label id="lblRegisterIP" runat="server">127.0.0.1</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Login IP</td>
                                                            <td>
                                                                <label id="lblLastLoginIP" runat="server">127.0.0.1</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Deposit IP</td>
                                                            <td>
                                                                <label id="lblLastDepIP" runat="server">127.0.0.1</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Withdrawal IP</td>
                                                            <td>
                                                                <label id="lblLastWtdIP" runat="server">127.0.0.1</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Transfer IP</td>
                                                            <td>
                                                                <label id="lblLastTrfIP" runat="server">127.0.0.1</label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Last Product ID Request IP</td>
                                                            <td>
                                                                <label id="lblLastGAIP" runat="server">127.0.0.1</label></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="product" role="tabpanel" aria-labelledby="pdtTab">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card shadow mb-4">
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <asp:Table CssClass="table table-bordered table-hover" ID="dataTable1" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                                                <asp:TableHeaderRow TableSection="TableHeader">
                                                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>User Name</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Password</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="transaction" role="tabpanel" aria-labelledby="transTab">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card shadow mb-4">
                                    <div class="card-body">
                                        <div class="form-group row">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-left: 10px;"><a href="AdjustCredit.aspx?mode=credit&id=<%=txtUserID.Text.Trim %>" class="btn btn-primary btn-user btn-block" title="Credit Adjustment"><i class="fas fa-coins"></i>Credit Adjustment</a></td>
                                                        <td style="padding-left: 10px;"><a href="AdjustCredit.aspx?mode=promo&id=<%=txtUserID.Text.Trim %>" class="btn btn-warning btn-user btn-block" title="Promotion Adjustment"><i class="fas fa-percentage"></i>Promotion Adjustment</a></td>
                                                        <td style="padding-left: 10px;"><a href="AdjustCredit.aspx?mode=debit&id=<%=txtUserID.Text.Trim %>" class="btn btn-danger btn-user btn-block" title="Debit Adjustment"><i class="fas fa-hand-holding-usd"></i>Debit Adjustment</a></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:Table CssClass="table table-bordered table-hover" ID="dataTable3" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                                                <asp:TableHeaderRow TableSection="TableHeader">
                                                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Payment Method</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell HorizontalAlign="Right" Style="text-align: right !important;">Credit</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell HorizontalAlign="Right" Style="text-align: right !important;">Debit</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="transfer" role="tabpanel" aria-labelledby="tranfTab">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card shadow mb-4">
                                    <div class="card-body">
                                        <div class="form-group row">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-left: 10px;"><a href="AdjustTransfer.aspx?id=<%=txtUserID.Text.Trim %>" class="btn btn-primary btn-user btn-block" title="Transfer Adjustment"><i class="fas fa-exchange-alt"></i>Transfer Adjustment</a></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:Table CssClass="table table-bordered table-hover" ID="dataTable4" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                                                <asp:TableHeaderRow TableSection="TableHeader">
                                                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>From Product</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>To Product</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell HorizontalAlign="Right" Style="text-align: right !important;">Amount</asp:TableHeaderCell>
                                                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                    </div>
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

