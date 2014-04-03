Imports System.IO

Public Class MTGTRader

    Dim db As New MTGCardsDatabase
    Dim guid As String = Date.Now.Ticks.ToString
    Private foldername As String

    Public Sub getPrices(setcode As String, numcard As Integer)


        foldername = "./" & guid & "-" & setcode & "/"
        System.IO.Directory.CreateDirectory(foldername)
        extractall(setcode, numcard)

    End Sub

    ''' <summary>
    ''' This routine loop the database to extract prices
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub extractall(setcode As String, numcard As Integer)

        Dim streamwriter As New StreamWriter(foldername & "prices.html")
        streamwriter.WriteLine("<table>")
        For i = 1 To numcard

            If i Mod 5 = 0 Then Threading.Thread.Sleep(30 * 1000)
            estrailowhigh(setcode, i, streamwriter)


        Next
        streamwriter.WriteLine("</table>")
        streamwriter.Close()
        streamwriter.Dispose()
    End Sub


    Private Sub estrailowhigh(setcode As String, cardnumber As Integer, Optional streamwriter As StreamWriter = Nothing)

        Dim cardfilepath As String = scaricaCartaByNumber(cardnumber, setcode)
        Dim lowsell As String
        Dim highbuy As String
        Dim cardname As String


        Dim linenumber As Integer = 0
        Try

            Using sr As New StreamReader(cardfilepath)

                Dim tmpline As String
                Dim i As Integer = 0
                Do Until sr.EndOfStream

                    tmpline = sr.ReadLine
                    i += 1
                    ' card name
                    If i = 63 Then cardname = tmpline
                    ' lower sell
                    If i = 158 Then lowsell = tmpline
                    ' higher buy
                    If i = 297 Then highbuy = tmpline : Exit Do

                Loop



            End Using

            If streamwriter Is Nothing Then streamwriter = New StreamWriter(cardfilepath + "_out.html")
            If cardnumber Mod 2 = 0 Then
                streamwriter.WriteLine("<TR >")
            Else
                streamwriter.WriteLine("<TR bgcolor=""#999999"">")
            End If

            cardname = cardname.Replace("<title>", "<td>")
            cardname = cardname.Replace("</title>", ":&nbsp;&nbsp;</td>")
            streamwriter.Write(cardname)
            streamwriter.WriteLine(lowsell.Replace("</tr>", ""))
            streamwriter.WriteLine(highbuy)


        Catch x As Exception


        End Try


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

        My.Computer.Network.DownloadFile(url, foldername & cardnumber & ".html")

        Return foldername & cardnumber & ".html"

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
