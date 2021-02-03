
Partial Class _Products
    Inherits BasePage

    Public cat As String = "all"

    Private Sub _Products_Load(sender As Object, e As EventArgs) Handles Me.Load
        cat = Request.QueryString("cat")

        If Not IsPostBack Then
            Select Case cat
                Case "slot"
                    headerBgImg.Attributes("class") = "header-page inm_slot"
                    catTitleH1.InnerText = "SLOT GAME"
                    catTitle.InnerText = "Slot Game"
                    catSlot.Attributes("class") = "active"

                    Using db As New DataClassesDataContext
                        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing And x.CatSlot = True).ToList
                        For Each product As TblProduct In products
                            Dim pdtName As String = Nothing
                            If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                            productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                        Next
                    End Using
                Case "live"
                    headerBgImg.Attributes("class") = "header-page inm_live"
                    catTitleH1.InnerText = "LIVE CASINO"
                    catTitle.InnerText = "Live Casino"
                    catLive.Attributes("class") = "active"

                    Using db As New DataClassesDataContext
                        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing And x.CatLive = True).ToList
                        For Each product As TblProduct In products
                            Dim pdtName As String = Nothing
                            If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                            productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                        Next
                    End Using
                Case "sport"
                    headerBgImg.Attributes("class") = "header-page inm_sport"
                    catTitleH1.InnerText = "SPORTSBOOK"
                    catTitle.InnerText = "Sportsbook"
                    catSport.Attributes("class") = "active"

                    Using db As New DataClassesDataContext
                        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing And x.CatSport = True).ToList
                        For Each product As TblProduct In products
                            Dim pdtName As String = Nothing
                            If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                            productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                        Next
                    End Using
                Case "rng"
                    headerBgImg.Attributes("class") = "header-page inm_rng"
                    catTitleH1.InnerText = "RNG"
                    catTitle.InnerText = "RNG"
                    catRNG.Attributes("class") = "active"

                    Using db As New DataClassesDataContext
                        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing And x.CatRNG = True).ToList
                        For Each product As TblProduct In products
                            Dim pdtName As String = Nothing
                            If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                            productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                        Next
                    End Using
                Case "fish"
                    headerBgImg.Attributes("class") = "header-page inm_fish"
                    catTitleH1.InnerText = "FISH HUNTER"
                    catTitle.InnerText = "Fish Hunter"
                    catFish.Attributes("class") = "active"

                    Using db As New DataClassesDataContext
                        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing And x.CatFish = True).ToList
                        For Each product As TblProduct In products
                            Dim pdtName As String = Nothing
                            If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                            productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                        Next
                    End Using
                Case "poker"
                    headerBgImg.Attributes("class") = "header-page inm_poker"
                    catTitleH1.InnerText = "POKER"
                    catTitle.InnerText = "Poker"
                    catPoker.Attributes("class") = "active"

                    Using db As New DataClassesDataContext
                        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing And x.CatPoker = True).ToList
                        For Each product As TblProduct In products
                            Dim pdtName As String = Nothing
                            If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                            productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                        Next
                    End Using
                Case "other"
                    headerBgImg.Attributes("class") = "header-page inm_other"
                    catTitleH1.InnerText = "OTHER"
                    catTitle.InnerText = "Other"
                    catOther.Attributes("class") = "active"

                    Using db As New DataClassesDataContext
                        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing And x.CatOther = True).ToList
                        For Each product As TblProduct In products
                            Dim pdtName As String = Nothing
                            If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                            productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                        Next
                    End Using
                Case Else 'all
                    catTitleH1.InnerText = "ALL PRODUCTS"
                    catTitle.InnerText = "All Products"
                    catAll.Attributes("class") = "active"

                    Using db As New DataClassesDataContext
                        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing).ToList
                        For Each product As TblProduct In products
                            Dim pdtName As String = Nothing
                            If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                            productView.Controls.Add(LoadProductsByCategory(product.ProductID, product.ProductImage, pdtName, product.AndroidLink, product.iOSLink, product.WindowsLink, product.WebsiteUrl))
                        Next
                    End Using
            End Select
        End If

    End Sub

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
            .Attributes("href") = "Product.aspx?id=" & id.Trim
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
            .Attributes("href") = "Product.aspx?id=" & id.Trim
            .Attributes("class") = "read"
            .InnerText = "READ MORE"
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
