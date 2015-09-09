Namespace Cards.Analyzer

    Public Class AnalysyResult

        Public Property cardname As String
        Public Property cardtext As String
        Public Property cardvalue As String
        Public Property keywords As New LinkedList(Of String)

        Overrides Function toString() As String

            Dim keys As String = ""
            For Each k As String In keywords
                keys += ","
                keys += k
            Next

            Return cardname + vbTab + cardvalue + vbTab + keys

        End Function

    End Class

End Namespace