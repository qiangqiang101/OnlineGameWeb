Imports System.Globalization
Imports System.Threading

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If IsMemberLoginSuccess(txtUserID.Text.Trim, txtPassword.Text.Trim, Page) Then
            LogAction(txtUserID.Text.Trim, Request.UserHostAddress, eLogType.Login)
            Response.Redirect("Default.aspx")
        Else
            swal(Me.Page, Resources.Resource.Oops, Resources.Resource.IncorrectUserIdPassword, "error")
        End If
    End Sub

    Private Sub logout_ServerClick(sender As Object, e As EventArgs) Handles logout.ServerClick
        Session.Abandon()
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

    Private Function GenerateLi(inHtml As String) As HtmlGenericControl
        Dim li = New HtmlGenericControl("li")
        With li
            .InnerHtml = "<i class=""far fa-user-circle""></i>" & inHtml
        End With

        Return li
    End Function

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        hFb.HRef = ConfigSettings.ReadSetting(Of String)("HeadFacebook", "#")
        hTw.HRef = ConfigSettings.ReadSetting(Of String)("HeadTwitter", "#")
        hIg.HRef = ConfigSettings.ReadSetting(Of String)("HeadInstagram", "#")
        hTt.HRef = ConfigSettings.ReadSetting(Of String)("HeadTikTok", "#")
        hYt.HRef = ConfigSettings.ReadSetting(Of String)("HeadYoutube", "#")

        hWs.InnerText = ConfigSettings.ReadSetting(Of String)("HeadWhatsApp", "#")
        hTg.InnerText = ConfigSettings.ReadSetting(Of String)("HeadTelegram", "#")
        hWc.InnerText = ConfigSettings.ReadSetting(Of String)("HeadWeChat", "#")

        Page.Title = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game")
        siteLogo.Src = ConfigSettings.ReadSetting(Of String)("CompanyLogo", "Theme/img/logo.png")
        siteLogo2.Src = ConfigSettings.ReadSetting(Of String)("CompanyLogo", "Theme/img/logo.png")
        siteTitle.InnerText = ConfigSettings.ReadSetting(Of String)("CompanyName", "Online Game")
        copyright.InnerText = ConfigSettings.ReadSetting(Of String)("CopyrightText", "Copyright 2020. All Rights Reserved.")

        Dim socialCache = "socialCache"
        Dim socialList As List(Of TblContact) = HttpRuntime.Cache(socialCache)
        If socialList Is Nothing Then
            Using db As New DataClassesDataContext
                socialList = db.TblContacts.Where(Function(x) x.Status = True And x.ShowFooter = True And x.ContactType = 0).Take(8).ToList
                HttpRuntime.Cache.Add(socialCache, socialList, Nothing, Now.AddHours(8), TimeSpan.Zero, CacheItemPriority.Default, Nothing)
            End Using
        End If
        For Each s As TblContact In socialList
            contactList.Controls.Add(GenerateContact(s.FaIcon.Trim, s.Website.Trim, s.ContactTitle.Trim))
        Next

        If Request.Cookies("Lang") Is Nothing Then
            With Response.Cookies("Lang")
                .Value = "en-US"
                .Expires = Now.AddYears(1)
            End With
        End If

        Select Case Request.Cookies("Lang").Value
            Case "zh-CN"
                ddlLanguages.Attributes("class") = "dropdown inm_flag_cn_ul"
            Case "my-MY"
                ddlLanguages.Attributes("class") = "dropdown inm_flag_my_ul"
            Case Else
                ddlLanguages.Attributes("class") = "dropdown inm_flag_gb_ul"
        End Select

        If IsClientOnMobileDevice(Request) Then
            mobileProduct.Visible = True
            megaProduct.Visible = False
        Else
            Dim productCache = "productCache"
            Dim productsList As List(Of TblProduct) = HttpRuntime.Cache(productCache)
            If productsList Is Nothing Then
                Using db As New DataClassesDataContext
                    productsList = db.TblProducts.Where(Function(x) x.Status = True).ToList
                    HttpRuntime.Cache.Add(productCache, productsList, Nothing, Now.AddHours(8), TimeSpan.Zero, CacheItemPriority.Default, Nothing)
                End Using
            End If

            Dim slots = productsList.Where(Function(x) x.CatSlot = True).Take(5).ToList
            For Each slot As TblProduct In slots
                menuSlot.Controls.Add(LoadProductMenus(slot.ProductName, "Product.aspx?id=" & slot.ProductID))
            Next
            menuSlot.Controls.Add(LoadProductMenus(Resources.Resource.More & Resources.Resource.SlotGame & "...", "Products.aspx?cat=slot"))

            Dim lcs = productsList.Where(Function(x) x.CatLive = True).Take(5).ToList
            For Each lc As TblProduct In lcs
                menuLive.Controls.Add(LoadProductMenus(lc.ProductName, "Product.aspx?id=" & lc.ProductID))
            Next
            menuLive.Controls.Add(LoadProductMenus(Resources.Resource.More & Resources.Resource.LiveCasino & "...", "Products.aspx?cat=live"))

            Dim sports = productsList.Where(Function(x) x.CatSport = True).Take(5).ToList
            For Each sport As TblProduct In sports
                menuSport.Controls.Add(LoadProductMenus(sport.ProductName, "Product.aspx?id=" & sport.ProductID))
            Next
            menuSport.Controls.Add(LoadProductMenus(Resources.Resource.More & Resources.Resource.Sportsbook & "...", "Products.aspx?cat=sport"))

            Dim rngs = productsList.Where(Function(x) x.CatRNG = True).Take(5).ToList
            For Each rng As TblProduct In rngs
                menuRNG.Controls.Add(LoadProductMenus(rng.ProductName, "Product.aspx?id=" & rng.ProductID))
            Next
            menuRNG.Controls.Add(LoadProductMenus(Resources.Resource.More & Resources.Resource.Rng & "...", "Products.aspx?cat=rng"))

            Dim fishes = productsList.Where(Function(x) x.CatFish = True).Take(5).ToList
            For Each fish As TblProduct In fishes
                menuFish.Controls.Add(LoadProductMenus(fish.ProductName, "Product.aspx?id=" & fish.ProductID))
            Next
            menuFish.Controls.Add(LoadProductMenus(Resources.Resource.More & Resources.Resource.FishHunter & "...", "Products.aspx?cat=fish"))

            Dim pokers = productsList.Where(Function(x) x.CatPoker = True).Take(5).ToList
            For Each poker As TblProduct In pokers
                menuPoker.Controls.Add(LoadProductMenus(poker.ProductName, "Product.aspx?id=" & poker.ProductID))
            Next
            menuPoker.Controls.Add(LoadProductMenus(Resources.Resource.More & Resources.Resource.Poker & "...", "Products.aspx?cat=poker"))

            Dim others = productsList.Where(Function(x) x.CatOther = True).Take(5).ToList
            For Each other As TblProduct In others
                menuOther.Controls.Add(LoadProductMenus(other.ProductName, "Product.aspx?id=" & other.ProductID))
            Next
            menuOther.Controls.Add(LoadProductMenus(Resources.Resource.More & Resources.Resource.Other & "...", "Products.aspx?cat=other"))

            Dim products = productsList.Take(5).ToList
            For Each product As TblProduct In products
                menuAll.Controls.Add(LoadProductMenus(product.ProductName, "Product.aspx?id=" & product.ProductID))
            Next
            menuAll.Controls.Add(LoadProductMenus(Resources.Resource.More & "...", "Products.aspx?cat=all"))

            mobileProduct.Visible = False
            megaProduct.Visible = True

            Dim winnerCache = "winnerCache"
            Dim winnersList As List(Of TblTransaction) = HttpRuntime.Cache(winnerCache)
            If winnersList Is Nothing Then
                Using db As New DataClassesDataContext
                    winnersList = db.TblTransactions.Where(Function(x) x.TransType = 1 And x.Status = 2).OrderByDescending(Function(x) x.TransactionDate).Take(7).ToList
                    HttpRuntime.Cache.Add(winnerCache, winnersList, Nothing, Now.AddMinutes(30), TimeSpan.Zero, CacheItemPriority.Default, Nothing)
                End Using
            End If

            For Each w As TblTransaction In winnersList
                wthdraw.Controls.Add(GenerateLi(Camoflauge(w.UserName.Trim) & Resources.Resource.Won & w.Debit.ToString("N") & " MYR " & w.TransactionDate.HowLong))
            Next
        End If

        If Not IsPostBack Then

        End If

        Dim role As String = HttpContext.Current.Session("role")

        Select Case role
            Case "user"
                memberLogin.Visible = False
                memberMenu.Visible = True
                memberName.Visible = True
                memberName.InnerText = Resources.Resource.Hello & Session("fullname")
                btnHeadReg.Visible = False
            Case Else
                memberLogin.Visible = True
                memberMenu.Visible = False
                memberName.Visible = False
                btnHeadAlt.Attributes("class") = "btn btn-slider-black"
                btnHeadAlt.Attributes.Remove("aria-haspopup")
                btnHeadAlt.Attributes.Remove("data-toggle")
                btnHeadAlt.Attributes.Remove("aria-expanded")
                btnHead.Attributes.Remove("class")
                btnHead.Visible = False

                btnHeadControls.Visible = False
        End Select

        fFb.HRef = ConfigSettings.ReadSetting(Of String)("HeadFacebook", "#")
        fTw.HRef = ConfigSettings.ReadSetting(Of String)("HeadTwitter", "#")
        fIg.HRef = ConfigSettings.ReadSetting(Of String)("HeadInstagram", "#")
        fTt.HRef = ConfigSettings.ReadSetting(Of String)("HeadTikTok", "#")
        fYt.HRef = ConfigSettings.ReadSetting(Of String)("HeadYoutube", "#")

        htmlCode.InnerHtml = ConfigSettings.ReadSetting(Of String)("HTMLCode", "").Base64ToString
    End Sub

    'Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
    '    If IsEmailExists(txtEmail.Text) Then
    '        swal(Me.Page, Resources.Resource.Oops, Resources.Resource.EmailAlreadyRegister, "error")
    '    ElseIf Not IsEmailValid(txtEmail.Text) Then
    '        swal(Me.Page, Resources.Resource.Oops, Resources.Resource.EmailNotValid, "error")
    '    ElseIf txtUserIDR.Text.Length < 6 Then
    '        swal(Me.Page, Resources.Resource.Oops, Resources.Resource.UserIdTooShort, "error")
    '    ElseIf IsMemberExists(txtUserIDR.Text) Then
    '        swal(Me.Page, Resources.Resource.Oops, Resources.Resource.UserIdTaken, "error")
    '    ElseIf txtPasswordR.Text <> txtPasswordR2.Text Then
    '        swal(Me.Page, Resources.Resource.Oops, Resources.Resource.PasswordNotMatch, "error")
    '    ElseIf Not cb18yo.Checked Then
    '        swal(Me.Page, Resources.Resource.UnderAge, Resources.Resource.TooYoung, "warning")
    '    ElseIf Not cbTnc.Checked Then
    '        swal(Me.Page, Resources.Resource.TnC, Resources.Resource.AcceptTnC, "warning")
    '    Else
    '        If RegisterMember() Then
    '            LogAction(txtUserIDR.Text.Trim, Request.UserHostAddress, eLogType.Register)
    '            If IsMemberLoginSuccess(txtUserIDR.Text, txtPasswordR.Text, Page) Then
    '                LogAction(txtUserIDR.Text.Trim, Request.UserHostAddress, eLogType.Login)
    '                Response.Redirect("Default.aspx")
    '            End If
    '        Else
    '            swal(Me.Page, Resources.Resource.Oops, Resources.Resource.RegFailed, "error")
    '        End If
    '    End If
    'End Sub

    'Private Function RegisterMember() As Boolean
    '    Try
    '        Using db As New DataClassesDataContext
    '            Dim newMember As New TblMember
    '            With newMember
    '                .UserName = txtUserIDR.Text.Trim
    '                .Password = txtPasswordR.Text.Trim
    '                .Email = txtEmail.Text.Trim
    '                .PhoneNo = txtContact.Text.Trim
    '                .FullName = txtFullName.Text.Trim
    '                .DateOfBirth = Date.ParseExact(txtBirthday.Text.Trim, "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
    '                .RefCode = txtUserIDR.Text.GetHashCode
    '                .RefCodeReg = Nothing
    '                .VipLevel = 0
    '                .Promotion = 0F
    '                .DateCreated = Now
    '                .LastModified = Now
    '                .IPAddress = Request.UserHostAddress
    '                .GroupLeaderID = -1
    '                .Enabled = True
    '                .Remark = Nothing
    '                .Affiliate = Nothing
    '            End With

    '            db.TblMembers.InsertOnSubmit(newMember)
    '            db.SubmitChanges()
    '        End Using
    '    Catch ex As Exception
    '        Log(ex)
    '        Return False
    '    End Try
    '    Return True
    'End Function

    Private Sub langEn_ServerClick(sender As Object, e As EventArgs) Handles langEn.ServerClick
        Dim language As String = "en-US"

        Response.Cookies("Lang").Value = language

        Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)

        Response.Redirect(Request.RawUrl.ToString())
    End Sub

    Private Sub langZh_ServerClick(sender As Object, e As EventArgs) Handles langZh.ServerClick
        Dim language As String = "zh-CN"

        Response.Cookies("Lang").Value = language

        Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)

        Response.Redirect(Request.RawUrl.ToString())
    End Sub

    Private Sub langMy_ServerClick(sender As Object, e As EventArgs) Handles langMy.ServerClick
        Dim language As String = "my-MY"

        Response.Cookies("Lang").Value = language

        Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)

        Response.Redirect(Request.RawUrl.ToString())
    End Sub

    Private Function GenerateContact(faicon As String, href As String, title As String) As HtmlGenericControl
        Return New HtmlGenericControl("li") With {.InnerHtml = "<i class=""" & faicon & """></i><a href=""" & href & """ target=""_blank"">" & title & "</a>"}
    End Function
End Class

