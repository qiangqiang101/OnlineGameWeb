<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="MyAccounts.aspx.vb" Inherits="MyAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page inm_history">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>MY ACCOUNTS</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">My Accounts</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <article class="page-contact p-t-30 p-b-50">
                <div class="row">
                    <div class="col-md-3">
                        <hr class="hr" />
                        <h4>Categories</h4>
                        <ul class="category m-b-60">
                            <li><a href="MyProfile.aspx">Profile</a></li>
                            <li><a href="MyPassword.aspx">Password</a></li>
                            <li class="active"><a href="MyAccounts.aspx">Accounts</a></li>
                            <%--<li><a href="TransactionHistory.aspx">Transaction History</a></li>--%>
                        </ul>
                    </div>
                    <div class="col-md-9">
                        <hr class="hr" />
                        <h4>Accounts</h4>
                        <article class="shop-cart">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Table CssClass="table" ID="table" runat="server">
                                        <asp:TableHeaderRow TableSection="TableHeader">
                                            <asp:TableHeaderCell>Product</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Category</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>User Name</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Password</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Action</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                        </article>
                    </div>
                </div>
            </article>
        </div>
    </div>
</asp:Content>

