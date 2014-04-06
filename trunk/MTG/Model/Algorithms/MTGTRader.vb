Imports System.IO
Imports System.Text

Public Class MTGTRader

    Dim db As New MTGCardsDatabase(False)
    Dim guid As String = Date.Now.Ticks.ToString
    Private foldername As String
    Private blacklist As List(Of String)

    Public Sub getPrices(setcode As String, numcard As Integer)


        foldername = "./" & guid & "-" & setcode & "/"
        System.IO.Directory.CreateDirectory(foldername)
        extractall(setcode, numcard)

    End Sub


    Public Sub refreshAllSets()

        Dim sets As ICollection(Of MTGSet) = generateSets()
        For Each mset As MTGSet In sets

            getPrices(mset.setcode, mset.cardnumber)

        Next


    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cardlist">The list of cards to sell</param>
    ''' <param name="pset">The set of those cards</param>
    ''' <param name="runtim">true to query the web, false to read the database. When we query the website we suspend 30 seconds every 5 cards.</param>
    ''' <remarks></remarks>
    Public Sub findBots(cardlist() As String, pset As String, runtim As Boolean, output As RichTextBox, pblacklist As RichTextBox)
        blacklist = New List(Of String)(pblacklist.Lines)
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

        If cardlist Is Nothing Then output.AppendText("cardlist empty" & vbNewLine) : Exit Sub
        If database Is Nothing Then output.AppendText("database empty" & vbNewLine) : Exit Sub

        Dim cardnumber As Integer
        Dim counter As Integer = 1
        For Each card As String In cardlist

            If counter Mod 9 = 0 Then Threading.Thread.Sleep(30 * 1000)

            card = card.Substring(card.IndexOf(" ") + 1)

            If Not database.ContainsKey(card) Then output.AppendText("card not found:" & card & vbNewLine) : Continue For

            cardnumber = database(card)
            output.AppendText(estraiLowHighAsString(pset, cardnumber))
            output.AppendText(vbNewLine)
            output.Refresh()
            counter += 1

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

            If i Mod 9 = 0 Then Threading.Thread.Sleep(30 * 1000)
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
        Dim cardname, seller As String
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
                        seller = getName(tmpline)
                        While Not hasTickets(tmpline) OrElse blacklist.Contains(seller)
                            tmpline = sr.ReadLine
                            tmpline = sr.ReadLine
                            seller = getName(tmpline)
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

        Dim filepath As String = foldername & cardnumber & ".html"
        Dim tmpfile As New FileInfo(filepath)
        If tmpfile.Exists Then tmpfile.Delete()

        My.Computer.Network.DownloadFile(url, filepath)

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

        Dim filepath As String = nomecarta + ".html"
        Dim tmpfile As New FileInfo(filepath)
        If tmpfile.Exists Then tmpfile.Delete()

        My.Computer.Network.DownloadFile(url, filepath)


        Return nomecarta + ".html"
    End Function


    Private Function generateSets() As ICollection(Of MTGSet)

        Dim ret As New List(Of MTGSet)
        ret.Add(New MTGSet("BNG", 165))
        ret.Add(New MTGSet("THS", 249))
        ret.Add(New MTGSet("M14", 249))
        ret.Add(New MTGSet("DGM", 156))
        ret.Add(New MTGSet("GTC", 249))
        ret.Add(New MTGSet("RTR", 274))
        ret.Add(New MTGSet("M13", 249))
        ret.Add(New MTGSet("AVR", 244))
        ret.Add(New MTGSet("DKA", 158))
        ret.Add(New MTGSet("ISD", 264))
        ret.Add(New MTGSet("M12", 249))
        ret.Add(New MTGSet("NPH", 175))
        ret.Add(New MTGSet("MBS", 155))
        ret.Add(New MTGSet("SOM", 249))
        ret.Add(New MTGSet("M11", 249))
        ret.Add(New MTGSet("ROE", 248))
        ret.Add(New MTGSet("WWK", 145))
        ret.Add(New MTGSet("ZEN", 249))
        ret.Add(New MTGSet("M10", 249))
        ret.Add(New MTGSet("ARB", 145))
        ret.Add(New MTGSet("CON", 145))
        ret.Add(New MTGSet("ALA", 249))
        ret.Add(New MTGSet("EVE", 180))
        ret.Add(New MTGSet("SHM", 301))
        ret.Add(New MTGSet("MOR", 150))
        ret.Add(New MTGSet("LRW", 301))
        ret.Add(New MTGSet("10E", 383))
        ret.Add(New MTGSet("FUT", 180))
        ret.Add(New MTGSet("PLC", 165))
        ret.Add(New MTGSet("TSP", 370))
        ret.Add(New MTGSet("CSP", 155))
        ret.Add(New MTGSet("DIS", 180))
        ret.Add(New MTGSet("GPT", 165))
        ret.Add(New MTGSet("RAV", 306))
        ret.Add(New MTGSet("SOK", 165))
        ret.Add(New MTGSet("CHK", 306))
        ret.Add(New MTGSet("DST", 165))
        ret.Add(New MTGSet("MRD", 306))
        ret.Add(New MTGSet("SCG", 143))
        ret.Add(New MTGSet("LGN", 145))
        ret.Add(New MTGSet("ONS", 350))
        ret.Add(New MTGSet("JUD", 143))
        ret.Add(New MTGSet("TOR", 143))
        ret.Add(New MTGSet("OD", 350))
        ret.Add(New MTGSet("PS", 143))
        ret.Add(New MTGSet("IN", 350))
        ret.Add(New MTGSet("AP", 143))
        ret.Add(New MTGSet("BOK", 165))
        ret.Add(New MTGSet("9ED", 359))
        ret.Add(New MTGSet("8ED", 357))
        ret.Add(New MTGSet("7E", 350))
        ret.Add(New MTGSet("5DN", 165))

        Return ret


    End Function

End Class
