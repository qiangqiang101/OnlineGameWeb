
Partial Class Admin_AddRejectReason
    Inherits System.Web.UI.Page

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If AddNewRR() Then
            JsMsgBox("Reject reason added successfully.")
            Response.Redirect("RejectReasons.aspx")
        Else
            JsMsgBox("Add reject reason failed! Please contact Administrator.")
        End If
    End Sub

    Private Function AddNewRR() As Boolean
        Dim newRR As New TblTRejectReason
        With newRR
            .TrReason = txtName.Text.Trim
            .Status = CBool(cmbEnabled.SelectedValue)
        End With

        Try
            db.TblTRejectReasons.InsertOnSubmit(newRR)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
