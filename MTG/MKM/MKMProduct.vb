Imports System.Xml

' <product>
'  <name>Navegador de termales</name>
'  <image>./img/cards/Fifth_Dawn/thermal_navigator.jpg</image>
'  <idGame>1</idGame>
'  <expansion>Quinto Amanecer</expansion>
'  <expIcon>45</expIcon>
'  <rarity>Common</rarity>
' </product>

Public Class MKMProduct

    Private _properties As Dictionary(Of String, Object)
    Public Sub New(pxml As XmlNode)
        If pxml Is Nothing Then Exit Sub
        Dim childNodes As XmlNodeList = pxml.ChildNodes
        For Each node As XmlNode In childNodes

            _properties(node.Name) = node.InnerText

        Next

    End Sub

End Class
