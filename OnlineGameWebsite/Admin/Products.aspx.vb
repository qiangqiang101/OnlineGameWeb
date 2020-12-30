
Partial Class Admin_Products
    Inherits System.Web.UI.Page

    Private Sub Admin_Products_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim products = db.TblProducts.OrderByDescending(Function(x) x.ProductID) '(From p In db.TblProducts Order By p.ProductID Descending)
        For Each p As TblProduct In db.TblProducts
            Dim hasImage As Boolean = p.ProductImage <> Nothing
            dataTable.AddTableItem(p.ProductID.ToString("00000"), If(hasImage, Img("..\" & p.ProductImage.Trim, p.ProductName.Trim), ""), p.ProductName.Trim, p.ProductAlias.Trim,
                                   p.Balance.ToString("0.00"), ProductCategoryToString(p.ProductCategory), p.Status,
                                   RB("EditProduct.aspx?id=" & p.ProductID, "fas fa-edit"))
        Next
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Response.Redirect("AddProduct.aspx")
    End Sub
End Class
