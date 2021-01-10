
Partial Class Admin_Remarks
    Inherits System.Web.UI.Page

    Private Sub Admin_Remarks_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim rr = db.TblTransRemarks.OrderByDescending(Function(x) x.TrID)
        For Each r As TblTransRemark In rr
            dataTable.AddTableItem(r.TrID.ToString("00000"), r.TRemark.Trim, r.Status.ToString, RB("EditRemark.aspx?id=" & r.TrID, "fas fa-edit"))
        Next
    End Sub

    Private Sub btnAddRemark_Click(sender As Object, e As EventArgs) Handles btnAddRemark.Click
        Response.Redirect("AddRemark.aspx")
    End Sub
End Class
