Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Drawing

Namespace pF.DesignSurfaceExt
    Friend Class DesignerOptionServiceExt4SnapLines
        Inherits DesignerOptionService

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub PopulateOptionCollection(ByVal options As DesignerOptionCollection)
            If options.Parent IsNot Nothing Then Return
            Dim ops As DesignerOptions = New DesignerOptions()
            ops.UseSnapLines = True
            ops.UseSmartTags = True
            Dim wfd As DesignerOptionCollection = Me.CreateOptionCollection(options, "WindowsFormsDesigner", Nothing)
            Me.CreateOptionCollection(wfd, "General", ops)
        End Sub
    End Class

    Friend Class DesignerOptionServiceExt4Grid
        Inherits DesignerOptionService

        Private _gridSize As System.Drawing.Size

        Public Sub New(ByVal gridSize As System.Drawing.Size)
            MyBase.New()
            _gridSize = gridSize
        End Sub

        Protected Overrides Sub PopulateOptionCollection(ByVal options As DesignerOptionCollection)
            If options.Parent IsNot Nothing Then Return
            Dim ops As DesignerOptions = New DesignerOptions()
            ops.GridSize = _gridSize
            ops.SnapToGrid = True
            ops.ShowGrid = True
            ops.UseSnapLines = False
            ops.UseSmartTags = True
            Dim wfd As DesignerOptionCollection = Me.CreateOptionCollection(options, "WindowsFormsDesigner", Nothing)
            Me.CreateOptionCollection(wfd, "General", ops)
        End Sub
    End Class

    Friend Class DesignerOptionServiceExt4GridWithoutSnapping
        Inherits DesignerOptionService

        Private _gridSize As System.Drawing.Size

        Public Sub New(ByVal gridSize As System.Drawing.Size)
            MyBase.New()
            _gridSize = gridSize
        End Sub

        Protected Overrides Sub PopulateOptionCollection(ByVal options As DesignerOptionCollection)
            If options.Parent IsNot Nothing Then Return
            Dim ops As DesignerOptions = New DesignerOptions()
            ops.GridSize = _gridSize
            ops.SnapToGrid = False
            ops.ShowGrid = True
            ops.UseSnapLines = False
            ops.UseSmartTags = True
            Dim wfd As DesignerOptionCollection = Me.CreateOptionCollection(options, "WindowsFormsDesigner", Nothing)
            Me.CreateOptionCollection(wfd, "General", ops)
        End Sub
    End Class

    Friend Class DesignerOptionServiceExt4NoGuides
        Inherits DesignerOptionService

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub PopulateOptionCollection(ByVal options As DesignerOptionCollection)
            If options.Parent IsNot Nothing Then Return
            Dim ops As DesignerOptions = New DesignerOptions()
            ops.GridSize = New System.Drawing.Size(8, 8)
            ops.SnapToGrid = False
            ops.ShowGrid = False
            ops.UseSnapLines = False
            ops.UseSmartTags = True
            Dim wfd As DesignerOptionCollection = Me.CreateOptionCollection(options, "WindowsFormsDesigner", Nothing)
            Me.CreateOptionCollection(wfd, "General", ops)
        End Sub
    End Class
End Namespace
