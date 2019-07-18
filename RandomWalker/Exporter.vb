Imports System.IO

Public Class Exporter
    Private Data As World
    Public Sub New(ByRef _data As World)
        Data = _data
    End Sub

    Public Sub WriteData(ByVal fileLoc As String)
        'System.IO.File.WriteAllText(fileLoc, "")
        'For a As Integer = 0 To Data.Width - 1
        '    For b As Integer = 0 To Data.Height - 1
        '        WriteToFile(a + 1, b + 1, Data.Coordinate(a)(b), fileLoc)
        '    Next
        'Next

        Using writer As StreamWriter = New StreamWriter(fileLoc)
            For a As Integer = 0 To Data.Width - 1
                For b As Integer = 0 To Data.Height - 1
                    writer.WriteLine($"{a + 1},{b + 1},1,{Data.Coordinate(a)(b)}")
                Next
            Next
        End Using

    End Sub

    Private Sub WriteToFile(ByVal a As Integer, ByVal b As Integer, ByVal d As Integer, ByVal fileLoc As String)

        Using writer As StreamWriter = New StreamWriter(fileLoc)
            For i As Integer = 0 To Data.Height * Data.Width - 1
                writer.WriteLine($"{a},{b},1,{d}")
            Next
        End Using

        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter(fileLoc, True)
        'file.WriteLine($"{a},{b},1,{d}")
        ''Console.WriteLine($"{a},{b},1")
        'file.Close()
    End Sub
End Class