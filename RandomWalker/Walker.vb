Imports RndNorm
Imports System.IO
' Walker
'Direction:
' NW = 1
' N  = 2
' NW = 3
' E  = 4
' SE = 5
' S  = 6
' SW = 7
' W  = 8
Public Class Walker
    Public X As Integer
    Public Y As Integer
    Public KnowledgeWorld As World
    Public Direction As Integer
    Public JumpNum As Integer = 0
    Public Temperature As Integer    '' Temperature determines the amount of random step
    Public typeIndex As Integer
    Public Temper As Integer
    Public rnd As Random
    Public Distance As Double = 0
    Public Steps = 1
    Private totalNumDie As Integer
    Private OrderDirR As Boolean = True
    Private OrderNextLine As Boolean = False
    Private rndNorm As RndNormGen
    Public Sub New(ByVal _x As Integer, ByVal _y As Integer, ByVal _dir As Integer, ByRef _world As World)
        X = _x
        Y = _y
        KnowledgeWorld = _world
        Direction = _dir
        Temperature = 1
        typeIndex = KnowledgeWorld.Types - 1
        rnd = New Random()
        totalNumDie = (KnowledgeWorld.Width * KnowledgeWorld.Height)
        rndNorm = New RndNormGen(typeIndex + 1, 2, totalNumDie)
    End Sub
    Public Sub RandomXY()
        Dim rndX = rnd.Next(KnowledgeWorld.Width)
        Dim rndY = rnd.Next(KnowledgeWorld.Height)
        X = rndX
        Y = rndY
        'Console.WriteLine($"({rndX}, {rndY})")
    End Sub
    ''choose a random direction
    Public Sub RandomDir()
        Dim rndDir = rnd.Next(9)
        Direction = rndDir
        'Console.WriteLine($"{rndDir}")
    End Sub

    Public Sub RandomRePosition()
        If rnd.Next(KnowledgeWorld.CurReserveTotal) < 400 Then
            RandomXY()
            JumpNum += 1
            'Console.WriteLine($"reposition at reserveTotal({KnowledgeWorld.CurReserveTotal})")
        End If
    End Sub

    Public Sub MapFill()
        Dim pathFind = New PathFinder(KnowledgeWorld.Width, KnowledgeWorld.Height)
        pathFind.ReadFile($"C:\test\RW\PathFinder\sample\{KnowledgeWorld.Width}x{KnowledgeWorld.Height}_{KnowledgeWorld.Types}.txt")
        pathFind.CreateBinList()
        pathFind.GetCoordinateFromFile()

        'For x As Integer = 0 To KnowledgeWorld.Width - 1
        '    For y As Integer = 0 To KnowledgeWorld.Height - 1
        '        Me.X = x
        '        Me.Y = y
        '        Dim selection = pathFind.GetCoordinate(x, y) - 1
        '        KnowledgeWorld.SetType(x, y, selection + 1)
        '        UpdateWorld(selection)
        '    Next
        'Next

        For i As Integer = 0 To typeIndex
            X = 0
            Y = 0
            OrderDirR = True
            For x As Integer = 0 To KnowledgeWorld.Width - 1
                For y As Integer = 0 To KnowledgeWorld.Height - 1
                    ChangeWorldWithMap(pathFind, i)
                    MoveToNext()
                Next
            Next
        Next
    End Sub
    Private Sub ChangeWorldWithMap(ByRef pfinder As PathFinder, curTypeIndex As Integer)
        Dim selection = pfinder.GetCoordinate(X, Y) - 1

        If selection = curTypeIndex Then
            KnowledgeWorld.SetType(X, Y, curTypeIndex + 1)
            UpdateWorld(curTypeIndex)
        End If

    End Sub
    Public Sub MoveToNext()
        Steps = 1
        Dim stepOverFlowR As Integer = X + Steps
        Dim stepOverFlowL As Integer = X - Steps

        If stepOverFlowR > (KnowledgeWorld.Width - 1) And OrderDirR And (Y < KnowledgeWorld.Height - 1) Then
            Y += 1
            OrderDirR = False
        ElseIf stepOverFlowL < 0 And Not (OrderDirR) And (Y < KnowledgeWorld.Height - 1) Then
            Y += 1
            OrderDirR = True
        Else
            If OrderDirR And stepOverFlowR <= KnowledgeWorld.Width - 1 Then
                X += Steps
            ElseIf stepOverFlowL >= 0 Then
                X -= Steps
            End If
        End If
    End Sub

    Public Sub OrderFill()
        For i As Integer = typeIndex To 0 Step -1
            X = 0
            Y = 0
            For j As Integer = 0 To KnowledgeWorld.ReserveList(i).Size - 1
                OrderMove()
                ChangeWorldBasedOnLoop(i)
            Next
        Next
        'RevolverFill()
        'ProbabilityFill()
    End Sub

    Private Sub ProbabilityFill()
        Dim remaining() As Integer = New Integer(KnowledgeWorld.CurReserveTotal - 1) {}
        CreateProbArray(remaining)
        X = 0
        Y = 0

        For i As Integer = 0 To KnowledgeWorld.Height - 1
            X = 0
            For j As Integer = 0 To KnowledgeWorld.Width - 1
                PFillChangeWorld(remaining)
                'Console.WriteLine($"Cylinder: {cylinder}")
                X += 1
            Next
            Y += 1
        Next
    End Sub

    Private Sub CreateProbArray(ByRef remaining() As Integer)
        Dim nextLine As Integer = 0
        For i As Integer = 0 To typeIndex
            For j As Integer = 0 To KnowledgeWorld.ReserveList(i).Size - 1
                remaining(nextLine) = i + 1
            Next
            nextLine += KnowledgeWorld.ReserveList(i).Size
        Next
    End Sub

    Private Sub PFillChangeWorld(ByRef remaining() As Integer)
        Dim index = remaining(rnd.Next(0, KnowledgeWorld.CurReserveTotal - 1))
        Dim currentPos As Integer = KnowledgeWorld.GetCoor(X, Y)

        If currentPos = 0 Then
            For i As Integer = 0 To typeIndex

                If Not (KnowledgeWorld.ReserveList(index).Size <= 0) Then
                    KnowledgeWorld.SetType(X, Y, index + 1)
                    UpdateWorld(index)
                    Exit For
                Else

                End If
            Next
        End If
    End Sub

    Private Sub RevolverFill()
        X = 0
        Y = 0
        Dim cylinder As Integer = 0
        For i As Integer = 0 To KnowledgeWorld.Height - 1
            X = 0
            For j As Integer = 0 To KnowledgeWorld.Width - 1
                RevolverChangeWorld(cylinder)
                Roll(cylinder)
                'Console.WriteLine($"Cylinder: {cylinder}")
                X += 1
            Next
            Y += 1
        Next
    End Sub

    Private Sub Roll(ByRef cylinder As Integer)
        cylinder = (cylinder Mod typeIndex)
        cylinder += 1
    End Sub

    Private Sub RevolverChangeWorld(ByRef cylinder As Integer)
        Dim currentPos As Integer = KnowledgeWorld.GetCoor(X, Y)

        If currentPos = 0 Then
            For i As Integer = 0 To typeIndex

                If Not (KnowledgeWorld.ReserveList(cylinder).Size <= 0) Then
                    KnowledgeWorld.SetType(X, Y, cylinder + 1)
                    UpdateWorld(cylinder)
                    Exit For
                End If
                Roll(cylinder)
            Next
        End If




        'If Not (KnowledgeWorld.ReserveList(cylinder).Size <= 0) Then
        '    If currentPos = 0 Then
        '        KnowledgeWorld.SetType(X, Y, cylinder + 1)
        '        UpdateWorld(cylinder)
        '    End If
        'Else
        '    For i As Integer = 0 To 5
        '        If Not (KnowledgeWorld.ReserveList(cylinder).Size <= 0) And currentPos = 0 Then

        '        Else
        '            Roll(cylinder)
        '        End If
        '    Next

        'End If


    End Sub
    ''let walker random walk and random reposition and change world with order with 1 loop
    Public Sub RandomFill()
        RandomXY()
        RandomDir()
        For i As Integer = 0 To 1 * KnowledgeWorld.Width * KnowledgeWorld.Height - 1
            RandomMove()

            'walker.Distance += walker.Steps
            'walker.ChangeWorld()
            ChangeWorldWithOrder()

            RandomRePosition() 'random restart
        Next
    End Sub

    'move the walker's x, y position in a orderly manner with random steps
    Private Sub OrderMove()
        Dim binReserve = totalNumDie / typeIndex + 1

        Dim i As Integer = rndNorm.GetRnd()       '' random normal distribution mean = types, stdDev = 1, samplesize = totalnumdie
        If i <= 0 Then                            '' prevents negative steps
            i = 1
        End If
        Steps = i
        Dim stepOverFlowR As Integer = X + Steps
        Dim stepOverFlowL As Integer = X - Steps

        If stepOverFlowR > (KnowledgeWorld.Width - 1) And OrderDirR And (Y < KnowledgeWorld.Height - 1) Then
            Y += 1
            X = (KnowledgeWorld.Width - 1) - (stepOverFlowR - KnowledgeWorld.Width - 1) - 1
            OrderDirR = False
        ElseIf stepOverFlowL < 0 And Not (OrderDirR) And (Y < KnowledgeWorld.Height - 1) Then
            Y += 1
            X = -(stepOverFlowL + 1)
            OrderDirR = True
        Else
            If OrderDirR And X + Steps < KnowledgeWorld.Width - 1 Then
                X += Steps
            ElseIf X - Steps >= 0 Then
                X -= Steps
            End If
        End If
        'Console.WriteLine($"({X}, {Y})")
    End Sub

    'move the walker's x, y positiion 'steps' unit towards a random direction
    Private Sub RandomMove()
        Steps = rnd.Next(1, Temperature) ' Steps amount = random value between 1 and temperature
        RandomDir()
        Dim curX = X
        Dim curY = Y
        'Console.WriteLine(Direction)
        Select Case Direction
            Case 1
                If Not (X - Steps < 0 Or Y - Steps < 0) Then
                    X -= Steps
                    Y -= Steps
                Else
                    RandomMove()
                End If
            Case 2
                If Not (Y - Steps < 0) Then
                    Y -= Steps
                Else
                    RandomMove()
                End If
            Case 3
                If Not (X + Steps > KnowledgeWorld.Width - 1 Or Y - Steps < 0) Then
                    X += Steps
                    Y -= Steps
                Else
                    RandomMove()
                End If
            Case 4
                If Not (X + Steps > KnowledgeWorld.Width - 1) Then
                    X += Steps
                Else
                    RandomMove()
                End If
            Case 5
                If Not (X + Steps > KnowledgeWorld.Width - 1 Or Y + Steps > KnowledgeWorld.Height - 1) Then
                    X += Steps
                    Y += Steps
                Else
                    RandomMove()
                End If
            Case 6
                If Not (Y + Steps > KnowledgeWorld.Height - 1) Then
                    Y += Steps
                Else
                    RandomMove()
                End If
            Case 7
                If Not (X - Steps < 0 Or Y + Steps > KnowledgeWorld.Height - 1) Then
                    X -= Steps
                    Y += Steps
                Else
                    RandomMove()
                End If
            Case 8
                If Not (X - Steps < 0) Then
                    X -= Steps
                Else
                    RandomMove()
                End If
        End Select
        'Distance += Math.Abs(Math.Sqrt((X - curX) ^ 2 + (Y - curY) ^ 2))
        'Console.WriteLine(Distance)
        'Console.WriteLine($"({X}, {Y})")
    End Sub

    'If the world has not been changed yet, Select a random value from the remaining avaliable types
    'and set it in the world at the walker's position
    Public Sub ChangeWorld()
        Dim currentPos As Integer = KnowledgeWorld.GetCoor(X, Y)

        If currentPos = 0 Then
            Dim rndSelection = rnd.Next(KnowledgeWorld.Types)
            If Not (KnowledgeWorld.ReserveList(rndSelection).Size = 0) Then
                KnowledgeWorld.SetType(X, Y, rndSelection + 1)
                UpdateWorld(rndSelection)
                'Console.WriteLine("changeWorld")
            Else
                'Console.WriteLine($" reserve({rndSelection + 1}) size: {KnowledgeWorld.ReserveList(rndSelection).Size}")
            End If
        Else

            'Console.WriteLine($" walker pos: ({X}, {Y})")
        End If
    End Sub
    Public Sub ChangeWorldBasedOnLoop(ByVal TypNum As Integer)
        Dim currentPos As Integer = KnowledgeWorld.GetCoor(X, Y)

        If currentPos = 0 Then
            KnowledgeWorld.SetType(X, Y, TypNum + 1)
            UpdateWorld(TypNum)
        Else
            'RandomMove()    '' comment out with ordermove

        End If
    End Sub
    Public Sub ChangeWorldWithOrder()
        Dim currentPos As Integer = KnowledgeWorld.GetCoor(X, Y)

        If currentPos = 0 Then
            If Not (KnowledgeWorld.ReserveList(typeIndex).Size = 0) Then
                KnowledgeWorld.SetType(X, Y, typeIndex + 1)
                UpdateWorld(typeIndex)
            Else
                typeIndex -= 1
                KnowledgeWorld.SetType(X, Y, typeIndex + 1)
                UpdateWorld(typeIndex)
            End If

        Else
            'RandomMove()    '' comment out with ordermove

        End If
    End Sub

    ''update world: decrement reserve
    ''              decrement reserve total
    ''              update temperature value
    '' Temperature is the maximum amount of steps the walker can take 
    '' Temperature decreases as reserve decreases
    Private Sub UpdateWorld(ByVal typeIndex As Integer)
        KnowledgeWorld.ReserveList(typeIndex).Size -= 1
        KnowledgeWorld.CurReserveTotal -= 1
        Temperature = 10 * KnowledgeWorld.CurReserveTotal / totalNumDie
    End Sub


    Private Class PathFinder
        Private Coordinate()() As Integer
        Private charArray() As Char
        Private s As String = vbCrLf
        Private tempArray() As Char = s.ToCharArray
        Private NewLineChar1 As Char = tempArray(0)
        Private binList() As Integer
        Private Width As Integer
        Private Length As Integer

        Public Sub New(_width As Integer, _length As Integer)
            Width = _width
            Length = _length
            binList = New Integer(Width * Length) {}
            Coordinate = New Integer(_width)() {}

            For w As Integer = 0 To _width
                Coordinate(w) = New Integer(_length) {}
            Next

        End Sub

        Public ReadOnly Property GetCoordinate(_x As Integer, _y As Integer) As Integer
            Get
                Return Coordinate(_x)(_y)
            End Get
        End Property

        Public Sub CreateBinList()
            Dim binCounter As Integer = 0
            'Dim nonNewLineCounter As Integer = 0
            For i As Integer = 0 To charArray.Count - 1

                If charArray(i) = NewLineChar1 Then  '' If charArray(i) = new line char
                    Dim int As Integer
                    If charArray(i - 2) = "," Then
                        int = Convert.ToInt32(charArray(i - 1).ToString)
                    ElseIf charArray(i - 3) = "," Then
                        int = Convert.ToInt32(charArray(i - 2).ToString) * 10 + Convert.ToInt32(charArray(i - 1).ToString)
                    ElseIf charArray(i - 4) = "," Then
                        int = Convert.ToInt32(charArray(i - 3).ToString) * 100 + Convert.ToInt32(charArray(i - 2).ToString) * 10 + Convert.ToInt32(charArray(i - 1).ToString)
                    Else
                        int = 0
                    End If
                    binList(binCounter) = int
                    binCounter += 1
                    'ElseIf charArray(i) = NewLineChar2 Then

                Else
                    'Console.WriteLine(charArray(i))
                    'nonNewLineCounter += 1
                End If
                If i > 0 Then
                    'Console.WriteLine($"charArray({i}) = {charArray(i)}? -> binList({binCounter}) = {charArray(i - 1)}")
                End If
            Next
        End Sub

        Public Sub ReadFile(fileLoc As String)
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(fileLoc)
            charArray = fileReader.ToCharArray()
        End Sub

        Public Sub GetCoordinateFromFile()
            Dim binCounter As Integer = 0

            For x As Integer = 0 To Width - 1
                For y As Integer = 0 To Length - 1
                    Coordinate(x)(y) = binList(binCounter)
                    binCounter = binCounter + 1
                Next
            Next
        End Sub

        Public Sub WriteToFile(fileLoc As String)
            Using writer As StreamWriter = New StreamWriter(fileLoc)
                Dim binCounter = 0
                For i As Integer = 0 To Width - 1
                    For j As Integer = 0 To Length - 1
                        writer.WriteLine($"{i + 1},{j + 1},1, {binList(binCounter)}")
                        binCounter += 1
                    Next
                Next
            End Using
        End Sub
    End Class

End Class