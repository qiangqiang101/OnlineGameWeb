<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Banking.aspx.vb" Inherits="Banking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>BANKING</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Banking</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>

        <section class="plans dotted-bg p-t-30 p-b-60">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 palovit-title m-b-20">
                        <p>You can make transactions with convenience and efficient, as there is a wide variety of withdrawal and deposit methods for you to pick and choose from. Please glance over at all of our banking options shown below, and choose a method that suits you best.</p>
                    </div>
                </div>
                <div class="row" id="bankList" runat="server">
                    <%-- Bank List will show here --%>
                </div>
                <div class="row">
                    <div class="col-md-12 m-b-20">
                        <p><strong>Please note: </strong></p>
                        <ul>
                            <li>All maximum amounts are based on per transaction per day.</li>
                            <li>You may contact our Customer Service for more information on our panel banks.</li>
                            <li>Please keep any bank receipts or transaction reference numbers as we require a proof of transaction</li>
                            <li>Attaching your proof of deposit along with your deposit ticket will reduce the delay of the deposit transaction.</li>
                            <li>Standard verification will be requested upon processing any withdrawals from your eWallet.</li>
                            <li>Large withdrawals or withdrawal amounts above the daily limit might a longer time to process.</li>
                            <li>If a bonus/promotion is utilized, Kindly be aware of its related turnover requirements before requesting for a withdrawal.</li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

