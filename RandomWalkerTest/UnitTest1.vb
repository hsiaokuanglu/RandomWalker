Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports PathFinderLibrary

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Dim pathfinder = New PathFinder(10, 10)
        pathfinder.CreateBinList()
    End Sub

End Class