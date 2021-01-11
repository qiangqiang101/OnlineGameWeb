
Partial Class Admin_EditRemark
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public rid As String = 0

    Private Sub Admin_EditRemark_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mode = Request.QueryString("mode")
            rid = Request.QueryString("id")

            Select Case mode
                Case "edit"
                    If rid <> Nothing Then
                        Try
                            Dim rr = db.TblTransRemarks.Single(Function(x) x.TrID = rid)
                            txtName.Text = rr.TRemark.Trim
                            cmbEnabled.SelectedValue = rr.Status
                            h6.InnerText = "Edit " & rr.TrID.ToString("00000")
                        Catch ex As Exception
                            JsMsgBox("Remark not found!")
                            btnSubmit.Enabled = False
                        End Try
                    Else
                        JsMsgBox("Remark not found!")
                        btnSubmit.Enabled = False
                    End If
                Case "delete"

                Case Else
                    h6.InnerText = "Add New Remark"
                    btnSubmit.Text = "Insert"
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                Dim editRmk = db.TblTransRemarks.Single(Function(x) x.TrID = CInt(rid))

                If TryEditRemark() Then
                    JsMsgBox("Remark " & editRmk.TRemark & " update successfully.")
                    Response.Redirect("Remarks.aspx")
                Else
                    JsMsgBox("Remark " & editRmk.TRemark & " edit failed! Please contact Administrator.")
                End If
            Case "delete"

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
            Dim editRmk = db.TblTransRemarks.Single(Function(x) x.TrID = CInt(rid))
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
