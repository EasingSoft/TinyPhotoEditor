Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel.Design

Namespace pF.DesignSurfaceExt
    Class MenuCommandServiceExt
        Implements IMenuCommandService

        Private _serviceProvider As IServiceProvider = Nothing
        Private _menuCommandService As MenuCommandService = Nothing

        Public Sub New(ByVal serviceProvider As IServiceProvider)
            Me._serviceProvider = serviceProvider
            _menuCommandService = New MenuCommandService(serviceProvider)
        End Sub

        Public Sub ShowContextMenu(ByVal menuID As CommandID, ByVal x As Integer, ByVal y As Integer) Implements IMenuCommandService.ShowContextMenu
            Dim contextMenu As ContextMenu = New ContextMenu()
            Dim command As MenuCommand = FindCommand(StandardCommands.Cut)

            If command IsNot Nothing Then
                Dim menuItem As MenuItem = New MenuItem("Cut", New EventHandler(AddressOf OnMenuClicked))
                menuItem.Tag = command
                contextMenu.MenuItems.Add(menuItem)
            End If

            command = FindCommand(StandardCommands.Copy)

            If command IsNot Nothing Then
                Dim menuItem As MenuItem = New MenuItem("Copy", New EventHandler(AddressOf OnMenuClicked))
                menuItem.Tag = command
                contextMenu.MenuItems.Add(menuItem)
            End If

            command = FindCommand(StandardCommands.Paste)

            If command IsNot Nothing Then
                Dim menuItem As MenuItem = New MenuItem("Paste", New EventHandler(AddressOf OnMenuClicked))
                menuItem.Tag = command
                contextMenu.MenuItems.Add(menuItem)
            End If

            command = FindCommand(StandardCommands.Delete)

            If command IsNot Nothing Then
                Dim menuItem As MenuItem = New MenuItem("Delete", New EventHandler(AddressOf OnMenuClicked))
                menuItem.Tag = command
                contextMenu.MenuItems.Add(menuItem)
            End If

            Dim surface As DesignSurface = CType(_serviceProvider, DesignSurface)
            Dim viewService As Control = CType(surface.View, Control)

            If viewService IsNot Nothing Then
                contextMenu.Show(viewService, viewService.PointToClient(New Point(x, y)))
            End If
        End Sub

        Private Sub OnMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
            Dim menuItem As MenuItem = TryCast(sender, MenuItem)

            If menuItem IsNot Nothing AndAlso TypeOf menuItem.Tag Is MenuCommand Then
                Dim command As MenuCommand = TryCast(menuItem.Tag, MenuCommand)
                command.Invoke()
            End If
        End Sub

        Public Sub AddCommand(ByVal command As MenuCommand) Implements IMenuCommandService.AddCommand
            _menuCommandService.AddCommand(command)
        End Sub

        Public Sub AddVerb(ByVal verb As DesignerVerb) Implements IMenuCommandService.AddVerb
            _menuCommandService.AddVerb(verb)
        End Sub

        Public Function FindCommand(ByVal commandID As CommandID) As MenuCommand Implements IMenuCommandService.FindCommand
            Return _menuCommandService.FindCommand(commandID)
        End Function

        Public Function GlobalInvoke(ByVal commandID As CommandID) As Boolean Implements IMenuCommandService.GlobalInvoke
            Return _menuCommandService.GlobalInvoke(commandID)
        End Function

        Public Sub RemoveCommand(ByVal command As MenuCommand) Implements IMenuCommandService.RemoveCommand
            _menuCommandService.RemoveCommand(command)
        End Sub

        Public Sub RemoveVerb(ByVal verb As DesignerVerb) Implements IMenuCommandService.RemoveVerb
            _menuCommandService.RemoveVerb(verb)
        End Sub

        Public ReadOnly Property Verbs As DesignerVerbCollection Implements IMenuCommandService.Verbs
            Get
                Return _menuCommandService.Verbs
            End Get
        End Property
    End Class
End Namespace
