
Partial Class Admin_EditSlider
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public sid As String = 0
    Private imageUrl As String = Nothing

    Private Sub Admin_EditSlider_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        sid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Dim s = db.TblSliders.Single(Function(x) x.SliderID = sid)
                        txtIndex.Text = s.DisplayIndex
                        txtName.Text = s.SliderName.Trim
                        txtUrl.Text = s.LinkUrl.Trim
                        cmbEnabled.SelectedValue = s.Status
                        imageUrl = s.SliderImage.Trim
                        imgSlide.ImageUrl = If(s.SliderImage = Nothing, "", "..\" & s.SliderImage.Trim)
                        h6.InnerText = "Edit " & s.SliderID.ToString("00000")
                    Catch ex As Exception
                        JsMsgBox("Slider not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Dim s = db.TblSliders.Single(Function(x) x.SliderID = sid)
                        txtIndex.Text = s.DisplayIndex
                        txtName.Text = s.SliderName.Trim
                        txtUrl.Text = s.LinkUrl.Trim
                        cmbEnabled.SelectedValue = s.Status
                        imageUrl = s.SliderImage.Trim
                        imgSlide.ImageUrl = If(s.SliderImage = Nothing, "", "..\" & s.SliderImage.Trim)

                        txtIndex.ReadOnly = True
                        txtName.ReadOnly = True
                        txtUrl.ReadOnly = True
                        cmbEnabled.Enabled = False

                        h6.InnerText = "Are you sure you want to delete " & s.SliderName & " (" & s.SliderID.ToString("00000") & ")?"
                        btnSubmit.Text = "Delete"
                    Catch ex As Exception
                        JsMsgBox("Slider not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "duplicate"
                    h6.InnerText = "Add New Slider"
                    btnSubmit.Text = "Insert"
                    imgSlide.Visible = False

                    Try
                        Dim s = db.TblSliders.Single(Function(x) x.SliderID = sid)
                        txtIndex.Text = s.DisplayIndex
                        txtName.Text = "Copy of " & s.SliderName.Trim
                        txtUrl.Text = s.LinkUrl.Trim
                        cmbEnabled.SelectedValue = s.Status
                        imageUrl = s.SliderImage.Trim
                        imgSlide.ImageUrl = If(s.SliderImage = Nothing, "", "..\" & s.SliderImage.Trim)
                        h6.InnerText = "Edit " & s.SliderID.ToString("00000")

                        If AddNewSlider() Then
                            JsMsgBox("Slider added successfully.")
                            Response.Redirect("Sliders.aspx")
                        Else
                            JsMsgBox("Add slider failed! Please contact Administrator.")
                        End If
                    Catch ex As Exception
                        JsMsgBox("Slider not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case Else
                    h6.InnerText = "Add New Slider"
                    btnSubmit.Text = "Insert"
                    imgSlide.Visible = False
            End Select
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                Dim editSlide = db.TblSliders.Single(Function(x) x.SliderID = CInt(sid))

                If TryEditSlider() Then
                    JsMsgBox("Slider " & editSlide.SliderName & " update successfully.")
                    Response.Redirect("Sliders.aspx")
                Else
                    JsMsgBox("Slider " & editSlide.SliderName & " edit failed! Please contact Administrator.")
                End If
            Case "delete"
                Try
                    Dim sliderToDelete = db.TblSliders.Single(Function(x) x.SliderID = CInt(sid))
                    db.TblSliders.DeleteOnSubmit(sliderToDelete)
                    db.SubmitChanges()

                    JsMsgBox("Slider delete successfully.")
                    Response.Redirect("Sliders.aspx")
                Catch ex As Exception
                    JsMsgBox("Delete slider failed! Please contact Administrator.")
                End Try
            Case Else
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
        End Select

    End Sub

    Private Function TryEditSlider() As Boolean
        Try
            Dim editSlide = db.TblSliders.Single(Function(x) x.SliderID = CInt(sid))
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

    Private Function AddNewSlider(Optional image As String = "images/empty_box.png") As Boolean
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
                .SliderImage = image
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
