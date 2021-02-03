
Partial Class Product
    Inherits BasePage

    Public pid As String = "-1"

    Private Sub Product_Load(sender As Object, e As EventArgs) Handles Me.Load
        pid = Request.QueryString("id")

        If Not IsPostBack Then
            Try
                Using db As New DataClassesDataContext
                    Dim product = db.TblProducts.Single(Function(x) x.ProductID = pid And x.ProductImage <> Nothing)
                    Dim pdtName As String = Nothing
                    If String.IsNullOrWhiteSpace(product.ProductAlias) Then pdtName = product.ProductName Else pdtName = product.ProductAlias
                    pdtTitleH1.InnerText = pdtName.ToUpper
                    pdtTitleH3.InnerText = pdtName.ToUpper
                    pdtTitle.InnerText = pdtName

                    imgURL.Attributes("href") = product.ProductImage.Trim
                    imgURL2.Attributes("src") = product.ProductImage.Trim

                    If String.IsNullOrWhiteSpace(product.AndroidLink) Then divAndroid.Visible = False Else btnAndroid.Attributes("href") = product.AndroidLink : btnAndroid.InnerHtml = Resources.Resource.AndroidDownload & "<i class=""fa fa-android""></i>"
                    If String.IsNullOrWhiteSpace(product.iOSLink) Then divApple.Visible = False Else btnApple.Attributes("href") = product.iOSLink : btnApple.InnerHtml = Resources.Resource.iOSDownload & "<i class=""fa fa-apple""></i>"
                    If String.IsNullOrWhiteSpace(product.WindowsLink) Then divWindows.Visible = False Else btnWindows.Attributes("href") = product.WindowsLink : btnWindows.InnerHtml = Resources.Resource.WindowsDownload & "<i class=""fa fa-windows""></i>"
                    If String.IsNullOrWhiteSpace(product.WebsiteUrl) Then divWebsite.Visible = False Else btnWebsite.Attributes("href") = product.WebsiteUrl : btnWebsite.InnerHtml = Resources.Resource.VisitWebsite & "<i class=""fa fa-html5""></i>"

                    Dim role As String = HttpContext.Current.Session("role")
                    If role = "user" Then
                        Try
                            Dim user = db.TblUsers.Single(Function(x) x.UserName = Session("username") And x.UserID = Session("userid"))
                            Dim uproduct = db.TblGameAccounts.Single(Function(x) x.MemberUserName.Trim = user.UserName.Trim)
                            username.InnerText = "User Name: " & uproduct.UserName.Trim
                            password.InnerText = "Password: " & uproduct.Password.Trim
                        Catch ex As Exception
                            Log(ex)
                            divUsername.Visible = False
                            divPassword.Visible = False
                        End Try
                    Else
                        divUsername.Visible = False
                        divPassword.Visible = False
                    End If
                End Using
            Catch ex As Exception
                Log(ex)
                Response.Redirect("404.aspx")
            End Try
        End If
    End Sub



End Class
