<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Promotion.aspx.vb" Inherits="Promotion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">

        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.PromotionMenu %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.Promotion %></li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <article class="code p-t-50 p-b-50">
                        <div class="palovit-accordion panel-group m-t-30" id="accordion" role="tablist" aria-multiselectable="true" runat="server">
                            <%--Promotions will show here--%>
                        </div>
                    </article>
                </div>
            </div>
        </div>
</asp:Content>

