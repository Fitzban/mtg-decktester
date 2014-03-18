Public Class MTGLastTurn
    Inherits MTGTurn

    Sub New(PV As Integer, mturnnumber As Integer)
        endingPV = PV
        pturnnumber = mturnnumber
    End Sub

    Public endingPV As Integer


    Public Overrides Function ToString() As String
        If endingPV > 0 Then MyBase.lost = True : Return "LOST!!!"
        Return "turn#: " + pturnnumber.ToString + " ----- PV: " + endingPV.ToString
    End Function

    
End Class
