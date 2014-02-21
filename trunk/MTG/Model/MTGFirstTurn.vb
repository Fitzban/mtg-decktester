Public Class MTGFirstTurn
    Implements IMTGTurn

    Private _base As New MTGTurn()
    Sub New(mdeck As IMTGDeck)
        
        _base.deck = mdeck
        
    End Sub

    Public ReadOnly Property playground As LinkedList(Of MTGCard)
        Get
            Return _base.playground
        End Get
    End Property

    Public ReadOnly Property cemetery As LinkedList(Of MTGCard)
        Get
            Return _base.cemetery
        End Get
    End Property

    Public ReadOnly Property hand As LinkedList(Of MTGCard)
        Get
            Return _base.hand
        End Get
    End Property


    Public Sub draw() Implements IMTGTurn.draw
        _base.draw()
        _base.draw()
        _base.draw()
        _base.draw()
        _base.draw()
        _base.draw()
        _base.draw()
    End Sub

    ''' <summary>
    ''' apertura si sceglie il mulligan.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property nextcardtoplay As MTGCard Implements IMTGTurn.nextcardtoplay
        Get
            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' apertura si sceglie il mulligan.
    ''' </summary>
    ''' <param name="card"></param>
    ''' <remarks></remarks>
    Public Sub play(card As MTGCard) Implements IMTGTurn.play

    End Sub

    ''' <summary>
    ''' apertura si sceglie il mulligan.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub playland() Implements IMTGTurn.playland

    End Sub

    Public Overrides Function ToString() As String
        Dim ret As New System.Text.StringBuilder

        ret.AppendLine("First turn")
        ret.AppendLine(_base.ToString)

        Return ret.ToString
    End Function
End Class
