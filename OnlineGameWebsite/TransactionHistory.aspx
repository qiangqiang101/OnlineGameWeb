<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="TransactionHistory.aspx.vb" Inherits="TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page inm_history">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>TRANSACTION HISTORY</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Transaction History</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <article class="shop-cart p-t-50 p-b-50">
                        <div class="row">
                            <div class="col-md-3">
                                <hr class="hr" />
                                <h4>Categories</h4>
                                <ul class="category m-b-60">
                                    <li><a href="Deposit.aspx">Deposit</a></li>
                                    <li><a href="Withdrawal.aspx">Withdrawal</a></li>
                                    <li><a href="Transfer.aspx">Transfer</a></li>
                                    <li class="active"><a href="TransactionHistory.aspx">Transaction History</a></li>
                                    <li><a href="TransferHistory.aspx">Transfer History</a></li>
                                    <li><a href="GameAccount.aspx">Game Account</a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4>Deposit</h4>
                                <asp:Table CssClass="table" ID="tblDeposit" runat="server">
                                    <asp:TableHeaderRow TableSection="TableHeader">
                                        <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Payment Method</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Cancel</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                                <hr class="hr" />
                                <h4>Promotion</h4>
                                <asp:Table CssClass="table" ID="tblPromotion" runat="server">
                                    <asp:TableHeaderRow TableSection="TableHeader">
                                        <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Payment Method</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Cancel</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                                <hr class="hr" />
                                <h4>Withdrawal</h4>
                                <asp:Table CssClass="table" ID="tblWithdraw" runat="server">
                                    <asp:TableHeaderRow TableSection="TableHeader">
                                        <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Payment Method</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Cancel</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

