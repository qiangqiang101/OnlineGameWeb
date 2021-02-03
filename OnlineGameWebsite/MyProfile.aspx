<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="MyProfile.aspx.vb" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.MyProfileU %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.Profile %></li>
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
                                    <li class="active"><a href="MyProfile.aspx"><%=Resources.Resource.Profile %></a></li>
                                    <li><a href="MyPassword.aspx"><%=Resources.Resource.Password %></a></li>
                                    <li><a href="MyAccounts.aspx"><%=Resources.Resource.Accounts %></a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4><%=Resources.Resource.ProfileDetails %></h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.UserID %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtUserID" runat="server" ReadOnly="True" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Email %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" TextMode="Email" required="Required" AutoCompleteType="Email"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.ContactNo %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server" TextMode="Phone" AutoCompleteType="HomePhone" required="Required"></asp:TextBox>

                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.FullName %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtFullName" runat="server" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.DateOfBirth %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtBirthday" runat="server" placeholder="dd/MM/yyyy" TextMode="Date" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.RefCode %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtRefCode" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Bank %></label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbBank" AutoPostBack="False" runat="server" placeholder="">
                                            <asp:ListItem Value="-1">---</asp:ListItem>
                                            <asp:ListItem Value="0" Text="<%$Resources:Resource, Maybank%>"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="<%$Resources:Resource, CimbBank%>"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="<%$Resources:Resource, PublicBank%>"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="<%$Resources:Resource, RHBBank%>"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="<%$Resources:Resource, HongLeongBank%>"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="<%$Resources:Resource, AmBank%>"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="<%$Resources:Resource, UOBBank%>"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="<%$Resources:Resource, BankRakyat%>"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="<%$Resources:Resource, OCBCBank%>"></asp:ListItem>
                                            <asp:ListItem Value="9" Text="<%$Resources:Resource, HSBCBank%>"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="<%$Resources:Resource, AffinBank%>"></asp:ListItem>
                                            <asp:ListItem Value="11" Text="<%$Resources:Resource, BankIslam%>"></asp:ListItem>
                                            <asp:ListItem Value="12" Text="<%$Resources:Resource, SCBank%>"></asp:ListItem>
                                            <asp:ListItem Value="13" Text="<%$Resources:Resource, CitiBank%>"></asp:ListItem>
                                            <asp:ListItem Value="14" Text="<%$Resources:Resource, BankSN%>"></asp:ListItem>
                                            <asp:ListItem Value="15" Text="<%$Resources:Resource, BankMuamalat%>"></asp:ListItem>
                                            <asp:ListItem Value="16" Text="<%$Resources:Resource, AllianceBank%>"></asp:ListItem>
                                            <asp:ListItem Value="17" Text="<%$Resources:Resource, AgroBank%>"></asp:ListItem>
                                            <asp:ListItem Value="18" Text="<%$Resources:Resource, AlRajhi%>"></asp:ListItem>
                                            <asp:ListItem Value="19" Text="<%$Resources:Resource, MBSBBank%>"></asp:ListItem>
                                            <asp:ListItem Value="20" Text="<%$Resources:Resource, CoopBank%>"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.BankAccountNo %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtBankAccNo" runat="server" placeholder=""></asp:TextBox>
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

