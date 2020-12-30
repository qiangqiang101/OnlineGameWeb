﻿
Partial Class Admin_EditProduct
    Inherits System.Web.UI.Page

    Public imageUrl As String = Nothing

    Private Sub Admin_EditProduct_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = Request.QueryString("id")

            If id <> Nothing Then
                Dim p = db.TblProducts.Single(Function(x) x.ProductID = id)
                If p IsNot Nothing Then
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
                Else
                    JsMsgBox("Product not found!")
                    btnSubmit.Enabled = False
                End If
            Else
                JsMsgBox("Product not found!")
                btnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
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
            End If
        End With
        db.SubmitChanges()
        JsMsgBox("Product " & editProduct.ProductName & " update successfully.")
    End Sub
End Class