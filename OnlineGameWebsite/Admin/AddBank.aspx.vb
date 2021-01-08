
Partial Class Admin_AddBank
    Inherits System.Web.UI.Page

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If AddNewBank() Then
            JsMsgBox("Bank added successfully.")
            Response.Redirect("Banks.aspx")
        Else
            JsMsgBox("Add bank failed! Please contact Administrator.")
        End If
    End Sub

    Private Function AddNewBank() As Boolean
        Dim newBank As New TblBank
        With newBank
            .BankName = txtBank.Text.Trim
            .AccountName = txtName.Text.Trim
            .AccountNo = txtAccNo.Text.Trim
            .Status = cmbEnabled.SelectedValue
            .BankWeb = txtWebsite.Text.Trim
            .MinCredit = CSng(txtMinCredit.Text.Trim)
            .MaxCredit = CSng(txtMaxCredit.Text.Trim)
            .MinDebit = CSng(txtMinDebit.Text.Trim)
            .MaxDebit = CSng(txtMaxDebit.Text.Trim)
        End With

        Try
            db.TblBanks.InsertOnSubmit(newBank)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
