<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Contact.aspx.vb" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" Runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>CONTACT</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Contact</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <article class="page-contact p-t-30 p-b-50">
                        <div class="row">
                            <div class="col-md-5">
                                <hr class="hr" />
                                <img src="Theme/img/contact.jpg" class="img-responsive" alt="" />
                            </div>
                            <div class="col-md-7">
                                <hr class="hr" />
                                <h4>Contact Information</h4>
                                <ul class="adress m-t-30 m-b-30">
                                    <li><i class="far fa-commenting"></i>Our Customer Service officers are available 24 hours a day, 7 days a week to serve you better.<br /><a class="btn btn-arrow slider20 m-r-10" href="#" target="_blank">Live Chat <i class="fa fa-chevron-right"></i></a></li>
                                    <li><i class="fab fa-telegram-plane"></i><a href="#">bibitelegram</a> - Bibi<br />
                                        <a href="#">deboratelegram</a> - Debora</li>
                                    <li><i class="fab fa-whatsapp"></i><a href="#">+6012-345 6789</a> - Bibi<br />
                                        <a href="#">+6013-456 7890</a> - Debora</li>
                                    <li><i class="fas fa-phone"></i><a href="tel:+6012-345 6789">+6012-345 6789</a> - Bibi<br />
                                        <a href="tel:+6013-456 7890">+6013-456 7890</a> - Debora</li>
                                    <li><i class="fab fa-weixin"></i>wxid_0123456789 - Bibi<br />
                                        wxid_9876543210 - Debora</li>
                                    <li><i class="fas fa-envelope"></i>contact@gmail.com<br />
                                        support@hotmail.com</li>
                                </ul>
                                <hr class="hr" />
                                <h4>Social Media</h4>
                                <ul class="adress m-t-30 m-b-30">
                                    <li><i class="fab fa-facebook-f"></i><a href="#" target="_blank">Facebook</a></li>
                                    <li><i class="fab fa-twitter"></i><a href="#" target="_blank">Twitter</a></li>
                                    <li><i class="fab fa-youtube"></i><a href="#" target="_blank">Youtube</a></li>
                                    <li><i class="fab fa-tiktok"></i><a href="#" target="_blank">Tiktok</a></li>
                                    <li><i class="fa fa-instagram"></i><a href="#" target="_blank">Instagram</a></li>
                                </ul>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

