<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="GameAccounts.aspx.vb" Inherits="Admin_GameAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Game Account</h1>

        <div class="row">
            <div class="col-lg-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">File Import</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-8 mb-3 mb-sm-0">
                                <label>File</label>
                                <div class="custom-file">
                                    <asp:FileUpload CssClass="custom-file-input" ID="fileUploader" runat="server" ClientIDMode="Static" />
                                    <label class="custom-file-label" for="fileUploader" id="fileUploaderLabel" runat="server">Select CSV file</label>
                                </div> 
<%--                                <div class="custom-file" id="customFile" lang="en">
                                    <asp:FileUpload CssClass="custom-file-input" ID="fileUploader" aria-describedby="fileHelp" runat="server" ClientIDMode="Static" />
                                    <label class="custom-file-label" for="fileUploader">Select CSV file...</label>
                                </div>--%>
                            </div>
                            <div class="col-sm-4">
                                <label>Product</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbProduct2" AutoPostBack="True" runat="server" placeholder=""></asp:DropDownList></td>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 ml-auto">
                                <asp:Button class="btn btn-warning btn-user btn-block" ID="btnUpload" runat="server" Text="Import" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Add New</h6>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                <label>User Name</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtUName" runat="server" placeholder="User Name"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label>Password</label>
                                <asp:TextBox class="form-control form-control-user" ID="txtPass" runat="server" placeholder="Password"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                <label>Product</label>
                                <asp:DropDownList CssClass="form-control form-control-user" ID="cmbProduct" AutoPostBack="True" runat="server" placeholder="">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 ml-auto">
                                <asp:Button class="btn btn-success btn-user btn-block" ID="btnAddPdtUserName" runat="server" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Game Accounts</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Table CssClass="table table-bordered" ID="dataTable" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Date Created</asp:TableHeaderCell>
                            <asp:TableHeaderCell>User Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Password</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Member</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
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


    <script>
        $('#fileUploader').on('change', function () {
                //get the file name
                var fileName = $(this).val();
                //replace the "Choose a file" label
                $(this).next('.custom-file-label').html(fileName);
            })
        </script>
</asp:Content>

