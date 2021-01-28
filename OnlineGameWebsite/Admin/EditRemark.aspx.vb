
Partial Class Admin_EditRemark
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public rid As String = 0

    Private Sub Admin_EditRemark_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        rid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Using db As New DataClassesDataContext
                            Dim rr = db.TblTransRemarks.Single(Function(x) x.TrID = rid)
                            txtName.Text = rr.TRemark.Trim
                            cmbEnabled.SelectedValue = rr.Status
                            h6.InnerText = "Edit " & rr.TrID.ToString("00000")
                        End Using
                    Catch ex As Exception
                        JsMsgBox("Remark not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Using db As New DataClassesDataContext
                            Dim rr = db.TblTransRemarks.Single(Function(x) x.TrID = rid)
                        txtName.Text = rr.TRemark.Trim
                        cmbEnabled.SelectedValue = rr.Status

                        txtName.ReadOnly = True
                        cmbEnabled.Enabled = False

                        h6.InnerText = "Are you sure you want to delete " & rr.TRemark & " (" & rr.TrID.ToString("00000") & ")?"
                            btnSubmit.Text = "Delete"
                        End Using
                    Catch ex As Exception
                        JsMsgBox("Remark not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "duplicate"
                    h6.InnerText = "Add New Remark"
                    btnSubmit.Text = "Insert"

                    Try
                        Using db As New DataClassesDataContext
                            Dim rr = db.TblTransRemarks.Single(Function(x) x.TrID = rid)
                            txtName.Text = "Copy of " & rr.TRemark.Trim
                            cmbEnabled.SelectedValue = rr.Status

                            If AddNewRemark() Then
                                JsMsgBox("Remark added successfully.")
                                Response.Redirect("Remarks.aspx")
                            Else
                                JsMsgBox("Add remark failed! Please contact Administrator.")
                            End If
                        End Using
                    Catch ex As Exception
                        JsMsgBox("Remark not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case Else
                    h6.InnerText = "Add New Remark"
                    btnSubmit.Text = "Insert"
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                Using db As New DataClassesDataContext
                    Dim editRmk = db.TblTransRemarks.Single(Function(x) x.TrID = CInt(rid))

                    If TryEditRemark() Then
                        JsMsgBox("Remark " & editRmk.TRemark & " update successfully.")
                        Response.Redirect("Remarks.aspx")
                    Else
                        JsMsgBox("Remark " & editRmk.TRemark & " edit failed! Please contact Administrator.")
                    End If
                End Using
            Case "delete"
                Try
                    Using db As New DataClassesDataContext
                        Dim remarkToDelete = db.TblTransRemarks.Single(Function(x) x.TrID = CInt(rid))
                        db.TblTransRemarks.DeleteOnSubmit(remarkToDelete)
                        db.SubmitChanges()
                    End Using

                    JsMsgBox("Remark delete successfully.")
                    Response.Redirect("Remarks.aspx")
                Catch ex As Exception
                    JsMsgBox("Delete remark failed! Please contact Administrator.")
                End Try
            Case Else
                If AddNewRemark() Then
                    JsMsgBox("Remark added successfully.")
                    Response.Redirect("Remarks.aspx")
                Else
                    JsMsgBox("Add remark failed! Please contact Administrator.")
                End If
        End Select
    End Sub

    Private Function TryEditRemark() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editRmk = db.TblTransRemarks.Single(Function(x) x.TrID = CInt(rid))
                With editRmk
                    .TRemark = txtName.Text.Trim
                    .Status = CBool(cmbEnabled.SelectedValue)
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function AddNewRemark() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newRemark As New TblTransRemark
                With newRemark
                    .TRemark = txtName.Text.Trim
                    .Status = CBool(cmbEnabled.SelectedValue)
                End With

                db.TblTransRemarks.InsertOnSubmit(newRemark)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
