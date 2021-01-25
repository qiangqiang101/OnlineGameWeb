<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="404.aspx.vb" Inherits="_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>PAGE NOT FOUND</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">404 Page</li>
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
                            <h2>THIS PAGE IS NOT FOUND</h2>
                            <p>We apologize for the inconvenience. This is our fault. There is not a problem with your computer or Internet connection.</p>
                            <button type="button" onclick="window.location.href='Default.aspx'" class="btn btn-slider-black">BACK TO HOME</button>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

