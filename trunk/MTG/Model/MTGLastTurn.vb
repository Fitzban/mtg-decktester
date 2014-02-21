Public Class MTGLastTurn
    Implements IMTGTurn


    Sub New(PV As Integer, mturnnumber As Integer)
        endingPV = PV
        pturnnumber = mturnnumber
    End Sub

    Public endingPV As Integer
    Public pturnnumber As Integer

    Public Overrides Function ToString() As String
        If endingPV > 0 Then Return "LOST!!!"
        Return "turn#: " + pturnnumber.ToString + " ----- PV: " + endingPV.ToString
    End Function

    Public Sub draw() Implements IMTGTurn.draw

    End Sub

    Public ReadOnly Property nextcardtoplay As MTGCard Implements IMTGTurn.nextcardtoplay
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property turnnumber1 As Integer Implements IMTGTurn.turnnumber
        Get
            Return pturnnumber
        End Get
    End Property

    Public Sub play(card As MTGCard) Implements IMTGTurn.play

    End Sub

    Public Sub playland() Implements IMTGTurn.playland

    End Sub
End Class
