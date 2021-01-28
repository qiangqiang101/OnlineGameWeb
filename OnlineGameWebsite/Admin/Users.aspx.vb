
Partial Class Admin_Users
    Inherits System.Web.UI.Page

    Private Sub Admin_Users_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim users = db.TblUsers.OrderByDescending(Function(x) x.UserID)
            For Each u As TblUser In users
                dataTable.AddTableItem(u.UserID.ToString("00000"), u.UserName.Trim, u.FullName.Trim, u.DateCreated.ToString(dateFormat), UserRoleToString(u.UserRole), BoolStatusToString(u.Status), u.LastLoginDate.ToString(dateFormat), u.LastLoginIP.Trim,
                                       RB("EditUser.aspx?mode=edit&id=" & u.UserID, "fas fa-edit", tooltip:="Edit") & RB("EditUser.aspx?mode=delete&id=" & u.UserID, "fas fa-trash", "btn-danger", "Delete"))
            Next
        End Using
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Response.Redirect("EditUser.aspx?mode=new&id=-1")
    End Sub

End Class
