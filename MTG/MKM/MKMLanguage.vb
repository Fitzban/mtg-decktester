Imports System.Xml

'la classe :anguage per le MKM API
'<language>
'  <idLanguage>1</idLanguage>
'  <languageName>English</languageName>
' </language>
'  

Public Class MKMLanguage
    Public idLanguage As String
    Public languageName As String
    Public Sub New(pxmlnode As XmlNode)
        If pxmlnode Is Nothing Then Exit Sub
        Dim childnodes As XmlNodeList = pxmlnode.ChildNodes

        idLanguage = childnodes(0).InnerText
        languageName = childnodes(1).InnerText
    End Sub
End Class
