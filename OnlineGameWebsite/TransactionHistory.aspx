<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="TransactionHistory.aspx.vb" Inherits="TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page inm_history">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.TransactionHistoryU %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.TransactionHistory %></li>
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
                                <h4><%=Resources.Resource.Categories %></h4>
                                <ul class="category m-b-60">
                                    <li><a href="Deposit.aspx"><%=Resources.Resource.Deposit %></a></li>
                                    <li><a href="Withdrawal.aspx"><%=Resources.Resource.Withdrawal %></a></li>
                                    <li><a href="Transfer.aspx"><%=Resources.Resource.Transfer %></a></li>
                                    <li class="active"><a href="TransactionHistory.aspx"><%=Resources.Resource.TransactionHistory %></a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4><%=Resources.Resource.TransactionHistory %></h4>
                                <div class="palovit-tab">
                                    <ul class="nav nav-tabs" role="tablist">
                                        <li role="presentation" class="active">
                                            <a href="#tabDeposit" aria-controls="tabDeposit" role="tab" data-toggle="tab"><%=Resources.Resource.DepositU %></a>
                                        </li>
                                        <li role="presentation">
                                            <a href="#tabPromotion" aria-controls="tabPromotion" role="tab" data-toggle="tab"><%=Resources.Resource.PromotionMenu %></a>
                                        </li>
                                        <li role="presentation">
                                            <a href="#tabWithdrawal" aria-controls="tabWithdrawal" role="tab" data-toggle="tab"><%=Resources.Resource.WithdrawalU %></a>
                                        </li>
                                        <li role="presentation">
                                            <a href="#tabTransfer" aria-controls="tabTransfer" role="tab" data-toggle="tab"><%=Resources.Resource.TransferU %></a>
                                        </li>
                                    </ul>
                                    <div class="tab-content">
                                        <div role="tabpanel" class="tab-pane active p-15" id="tabDeposit">
                                            <asp:Table CssClass="table table-hover" ID="tblDeposit" runat="server">
                                                <asp:TableHeaderRow TableSection="TableHeader">
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Date%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Product%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, PaymentMethod%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Status%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Amount%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Action%>"></asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                        <div role="tabpanel" class="tab-pane p-15" id="tabPromotion">
                                            <asp:Table CssClass="table table-hover" ID="tblPromotion" runat="server">
                                                <asp:TableHeaderRow TableSection="TableHeader">
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Date%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Product%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, PaymentMethod%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Status%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Amount%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Action%>"></asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                        <div role="tabpanel" class="tab-pane p-15" id="tabWithdrawal">
                                            <asp:Table CssClass="table table-hover" ID="tblWithdraw" runat="server">
                                                <asp:TableHeaderRow TableSection="TableHeader">
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Date%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Product%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, PaymentMethod%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Status%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Amount%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Action%>"></asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                        <div role="tabpanel" class="tab-pane p-15" id="tabTransfer">
                                            <asp:Table CssClass="table table-hover" ID="tblTransfer" runat="server">
                                                <asp:TableHeaderRow TableSection="TableHeader">
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Date%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, From%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, To%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Status%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Amount%>"></asp:TableHeaderCell>
                                                    <asp:TableHeaderCell Text="<%$Resources:Resource, Action%>"></asp:TableHeaderCell>
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

