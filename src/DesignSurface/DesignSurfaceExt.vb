Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.ComponentModel.Design.Serialization
Imports System.Diagnostics

Namespace pF.DesignSurfaceExt
    Public Class DesignSurfaceExt
        Inherits DesignSurface
        Implements IDesignSurfaceExt

        Private Const _Name_ As String = "DesignSurfaceExt"

        Public Sub SwitchTabOrder() Implements IDesignSurfaceExt.SwitchTabOrder
            If False = IsTabOrderMode Then
                InvokeTabOrder()
            Else
                DisposeTabOrder()
            End If
        End Sub

        Public Sub UseSnapLines() Implements IDesignSurfaceExt.UseSnapLines
            Dim serviceProvider As IServiceContainer = TryCast(Me.GetService(GetType(IServiceContainer)), IServiceContainer)
            Dim opsService As DesignerOptionService = TryCast(serviceProvider.GetService(GetType(DesignerOptionService)), DesignerOptionService)

            If opsService IsNot Nothing Then
                serviceProvider.RemoveService(GetType(DesignerOptionService))
            End If

            Dim opsService2 As DesignerOptionService = New DesignerOptionServiceExt4SnapLines()
            serviceProvider.AddService(GetType(DesignerOptionService), opsService2)
        End Sub

        Public Sub UseGrid(ByVal gridSize As Size) Implements IDesignSurfaceExt.UseGrid
            Dim serviceProvider As IServiceContainer = TryCast(Me.GetService(GetType(IServiceContainer)), IServiceContainer)
            Dim opsService As DesignerOptionService = TryCast(serviceProvider.GetService(GetType(DesignerOptionService)), DesignerOptionService)

            If opsService IsNot Nothing Then
                serviceProvider.RemoveService(GetType(DesignerOptionService))
            End If

            Dim opsService2 As DesignerOptionService = New DesignerOptionServiceExt4Grid(gridSize)
            serviceProvider.AddService(GetType(DesignerOptionService), opsService2)
        End Sub

        Public Sub UseGridWithoutSnapping(ByVal gridSize As Size) Implements IDesignSurfaceExt.UseGridWithoutSnapping
            Dim serviceProvider As IServiceContainer = TryCast(Me.GetService(GetType(IServiceContainer)), IServiceContainer)
            Dim opsService As DesignerOptionService = TryCast(serviceProvider.GetService(GetType(DesignerOptionService)), DesignerOptionService)

            If opsService IsNot Nothing Then
                serviceProvider.RemoveService(GetType(DesignerOptionService))
            End If

            Dim opsService2 As DesignerOptionService = New DesignerOptionServiceExt4GridWithoutSnapping(gridSize)
            serviceProvider.AddService(GetType(DesignerOptionService), opsService2)
        End Sub

        Public Sub UseNoGuides() Implements IDesignSurfaceExt.UseNoGuides
            Dim serviceProvider As IServiceContainer = TryCast(Me.GetService(GetType(IServiceContainer)), IServiceContainer)
            Dim opsService As DesignerOptionService = TryCast(serviceProvider.GetService(GetType(DesignerOptionService)), DesignerOptionService)

            If opsService IsNot Nothing Then
                serviceProvider.RemoveService(GetType(DesignerOptionService))
            End If

            Dim opsService2 As DesignerOptionService = New DesignerOptionServiceExt4NoGuides()
            serviceProvider.AddService(GetType(DesignerOptionService), opsService2)
        End Sub

        Public Function GetUndoEngineExt() As UndoEngineExt Implements IDesignSurfaceExt.GetUndoEngineExt
            Return Me._undoEngine
        End Function

        Private Function CreateRootComponentCore(ByVal controlType As Type, ByVal controlSize As Size, ByVal loader As DesignerLoader) As IComponent
            Const _signature_ As String = _Name_ & "::CreateRootComponentCore()"

            Try
                Dim host As IDesignerHost = GetIDesignerHost()
                If host Is Nothing Then Return Nothing
                If host.RootComponent IsNot Nothing Then Return Nothing

                If loader IsNot Nothing Then
                    Me.BeginLoad(loader)
                    If Me.LoadErrors.Count > 0 Then Throw New Exception(_signature_ & " - Exception: the BeginLoad(loader) failed!")
                Else
                    Me.BeginLoad(controlType)
                    If Me.LoadErrors.Count > 0 Then Throw New Exception(_signature_ & " - Exception: the BeginLoad(Type) failed! Some error during " & controlType.ToString() & " loading")
                End If

                Dim ihost As IDesignerHost = GetIDesignerHost()
                Dim ctrl As Control = Nothing

                If TypeOf host.RootComponent Is Form Then
                    ctrl = TryCast(Me.View, Control)
                    ctrl.BackColor = Color.LightGray
                    Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(ctrl)
                    Dim pdS As PropertyDescriptor = pdc.Find("Size", False)
                    If pdS IsNot Nothing Then pdS.SetValue(ihost.RootComponent, controlSize)
                ElseIf TypeOf host.RootComponent Is UserControl Then
                    ctrl = TryCast(Me.View, Control)
                    ctrl.BackColor = Color.Gray
                    Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(ctrl)
                    Dim pdS As PropertyDescriptor = pdc.Find("Size", False)
                    If pdS IsNot Nothing Then pdS.SetValue(ihost.RootComponent, controlSize)
                ElseIf TypeOf host.RootComponent Is Control Then
                    ctrl = TryCast(Me.View, Control)
                    ctrl.BackColor = Color.LightGray
                    Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(ctrl)
                    Dim pdS As PropertyDescriptor = pdc.Find("Size", False)
                    If pdS IsNot Nothing Then pdS.SetValue(ihost.RootComponent, controlSize)
                ElseIf TypeOf host.RootComponent Is Component Then
                    ctrl = TryCast(Me.View, Control)
                    ctrl.BackColor = Color.White
                Else
                    ctrl = TryCast(Me.View, Control)
                    ctrl.BackColor = Color.Red
                End If

                Return ihost.RootComponent
            Catch exx As Exception
                Debug.WriteLine(exx.Message)
                If exx.InnerException IsNot Nothing Then Debug.WriteLine(exx.InnerException.Message)
                Throw
            End Try
        End Function

        Public Function CreateRootComponent(ByVal controlType As Type, ByVal controlSize As Size) As IComponent Implements IDesignSurfaceExt.CreateRootComponent
            Return CreateRootComponentCore(controlType, controlSize, Nothing)
        End Function

        Public Function CreateRootComponent(ByVal loader As DesignerLoader, ByVal controlSize As Size) As IComponent Implements IDesignSurfaceExt.CreateRootComponent
            Return CreateRootComponentCore(Nothing, controlSize, loader)
        End Function

        Public Function CreateControl(ByVal controlType As Type, ByVal controlSize As Size, ByVal controlLocation As Point) As Control Implements IDesignSurfaceExt.CreateControl
            Try
                Dim host As IDesignerHost = GetIDesignerHost()
                If host Is Nothing Then Return Nothing
                If host.RootComponent Is Nothing Then Return Nothing
                Dim newComp As IComponent = host.CreateComponent(controlType)
                If newComp Is Nothing Then Return Nothing
                Dim designer As IDesigner = host.GetDesigner(newComp)
                If designer Is Nothing Then Return Nothing
                If TypeOf designer Is IComponentInitializer Then
                    Dim d = (CType(designer, IComponentInitializer))
                    d.InitializeNewComponent(Nothing)
                End If
                Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(newComp)
                Dim pdS As PropertyDescriptor = pdc.Find("Size", False)
                If pdS IsNot Nothing Then pdS.SetValue(newComp, controlSize)
                Dim pdL As PropertyDescriptor = pdc.Find("Location", False)
                If pdL IsNot Nothing Then pdL.SetValue(newComp, controlLocation)
                Dim c = (CType(newComp, Control))
                c.Parent = TryCast(host.RootComponent, Control)
                Return TryCast(newComp, Control)
            Catch exx As Exception
                Debug.WriteLine(exx.Message)
                If exx.InnerException IsNot Nothing Then Debug.WriteLine(exx.InnerException.Message)
                Throw
            End Try
        End Function

        Public Function GetIDesignerHost() As IDesignerHost Implements IDesignSurfaceExt.GetIDesignerHost
            Return CType((Me.GetService(GetType(IDesignerHost))), IDesignerHost)
        End Function

        Public Function GetView() As Control Implements IDesignSurfaceExt.GetView
            Dim ctrl As Control = TryCast(Me.View, Control)
            If ctrl Is Nothing Then Return Nothing
            ctrl.Dock = DockStyle.Fill
            Return ctrl
        End Function

        Private _tabOrder As TabOrderHooker = Nothing
        Private _tabOrderMode As Boolean = False

        Public ReadOnly Property IsTabOrderMode As Boolean
            Get
                Return _tabOrderMode
            End Get
        End Property

        Public Property TabOrder As TabOrderHooker
            Get
                If _tabOrder Is Nothing Then _tabOrder = New TabOrderHooker()
                Return _tabOrder
            End Get
            Set(ByVal value As TabOrderHooker)
                _tabOrder = value
            End Set
        End Property

        Public Sub InvokeTabOrder()
            TabOrder.HookTabOrder(Me.GetIDesignerHost())
            _tabOrderMode = True
        End Sub

        Public Sub DisposeTabOrder()
            TabOrder.HookTabOrder(Me.GetIDesignerHost())
            _tabOrderMode = False
        End Sub

        Private _undoEngine As UndoEngineExt = Nothing
        Private _nameCreationService As NameCreationServiceImp = Nothing
        Private _designerSerializationService As DesignerSerializationServiceImpl = Nothing
        Private _codeDomComponentSerializationService As CodeDomComponentSerializationService = Nothing

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
            _nameCreationService = New NameCreationServiceImp()

            If _nameCreationService IsNot Nothing Then
                Me.ServiceContainer.RemoveService(GetType(INameCreationService), False)
                Me.ServiceContainer.AddService(GetType(INameCreationService), _nameCreationService)
            End If

            _codeDomComponentSerializationService = New CodeDomComponentSerializationService(Me.ServiceContainer)

            If _codeDomComponentSerializationService IsNot Nothing Then
                Me.ServiceContainer.RemoveService(GetType(ComponentSerializationService), False)
                Me.ServiceContainer.AddService(GetType(ComponentSerializationService), _codeDomComponentSerializationService)
            End If

            _designerSerializationService = New DesignerSerializationServiceImpl(Me.ServiceContainer)

            If _designerSerializationService IsNot Nothing Then
                Me.ServiceContainer.RemoveService(GetType(IDesignerSerializationService), False)
                Me.ServiceContainer.AddService(GetType(IDesignerSerializationService), _designerSerializationService)
            End If

            _undoEngine = New UndoEngineExt(Me.ServiceContainer)
            _undoEngine.Enabled = False

            If _undoEngine IsNot Nothing Then
                Me.ServiceContainer.RemoveService(GetType(UndoEngine), False)
                Me.ServiceContainer.AddService(GetType(UndoEngine), _undoEngine)
            End If

            Me.ServiceContainer.AddService(GetType(IMenuCommandService), New MenuCommandService(Me))
        End Sub

        Public Sub DoAction(ByVal command As String) Implements IDesignSurfaceExt.DoAction
            If String.IsNullOrEmpty(command) Then Return
            Dim ims As IMenuCommandService = TryCast(Me.GetService(GetType(IMenuCommandService)), IMenuCommandService)
            If ims Is Nothing Then Return

            Try

                Select Case command.ToUpper()
                    Case "CUT"
                        ims.GlobalInvoke(StandardCommands.Cut)
                    Case "COPY"
                        ims.GlobalInvoke(StandardCommands.Copy)
                    Case "PASTE"
                        ims.GlobalInvoke(StandardCommands.Paste)
                    Case "DELETE"
                        ims.GlobalInvoke(StandardCommands.Delete)
                    Case Else
                End Select

            Catch exx As Exception
                Debug.WriteLine(exx.Message)
                If exx.InnerException IsNot Nothing Then Debug.WriteLine(exx.InnerException.Message)
                Throw
            End Try
        End Sub
    End Class
End Namespace
