<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

<asp:Content ID="dvhead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="dvcontent" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>REGISTER</h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active">Sign Up</li>
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
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4>Sign Up</h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label>Full Name</label>
                                        <asp:TextBox CssClass="form-control" ID="txtFullName" runat="server" placeholder="Tan Ah Kow" required="Required" AutoCompleteType="DisplayName"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Date of Birth</label>
                                        <asp:TextBox CssClass="form-control" ID="txtBirthday" runat="server" placeholder="dd/MM/yyyy" TextMode="Date" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Contact No</label>
                                        <asp:TextBox CssClass="form-control" ID="txtContact" runat="server" placeholder="+60123456789" TextMode="Phone" required="Required" AutoCompleteType="HomePhone"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-6">
                                        <label>Email</label>
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" AutoCompleteType="Email" runat="server" placeholder="user@email.com" TextMode="Email" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Referral Code</label>
                                        <asp:TextBox CssClass="form-control" ID="txtRegRefCode" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>User ID</label>
                                        <asp:TextBox class="form-control" ID="txtUserID" runat="server" placeholder="User ID" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Password</label>
                                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Confirm Password</label>
                                        <asp:TextBox class="form-control" ID="txtPassword2" runat="server" placeholder="Password" TextMode="Password" required="Required"></asp:TextBox>
                                    </div>
                                    <hr class="hr" />
                                    <div class="form-check-label col-md-12">
                                        <asp:CheckBox class="form-check-input" ID="cbTnc" runat="Server" Text="&nbsp I understand and accept all the policies, Conditions, Rules and Privacy statement." /><br />
                                        <asp:CheckBox class="form-check-input" ID="cb18yo" runat="Server" Text="&nbsp I declare that I am 18 years old or above." />
                                        <br />
                                        <br />
                                    </div>
                                    <div class="form-group m-t-30 center-block">
                                        <asp:Button class="btn btn-palovit" ID="btnRegister" runat="server" Text="CREATE ACCOUNT NOW" />
                                    </div>
                                </form>
                            </div>
                            <div class="col-md-3">
                                <hr class="hr" />
                                <h4>Member Benefits</h4>
                                <ul class="adress" id="benefitsList" runat="server">
                                    <%--Promotion will list here--%>
                                </ul>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
