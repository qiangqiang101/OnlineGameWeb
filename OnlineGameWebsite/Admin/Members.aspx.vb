
Partial Class Admin_Members
    Inherits System.Web.UI.Page

    Private Sub Admin_Members_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim members = (From m In db.TblMembers Order By m.UserID Descending)
            For Each m As TblMember In members
                dataTable.AddTableItem(m.UserID.ToString("00000"), m.DateCreated.ToString(dateFormat), m.UserName.Trim, m.FullName.Trim, m.PhoneNo.Trim, m.Email.Trim,
                                      RB("EditMember.aspx?mode=view&id=" & m.UserID, "fas fa-eye", "btn-success", "View") & RB("EditMember.aspx?mode=edit&id=" & m.UserID, "fas fa-edit", tooltip:="Edit"))
            Next
        End Using
    End Sub

End Class
