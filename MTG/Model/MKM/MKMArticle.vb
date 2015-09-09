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


''' <summary>
''' Questa classe gestisce la collezione di Article presente nel database. Legge e scrive JSON.
''' </summary>
''' <remarks></remarks>
Public Class MKMArticle

    Public cardname As String
    Public idArticle As String
    Public idProduct As String '            // Product ID
    Public language As MKMLanguage '        // Language entity
    Public comments As String '             // Comments
    Public price As String '                // Price of the article
    Public count As String '                // Count (see notes)
    Public inShoppingCart As String '       // Flag, if that article is currently in a shopping cart
    Public seller As MKMSeller   '          // Seller's user entity
    Public lastEdited As String '           // Date, the article was last updated
    Public condition As String '            // Product's condition, if applicable
    Public isFoil As String '               // Foil flag, if applicable
    Public isSigned As String '             // Signed flag, if applicable
    Public isAltered As String '            // Altered flag, if applicable
    Public isPlayset As String '            // Playset flag, if applicable
    Public isFirstEd As String '            // First edition flag, if applicable

    Public Function toXML() As String
        Return ""
    End Function

    Public Function storeToDB() As Boolean
        Return False
    End Function
End Class

