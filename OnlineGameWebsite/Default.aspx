<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="dvhead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="dvcontent" ContentPlaceHolderID="dvcontent" runat="Server">
    <div>
        <div class="ms-fullscreen-template">
            <div class="master-slider ms-skin-default" id="masterslider" clientidmode="Static" runat="server">
                <!-- sliders from database will show here -->
            </div>
        </div>

        <section class="archive2 p-t-60 p-b-20">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 m-b-30 item">
                        <div><i class="fa fa-heart"></i></div>
                        <div>
                            <h4><%=Resources.Resource.LiveCasinoMenu %></h4>
                            <p><%=Resources.Resource.LiveCasinoSubtitle %></p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <div><i class="fa fa-futbol-o"></i></div>
                        <div>
                            <h4><%=Resources.Resource.SportsbookMenu %></h4>
                            <p><%=Resources.Resource.SportsbookSubtitle %></p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <div><i class="fa fa-trophy"></i></div>
                        <div>
                            <h4><%=Resources.Resource.SlotGameMenu %></h4>
                            <p><%=Resources.Resource.SlotGameSubtitle %></p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <div><i class="fa fa-list"></i></div>
                        <div>
                            <h4><%=Resources.Resource.RngMenu %></h4>
                            <p><%=Resources.Resource.RngSubtitle %></p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <div><i class="fa fa-fighter-jet"></i></div>
                        <div>
                            <h4><%=Resources.Resource.FishHunterMenu %></h4>
                            <p><%=Resources.Resource.FishHunterSubtitle %></p>
                        </div>
                    </div>
                    <div class="col-md-4 m-b-30 item">
                        <div><i class="fa fa-diamond"></i></div>
                        <div>
                            <h4><%=Resources.Resource.PokerMenu %></h4>
                            <p><%=Resources.Resource.PokerSubtitle %></p>
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
                        <h2><%=Resources.Resource.WhyChooseUs %></h2>
                        <p><%=Resources.Resource.WhyChooseUsSubtitle %></p>
                    </div>

                    <div class="col-md-6 p-t-30">
                        <div class="panel-group m-t-30" id="accordion" role="tablist" aria-multiselectable="true">
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading1">
                                    <h3 class="panel-title">
                                        <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse1" aria-expanded="true" aria-controls="collapse1">
                                            <i class="fa fa-chevron-up"></i>
                                            <%=Resources.Resource.WCUAcc1T %>
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse1" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="heading1">
                                    <div class="panel-body">
                                        <p><%=Resources.Resource.WCUAcc1S %></p>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading2">
                                    <h3 class="panel-title">
                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2">
                                            <i class="fa fa-chevron-down"></i>
                                            <%=Resources.Resource.WCUAcc2T %>
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading2">
                                    <div class="panel-body">
                                        <p><%=Resources.Resource.WCUAcc2S %></p>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading3">
                                    <h3 class="panel-title">
                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse3" aria-expanded="false" aria-controls="collapse3">
                                            <i class="fa fa-chevron-down"></i>
                                            <%=Resources.Resource.WCUAcc3T %>
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading3">
                                    <div class="panel-body">
                                        <p><%=Resources.Resource.WCUAcc3S %></p>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading4">
                                    <h3 class="panel-title">
                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse4" aria-expanded="false" aria-controls="collapse4">
                                            <i class="fa fa-chevron-down"></i>
                                            <%=Resources.Resource.WCUAcc4T %>
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse4" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading4">
                                    <div class="panel-body">
                                        <p><%=Resources.Resource.WCUAcc4S %></p>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id="heading5">
                                    <h3 class="panel-title">
                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse5" aria-expanded="false" aria-controls="collapse5">
                                            <i class="fa fa-chevron-down"></i>
                                            <%=Resources.Resource.WCUAcc5T %>
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapse5" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading5">
                                    <div class="panel-body">
                                        <p><%=Resources.Resource.WCUAcc5S %></p>
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
