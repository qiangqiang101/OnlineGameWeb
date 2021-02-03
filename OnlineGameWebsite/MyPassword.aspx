<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="MyPassword.aspx.vb" Inherits="MyPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" Runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>MY PASSWORD</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Password</li>
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
                                    <li><a href="MyProfile.aspx">Profile</a></li>
                                    <li class="active"><a href="MyPassword.aspx">Password</a></li>
                                    <li><a href="MyAccounts.aspx">Accounts</a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4>Password Details</h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label>Current Password</label>
                                        <asp:TextBox CssClass="form-control" ID="txtOldPassword" runat="server" required="Required" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>New Password</label>
                                        <asp:TextBox CssClass="form-control" ID="txtNewPassword" runat="server" required="Required" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Confirm New Password</label>
                                        <asp:TextBox CssClass="form-control" ID="txtConfirmPassword" runat="server" required="Required" TextMode="Password"></asp:TextBox>
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

