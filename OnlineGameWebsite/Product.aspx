<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Product.aspx.vb" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1 id="pdtTitleH1" runat="server">PRODUCT</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active" id="pdtTitle" runat="server">Product</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <aside class="aside p-t-50">
                        <h4><%=Resources.Resource.Categories %></h4>
                        <ul class="category m-b-60">
                            <li id="catSlot" runat="server"><a href="Products.aspx?cat=slot"><%=Resources.Resource.SlotGame %></a></li>
                            <li id="catLive" runat="server"><a href="Products.aspx?cat=live"><%=Resources.Resource.LiveCasino %></a></li>
                            <li id="catSport" runat="server"><a href="Products.aspx?cat=sport"><%=Resources.Resource.Sportsbook %></a></li>
                            <li id="catRNG" runat="server"><a href="Products.aspx?cat=rng"><%=Resources.Resource.Rng %></a></li>
                            <li id="catFish" runat="server"><a href="Products.aspx?cat=fish"><%=Resources.Resource.FishHunter %></a></li>
                            <li id="catPoker" runat="server"><a href="Products.aspx?cat=poker"><%=Resources.Resource.Poker %></a></li>
                            <li id="catOther" runat="server"><a href="Products.aspx?cat=other"><%=Resources.Resource.Other %></a></li>
                            <li id="catAll" runat="server"><a href="Products.aspx?cat=all"><%=Resources.Resource.AllProducts %></a></li>
                        </ul>
                    </aside>
                </div>
                <div class="col-md-9">
                    <article class="services-detail p-t-40 p-b-40">
                        <hr class="hr" />
                        <h3 id="pdtTitleH3" runat="server">PRODUCT</h3>
                        <br />
                        <div class="row">
                            <div class="col-md-6 m-t-30">
                                <a href="#" class="image-popup-link" id="imgURL" runat="server">
                                    <img src="#" class="img-responsive" alt="" id="imgURL2" runat="server" /></a>
                            </div>
                        </div>
                        <div class="row m-t-30">
                            <div class="col-md-3 m-t-30 item" id="divUsername" runat="server">
                                <label id="username" runat="server">User Name:</label>
                            </div>
                            <div class="col-md-3 m-t-30 item" id="divPassword" runat="server">
                                <label id="password" runat="server">Password:</label>
                            </div>
                        </div>
                        <div class="row m-t-30">
                            <div class="col-md-6 m-t-30 item" id="divAndroid" runat="server">
                                <a href="#" target="_blank" class="btn btn-slider m-r-10" id="btnAndroid" runat="server" style="width: 100%;">ANDROID DOWNLOAD <i class="fa fa-android"></i></a>
                            </div>
                            <div class="col-md-6 m-t-30 item" id="divApple" runat="server">
                                <a href="#" target="_blank" class="btn btn-slider m-r-10" id="btnApple" runat="server" style="width: 100%;">iOS DOWNLOAD <i class="fa fa-apple"></i></a>
                            </div>
                            <div class="col-md-6 m-t-30 item" id="divWindows" runat="server">
                                <a href="#" target="_blank" class="btn btn-slider m-r-10" id="btnWindows" runat="server" style="width: 100%;">WINDOWS DOWNLOAD <i class="fa fa-windows"></i></a>
                            </div>
                            <div class="col-md-6 m-t-30 item" id="divWebsite" runat="server">
                                <a href="#" target="_blank" class="btn btn-slider m-r-10" id="btnWebsite" runat="server" style="width: 100%;">VISIT WEBSITE <i class="fa fa-html5"></i></a>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

