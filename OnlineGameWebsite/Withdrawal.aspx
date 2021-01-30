<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Withdrawal.aspx.vb" Inherits="Withdrawal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page inm_withdraw">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>WITHDRAWAL</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Withdrawal</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <article class="page-contact p-t-30 p-b-50">
                        <div class="row">
                            <div class="col-md-3">
                                <hr class="hr" />
                                <h4>Categories</h4>
                                <ul class="category m-b-60">
                                    <li><a href="Deposit.aspx">Deposit</a></li>
                                    <li class="active"><a href="Withdrawal.aspx">Withdrawal</a></li>
                                    <li><a href="Transfer.aspx">Transfer</a></li>
                                    <li><a href="TransactionHistory.aspx">Transaction History</a></li>
                                    <li><a href="GameAccount.aspx">Game Account</a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4>Withdrawal</h4>
                                <form action="#" class="m-t-30">
                                    <asp:UpdatePanel ID="upForm" runat="server">
                                        <ContentTemplate>
                                            <asp:ScriptManager ID="smForm" runat="server"></asp:ScriptManager>
                                            <div class="form-group col-md-6">
                                                <label>Amount</label>
                                                <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" placeholder="30.00" TextMode="Number" required="Required" AutoCompleteType="None" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Product</label>
                                                <asp:DropDownList CssClass="form-control" ID="cmbProduct" AutoPostBack="False" runat="server" placeholder="">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Bank</label>
                                                <asp:DropDownList CssClass="form-control" ID="cmbBank" AutoPostBack="True" runat="server" placeholder="">
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
                                            <div class="form-group col-md-6">
                                                <label>Bank Account Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtBankAccountName" runat="server" placeholder="" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Bank Account No.</label>
                                                <asp:TextBox CssClass="form-control" ID="txtBankAccountNo" runat="server" placeholder="" AutoPostBack="False"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Remark</label>
                                                <asp:TextBox CssClass="form-control" ID="txtRemark" runat="server" placeholder=""></asp:TextBox>
                                            </div>
                                            <div class="form-group m-t-30">
                                                <div class="form-group col-md-6">
                                                    <label>Captcha</label>
                                                    <asp:TextBox class="form-control" ID="txtVerification" runat="server" placeholder="" TextMode="SingleLine" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label></label>
                                                    <img src="#" id="captchaImg" runat="server" class="img-responsive" alt="" style="height: 50px;" />
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-group m-t-30 col-md-12">
                                        <asp:Button class="btn btn-palovit center-block" ID="btnSubmit" runat="server" Text="SUBMIT" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

