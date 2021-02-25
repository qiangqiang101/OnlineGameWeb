<%@ Page Title="" Language="VB" MasterPageFile="~/PWA/PWA.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="PWA_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">

        <div class="double-slider owl-carousel owl-no-dots" id="productSlider" runat="server">
            <%--slider--%>
        </div>

        <div class="card card-style shadow-xl">
            <div class="content">
                <p class="color-highlight font-600 mb-n1">About Us</p>
                <h1 class="font-24 font-700 mb-2">Online Gaming<i class="fa fa-star mt-n2 font-30 color-yellow-dark float-right mr-2 scale-box"></i></h1>
                <p class="mb-1">
                    We are one of the most excellent and trusted online casino brands in Asia, we are manage by Billion Ace Investment Ltd Company, registered and certified by First Cagayan Leisure & Resort Corporation and officially approved by Philippines government. As a top online gambling sites, we provides a lot of online betting games such as casino games, online sports betting and slot games.
                </p>
            </div>
        </div>

        <div class="card card-full-left card-style">
            <div class="content">
                <div class="d-flex">
                    <div class="mr-3">
                        <img width="120" class="fluid-img rounded-m shadow-xl" src="images/pictures/31l.jpg">
                    </div>
                    <div>
                        <p class="color-highlight font-600 mb-n1">The Best Sportsbook Online</p>
                        <h2>Live Sports Betting</h2>
                        <a href="index-components.html" class="btn btn-sm rounded-s font-13 font-600 gradient-highlight">View All</a>
                    </div>
                </div>

                <div class="divider mt-4"></div>

                <div class="d-flex">
                    <div class="mr-3">
                        <img width="120" class="fluid-img rounded-m shadow-xl" src="images/pictures/31l.jpg">
                    </div>
                    <div>
                        <p class="color-highlight font-600 mb-n1">Play Malaysia Live Casino Games Online</p>
                        <h2>Real Live Casino</h2>

                        <a href="index-pages.html" class="btn btn-sm rounded-s font-13 font-600 gradient-highlight">View All</a>
                    </div>
                </div>
                <div class="divider mt-4"></div>

                <div class="d-flex">
                    <div class="mr-3">
                        <img width="120" class="fluid-img rounded-m shadow-xl" src="images/pictures/31l.jpg">
                    </div>
                    <div>
                        <p class="color-highlight font-600 mb-n1">Play Online Slot Game</p>
                        <h2>Slots Club</h2>

                        <a href="index-homepages.html" class="btn btn-sm rounded-s font-13 font-600 gradient-highlight">View All</a>
                    </div>
                </div>

            </div>
        </div>

        <div class="row mb-0">
            <a href="#" class="col-6 pr-2">
                <div class="card mr-0 card-style">
                    <div class="d-flex pt-3 pb-3">
                        <div class="align-self-center">
                            <i class="fa fa-home color-green-light ml-3 font-34 mt-1"></i>
                        </div>
                        <div class="align-self-center">
                            <h5 class="pl-2 ml-1 mb-0">PWA
                                <br>
                                Ready</h5>
                        </div>
                    </div>
                    <p class="px-3">
                        Enjoy AppKit from your Home Screen.
                    </p>
                </div>
            </a>
            <a href="#" class="col-6 pl-2">
                <div class="card ml-0 card-style">
                    <div class="d-flex pt-3 pb-3">
                        <div class="align-self-center">
                            <i class="fa fa-cog color-blue-dark ml-3 font-34 mt-1"></i>
                        </div>
                        <div class="align-self-center">
                            <h5 class="pl-2 ml-1 mb-0">Clean<br>
                                Code</h5>
                        </div>
                    </div>
                    <p class="px-3">
                        Powered by Bootstrap makes your job easier!
                    </p>
                </div>
            </a>
        </div>

        <a href="#" data-toggle-theme-switch>
            <div class="card card-style">
                <div class="d-flex pt-3 mt-1 mb-2 pb-2">
                    <div class="align-self-center">
                        <i class="color-icon-gray color-gray-dark font-30 icon-40 text-center fa fa-moon ml-3 show-on-theme-light"></i>
                        <i class="color-icon-yellow color-yellow-dark font-30 icon-40 text-center fa fa-sun ml-3 show-on-theme-dark"></i>
                    </div>
                    <div class="align-self-center">
                        <p class="pl-2 ml-1 color-highlight font-500 mb-n1 mt-n1">Tap to Enable</p>
                        <h4 class="show-on-theme-light pl-2 ml-1 mb-0">Dark Mode</h4>
                        <h4 class="show-on-theme-dark pl-2 ml-1 mb-0">Light Mode</h4>
                    </div>
                    <div class="ml-auto align-self-center">
                        <div class="custom-control ios-switch mr-5 pr-2 mt-n2">
                            <input type="checkbox" class="ios-input" id="toggle-dark-switch">
                            <label class="custom-control-label" for="toggle-dark-switch"></label>
                        </div>
                    </div>
                </div>
            </div>
        </a>

        <div data-menu-load="menu-footer.html"></div>
    </div>
</asp:Content>

