<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Contact.aspx.vb" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" Runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.ContactMenu %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.Contact %></li>
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
                                <h4><%=Resources.Resource.ContactInformation %></h4>
                                <p><%=Resources.Resource.ContactSubtitle %></p>
                                <ul class="adress m-t-30 m-b-30" id="chatList" runat="server">
                                    <%-- Contact will show here --%>
                                </ul>
                                <hr class="hr" />
                                <h4><%=Resources.Resource.SocialMedia %></h4>
                                <ul class="adress m-t-30 m-b-30" id="socialList" runat="server">
                                    <%-- Social links will show here --%>
                                </ul>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

