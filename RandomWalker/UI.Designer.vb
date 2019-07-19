<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dataLoc_textBox = New System.Windows.Forms.TextBox()
        Me.Generate_button = New System.Windows.Forms.Button()
        Me.dataLoc_label = New System.Windows.Forms.Label()
        Me.outputLoc_label = New System.Windows.Forms.Label()
        Me.outputLoc_text = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.tbx = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tby = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbb = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'dataLoc_textBox
        '
        Me.dataLoc_textBox.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataLoc_textBox.Location = New System.Drawing.Point(174, 81)
        Me.dataLoc_textBox.Name = "dataLoc_textBox"
        Me.dataLoc_textBox.Size = New System.Drawing.Size(509, 35)
        Me.dataLoc_textBox.TabIndex = 0
        Me.dataLoc_textBox.Text = "C:\test\RW\animationfile\"
        '
        'Generate_button
        '
        Me.Generate_button.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Generate_button.Location = New System.Drawing.Point(532, 346)
        Me.Generate_button.Name = "Generate_button"
        Me.Generate_button.Size = New System.Drawing.Size(151, 52)
        Me.Generate_button.TabIndex = 1
        Me.Generate_button.Text = "Generate"
        Me.Generate_button.UseVisualStyleBackColor = True
        '
        'dataLoc_label
        '
        Me.dataLoc_label.AutoSize = True
        Me.dataLoc_label.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataLoc_label.Location = New System.Drawing.Point(12, 81)
        Me.dataLoc_label.Name = "dataLoc_label"
        Me.dataLoc_label.Size = New System.Drawing.Size(156, 27)
        Me.dataLoc_label.TabIndex = 3
        Me.dataLoc_label.Text = "Data Location:"
        '
        'outputLoc_label
        '
        Me.outputLoc_label.AutoSize = True
        Me.outputLoc_label.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outputLoc_label.Location = New System.Drawing.Point(5, 143)
        Me.outputLoc_label.Name = "outputLoc_label"
        Me.outputLoc_label.Size = New System.Drawing.Size(163, 27)
        Me.outputLoc_label.TabIndex = 5
        Me.outputLoc_label.Text = "Image Out Loc:"
        '
        'outputLoc_text
        '
        Me.outputLoc_text.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outputLoc_text.Location = New System.Drawing.Point(174, 140)
        Me.outputLoc_text.Name = "outputLoc_text"
        Me.outputLoc_text.Size = New System.Drawing.Size(509, 35)
        Me.outputLoc_text.TabIndex = 4
        Me.outputLoc_text.Text = "C:\test\RW\animationfile\"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 27)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "pFinder Out Loc: "
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(211, 205)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(509, 35)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "C:\test\RW\animationfile\"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 266)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 27)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Animate Out Loc: "
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(211, 263)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(509, 35)
        Me.TextBox2.TabIndex = 9
        Me.TextBox2.Text = "C:\test\RW\Animation\"
        '
        'tbx
        '
        Me.tbx.Location = New System.Drawing.Point(56, 31)
        Me.tbx.Name = "tbx"
        Me.tbx.Size = New System.Drawing.Size(60, 31)
        Me.tbx.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 25)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "X: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(150, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 25)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Y: "
        '
        'tby
        '
        Me.tby.Location = New System.Drawing.Point(194, 31)
        Me.tby.Name = "tby"
        Me.tby.Size = New System.Drawing.Size(60, 31)
        Me.tby.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(287, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 25)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Bin: "
        '
        'tbb
        '
        Me.tbb.Location = New System.Drawing.Point(348, 31)
        Me.tbb.Name = "tbb"
        Me.tbb.Size = New System.Drawing.Size(60, 31)
        Me.tbb.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(562, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 41)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Set File Loc"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(17, 316)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(122, 29)
        Me.CheckBox1.TabIndex = 18
        Me.CheckBox1.Text = "Animate"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'UI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbb)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tby)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbx)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.outputLoc_label)
        Me.Controls.Add(Me.outputLoc_text)
        Me.Controls.Add(Me.dataLoc_label)
        Me.Controls.Add(Me.Generate_button)
        Me.Controls.Add(Me.dataLoc_textBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "UI"
        Me.Text = "RandomWalker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dataLoc_textBox As Windows.Forms.TextBox
    Friend WithEvents Generate_button As Windows.Forms.Button
    Friend WithEvents dataLoc_label As Windows.Forms.Label
    Friend WithEvents outputLoc_label As Windows.Forms.Label
    Friend WithEvents outputLoc_text As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents tbx As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents tby As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents tbb As Windows.Forms.TextBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents CheckBox1 As Windows.Forms.CheckBox
End Class
