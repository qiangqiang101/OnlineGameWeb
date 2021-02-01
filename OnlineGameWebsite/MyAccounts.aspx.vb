
Partial Class MyAccounts
    Inherits System.Web.UI.Page

    Public qsSwal As String = ""

    Private Sub MyAccounts_Load(sender As Object, e As EventArgs) Handles Me.Load
        qsSwal = Request.QueryString("swal")
        If qsSwal <> "" Then
            swal(qsSwal)
        End If

        Dim role As String = HttpContext.Current.Session("role")

        If role <> "user" Then
            LoginMsgBox
        Else
            Using db As New DataClassesDataContext
                Dim products = db.TblProducts.Where(Function(x) x.Status = True).ToList
                For Each product As TblProduct In products
                    Dim accounts = db.TblGameAccounts.Where(Function(x) x.MemberUserName = Session("username").ToString.Trim And x.ProductID = product.ProductID).ToList
                    Dim username As String = "-"
                    Dim password As String = "-"
                    If accounts.Count <> 0 Then
                        Dim account = accounts.Single
                        username = account.UserName.Trim
                        password = account.Password.Trim
                    End If
                    Dim request As String = String.Empty
                    If accounts.Count = 0 Then
                        request = "<a href=""Action.aspx?mode=account&redirect=account&id=" & product.ProductID & "&mid=" & Session("userid").ToString.Trim & """><i class=""fas fa-hand-paper"" data-toggle=""tooltip"" title=""Get ID"">&nbsp</i>Get ID</a>"
                    End If

                    Dim pdtName As String = If(String.IsNullOrWhiteSpace(product.ProductAlias), product.ProductName.Trim, product.ProductAlias.Trim)
                    Dim image As String = "<img src=""" & product.ProductImage.Trim & """ class=""img-responsive"" alt=""" & pdtName & """ />"
                    Dim download As String = "<a href=""Product.aspx?id=" & product.ProductID & """><i class=""fas fa-download"" data-toggle=""tooltip"" title=""Download"">&nbsp</i>Download</a> "

                    table.AddTableItem(image, pdtName, GenerateCategoryString(product.CatSlot, product.CatLive, product.CatSport, product.CatRNG, product.CatFish, product.CatPoker, product.CatOther), username, password, download & request)
                Next
            End Using
        End If
    End Sub
End Class
