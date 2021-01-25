<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Products.aspx.vb" Inherits="_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">

        <section class="header-page" id="headerBgImg" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1 id="catTitleH1" runat="server">ALL PRODUCTS</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active" id="catTitle" runat="server">All Products</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <aside class="aside p-t-50">
                        <h4>Categories</h4>
                        <ul class="category m-b-60">
                            <li id="catSlot" runat="server"><a href="Products.aspx?cat=slot">Slot Game</a></li>
                            <li id="catLive" runat="server"><a href="Products.aspx?cat=live">Live Casino</a></li>
                            <li id="catSport" runat="server"><a href="Products.aspx?cat=sport">Sportsbook</a></li>
                            <li id="catRNG" runat="server"><a href="Products.aspx?cat=rng">RNG</a></li>
                            <li id="catFish" runat="server"><a href="Products.aspx?cat=fish">Fish Hunter</a></li>
                            <li id="catPoker" runat="server"><a href="Products.aspx?cat=poker">Poker</a></li>
                            <li id="catOther" runat="server"><a href="Products.aspx?cat=other">Other</a></li>
                            <li id="catAll" runat="server"><a href="Products.aspx?cat=all">All Products</a></li>
                        </ul>
                        <%--<h4>Brochure Download</h4>
                        <ul class="download m-b-60">
                            <li><a href="#"><i class="fa fa-file-pdf-o"></i>palovit_2016_en.psd</a></li>
                            <li><a href="#"><i class="fa fa-file-pdf-o"></i>palovit_2016_en.psd</a></li>
                        </ul>--%>
                        <h4>Contact Us</h4>
                        <ul class="contact m-b-60">
                            <li>How can we help you? Click to contact us immediately.</li>
                            <li><a href="#">Live Chat <i class="fa fa-chevron-right"></i></a></li>
                            <li><a href="#">WhatsApp <i class="fa fa-chevron-right"></i></a></li>
                            <li><a href="#">Telegram <i class="fa fa-chevron-right"></i></a></li>
                            <li><a href="Contact.aspx">Contact Us <i class="fa fa-chevron-right"></i></a></li>
                        </ul>
                    </aside>
                </div>
                <div class="col-md-9">
                    <article class="services p-t-50 p-b-60">
                        <div class="row masonry" id="productView" runat="server">
                            <%--<div class="col-md-4 item">
                                <img src="Theme/img/services-1.jpg" class="img-responsive" alt="" />
                                <div>
                                    <a href="#">
                                        <h4>Architecture Design</h4>
                                    </a>
                                    <p>Sportsman delighted improving dashwoods gay instantly happiness six. Ham now amounted absolute not mistaken way pleasant whatever.</p>
                                    <a href="#" class="read">READ MORE</a>
                                </div>
                            </div>
                            <div class="col-md-4 item">
                                <img src="Theme/img/services-2.jpg" class="img-responsive" alt="" />
                                <div>
                                    <a href="#">
                                        <h4>Building Painting</h4>
                                    </a>
                                    <p>Sportsman delighted improving dashwoods gay instantly happiness six. Ham now amounted absolute not mistaken way pleasant whatever.</p>
                                    <a href="#" class="read">READ MORE</a>
                                </div>
                            </div>
                            <div class="col-md-4 item">
                                <img src="Theme/img/services-3.jpg" class="img-responsive" alt="" />
                                <div>
                                    <a href="#">
                                        <h4>Laminate Floring</h4>
                                    </a>
                                    <p>Sportsman delighted improving dashwoods gay instantly happiness six. Ham now amounted absolute not mistaken way pleasant whatever.</p>
                                    <a href="#" class="read">READ MORE</a>
                                </div>
                            </div>
                            <div class="col-md-4 item">
                                <img src="Theme/img/services-4.jpg" class="img-responsive" alt="" />
                                <div>
                                    <a href="#">
                                        <h4>Parquet Polishing</h4>
                                    </a>
                                    <p>Sportsman delighted improving dashwoods gay instantly happiness six. Ham now amounted absolute not mistaken way pleasant whatever.</p>
                                    <a href="#" class="read">READ MORE</a>
                                </div>
                            </div>
                            <div class="col-md-4 item">
                                <img src="Theme/img/services-5.jpg" class="img-responsive" alt="" />
                                <div>
                                    <a href="#">
                                        <h4>Building Repair</h4>
                                    </a>
                                    <p>Sportsman delighted improving dashwoods gay instantly happiness six. Ham now amounted absolute not mistaken way pleasant whatever.</p>
                                    <a href="#" class="read">READ MORE</a>
                                </div>
                            </div>
                            <div class="col-md-4 item">
                                <img src="Theme/img/services-6.jpg" class="img-responsive" alt="" />
                                <div>
                                    <a href="#">
                                        <h4>Construction Management</h4>
                                    </a>
                                    <p>Sportsman delighted improving dashwoods gay instantly happiness six. Ham now amounted absolute not mistaken way pleasant whatever.</p>
                                    <a href="#" class="read">READ MORE</a>
                                </div>
                            </div>--%>
                        </div>
                        <%--<nav class="text-center">
                            <ul class="pagination m-t-30">
                                <li>
                                    <a href="#" aria-label="Previous">
                                        <i class="fa fa-angle-left" aria-hidden="true"></i>
                                    </a>
                                </li>
                                <li><a href="#">1</a></li>
                                <li><a href="#">2</a></li>
                                <li class="active"><span>3</span></li>
                                <li><a href="#">4</a></li>
                                <li><a href="#">5</a></li>
                                <li>
                                    <a href="#" aria-label="Next">
                                        <i class="fa fa-angle-right" aria-hidden="true"></i>
                                    </a>
                                </li>
                            </ul>
                        </nav>--%>
                    </article>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

