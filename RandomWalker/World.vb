Public Class World
    Public X As Integer
    Public Y As Integer
    Public Width As Integer
    Public Height As Integer
    Public Coordinate()() As Integer
    Public Types As Integer
    Public ReserveList() As Reserve
    Public CurReserveTotal As Integer
    Public WPR As WalkerPathRecorder
    Public Sub New(ByVal _width As Integer, ByVal _height As Integer, ByVal _types As Integer)
        Width = _width
        Height = _height
        Types = _types
        Coordinate = New Integer(Width)() {}
        ReserveList = New Reserve(Types) {}
        CurReserveTotal = Width * Height
        WPR = New WalkerPathRecorder(Width)
        For w As Integer = 0 To Width - 1
            Coordinate(w) = New Integer(Height) {}
        Next
        Dim size As Integer = Width * Height / Types

        For index As Integer = 0 To Types - 1
            Dim reserve = New Reserve(size)
            ReserveList(index) = reserve
        Next
    End Sub

    Public ReadOnly Property GetCoor(_x As Integer, _y As Integer) As Integer
        Get
            Return Coordinate(_x)(_y)
        End Get
    End Property
    'Public Function GetCoor(_x As Integer, _y As Integer)
    '    Return Coordinate(_x)(_y)
    'End Function

    Public Sub SetType(ByVal _x As Integer, ByVal _y As Integer, ByVal _type As Integer)
        Try
            Coordinate(_x)(_y) = _type
            WPR.RecordXY(_x, _y, _type)
        Catch ex As Exception
            Console.WriteLine($"World Set Type Exception: ({_x}, {_y})")
        End Try

        'Console.Write(_type)
    End Sub

    Public Sub PrintReserve()
        Dim total As Integer = 0
        For i As Integer = 0 To Types - 1
            Console.WriteLine($"reserve({i + 1}): {ReserveList(i).Size}")
            total += ReserveList(i).Size
        Next
        Console.WriteLine($"ReserveTotal: {total}")
    End Sub

    Public Sub PrintCoordinate()
        Console.Write("   ")
        For i As Integer = 0 To Height - 1
            Console.Write($"{i} ")
        Next
        Console.Write(vbCrLf)
        For i As Integer = 0 To Width - 1
            Console.Write($"{i} |")
            For j As Integer = 0 To Height - 1
                Console.Write($"{Coordinate(j)(i)} ")
            Next
            Console.Write(vbCrLf)
        Next

    End Sub
End Class
