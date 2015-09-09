Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.IO

''' <summary>
''' Questa classe gestisce le chiamate a MKM
''' </summary>
''' <remarks></remarks>
Public Class MKMRequestHandler
    ''' <summary>
    ''' Questo costruttore scarica il metaproduct da MKM e lo salva.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Public Function downloadMKMMetaproduct(ByVal id As String) As Dictionary(Of String, MKMMetaproduct)
        If String.IsNullOrEmpty(id) Then Throw New InvalidOperationException("No id provided for MKMMetaproducts constructor")
        Dim method As [String] = "GET"
        Dim url As [String] = "https://www.mkmapi.eu/ws/v1.1/output.json/metaproduct/" + id.ToString

        Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim header As New OAuthHeader()
        request.Headers.Add(HttpRequestHeader.Authorization, header.getAuthorizationHeader(method, url))
        request.Method = method

        Dim response As HttpWebResponse = Nothing
        Try
            response = TryCast(request.GetResponse(), HttpWebResponse)
        Catch ex As Exception
            Return Nothing
        End Try
        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)
        Dim metadata_json As String = reader.ReadToEnd()
        dataStream.Close()
        reader.Close()

        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, MKMMetaproduct))(metadata_json)
    End Function

    ''' <summary>
    ''' trova gli articoli dato un prodotto.
    ''' https://www.mkmapi.eu/ws/v1.1/articles/266361
    ''' </summary>
    ''' <param name="productID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function downloadMKMArticle(productID As String) As Dictionary(Of String, MKMArticle())

        If String.IsNullOrEmpty(productID) Then Throw New InvalidOperationException("No id provided for MKMMetaproducts constructor")
        Dim method As [String] = "GET"
        Dim url As [String] = "https://www.mkmapi.eu/ws/v1.1/output.json/articles/" + productID.ToString + "/1"

        Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim header As New OAuthHeader()
        request.Headers.Add(HttpRequestHeader.Authorization, header.getAuthorizationHeader(method, url))
        request.Method = method

        Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)
        Dim metadata_json As String = reader.ReadToEnd()
        dataStream.Close()
        reader.Close()

        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, MKMArticle()))(metadata_json)

    End Function


    Public Function downloadProduct(productID As String) As MKMProducts

        If String.IsNullOrEmpty(productID) Then Throw New InvalidOperationException("No id provided for MKMMetaproducts constructor")
        Dim method As [String] = "GET"
        Dim url As [String] = "https://www.mkmapi.eu/ws/v1.1/output.json/product/" + productID

        Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim header As New OAuthHeader()
        request.Headers.Add(HttpRequestHeader.Authorization, header.getAuthorizationHeader(method, url))
        request.Method = method

        Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)
        Dim metadata_json As String = reader.ReadToEnd()
        dataStream.Close()
        reader.Close()

        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of MKMProducts)(metadata_json)


    End Function



    ''' <summary>
    ''' It download the whole stock from https://www.mkmapi.eu/ws/v1.1/output.json/stock and returns a list of articles.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function downloadStock() As MKMStock


        Dim method As [String] = "GET"
        Dim url As [String] = "https://www.mkmapi.eu/ws/v1.1/output.json/stock"

        Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim header As New OAuthHeader()
        request.Headers.Add(HttpRequestHeader.Authorization, header.getAuthorizationHeader(method, url))
        request.Method = method

        Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)
        Dim metadata_json As String = reader.ReadToEnd()
        dataStream.Close()
        reader.Close()

        Dim stock_file As New FileInfo("stock_file.json")
        Dim file_writer As StreamWriter = Nothing
        file_writer = stock_file.CreateText()
        file_writer.Write(metadata_json)
        file_writer.Close()

        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of MKMStock)(metadata_json)

    End Function


    ''' <summary>
    ''' This takes an article and update the stock with the values found in it.
    ''' </summary>
    ''' <param name="article"></param>
    ''' <remarks></remarks>
    Public Sub updateArticle(ByVal article As MKMArticle)

        Dim url As String = "https://www.mkmapi.eu/ws/v1.1/stock"
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)

        Dim xmlString As String = article.toXML
        Dim encoding As New ASCIIEncoding()

        Dim bytesToWrite As Byte() = encoding.GetBytes(xmlString)

        request.Method = "POST"
        request.ContentLength = bytesToWrite.Length
        'You need to change this
        request.Headers.Add("SOAPAction: ""https://www.mkmapi.eu/ws/v1.1/stock""")

        request.ContentType = "text/xml; charset=utf-8"

        Dim newStream As Stream = request.GetRequestStream()
        newStream.Write(bytesToWrite, 0, bytesToWrite.Length)
        newStream.Close()

        Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)

        Dim responseFromServer As String = reader.ReadToEnd()

    End Sub
End Class
