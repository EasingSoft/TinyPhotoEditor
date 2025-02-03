Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.ComponentModel

Namespace pF.DesignSurfaceExt
    Public Class DesignSurfaceExt2
        Inherits DesignSurfaceExt
        Implements IDesignSurfaceExt2

        Private Const _Name_ As String = "DesignSurfaceExt2"
        Private _toolboxService As ToolboxServiceImp = Nothing

        Public Function GetIToolboxService() As ToolboxServiceImp Implements IDesignSurfaceExt2.GetIToolboxService
            Return CType(Me.GetService(GetType(IToolboxService)), ToolboxServiceImp)
        End Function

        Public Sub EnableDragandDrop() Implements IDesignSurfaceExt2.EnableDragandDrop
            Dim ctrl As Control = Me.GetView()
            If ctrl Is Nothing Then Return
            ctrl.AllowDrop = True
            AddHandler ctrl.DragDrop, AddressOf OnDragDrop
            Dim tbs As ToolboxServiceImp = Me.GetIToolboxService()
            If tbs Is Nothing Then Return
            If tbs.Toolbox Is Nothing Then Return
            AddHandler tbs.Toolbox.MouseDown, AddressOf OnListboxMouseDown
        End Sub

        Private Sub OnListboxMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim tbs As ToolboxServiceImp = Me.GetIToolboxService()
            If tbs Is Nothing Then Return
            If tbs.Toolbox Is Nothing Then Return
            If tbs.Toolbox.SelectedItem Is Nothing Then Return
            tbs.Toolbox.DoDragDrop(tbs.Toolbox.SelectedItem, DragDropEffects.Copy Or DragDropEffects.Move)
        End Sub

        Public Sub OnDragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
            If Not e.Data.GetDataPresent(GetType(ToolboxItem)) Then
                e.Effect = DragDropEffects.None
                Return
            End If

            Dim item As ToolboxItem = TryCast(e.Data.GetData(GetType(ToolboxItem)), ToolboxItem)
            e.Effect = DragDropEffects.Copy
            item.CreateComponents(Me.GetIDesignerHost())
        End Sub

        Private _menuCommandService As MenuCommandServiceExt = Nothing

        Public Sub New()
            MyBase.New()
            InitServices()
        End Sub

        Public Sub New(ByVal parentProvider As IServiceProvider)
            MyBase.New(parentProvider)
            InitServices()
        End Sub

        Public Sub New(ByVal rootComponentType As Type)
            MyBase.New(rootComponentType)
            InitServices()
        End Sub

        Public Sub New(ByVal parentProvider As IServiceProvider, ByVal rootComponentType As Type)
            MyBase.New(parentProvider, rootComponentType)
            InitServices()
        End Sub

        Private Sub InitServices()
            _menuCommandService = New MenuCommandServiceExt(Me)

            If _menuCommandService IsNot Nothing Then
                Me.ServiceContainer.RemoveService(GetType(IMenuCommandService), False)
                Me.ServiceContainer.AddService(GetType(IMenuCommandService), _menuCommandService)
            End If

            _toolboxService = New ToolboxServiceImp(Me.GetIDesignerHost())

            If _toolboxService IsNot Nothing Then
                Me.ServiceContainer.RemoveService(GetType(IToolboxService), False)
                Me.ServiceContainer.AddService(GetType(IToolboxService), _toolboxService)
            End If
        End Sub
    End Class
End Namespace
