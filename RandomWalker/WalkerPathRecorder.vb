Imports System.IO

Public Class WalkerPathRecorder
    Public X
    Public Y
    Public Distance As Double = 0
    Public Coordinate()() As Integer
    Public Que As Queue
    Public Sub New(ByVal Width As Integer)
        Que = New Queue()
        Coordinate = New Integer(Width)() {}

    End Sub

    Public Sub RecordXY(ByVal _x As Integer, ByVal _y As Integer, ByVal _type As Integer)
        Que.Enqueue(New Tuple(_x, _y, _type))
    End Sub

    Public Sub WriteToFile(ByVal fileLoc As String)

        Using writer As StreamWriter = New StreamWriter(fileLoc)
            For Each element As Tuple In Que
                writer.WriteLine($"{element.X + 1},{element.Y + 1},1,{element.Types}")
            Next element
        End Using

    End Sub

    Public Function CalDistance() As Double

        While Que.Count > 1
            Dim curTuple = Que.Dequeue()
            Dim nextTuple = Que.Peek()
            Distance += Math.Abs(Math.Sqrt((curTuple.X - nextTuple.X) ^ 2 + (curTuple.Y - nextTuple.Y) ^ 2))
        End While
        Return Distance
    End Function

    Private Class Tuple
        Public X
        Public Y
        Public Types
        Public Sub New(ByVal _x As Integer, ByVal _y As Integer, ByVal _type As Integer)
            X = _x
            Y = _y
            Types = _type
        End Sub
    End Class
End Class