﻿
Partial Class Admin_Products
    Inherits System.Web.UI.Page

    Private Sub Admin_Products_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim products = db.TblProducts.OrderByDescending(Function(x) x.ProductID)
        For Each p As TblProduct In products
            Dim hasImage As Boolean = p.ProductImage <> Nothing
            dataTable.AddTableItem(p.ProductID.ToString("00000"), If(hasImage, Img("..\" & p.ProductImage.Trim, p.ProductName.Trim), ""), p.ProductName.Trim, p.ProductAlias.Trim,
                                   p.Balance.ToString("0.00"), ProductCategoryToString(p.ProductCategory), p.Status,
                                   RB("EditProduct.aspx?mode=edit&id=" & p.ProductID, "fas fa-edit", tooltip:="Edit") & RB("EditProduct.aspx?mode=delete&id=" & p.ProductID, "fas fa-trash", "btn-danger", "Delete") &
                                   RB("EditProduct.aspx?mode=duplicate&id=" & p.ProductID, "fas fa-clone", "btn-info", "Duplicate"))
        Next
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Response.Redirect("EditProduct.aspx?mode=new&id=-1")
    End Sub
End Class
