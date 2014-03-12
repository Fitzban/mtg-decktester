Public Class MTGBurnAggressivity
    Implements IMTGAggressivity


    Public Function getDamage(turn As IMTGTurn) As Integer Implements IMTGAggressivity.getDamage
        Select Case turn.turnnumber
            Case 1
                Return 2
            Case 2
                Return 3
            Case 3, 4, 5
                Return 4
            Case Else
                Return 3
        End Select
    End Function
End Class
