Module Widgets
    Public Class Widget
        Public Name As String
        Public Type As Type
        Public Icon As Image

        Public Sub New(Type As Type, Icon As Image)
            Me.Name = Type.Name
            Me.Type = Type
            Me.Icon = My.Resources.ResourceManager.GetObject(Me.Name, My.Resources.Culture) 'Icon
        End Sub
    End Class
    Public List As New List(Of Widget) From {
            New Widget(GetType(Text), My.Resources.Text)
        }
End Module
