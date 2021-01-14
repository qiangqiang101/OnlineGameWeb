
Partial Class Admin_IpTool
    Inherits System.Web.UI.Page

    Private Sub Admin_IpTool_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim logs = db.TblLogs.OrderByDescending(Function(x) x.LogID)
        For Each l As TblLog In logs
            dataTable.AddTableItem(l.LogID.ToString("000000"), l.LogMember.Trim, l.LogDate.ToString(dateFormat), LogTypeToString(l.LogType), l.LogIP.Trim, RB("EditMember.aspx?mode=view&id=" & l.LogMember.Trim, "fas fa-eye", "btn-success", "View"))
        Next
    End Sub
End Class
