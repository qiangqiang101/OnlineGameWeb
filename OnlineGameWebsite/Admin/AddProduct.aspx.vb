
Partial Class Admin_AddProduct
    Inherits System.Web.UI.Page

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtName.Text = Nothing Then
            JsMsgBox("Name is required!")
        ElseIf txtBalance.Text = Nothing Then
            JsMsgBox("Balance is required!")
        Else
            If AddNewProduct() Then
                JsMsgBox("Product added successfully.")
                Response.Redirect("Products.aspx")
            Else
                JsMsgBox("Add product failed! Please contact Administrator.")
            End If
        End If
    End Sub

    Private Function AddNewProduct() As Boolean
        Dim newProduct As New TblProduct
        With newProduct
            .ProductName = txtName.Text.Trim
            .ProductAlias = txtAlias.Text.Trim
            .ProductCategory = cmbCategory.SelectedValue
            .Status = cmbEnabled.SelectedValue
            .Balance = CSng(txtBalance.Text)
            .AndroidLink = txtAndroid.Text.Trim
            .iOSLink = txtiOS.Text.Trim
            .WindowsLink = txtWindows.Text.Trim
            .WebsiteUrl = txtWebsite.Text.Trim
            If fileUploader.HasFile Then
                Dim file As String = Server.MapPath(upload & fileUploader.FileName)
                Dim fileUrl As String = (upload & fileUploader.FileName).Replace("~/", "")
                Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
                If IsImage(ext) Then
                    If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                    fileUploader.SaveAs(file)
                    .ProductImage = fileUrl
                Else
                    JsMsgBox("Image upload failed, please try upload only supported image format.")
                    .ProductImage = Nothing
                End If
            Else
                .ProductImage = "images/empty_box.png"
            End If
        End With

        Try
            db.TblProducts.InsertOnSubmit(newProduct)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class
