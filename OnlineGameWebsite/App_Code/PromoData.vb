Imports System.IO
Imports System.Xml.Serialization

Public Structure PromoData

    Public ReadOnly Property Instance As PromoData
        Get
            Return ReadFromFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property FileName() As String

    Public English As String
    Public Chinese As String
    Public Malay As String

    Public Sub New(_filename As String)
        FileName = _filename
    End Sub

    Public Sub Save()
        Dim ser = New XmlSerializer(GetType(PromoData))
        Dim writer As TextWriter = New StreamWriter(FileName)
        ser.Serialize(writer, Me)
        writer.Close()
    End Sub

    Public Function ReadFromFile() As PromoData
        If Not File.Exists(FileName) Then
            Return New PromoData(FileName) With {.English = Nothing, .Chinese = Nothing, .Malay = Nothing}
        End If

        Try
            Dim ser = New XmlSerializer(GetType(PromoData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), PromoData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New PromoData(FileName) With {.English = Nothing, .Chinese = Nothing, .Malay = Nothing}
        End Try
    End Function

End Structure
