Imports System.Text

Public Class Form1

    Public db As New MTGCardsDatabase
    Public mdeck As IMTGDeck

    ''' <summary>
    ''' Loads the library
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim test As New LinkedList(Of MTGMatchResult)

        mdeck = buildDeck(19, 60, db.cards)
        deck.Text = mdeck.ToString
        Me.Refresh()

        For index = 1 To Integer.Parse(MaskedTextBox1.Text)

            mdeck.shuffle()

            mdeck.algorithm = New BurnPlayalgorithms
            Dim result As MTGMatchResult = mdeck.play
            test.AddLast(result)

        Next

        Dim counts(6) As Integer
        For Each r As MTGMatchResult In test

            counts(r.turns(0).turnnumber) += 1

        Next

        Dim ret As New StringBuilder
        ret.AppendLine("chiusure di terzo: " + counts(3).ToString)
        ret.AppendLine("chiusure di quarto: " + counts(4).ToString)
        ret.AppendLine("chiusure di quinto: " + counts(5).ToString)
        ret.AppendLine("chiusure di sesto: " + counts(6).ToString)

        RichTextBox1.Text = ret.ToString

    End Sub

    ''' <summary>
    ''' Main algorithm.
    ''' 1) build a deck
    ''' 2) play the deck 100 times
    ''' 3) store the stats
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click


        mdeck = buildDeck(19, 60, db.cards)
        mdeck.shuffle()
        deck.Text = mdeck.ToString
        Me.Refresh()

        mdeck.algorithm = New BurnPlayalgorithms
        Dim result As MTGMatchResult = mdeck.play

        RichTextBox1.Text = result.result

    End Sub

    ''' <summary>
    ''' takes 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function buildDeck(mountainsn As Integer, cardsn As Integer, mcards As IMTGCardsSet) As IMTGDeck

        Dim ret As New MTGDeck
        Dim x As Integer = mountainsn

        ' add the lands
        While x > 0
            ret.Add(New MTGCard("Mountain", 0, 0, True))
            x -= 1
        End While

        ' add the cards
        Dim sourceries As Integer = cardsn - mountainsn

        ret.addRange(mcards.take(sourceries).ToList)


        Return ret

    End Function

    

    Private Function buildCapodanno() As IMTGDeck
        Dim ret As New MTGDeck
        Dim x As Integer = 20

        ' add the lands
        While x > 0
            ret.Add(New MTGCard("Mountain", 0, 0, True))
            x -= 1
        End While

        ' add the cards
        Dim sourceries As Integer = 40

        ret.Add(New MTGCard("fulmine", 3, 1))
        ret.Add(New MTGCard("fulmine", 3, 1))
        ret.Add(New MTGCard("fulmine", 3, 1))
        ret.Add(New MTGCard("fulmine", 3, 1))

        ret.Add(New MTGCard("chain lightning", 3, 1))
        ret.Add(New MTGCard("chain lightning", 3, 1))
        ret.Add(New MTGCard("chain lightning", 3, 1))
        ret.Add(New MTGCard("chain lightning", 3, 1))

        ret.Add(New MTGCard("incinerate", 3, 2))
        ret.Add(New MTGCard("incinerate", 3, 2))
        ret.Add(New MTGCard("incinerate", 3, 2))
        ret.Add(New MTGCard("incinerate", 3, 2))

        ret.Add(New MTGCard("firebolt", 2, 1))
        ret.Add(New MTGCard("firebolt", 2, 1))
        ret.Add(New MTGCard("firebolt", 2, 1))
        ret.Add(New MTGCard("firebolt", 2, 1))

        ret.Add(New MTGCard("flame rift", 1, 1))
        ret.Add(New MTGCard("flame rift", 1, 1))
        ret.Add(New MTGCard("flame rift", 1, 1))
        ret.Add(New MTGCard("flame rift", 1, 1))

        ret.Add(New MTGCard("chain of plasma", 3, 2))
        ret.Add(New MTGCard("chain of plasma", 3, 2))
        ret.Add(New MTGCard("chain of plasma", 3, 2))
        ret.Add(New MTGCard("chain of plasma", 3, 2))

        ret.Add(New MTGCard("magma jet", 2, 2))
        ret.Add(New MTGCard("magma jet", 2, 2))
        ret.Add(New MTGCard("magma jet", 2, 2))
        ret.Add(New MTGCard("magma jet", 2, 2))

        ret.Add(New MTGCard("rift bolt", 3, 1))
        ret.Add(New MTGCard("rift bolt", 3, 1))
        ret.Add(New MTGCard("rift bolt", 3, 1))
        ret.Add(New MTGCard("rift bolt", 3, 1))

        ret.Add(New MTGCard("lava spike", 3, 1))
        ret.Add(New MTGCard("lava spike", 3, 1))
        ret.Add(New MTGCard("lava spike", 3, 1))
        ret.Add(New MTGCard("lava spike", 3, 1))

        ret.Add(New MTGCard("burst lightning", 2, 1))
        ret.Add(New MTGCard("burst lightning", 2, 1))
        ret.Add(New MTGCard("burst lightning", 2, 1))
        ret.Add(New MTGCard("burst lightning", 2, 1))

        Return ret
    End Function

    Private Function takeordered() As IMTGDeck
        Dim ret As New MTGDeck
        Dim x As Integer = 20

        ' add the lands
        While x > 0
            ret.Add(New MTGCard("Mountain", 0, 0, True))
            x -= 1
        End While

        ' add the cards taking by rateo from the higest
        Dim sourceries As Integer = 40
        Dim pick As List(Of MTGCard) = (From y As MTGCard In db.cards.library.AsEnumerable Select y Order By y.rateo Descending).Take(sourceries).ToList
        ret.addRange(pick)

        Return ret
    End Function

    ''' <summary>
    ''' Takes the cards ordered by rateo descending.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        deck.Text = ""
        deck.Refresh()
        Dim test As New LinkedList(Of MTGMatchResult)

        mdeck = takeordered()
        deck.Text = mdeck.ToString
        Me.Refresh()

        For index = 1 To Integer.Parse(MaskedTextBox1.Text)

            mdeck.shuffle()

            mdeck.algorithm = New BurnPlayalgorithms
            Dim result As MTGMatchResult = mdeck.play
            test.AddLast(result)

        Next

        Dim counts(6) As Integer
        For Each r As MTGMatchResult In test

            counts(r.turns(0).turnnumber) += 1

        Next

        Dim ret As New StringBuilder
        ret.AppendLine("chiusure di terzo: " + counts(3).ToString)
        ret.AppendLine("chiusure di quarto: " + counts(4).ToString)
        ret.AppendLine("chiusure di quinto: " + counts(5).ToString)
        ret.AppendLine("chiusure di sesto: " + counts(6).ToString)

        RichTextBox1.Text = ret.ToString
    End Sub

    ''' <summary>
    ''' THis will generate 100 decks random and will test them 1000 of times. Will give back the best as percentage of victories.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim results As New MTGMatchResult
        results.percentage = Integer.MinValue
        results.turn = Integer.MaxValue
        
        For index = 1 To 5000

            ' build the deck
            Dim mdeck As IMTGDeck = buildDeck(19, 60, db.cards)
            Me.Label1.Text = "test : " & index.ToString
            Me.Label1.Refresh()

            mdeck.algorithm = New BurnPlayalgorithms

            Dim test As New LinkedList(Of MTGMatchResult)

            ' test it
            For index2 = 1 To 250

                mdeck.shuffle()

                Dim result As MTGMatchResult = mdeck.play
                test.AddLast(result)

            Next

            ' read the results
            Dim counts(6) As Integer
            For Each r As MTGMatchResult In test

                counts(r.turns(0).turnnumber) += 1

            Next

            Dim ret As New StringBuilder
            '' store the maximum victories
            Dim percentage As Integer = counts(3) * 8 + counts(4) * 4 + counts(5) * 2 + counts(6)
            If results.percentage < percentage Then

                results.percentage = percentage
                ret.AppendLine("chiusure di terzo: " + counts(3).ToString)
                ret.AppendLine("chiusure di quarto: " + counts(4).ToString)
                ret.AppendLine("chiusure di quinto: " + counts(5).ToString)
                ret.AppendLine("chiusure di sesto: " + counts(6).ToString)
                ret.AppendLine()
                ret.AppendLine(mdeck.ToString)

                results.deck = ret.ToString
                Me.deck.Text = results.deck
                Me.deck.Refresh()

            End If

            ret = New StringBuilder
            ret.AppendLine("chiusure di terzo: " + counts(3).ToString)
            ret.AppendLine("chiusure di quarto: " + counts(4).ToString)
            ret.AppendLine("chiusure di quinto: " + counts(5).ToString)
            ret.AppendLine("chiusure di sesto: " + counts(6).ToString)
            ret.AppendLine()
            ret.AppendLine(mdeck.ToString)
            RichTextBox1.Text = ret.ToString
            RichTextBox1.Refresh()
        Next

        Me.RichTextBox1.Text = results.turn & " ---  " & results.percentage
        Me.deck.Text = results.deck

    End Sub
End Class

