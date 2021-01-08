
Partial Class Admin_EditPromotion
    Inherits System.Web.UI.Page

    Private imageUrl As String = Nothing
    Private promoUrl As String = Nothing
    Private promodat As PromoData = Nothing

    Private Sub Admin_EditPromotion_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = Request.QueryString("id")

            If id <> Nothing Then
                Try
                    Dim p = db.TblPromotions.Single(Function(x) x.PromoID = id)
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
                Catch ex As Exception
                    JsMsgBox("Promotion not found!")
                    btnSubmit.Enabled = False
                End Try
            Else
                JsMsgBox("Promotion not found!")
                btnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim editPromo = db.TblPromotions.Single(Function(x) x.PromoID = CInt(Request.QueryString("id")))

        If TryEditPromotion() Then
            JsMsgBox("Promotion " & editPromo.PromoName & " update successfully.")
            Response.Redirect("Promotions.aspx")
        Else
            JsMsgBox("Promotion " & editPromo.PromoName & " edit failed! Please contact Administrator.")
        End If
    End Sub

    Private Function TryEditPromotion() As Boolean
        Try
            Dim editPromo = db.TblPromotions.Single(Function(x) x.PromoID = CInt(Request.QueryString("id")))
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
End Class
