Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.ComponentModel.Design.Serialization

Namespace pF.DesignSurfaceExt
    Interface IDesignSurfaceExt
        Sub DoAction(ByVal command As String)
        Sub SwitchTabOrder()
        Sub UseSnapLines()
        Sub UseGrid(ByVal gridSize As System.Drawing.Size)
        Sub UseGridWithoutSnapping(ByVal gridSize As System.Drawing.Size)
        Sub UseNoGuides()
        Function CreateRootComponent(ByVal controlType As Type, ByVal controlSize As Size) As IComponent
        Function CreateRootComponent(ByVal loader As DesignerLoader, ByVal controlSize As Size) As IComponent
        Function CreateControl(ByVal controlType As Type, ByVal controlSize As Size, ByVal controlLocation As Point) As Control
        Function GetUndoEngineExt() As UndoEngineExt
        Function GetIDesignerHost() As IDesignerHost
        Function GetView() As Control
    End Interface
End Namespace
