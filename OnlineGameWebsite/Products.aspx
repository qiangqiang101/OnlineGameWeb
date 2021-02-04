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
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
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
                        <h4><%=Resources.Resource.Contact %></h4>
                        <ul class="contact m-b-60" id="pdtPageContact" runat="server">
                            <%-- Contact list will show here --%>
                        </ul>
                    </aside>
                </div>
                <div class="col-md-9">
                    <article class="services p-t-50 p-b-60">
                        <div class="row masonry" id="productView" runat="server">
                        </div>
                    </article>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

