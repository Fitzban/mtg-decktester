Imports System.Net
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Text

Class RequestHelper
    Public Sub makeRequest()
        Dim method As [String] = "GET"
        Dim url As [String] = "https://www.mkmapi.eu/ws/v1.1/account"

        Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim header As New OAuthHeader()
        request.Headers.Add(HttpRequestHeader.Authorization, header.getAuthorizationHeader(method, url))
        request.Method = method

        Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()


    End Sub
End Class


''' <summary>
''' Class encapsulates tokens and secret to create OAuth signatures and return Authorization headers for web requests.
''' </summary>
Class OAuthHeader
    ''' <summary>App Token</summary>
    Protected appToken As [String] = "CPKCcpttyoNuS7mD"
    ''' <summary>App Secret</summary>
    Protected appSecret As [String] = "R8xYaTRJ67TK5c6APgsnCkdaAjtrMudz"
    ''' <summary>Access Token (Class should also implement an AccessToken property to set the value)</summary>
    Protected accessToken As [String] = "SIDx4GYAbbEhqwIYhEgdaXlwxCDNKXE0"
    ''' <summary>Access Token Secret (Class should also implement an AccessToken property to set the value)</summary>
    Protected accessSecret As [String] = "C0qOvq0KUNw9QjV3Q88tNnecDVRg8HIg"
    ''' <summary>OAuth Signature Method</summary>
    Protected signatureMethod As [String] = "HMAC-SHA1"
    ''' <summary>OAuth Version</summary>
    Protected version As [String] = "1.0"
    ''' <summary>All Header params compiled into a Dictionary</summary>
    Protected headerParams As IDictionary(Of [String], [String])

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        ' String nonce = Guid.NewGuid().ToString("n");
        Dim nonce As [String] = "53eb1f44909d6"
        ' String timestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
        Dim timestamp As [String] = "1407917892"
        ' Initialize all class members
        Me.headerParams = New Dictionary(Of [String], [String])()
        Me.headerParams.Add("oauth_consumer_key", Me.appToken)
        Me.headerParams.Add("oauth_token", Me.accessToken)
        Me.headerParams.Add("oauth_nonce", nonce)
        Me.headerParams.Add("oauth_timestamp", timestamp)
        Me.headerParams.Add("oauth_signature_method", Me.signatureMethod)
        Me.headerParams.Add("oauth_version", Me.version)
    End Sub

    ''' <summary>
    ''' Pass request method and URI parameters to get the Authorization header value
    ''' </summary>
    ''' <param name="method">Request Method</param>
    ''' <param name="url">Request URI</param>
    ''' <returns>Authorization header value</returns>
    Public Function getAuthorizationHeader(method As [String], url As [String]) As [String]
        ' Add the realm parameter to the header params
        Me.headerParams.Add("realm", url)

        ' Start composing the base string from the method and request URI
        Dim baseString As [String] = method.ToUpper() & "&" & Uri.EscapeDataString(url) & "&"

        ' Gather, encode, and sort the base string parameters
        Dim encodedParams As New SortedDictionary(Of [String], [String])()
        For Each parameter As KeyValuePair(Of [String], [String]) In Me.headerParams
            If False = parameter.Key.Equals("realm") Then
                encodedParams.Add(Uri.EscapeDataString(parameter.Key), Uri.EscapeDataString(parameter.Value))
            End If
        Next

        ' Expand the base string by the encoded parameter=value pairs
        Dim paramStrings As New List(Of [String])()
        For Each parameter As KeyValuePair(Of [String], [String]) In encodedParams
            paramStrings.Add(parameter.Key + "=" + parameter.Value)
        Next
        Dim paramString As [String] = Uri.EscapeDataString([String].Join(Of [String])("&", paramStrings))
        baseString += paramString

        ' Create the OAuth signature
        Dim signatureKey As [String] = Uri.EscapeDataString(Me.appSecret) & "&" & Uri.EscapeDataString(Me.accessSecret)
        Dim hasher As HMAC = HMACSHA1.Create()
        hasher.Key = Encoding.UTF8.GetBytes(signatureKey)
        Dim rawSignature As [Byte]() = hasher.ComputeHash(Encoding.UTF8.GetBytes(baseString))
        Dim oAuthSignature As [String] = Convert.ToBase64String(rawSignature)

        ' Include the OAuth signature parameter in the header parameters array
        Me.headerParams.Add("oauth_signature", oAuthSignature)

        ' Construct the header string
        Dim headerParamStrings As New List(Of [String])()
        For Each parameter As KeyValuePair(Of [String], [String]) In Me.headerParams
            headerParamStrings.Add(parameter.Key + "=""" + parameter.Value & """")
        Next
        Dim authHeader As [String] = "OAuth " & [String].Join(Of [String])(", ", headerParamStrings)

        Return authHeader
    End Function
End Class
