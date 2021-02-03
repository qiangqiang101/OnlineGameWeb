<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="MyAccounts.aspx.vb" Inherits="MyAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page inm_history">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.MyAccountsU %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.MyAccounts %></li>
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
                        <h4><%=Resources.Resource.Categories %></h4>
                        <ul class="category m-b-60">
                            <li><a href="MyProfile.aspx"><%=Resources.Resource.Profile %></a></li>
                            <li><a href="MyPassword.aspx"><%=Resources.Resource.Password %></a></li>
                            <li class="active"><a href="MyAccounts.aspx"><%=Resources.Resource.Accounts %></a></li>
                        </ul>
                    </div>
                    <div class="col-md-9">
                        <hr class="hr" />
                        <h4><%=Resources.Resource.Accounts %></h4>
                        <article class="shop-cart">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Table CssClass="table" ID="table" runat="server">
                                        <asp:TableHeaderRow TableSection="TableHeader">
                                            <asp:TableHeaderCell Text="<%$Resources:Resource, Product%>"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell Text="<%$Resources:Resource, Name%>"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell Text="<%$Resources:Resource, Category%>"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell Text="<%$Resources:Resource, UserName%>"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell Text="<%$Resources:Resource, Password%>"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell Text="<%$Resources:Resource, Action%>"></asp:TableHeaderCell>
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

