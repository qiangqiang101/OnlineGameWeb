
Partial Class Admin_EditContact
    Inherits System.Web.UI.Page

    Public mode As String = "edit"
    Public cid As String = 0

    Private Sub Admin_EditContact_Load(sender As Object, e As EventArgs) Handles Me.Load
        mode = Request.QueryString("mode")
        cid = Request.QueryString("id")

        If Not IsPostBack Then
            Select Case mode
                Case "edit"
                    Try
                        Using db As New DataClassesDataContext
                            Dim c = db.TblContacts.Single(Function(x) x.ContactID = CInt(cid))
                            cmbList.SelectedValue = GetContactPresetFromCss(c.FaIcon.Trim)
                            cmbType.SelectedValue = c.ContactType
                            txtName.Text = c.ContactName.Trim
                            txtAccNo.Text = c.Website.Trim
                            txtTitle.Text = If(c.ContactTitle = Nothing, "", c.ContactTitle.Trim)
                            txtFaIcon.Text = c.FaIcon.Trim
                            cbFooter.Checked = c.ShowFooter
                            cbProductPage.Checked = c.ShowProductPage
                            cbContactPage.Checked = c.ShowContactPage
                            cmbEnabled.SelectedValue = c.Status

                            h6.InnerText = "Edit " & c.ContactID.ToString("00000")
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        JsMsgBox("Contact not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "delete"
                    Try
                        Using db As New DataClassesDataContext
                            Dim c = db.TblContacts.Single(Function(x) x.ContactID = CInt(cid))
                            cmbList.SelectedValue = GetContactPresetFromCss(c.FaIcon.Trim)
                            cmbType.SelectedValue = c.ContactType
                            txtName.Text = c.ContactName.Trim
                            txtAccNo.Text = c.Website.Trim
                            txtTitle.Text = If(c.ContactTitle = Nothing, "", c.ContactTitle.Trim)
                            txtFaIcon.Text = c.FaIcon.Trim
                            cbFooter.Checked = c.ShowFooter
                            cbProductPage.Checked = c.ShowProductPage
                            cbContactPage.Checked = c.ShowContactPage
                            cmbEnabled.SelectedValue = c.Status

                            cmbList.Enabled = False
                            cmbType.Enabled = False
                            txtName.ReadOnly = True
                            txtAccNo.ReadOnly = True
                            txtTitle.ReadOnly = True
                            txtFaIcon.ReadOnly = True
                            cbFooter.Enabled = False
                            cbProductPage.Enabled = False
                            cbContactPage.Enabled = False
                            cmbEnabled.Enabled = False

                            h6.InnerText = "Edit " & c.ContactID.ToString("00000")
                            btnSubmit.Text = "Delete"
                        End Using
                    Catch ex As Exception
                        Log(ex)
                        JsMsgBox("Contact not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case "duplicate"
                    Try
                        Using db As New DataClassesDataContext
                            Dim c = db.TblContacts.Single(Function(x) x.ContactID = CInt(cid))
                            cmbList.SelectedValue = GetContactPresetFromCss(c.FaIcon.Trim)
                            cmbType.SelectedValue = c.ContactType
                            txtName.Text = c.ContactName.Trim
                            txtAccNo.Text = c.Website.Trim
                            txtTitle.Text = If(c.ContactTitle = Nothing, "", c.ContactTitle.Trim)
                            txtFaIcon.Text = c.FaIcon.Trim
                            cbFooter.Checked = c.ShowFooter
                            cbProductPage.Checked = c.ShowProductPage
                            cbContactPage.Checked = c.ShowContactPage
                            cmbEnabled.SelectedValue = c.Status

                            h6.InnerText = "Edit " & c.ContactID.ToString("00000")
                        End Using

                        If AddNewContact() Then
                            JsMsgBox("Contact duplicate successfully.")
                            Response.Redirect("Contacts.aspx")
                        Else
                            JsMsgBox("Duplicate contact failed! Please contact Administrator.")
                        End If
                    Catch ex As Exception
                        Log(ex)
                        JsMsgBox("Contact not found!")
                        btnSubmit.Enabled = False
                    End Try
                Case Else
                    h6.InnerText = "Add New Contact"
                    btnSubmit.Text = "Insert"
            End Select
        End If
    End Sub

    Private Sub cmbList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbList.SelectedIndexChanged
        Dim res As Tuple(Of Integer, String) = GetContactPreset(cmbList.SelectedValue)
        cmbType.SelectedValue = res.Item1
        txtFaIcon.Text = res.Item2
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Select Case mode
            Case "edit"
                If TryEditContact() Then
                    JsMsgBox("Contact update successfully.")
                    Response.Redirect("Contacts.aspx")
                Else
                    JsMsgBox("Contact edit failed! Please contact Administrator.")
                End If
            Case "delete"
                Try
                    Using db As New DataClassesDataContext
                        Dim contactToDelete = db.TblContacts.Single(Function(x) x.ContactID = CInt(cid))
                        db.TblContacts.DeleteOnSubmit(contactToDelete)
                        db.SubmitChanges()
                    End Using

                    JsMsgBox("Contact delete successfully.")
                    Response.Redirect("Contacts.aspx")
                Catch ex As Exception
                    Log(ex)
                    JsMsgBox("Delete contact failed! Please contact Administrator.")
                End Try
            Case Else
                If AddNewContact() Then
                    JsMsgBox("Contact added successfully.")
                    Response.Redirect("Contacts.aspx")
                Else
                    JsMsgBox("Add contact failed! Please contact Administrator.")
                End If
        End Select
    End Sub

    Private Function TryEditContact() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim editContact = db.TblContacts.Single(Function(x) x.ContactID = CInt(cid))
                With editContact
                    .ContactType = cmbType.SelectedValue
                    .ContactName = txtName.Text.Trim
                    .Website = txtAccNo.Text.Trim
                    .ContactTitle = If(txtTitle.Text = Nothing, "", txtTitle.Text.Trim)
                    .FaIcon = txtFaIcon.Text.Trim
                    .ShowFooter = cbFooter.Checked
                    .ShowProductPage = cbProductPage.Checked
                    .ShowContactPage = cbContactPage.Checked
                    .Status = cmbEnabled.SelectedValue
                End With

                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

    Private Function AddNewContact() As Boolean
        Try
            Using db As New DataClassesDataContext
                Dim newContact As New TblContact
                With newContact
                    .ContactType = cmbType.SelectedValue
                    .ContactName = txtName.Text.Trim
                    .Website = txtAccNo.Text.Trim
                    .ContactTitle = If(txtTitle.Text = Nothing, "", txtTitle.Text.Trim)
                    .FaIcon = txtFaIcon.Text.Trim
                    .ShowFooter = cbFooter.Checked
                    .ShowProductPage = cbProductPage.Checked
                    .ShowContactPage = cbContactPage.Checked
                    .Status = cmbEnabled.SelectedValue
                End With

                db.TblContacts.InsertOnSubmit(newContact)
                db.SubmitChanges()
            End Using
        Catch ex As Exception
            Log(ex)
            Return False
        End Try

        Return True
    End Function

End Class
