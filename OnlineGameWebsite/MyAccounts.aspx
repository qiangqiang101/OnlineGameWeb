<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="MyAccounts.aspx.vb" Inherits="MyAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" Runat="Server">
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
            <div class="row">
                <div class="col-md-12">
                    <article class="shop-cart p-t-50 p-b-50">
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
        </div>
    </div>
</asp:Content>

