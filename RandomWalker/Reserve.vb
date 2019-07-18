Public Class Reserve
    Public Stk As Stack
    Public Size As Integer
    Public Sub New(ByVal _size As Integer)
        Size = _size
        Stk = New Stack()
    End Sub
End Class