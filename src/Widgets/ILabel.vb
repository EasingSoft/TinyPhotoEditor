Imports System.ComponentModel

Public Class ILabel
    Inherits Label
    <Browsable(False)>
    Public Shared Property CheckForIllegalCrossThreadCalls As Boolean
    <Browsable(False)>
    Public Property Region As Region
    <Browsable(False)>
    Public Overridable Property Dock As DockStyle
    <Browsable(False)>
    Public Property Enabled As Boolean

    <Browsable(False)>
    Public Property IsAccessible As Boolean
    <Browsable(False)>
    Public Property Left As Integer
    <Browsable(False)>
    Public Property Margin As Padding
    <Browsable(False)>
    Public Overridable Property MaximumSize As Size
    <Browsable(False)>
    Public Overridable Property MinimumSize As Size
    <Browsable(False)>
    Public Property Parent As Control
    <Browsable(False)>
    Public Overridable Property Cursor As Cursor
    <Browsable(False)>
    Public Property AccessibleDefaultActionDescription As String
    <Browsable(False)>
    Public Property AccessibleDescription As String
    <Browsable(False)>
    Public Property AccessibleName As String
    <Browsable(False)>
    Public Property AccessibleRole As AccessibleRole
    <Browsable(False)>
    Public Overridable Property AllowDrop As Boolean
    <Browsable(False)>
    Public Overridable Property Anchor As AnchorStyles

    <Browsable(False)>
    Public Overridable Property AutoScrollOffset As Point

    <Browsable(False)>
    Public Overridable Property BackgroundImage As Image
    <Browsable(False)>
    Public Overridable Property BackgroundImageLayout As ImageLayout
    <Browsable(False)>
    Public Overridable Property BindingContext As BindingContext
    <Browsable(False)>
    Public Property Bounds As Rectangle
    <Browsable(False)>
    Public Property Capture As Boolean
    <Browsable(False)>
    Public Property CausesValidation As Boolean
    <Browsable(False)>
    Public Property ClientSize As Size
    <Browsable(False)>
    Public Overridable Property ContextMenu As ContextMenu
    <Browsable(False)>
    Public Overridable Property ContextMenuStrip As ContextMenuStrip
    <Browsable(False)>
    Public Overridable Property RightToLeft As RightToLeft
    <Browsable(False)>
    Public Overrides Property Site As ISite

    <Browsable(False)>
    Public Property Visible As Boolean
    <Browsable(False)>
    Public Property UseWaitCursor As Boolean
    <Browsable(False)>
    Public Property Padding As Padding
    <Browsable(False)>
    Public Property Top As Integer
    <Browsable(False)>
    Public Property WindowTarget As IWindowTarget

    <Browsable(False)>
    Public Property TabStop As Boolean
    <Browsable(False)>
    Public Property TabIndex As Integer

    <Browsable(False)>
    Public Property ImeMode As ImeMode
    <Browsable(False)>
    Public Property Tag As Object
    <Browsable(False)>
    Protected Overridable Property DoubleBuffered As Boolean
    <Browsable(False)>
    Protected Property FontHeight As Integer
    <Browsable(False)>
    Protected Property ResizeRedraw As Boolean
    <Browsable(False)>
    Protected Overridable Property ImeModeBase As ImeMode
    <Browsable(False)>
    Public Property Handle As IntPtr

    <Browsable(False)>
    Public Property ImageIndex As Integer

    <Browsable(False)>
    Public Property Image As IntPtr

    <Browsable(False)>
    Public Property FlatStyle As FlatStyle

    <Browsable(False)>
    Public Property BorderStyle As BorderStyle

    <Browsable(False)>
    Public Property AutoEllipsis As Boolean

    <Browsable(False)>
    Public Property ImageKey As String

    <Browsable(False)>
    Public Property UseMnemonic As Boolean

    <Browsable(False)>
    Public Property UseCompatibleTextRendering As Boolean

    <Browsable(False)>
    Public Property Locked As Boolean
        Get
            Return Locked
        End Get
        Set(value As Boolean)

        End Set
    End Property


    <Browsable(False)>
    Public Property ImageList As ImageList

    <Browsable(False)>
    Public Property DataBindings As ControlBindingsCollection

    <Browsable(False)>
    Public Property ImageAlign As ContentAlignment

    <Browsable(False)>
    Public Property Name As String
End Class