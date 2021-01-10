
Partial Class Admin_EditRejectReason
    Inherits System.Web.UI.Page

    Private Sub Admin_EditRejectReason_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = Request.QueryString("id")

            If id <> Nothing Then
                Try
                    Dim rr = db.TblTRejectReasons.Single(Function(x) x.TrrID = id)
                    txtName.Text = rr.TrReason.Trim
                    cmbEnabled.SelectedValue = rr.Status
                Catch ex As Exception
                    JsMsgBox("Reject reason not found!")
                    btnSubmit.Enabled = False
                End Try
            Else
                JsMsgBox("Reject reason not found!")
                btnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim editRR = db.TblTRejectReasons.Single(Function(x) x.TrrID = CInt(Request.QueryString("id")))

        If TryEditRR() Then
            JsMsgBox("Reject reason " & editRR.TrReason & " update successfully.")
            Response.Redirect("RejectReasons.aspx")
        Else
            JsMsgBox("Reject reason " & editRR.TrReason & " edit failed! Please contact Administrator.")
        End If
    End Sub

    Private Function TryEditRR() As Boolean
        Try
            Dim editRR = db.TblTRejectReasons.Single(Function(x) x.TrrID = CInt(Request.QueryString("id")))
            With editRR
                .TrReason = txtName.Text.Trim
                .Status = CBool(cmbEnabled.SelectedValue)
            End With

            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
