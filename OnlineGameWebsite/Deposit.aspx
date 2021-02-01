<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Deposit.aspx.vb" Inherits="Deposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page inm_deposit">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>DEPOSIT</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Deposit</li>
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
                                    <li class="active"><a href="Deposit.aspx">Deposit</a></li>
                                    <li><a href="Withdrawal.aspx">Withdrawal</a></li>
                                    <li><a href="Transfer.aspx">Transfer</a></li>
                                    <li><a href="TransactionHistory.aspx">Transaction History</a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4>Deposit</h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label>Bank</label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbBank" AutoPostBack="False" runat="server" placeholder="">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Amount</label>
                                        <asp:UpdatePanel ID="updateAmount" runat="server">
                                            <ContentTemplate>
                                                <asp:ScriptManager ID="smUpdateAmount" runat="server"></asp:ScriptManager>
                                                <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" placeholder="30.00" TextMode="Number" required="Required" AutoCompleteType="None" AutoPostBack="True" MaxLength="10"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Date</label>
                                        <asp:TextBox CssClass="form-control" ID="txtDepositDate" runat="server" placeholder="dd/MM/yyyy" TextMode="DateTimeLocal" required="Required" AutoPostBack="False"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-6">
                                        <label>Deposit Type</label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbDepositType" AutoPostBack="False" runat="server" placeholder="">
                                            <asp:ListItem Value="0">Cash Deposit Machine</asp:ListItem>
                                            <asp:ListItem Value="1">ATM Transfer</asp:ListItem>
                                            <asp:ListItem Value="2">Internet Transfer</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Receipt</label>
                                        <asp:FileUpload CssClass="form-control" ID="fileUploader" runat="server" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Referral Code</label>
                                        <asp:TextBox CssClass="form-control" ID="txtRefCode" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Promotion</label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbPromotion" AutoPostBack="False" runat="server" placeholder="">
                                            <asp:ListItem Value="-1">No Thanks</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Product</label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbProduct" AutoPostBack="False" runat="server" placeholder="">
                                        </asp:DropDownList>
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

