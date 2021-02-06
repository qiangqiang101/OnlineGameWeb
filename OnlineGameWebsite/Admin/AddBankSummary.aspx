<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AddBankSummary.aspx.vb" Inherits="Admin_AddBankSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Add Bank Summary</h1>

        <!-- DataTales Example -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4" id="cdtdbtForm" runat="server">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Add Credit Summary</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Bank</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbBank" AutoPostBack="True" runat="server" placeholder="">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                                <label>Date</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtDate" runat="server" placeholder="" required="Required" TextMode="DateTimeLocal"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Amount</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtAmount" runat="server" placeholder="0.00" required="Required" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label>Description</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtDesc" runat="server" placeholder="Description" required="Required" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-2 ml-auto">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnSubmit" runat="server" Text="Submit" />
                            </div>
                            <div class="col-sm-2">
                                <input type="button" class="btn btn-primary btn-user btn-block" onclick="window.location = 'BankSummary.aspx'" value="Go Back" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card shadow mb-4" id="transferForm" runat="server">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Add Transfer Summary</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>From Bank</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbFromBank" AutoPostBack="True" runat="server" placeholder="">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                               <label>To Bank</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbToBank" AutoPostBack="True" runat="server" placeholder="">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                 <label>Date</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtDateT" runat="server" placeholder="" required="Required" TextMode="DateTimeLocal"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label>Amount</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtAmountT" runat="server" placeholder="0.00" required="Required" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label>Description</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtDescT" runat="server" placeholder="Description" required="Required" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-2 ml-auto">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnSubmitT" runat="server" Text="Submit" />
                            </div>
                            <div class="col-sm-2">
                                <input type="button" class="btn btn-primary btn-user btn-block" onclick="window.location = 'BankSummary.aspx'" value="Go Back" />
                            </div>
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

