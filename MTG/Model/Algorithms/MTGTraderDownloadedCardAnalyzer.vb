Public Class MTGTraderDownloadedCardAnalyzer

    Public Sub analyze(paths() As String, output As RichTextBox)

        If paths Is Nothing Then Exit Sub

        For i As Integer = 0 To paths.Length - 1


            output.AppendText((i + 1).ToString)

            Dim tmpline, cardname As String
            Dim line_index As Integer = 0
            Using sr As New IO.StreamReader(paths(i))


                Do Until sr.EndOfStream

                    tmpline = sr.ReadLine
                    line_index += 1

                    ' go to the card name
                    If line_index = 64 Then
                        cardname = tmpline
                        cardname = cardname.Replace("<title>", "")
                        cardname = cardname.Replace("</title>", "")
                        cardname = cardname.Replace("&#039;", "'")

                        output.AppendText("," & cardname)
                        output.AppendText(vbNewLine)

                    End If

                    Continue Do

                Loop

            End Using



        Next


    End Sub

End Class
