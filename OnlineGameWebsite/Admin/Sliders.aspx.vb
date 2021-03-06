﻿
Partial Class Admin_Sliders
    Inherits System.Web.UI.Page

    Private Sub Admin_Sliders_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim slide = db.TblSliders.OrderByDescending(Function(x) x.DisplayIndex And x.SliderID)
            For Each s As TblSlider In slide
                Dim hasImage As Boolean = s.SliderImage <> Nothing
                dataTable.AddTableItem(s.SliderID.ToString("00000"), s.SliderName.Trim, If(hasImage, Img("..\" & s.SliderImage.Trim, s.SliderImage.Trim), ""),
                                       s.DisplayIndex, s.Status.ToString, RB("EditSlider.aspx?mode=edit&id=" & s.SliderID, "fas fa-edit") & RB("EditSlider.aspx?mode=delete&id=" & s.SliderID, "fas fa-trash", "btn-danger", "Delete") &
                                       RB("EditSlider.aspx?mode=duplicate&id=" & s.SliderID, "fas fa-clone", "btn-info", "Duplicate"))
            Next
        End Using
    End Sub

    Private Sub btnAddSlider_Click(sender As Object, e As EventArgs) Handles btnAddSlider.Click
        Response.Redirect("EditSlider.aspx?mode=new&id=-1")
    End Sub
End Class
