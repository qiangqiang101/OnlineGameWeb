<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.vb" Inherits="Register" %>

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
                                    <center><h4>Registration</h4></center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>Full Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtFullName" runat="server" placeholder="Tan Ah Kow" required="Required" AutoCompleteType="DisplayName"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <label>Date of Birth</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtBirthday" runat="server" placeholder="dd/MM/yyyy" TextMode="Date" required="Required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>Contact No</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtContact" runat="server" placeholder="+60123456789" TextMode="Phone" required="Required" AutoCompleteType="HomePhone"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <label>Email</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" AutoCompleteType="Email" runat="server" placeholder="user@email.com" TextMode="Email" required="Required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>Referral Code</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtRegRefCode" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <label>Gender</label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="cmbGender" AutoPostBack="True" runat="server" placeholder="">
                                            <asp:ListItem Selected="True" Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>User ID</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtUserID" runat="server" placeholder="User ID" required="Required"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <label>Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required="Required"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <label>Confirm Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="txtPassword2" runat="server" placeholder="Password" TextMode="Password" required="Required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row" style="margin-left: 5px;">
                                <div class="col">
                                    <div class="form-check-label">
                                    <asp:CheckBox class="form-check-input" ID="cbTnc" runat="Server" Text="&nbsp I understand and accept all the policies, Conditions, Rules and Privacy statement." /><br />
                                    <asp:CheckBox class="form-check-input" ID="cb18yo" runat="Server" Text="&nbsp I declare that I am 18 years old or above." />
                                    <br />
                                    <br />
                                </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 mx-auto">
                                    <center>
                           <div class="form-group">
                               <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnRegister" runat="server" Text="Sign Up Now" />
                               <a href="Login.aspx">Already a member?</a>
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
