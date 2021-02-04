<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Withdrawal.aspx.vb" Inherits="Withdrawal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page inm_withdraw">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.WithdrawalU %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.Withdrawal %></li>
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
                                    <li><a href="Deposit.aspx"><%=Resources.Resource.Deposit %></a></li>
                                    <li class="active"><a href="Withdrawal.aspx"><%=Resources.Resource.Withdrawal %></a></li>
                                    <li><a href="Transfer.aspx"><%=Resources.Resource.Transfer %></a></li>
                                    <li><a href="TransactionHistory.aspx"><%=Resources.Resource.TransactionHistory %></a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4><%=Resources.Resource.Withdrawal %></h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Amount %><span class="req">*</span></label>
                                        <asp:UpdatePanel ID="upForm" runat="server">
                                            <ContentTemplate>
                                                <asp:ScriptManager ID="smForm" runat="server"></asp:ScriptManager>
                                                <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" placeholder="30.00" TextMode="Number" required="Required" AutoCompleteType="None" AutoPostBack="True"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Product %><span class="req">*</span></label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbProduct" AutoPostBack="False" runat="server" placeholder="">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Bank %><span class="req">*</span></label>
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
                                        <label><%=Resources.Resource.BankAccountName %><span class="req">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="txtBankAccountName" runat="server" placeholder="" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.BankAccountNo %><span class="req">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="txtBankAccountNo" runat="server" placeholder="" AutoPostBack="False"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Remarks %><span class="req"></span></label>
                                        <asp:TextBox CssClass="form-control" ID="txtRemark" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Captcha %><span class="req">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="txtVerification" runat="server" placeholder="" TextMode="SingleLine" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label></label>
                                        <asp:UpdatePanel ID="upCaptcha" runat="server">
                                            <ContentTemplate>
                                                <a href="#" id="refreshCaptcha" runat="server">
                                                    <img src="#" id="captchaImg" runat="server" class="img-responsive" alt="" style="height: 50px;" /></a>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="form-group m-t-30 col-md-12">
                                        <asp:Button class="btn btn-palovit center-block" ID="btnSubmit" runat="server" Text="<%$Resources:Resource, Submit%>" />
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

