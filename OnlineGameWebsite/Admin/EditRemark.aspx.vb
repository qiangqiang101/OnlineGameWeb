
Partial Class Admin_EditRemark
    Inherits System.Web.UI.Page

    Private Sub Admin_EditRemark_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = Request.QueryString("id")

            If id <> Nothing Then
                Try
                    Dim rr = db.TblTransRemarks.Single(Function(x) x.TrID = id)
                    txtName.Text = rr.TRemark.Trim
                    cmbEnabled.SelectedValue = rr.Status
                Catch ex As Exception
                    JsMsgBox("Remark not found!")
                    btnSubmit.Enabled = False
                End Try
            Else
                JsMsgBox("Remark not found!")
                btnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim editRmk = db.TblTransRemarks.Single(Function(x) x.TrID = CInt(Request.QueryString("id")))


        If TryEditRemark() Then
            JsMsgBox("Remark " & editRmk.TRemark & " update successfully.")
            Response.Redirect("Remarks.aspx")
        Else
            JsMsgBox("Remark " & editRmk.TRemark & " edit failed! Please contact Administrator.")
        End If
    End Sub

    Private Function TryEditRemark() As Boolean
        Try
            Dim editRmk = db.TblTransRemarks.Single(Function(x) x.TrID = CInt(Request.QueryString("id")))
            With editRmk
                .TRemark = txtName.Text.Trim
                .Status = CBool(cmbEnabled.SelectedValue)
            End With

            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
