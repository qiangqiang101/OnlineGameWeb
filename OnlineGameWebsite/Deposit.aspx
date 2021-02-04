<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Deposit.aspx.vb" Inherits="Deposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dvcontent" runat="Server">
    <div class="main">
        <section class="header-page inm_deposit">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1><%=Resources.Resource.DepositU %></h1>
                        <ul class="breadcrumb">
                            <li><a href="Default.aspx"><%=Resources.Resource.Home %></a></li>
                            <li class="active"><%=Resources.Resource.Deposit %></li>
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
                                    <li class="active"><a href="Deposit.aspx"><%=Resources.Resource.Deposit %></a></li>
                                    <li><a href="Withdrawal.aspx"><%=Resources.Resource.Withdrawal %></a></li>
                                    <li><a href="Transfer.aspx"><%=Resources.Resource.Transfer %></a></li>
                                    <li><a href="TransactionHistory.aspx"><%=Resources.Resource.TransactionHistory %></a></li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <hr class="hr" />
                                <h4><%=Resources.Resource.Deposit %></h4>
                                <form action="#" class="m-t-30">
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Bank %><span class="req">*</span></label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbBank" AutoPostBack="False" runat="server" placeholder="">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Amount %><span class="req">*</span></label>
                                        <asp:UpdatePanel ID="updateAmount" runat="server">
                                            <ContentTemplate>
                                                <asp:ScriptManager ID="smUpdateAmount" runat="server"></asp:ScriptManager>
                                                <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" placeholder="30.00" TextMode="Number" required="Required" AutoCompleteType="None" AutoPostBack="True" MaxLength="10"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Date %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtDepositDate" runat="server" placeholder="dd/MM/yyyy" TextMode="DateTimeLocal" AutoPostBack="False"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.DepositType %><span class="req">*</span></label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbDepositType" AutoPostBack="False" runat="server" placeholder="">
                                            <asp:ListItem Value="0" Text="<%$Resources:Resource, CashDepositMachine%>"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="<%$Resources:Resource, ATMTransfer%>"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="<%$Resources:Resource, InternetTransfer%>"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Receipt %></label>
                                        <asp:FileUpload CssClass="form-control" ID="fileUploader" runat="server" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.RefCode %></label>
                                        <asp:TextBox CssClass="form-control" ID="txtRefCode" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Promotion %><span class="req">*</span></label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbPromotion" AutoPostBack="False" runat="server" placeholder="">
                                            <asp:ListItem Value="-1" Text="<%$Resources:Resource, NoThanks%>"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label><%=Resources.Resource.Product %><span class="req">*</span></label>
                                        <asp:DropDownList CssClass="form-control" ID="cmbProduct" AutoPostBack="False" runat="server" placeholder="">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group m-t-30">
                                        <div class="form-group col-md-6">
                                            <label><%=Resources.Resource.Captcha %><span class="req">*</span></label>
                                            <asp:TextBox class="form-control" ID="txtVerification" runat="server" placeholder="" TextMode="SingleLine" ClientIDMode="Static"></asp:TextBox>
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
                                    </div>
                                    <div class="form-group m-t-30 col-md-12">
                                        <asp:Button class="btn btn-palovit center-block" ID="btnSubmit" runat="server" Text="<%$Resources:Resource, Submit %>" />
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

