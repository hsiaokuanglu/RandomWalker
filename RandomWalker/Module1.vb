Imports System.IO
Imports RenderJPG
Imports System.Windows.Forms

Module Module1

    Sub Main()

        Dim width = 100
        Dim length = 100
        Dim types = 5
        Dim fileLoc = $"C:\test\RW\animationfile\{width}x{length}_{types}.txt"

        Dim newWorld = New World(width, length, types)
        Dim walker = New Walker(0, 0, 1, newWorld)

        'walker.RandomFill()
        'walker.OrderFill()
        walker.MapFillnAnimate()
        newWorld.PrintReserve()
        'newWorld.PrintCoordinate()
        WriteFile(newWorld, walker, fileLoc)
        Dim renderer = New Renderer(width, length, types, fileLoc)
        renderer.RenderImage($"C:\test\RW\animationfile\{width}x{length}_{types}_map.jpg")
        Console.WriteLine("Done Rendering")
        ''Walker Path Recorder
        newWorld.WPR.WriteToFile($"C:\test\RW\animationfile\{width}x{length}_{types}_WalkerPath.txt")
        Console.WriteLine($"Jump Number: {walker.JumpNum}")
        Console.WriteLine($"Efficiency = {newWorld.WPR.CalDistance() / (width * length - 1)} times more")
        Console.ReadKey()
    End Sub

    Public Sub WriteFile(ByRef newWorld As World, ByRef newWalker As Walker, ByVal fileLoc As String)
        Dim writer As New Exporter(newWorld)
        'Console.WriteLine($"Jump: {newWalker.JumpNum}")
        'System.IO.File.WriteAllText("C:\test\outRandomWalker.txt", "")
        Console.WriteLine("writing file...")
        writer.WriteData(fileLoc)
        Console.WriteLine("done writing")
        'Console.ReadKey()
    End Sub


End Module
