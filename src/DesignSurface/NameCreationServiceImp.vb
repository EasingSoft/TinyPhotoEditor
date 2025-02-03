Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel.Design.Serialization
Imports System.ComponentModel

Namespace pF.DesignSurfaceExt
    Friend Class NameCreationServiceImp
        Implements INameCreationService

        Private Const _Name_ As String = "NameCreationServiceImp"

        Public Sub New()
        End Sub

        Public Function CreateName(ByVal container As IContainer, ByVal type As Type) As String Implements INameCreationService.CreateName
            If container Is Nothing Then Return String.Empty
            Dim cc As ComponentCollection = container.Components
            Dim min As Integer = Int32.MaxValue
            Dim max As Integer = Int32.MinValue
            Dim count As Integer = 0
            Dim i As Integer = 0

            While i < cc.Count
                Dim comp As Component = TryCast(cc(i), Component)

                If comp.[GetType]() = type Then
                    count += 1
                    Dim name As String = comp.Site.Name

                    If name.StartsWith(type.Name) Then

                        Try
                            Dim value As Integer = Int32.Parse(name.Substring(type.Name.Length))
                            If value < min Then min = value
                            If value > max Then max = value
                        Catch __unusedException1__ As Exception
                        End Try
                    End If
                End If

                i += 1
            End While

            If 0 = count Then
                Return type.Name & "1"
            ElseIf min > 1 Then
                Dim j As Integer = min - 1
                Return type.Name & j.ToString()
            Else
                Dim j As Integer = max + 1
                Return type.Name & j.ToString()
            End If
        End Function

        Public Function IsValidName(ByVal name As String) As Boolean Implements INameCreationService.IsValidName
            If String.IsNullOrEmpty(name) Then Return False
            If Not (Char.IsLetter(name, 0)) Then Return False
            If name.StartsWith("_") Then Return False
            Return True
        End Function

        Public Sub ValidateName(ByVal name As String) Implements INameCreationService.ValidateName
            Const _signature_ As String = _Name_ & "::ValidateName()"
            If Not (IsValidName(name)) Then Throw New ArgumentException(_signature_ & " - Exception: Invalid name: " & name)
        End Sub
    End Class
End Namespace
