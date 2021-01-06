Imports System.IO
Imports System.Xml.Serialization

Public Structure SettingsData

    Public ReadOnly Property Instance As SettingsData
        Get
            Return ReadFromFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property FileName() As String

    Public CompanyName As String
    Public CompanyLogo As String

    Public RecommendPercentage As Single
    Public RecommendMinimumAmount As Single

    Public Sub New(_filename As String)
        FileName = _filename
    End Sub

    Public Sub Save()
        Dim ser = New XmlSerializer(GetType(SettingsData))
        Dim writer As TextWriter = New StreamWriter(FileName)
        ser.Serialize(writer, Me)
        writer.Close()
    End Sub

    Public Function ReadFromFile() As SettingsData
        If Not File.Exists(FileName) Then
            Return New SettingsData(FileName) With {.CompanyName = "355Club", .CompanyLogo = "", .RecommendPercentage = 0.1F, .RecommendMinimumAmount = 10.0F}
        End If

        Try
            Dim ser = New XmlSerializer(GetType(SettingsData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), SettingsData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New SettingsData(FileName) With {.CompanyName = "355Club", .CompanyLogo = "355Club", .RecommendPercentage = 0.1F, .RecommendMinimumAmount = 10.0F}
        End Try
    End Function

End Structure
