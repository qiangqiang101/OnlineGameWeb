<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="false" CodeFile="EditProduct.aspx.vb" Inherits="Admin_EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Product</h1>

        <!-- DataTales Example -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Product</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Name</label>
                                <asp:textbox class="form-control form-control-user" id="txtName" runat="server" placeholder="Name" required="Required"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Alias</label>
                                <asp:textbox class="form-control form-control-user" id="txtAlias" runat="server" placeholder="Alias"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Category</label>
                                <div class="custom-control custom-checkbox small">
                                    <div class="form-group row">
                                        <div class="col-sm-4 mb-3 mb-sm-0">
                                            <asp:checkbox class="form-check-input form-control-user" id="cbSlot" runat="server" text="&nbsp Slot Game" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:checkbox class="form-check-input form-control-user" id="cbLive" runat="server" text="&nbsp Live Casino" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:checkbox class="form-check-input form-control-user" id="cbSport" runat="server" text="&nbsp Sportsbook" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-4 mb-3 mb-sm-0">
                                            <asp:checkbox class="form-check-input form-control-user" id="cbRNG" runat="server" text="&nbsp RNG" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:checkbox class="form-check-input form-control-user" id="cbFish" runat="server" text="&nbsp Fish Hunter" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:checkbox class="form-check-input form-control-user" id="cbPoker" runat="server" text="&nbsp Poker" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-4 mb-3 mb-sm-0">
                                            <asp:checkbox class="form-check-input form-control-user" id="cbOther" runat="server" text="&nbsp Other" />
                                        </div>
                                    </div>
                                </div>
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
                                <label>Balance</label>
                                <asp:textbox class="form-control form-control-user" id="txtBalance" runat="server" placeholder="0.00" textmode="Number" required="Required"></asp:textbox>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Android Download Link</label>
                                <asp:textbox class="form-control form-control-user" id="txtAndroid" runat="server" placeholder="https://www.example.com/android.apk" textmode="Url"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>iOS Download Link</label>
                                <asp:textbox class="form-control form-control-user" id="txtiOS" runat="server" placeholder="https://www.example.com/iphoneApp" textmode="Url"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Windows Download Link</label>
                                <asp:textbox class="form-control form-control-user" id="txtWindows" runat="server" placeholder="https://www.example.com/game_installer.exe" textmode="Url"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Website Link</label>
                                <asp:textbox class="form-control form-control-user" id="txtWebsite" runat="server" placeholder="https://www.example.com" textmode="Url"></asp:textbox>
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
                                                <asp:image id="imgProduct" runat="server" width="200px" />
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

