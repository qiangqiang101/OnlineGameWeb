
Imports System.IO

Partial Class Admin_GameAccounts
    Inherits System.Web.UI.Page

    Private Sub Admin_GameAccounts_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New DataClassesDataContext
            Dim gameAccounts = (From ga In db.TblGameAccounts Order By ga.GameID Descending)
            For Each ga As TblGameAccount In gameAccounts
                dataTable.AddTableItem(ga.GameID.ToString("00000"), ga.DateCreated.ToString(dateFormat),
                                       ga.UserName.Trim, ga.Password.Trim, GetProductName(ga.ProductID), If(String.IsNullOrWhiteSpace(ga.MemberUserName), "", ga.MemberUserName.Trim))
            Next
        End Using

        If Not IsPostBack Then
            Using db As New DataClassesDataContext
                Dim products = db.TblProducts.Where(Function(x) x.Status = True).ToList
                For Each p As TblProduct In products
                    cmbProduct.Items.Add(New ListItem(p.ProductName.Trim, p.ProductID))
                    cmbProduct2.Items.Add(New ListItem(p.ProductName.Trim, p.ProductID))
                Next
            End Using
        End If
    End Sub

    Private Sub btnAddPdtUserName_Click(sender As Object, e As EventArgs) Handles btnAddPdtUserName.Click
        InsertVault(cmbProduct.SelectedValue, txtUName.Text.Trim, txtPass.Text.Trim)
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If fileUploader.HasFile Then
            If Not Directory.Exists(Server.MapPath(upload)) Then Directory.CreateDirectory(Server.MapPath(upload))
            Dim csvPath As String = Server.MapPath(upload) & Path.GetFileName(fileUploader.PostedFile.FileName)
            Dim ext = csvPath.Substring(csvPath.LastIndexOf(".") + 1).ToLower
            If ext = "csv" Then
                fileUploader.SaveAs(csvPath)
                BulkInsert(File.ReadAllLines(csvPath))
            Else
                swalBs("Oops!", "The file you are trying to upload is not a .CSV file, please try again.", "error")
            End If
        Else
            swalBs("Oops!", "You have not specified a file.", "error")
        End If
    End Sub

    Private Sub BulkInsert(lists() As String)
        Try
            Using db As New DataClassesDataContext
                Dim al As New List(Of TblGameAccount)
                For Each line In lists
                    Dim accounts() As String = line.Split(","c)
                    al.Add(New TblGameAccount() With {.UserName = accounts(0).Trim, .Password = accounts(1).Trim, .ProductID = cmbProduct2.SelectedValue, .DateCreated = Now, .MemberUserName = Nothing})
                Next

                db.TblGameAccounts.InsertAllOnSubmit(al)
                db.SubmitChanges()
            End Using

            swalBsRedirect("GameAccounts.aspx", "Success", lists.Count & " of " & cmbProduct2.SelectedItem.Text & " Accounts import successfully.", "success")
        Catch ex As Exception
            Log(ex)
            swalBs("Oops!", ex.Message, "error")
        End Try
    End Sub

    Private Sub InsertVault(product As Integer, username As String, password As String)
        Try
            Using db As New DataClassesDataContext
                Dim newGameAcc As New TblGameAccount
                With newGameAcc
                    .DateCreated = Now
                    .MemberUserName = Nothing
                    .UserName = username.Trim
                    .Password = password.Trim
                    .ProductID = product
                End With

                db.TblGameAccounts.InsertOnSubmit(newGameAcc)
                db.SubmitChanges()
            End Using

            Response.Redirect("GameAccounts.aspx")
        Catch ex As Exception
            Log(ex)
            swalBs("Oops!", ex.Message, "error")
        End Try
    End Sub

End Class
