Imports System.Text

Public Class MTGMatchResult

    Public turns As New LinkedList(Of IMTGTurn)
    Public turn As Integer ' when most probably wins
    Public percentage As Integer
    Public deck As String ' deck 

    ReadOnly Property result As String
        Get
            Dim ret As New StringBuilder
            For Each turn As IMTGTurn In turns
                ret.AppendLine(turn.ToString)
                ret.AppendLine(" ")
            Next

            Return ret.ToString
        End Get
    End Property


End Class
