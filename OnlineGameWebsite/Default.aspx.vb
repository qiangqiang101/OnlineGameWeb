Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sliders = db.TblSliders.Where(Function(x) x.Status = True And x.SliderImage <> Nothing).OrderByDescending(Function(x) x.DisplayIndex And x.SliderID).Take(9).ToList
        For Each slider As TblSlider In sliders
            masterslider.Controls.Add(LoadSliders(slider.SliderImage, slider.SliderName))
        Next

        Dim products = db.TblProducts.Where(Function(x) x.Status = True And x.ProductImage <> Nothing).ToList
        For Each product As TblProduct In products
            productslider.Controls.Add(LoadProductSliders(product.ProductImage))
        Next
    End Sub

    Private Function LoadSliders(image As String, name As String) As HtmlGenericControl
        Dim img = New HtmlGenericControl("img")
        With img
            .Attributes("src") = "Plugins/masterslider/style/blank.gif"
            .Attributes("data-src") = image.Trim
            .Attributes("alt") = name.Trim
        End With
        Dim div = New HtmlGenericControl("div")
        With div
            .Attributes("class") = "ms-slide slide-1"
            .Controls.Add(img)
        End With
        Return div
    End Function

    Private Function LoadProductSliders(image As String) As HtmlGenericControl
        Dim img = New HtmlGenericControl("img")
        With img
            .Attributes("src") = image.Trim
            '.Attributes("style") = "height: 75px;"
        End With
        Dim div = New HtmlGenericControl("div")
        With div
            .Attributes("class") = "item"
            .Controls.Add(img)
        End With
        Return div
    End Function

End Class
