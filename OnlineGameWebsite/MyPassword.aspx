<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="MyPassword.aspx.vb" Inherits="MyPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" Runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.MyPasswordU %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.Password %></li>
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
                                <h4><%=Resources.Resource.Categories %></h4>
                                <ul class="category m-b-60">
                                    <li><a href="MyProfile.aspx"><%=Resources.Resource.Profile %></a></li>
                                    <li class="active"><a href="MyPassword.aspx"><%=Resources.Resource.Password %></a></li>
                                    <li><a href="MyAccounts.aspx"><%=Resources.Resource.Accounts %></a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4><%=Resources.Resource.PasswordDetails %></h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.CurrentPassword %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtOldPassword" runat="server" required="Required" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.NewPassword %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtNewPassword" runat="server" required="Required" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.ConfirmNewPassword %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtConfirmPassword" runat="server" required="Required" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group m-t-30 col-md-12">
                                        <asp:Button class="btn btn-palovit center-block" ID="btnSubmit" runat="server" Text="<%$Resources:Resource, SaveChangesU%>" />
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

