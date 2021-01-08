
Partial Class Admin_AddPromotion
    Inherits System.Web.UI.Page

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtPromotion.Text = Nothing Then
            JsMsgBox("Promotion name is required!")
        ElseIf txtEngName.Text = Nothing Then
            JsMsgBox("English name is required!")
        ElseIf txtchiName.Text = Nothing Then
            JsMsgBox("Chinese name is required!")
        ElseIf txtmysName.Text = Nothing Then
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
    End Sub

    Private Function AddNewPromotion() As Boolean
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
                .PromoImage = "images/empty_box.png"
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
