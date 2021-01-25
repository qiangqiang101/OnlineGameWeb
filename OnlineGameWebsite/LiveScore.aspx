<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="LiveScore.aspx.vb" Inherits="LiveScore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>LIVE SCORE</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Live Score</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <article class="p-t-50 p-b-50">
                        <div>
                            <p>
                                <iframe src="http://freelive.7m.cn/live.aspx?mark=en&amp;TimeZone=%2B0800&amp;wordAd=&amp;wadurl=http://&amp;width=700&amp;cpageBgColor=FFFFFF&amp;tableFontSize=11&amp;cborderColor=DDDDDD&amp;ctdColor1=FFFFFF&amp;ctdColor2=E0E9F6&amp;clinkColor=0044DD&amp;cdateFontColor=333333&amp;cdateBgColor=FFFFFF&amp;scoreFontSize=12&amp;cteamFontColor=000000&amp;cgoalFontColor=FF0000&amp;cgoalBgColor=FFFFE1&amp;cremarkFontColor=0000FF&amp;cremarkBgColor=F7F8F3&amp;Skins=10&amp;teamWeight=400&amp;scoreWeight=700&amp;goalWeight=400&amp;fontWeight=700&amp;DSTbox=" width="100%" height="1080px" frameborder="0" style="border: 0" allowfullscreen></iframe>
                            </p>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

