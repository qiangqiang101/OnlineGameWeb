
Partial Class Contact
    Inherits BasePage

    Private Sub Contact_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim contacts As List(Of TblContact)

        Using db As New DataClassesDataContext
            contacts = db.TblContacts.Where(Function(x) x.Status = True And x.ShowContactPage = True).ToList
        End Using

        Dim chats = contacts.Where(Function(x) x.ContactType = 0).ToList
        For Each c In chats
            chatList.Controls.Add(GenerateContact(c.FaIcon.Trim, c.Website.Trim, c.ContactTitle.Trim, c.ContactName.Trim))
        Next

        Dim socials = contacts.Where(Function(x) x.ContactType = 1).ToList
        For Each s In socials
            socialList.Controls.Add(GenerateContact(s.FaIcon.Trim, s.Website.Trim, s.ContactTitle.Trim))
        Next
    End Sub

    Private Function GenerateContact(faicon As String, href As String, title As String, name As String) As HtmlGenericControl
        Return New HtmlGenericControl("li") With {.InnerHtml = "<i class=""" & faicon & """></i><a href=""" & href & """ target=""_blank"">" & title & "</a> - " & name}
    End Function

    Private Function GenerateContact(faicon As String, href As String, title As String) As HtmlGenericControl
        Return New HtmlGenericControl("li") With {.InnerHtml = "<i class=""" & faicon & """></i><a href=""" & href & """ target=""_blank"">" & title & "</a>"}
    End Function
End Class
