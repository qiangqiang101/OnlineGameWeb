<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="dvhead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="dvcontent" ContentPlaceHolderID="dvcontent" runat="Server">
        <div>
            <div class="container-fluid container">
            <br />
            <div class="row">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                            <i class="fas fa-user"></i>
                                        </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <center><h4>Login</h4></center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>User ID / Email</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtUserID" runat="server" placeholder="User ID / Email" required="Required"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <label>Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required="Required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-6 mx-auto">
                                    <center>
                           <div class="form-group">
                               <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnLogin" runat="server" Text="Login" />
                               <p><a href="ForgotPassword.aspx">Forgot password?</a> / <a href="Register.aspx">Not a member yet?</a></p>
                           </div>
                        </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <img src="images/reg.jpg" alt="register" style="width: auto;" />
                </div>
            </div>
        </div>
        </div>
</asp:Content>
