<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="404.aspx.vb" Inherits="_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.PageNotFoundAlso %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.PageNotFoundToo %></li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <article class="page-404 p-t-50 p-b-50">
                        <div>
                            <h1>404</h1>
                            <h2><%=Resources.Resource.PageNotFound %></h2>
                            <p><%=Resources.Resource.PnfSubtitle %></p>
                            <button type="button" onclick="window.location.href='Default.aspx'" class="btn btn-slider-black"><%=Resources.Resource.BackToHomeU %></button>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

