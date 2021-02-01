<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="GeneralSettings.aspx.vb" Inherits="Admin_GeneralSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Settings</h1>

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
                                <label>Company Name</label>
                                <asp:textbox class="form-control form-control-user" id="txtCompany" runat="server" placeholder="Company Name" required="Required"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Copyright</label>
                                <asp:textbox class="form-control form-control-user" id="txtCopyright" runat="server" placeholder="© 2020 Online Game Website" required="Required"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Image</label>
                                <div class="custom-file">
                                    <asp:fileupload cssclass="custom-file-input" id="fileUploader" runat="server" clientidmode="Static" />
                                    <label class="custom-file-label" for="fileUploader" id="fileUploaderLabel" runat="server">Select logo file</label>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <asp:image id="imgLogo" runat="server" cssclass="img-fluid" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Recommend Bonus Percentage</label>
                                <asp:textbox class="form-control form-control-user" id="txtRecBonusPercent" runat="server" placeholder="0.1" required="Required" textmode="Number"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Recommend Bonus Minimum Amount</label>
                                <asp:textbox class="form-control form-control-user" id="txtRecBonusMinAmount" runat="server" placeholder="10.0" required="Required" textmode="Number"></asp:textbox>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-3 ml-auto">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnSubmit" runat="server" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Twilio SMS API</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Twilio Enable</label>
                                <asp:dropdownlist cssclass="form-control form-control-user" id="cmbTwilioEnabled" autopostback="True" runat="server" placeholder="">
                                        <asp:ListItem Value="False">Disabled</asp:ListItem>
                                        <asp:ListItem Value="True">Enabled</asp:ListItem>
                                    </asp:dropdownlist>
                            </div>
                            <div class="col-sm-6">
                                <label>Phone No.</label>
                                <asp:textbox class="form-control form-control-user" id="txtTwilioPhone" runat="server" placeholder="Phone No." textmode="Phone"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Account SID</label>
                                <asp:textbox class="form-control form-control-user" id="txtTwilioSID" runat="server" placeholder="Account SID"></asp:textbox>
                            </div>
                            <div class="col-sm-6">
                                <label>Auth Token</label>
                                <asp:textbox class="form-control form-control-user" id="txtTwilioToken" runat="server" placeholder="Auth Token"></asp:textbox>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-3 ml-auto">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnSubmitTwilio" runat="server" Text="Submit" />
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

    <script>
        $('#fileUploader').on('change', function () {
            //get the file name
            var fileName = $(this).val();
            //replace the "Choose a file" label
            $(this).next('.custom-file-label').html(fileName);
        })
    </script>
</asp:Content>

