<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Banking.aspx.vb" Inherits="Banking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.BankingMenu %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.Banking %></li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>

        <section class="plans dotted-bg p-t-30 p-b-60">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 palovit-title m-b-20">
                        <p><%=Resources.Resource.BankingSubtitle %></p>
                    </div>
                </div>
                <div class="row" id="bankList" runat="server">
                    <%-- Bank List will show here --%>
                </div>
                <div class="row">
                    <div class="col-md-12 m-b-20">
                        <p><strong><%=Resources.Resource.BankingPleaseNote %></strong></p>
                        <ul>
                            <li><%=Resources.Resource.BankingPN1 %></li>
                            <li><%=Resources.Resource.BankingPN2 %></li>
                            <li><%=Resources.Resource.BankingPN3 %></li>
                            <li><%=Resources.Resource.BankingPN4 %></li>
                            <li><%=Resources.Resource.BankingPN5 %></li>
                            <li><%=Resources.Resource.BankingPN6 %></li>
                            <li><%=Resources.Resource.BankingPN7 %></li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

