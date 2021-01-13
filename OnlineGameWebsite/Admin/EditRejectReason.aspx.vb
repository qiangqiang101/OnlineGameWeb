
Partial Class Admin_EditRejectReason
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public rrid As String = 0

    Private Sub Admin_EditRejectReason_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        rrid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Dim rr = db.TblTRejectReasons.Single(Function(x) x.TrrID = rrid)
                        txtName.Text = rr.TrReason.Trim
                        cmbEnabled.SelectedValue = rr.Status
                        h6.InnerText = "Edit " & rr.TrrID.ToString("00000")
                    Catch ex As Exception
                        JsMsgBox("Reject reason not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Dim rr = db.TblTRejectReasons.Single(Function(x) x.TrrID = rrid)
                        txtName.Text = rr.TrReason.Trim
                        cmbEnabled.SelectedValue = rr.Status

                        txtName.ReadOnly = True
                        cmbEnabled.Enabled = False

                        h6.InnerText = "Are you sure you want to delete " & rr.TrReason & " (" & rr.TrrID.ToString("00000") & ")?"
                        btnSubmit.Text = "Delete"
                    Catch ex As Exception
                        JsMsgBox("Reject reason not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "duplicate"
                    h6.InnerText = "Add New Reject Reason"
                    btnSubmit.Text = "Insert"

                    Try
                        Dim rr = db.TblTRejectReasons.Single(Function(x) x.TrrID = rrid)
                        txtName.Text = "Copy of " & rr.TrReason.Trim
                        cmbEnabled.SelectedValue = rr.Status

                        If AddNewRR() Then
                            JsMsgBox("Reject reason added successfully.")
                            Response.Redirect("RejectReasons.aspx")
                        Else
                            JsMsgBox("Add reject reason failed! Please contact Administrator.")
                        End If
                    Catch ex As Exception
                        JsMsgBox("Reject reason not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case Else
                    h6.InnerText = "Add New Reject Reason"
                    btnSubmit.Text = "Insert"
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                Dim editRR = db.TblTRejectReasons.Single(Function(x) x.TrrID = CInt(rrid))

                If TryEditRR() Then
                    JsMsgBox("Reject reason " & editRR.TrReason & " update successfully.")
                    Response.Redirect("RejectReasons.aspx")
                Else
                    JsMsgBox("Reject reason " & editRR.TrReason & " edit failed! Please contact Administrator.")
                End If
            Case "delete"
                Try
                    Dim rrToDelete = db.TblTRejectReasons.Single(Function(x) x.TrrID = CInt(rrid))
                    db.TblTRejectReasons.DeleteOnSubmit(rrToDelete)
                    db.SubmitChanges()

                    JsMsgBox("Reject Reason delete successfully.")
                    Response.Redirect("RejectReasons.aspx")
                Catch ex As Exception
                    JsMsgBox("Delete reject reason failed! Please contact Administrator.")
                End Try
            Case Else
                If AddNewRR() Then
                    JsMsgBox("Reject reason added successfully.")
                    Response.Redirect("RejectReasons.aspx")
                Else
                    JsMsgBox("Add reject reason failed! Please contact Administrator.")
                End If
        End Select
    End Sub

    Private Function TryEditRR() As Boolean
        Try
            Dim editRR = db.TblTRejectReasons.Single(Function(x) x.TrrID = CInt(rrid))
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
