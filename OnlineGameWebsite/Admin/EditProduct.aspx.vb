﻿
Partial Class Admin_EditProduct
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public pid As String = 0
    Public imageUrl As String = Nothing

    Private Sub Admin_EditProduct_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        pid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Using db As New DataClassesDataContext
                            Dim p = db.TblProducts.Single(Function(x) x.ProductID = pid)
                            txtName.Text = p.ProductName.Trim
                            txtAlias.Text = p.ProductAlias.Trim
                            cbSlot.Checked = p.CatSlot
                            cbLive.Checked = p.CatLive
                            cbSport.Checked = p.CatSport
                            cbRNG.Checked = p.CatRNG
                            cbFish.Checked = p.CatFish
                            cbPoker.Checked = p.CatPoker
                            cbOther.Checked = p.CatOther
                            cmbEnabled.SelectedValue = p.Status
                            txtBalance.Text = p.Balance.ToString("0.00")
                            txtAndroid.Text = p.AndroidLink.Trim
                            txtiOS.Text = p.iOSLink.Trim
                            txtWindows.Text = p.WindowsLink.Trim
                            txtWebsite.Text = p.WebsiteUrl.Trim
                            imageUrl = p.ProductImage
                            imgProduct.ImageUrl = If(p.ProductImage = Nothing, "", "..\" & p.ProductImage.Trim)
                            h6.InnerText = "Edit " & p.ProductID.ToString("00000")
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Product ID does not exist.", "error")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Using db As New DataClassesDataContext
                            Dim p = db.TblProducts.Single(Function(x) x.ProductID = pid)
                            txtName.Text = p.ProductName.Trim
                            txtAlias.Text = p.ProductAlias.Trim
                            cbSlot.Checked = p.CatSlot
                            cbLive.Checked = p.CatLive
                            cbSport.Checked = p.CatSport
                            cbRNG.Checked = p.CatRNG
                            cbFish.Checked = p.CatFish
                            cbPoker.Checked = p.CatPoker
                            cbOther.Checked = p.CatOther
                            cmbEnabled.SelectedValue = p.Status
                            txtBalance.Text = p.Balance.ToString("0.00")
                            txtAndroid.Text = p.AndroidLink.Trim
                            txtiOS.Text = p.iOSLink.Trim
                            txtWindows.Text = p.WindowsLink.Trim
                            txtWebsite.Text = p.WebsiteUrl.Trim
                            imageUrl = p.ProductImage
                            imgProduct.ImageUrl = If(p.ProductImage = Nothing, "", "..\" & p.ProductImage.Trim)

                            txtName.ReadOnly = True
                            txtAlias.ReadOnly = True
                            cbSlot.Enabled = False
                            cbLive.Enabled = False
                            cbSport.Enabled = False
                            cbRNG.Enabled = False
                            cbFish.Enabled = False
                            cbPoker.Enabled = False
                            cbOther.Enabled = False
                            cmbEnabled.Enabled = False
                            txtBalance.ReadOnly = True
                            txtAndroid.ReadOnly = True
                            txtiOS.ReadOnly = True
                            txtWindows.ReadOnly = True
                            txtWebsite.ReadOnly = True

                            h6.InnerText = "Are you sure you want to delete " & p.ProductName & " (" & p.ProductID.ToString("00000") & ")?"
                            btnSubmit.Text = "Delete"
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Product ID does not exist.", "error")
                        btnSubmit.Enabled = False
                    End Try
                Case "duplicate"
                    h6.InnerText = "Add New Product"
                    btnSubmit.Text = "Insert"
                    imgProduct.Visible = False

                    Try
                        Using db As New DataClassesDataContext
                            Dim p = db.TblProducts.Single(Function(x) x.ProductID = pid)
                            txtName.Text = "Copy of " & p.ProductName.Trim
                            txtAlias.Text = p.ProductAlias.Trim
                            cbSlot.Checked = p.CatSlot
                            cbLive.Checked = p.CatLive
                            cbSport.Checked = p.CatSport
                            cbRNG.Checked = p.CatRNG
                            cbFish.Checked = p.CatFish
                            cbPoker.Checked = p.CatPoker
                            cbOther.Checked = p.CatOther
                            cmbEnabled.SelectedValue = p.Status
                            txtBalance.Text = p.Balance.ToString("0.00")
                            txtAndroid.Text = p.AndroidLink.Trim
                            txtiOS.Text = p.iOSLink.Trim
                            txtWindows.Text = p.WindowsLink.Trim
                            txtWebsite.Text = p.WebsiteUrl.Trim
                            imageUrl = p.ProductImage.Trim
                            imgProduct.ImageUrl = If(p.ProductImage = Nothing, "", "..\" & p.ProductImage.Trim)

                            If AddNewProduct(p.ProductImage.Trim) Then
                                swalBsRedirect("Products.aspx", "Success", "This Product is successfully added.", "success")
                            Else
                                swalBs("Oops!", "Failed to add Product, Please contact Adminstrator.", "error")
                            End If
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        swalBs("Oops!", "This Product ID does not exist.", "error")
                        btnSubmit.Enabled = False
                    End Try
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
                Using db As New DataClassesDataContext
                    Dim editProduct = db.TblProducts.Single(Function(x) x.ProductID = CInt(pid))

                    If TryEditProduct() Then
                        swalBsRedirect("Products.aspx", "Success", "This Product is successfully update.", "success")

                    Else
                        swalBs("Oops!", "Failed to edit this Product, Please contact Administrator.", "error")
                    End If
                End Using
            Case "delete"
                Try
                    Using db As New DataClassesDataContext
                        Dim productToDelete = db.TblProducts.Single(Function(x) x.ProductID = CInt(pid))
                        db.TblProducts.DeleteOnSubmit(productToDelete)
                        db.SubmitChanges()

                        swalBsRedirect("Products.aspx", "Success", "This Product is successfully delete.", "success")
                    End Using
                Catch ex As Exception
                    Log(ex)
                    swalBs("Oops!", "This Product is failed to delete! Please contact Adminstrator.", "error")
                End Try
            Case Else
                If txtName.Text = Nothing Then
                    swalBs("Oops!", "Please enter Product Name.", "error")
                ElseIf txtBalance.Text = Nothing Then
                    swalBs("Oops!", "Please enter Product Balance.", "error")
                Else
                    If AddNewProduct() Then
                        swalBsRedirect("Products.aspx", "Success", "This Product is successfully added.", "success")
                    Else
                        swalBs("Oops!", "Failed to add Product, Please contact Adminstrator.", "error")
                    End If
                End If
        End Select
    End Sub

    Private Function TryEditProduct() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editProduct = db.TblProducts.Single(Function(x) x.ProductID = CInt(pid))
                With editProduct
                    .ProductName = txtName.Text.Trim
                    .ProductAlias = txtAlias.Text.Trim
                    .CatSlot = cbSlot.Checked
                    .CatLive = cbLive.Checked
                    .CatSport = cbSport.Checked
                    .CatRNG = cbRNG.Checked
                    .CatFish = cbFish.Checked
                    .CatPoker = cbPoker.Checked
                    .CatOther = cbOther.Checked
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
                            swalBs("Oops!", "Failed to upload image, please try again with supported image format.", "error")
                            .ProductImage = imageUrl
                        End If
                    Else
                        .ProductImage = imageUrl
                    End If
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

    Private Function AddNewProduct(Optional image As String = "Theme/img/empty_box.png") As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newProduct As New TblProduct
                With newProduct
                    .ProductName = txtName.Text.Trim
                    .ProductAlias = txtAlias.Text.Trim
                    .CatSlot = cbSlot.Checked
                    .CatLive = cbLive.Checked
                    .CatSport = cbSport.Checked
                    .CatRNG = cbRNG.Checked
                    .CatFish = cbFish.Checked
                    .CatPoker = cbPoker.Checked
                    .CatOther = cbOther.Checked
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
                            swalBs("Oops!", "Failed to upload image, please try again with supported image format.", "error")
                            .ProductImage = imgProduct.ImageUrl
                        End If
                    Else
                        .ProductImage = imgProduct.ImageUrl
                    End If
                End With

                db.TblProducts.InsertOnSubmit(newProduct)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try
        Return True
    End Function

End Class
