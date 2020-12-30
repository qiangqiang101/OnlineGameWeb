
Partial Class Admin_GameAccounts
    Inherits System.Web.UI.Page

    Private Sub Admin_GameAccounts_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim gameAccounts = (From ga In db.TblGameAccounts Order By ga.GameID Descending)
        For Each ga As TblGameAccount In gameAccounts
            dataTable.AddTableItem(ga.GameID.ToString("00000"), ga.DateCreated.ToString(dateFormat),
                                   ga.UserName.Trim, ga.Password.Trim, ga.Product.Trim, ga.MemberUserName.Trim)
        Next
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If fileUploader.HasFile Then
            Dim file As String = Server.MapPath(upload & fileUploader.FileName)
            Dim ext = file.Substring(file.LastIndexOf(".") + 1).ToLower
            If ext = "csv" Then
                If Not IO.Directory.Exists(upload) Then IO.Directory.CreateDirectory(upload)
                fileUploader.SaveAs(file)
                BulkInsert(IO.File.ReadAllLines(file))
                JsMsgBox("Uploaded successfully.")
            Else
                JsMsgBox("The file extension " & ext & " is not allowed!")
            End If
        Else
            JsMsgBox("You have not specified a file.")
        End If
    End Sub

    Private Sub BulkInsert(lists() As String)
        For i As Integer = 0 To lists.Count - 1
            Dim accounts() As String = lists(i).Split(","c)
            InsertVault(accounts(0).Trim, accounts(1).Trim, accounts(2).Trim)
        Next
    End Sub

    Private Sub InsertVault(product As String, username As String, password As String)
        Dim newGameAcc As New TblGameAccount
        With newGameAcc
            .DateCreated = Now
            .MemberUserName = Nothing
            .UserName = username.Trim
            .Password = password.Trim
            .Product = product.Trim
        End With

        db.TblGameAccounts.InsertOnSubmit(newGameAcc)
        db.SubmitChanges()
    End Sub
End Class
