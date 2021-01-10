
Partial Class Admin_EditProduct
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public pid As String = 0
    Public imageUrl As String = Nothing

    Private Sub Admin_EditProduct_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mode = Request.QueryString("mode")
            pid = Request.QueryString("id")

            Select Case mode
                Case "edit"
                    If pid <> Nothing Then
                        Try
                            Dim p = db.TblProducts.Single(Function(x) x.ProductID = pid)
                            txtName.Text = p.ProductName.Trim
                            txtAlias.Text = p.ProductAlias.Trim
                            cmbCategory.SelectedValue = p.ProductCategory
                            cmbEnabled.SelectedValue = p.Status
                            txtBalance.Text = p.Balance.ToString("0.00")
                            txtAndroid.Text = p.AndroidLink.Trim
                            txtiOS.Text = p.iOSLink.Trim
                            txtWindows.Text = p.WindowsLink.Trim
                            txtWebsite.Text = p.WebsiteUrl.Trim
                            imageUrl = p.ProductImage
                            imgProduct.ImageUrl = If(p.ProductImage = Nothing, "", "..\" & p.ProductImage.Trim)
                            h6.InnerText = "Edit " & p.ProductID.ToString("00000")
                        Catch ex As Exception
                            JsMsgBox("Product not found!")
                            btnSubmit.Enabled = False
                        End Try
                    Else
                        JsMsgBox("Product not found!")
                        btnSubmit.Enabled = False
                    End If
                Case "delete"

                Case Else
                    h6.InnerText = "Add New Product"
                    btnSubmit.Text = "Insert"
                    imgProduct.Visible = False
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                Dim editProduct = db.TblProducts.Single(Function(x) x.ProductID = CInt(pid))

                If TryEditProduct() Then
                    JsMsgBox("Product " & editProduct.ProductName & " update successfully.")
                    Response.Redirect("Product.aspx")
                Else
                    JsMsgBox("Product " & editProduct.ProductName & " edit failed! Please contact Administrator.")
                End If
            Case "delete"

            Case Else
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
        End Select
    End Sub

    Private Function TryEditProduct() As Boolean
        Try
            Dim editProduct = db.TblProducts.Single(Function(x) x.ProductID = CInt(Request.QueryString("id")))
            With editProduct
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
                        .ProductImage = imageUrl
                    End If
                Else
                    .ProductImage = imageUrl
                End If
            End With

            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

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
