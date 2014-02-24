Public Class MTGDestroyYourLandEffect
    Implements IMTGCardEffect

    Private _howmany As Integer = 1
    Sub New(howmany As Integer)
        _howmany = howmany
    End Sub


    ''' <summary>
    ''' Destroy 'howmany' of the lands in game.
    ''' </summary>
    ''' <param name="playground"></param>
    ''' <remarks></remarks>
    Public Sub applyOn(playground As MTGPlayGround) Implements IMTGCardEffect.applyOn
        Dim landsingame As IEnumerable(Of MTGCard) = From card As MTGCard In playground.cardsingame Select card Where card.island

        
        For Each land As MTGCard In landsingame

            playground.cardsingame.Remove(land)
            playground.cemetery.AddLast(land)
            _howmany -= 1

            If _howmany = 0 Then Exit For

        Next


    End Sub
End Class
