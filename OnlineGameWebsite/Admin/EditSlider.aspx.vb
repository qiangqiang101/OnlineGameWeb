
Partial Class Admin_EditSlider
    Inherits System.Web.UI.Page

    Private imageUrl As String = Nothing

    Private Sub Admin_EditSlider_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = Request.QueryString("id")

            If id <> Nothing Then
                Try
                    Dim s = db.TblSliders.Single(Function(x) x.SliderID = id)
                    txtIndex.Text = s.DisplayIndex
                    txtName.Text = s.SliderName.Trim
                    txtUrl.Text = s.LinkUrl.Trim
                    cmbEnabled.SelectedValue = s.Status
                    imageUrl = s.SliderImage.Trim
                    imgSlide.ImageUrl = If(s.SliderImage = Nothing, "", "..\" & s.SliderImage.Trim)
                Catch ex As Exception
                    JsMsgBox("Slider not found!")
                    btnSubmit.Enabled = False
                End Try
            Else
                JsMsgBox("Slider not found!")
                btnSubmit.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim editSlide = db.TblSliders.Single(Function(x) x.SliderID = CInt(Request.QueryString("id")))

        If TryEditSlider() Then
            JsMsgBox("Slider " & editSlide.SliderName & " update successfully.")
            Response.Redirect("Sliders.aspx")
        Else
            JsMsgBox("Slider " & editSlide.SliderName & " edit failed! Please contact Administrator.")
        End If
    End Sub

    Private Function TryEditSlider() As Boolean
        Try
            Dim editSlide = db.TblSliders.Single(Function(x) x.SliderID = CInt(Request.QueryString("id")))
            With editSlide
                .DisplayIndex = CInt(txtIndex.Text.Trim)
                .SliderName = txtName.Text.Trim
                .LinkUrl = txtUrl.Text.Trim
                .Status = CBool(cmbEnabled.SelectedValue)

                If fileUploader.HasFile Then
                    Dim file As String = Server.MapPath(upload & fileUploader.FileName)
                    Dim fileUrl As String = (upload & fileUploader.FileName).Replace("~/", "")
                    Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
                    If IsImage(ext) Then
                        If Not IO.Directory.Exists(Server.MapPath(upload)) Then IO.Directory.CreateDirectory(Server.MapPath(upload))
                        fileUploader.SaveAs(file)
                        .SliderImage = fileUrl
                    Else
                        JsMsgBox("Image upload failed, please try upload only supported image format.")
                        .SliderImage = imageUrl
                    End If
                Else
                    .SliderImage = imageUrl
                End If
            End With

            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class
