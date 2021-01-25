<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="dvhead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="dvcontent" ContentPlaceHolderID="dvcontent" runat="Server">
    <div>
        <div class="ms-fullscreen-template">
            <!-- masterslider -->
            <div class="master-slider ms-skin-default" id="masterslider" clientidmode="Static" runat="server">
                <!-- sliders from database will show here -->
            </div>
            <!-- end of masterslider -->
        </div>

        <section class="archive2 p-t-60 p-b-20">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 m-b-30 item">
                        <%--<div><i data-icon="O" class="icon"></i></div>--%>
                        <div><i class="fa fa-heart"></i></div>
                        <div>
                            <h4>LIVE CASINO</h4>
                            <p>Feel the same experience and adrenaline rush as in a real casino.</p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <%--<div><i data-icon=";" class="icon"></i></div>--%>
                        <div><i class="fa fa-futbol-o"></i></div>
                        <div>
                            <h4>SPORTSBOOK</h4>
                            <p>Thousands odds daily for all kind of sports betting around the world.</p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <%--<div><i data-icon="!" class="icon"></i></div>--%>
                        <div><i class="fa fa-trophy"></i></div>
                        <div>
                            <h4>SLOT GAMES</h4>
                            <p>More than 10 famous slot brands to choose from with over 1000+ slot games with realistic sound system and graphics.</p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <%--<div><i data-icon="P" class="icon"></i></div>--%>
                        <div><i class="fa fa-list"></i></div>
                        <div>
                            <h4>RNG</h4>
                            <p>Win more by betting with more number choices in our classic and ultimate keno!</p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <%--<div><i data-icon="^" class="icon"></i></div>--%>
                        <div><i class="fa fa-fighter-jet"></i></div>
                        <div>
                            <h4>FISH HUNTER</h4>
                            <p>Very simple yet exciting fishing games adventures with lots of features that many will enjoy playing.</p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <%--<div><i data-icon="V" class="icon"></i></div>--%>
                        <div><i class="fa fa-diamond"></i></div>
                        <div>
                            <h4>POKER</h4>
                            <p>Host up to 10 exceptional P2P games with real players and no bots.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="inm_bg1 accordion border-top p-t-30 p-b-50">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 palovit-title m-b-20">
                        <hr class="hr" />
                        <h2>WHY CHOOSE US</h2>
                        <p>We provides a positive entertainment facilities and supports responsible online gambling where any action is the player's responsibility. The safety and security of your information is incredibly important to us and we are committed to your safety and protection. All system used in our company are protected and secured.</p>
                    </div>

                    <div class="col-md-6 p-t-30">
                        <div class="panel-group m-t-30" id="accordion" role="tablist" aria-multiselectable="true">
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading1">
                                    <h3 class="panel-title">
                                        <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse1" aria-expanded="true" aria-controls="collapse1">
                                            <i class="fa fa-chevron-up"></i>
                                            RELIABLE
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse1" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="heading1">
                                    <div class="panel-body">
                                        <p>We build trust amongst our players by consistently proving a reliable platform that delivers a fastest transaction processes with security intact.</p>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading2">
                                    <h3 class="panel-title">
                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2">
                                            <i class="fa fa-chevron-down"></i>
                                            FAST PAYOUT
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading2">
                                    <div class="panel-body">
                                        <p>To provide a real-time casino feeling amongst our players, we strongly emphasize on our internal system, forming the best team to ensure the fastest deposit and withdrawal time.</p>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading3">
                                    <h3 class="panel-title">
                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse3" aria-expanded="false" aria-controls="collapse3">
                                            <i class="fa fa-chevron-down"></i>
                                            CUSTOMER FIRST
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading3">
                                    <div class="panel-body">
                                        <p>To establish a trustful relationship with players, we place your satisfaction above all else. We give back where we can, doing our best to provide great value and make life so much happier, easier, more fun, more value.</p>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading4">
                                    <h3 class="panel-title">
                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse4" aria-expanded="false" aria-controls="collapse4">
                                            <i class="fa fa-chevron-down"></i>
                                            IMAGINATIVE
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse4" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading4">
                                    <div class="panel-body">
                                        <p>We always find new ways to challenge convention, innovate our services to provide the best casino experience in our core markets.</p>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading5">
                                    <h3 class="panel-title">
                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse5" aria-expanded="false" aria-controls="collapse5">
                                            <i class="fa fa-chevron-down"></i>
                                            HUGE BONUS AND REWARDS
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse5" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading5">
                                    <div class="panel-body">
                                        <p>Not only astonishing graphics, but each online games also presents huge casino bonus rewards to the winners with 24 hours customer service. Up to millions of ringgits are waiting for every player, and you can be one of them!</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <img src="Theme/img/why-choose-us.jpg" class="img-responsive" alt="" />
                    </div>
                </div>
            </div>
        </section>

        <section class="clients border-top p-t-40 p-b-40">
            <div class="container">
                <div class="owl-carousel" data-items="6" data-autoplay="2000" id="productslider" runat="server">
                    <!-- products from database will show here -->
                </div>
            </div>
        </section>
    </div>
</asp:Content>
