
Partial Class Admin_Contacts
    Inherits BasePage

    Private Sub Admin_Contacts_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim contacts = db.TblContacts.OrderByDescending(Function(x) x.ContactID)
            For Each c As TblContact In contacts
                dataTable.AddTableItem(c.ContactID.ToString("00000"), ContactTypeToString(c.ContactType), c.ContactName.Trim, If(c.ContactTitle = Nothing, "", c.ContactTitle.Trim), c.Website.Trim, "<i class=""" & c.FaIcon.Trim & """></i>", BoolStatusToString(c.Status),
                                       RB("EditContact.aspx?mode=edit&id=" & c.ContactID, "fas fa-edit", tooltip:="Edit") & RB("EditContact.aspx?mode=delete&id=" & c.ContactID, "fas fa-trash", "btn-danger", "Delete") &
                                       RB("EditContact.aspx?mode=duplicate&id=" & c.ContactID, "fas fa-clone", "btn-info", "Duplicate"))
            Next
        End Using
    End Sub

    Private Sub btnAddContact_Click(sender As Object, e As EventArgs) Handles btnAddContact.Click
        Response.Redirect("EditContact.aspx?mode=new&id=-1")
    End Sub
End Class
