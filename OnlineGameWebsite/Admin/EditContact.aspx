<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EditContact.aspx.vb" Inherits="Admin_EditContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Contact</h1>

        <!-- DataTales Example -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary" id="h6" runat="server">Contact</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>List</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbList" AutoPostBack="True" runat="server" placeholder="">
                                    <asp:ListItem Value="0">Telegram</asp:ListItem>
                                    <asp:ListItem Value="1">WhatsApp</asp:ListItem>
                                    <asp:ListItem Value="2">Phone No.</asp:ListItem>
                                    <asp:ListItem Value="3">QQ</asp:ListItem>
                                    <asp:ListItem Value="4">WeChat</asp:ListItem>
                                    <asp:ListItem Value="5">Line</asp:ListItem>
                                    <asp:ListItem Value="6">Skype</asp:ListItem>
                                    <asp:ListItem Value="7">Discord</asp:ListItem>
                                    <asp:ListItem Value="8">Facebook</asp:ListItem>
                                    <asp:ListItem Value="9">Twitter</asp:ListItem>
                                    <asp:ListItem Value="10">Youtube</asp:ListItem>
                                    <asp:ListItem Value="11">TikTok</asp:ListItem>
                                    <asp:ListItem Value="12">Instagram</asp:ListItem>
                                    <asp:ListItem Value="13">Email</asp:ListItem>
                                    <asp:ListItem Value="14">LiveChat</asp:ListItem>
                                    <asp:ListItem Value="15">Custom Link</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                                <label>Type</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbType" AutoPostBack="True" runat="server" placeholder="">
                                    <asp:ListItem Value="0">Chat App</asp:ListItem>
                                    <asp:ListItem Value="1">Social Media</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Name</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtName" runat="server" placeholder="Debora" required="Required"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label>Website URL</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtAccNo" runat="server" placeholder="username" required="Required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <label>Icon CSS</label>
                               <asp:TextBox class="form-control form-control-user" ID="txtFaIcon" runat="server" placeholder="fab fa-facebook-f" required="Required"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label>Status</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnabled" AutoPostBack="True" runat="server" placeholder="">
                                    <asp:ListItem Value="True">Enabled</asp:ListItem>
                                    <asp:ListItem Value="False">Disabled</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <hr />
                        <div class="form-group row">
                            <div class="col-sm-2 ml-auto">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnSubmit" runat="server" Text="Update" />
                            </div>
                            <div class="col-sm-2">
                                <input type="button" class="btn btn-primary btn-user btn-block" onclick="window.location = 'Contacts.aspx'" value="Go Back" />
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

