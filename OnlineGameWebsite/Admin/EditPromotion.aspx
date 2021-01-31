<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditPromotion.aspx.vb" Inherits="Admin_EditPromotion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Promotion</h1>

        <!-- DataTales Example -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Promotion</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Promotion</label>
                                <asp:textbox class="form-control form-control-user" id="txtPromotion" runat="server" placeholder="Promotion Name" required="Required"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>English Name</label>
                                <asp:textbox class="form-control form-control-user" id="txtEngName" runat="server" placeholder="English Name" required="Required"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Chinese Name</label>
                                <asp:textbox class="form-control form-control-user" id="txtChiName" runat="server" placeholder="Chinese Name" required="Required"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Malay Name</label>
                                <asp:textbox class="form-control form-control-user" id="txtMysName" runat="server" placeholder="Malay Name" required="Required"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Display Index</label>
                                <asp:textbox class="form-control form-control-user" id="txtIndex" runat="server" placeholder="1" required="Required" textmode="Number"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Type</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbType" autopostback="True" runat="server" placeholder="">
                                        <asp:ListItem Value="0">Percentage</asp:ListItem>
                                        <asp:ListItem Value="1">Fixed Amount</asp:ListItem>
                                    </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Value</label>
                                <asp:textbox class="form-control form-control-user" id="txtValue" runat="server" placeholder="0.00" textmode="Number" required="Required"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Max Payout</label>
                                <asp:textbox class="form-control form-control-user" id="txtMaxPayout" runat="server" placeholder="0.00" textmode="Number" required="Required"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Status</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbEnabled" autopostback="True" runat="server" placeholder="">
                                        <asp:ListItem Value="1">Enabled</asp:ListItem>
                                        <asp:ListItem Value="0">Disabled</asp:ListItem>
                                    </asp:dropdownlist>
                            </div>
                        </div>

                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>English Terms</label>
                                <asp:textbox class="form-control form-control-user" id="txtEngTnC" runat="server" placeholder="" textmode="MultiLine"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Chinese Terms</label>
                                <asp:textbox class="form-control form-control-user" id="txtChiTnC" runat="server" placeholder="" textmode="MultiLine"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <label>Malay Terms</label>
                                <asp:textbox class="form-control form-control-user" id="txtMysTnc" runat="server" placeholder="" textmode="MultiLine"></asp:textbox>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <table width="100%" cellspacing="0">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">Select Image</td>
                                            <td colspan="2">
                                                <asp:fileupload id="fileUploader" runat="server" />
                                            </td>
                                            <td colspan="2">
                                                <asp:image id="imgPromo" runat="server" width="200px" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <hr />
                        <div class="col-sm-3 ml-auto">
                            <asp:button class="btn btn-primary btn-user btn-block" id="btnSubmit" runat="server" text="Update" />
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
</asp:Content>

