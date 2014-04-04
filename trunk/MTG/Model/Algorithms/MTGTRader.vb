Imports System.IO
Imports System.Text

Public Class MTGTRader

    Dim db As New MTGCardsDatabase(False)
    Dim guid As String = Date.Now.Ticks.ToString
    Private foldername As String

    Public Sub getPrices(setcode As String, numcard As Integer)


        foldername = "./" & guid & "-" & setcode & "/"
        System.IO.Directory.CreateDirectory(foldername)
        extractall(setcode, numcard)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cardlist">The list of cards to sell</param>
    ''' <param name="pset">The set of those cards</param>
    ''' <param name="runtim">true to query the web, false to read the database. When we query the website we suspend 30 seconds every 5 cards.</param>
    ''' <remarks></remarks>
    Public Sub findBots(cardlist() As String, pset As String, runtim As Boolean, output As RichTextBox)
        Dim database As Dictionary(Of String, Integer) = loadDatabaseAsDictionary(pset)
        If database Is Nothing Then Exit Sub

        If runtim Then
            queryWebsite(cardlist, pset, database, output)
            'Else
            '    querydabatase(cardlist, database, output) 'TODO
        End If
    End Sub

    Private Sub queryWebsite(cardlist() As String, pset As String, database As Dictionary(Of String, Integer), output As RichTextBox)

        If output Is Nothing Then Exit Sub

        output.Clear()
        output.Refresh()

        If cardlist Is Nothing Then output.AppendText("cardlist empty") : Exit Sub
        If database Is Nothing Then output.AppendText("database empty") : Exit Sub

        Dim cardnumber As Integer
        For Each card As String In cardlist

            If Not database.ContainsKey(card) Then output.AppendText("card not found:" & card) : Continue For

            cardnumber = database(card)
            output.AppendText(estraiLowHighAsString(pset, cardnumber))
            output.AppendText(vbNewLine)

        Next


    End Sub

    ''' <summary>
    ''' Read the database for the set and compile the map cardname,cardnumber
    ''' </summary>
    ''' <param name="pset"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadDatabaseAsDictionary(pset As String) As Dictionary(Of String, Integer)

        If String.IsNullOrEmpty(pset) Then Return Nothing

        Dim databasefolder As New DirectoryInfo("..\..\..\Databases")
        If Not databasefolder.Exists Then Return Nothing

        Dim setcardlist As New FileInfo("..\..\..\Databases\" & pset & "_card_list.txt")
        If setcardlist Is Nothing Then Return Nothing

        Dim ret As New Dictionary(Of String, Integer)

        Using sr As New StreamReader(setcardlist.FullName)

            Dim tmp As String
            Dim tokens() As String
            Do Until sr.EndOfStream

                tmp = sr.ReadLine
                tokens = tmp.Split(","c)
                ret(tokens(1)) = Integer.Parse(tokens(0))

            Loop

        End Using

        Return ret
    End Function


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


    ''' <summary>
    ''' This one download the high buyer and low seller as a clean text.
    ''' It skips the buyers with no tickets.
    ''' </summary>
    ''' <param name="setcode"></param>
    ''' <param name="cardnumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function estraiLowHighAsString(setcode As String, cardnumber As Integer) As String

        Dim cardfilepath As String = scaricaCartaByNumber(cardnumber, setcode)
        Dim lowsell As String
        Dim highbuy As String
        Dim cardname As String
        Dim newline As New StringBuilder

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
                    If i = 297 Then
                        ' now here we found the first buyer, we skip them until we find one with tickets
                        While Not hasTickets(tmpline)
                            tmpline = sr.ReadLine
                            tmpline = sr.ReadLine
                        End While
                        highbuy = tmpline : Exit Do
                    End If

                Loop



            End Using


            cardname = cardname.Replace("<title>", "")
            cardname = cardname.Replace("</title>", ": ")
            newline.Append(cardname)

            ' clean the low sell
            newline.Append(" buyer[")
            newline.Append(getName(lowsell))
            newline.Append("] ")

            'clean the high sell
            newline.Append(" seller[")
            newline.Append(getName(highbuy))
            newline.Append("] ")

        Catch x As Exception


        End Try

        Return newline.ToString

    End Function

    Private Function estrailowhigh(setcode As String, cardnumber As Integer, Optional streamwriter As StreamWriter = Nothing) As String

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

            Dim newline As New StringBuilder
            If cardnumber Mod 2 = 0 Then
                newline.Append("<TR >")
            Else
                newline.Append("<TR bgcolor=""#999999"">")
            End If
            cardname = cardname.Replace("<title>", "<td>")
            cardname = cardname.Replace("</title>", ":&nbsp;&nbsp;</td>")
            newline.Append(cardname)
            newline.Append(lowsell.Replace("</tr>", ""))
            newline.Append(highbuy)

            If streamwriter Is Nothing Then Return newline.ToString

            streamwriter.WriteLine(newline.ToString)

        Catch x As Exception


        End Try


    End Function

    ''' <summary>
    ''' this routing extract the bot name from the line.
    ''' </summary>
    ''' <param name="line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getName(line As String) As String

        Dim mline As String = line.Substring(line.IndexOf(">"c))
        mline = mline.Substring(mline.IndexOf(">"c))
        mline = mline.Substring(mline.IndexOf(">"c))
        mline = mline.Substring(0, mline.IndexOf("<"c))

        Return mline.Replace(">", "")

    End Function

    ''' <summary>
    ''' This routine analyze the seller and check the amount of tickets
    ''' </summary>
    ''' <param name="line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function hasTickets(line As String) As Boolean

        Dim tmpline As String = line.Substring(line.Length - 11)
        Return Not tmpline.StartsWith("0")

    End Function

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
