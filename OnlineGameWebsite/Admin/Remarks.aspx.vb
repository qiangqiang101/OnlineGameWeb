
Partial Class Admin_Remarks
    Inherits System.Web.UI.Page

    Private Sub Admin_Remarks_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim rr = db.TblTransRemarks.OrderByDescending(Function(x) x.TrID)
        For Each r As TblTransRemark In rr
            dataTable.AddTableItem(r.TrID.ToString("00000"), r.TRemark.Trim, BoolStatusToString(r.Status), RB("EditRemark.aspx?mode=edit&id=" & r.TrID, "fas fa-edit") &
                                   RB("EditRemark.aspx?mode=delete&id=" & r.TrID, "fas fa-trash", "btn-danger", "Delete") &
                                   RB("EditRemark.aspx?mode=duplicate&id=" & r.TrID, "fas fa-clone", "btn-info", "Duplicate"))
        Next
    End Sub

    Private Sub btnAddRemark_Click(sender As Object, e As EventArgs) Handles btnAddRemark.Click
        Response.Redirect("EditRemark.aspx?mode=new&id=-1")
    End Sub
End Class
