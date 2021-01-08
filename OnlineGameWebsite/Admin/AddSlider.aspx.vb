
Partial Class Admin_AddSlider
    Inherits System.Web.UI.Page

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtName.Text = Nothing Then
            JsMsgBox("Slider name is required!")
        Else
            If AddNewSlider() Then
                JsMsgBox("Slider added successfully.")
                Response.Redirect("Sliders.aspx")
            Else
                JsMsgBox("Add slider failed! Please contact Administrator.")
            End If
        End If
    End Sub

    Private Function AddNewSlider() As Boolean
        Dim newSlide As New TblSlider
        With newSlide
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
                    .SliderImage = Nothing
                End If
            Else
                .SliderImage = "images/empty_box.png"
            End If
        End With

        Try
            db.TblSliders.InsertOnSubmit(newSlide)
            db.SubmitChanges()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class
