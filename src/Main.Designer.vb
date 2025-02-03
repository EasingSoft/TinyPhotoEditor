<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Table = New System.Windows.Forms.TableLayoutPanel()
        Me.RightTab = New System.Windows.Forms.TableLayoutPanel()
        Me.Prop = New System.Windows.Forms.PropertyGrid()
        Me.Layers = New System.Windows.Forms.DataGridView()
        Me.colmName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colmVisible = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colmRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.MainPanel = New System.Windows.Forms.TabControl()
        Me.LeftTab = New System.Windows.Forms.TableLayoutPanel()
        Me.ImageList = New System.Windows.Forms.DataGridView()
        Me.colmImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colmPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Widgets = New System.Windows.Forms.ListBox()
        Me.MainStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordList = New System.Windows.Forms.ComboBox()
        Me.PasteText = New System.Windows.Forms.Button()
        Me.Table.SuspendLayout()
        Me.RightTab.SuspendLayout()
        CType(Me.Layers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LeftTab.SuspendLayout()
        CType(Me.ImageList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Table
        '
        Me.Table.ColumnCount = 3
        Me.Table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.Table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.Table.Controls.Add(Me.RightTab, 2, 0)
        Me.Table.Controls.Add(Me.MainPanel, 1, 0)
        Me.Table.Controls.Add(Me.LeftTab, 0, 0)
        Me.Table.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Table.Location = New System.Drawing.Point(0, 24)
        Me.Table.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Table.Name = "Table"
        Me.Table.RowCount = 1
        Me.Table.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table.Size = New System.Drawing.Size(887, 419)
        Me.Table.TabIndex = 0
        '
        'RightTab
        '
        Me.RightTab.ColumnCount = 1
        Me.RightTab.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RightTab.Controls.Add(Me.Prop, 0, 0)
        Me.RightTab.Controls.Add(Me.Layers, 0, 1)
        Me.RightTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightTab.Location = New System.Drawing.Point(640, 3)
        Me.RightTab.Name = "RightTab"
        Me.RightTab.RowCount = 2
        Me.RightTab.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350.0!))
        Me.RightTab.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RightTab.Size = New System.Drawing.Size(244, 413)
        Me.RightTab.TabIndex = 5
        '
        'Prop
        '
        Me.Prop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Prop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prop.Location = New System.Drawing.Point(3, 3)
        Me.Prop.Name = "Prop"
        Me.Prop.Size = New System.Drawing.Size(238, 344)
        Me.Prop.TabIndex = 0
        '
        'Layers
        '
        Me.Layers.AllowUserToAddRows = False
        Me.Layers.AllowUserToDeleteRows = False
        Me.Layers.AllowUserToResizeColumns = False
        Me.Layers.AllowUserToResizeRows = False
        Me.Layers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Layers.ColumnHeadersVisible = False
        Me.Layers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colmName, Me.colmVisible, Me.colmRemove})
        Me.Layers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Layers.Location = New System.Drawing.Point(3, 353)
        Me.Layers.MultiSelect = False
        Me.Layers.Name = "Layers"
        Me.Layers.RowHeadersVisible = False
        Me.Layers.RowTemplate.Height = 30
        Me.Layers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Layers.ShowCellToolTips = False
        Me.Layers.Size = New System.Drawing.Size(238, 57)
        Me.Layers.TabIndex = 1
        '
        'colmName
        '
        Me.colmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colmName.HeaderText = "Name"
        Me.colmName.Name = "colmName"
        Me.colmName.ReadOnly = True
        '
        'colmVisible
        '
        Me.colmVisible.HeaderText = "colmVisible"
        Me.colmVisible.Name = "colmVisible"
        Me.colmVisible.Width = 80
        '
        'colmRemove
        '
        Me.colmRemove.HeaderText = "Remove"
        Me.colmRemove.Name = "colmRemove"
        Me.colmRemove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colmRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colmRemove.Width = 30
        '
        'MainPanel
        '
        Me.MainPanel.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(203, 3)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.SelectedIndex = 0
        Me.MainPanel.Size = New System.Drawing.Size(431, 413)
        Me.MainPanel.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.MainPanel.TabIndex = 3
        '
        'LeftTab
        '
        Me.LeftTab.ColumnCount = 1
        Me.LeftTab.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LeftTab.Controls.Add(Me.ImageList, 0, 1)
        Me.LeftTab.Controls.Add(Me.Widgets, 0, 0)
        Me.LeftTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeftTab.Location = New System.Drawing.Point(3, 3)
        Me.LeftTab.Name = "LeftTab"
        Me.LeftTab.RowCount = 2
        Me.LeftTab.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.LeftTab.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LeftTab.Size = New System.Drawing.Size(194, 413)
        Me.LeftTab.TabIndex = 4
        '
        'ImageList
        '
        Me.ImageList.AllowDrop = True
        Me.ImageList.AllowUserToAddRows = False
        Me.ImageList.AllowUserToDeleteRows = False
        Me.ImageList.AllowUserToResizeColumns = False
        Me.ImageList.AllowUserToResizeRows = False
        Me.ImageList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ImageList.ColumnHeadersVisible = False
        Me.ImageList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colmImage, Me.colmPath})
        Me.ImageList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageList.Location = New System.Drawing.Point(3, 53)
        Me.ImageList.MultiSelect = False
        Me.ImageList.Name = "ImageList"
        Me.ImageList.ReadOnly = True
        Me.ImageList.RowHeadersVisible = False
        Me.ImageList.RowTemplate.Height = 100
        Me.ImageList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ImageList.ShowCellToolTips = False
        Me.ImageList.Size = New System.Drawing.Size(188, 357)
        Me.ImageList.TabIndex = 0
        '
        'colmImage
        '
        Me.colmImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colmImage.HeaderText = "Image"
        Me.colmImage.Name = "colmImage"
        Me.colmImage.ReadOnly = True
        '
        'colmPath
        '
        Me.colmPath.HeaderText = "Path"
        Me.colmPath.Name = "colmPath"
        Me.colmPath.ReadOnly = True
        Me.colmPath.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colmPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colmPath.Visible = False
        '
        'Widgets
        '
        Me.Widgets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Widgets.FormattingEnabled = True
        Me.Widgets.ItemHeight = 20
        Me.Widgets.Location = New System.Drawing.Point(3, 3)
        Me.Widgets.Name = "Widgets"
        Me.Widgets.Size = New System.Drawing.Size(188, 44)
        Me.Widgets.TabIndex = 0
        '
        'MainStrip
        '
        Me.MainStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MainStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainStrip.Name = "MainStrip"
        Me.MainStrip.Size = New System.Drawing.Size(887, 24)
        Me.MainStrip.TabIndex = 1
        Me.MainStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAllToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAllToolStripMenuItem
        '
        Me.SaveAllToolStripMenuItem.Name = "SaveAllToolStripMenuItem"
        Me.SaveAllToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.SaveAllToolStripMenuItem.Text = "Save All"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'WordList
        '
        Me.WordList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WordList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.WordList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.WordList.FormattingEnabled = True
        Me.WordList.Location = New System.Drawing.Point(256, 0)
        Me.WordList.Name = "WordList"
        Me.WordList.Size = New System.Drawing.Size(511, 28)
        Me.WordList.TabIndex = 2
        '
        'PasteText
        '
        Me.PasteText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasteText.ForeColor = System.Drawing.Color.Black
        Me.PasteText.Location = New System.Drawing.Point(200, 0)
        Me.PasteText.Name = "PasteText"
        Me.PasteText.Size = New System.Drawing.Size(50, 30)
        Me.PasteText.TabIndex = 3
        Me.PasteText.Text = "📋"
        Me.PasteText.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 443)
        Me.Controls.Add(Me.PasteText)
        Me.Controls.Add(Me.WordList)
        Me.Controls.Add(Me.Table)
        Me.Controls.Add(Me.MainStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MainStrip
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tiny Editor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Table.ResumeLayout(False)
        Me.RightTab.ResumeLayout(False)
        CType(Me.Layers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LeftTab.ResumeLayout(False)
        CType(Me.ImageList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainStrip.ResumeLayout(False)
        Me.MainStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Table As TableLayoutPanel
    Friend WithEvents ImageList As DataGridView
    Friend WithEvents colmImage As DataGridViewImageColumn
    Friend WithEvents colmPath As DataGridViewTextBoxColumn
    Friend WithEvents Prop As PropertyGrid
    Friend WithEvents MainPanel As TabControl
    Friend WithEvents Widgets As ListBox
    Friend WithEvents LeftTab As TableLayoutPanel
    Friend WithEvents MainStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RightTab As TableLayoutPanel
    Friend WithEvents Layers As DataGridView
    Friend WithEvents colmName As DataGridViewTextBoxColumn
    Friend WithEvents colmVisible As DataGridViewCheckBoxColumn
    Friend WithEvents colmRemove As DataGridViewButtonColumn
    Friend WithEvents WordList As ComboBox
    Friend WithEvents PasteText As Button
End Class
