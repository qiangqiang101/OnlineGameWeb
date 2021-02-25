
Partial Class PWA_Default
    Inherits BasePage

    Private Sub PWA_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim sliders = db.TblSliders.Where(Function(x) x.Status = True And x.SliderImage <> Nothing).OrderByDescending(Function(x) x.DisplayIndex And x.SliderID).Take(9).ToList
            For Each slider As TblSlider In sliders
                productSlider.Controls.Add(LoadSlider(slider.SliderImage, slider.SliderName))
            Next
        End Using
    End Sub

    Private Function LoadSlider(image As String, text As String) As HtmlGenericControl
        Dim overlay = New HtmlGenericControl("div")
        With overlay
            .InnerHtml = "<div class=""card-overlay bg-gradient""></div>"
        End With
        Dim textContainer = New HtmlGenericControl("div")
        With textContainer
            .Attributes("class") = "card-bottom text-center"
            .InnerHtml = "<h4 class=""color-white font-800 mb-3"">" & text.Trim & "</h4>"
        End With

        Dim card = New HtmlGenericControl("div")
        With card
            .Attributes("style") = "height: 220px; background-image: url(" & "../" & image.Trim & ");"
            .Attributes("class") = "card shadow-xl rounded-m"
            .Controls.Add(overlay)
            .Controls.Add(textContainer)
        End With
        Dim item = New HtmlGenericControl("div")
        With item
            .Attributes("class") = "item"
            .Controls.Add(card)
        End With
        Return item
    End Function

    'Private Function LoadSlider(image As String, text As String) As HtmlGenericControl
    '    Dim h4 = New HtmlGenericControl("h4")
    '    With h4
    '        .Attributes("class") = "color-white font-800 mb-3"
    '        .InnerText = text.Trim
    '    End With
    '    Dim img = New HtmlGenericControl("img")
    '    With img
    '        .Attributes("class") = "card-center"
    '        .Attributes("src") = "..\" & image.Trim
    '    End With
    '    Dim overlay = New HtmlGenericControl("div")
    '    With overlay
    '        .Attributes("class") = "card-overlay bg-gradient"
    '    End With
    '    Dim cardCenter = New HtmlGenericControl("div")
    '    With cardCenter
    '        .Attributes("class") = "card-bottom text-center"

    '        .Controls.Add(h4)
    '    End With
    '    Dim card = New HtmlGenericControl("div")
    '    With card
    '        .Attributes("style") = "height:220px"
    '        .Attributes("weight") = "420"
    '        .Attributes("class") = "card shadow-xl rounded-m"
    '        .Controls.Add(img)
    '        .Controls.Add(overlay)
    '        .Controls.Add(cardCenter)
    '        .Controls.Add(h4)

    '    End With
    '    Dim div = New HtmlGenericControl("div")
    '    With div
    '        .Attributes("class") = "item"
    '        .Controls.Add(card)
    '    End With
    '    Return div
    'End Function

End Class
