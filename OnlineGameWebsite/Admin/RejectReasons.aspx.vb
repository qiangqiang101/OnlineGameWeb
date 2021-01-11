
Partial Class Admin_RejectReasons
    Inherits System.Web.UI.Page

    Private Sub Admin_RejectReasons_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim rr = db.TblTRejectReasons.OrderByDescending(Function(x) x.TrrID)
        For Each r As TblTRejectReason In rr
            dataTable.AddTableItem(r.TrrID.ToString("00000"), r.TrReason.Trim, r.Status.ToString, RB("EditRejectReason.aspx?mode=edit&id=" & r.TrrID, "fas fa-edit"))
        Next
    End Sub

    Private Sub btnAddRR_Click(sender As Object, e As EventArgs) Handles btnAddRR.Click
        Response.Redirect("EditRejectReason.aspx?mode=new&id=-1")
    End Sub

End Class
