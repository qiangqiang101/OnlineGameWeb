
Partial Class Admin_Affiliates
    Inherits System.Web.UI.Page

    Private Sub Admin_Affiliates_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim partners = db.TblAffiliates.OrderByDescending(Function(x) x.AffiliateID)
            For Each p As TblAffiliate In partners
                dataTable.AddTableItem(p.AffiliateID.ToString("00000"), p.UserName.Trim, p.FullName.Trim, p.Code.Trim, p.DateCreated.ToString(dateFormat), PartnersCalculation(p.Calculation), (p.Percentage * 100).ToString("N"), BoolStatusToString(p.Status), p.LastLoginDate.ToString(dateFormat), p.LastLoginIP.Trim,
                                       RB("EditAffiliate.aspx?mode=edit&id=" & p.AffiliateID, "fas fa-edit", tooltip:="Edit") & RB("EditAffiliate.aspx?mode=delete&id=" & p.AffiliateID, "fas fa-trash", "btn-danger", "Delete"))
            Next
        End Using
    End Sub

    Private Sub btnAddAffiliate_Click(sender As Object, e As EventArgs) Handles btnAddAffiliate.Click
        Response.Redirect("EditAffiliate.aspx?mode=new&id=-1")
    End Sub
End Class
