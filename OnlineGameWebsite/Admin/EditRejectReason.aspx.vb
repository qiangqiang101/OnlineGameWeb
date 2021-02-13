
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
                        Using db As New DataClassesDataContext
                            Dim rr = db.TblTRejectReasons.Single(Function(x) x.TrrID = rrid)
                            txtName.Text = rr.TrReason.Trim
                            cmbEnabled.SelectedValue = rr.Status
                            h6.InnerText = "Edit " & rr.TrrID.ToString("00000")
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Reject Reason ID does not exist.", "error")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Using db As New DataClassesDataContext
                            Dim rr = db.TblTRejectReasons.Single(Function(x) x.TrrID = rrid)
                            txtName.Text = rr.TrReason.Trim
                            cmbEnabled.SelectedValue = rr.Status

                            txtName.ReadOnly = True
                            cmbEnabled.Enabled = False

                            h6.InnerText = "Are you sure you want to delete " & rr.TrReason & " (" & rr.TrrID.ToString("00000") & ")?"
                            btnSubmit.Text = "Delete"
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Reject Reason ID does not exist.", "error")
                        btnSubmit.Enabled = False
                    End Try
                Case "duplicate"
                    h6.InnerText = "Add New Reject Reason"
                    btnSubmit.Text = "Insert"

                    Try
                        Using db As New DataClassesDataContext
                            Dim rr = db.TblTRejectReasons.Single(Function(x) x.TrrID = rrid)
                            txtName.Text = "Copy of " & rr.TrReason.Trim
                            cmbEnabled.SelectedValue = rr.Status
                        End Using

                        If AddNewRR() Then
                            swalBsRedirect("RejectReasons.aspx", "Success", "This reject reason is successfully added.", "success")
                        Else
                            swalBs("Oops!", "This Reject reason is failed to add! Please contact Adminstrator.", "error")
                        End If
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Reject Reason ID does not exist.", "error")
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
                Using db As New DataClassesDataContext
                    If TryEditRR() Then
                        swalBsRedirect("RejectReasons.aspx", "Success", "This reject reason is successfully update.", "success")
                    Else
                        swalBs("Oops!", "This Reject reason is failed to edit! Please contact Adminstrator.", "error")
                    End If
                End Using
            Case "delete"
                Try
                    Using db As New DataClassesDataContext
                        Dim rrToDelete = db.TblTRejectReasons.Single(Function(x) x.TrrID = CInt(rrid))
                        db.TblTRejectReasons.DeleteOnSubmit(rrToDelete)
                        db.SubmitChanges()
                    End Using

                    swalBsRedirect("RejectReasons.aspx", "Success", "This reject reason is successfully delete.", "success")
                Catch ex As Exception
                    Log(ex)
                    swalBs("Oops!", "This Reject reason is failed to delete! Please contact Adminstrator.", "error")
                End Try
            Case Else
                If AddNewRR() Then
                    swalBsRedirect("RejectReasons.aspx", "Success", "This reject reason is successfully added.", "success")
                Else
                    swalBs("Oops!", "Failed to add Reject Reason! Please contact Adminstrator.", "error")
                End If
        End Select
    End Sub

    Private Function TryEditRR() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editRR = db.TblTRejectReasons.Single(Function(x) x.TrrID = CInt(rrid))
                With editRR
                    .TrReason = txtName.Text.Trim
                    .Status = CBool(cmbEnabled.SelectedValue)
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

    Private Function AddNewRR() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newRR As New TblTRejectReason
                With newRR
                    .TrReason = txtName.Text.Trim
                    .Status = CBool(cmbEnabled.SelectedValue)
                End With

                db.TblTRejectReasons.InsertOnSubmit(newRR)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

End Class
