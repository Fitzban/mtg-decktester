Public Class MTGDeckBuilder

    ''' <summary>
    ''' takes 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function buildDeck(mountainsn As Integer, cardsn As Integer, mcards As IMTGCardsSet) As IMTGDeck

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

End Class
