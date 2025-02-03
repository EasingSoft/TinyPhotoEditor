Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing.Design
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Collections

Namespace pF.DesignSurfaceExt
    Public Class ToolboxServiceImp
        Implements IToolboxService

        Public Property DesignerHost As IDesignerHost
        Public Property Toolbox As ListBox

        Public Sub New(ByVal host As IDesignerHost)
            Me.DesignerHost = host
            Toolbox = Nothing
        End Sub

        Private Sub AddCreator(ByVal creator As ToolboxItemCreatorCallback, ByVal format As String, ByVal host As IDesignerHost) Implements IToolboxService.AddCreator
        End Sub

        Private Sub AddCreator(ByVal creator As ToolboxItemCreatorCallback, ByVal format As String) Implements IToolboxService.AddCreator
        End Sub

        Private Sub AddLinkedToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal category As String, ByVal host As IDesignerHost) Implements IToolboxService.AddLinkedToolboxItem
        End Sub

        Private Sub AddLinkedToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal host As IDesignerHost) Implements IToolboxService.AddLinkedToolboxItem
        End Sub

        Private Sub AddToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal category As String) Implements IToolboxService.AddToolboxItem
            Dim t = (CType(Me, IToolboxService))
            t.AddToolboxItem(toolboxItem)
        End Sub

        Private Sub AddToolboxItem(ByVal toolboxItem As ToolboxItem) Implements IToolboxService.AddToolboxItem
            Toolbox.Items.Add(toolboxItem)
        End Sub

        Private ReadOnly Property CategoryNames As CategoryNameCollection Implements IToolboxService.CategoryNames
            Get
                Return Nothing
            End Get
        End Property

        Private Function DeserializeToolboxItem(ByVal serializedObject As Object, ByVal host As IDesignerHost) As ToolboxItem Implements IToolboxService.DeserializeToolboxItem
            Return (CType(Me, IToolboxService)).DeserializeToolboxItem(serializedObject)
        End Function

        Private Function DeserializeToolboxItem(ByVal serializedObject As Object) As ToolboxItem Implements IToolboxService.DeserializeToolboxItem
            Return CType((CType(serializedObject, DataObject)).GetData(GetType(ToolboxItem)), ToolboxItem)
        End Function

        Private Function GetSelectedToolboxItem(ByVal host As IDesignerHost) As ToolboxItem Implements IToolboxService.GetSelectedToolboxItem
            Return (CType(Me, IToolboxService)).GetSelectedToolboxItem()
        End Function

        Private Function GetSelectedToolboxItem() As ToolboxItem Implements IToolboxService.GetSelectedToolboxItem
            If Toolbox Is Nothing OrElse Toolbox.SelectedItem Is Nothing Then Return Nothing
            Dim tbItem As ToolboxItem = CType(Toolbox.SelectedItem, ToolboxItem)
            If tbItem.DisplayName.ToUpper().Contains("POINTER") Then Return Nothing
            Return tbItem
        End Function

        Private Function GetToolboxItems(ByVal category As String, ByVal host As IDesignerHost) As ToolboxItemCollection Implements IToolboxService.GetToolboxItems
            Return (CType(Me, IToolboxService)).GetToolboxItems()
        End Function

        Private Function GetToolboxItems(ByVal category As String) As ToolboxItemCollection Implements IToolboxService.GetToolboxItems
            Return (CType(Me, IToolboxService)).GetToolboxItems()
        End Function

        Private Function GetToolboxItems(ByVal host As IDesignerHost) As ToolboxItemCollection Implements IToolboxService.GetToolboxItems
            Dim S = (CType(Me, IToolboxService))
            Return S.GetToolboxItems()
        End Function

        Private Function GetToolboxItems() As ToolboxItemCollection Implements IToolboxService.GetToolboxItems
            If Toolbox Is Nothing Then Return Nothing
            Dim arr As ToolboxItem() = New ToolboxItem(Toolbox.Items.Count - 1) {}
            Toolbox.Items.CopyTo(arr, 0)
            Return New ToolboxItemCollection(arr)
        End Function

        Private Function IsSupported(ByVal serializedObject As Object, ByVal filterAttributes As ICollection) As Boolean Implements IToolboxService.IsSupported
            Return True
        End Function

        Private Function IsSupported(ByVal serializedObject As Object, ByVal host As IDesignerHost) As Boolean Implements IToolboxService.IsSupported
            Return True
        End Function

        Private Function IsToolboxItem(ByVal serializedObject As Object, ByVal host As IDesignerHost) As Boolean Implements IToolboxService.IsToolboxItem
            Return (CType(Me, IToolboxService)).IsToolboxItem(serializedObject)
        End Function

        Private Function IsToolboxItem(ByVal serializedObject As Object) As Boolean Implements IToolboxService.IsToolboxItem
            If (CType(Me, IToolboxService)).DeserializeToolboxItem(serializedObject) IsNot Nothing Then Return True
            Return False
        End Function

        Private Sub Refresh() Implements IToolboxService.Refresh
            Toolbox.Refresh()
        End Sub

        Private Sub RemoveCreator(ByVal format As String, ByVal host As IDesignerHost) Implements IToolboxService.RemoveCreator
        End Sub

        Private Sub RemoveCreator(ByVal format As String) Implements IToolboxService.RemoveCreator
        End Sub

        Private Sub RemoveToolboxItem(ByVal toolboxItem As ToolboxItem, ByVal category As String) Implements IToolboxService.RemoveToolboxItem
            Dim t = (CType(Me, IToolboxService))
            t.RemoveToolboxItem(toolboxItem)
        End Sub

        Private Sub RemoveToolboxItem(ByVal toolboxItem As ToolboxItem) Implements IToolboxService.RemoveToolboxItem
            If Toolbox Is Nothing Then Return
            Toolbox.SelectedItem = Nothing
            Toolbox.Items.Remove(toolboxItem)
        End Sub

        Private Property SelectedCategory As String Implements IToolboxService.SelectedCategory
            Get
                Return Nothing
            End Get
            Set(ByVal value As String)
            End Set
        End Property

        Private Sub SelectedToolboxItemUsed() Implements IToolboxService.SelectedToolboxItemUsed
            If Toolbox Is Nothing Then Return
            Toolbox.SelectedItem = Nothing
        End Sub

        Private Function SerializeToolboxItem(ByVal toolboxItem As ToolboxItem) As Object Implements IToolboxService.SerializeToolboxItem
            Dim dataObject As DataObject = New DataObject()
            dataObject.SetData(GetType(ToolboxItem), toolboxItem)
            Return dataObject
        End Function

        Private Function SetCursor() As Boolean Implements IToolboxService.SetCursor
            If Toolbox Is Nothing OrElse Toolbox.SelectedItem Is Nothing Then Return False
            Dim tbItem As ToolboxItem = CType(Toolbox.SelectedItem, ToolboxItem)
            If tbItem.DisplayName.ToUpper().Contains("POINTER") Then Return False

            If Toolbox.SelectedItem IsNot Nothing Then
                Cursor.Current = Cursors.Cross
                Return True
            End If

            Return False
        End Function

        Private Sub SetSelectedToolboxItem(ByVal toolboxItem As ToolboxItem) Implements IToolboxService.SetSelectedToolboxItem
            If Toolbox Is Nothing Then Return
            Toolbox.SelectedItem = toolboxItem
        End Sub







    End Class
End Namespace
