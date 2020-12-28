
Partial Class Admin_Members
    Inherits System.Web.UI.Page

    Private Sub Admin_Members_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadMembers()
    End Sub

    Private Sub LoadMembers()
        Dim members = (From m In db.TblMembers Order By m.UserID Descending)
        For Each m As TblMember In members
            Dim row As New TableRow()
            row.Cells.Add(New TableCell() With {.Text = m.UserID.ToString("00000")})
            row.Cells.Add(New TableCell() With {.Text = m.DateCreated.ToString(dateFormat)})
            row.Cells.Add(New TableCell() With {.Text = m.UserName.Trim})
            row.Cells.Add(New TableCell() With {.Text = m.FullName.Trim})
            row.Cells.Add(New TableCell() With {.Text = m.PhoneNo.Trim})
            row.Cells.Add(New TableCell() With {.Text = m.Email.Trim})
            row.Cells.Add(New TableCell() With {.Text = RoundButton("EditMember.aspx?id=" & m.UserID, "fas fa-edit") & RoundButton("DeleteMember.aspx?id=" & m.UserID, "fas fa-trash", "btn-danger")})
            dataTable.Rows.Add(row)
        Next
    End Sub

    Private Function RoundButton(action As String, css As String, Optional button As String = "btn-primary") As String
        Return "<a href=""" & action & """ class=""btn " & button & " btn-circle btn-sm""><i class=""" & css & """></i></a>"
    End Function

End Class
