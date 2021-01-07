Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports Microsoft.VisualBasic

Public Module ConfigSettings

    Public Function ReadSetting(Of T)(key As String, def As T) As T
        Try
            Return CType(Convert.ChangeType(ConfigurationManager.AppSettings(key), GetType(T)), T)
        Catch ex As Exception
            Return def
        End Try
    End Function

    Public Sub WriteSetting(Of T)(key As String, value As T)
        Dim doc As XmlDocument = LoadConfigDocument()
        Dim node As XmlNode = doc.SelectSingleNode("//appSettings")
        If node Is Nothing Then Throw New InvalidOperationException("appSettings section not found in config file.")

        Try
            Dim elem As XmlElement = CType(node.SelectSingleNode(String.Format("//add[@key='{0}']", key)), XmlElement)

            If elem IsNot Nothing Then
                elem.SetAttribute("value", If(CType(value, Object) = Nothing, Nothing, value.ToString))
            Else
                elem = doc.CreateElement("add")
                elem.SetAttribute("key", key)
                elem.SetAttribute("value", value.ToString)
                node.AppendChild(elem)
            End If

            doc.Save(GetConfigFilePath)
        Catch
            Throw
        End Try
    End Sub

    Public Sub WriteSettings(ParamArray obj As CfgWrite())
        Dim doc As XmlDocument = LoadConfigDocument()
        Dim node As XmlNode = doc.SelectSingleNode("//appSettings")
        If node Is Nothing Then Throw New InvalidOperationException("appSettings section not found in config file.")


        Try
            For Each o In obj
                Dim elem As XmlElement = CType(node.SelectSingleNode(String.Format("//add[@key='{0}']", o.Key)), XmlElement)

                If elem IsNot Nothing Then
                    elem.SetAttribute("value", If(o.Value = Nothing, Nothing, o.Value.ToString))
                Else
                    elem = doc.CreateElement("add")
                    elem.SetAttribute("key", o.Key)
                    elem.SetAttribute("value", o.Value.ToString)
                    node.AppendChild(elem)
                End If
            Next

            doc.Save(GetConfigFilePath)
        Catch
            Throw
        End Try
    End Sub

    Public Sub RemoveSetting(key As String)
        Dim doc As XmlDocument = LoadConfigDocument()
        Dim node As XmlNode = doc.SelectSingleNode("//appSettings")

        Try
            If node Is Nothing Then
                Throw New InvalidOperationException("appSettings section not found in config file.")
            Else
                node.RemoveChild(node.SelectSingleNode(String.Format("//add[@key='{0}']", key)))
                doc.Save(GetConfigFilePath())
            End If
        Catch ex As NullReferenceException
            Throw New Exception(String.Format("The key {0} does not exist.", key), ex)
        End Try
    End Sub

    Private Function LoadConfigDocument() As XmlDocument
        Dim doc As XmlDocument = Nothing

        Try
            doc = New XmlDocument
            doc.Load(GetConfigFilePath)
            Return doc
        Catch ex As FileNotFoundException
            Throw New Exception("No configuration file found.", ex)
        End Try
    End Function

    Public Function GetConfigFilePath() As String
        Return HttpRuntime.AppDomainAppPath & "Web.config"
    End Function

End Module

Public Class CfgWrite

    Public Key As String
    Public Value As Object

    Public Sub New(k As String, v As Object)
        Key = k
        Value = v
    End Sub

End Class