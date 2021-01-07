
Partial Class Admin_Promotions
    Inherits System.Web.UI.Page

    Private Sub Admin_Promotions_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim promo = db.TblPromotions.OrderByDescending(Function(x) x.DisplayIndex And x.PromoID)
        For Each p As TblPromotion In promo
            Dim hasImage As Boolean = p.PromoImage <> Nothing
            dataTable.AddTableItem(p.PromoID.ToString("00000"), p.PromoName.Trim, If(hasImage, Img("..\" & p.PromoImage.Trim, p.PromoImage.Trim), ""), p.DisplayIndex,
                                   p.PromoPercent.ToString("0.00"), p.MaxPayout.ToString("0.00"), PromotionTypeToString(p.PromoType), IntStatusToString(p.Status),
                                   RB("EditPromotion.aspx?id=" & p.PromoID, "fas fa-edit"))
        Next
    End Sub

    Private Sub btnAddPromo_Click(sender As Object, e As EventArgs) Handles btnAddPromo.Click
        Response.Redirect("AddPromotion.aspx")
    End Sub
End Class
