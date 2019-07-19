Imports RenderJPG
Imports RandomizedAry

Public Class UI
    Private _width As Integer
    Private _length As Integer
    Private _bin As Integer
    Private world As World
    Private walker As Walker

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _width = Me.tbx.Text
        _length = Me.tby.Text
        _bin = Me.tbb.Text
        Me.dataLoc_textBox.Text = $"C:\test\RW\animationfile\{_width}x{_length}_{_bin}.txt"
        Me.outputLoc_text.Text = $"C:\test\RW\animationfile\{_width}x{_length}_{_bin}_map.jpg"
        Me.TextBox1.Text = $"C:\test\RW\animationfile\{_width}x{_length}_{_bin}_Track.txt"
        Me.TextBox2.Text = $"C:\test\RW\Animation\{_width}x{_length}_{_bin}"
    End Sub

    Private Sub Generate_button_Click_1(sender As Object, e As EventArgs) Handles Generate_button.Click
        Dim data = New TestDataAry(_width, _length, Me.dataLoc_textBox.Text, _bin)
        data.RandomizeTestAry()
        data.WriteTestAry()

        world = New World(_width, _length, _bin)
        walker = New Walker(0, 0, 1, world)
        walker.SetInFile(Me.dataLoc_textBox.Text)
        'Dim newFolder As String = $"{Me.TextBox2.Text}\{_width}x{_length}_{_bin}"
        If (Not System.IO.Directory.Exists(Me.TextBox2.Text)) Then
            System.IO.Directory.CreateDirectory(Me.TextBox2.Text)
            walker.SetFrameFolder(Me.TextBox2.Text)
        Else
            walker.SetFrameFolder(Me.TextBox2.Text & "(2)")
        End If



        If Me.CheckBox1.Checked Then
            walker.MapFillnAnimate()
        Else
            walker.MapFill()
        End If


        world.PrintReserve()
        WriteFile(world, walker, Me.dataLoc_textBox.Text)
        Dim renderer = New Renderer(_width, _length, _bin, Me.dataLoc_textBox.Text)
        renderer.RenderImage(Me.outputLoc_text.Text)
        world.WPR.WriteToFile(TextBox1.Text)
    End Sub

    Private Sub Animate_button_Click(sender As Object, e As EventArgs)

    End Sub

End Class