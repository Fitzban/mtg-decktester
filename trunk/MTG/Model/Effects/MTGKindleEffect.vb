Public Class MTGKindleEffect
    Implements IMTGCardEffect

    ''' <summary>
    ''' It deals damage equals to 2 + the number of Kindle in the cemetery
    ''' </summary>
    ''' <param name="playground"></param>
    ''' <remarks></remarks>
    Public Sub applyOn(playground As MTGPlayGround) Implements IMTGCardEffect.applyOn

        Dim otherkindles As IEnumerable(Of MTGCard) = playground.grimory.getCardsByNAme("Kindle")

        For Each c As MTGCard In otherkindles
            c.damage += 2
        Next

    End Sub

End Class
