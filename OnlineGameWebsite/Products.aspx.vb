
Partial Class _Products
    Inherits BasePage

    Public cat As String = "all"

    Private Sub _Products_Load(sender As Object, e As EventArgs) Handles Me.Load
        cat = Request.QueryString("cat")

        If Not IsPostBack Then
            Dim products As List(Of TblProduct)
            Dim contacts As List(Of TblContact)
            Using db As New DataClassesDataContext
                products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing).ToList
                contacts = db.TblContacts.Where(Function(x) x.Status = True And x.ShowProductPage = True).ToList
            End Using

            pdtPageContact.Controls.Add(New HtmlGenericControl("li") With {.InnerHtml = Resources.Resource.HowCanWeHelpYou})
            For Each c In contacts
                pdtPageContact.Controls.Add(GenerateContact(c.FaIcon, c.Website, c.ContactTitle))
            Next

            Select Case cat
                Case "slot"
                    headerBgImg.Attributes("class") = "header-page inm_slot"
                    catTitleH1.InnerText = Resources.Resource.SlotGameMenu
                    catTitle.InnerText = Resources.Resource.SlotGame
                    catSlot.Attributes("class") = "active"

                    Dim slots = products.Where(Function(x) x.CatSlot = True).ToList
                    For Each product As TblProduct In slots
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                        productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                    Next
                Case "live"
                    headerBgImg.Attributes("class") = "header-page inm_live"
                    catTitleH1.InnerText = Resources.Resource.LiveCasinoMenu
                    catTitle.InnerText = Resources.Resource.LiveCasino
                    catLive.Attributes("class") = "active"

                    Dim lives = products.Where(Function(x) x.CatLive = True).ToList
                    For Each product As TblProduct In lives
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                        productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                    Next
                Case "sport"
                    headerBgImg.Attributes("class") = "header-page inm_sport"
                    catTitleH1.InnerText = Resources.Resource.SportsbookMenu
                    catTitle.InnerText = Resources.Resource.Sportsbook
                    catSport.Attributes("class") = "active"

                    Dim sports = products.Where(Function(x) x.CatSport = True).ToList
                    For Each product As TblProduct In sports
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                        productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                    Next
                Case "rng"
                    headerBgImg.Attributes("class") = "header-page inm_rng"
                    catTitleH1.InnerText = Resources.Resource.RngMenu
                    catTitle.InnerText = Resources.Resource.Rng
                    catRNG.Attributes("class") = "active"

                    Dim rngs = products.Where(Function(x) x.CatRNG = True).ToList
                    For Each product As TblProduct In rngs
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                        productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                    Next
                Case "fish"
                    headerBgImg.Attributes("class") = "header-page inm_fish"
                    catTitleH1.InnerText = Resources.Resource.FishHunterMenu
                    catTitle.InnerText = Resources.Resource.FishHunter
                    catFish.Attributes("class") = "active"

                    Dim fishes = products.Where(Function(x) x.CatFish = True).ToList
                    For Each product As TblProduct In fishes
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                        productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                    Next
                Case "poker"
                    headerBgImg.Attributes("class") = "header-page inm_poker"
                    catTitleH1.InnerText = Resources.Resource.PokerMenu
                    catTitle.InnerText = Resources.Resource.Poker
                    catPoker.Attributes("class") = "active"

                    Dim pokers = products.Where(Function(x) x.CatPoker = True).ToList
                    For Each product As TblProduct In pokers
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                        productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                    Next
                Case "other"
                    headerBgImg.Attributes("class") = "header-page inm_other"
                    catTitleH1.InnerText = Resources.Resource.OtherMenu
                    catTitle.InnerText = Resources.Resource.Other
                    catOther.Attributes("class") = "active"

                    Dim others = products.Where(Function(x) x.CatOther = True).ToList
                    For Each product As TblProduct In others
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                        productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                    Next
                Case Else 'all
                    catTitleH1.InnerText = Resources.Resource.AllMenu
                    catTitle.InnerText = Resources.Resource.AllProducts
                    catAll.Attributes("class") = "active"

                    For Each product As TblProduct In products
                        Dim pdtName As String = Nothing
                        If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                        productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                    Next
            End Select
        End If

    End Sub

    Private Function GenerateContact(faicon As String, href As String, title As String) As HtmlGenericControl
        Return New HtmlGenericControl("li") With {.InnerHtml = "<a href=""" & href & """ target=""_blank""><i class=""" & faicon & " fa-fw""></i> " & title & " <i class=""fas fa-chevron-right""></i></a>"}
    End Function

    Private Function LoadProductsByCategory(id As String, image As String, title As String, android As String, ios As String, windows As String, website As String) As HtmlGenericControl
        Dim img = New HtmlGenericControl("img")
        With img
            .Attributes("src") = image.Trim
            .Attributes("class") = "img-responsive inm_img_border"
            .Attributes("alt") = title.Trim
        End With

        Dim h4 = New HtmlGenericControl("h4")
        With h4
            .InnerText = title.Trim
        End With
        Dim a = New HtmlGenericControl("a")
        With a
            .Attributes("href") = "Product-" & id.Trim
            .Controls.Add(h4)
        End With
        Dim p = New HtmlGenericControl("p")
        With p
            If Not String.IsNullOrWhiteSpace(android) Then .Controls.Add(GenerateP(eIcon.Android, android))
            If Not String.IsNullOrWhiteSpace(ios) Then .Controls.Add(GenerateP(eIcon.iOS, ios))
            If Not String.IsNullOrWhiteSpace(windows) Then .Controls.Add(GenerateP(eIcon.Window, windows))
            If Not String.IsNullOrWhiteSpace(website) Then .Controls.Add(GenerateP(eIcon.Website, website))
        End With
        Dim more = New HtmlGenericControl("a")
        With more
            .Attributes("href") = "Product-" & id.Trim
            .Attributes("class") = "read"
            .InnerText = Resources.Resource.ReadMoreU
        End With
        Dim innerDiv = New HtmlGenericControl("div")
        With innerDiv
            .Controls.Add(a)
            .Controls.Add(p)
            .Controls.Add(more)
        End With
        Dim mainDiv = New HtmlGenericControl("div")
        With mainDiv
            .Attributes("class") = "col-md-4 item"
            .Controls.Add(img)
            .Controls.Add(innerDiv)
        End With
        Return mainDiv
    End Function

    Private Enum eIcon
        Android
        iOS
        Window
        Website
    End Enum

    Private Function GenerateP(ico As eIcon, url As String) As HtmlGenericControl
        Dim i = New HtmlGenericControl("i")
        With i
            Select Case ico
                Case eIcon.Android
                    .Attributes("class") = "fa fa-android android_link"
                Case eIcon.iOS
                    .Attributes("class") = "fa fa-apple ios_link"
                Case eIcon.Website
                    .Attributes("class") = "fa fa-html5 website_link"
                Case eIcon.Window
                    .Attributes("class") = "fa fa-windows windows_link"
            End Select
            .InnerHtml = "&nbsp"
        End With
        Dim a = New HtmlGenericControl("a")
        With a
            .Attributes("href") = url.Trim
            .Attributes("target") = "_blank"
            .Controls.Add(i)
        End With
        Return a
    End Function

End Class
