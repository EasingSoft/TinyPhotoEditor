Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.IO
Imports System.Reflection
Imports TinyEditor.pF.DesignSurfaceExt

Public Class Main
    Dim Surfaces As New Dictionary(Of String, IDesignSurfaceExt2)
    Dim Images As New List(Of Bitmap)
    Private Sub ImageList_DragEnter(sender As Object, e As DragEventArgs) Handles ImageList.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub ImageList_DragDrop(sender As Object, e As DragEventArgs) Handles ImageList.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim Drops = CType(e.Data.GetData(DataFormats.FileDrop), String())
            LoadAll(Drops)
        End If
    End Sub

    Function Res() As Size
        Dim Resoultion = Screen.FromControl(Me).WorkingArea
        Dim W = Resoultion.Width - (LeftTab.Width + RightTab.Width)
        Dim H = Resoultion.Height - (MainStrip.Height + 40)
        Return New Size(W, H)
    End Function



    Sub LoadAll(Drops As String())
        RemoveHandler ImageList.SelectionChanged, AddressOf ImageList_SelectionChanged
        For Each I In Images
            I.Dispose()
        Next
        Images.Clear()
        ImageList.Rows.Clear()
        Surfaces.Clear()
        MainPanel.TabPages.Clear()
        CurrentImg = String.Empty
        For Each Pth In Drops
            If Directory.Exists(Pth) Then
                LoadImages(Directory.GetFiles(Pth))
            Else
                LoadImg(Pth)
            End If
        Next
        AddHandler ImageList.SelectionChanged, AddressOf ImageList_SelectionChanged
        ImageList_SelectionChanged(Nothing, Nothing)
    End Sub

    Sub LoadImages(Files As String())
        For Each FilePath In Files
            LoadImg(FilePath)
        Next
    End Sub

    Sub LoadImg(FilePath As String)
        Dim Ext = Path.GetExtension(FilePath).TrimStart(".").ToLower()
        If Not AllowedExt.Contains(Ext) Then Return
        Using fs As New FileStream(FilePath, FileMode.Open)
            Using Bitmap = Image.FromStream(fs)
                ImageList.Rows.Add(New Object() {Img.Resize(Bitmap, (Bitmap.Width / Bitmap.Height) * ImageList.RowTemplate.Height, ImageList.RowTemplate.Height), FilePath})
                Dim surface As New DesignSurfaceExt2()
                surface.UseSnapLines()

                Dim form1 As Form = surface.CreateRootComponent(GetType(Form), New Size(400, 400))
                form1.Name = Path.GetFileName(FilePath)
                form1.BackColor = Color.Black
                form1.Dock = DockStyle.Fill
                form1.FormBorderStyle = FormBorderStyle.None
                form1.BackgroundImageLayout = ImageLayout.None
                form1.KeyPreview = True

                Dim Scale = EditorScale(Res, Bitmap.Width, Bitmap.Height)
                form1.BackgroundImage = Img.Resize(Bitmap, Bitmap.Width * Scale, Bitmap.Height * Scale) 'Image.FromStream(New FileStream(FilePath, FileMode.Open))

                Images.Add(form1.BackgroundImage)




                GetType(Form).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, form1, New Object() {True})
                MainPanel.TabPages.Add(MainPanel.TabPages.Count)
                Dim Tab = MainPanel.TabPages(MainPanel.TabPages.Count - 1)

                surface.GetView().Parent = Tab

                surface.GetUndoEngineExt().Enabled = True
                Dim Host = surface.GetIDesignerHost()
                Dim selectionService As ISelectionService = (Host.GetService(GetType(ISelectionService)))
                If selectionService IsNot Nothing Then
                    AddHandler selectionService.SelectionChanged, AddressOf OnSelectionChanged
                End If
                Dim Box = surface.GetIToolboxService()
                If Box IsNot Nothing Then Box.Toolbox = Widgets
                Surfaces.Add(FilePath, surface)
                AddHandler form1.ControlAdded, AddressOf Control_Added
            End Using
        End Using
    End Sub


    Private Sub Control_Added(sender As Object, e As ControlEventArgs)
        Layers.Rows.Add(New Object() {e.Control.Name, True, "❌"})
    End Sub

    Dim CurrentImg As String = String.Empty
    Private Sub ImageList_SelectionChanged(sender As Object, e As EventArgs)
        Dim cell = ImageList.SelectedCells.Cast(Of DataGridViewCell).FirstOrDefault()
        If cell Is Nothing Then Return
        Dim FilePath As String = ImageList.Rows(cell.RowIndex).Cells(colmPath.Index).Value
        CurrentImg = FilePath
        MainPanel.SelectedIndex = cell.RowIndex
        Prop.SelectedObject = Nothing
        RefreshLayers()
    End Sub

    Sub RefreshLayers()
        Dim isurf = Surfaces(CurrentImg)
        If isurf IsNot Nothing Then
            Dim host = isurf.GetIDesignerHost()
            Layers.Rows.Clear()
            For Each Con As Control In DirectCast(host.RootComponent, Control).Controls
                Layers.Rows.Add(New Object() {Con.Name, Con.Visible, "❌"})
            Next
        End If
    End Sub

    Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim isurf = Surfaces(CurrentImg)
        If isurf IsNot Nothing Then
            Dim Service As ISelectionService = Nothing
            Service = TryCast(isurf.GetIDesignerHost().GetService(GetType(ISelectionService)), ISelectionService)

            Dim Widget As Control = Service.PrimarySelection
            If TinyEditor.Widgets.List.Any(Function(W) W.Type = Widget.GetType()) Then
                Prop.SelectedObject = Widget
                For Each R In Layers.Rows.Cast(Of DataGridViewRow)
                    Dim Name As String = R.Cells(colmName.Index).Value
                    Dim IsVisible As Boolean = R.Cells(colmVisible.Index).Value
                    If Name = Widget.Name Then
                        R.Selected = True
                        Return
                    End If
                Next
                Widget.Focus()
            Else
                Prop.SelectedObject = Nothing
                If Service IsNot Nothing Then Service.SetSelectedComponents(Nothing)
            End If
        End If
    End Sub


    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        For Each W In TinyEditor.Widgets.List
            Widgets.Items.Add(New ToolboxItem(W.Type))
        Next
        MainPanel.Appearance = TabAppearance.FlatButtons
        MainPanel.ItemSize = New Size(0, 1)
        MainPanel.SizeMode = TabSizeMode.Fixed
        If File.Exists("list.txt") Then
            WordList.Items.AddRange(File.ReadAllLines("list.txt"))
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Using Diag As New OpenFileDialog()
            Diag.Multiselect = True
            Diag.Filter = "Images|" & String.Join(String.Empty, AllowedExt.Select(Function(Ex) $"*.{Ex};").ToArray()).TrimEnd(";")
            If Diag.ShowDialog() = DialogResult.OK Then
                LoadAll(Diag.FileNames)
            End If
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub SaveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAllToolStripMenuItem.Click
        Export.Save(Surfaces, Res)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Export.Save(CurrentImg, Surfaces(CurrentImg), Res)
    End Sub

    Private Sub Layers_SelectionChanged(sender As Object, e As EventArgs) Handles Layers.SelectionChanged
        Dim R = Layers.SelectedRows.Cast(Of DataGridViewRow).FirstOrDefault()
        If R Is Nothing Then Return
        Dim Name As String = R.Cells(colmName.Index).Value
        Dim IsVisible As Boolean = R.Cells(colmVisible.Index).Value
        Dim isurf = Surfaces(CurrentImg)
        If isurf IsNot Nothing Then
            Dim host = isurf.GetIDesignerHost()
            For Each Con As Control In DirectCast(host.RootComponent, Control).Controls
                If Con.Name = Name Then
                    Dim Service As ISelectionService = Nothing
                    Service = TryCast(host.GetService(GetType(ISelectionService)), ISelectionService)
                    If Service IsNot Nothing Then
                        Service.SetSelectedComponents(New Control() {Con})
                    End If
                    Return
                End If
            Next
        End If
    End Sub
    Private Sub Layers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Layers.CellContentClick
        If e.ColumnIndex = colmVisible.Index AndAlso Layers.CurrentCell.GetType() = GetType(DataGridViewCheckBoxCell) Then
            Dim IsVisible As Boolean = CBool(Layers(e.ColumnIndex, e.RowIndex).EditedFormattedValue)
            Dim R = Layers.Rows(e.RowIndex)
            Dim Name As String = R.Cells(colmName.Index).Value
            Dim isurf = Surfaces(CurrentImg)
            If isurf IsNot Nothing Then
                Dim host = isurf.GetIDesignerHost()
                For Each Con As Control In DirectCast(host.RootComponent, Control).Controls
                    If Con.Name = Name Then
                        Con.Visible = IsVisible
                        Return
                    End If
                Next
            End If
            Layers.EndEdit()
        End If
    End Sub

    Private Sub Layers_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles Layers.CurrentCellDirtyStateChanged
        If Layers.CurrentCell.GetType() = GetType(DataGridViewCheckBoxCell) Then Layers.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub Layers_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Layers.CellEndEdit
        If e.ColumnIndex = colmVisible.Index Then Layers.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub Layers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Layers.CellClick
        Dim R = Layers.SelectedRows.Cast(Of DataGridViewRow).FirstOrDefault()
        If R Is Nothing Then Return
        Dim Name As String = R.Cells(colmName.Index).Value
        If e.ColumnIndex = colmRemove.Index Then
            Dim isurf = Surfaces(CurrentImg)
            If isurf IsNot Nothing Then
                Dim host = isurf.GetIDesignerHost()
                For Each Con As Control In DirectCast(host.RootComponent, Control).Controls
                    If Con.Name = Name Then
                        host.DestroyComponent(Con)
                        RefreshLayers()
                        Return
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub WordList_KeyDown(sender As Object, e As KeyEventArgs) Handles WordList.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Surfaces.ContainsKey(CurrentImg) Then
            Dim txt = WordList.Text
            Dim isurf = Surfaces(CurrentImg)
            If isurf IsNot Nothing Then
                Dim host = isurf.GetIDesignerHost()
                Dim Controls = DirectCast(host.RootComponent, Control).Controls
                Dim Con As Text = isurf.CreateControl(GetType(TinyEditor.Text), New Drawing.Size(50, 50), New Point(50, 50))
                Con.AutoSize = True
                Con.Text = txt.Replace("\n", vbLf)
                Dim Size = Con.Size
                Con.AutoSize = False
                Con.Size = Size

                Dim Service As ISelectionService = Nothing
                Service = TryCast(isurf.GetIDesignerHost().GetService(GetType(ISelectionService)), ISelectionService)
                Service.SetSelectedComponents(Nothing)
                Service.SetSelectedComponents(New Control() {Con})
                'RefreshLayers()
            End If
        End If
    End Sub

    Private Sub PasteText_Click(sender As Object, e As EventArgs) Handles PasteText.Click
        WordList.Text = Clipboard.GetText()
        WordList.Focus()
    End Sub
End Class
