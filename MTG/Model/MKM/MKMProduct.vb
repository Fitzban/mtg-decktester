Imports System.Xml

''' <summary>
''' Questa classe gestisce la lettura/scrittura dei prodotti da/al database. Tutto JSON.
''' </summary>
''' <remarks></remarks>
Public Class MKMProduct

    Public Property idProduct As String ':         // Product ID
    Public Property idMetaproduct As String '        // Metaproduct ID
    Public Property countReprints As String '        // Number of similar products bundled by the metaproduct
    Public Property name As MKMName '              // Name entity for each supported language
    Public Property category As MKMCategory '        // Category entity the product belongs to
    Public Property priceGuide As MKMPriceGuide '    // Price guide entity '''(ATTN: not returned for expansion requests)'''
    Public Property website As String '              // URL to the product (relative to MKM's base URL)
    Public Property image As String '                // Path to the product's image
    Public Property expansion As String '            // Expansion's name
    Public Property expIcon As String '              // Index of the expansion icon
    Public Property number As String '               // Number of product within the expansion (where applicable)
    Public Property rarity As String '               // Rarity of product (where applicable)
    Public Property reprint As MKMReprint() '        // Reprint entities for each similar product bundled by the metaproduct
    Public Property countArticles As String '        // Number of available articles of this product
    Public Property countFoils As String '           // Number of available articles in foil of this products

End Class


Public Class MKMProducts

    Public Property product As MKMProduct 

End Class
