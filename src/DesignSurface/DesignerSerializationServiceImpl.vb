Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.ComponentModel.Design.Serialization
Imports System.Collections

Namespace pF.DesignSurfaceExt
    Friend Class DesignerSerializationServiceImpl
        Implements IDesignerSerializationService

        Private _serviceProvider As IServiceProvider

        Public Sub New(ByVal serviceProvider As IServiceProvider)
            Me._serviceProvider = serviceProvider
        End Sub

        Public Function Deserialize(ByVal serializationData As Object) As System.Collections.ICollection Implements IDesignerSerializationService.Deserialize
            Dim serializationStore As SerializationStore = TryCast(serializationData, SerializationStore)

            If serializationStore IsNot Nothing Then
                Dim componentSerializationService As ComponentSerializationService = TryCast(_serviceProvider.GetService(GetType(ComponentSerializationService)), ComponentSerializationService)
                Dim collection As ICollection = componentSerializationService.Deserialize(serializationStore)
                Return collection
            End If

            Return New Object() {}
        End Function

        Public Function Serialize(ByVal objects As System.Collections.ICollection) As Object Implements IDesignerSerializationService.Serialize
            Dim componentSerializationService As ComponentSerializationService = TryCast(_serviceProvider.GetService(GetType(ComponentSerializationService)), ComponentSerializationService)
            Dim returnObject As SerializationStore = Nothing

            Using serializationStore As SerializationStore = componentSerializationService.CreateStore()

                For Each obj As Object In objects
                    If TypeOf obj Is Control Then componentSerializationService.Serialize(serializationStore, obj)
                Next

                returnObject = serializationStore
            End Using

            Return returnObject
        End Function
    End Class
End Namespace
