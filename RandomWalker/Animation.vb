Imports RenderJPG
Imports System.Drawing

Public Class Animation
    'animation will 
    Private Width As Integer
    Private Length As Integer
    Private Types As Integer
    Private Coordinate()() As Integer
    Private Aniworld As World
    Private FrameRate As Integer = 0
    Private FrameCounter As Integer = 0

    Public Sub New(_w As Integer, _l As Integer, _t As Integer, ByRef world As World, fps As Integer)
        Width = _w
        Length = _l
        Types = _t
        Aniworld = world
        FrameRate = fps
        'initialize coordinate
        Coordinate = New Integer(Width)() {}
        For w As Integer = 0 To Width - 1
            Coordinate(w) = New Integer(Length) {}
        Next

        UpdateWorld(Aniworld.Coordinate)
    End Sub

    Private Sub UpdateWorld(ByRef c()() As Integer)
        For w As Integer = 0 To Width - 1
            For l As Integer = 0 To Length - 1
                Coordinate(w)(l) = c(w)(l)
            Next
        Next
    End Sub

    Public Sub RenderFrame(ByVal toFileLoc As String, ByRef c()() As Integer)
        If FrameCounter = 0 Then
            UpdateWorld(c)
            Dim binCounter As Integer = 0
            Dim imageTest = New Bitmap(Width, Length)
            For x = 0 To imageTest.Width - 1
                For y = 0 To imageTest.Height - 1
                    Dim nColor As PixelRGB = ColorPicker(Coordinate(x)(y))

                    Dim newColor As Color = Color.FromArgb(nColor.R, nColor.G, nColor.B)
                    imageTest.SetPixel(x, y, newColor)
                    binCounter = binCounter + 1
                Next
            Next
            imageTest.Save(toFileLoc)
        End If
        FrameCounter += 1
        FrameCounter = FrameCounter Mod FrameRate
    End Sub

    Private Function ColorPicker(ByVal group As Integer) As PixelRGB
        Dim assignPool As Integer = 1020 / Types * group
        Dim R As Integer
        Dim G As Integer
        Dim B As Integer
        If assignPool <= 255 And assignPool > 0 Then
            R = 255
            G = assignPool
            B = 0
            'Console.Write("R")
        ElseIf assignPool > 255 And assignPool <= 510 Then
            R = 255
            G = 255
            B = assignPool - 255
            'Console.Write("Y")
        ElseIf assignPool > 510 And assignPool <= 765 Then
            R = 255 - (assignPool - 510)
            G = 255
            B = 255
            'Console.Write("B")
        ElseIf assignPool > 765 And assignPool <= 1020 Then
            R = assignPool - 765
            G = 0
            B = 255
            'Console.Write("P")
        Else
            R = 0
            G = 0
            B = 0
            'Console.WriteLine(group)
            'Console.WriteLine("else case")
        End If

        Dim color As New PixelRGB(R, G, B)
        Return color
    End Function

    Private Class PixelRGB
        Public R
        Public G
        Public B
        Public Sub New(ByVal _r As Integer, ByVal _g As Integer, ByVal _b As Integer)
            R = _r
            G = _g
            B = _b
        End Sub
    End Class
End Class
