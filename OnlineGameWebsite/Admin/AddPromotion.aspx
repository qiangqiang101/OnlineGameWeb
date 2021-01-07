<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AddPromotion.aspx.vb" Inherits="Admin_AddPromotion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
    <!-- Main Content -->
    <div id="content">
        <!-- Begin Page Content -->
        <div class="container-fluid">

            <!-- Page Heading -->
            <h1 class="h3 mb-2 text-gray-800">Add Promotion</h1>

            <!-- DataTales Example -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Add New Promotion</h6>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Promotion</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtPromotion" runat="server" placeholder="Promotion Name" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>English Name</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtEngName" runat="server" placeholder="English Name" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Chinese Name</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtChiName" runat="server" placeholder="Chinese Name" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Malay Name</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtMysName" runat="server" placeholder="Malay Name" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Display Index</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtIndex" runat="server" placeholder="1" required="Required" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Type</label>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="cmbType" AutoPostBack="True" runat="server" placeholder="">
                                        <asp:ListItem Value="0">Percentage</asp:ListItem>
                                        <asp:ListItem Value="1">Fixed Amount</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Value</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtValue" runat="server" placeholder="0.00" TextMode="Number" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Max Payout</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtMaxPayout" runat="server" placeholder="0.00" TextMode="Number" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Status</label>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnabled" AutoPostBack="True" runat="server" placeholder="">
                                        <asp:ListItem Value="1">Enabled</asp:ListItem>
                                        <asp:ListItem Value="0">Disabled</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            <hr />
                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <label>English Terms</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtEngTnC" runat="server" placeholder="" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <label>Chinese Terms</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtChiTnC" runat="server" placeholder="" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <label>Malay Terms</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtMysTnc" runat="server" placeholder="" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <hr />
                            <div class="form-group row">
                                <div class="col-sm-12">
                                    <table width="100%" cellspacing="0">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">Select Image</td>
                                            <td colspan="2"><asp:FileUpload ID="fileUploader" runat="server" /></td>
                                        </tr>
                                    </tbody>
                                </table>
                                </div>
                            </div>
                            <hr />
                            <div class="col-sm-3 ml-auto">
                                <asp:Button class="btn btn-primary btn-user btn-block" ID="btnSubmit" runat="server" Text="Confirm Add" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->

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

