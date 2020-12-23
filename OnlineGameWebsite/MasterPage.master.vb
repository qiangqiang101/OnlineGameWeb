
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public WriteOnly Property LiveGamesLink As String
        Set(ByVal value As String)
            lnkLive.Attributes.Add("class", value)
        End Set
    End Property

    Public WriteOnly Property SportsbookLink As String
        Set(ByVal value As String)
            lnkSport.Attributes.Add("class", value)
        End Set
    End Property

    Public WriteOnly Property OthersLink As String
        Set(ByVal value As String)
            lnkOther.Attributes.Add("class", value)
        End Set
    End Property

    Public WriteOnly Property PromotionLink As String
        Set(ByVal value As String)
            lnkPromo.Attributes.Add("class", value)
        End Set
    End Property

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case Request.FilePath
            Case "/Default.aspx", "/default.aspx"
                lnkHome.Attributes.Add("class", "nav-link active")
            Case "/SlotGames.aspx", "/slotgames.aspx"
                lnkSlot.Attributes.Add("class", "nav-link active")
            Case "/Register.aspx"

        End Select
    End Sub
End Class

