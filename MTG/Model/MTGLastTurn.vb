Public Class MTGLastTurn
    Inherits MTGTurn

    Sub New(PV As Integer, mturnnumber As Integer)
        endingPV = PV
        pturnnumber = mturnnumber
        If endingPV > 0 Then MyBase.lost = True
    End Sub

    Public endingPV As Integer


    Public Overrides Function ToString() As String
        If MyBase.lost Then Return "LOST!!! " & pturnnumber.ToString & " ----- PV: " & endingPV.ToString
        Return "turn#: " + pturnnumber.ToString + " ----- PV: " + endingPV.ToString
    End Function

    
End Class
