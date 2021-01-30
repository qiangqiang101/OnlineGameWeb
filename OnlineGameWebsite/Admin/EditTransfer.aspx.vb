
Partial Class Admin_EditTransfer
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public tid As String = 0

    Private Sub Admin_EditTransfer_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        tid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Pending(CInt(tid), ePending.Transfer)

                        Using db As New DataClassesDataContext
                            Dim rejects = db.TblTRejectReasons.Where(Function(x) x.Status = True).ToList
                            cmbRejectReason.Items.Add(New ListItem("", ""))
                            For Each reason As TblTRejectReason In rejects
                                cmbRejectReason.Items.Add(New ListItem(reason.TrReason.Trim, reason.TrReason.Trim))
                            Next

                            Dim t = db.TblTransfers.Single(Function(x) x.TransferID = CInt(tid))
                            Dim pf = db.TblProducts.Single(Function(x) x.ProductID = t.FromProductID)
                            Dim pt = db.TblProducts.Single(Function(x) x.ProductID = t.ToProductID)
                            Dim m = db.TblMembers.Single(Function(x) x.UserName = t.UserName)

                            h6Title.InnerText = "Transfer " & t.TransferID.ToString("00000")
                            lblID.InnerText = t.TransferID.ToString("00000")
                            lblFromProduct.InnerText = pf.ProductName.Trim
                            lblFromUsername.InnerText = t.FromUserName.Trim
                            lblToProduct.InnerText = pt.ProductName.Trim
                            lblToUsername.InnerText = t.ToUserName.Trim
                            lblUserID.InnerText = t.UserName.Trim
                            lblFullName.InnerText = m.FullName.Trim
                            lblIpAddress.InnerText = t.IPAddress.Trim
                            lblTime.InnerText = t.TransferDate.ToString(dateFormat)
                            lblAmount.InnerText = t.Amount.ToString("N")
                            lblAffiliate.InnerText = If(m.Affiliate = Nothing, "-", m.Affiliate.Trim)
                            lblStatus.InnerText = StatusToString(t.Status)
                            If t.Status <= 1 Then
                                btnApprove.Visible = True
                                btnReject.Visible = True
                            Else
                                btnApprove.Visible = False
                                btnReject.Visible = False
                            End If
                            If Not t.Reason = Nothing Then cmbRejectReason.SelectedValue = t.Reason.Trim
                            If Not t.Remark = Nothing Then txtRemarks.Text = t.Remark.Trim
                            If t.ApproveByUser.Trim <> "None" Then
                                txtConfirmUser.Text = t.ApproveByUser.Trim
                                txtConfirmDate.Text = t.ApproveDate.ToString(dateFormat)
                            End If
                        End Using
                    Catch ex As Exception
                        JsMsgBox("Transfer not found!")
                        Log(ex)
                        btnApprove.Enabled = False
                        btnReject.Enabled = False
                        Exit Sub
                    End Try
                Case "approve"
                    If TryApproveTransfer() Then
                        Response.Redirect("Transfer.aspx")
                    Else
                        JsMsgBoxRedirect("Transfer failed to Approve! Please contact Administrator.", Request.RawUrl.ToString())
                    End If
                Case "reject"
                    If TryRejectTransfer() Then
                        Response.Redirect("Transfer.aspx")
                    Else
                        JsMsgBoxRedirect("Transfer failed to Reject! Please contact Administrator.", Request.RawUrl.ToString())
                    End If
            End Select
        End If
    End Sub

    Private Function TryRejectTransfer() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editTransfer = db.TblTransfers.Single(Function(x) x.TransferID = CInt(tid))
                With editTransfer
                    .Reason = cmbRejectReason.SelectedValue.Trim
                    .Remark = txtRemarks.Text.Trim
                    .Status = 3
                    .ApproveByUser = Session("username").ToString.Trim
                    .ApproveDate = Now
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

    Private Function TryApproveTransfer() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editTransfer = db.TblTransfers.Single(Function(x) x.TransferID = CInt(tid))
                With editTransfer
                    .Remark = txtRemarks.Text.Trim
                    .Status = 2
                    .ApproveByUser = Session("username").ToString.Trim
                    .ApproveDate = Now
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If mode = "edit" Then
            If TryApproveTransfer() Then
                Response.Redirect("Transfer.aspx")
            Else
                JsMsgBoxRedirect("Transfer failed to Approve! Please contact Administrator.", Request.RawUrl.ToString())
            End If
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If mode = "edit" Then
            If TryRejectTransfer() Then
                Response.Redirect("Transfer.aspx")
            Else
                JsMsgBoxRedirect("Transfer failed to Reject! Please contact Administrator.", Request.RawUrl.ToString())
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Transfer.aspx")
    End Sub
End Class
