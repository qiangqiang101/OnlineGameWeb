
Partial Class Admin_AddRemark
    Inherits System.Web.UI.Page

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If AddNewRemark() Then
            JsMsgBox("Remark added successfully.")
            Response.Redirect("Remarks.aspx")
        Else
            JsMsgBox("Add remark failed! Please contact Administrator.")
        End If
    End Sub

    Private Function AddNewRemark() As Boolean
        Dim newRemark As New TblTransRemark
        With newRemark
            .TRemark = txtName.Text.Trim
            .Status = CBool(cmbEnabled.SelectedValue)
        End With

        Try
            db.TblTransRemarks.InsertOnSubmit(newRemark)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
