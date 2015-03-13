Imports System.Text

Public Class MTGCardSet
    Implements IMTGCardsSet



    Sub New()
        _library = New LinkedList(Of MTGCard)
    End Sub

    

    Public Function take(num As Integer) As LinkedList(Of MTGCard) Implements IMTGCardsSet.take
        Dim ret As New LinkedList(Of MTGCard)(_library.Take(num).ToList)
        Return ret
    End Function

    

    Public Overridable ReadOnly Property count_cards As Integer Implements IMTGCardsSet.count_cards
        Get
            Return _library.Count
        End Get
    End Property

    Public ReadOnly Property library1 As System.Collections.Generic.LinkedList(Of MTGCard) Implements IMTGCardsSet.library
        Get
            Return _library
        End Get
    End Property



End Class
