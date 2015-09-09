Public Class MTGBaseAggressivity
    Implements IMTGAggressivity


    Public Function getDamage(turn As IMTGTurn) As Integer Implements IMTGAggressivity.getDamage

        Return 2

    End Function
End Class
