
Partial Class Admin_EditPromotion
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public pid As String = 0
    Private imageUrl As String = Nothing
    Private promoUrl As String = Nothing
    Private promodat As PromoData = Nothing

    Private Sub Admin_EditPromotion_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        pid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Dim p = db.TblPromotions.Single(Function(x) x.PromoID = pid)
                        txtPromotion.Text = p.PromoName.Trim
                        txtEngName.Text = p.EnglishName.Trim
                        txtChiName.Text = p.ChineseName.Trim
                        txtMysName.Text = p.MalayName.Trim
                        txtIndex.Text = p.DisplayIndex
                        cmbType.SelectedValue = p.PromoType
                        txtValue.Text = p.PromoPercent.ToString("0.00")
                        txtMaxPayout.Text = p.MaxPayout.ToString("0.00")
                        cmbEnabled.SelectedValue = p.Status

                        promoUrl = p.PromoFile
                        promodat = New PromoData(Server.MapPath("..\" & p.PromoFile)).Instance

                        txtEngTnC.Text = promodat.English
                        txtChiTnC.Text = promodat.Chinese
                        txtMysTnc.Text = promodat.Malay

                        imageUrl = p.PromoImage.Trim
                        imgPromo.ImageUrl = If(p.PromoImage = Nothing, "", "..\" & p.PromoImage.Trim)
                        h6.InnerText = "Edit " & p.PromoID.ToString("00000")
                    Catch ex As Exception
                        JsMsgBox("Promotion not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Dim p = db.TblPromotions.Single(Function(x) x.PromoID = pid)
                        txtPromotion.Text = p.PromoName.Trim
                        txtEngName.Text = p.EnglishName.Trim
                        txtChiName.Text = p.ChineseName.Trim
                        txtMysName.Text = p.MalayName.Trim
                        txtIndex.Text = p.DisplayIndex
                        cmbType.SelectedValue = p.PromoType
                        txtValue.Text = p.PromoPercent.ToString("0.00")
                        txtMaxPayout.Text = p.MaxPayout.ToString("0.00")
                        cmbEnabled.SelectedValue = p.Status

                        promoUrl = p.PromoFile
                        promodat = New PromoData(Server.MapPath("..\" & p.PromoFile)).Instance

                        txtEngTnC.Text = promodat.English
                        txtChiTnC.Text = promodat.Chinese
                        txtMysTnc.Text = promodat.Malay

                        imageUrl = p.PromoImage.Trim
                        imgPromo.ImageUrl = If(p.PromoImage = Nothing, "", "..\" & p.PromoImage.Trim)

                        txtPromotion.ReadOnly = True
                        txtEngName.ReadOnly = True
                        txtChiName.ReadOnly = True
                        txtMysName.ReadOnly = True
                        txtIndex.ReadOnly = True
                        cmbType.Enabled = False
                        txtValue.ReadOnly = True
                        txtMaxPayout.ReadOnly = True
                        cmbEnabled.Enabled = False
                        txtEngTnC.ReadOnly = True
                        txtChiTnC.ReadOnly = True
                        txtMysTnc.ReadOnly = True

                        h6.InnerText = "Are you sure you want to delete " & p.PromoName & " (" & p.PromoID.ToString("00000") & ")?"
                        btnSubmit.Text = "Delete"
                    Catch ex As Exception
                        JsMsgBox("Promotion not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "duplicate"
                    h6.InnerText = "Add New Promotion"
                    btnSubmit.Text = "Insert"
                    imgPromo.Visible = False

                    Try
                        Dim p = db.TblPromotions.Single(Function(x) x.PromoID = pid)
                        txtPromotion.Text = "Copy of " & p.PromoName.Trim
                        txtEngName.Text = p.EnglishName.Trim
                        txtChiName.Text = p.ChineseName.Trim
                        txtMysName.Text = p.MalayName.Trim
                        txtIndex.Text = p.DisplayIndex
                        cmbType.SelectedValue = p.PromoType
                        txtValue.Text = p.PromoPercent.ToString("0.00")
                        txtMaxPayout.Text = p.MaxPayout.ToString("0.00")
                        cmbEnabled.SelectedValue = p.Status

                        promoUrl = p.PromoFile
                        promodat = New PromoData(Server.MapPath("..\" & p.PromoFile)).Instance

                        txtEngTnC.Text = promodat.English
                        txtChiTnC.Text = promodat.Chinese
                        txtMysTnc.Text = promodat.Malay

                        imageUrl = p.PromoImage.Trim
                        imgPromo.ImageUrl = If(p.PromoImage = Nothing, "", "..\" & p.PromoImage.Trim)

                        If AddNewPromotion(p.PromoImage.Trim) Then
                            JsMsgBox("Promotion added successfully.")
                            Response.Redirect("Promotions.aspx")
                        Else
                            JsMsgBox("Add promotion failed! Please contact Administrator.")
                        End If
                    Catch ex As Exception
                        JsMsgBox("Promotion not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case Else
                    h6.InnerText = "Add New Promotion"
                    btnSubmit.Text = "Submit"
                    imgPromo.Visible = False
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                Dim editPromo = db.TblPromotions.Single(Function(x) x.PromoID = CInt(pid))

                If TryEditPromotion() Then
                    JsMsgBox("Promotion " & editPromo.PromoName & " update successfully.")
                    Response.Redirect("Promotions.aspx")
                Else
                    JsMsgBox("Promotion " & editPromo.PromoName & " edit failed! Please contact Administrator.")
                End If
            Case "delete"
                Try
                    Dim promoToDelete = db.TblPromotions.Single(Function(x) x.PromoID = CInt(pid))
                    db.TblPromotions.DeleteOnSubmit(promoToDelete)
                    db.SubmitChanges()

                    JsMsgBox("Promotion delete successfully.")
                    Response.Redirect("Promotions.aspx")
                Catch ex As Exception
                    JsMsgBox("Delete product failed! Please contact Administrator.")
                End Try
            Case Else
                If txtPromotion.Text = Nothing Then
                    JsMsgBox("Promotion name is required!")
                ElseIf txtEngName.Text = Nothing Then
                    JsMsgBox("English name is required!")
                ElseIf txtChiName.Text = Nothing Then
                    JsMsgBox("Chinese name is required!")
                ElseIf txtMysName.Text = Nothing Then
                    JsMsgBox("Malay name is required!")
                ElseIf txtValue.Text = Nothing Then
                    JsMsgBox("Value has to be greater than zero.")
                ElseIf txtMaxPayout.Text = Nothing Then
                    JsMsgBox("Max Payout is required.")
                Else
                    If AddNewPromotion() Then
                        JsMsgBox("Promotion added successfully.")
                        Response.Redirect("Promotions.aspx")
                    Else
                        JsMsgBox("Add promotion failed! Please contact Administrator.")
                    End If
                End If
        End Select
    End Sub

    Private Function TryEditPromotion() As Boolean
        Try
            Dim editPromo = db.TblPromotions.Single(Function(x) x.PromoID = CInt(pid))
            With editPromo
                .PromoName = txtPromotion.Text.Trim
                .EnglishName = txtEngName.Text.Trim
                .ChineseName = txtChiName.Text.Trim
                .MalayName = txtMysName.Text.Trim
                .DisplayIndex = CInt(txtIndex.Text.Trim)
                .PromoType = CInt(cmbType.SelectedValue)
                .PromoPercent = CSng(txtValue.Text.Trim)
                .MaxPayout = CSng(txtMaxPayout.Text.Trim)
                .Status = CInt(cmbEnabled.SelectedValue)
                .PromoFile = .PromoFile

                promodat = New PromoData(Server.MapPath("..\" & .PromoFile))
                promodat.English = txtEngTnC.Text.Trim
                promodat.Chinese = txtChiTnC.Text.Trim
                promodat.Malay = txtMysTnc.Text.Trim
                promodat.FileName = Server.MapPath("..\" & .PromoFile)
                promodat.Save()

                If fileUploader.HasFile Then
                    Dim file As String = Server.MapPath(upload & fileUploader.FileName)
                    Dim fileUrl As String = (upload & fileUploader.FileName).Replace("~/", "")
                    Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
                    If IsImage(ext) Then
                        If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                        fileUploader.SaveAs(file)
                        .PromoImage = fileUrl
                    Else
                        JsMsgBox("Image upload failed, please try upload only supported image format.")
                        .PromoImage = imageUrl
                    End If
                Else
                    .PromoImage = imageUrl
                End If
            End With

            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function AddNewPromotion(Optional image As String = "images/empty_box.png") As Boolean
        Dim newPromo As New TblPromotion
        With newPromo
            .DisplayIndex = CInt(txtIndex.Text.Trim)
            .PromoName = txtPromotion.Text.Trim
            .PromoType = cmbType.SelectedValue
            .PromoPercent = CSng(txtValue.Text.Trim)
            .MaxPayout = CSng(txtMaxPayout.Text.Trim)
            .EnglishName = txtEngName.Text.Trim
            .ChineseName = txtChiName.Text.Trim
            .MalayName = txtMysName.Text.Trim
            .Status = cmbEnabled.SelectedValue

            Dim uniqueFileName As String = txtPromotion.Text.Trim.GetHashCode & ".xml"
            Dim fileUrl2 As String = (promoTnc & uniqueFileName).Replace("~/", "")
            If Not IO.Directory.Exists(Server.MapPath(promoTnc)) Then IO.Directory.CreateDirectory(Server.MapPath(promoTnc))
            Dim promodat As New PromoData(Server.MapPath("..\" & fileUrl2))
            With promodat
                .English = txtEngTnC.Text.Trim
                .Chinese = txtChiTnC.Text.Trim
                .Malay = txtMysTnc.Text.Trim
            End With
            promodat.Save()

            .PromoFile = fileUrl2

            If fileUploader.HasFile Then
                Dim file As String = Server.MapPath(upload & fileUploader.FileName)
                Dim fileUrl As String = (upload & fileUploader.FileName).Replace("~/", "")
                Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
                If IsImage(ext) Then
                    If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                    fileUploader.SaveAs(file)
                    .PromoImage = fileUrl
                Else
                    JsMsgBox("Image upload failed, please try upload only supported image format.")
                    .PromoImage = Nothing
                End If
            Else
                .PromoImage = image
            End If
        End With

        Try
            db.TblPromotions.InsertOnSubmit(newPromo)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class
