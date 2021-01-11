
Partial Class Admin_EditPromotion
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public pid As String = 0
    Private imageUrl As String = Nothing
    Private promoUrl As String = Nothing
    Private promodat As PromoData = Nothing

    Private Sub Admin_EditPromotion_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mode = Request.QueryString("mode")
            pid = Request.QueryString("id")

            Select Case mode
                Case "edit"
                    If pid <> Nothing Then
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
                    Else
                        JsMsgBox("Promotion not found!")
                        btnSubmit.Enabled = False
                    End If
                Case "delete"

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
