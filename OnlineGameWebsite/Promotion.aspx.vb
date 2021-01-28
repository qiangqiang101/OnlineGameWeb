
Partial Class Promotion
    Inherits System.Web.UI.Page

    Private Sub Promotion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim promos = db.TblPromotions.Where(Function(x) x.Status = 1).ToList
            For Each promo As TblPromotion In promos
                Dim data = New PromoData(Server.MapPath(promo.PromoFile)).Instance
                accordion.Controls.Add(LoadPromotions(promo.PromoID, promo.EnglishName, data.English, promo.PromoImage))
            Next
        End Using
    End Sub

    Private Function LoadPromotions(id As String, title As String, text As String, image As String) As HtmlGenericControl
        Dim img = New HtmlGenericControl("img")
        With img
            .Attributes("src") = image.Trim
            .Attributes("alt") = title.Trim
            .Attributes("style") = "width: 100%;"
        End With

        Dim a = New HtmlGenericControl("a")
        With a
            .Attributes("class") = "collapsed"
            .Attributes("role") = "button"
            .Attributes("data-toggle") = "collapse"
            .Attributes("data-parent") = "#accordion"
            .Attributes("href") = "#collapse" & id.Trim
            .Attributes("aria-expanded") = "true"
            .Attributes("aria-controls") = "collapse" & id.Trim
            .Controls.Add(img)
        End With

        Dim tab = New HtmlGenericControl("div")
        With tab
            .Attributes("role") = "tab"
            .Attributes("id") = "heading" & id.Trim
            .Controls.Add(a)
        End With

        Dim p = New HtmlGenericControl("p")
        With p
            .InnerText = text.Trim
        End With

        Dim tncBody = New HtmlGenericControl("div")
        With tncBody
            .Attributes("class") = "panel-body"
            .Controls.Add(p)
        End With

        Dim tnc = New HtmlGenericControl("div")
        With tnc
            .Attributes("id") = "collapse" & id.Trim
            .Attributes("class") = "panel-collapse collapse"
            .Attributes("role") = "tabpanel"
            .Attributes("aria-labelledby") = "heading" & id.Trim
            .Attributes("aria-expanded") = "false"
            .Controls.Add(tncBody)
        End With

        Dim mainDiv = New HtmlGenericControl("div")
        With mainDiv
            .Attributes("class") = "panel panel-default"
            .Controls.Add(tab)
            .Controls.Add(tnc)
        End With
        Return mainDiv
    End Function
End Class
