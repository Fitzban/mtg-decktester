Imports System.Text

Public Class Form1

    Public cards As New MTGCardSet
    Public mdeck As IMTGDeck

    ''' <summary>
    ''' Loads the library
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim test As New LinkedList(Of MTGMatchResult)

        loadCards()
        mdeck = buildDeck(19, 60, cards)


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


        loadCards()
        mdeck = buildDeck(19, 60, cards)
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

    Private Sub loadCards()
        cards.Add(New MTGCard("Incinerate", 3, 2))
        cards.Add(New MTGCard("Incinerate", 3, 2))
        cards.Add(New MTGCard("Incinerate", 3, 2))
        cards.Add(New MTGCard("Incinerate", 3, 2))
        cards.Add(New MTGCard("Magma Jet", 2, 2))
        cards.Add(New MTGCard("Magma Jet", 2, 2))
        cards.Add(New MTGCard("Magma Jet", 2, 2))
        cards.Add(New MTGCard("Magma Jet", 2, 2))
        cards.Add(New MTGCard("Lightning Bolt", 3, 1))
        cards.Add(New MTGCard("Lightning Bolt", 3, 1))
        cards.Add(New MTGCard("Lightning Bolt", 3, 1))
        cards.Add(New MTGCard("Lightning Bolt", 3, 1))
        cards.Add(New MTGCard("Price of Progress", 2, 2))
        cards.Add(New MTGCard("Price of Progress", 2, 2))
        cards.Add(New MTGCard("Price of Progress", 2, 2))
        cards.Add(New MTGCard("Price of Progress", 2, 2))
        cards.Add(New MTGCard("Chain Lightning", 3, 1))
        cards.Add(New MTGCard("Chain Lightning", 3, 1))
        cards.Add(New MTGCard("Chain Lightning", 3, 1))
        cards.Add(New MTGCard("Chain Lightning", 3, 1))
        cards.Add(New MTGCard("Barbarian Ring", 2, 1))
        cards.Add(New MTGCard("Barbarian Ring", 2, 1))
        cards.Add(New MTGCard("Barbarian Ring", 2, 1))
        cards.Add(New MTGCard("Barbarian Ring", 2, 1))
        cards.Add(New MTGCard("Rift Bolt", 3, 1))
        cards.Add(New MTGCard("Rift Bolt", 3, 1))
        cards.Add(New MTGCard("Rift Bolt", 3, 1))
        cards.Add(New MTGCard("Rift Bolt", 3, 1))
        cards.Add(New MTGCard("Flamebreak", 3, 3))
        cards.Add(New MTGCard("Flamebreak", 3, 3))
        cards.Add(New MTGCard("Flamebreak", 3, 3))
        cards.Add(New MTGCard("Flamebreak", 3, 3))
        cards.Add(New MTGCard("Lava Spike", 3, 1))
        cards.Add(New MTGCard("Lava Spike", 3, 1))
        cards.Add(New MTGCard("Lava Spike", 3, 1))
        cards.Add(New MTGCard("Lava Spike", 3, 1))
        cards.Add(New MTGCard("Fireblast", 4, 2))
        cards.Add(New MTGCard("Fireblast", 4, 2))
        cards.Add(New MTGCard("Fireblast", 4, 2))
        cards.Add(New MTGCard("Fireblast", 4, 2))
        cards.Add(New MTGCard("Firebolt", 2, 1))
        cards.Add(New MTGCard("Firebolt", 2, 1))
        cards.Add(New MTGCard("Firebolt", 2, 1))
        cards.Add(New MTGCard("Firebolt", 2, 1))
        cards.Add(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.Add(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.Add(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.Add(New MTGCard("Flames of the Blood Hand", 4, 3))
        cards.Add(New MTGCard("Volcanic Fallout", 3, 2))
        cards.Add(New MTGCard("Volcanic Fallout", 3, 2))
        cards.Add(New MTGCard("Volcanic Fallout", 3, 2))
        cards.Add(New MTGCard("Volcanic Fallout", 3, 2))
        cards.Add(New MTGCard("Burst Lightning", 2, 1))
        cards.Add(New MTGCard("Burst Lightning", 2, 1))
        cards.Add(New MTGCard("Burst Lightning", 2, 1))
        cards.Add(New MTGCard("Burst Lightning", 2, 1))
        cards.Add(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.Add(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.Add(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.Add(New MTGCard("Sulfuric Vortex", 2, 3))
        cards.Add(New MTGCard("Chain of Plasma", 3, 2))
        cards.Add(New MTGCard("Chain of Plasma", 3, 2))
        cards.Add(New MTGCard("Chain of Plasma", 3, 2))
        cards.Add(New MTGCard("Chain of Plasma", 3, 2))
        cards.Add(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.Add(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.Add(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.Add(New MTGCard("Pyrostatic Pillar", 2, 3))
        cards.Add(New MTGCard("Flame Rift", 4, 2))
        cards.Add(New MTGCard("Flame Rift", 4, 2))
        cards.Add(New MTGCard("Flame Rift", 4, 2))
        cards.Add(New MTGCard("Flame Rift", 4, 2))
    End Sub
End Class

