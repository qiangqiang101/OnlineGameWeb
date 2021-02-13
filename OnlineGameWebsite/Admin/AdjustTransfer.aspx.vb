
Partial Class Admin_AdjustTransfer
    Inherits System.Web.UI.Page

    Public mid As String = 0

    Private Sub Admin_AdjustTransfer_Load(sender As Object, e As EventArgs) Handles Me.Load
        mid = Request.QueryString("id")

        If Not IsPostBack Then
            If Not mid = Nothing Then txtUserID.Text = mid

            Try
                Using db As New DataClassesDataContext
                    Dim members = db.TblMembers.Where(Function(x) x.Enabled = True).ToList
                    For Each m In members
                        userIdList.Controls.Add(AddOption(m.UserName.Trim, m.UserName.Trim))
                    Next

                    Dim products = db.TblProducts.Where(Function(x) x.Status = True).ToList
                    For Each pdt As TblProduct In products
                        cmbFromProduct.Items.Add(New ListItem(pdt.ProductName, pdt.ProductID))
                        cmbToProduct.Items.Add(New ListItem(pdt.ProductName, pdt.ProductID))
                    Next
                End Using
            Catch ex As Exception
                Log(ex)
            End Try
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cmbFromProduct.SelectedValue = cmbToProduct.SelectedValue Then
            swalBs("Oops!", "Unable to transfer to the same product.", "error")
        Else
            If Transfer() Then
                swalBsRedirect("Transfers.aspx", "Success", "This Transfer Adjustment is successfully added.", "success")
            Else
                swalBs("Oops!", "Failed to add Transfer Adjustment, Please contact Adminstrator.", "error")
            End If
        End If
    End Sub

    Private Function AddOption(text As String, value As String) As HtmlGenericControl
        Dim opt As New HtmlGenericControl("option")
        With opt
            .Attributes("value") = value.Trim
            .InnerText = text.Trim
        End With
        Return opt
    End Function

    Private Function Transfer() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newTransfer As New TblTransfer
                With newTransfer
                    .TransferDate = Now
                    .UserName = txtUserID.Text.Trim
                    .FromProductID = cmbFromProduct.SelectedValue
                    .FromUserName = GetProductUserName(cmbFromProduct.SelectedValue, txtUserID.Text.Trim)
                    .ToProductID = cmbToProduct.SelectedValue
                    .ToUserName = GetProductUserName(cmbToProduct.SelectedValue, txtUserID.Text.Trim)
                    .Amount = CSng(txtAmount.Text.Trim)
                    .Status = 0
                    .IPAddress = "127.0.0.1"
                    .Reason = Nothing
                    .ApproveByUser = "None"
                    .ApproveDate = Now
                    .Remark = Nothing
                End With

                db.TblTransfers.InsertOnSubmit(newTransfer)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
        Return True
    End Function

End Class
