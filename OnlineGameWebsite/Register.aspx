<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

<asp:Content ID="dvhead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="dvcontent" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.RegisterU %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.SignUp %></li>
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
                                <h4><%=Resources.Resource.SignUp %></h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.FullName %><span class="req">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="txtFullName" runat="server" placeholder="Tan Ah Kow" required="Required" AutoCompleteType="DisplayName"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.DateOfBirth %><span class="req">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="txtBirthday" runat="server" placeholder="15/10/1999" TextMode="Date" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.ContactNo %><span class="req">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="txtContact" runat="server" placeholder="+60123456789" TextMode="Phone" required="Required" AutoCompleteType="HomePhone"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Email %><span class="req">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" AutoCompleteType="Email" runat="server" placeholder="user@email.com" TextMode="Email" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.RefCode %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtRegRefCode" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.UserID %><span class="req">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtUserID" runat="server" placeholder="User ID" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Password %><span class="req">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.ConfirmPassword %><span class="req">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtPassword2" runat="server" placeholder="Password" TextMode="Password" required="Required"></asp:TextBox>
                                    </div>
                                    <div class="form-check-label col-md-12 clearfix">
                                        <asp:CheckBox class="form-check-input" ID="cbTnc" runat="Server" Text="" /><%=Resources.Resource.RegisterTnCP1 %><a href='Terms.aspx' target='_blank'><%=Resources.Resource.TnC %></a><%=Resources.Resource.RegisterTnCP2 %><a href='Privacy.aspx' target='_blank'><%=Resources.Resource.PrivacyMenuBtm %></a><%=Resources.Resource.RegisterTncP3 %><span class="req">*</span><br />
                                        <asp:CheckBox class="form-check-input" ID="cb18yo" runat="Server" Text="<%$Resources:Resource, IDeclare18YearsOld%>" /><span class="req">*</span>
                                    </div>
                                    <div class="form-group m-t-30">
                                        <asp:Button class="btn btn-palovit center-block" ID="btnRegister" runat="server" Text="<%$Resources:Resource, CreateAccNow%>" />
                                    </div>
                                </form>
                            </div>
                            <div class="col-md-3">
                                <hr class="hr" />
                                <h4><%=Resources.Resource.MemberBenefits %></h4>
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
