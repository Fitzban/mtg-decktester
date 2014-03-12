Public Class MTGBurnVSAggroSimulation
    Implements IMTGSimulation

    Sub New()
        _mydeck = New MTGDeck
        _mydeck.algorithm = New BurnPlayalgorithms
        _mydeck.aggressivity = New MTGBurnAggressivity

        _opponent = New MTGDeck
        _opponent.algorithm = New MTGAggroAlgorithm
        _opponent.aggressivity = New MTGAggroAggressivity
    End Sub

    Private _mydeck As IMTGDeck
    Public ReadOnly Property mydeck As IMTGDeck Implements IMTGSimulation.mydeck
        Get
            Return _mydeck
        End Get
    End Property

    Private _opponent As IMTGDeck
    Public ReadOnly Property opponent As IMTGDeck Implements IMTGSimulation.opponent
        Get
            Return _opponent
        End Get
    End Property

    Private _match As MTGMatch
    Public ReadOnly Property match As MTGMatch Implements IMTGSimulation.match
        Get
            Return _match
        End Get
    End Property

    Private _matchresult As MTGMatchResult
    Public ReadOnly Property matchresult As MTGMatchResult Implements IMTGSimulation.matchresult
        Get
            Return _matchresult
        End Get
    End Property

    ''' <summary>
    ''' Will excecute turns one by one untill the first player dies.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub simulatematch() Implements IMTGSimulation.simulatematch

        _match = New MTGMatch
        _matchresult = New MTGMatchResult

        Dim mPV As Integer = 20
        Dim oppoPV As Integer = 20
        Dim hand As New LinkedList(Of MTGCard)
        hand.AddLast(_mydeck.draw())
        hand.AddLast(_mydeck.draw())
        hand.AddLast(_mydeck.draw())
        hand.AddLast(_mydeck.draw())
        hand.AddLast(_mydeck.draw())
        hand.AddLast(_mydeck.draw())
        hand.AddLast(_mydeck.draw())

        Dim turnnumber As Integer = 0
        Dim turn As MTGTurn = New MTGTurn(hand, New LinkedList(Of MTGCard), New LinkedList(Of MTGCard), _mydeck, turnnumber, 0)

        _matchresult.turns.AddLast(turn)
        _mydeck.shuffle()

        Do

            playturn(_matchresult.turns.LastOrDefault)
            If _matchresult.turns.LastOrDefault.totaldamage <= 0 Then Exit Do

            turn = New MTGTurn(hand, New LinkedList(Of MTGCard), New LinkedList(Of MTGCard), _mydeck, turnnumber, 0)

        Loop



    End Sub

    ''' <summary>
    ''' returns the damage done
    ''' </summary>
    ''' <param name="turn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function playturn(turn As IMTGTurn) As Integer

        turn = New MTGTurn(turn.playground.hand, turn.playground.cardsingame, turn.playground.cemetery, turn.deck, turn.turnnumber + 1, turn.totaldamage)

        ' draw
        turn.draw()

        ' play land
        turn.playland()

        ' pickup
        Dim cardtoplay As MTGCard = turn.nextcardtoplay

        While cardtoplay IsNot Nothing AndAlso turn.playground.availablelands >= cardtoplay.converted_cost

            turn.play(cardtoplay)
            cardtoplay = turn.nextcardtoplay

        End While

        _matchresult.turns.AddLast(turn)
        Return turn.damagedone
    End Function
End Class
