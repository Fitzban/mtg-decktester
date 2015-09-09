Imports System.Net

'{"metaproduct":{"idMetaproduct":17,"name":[{"idLanguage":1,"languageName":"English","metaproductName":"Abu Ja\u0027far"},{"idLanguage":2,"languageName":"French","metaproductName":"Abu Ja\u0027far"},{"idLanguage":3,"languageName":"German","metaproductName":"Abu Ja\u0027far"},{"idLanguage":4,"languageName":"Spanish","metaproductName":"Abu Ja\u0027far"},{"idLanguage":5,"languageName":"Italian","metaproductName":"Abu Ja\u0027far"}],"products":{"idProduct":[272550,19346,7644,6834]}}}


''' <summary>
''' This class downloads all teh metaproducts handled by MKM
''' https://www.mkmapi.eu/ws/v1.1/metaproduct/2923
''' </summary>
''' <remarks></remarks>
Public Class MKMMetaproduct

    Public Property idMetaproduct As Double
    Public Property name As MKMName()
    Public Property products As MKMProduct

    Public Function storeToDB() As Boolean
        ' writes it to MongoDB
        Return False
    End Function
End Class
