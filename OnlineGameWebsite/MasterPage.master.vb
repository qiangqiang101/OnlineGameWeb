Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub btnHead_Click(sender As Object, e As EventArgs) Handles btnHead.Click
        Dim role As String = HttpContext.Current.Session("role")

        Select Case role
            Case "user", "admin"
                Response.Redirect("Deposit.aspx")
            Case Else
                Response.Redirect("Register.aspx")
        End Select
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUserID.Text = Nothing Then
            JsMsgBox(Me.Page, "UserID is required!")
        ElseIf txtPassword.Text = Nothing Then
            JsMsgBox(Me.Page, "Password is required!")
        Else
            If IsMemberLoginSuccess(txtUserID.Text.Trim, txtPassword.Text.Trim, Page) Then
                LogAction(txtUserID.Text.Trim, Request.UserHostAddress, eLogType.Login)
                Response.Redirect("Default.aspx")
            Else
                JsMsgBox(Me.Page, "Incorrect UserID or Password.")
            End If
        End If
    End Sub

    Private Sub logout_ServerClick(sender As Object, e As EventArgs) Handles logout.ServerClick
        Session.Clear()
        Response.Redirect("Default.aspx")
    End Sub

    Private Function LoadProductMenus(text As String, url As String) As HtmlGenericControl
        Dim a = New HtmlGenericControl("a")
        With a
            .Attributes("href") = url.Trim
            .InnerText = text.Trim
        End With
        Dim li = New HtmlGenericControl("li")
        With li
            .Controls.Add(a)
        End With
        Return li
    End Function

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Title = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game")
        siteLogo.Src = ConfigSettings.ReadSetting(Of String)("CompanyLogo", "Theme/img/logo.png")
        siteLogo2.src = ConfigSettings.ReadSetting(Of String)("CompanyLogo", "Theme/img/logo.png")
        siteTitle.InnerText = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game")
        copyright.InnerText = ConfigSettings.ReadSetting(Of String)("CopyrightText", "Copyright 2020. All Rights Reserved.")

        If Request.Cookies("Lang") Is Nothing Then
            With Response.Cookies("Lang")
                .Value = 0
                .Expires = Now.AddYears(1)
            End With

        End If

        If IsClientOnMobileDevice(Request) Then
            mobileProduct.Visible = True
            megaProduct.Visible = False
        Else
            Using db As New DataClassesDataContext
                Dim slots = db.TblProducts.Where(Function(x) x.Status = True And x.CatSlot = True).Take(5).ToList
                For Each slot As TblProduct In slots
                    menuSlot.Controls.Add(LoadProductMenus(slot.ProductName, "Product.aspx?id=" & slot.ProductID))
                Next
                menuSlot.Controls.Add(LoadProductMenus("More Slot Game...", "Products.aspx?cat=slot"))

                Dim lcs = db.TblProducts.Where(Function(x) x.Status = True And x.CatLive = True).Take(5).ToList
                For Each lc As TblProduct In lcs
                    menuLive.Controls.Add(LoadProductMenus(lc.ProductName, "Product.aspx?id=" & lc.ProductID))
                Next
                menuLive.Controls.Add(LoadProductMenus("More Live Casino...", "Products.aspx?cat=live"))

                Dim sports = db.TblProducts.Where(Function(x) x.Status = True And x.CatSport = True).Take(5).ToList
                For Each sport As TblProduct In sports
                    menuSport.Controls.Add(LoadProductMenus(sport.ProductName, "Product.aspx?id=" & sport.ProductID))
                Next
                menuSport.Controls.Add(LoadProductMenus("More Sportsbook...", "Products.aspx?cat=sport"))

                Dim rngs = db.TblProducts.Where(Function(x) x.Status = True And x.CatRNG = True).Take(5).ToList
                For Each rng As TblProduct In rngs
                    menuRNG.Controls.Add(LoadProductMenus(rng.ProductName, "Product.aspx?id=" & rng.ProductID))
                Next
                menuRNG.Controls.Add(LoadProductMenus("More RNG...", "Products.aspx?cat=rng"))

                Dim fishes = db.TblProducts.Where(Function(x) x.Status = True And x.CatFish = True).Take(5).ToList
                For Each fish As TblProduct In fishes
                    menuFish.Controls.Add(LoadProductMenus(fish.ProductName, "Product.aspx?id=" & fish.ProductID))
                Next
                menuFish.Controls.Add(LoadProductMenus("More Fish Hunter...", "Products.aspx?cat=fish"))

                Dim pokers = db.TblProducts.Where(Function(x) x.Status = True And x.CatPoker = True).Take(5).ToList
                For Each poker As TblProduct In pokers
                    menuPoker.Controls.Add(LoadProductMenus(poker.ProductName, "Product.aspx?id=" & poker.ProductID))
                Next
                menuPoker.Controls.Add(LoadProductMenus("More Poker...", "Products.aspx?cat=poker"))

                Dim others = db.TblProducts.Where(Function(x) x.Status = True And x.CatOther = True).Take(5).ToList
                For Each other As TblProduct In others
                    menuOther.Controls.Add(LoadProductMenus(other.ProductName, "Product.aspx?id=" & other.ProductID))
                Next
                menuOther.Controls.Add(LoadProductMenus("More Other...", "Products.aspx?cat=other"))

                Dim products = db.TblProducts.Where(Function(x) x.Status = True).Take(5).ToList
                For Each product As TblProduct In products
                    menuAll.Controls.Add(LoadProductMenus(product.ProductName, "Product.aspx?id=" & product.ProductID))
                Next
                menuAll.Controls.Add(LoadProductMenus("More...", "Products.aspx?cat=all"))

                mobileProduct.Visible = False
                megaProduct.Visible = True
            End Using
        End If

        If Not IsPostBack Then

        End If

        Dim role As String = HttpContext.Current.Session("role")

        Select Case role
            Case "user", "admin"
                memberLogin.Visible = False
                memberMenu.Visible = True
                memberName.Visible = True
                memberName.InnerText = "Hello, " & Session("fullname")
                btnHead.Text = "Deposit"
            Case Else
                memberLogin.Visible = True
                memberMenu.Visible = False
                memberName.Visible = False
                btnHead.Text = "Sign Up Now"
        End Select
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If txtFullName.Text = Nothing Then
            JsMsgBox(Me.Page, "Full Name is required!")
        ElseIf txtBirthday.Text = Nothing Then
            JsMsgBox(Me.Page, "Birthday is required!")
        ElseIf txtContact.Text = Nothing Then
            JsMsgBox(Me.Page, "Contact No. is required!")
        ElseIf txtEmail.Text = Nothing Then
            JsMsgBox(Me.Page, "Email is required!")
        ElseIf IsEmailExists(txtEmail.Text) Then
            JsMsgBox(Me.Page, "Email is already been registered!")
        ElseIf Not IsEmailValid(txtEmail.Text) Then
            JsMsgBox(Me.Page, "Email is not valid!")
        ElseIf txtUserIDr.Text = Nothing Then
            JsMsgBox(Me.Page, "UserID is required!")
        ElseIf txtUserIDr.Text.Length < 6 Then
            JsMsgBox(Me.Page, "UserID is too short!")
        ElseIf IsMemberExists(txtUserIDr.Text) Then
            JsMsgBox(Me.Page, "UserID already taken, please try another one.")
        ElseIf txtPasswordr.Text = Nothing Then
            JsMsgBox(Me.Page, "Password is required!")
        ElseIf txtPasswordr2.Text = Nothing Then
            JsMsgBox(Me.Page, "Please confirm your password.")
        ElseIf txtPasswordr.Text <> txtPasswordr2.Text Then
            JsMsgBox(Me.Page, "Your password did not match!")
        ElseIf Not cb18yo.Checked Then
            JsMsgBox(Me.Page, "You have to be at least 18 years old to register.")
        ElseIf Not cbTnc.Checked Then
            JsMsgBox(Me.Page, "Please accept the Terms & Conditions.")
        Else
            If RegisterMember() Then
                LogAction(txtUserIDR.Text.Trim, Request.UserHostAddress, eLogType.Register)
                JsMsgBox(Me.Page, "Registration completed!")
                If IsMemberLoginSuccess(txtUserIDR.Text, txtPasswordR.Text, Page) Then
                    LogAction(txtUserIDR.Text.Trim, Request.UserHostAddress, eLogType.Login)
                    Response.Redirect("Default.aspx")
                End If
            Else
                JsMsgBox(Me.Page, "Registration failed! Please contact Customer Service.")
            End If
        End If
    End Sub

    Private Function RegisterMember() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newMember As New TblMember
                With newMember
                    .UserName = txtUserIDR.Text.Trim
                    .Password = txtPasswordR.Text.Trim
                    .Email = txtEmail.Text.Trim
                    .PhoneNo = txtContact.Text.Trim
                    .FullName = txtFullName.Text.Trim
                    .DateOfBirth = Date.ParseExact(txtBirthday.Text.Trim, "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    .RefCode = txtUserIDR.Text.GetHashCode
                    .RefCodeReg = Nothing
                    .VipLevel = 0
                    .Promotion = 0F
                    .DateCreated = Now
                    .LastModified = Now
                    .IPAddress = Request.UserHostAddress
                    .GroupLeaderID = -1
                    .Enabled = True
                    .Remark = Nothing
                    .Affiliate = Nothing
                End With

                db.TblMembers.InsertOnSubmit(newMember)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub langEn_ServerClick(sender As Object, e As EventArgs) Handles langEn.ServerClick
        Response.Cookies("Lang").Value = 0
        Response.Redirect(Request.RawUrl.ToString())
    End Sub

    Private Sub langZh_ServerClick(sender As Object, e As EventArgs) Handles langZh.ServerClick
        Response.Cookies("Lang").Value = 1
        Response.Redirect(Request.RawUrl.ToString())
    End Sub

    Private Sub langMy_ServerClick(sender As Object, e As EventArgs) Handles langMy.ServerClick
        Response.Cookies("Lang").Value = 2
        Response.Redirect(Request.RawUrl.ToString())
    End Sub
End Class

