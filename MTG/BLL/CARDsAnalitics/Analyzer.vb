Imports System.Text

Namespace Cards.Analyzer

    ''' <summary>
    ''' This class takes all the decks found in a folder and counts the cards used.
    ''' Then it splashes on screen some details in a sortable list.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Analyzer

        Private _output As TextBox
        Private _jsondb As New MTGJson
        Sub New(ByVal outputbox As TextBox)
            _output = outputbox
            _output.Text = "Analyzer created"
        End Sub

        Public Sub analyze(ByVal folderpath As String, output As RichTextBox, Optional ByVal treshold As Integer = 0)

            _output.Text = "Starting..."

            ' read the decks (deckname,decktext)
            Dim decklist As Dictionary(Of String, String) = readDecks(folderpath)

            ' extract the cards (deckname, (cardname, quantity))
            Dim cardsindecks As Dictionary(Of String, Dictionary(Of MagicJason, Integer)) = extractCards(decklist)

            ' extract the words (deckname, (word, occourrences))
            Dim deckwordsmap As Dictionary(Of String, Dictionary(Of String, Integer)) = extractWords(cardsindecks)

            ' fill the output map
            Dim tmp As New StringBuilder

            For Each deck As String In deckwordsmap.Keys

                ' first line deckname + differect words count
                tmp.AppendLine()
                tmp.Append(deck)
                tmp.Append(" : different words ")
                tmp.AppendLine(deckwordsmap(deck).Keys.Count.ToString)
                Dim count As Integer = 0
                For Each w As String In deckwordsmap(deck).Keys
                    If deckwordsmap(deck)(w) < treshold Then Continue For
                    tmp.Append(vbTab)
                    tmp.Append(w.Replace(vbNewLine, ""))
                    tmp.Append(" (")
                    tmp.Append(deckwordsmap(deck)(w).ToString)
                    tmp.Append(") ")
                    count += 1
                    If count = 10 Then
                        tmp.AppendLine()
                        count = 0
                    End If
                Next

            Next

            output.Text = tmp.ToString
        End Sub

        ''' <summary>
        ''' This takes the deck files in the folder and prepare a map (deckname,decktext)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>ö
        Private Function readDecks(folderpath As String) As Dictionary(Of String, String)

            Dim ret As New Dictionary(Of String, String)
            If String.IsNullOrEmpty(folderpath) Then Return ret

            Dim folder As New System.IO.DirectoryInfo(folderpath)
            If Not folder.Exists Then Return ret

            For Each file As IO.FileInfo In folder.EnumerateFiles

                Dim s As New System.IO.StreamReader(file.OpenRead)
                Dim data As String = s.ReadToEnd()
                s.Close()

                ret(file.Name) = data

            Next

            Return ret

        End Function


        ''' <summary>
        ''' This loops on the decks and prepare a structure like (deckname, (jsoncard,occurrences))
        ''' </summary>
        ''' <param name="decklist"></param>
        ''' <returns>(deckname, (cardname, quantity))</returns>
        ''' <remarks></remarks>
        Private Function extractCards(decklist As Dictionary(Of String, String)) As Dictionary(Of String, Dictionary(Of MagicJason, Integer))

            Dim ret As New Dictionary(Of String, Dictionary(Of MagicJason, Integer))
            If decklist Is Nothing Then Return ret

            For Each deck As String In decklist.Keys

                ret.Add(deck, New Dictionary(Of MagicJason, Integer))
                Dim text As String = decklist(deck)
                Dim lines As String() = text.Split(CChar(vbNewLine))
                For Each line As String In lines

                    If String.IsNullOrEmpty(line.Trim) Then Continue For ' empty line to divide the deck from the side

                    Dim quantity As Integer = Integer.Parse(line.Substring(0, line.IndexOf(" ")))
                    Dim cardname As String = line.Substring(line.IndexOf(" ") + 1)
                    If Not _jsondb.cardnameIndex.Keys.Contains(cardname) Then Continue For

                    If Not ret(deck).Keys.Contains(_jsondb.cardnameIndex(cardname)) Then
                        ' the deck
                        ret(deck).Add(_jsondb.cardnameIndex(cardname), quantity)
                    Else
                        ' the sideboard
                        ret(deck)(_jsondb.cardnameIndex(cardname)) = ret(deck)(_jsondb.cardnameIndex(cardname)) + quantity
                    End If


                Next

            Next

            Return ret

        End Function


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="cardsindeck"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function extractWords(cardsindeck As Dictionary(Of String, Dictionary(Of MagicJason, Integer))) As Dictionary(Of String, Dictionary(Of String, Integer))

            Dim ret As New Dictionary(Of String, Dictionary(Of String, Integer))
            If cardsindeck Is Nothing Then Return ret

            For Each deck As String In cardsindeck.Keys

                ret(deck) = New Dictionary(Of String, Integer)
                For Each card As MagicJason In cardsindeck(deck).Keys

                    If card.rarity = "Basic Land" Then Continue For
                    Dim cardtext As String = card.text
                    cardtext = cardtext.Replace("(Each card you exile from your graveyard while casting this spell pays for {1}.)", "")
                    cardtext = cardtext.Replace(".", " ")
                    cardtext = cardtext.Replace(vbNewLine, " ")
                    cardtext = cardtext.Replace(vbLf, " ")

                    Dim quantity As Integer = cardsindeck(deck)(card)
                    Dim words As String() = cardtext.Split(CChar(" "))
                    For Each w As String In words

                        w = w.Trim
                        If String.IsNullOrEmpty(w) Then Continue For

                        If Not ret(deck).Keys.Contains(w) Then

                            ret(deck).Add(w, quantity)

                        Else

                            ret(deck)(w) = ret(deck)(w) + quantity

                        End If

                    Next

                Next

            Next

            Return ret

        End Function

    End Class


End Namespace