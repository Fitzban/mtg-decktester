Imports System.Xml

' XML restituito da MKM API per la classe Articolo
'<article>
' <idArticle>188684882</idArticle>
' <idProduct>269322</idProduct>
' <language>
'  <idLanguage>1</idLanguage>
'  <languageName>English</languageName>
' </language>
' <comments></comments>
' <price>0.02</price>
' <count>2</count>
' <inShoppingCart>false</inShoppingCart>
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
' <condition>NM</condition>
' <isFoil>false</isFoil>
' <isSigned>false</isSigned>
' <isAltered>false</isAltered>
' <isPlayset>false</isPlayset>
'</article><article>

Public Class MKMArticle

    Private _properties As Dictionary(Of String, Object)
    

    ' not from the XML
    Private _cardname As String
    Public Property cardname As String
        Get
            Return _cardname
        End Get
        Set(value As String)
            _cardname = value
        End Set
    End Property

    Public Property price As Double
        Get
            Return Integer.Parse(CStr(_properties("price")))
        End Get
        Set(value As Double)
            _properties("price") = value.ToString
        End Set
    End Property
    Public Sub New(pxml As XmlNode)
        If pxml Is Nothing Then Exit Sub
        Dim childNodes As XmlNodeList = pxml.ChildNodes
        For Each node As XmlNode In childNodes
            Select Case node.Name
                Case "language"
                    _properties(node.Name) = New MKMLanguage(node)

                Case "seller"
                    _properties(node.Name) = New MKMSeller(node)

                Case "product"
                    _properties(node.Name) = New MKMProduct(node)

                Case Else
                    _properties(node.Name) = node.InnerText

            End Select

        Next
        
    End Sub
End Class
