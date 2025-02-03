Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Diagnostics

Namespace pF.DesignSurfaceExt
    Public Class UndoEngineExt
        Inherits UndoEngine

        Private _Name_ As String = "UndoEngineExt"
        Private undoStack As Stack(Of UndoEngine.UndoUnit) = New Stack(Of UndoEngine.UndoUnit)()
        Private redoStack As Stack(Of UndoEngine.UndoUnit) = New Stack(Of UndoEngine.UndoUnit)()

        Public Sub New(ByVal provider As IServiceProvider)
            MyBase.New(provider)
        End Sub

        Public ReadOnly Property EnableUndo As Boolean
            Get
                Return undoStack.Count > 0
            End Get
        End Property

        Public ReadOnly Property EnableRedo As Boolean
            Get
                Return redoStack.Count > 0
            End Get
        End Property

        Public Sub Undo()
            If undoStack.Count > 0 Then

                Try
                    Dim unit As UndoEngine.UndoUnit = undoStack.Pop()
                    unit.Undo()
                    redoStack.Push(unit)
                Catch ex As Exception
                    Debug.WriteLine(_Name_ & ex.Message)
                End Try
            Else
            End If
        End Sub

        Public Sub Redo()
            If redoStack.Count > 0 Then

                Try
                    Dim unit As UndoEngine.UndoUnit = redoStack.Pop()
                    unit.Undo()
                    undoStack.Push(unit)
                Catch ex As Exception
                    Debug.WriteLine(_Name_ & ex.Message)
                End Try
            Else
            End If
        End Sub

        Protected Overrides Sub AddUndoUnit(ByVal unit As UndoEngine.UndoUnit)
            undoStack.Push(unit)
        End Sub
    End Class
End Namespace
