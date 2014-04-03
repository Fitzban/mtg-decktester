Imports System.IO

Public Class MTGTRader

    Dim db As New MTGCardsDatabase

    Public Sub getPrices()

        extractall()


    End Sub

    ''' <summary>
    ''' This routine loop the database to extract prices
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub extractall()

        Dim streamwriter As New StreamWriter("./prices.html")
        For i = 1 To 6

            If i Mod 5 = 0 Then Threading.Thread.Sleep(30 * 1000)
            estrailowhigh(i, streamwriter)


        Next

        streamwriter.Close()
    End Sub


    Private Sub estrailowhigh(cardnumber As Integer, Optional streamwriter As StreamWriter = Nothing)

        Dim cardfilepath As String = scaricaCartaByNumber(cardnumber)
        Dim lowsell As String
        Dim highbuy As String
        Dim cardname As String

        'prendi linea 158 - lower sell
        Dim linenumber As Integer = 0
        Try

            Using sr As New StreamReader(cardfilepath)

                Dim tmpline As String
                Dim i As Integer = 0
                Do Until sr.EndOfStream

                    tmpline = sr.ReadLine
                    i += 1
                    If i = 74 Then cardname = tmpline
                    If i = 158 Then lowsell = tmpline
                    If i = 297 Then highbuy = tmpline : Exit Do

                Loop



            End Using

            If streamwriter Is Nothing Then streamwriter = New StreamWriter(cardfilepath + "_out.html")
            streamwriter.WriteLine("<TR >")
            streamwriter.Write("<td>" & cardname.Replace("h1", "h5") & "<TD/>")
            streamwriter.WriteLine(lowsell)
            streamwriter.WriteLine(highbuy)


        Catch x As Exception


        End Try

        'prendi linea 297 - higher buy
    End Sub


    ''' <summary>
    ''' this routine download the file from mtgolibrary
    ''' </summary>
    ''' <param name="cardnumber"></param>
    ''' <param name="pset"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function scaricaCartaByNumber(cardnumber As Integer, Optional pset As String = "bng") As String


        '----    http://mtgowikiprice.com/card/bng/3/akroan-skyguard
        '----    http://mtgowikiprice.com/card/ 
        '----    + bng per Born of the Gods 
        '----    + 3 numero carta
        '----    + cyclops-of-oneeyed-pass nome carta
        Dim url As String = "http://mtgowikiprice.com/card/" + pset + "/" + cardnumber.ToString + "/"

        My.Computer.Network.DownloadFile(url, pset & cardnumber & ".html")

        Return pset & cardnumber & ".html"

    End Function


    ''' <summary>
    ''' this routine extract low/high sellers given a card
    ''' </summary>
    ''' <param name="cardnumber"></param>
    ''' <param name="nomecarta"></param>
    ''' <remarks></remarks>
    Private Sub estrailowhigh(cardnumber As Integer, nomecarta As String, Optional streamwriter As StreamWriter = Nothing)

        Dim cardfilepath As String = scaricaCarta(cardnumber, nomecarta)
        Dim lowsell As String
        Dim highbuy As String

        'prendi linea 158 - lower sell
        Dim linenumber As Integer = 0
        Try

            Using sr As New StreamReader(cardfilepath)

                Dim tmpline As String
                Dim i As Integer = 0
                Do Until sr.EndOfStream

                    tmpline = sr.ReadLine
                    i += 1
                    If i = 158 Then lowsell = tmpline
                    If i = 297 Then highbuy = tmpline : Exit Do

                Loop



            End Using

            If streamwriter Is Nothing Then streamwriter = New StreamWriter(cardfilepath + "_out.html")
            streamwriter.WriteLine(lowsell)
            streamwriter.WriteLine(highbuy)


        Catch x As Exception


        End Try

        'prendi linea 297 - higher buy
    End Sub

    ''' <summary>
    ''' this routine download the file from mtgolibrary
    ''' </summary>
    ''' <param name="cardnumber"></param>
    ''' <param name="nomecarta"></param>
    ''' <param name="pset"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function scaricaCarta(cardnumber As Integer, nomecarta As String, Optional pset As String = "bng") As String


        '----    http://mtgowikiprice.com/card/bng/3/akroan-skyguard
        '----    http://mtgowikiprice.com/card/ 
        '----    + bng per Born of the Gods 
        '----    + 3 numero carta
        '----    + cyclops-of-oneeyed-pass nome carta
        Dim url As String = "http://mtgowikiprice.com/card/" + pset + "/" + cardnumber.ToString + "/" + nomecarta.ToLower.Replace(" "c, "-")

        My.Computer.Network.DownloadFile(url, nomecarta + ".html")


        Return nomecarta + ".html"
    End Function

End Class
