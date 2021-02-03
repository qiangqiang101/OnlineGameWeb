<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="MyProfile.aspx.vb" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>MY PROFILE</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Profile</li>
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
                            <div class="col-md-3">
                                <hr class="hr" />
                                <h4>Categories</h4>
                                <ul class="category m-b-60">
                                    <li class="active"><a href="MyProfile.aspx">Profile</a></li>
                                    <li><a href="MyPassword.aspx">Password</a></li>
                                    <li><a href="MyAccounts.aspx">Accounts</a></li>
                                    <%--<li><a href="TransactionHistory.aspx">Transaction History</a></li>--%>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4>Profile Details</h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label>User ID</label>
                                        <asp:TextBox CssClass="form-control" ID="txtUserID" runat="server" ReadOnly="True" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Email</label>
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" TextMode="Email" required="Required" AutoCompleteType="Email"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Phone No.</label>
                                        <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server" TextMode="Phone" AutoCompleteType="HomePhone" required="Required"></asp:TextBox>

                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Full Name</label>
                                        <asp:TextBox CssClass="form-control" ID="txtFullName" runat="server" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Birthday</label>
                                        <asp:TextBox CssClass="form-control" ID="txtBirthday" runat="server" placeholder="dd/MM/yyyy" TextMode="Date" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Referral Code</label>
                                        <asp:TextBox CssClass="form-control" ID="txtRefCode" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Bank</label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbBank" AutoPostBack="False" runat="server" placeholder="">
                                            <asp:ListItem Value="-1">---</asp:ListItem>
                                            <asp:ListItem Value="0">Maybank</asp:ListItem>
                                            <asp:ListItem Value="1">CIMB Bank</asp:ListItem>
                                            <asp:ListItem Value="2">Public Bank</asp:ListItem>
                                            <asp:ListItem Value="3">RHB Bank</asp:ListItem>
                                            <asp:ListItem Value="4">Hong Leong Bank</asp:ListItem>
                                            <asp:ListItem Value="5">AmBank</asp:ListItem>
                                            <asp:ListItem Value="6">UOB Bank</asp:ListItem>
                                            <asp:ListItem Value="7">Bank Rakyat</asp:ListItem>
                                            <asp:ListItem Value="8">OCBC Bank</asp:ListItem>
                                            <asp:ListItem Value="9">HSBC Bank</asp:ListItem>
                                            <asp:ListItem Value="10">Affin Bank</asp:ListItem>
                                            <asp:ListItem Value="11">Bank Islam</asp:ListItem>
                                            <asp:ListItem Value="12">Standard Chartered Bank</asp:ListItem>
                                            <asp:ListItem Value="13">CitiBank</asp:ListItem>
                                            <asp:ListItem Value="14">Bank Simpanan Malaysia</asp:ListItem>
                                            <asp:ListItem Value="15">Bank Muamalat</asp:ListItem>
                                            <asp:ListItem Value="16">Alliance Bank</asp:ListItem>
                                            <asp:ListItem Value="17">Agrobank</asp:ListItem>
                                            <asp:ListItem Value="18">Al-Rajhi</asp:ListItem>
                                            <asp:ListItem Value="19">MBSB Bank</asp:ListItem>
                                            <asp:ListItem Value="20">Co-op Bank Pertama</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Bank Account No.</label>
                                        <asp:TextBox CssClass="form-control" ID="txtBankAccNo" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group m-t-30 col-md-12">
                                        <asp:Button class="btn btn-palovit center-block" ID="btnSubmit" runat="server" Text="SAVE CHANGES" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

