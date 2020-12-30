
Partial Class Admin_Members
    Inherits System.Web.UI.Page

    Private Sub Admin_Members_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim members = (From m In db.TblMembers Order By m.UserID Descending)
        For Each m As TblMember In members
            dataTable.AddTableItem(m.UserID.ToString("00000"), m.DateCreated.ToString(dateFormat), m.UserName.Trim, m.FullName.Trim, m.PhoneNo.Trim, m.Email.Trim,
                                   RB("EditMember.aspx?id=" & m.UserID, "fas fa-edit"))
        Next
    End Sub

End Class
