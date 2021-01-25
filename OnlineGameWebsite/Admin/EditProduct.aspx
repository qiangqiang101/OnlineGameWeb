<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="false" CodeFile="EditProduct.aspx.vb" Inherits="Admin_EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Main Content -->
    <div id="content">
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
                                    <asp:TextBox class="form-control form-control-user" ID="txtName" runat="server" placeholder="Name" required="Required"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Alias</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtAlias" runat="server" placeholder="Alias"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Category</label>
                                    <div class="custom-control custom-checkbox small">
                                        <div class="form-group row">
                                            <div class="col-sm-4 mb-3 mb-sm-0">
                                                <asp:CheckBox class="form-check-input form-control-user" ID="cbSlot" runat="server" Text="&nbsp Slot Game" />
                                            </div>
                                            <div class="col-sm-4">
                                                <asp:CheckBox class="form-check-input form-control-user" ID="cbLive" runat="server" Text="&nbsp Live Casino" />
                                            </div>
                                            <div class="col-sm-4">
                                                <asp:CheckBox class="form-check-input form-control-user" ID="cbSport" runat="server" Text="&nbsp Sportsbook" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-4 mb-3 mb-sm-0">
                                                <asp:CheckBox class="form-check-input form-control-user" ID="cbRNG" runat="server" Text="&nbsp RNG" />
                                            </div>
                                            <div class="col-sm-4">
                                                <asp:CheckBox class="form-check-input form-control-user" ID="cbFish" runat="server" Text="&nbsp Fish Hunter" />
                                            </div>
                                            <div class="col-sm-4">
                                                <asp:CheckBox class="form-check-input form-control-user" ID="cbPoker" runat="server" Text="&nbsp Poker" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-4 mb-3 mb-sm-0">
                                                <asp:CheckBox class="form-check-input form-control-user" ID="cbOther" runat="server" Text="&nbsp Other" />
                                            </div>
                                        </div>
                                    </div>
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
                                    <label>Balance</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtBalance" runat="server" placeholder="0.00" TextMode="Number" required="Required"></asp:TextBox>
                                </div>
                            </div>
                            <hr />
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Android Download Link</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtAndroid" runat="server" placeholder="https://www.example.com/android.apk" TextMode="Url"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>iOS Download Link</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtiOS" runat="server" placeholder="https://www.example.com/iphoneApp" TextMode="Url"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <label>Windows Download Link</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtWindows" runat="server" placeholder="https://www.example.com/game_installer.exe" TextMode="Url"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <label>Website Link</label>
                                    <asp:TextBox class="form-control form-control-user" ID="txtWebsite" runat="server" placeholder="https://www.example.com" TextMode="Url"></asp:TextBox>
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
                                                    <asp:FileUpload ID="fileUploader" runat="server" /></td>
                                                <td colspan="2">
                                                    <asp:Image ID="imgProduct" runat="server" Width="200px" /></td>
                                            </tr>
                                        </tbody>
                                    </table>
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
        <!-- /.container-fluid -->

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

