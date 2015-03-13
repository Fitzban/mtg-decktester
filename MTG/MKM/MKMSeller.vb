Imports System.Xml

' la classe seller per le MKM API
' <seller>
'  <idUser>85065</idUser>
'  <username>Admiral-Haze</username>
'  <country>D</country>
'  <isCommercial>0</isCommercial>
'  <riskGroup>0</riskGroup>
'  <reputation>1</reputation>
'  <shipsFast>1</shipsFast>
'  <sellCount>797</sellCount>
'  <onVacation>false</onVacation>
'  <idDisplayLanguage>3</idDisplayLanguage>
' </seller>


Public Class MKMSeller
    Public idUser As String
    Public username As String
    Public country As String
    Public isCommercial As String
    Public riskGroup As String
    Public reputation As String
    Public shipfast As String
    Public sellCount As Integer
    Public onVacation As String
    Public idDisplayLAnguage As String

    Public Sub New(pnode As XmlNode)
        If pnode Is Nothing Then Exit Sub
        Dim childnodes As XmlNodeList = pnode.ChildNodes

        idUser = childnodes(0).InnerText
        username = childnodes(1).InnerText
        country = childnodes(2).InnerText
        isCommercial = childnodes(3).InnerText
        riskGroup = childnodes(4).InnerText
        reputation = childnodes(5).InnerText
        shipfast = childnodes(6).InnerText
        sellCount = Integer.Parse(childnodes(7).InnerText)
        onVacation = childnodes(8).InnerText
        idDisplayLAnguage = childnodes(9).InnerText
    End Sub
End Class
