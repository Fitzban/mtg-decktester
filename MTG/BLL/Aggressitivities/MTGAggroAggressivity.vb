Public Class MTGAggroAggressivity
    Implements IMTGAggressivity


    Public Function getDamage(turn As IMTGTurn) As Integer Implements IMTGAggressivity.getDamage
        Return turn.turnnumber
    End Function
End Class
