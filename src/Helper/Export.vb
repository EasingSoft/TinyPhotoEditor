Imports System.IO
Imports TinyEditor.pF.DesignSurfaceExt

Module Export
    Sub Save(Surfaces As Dictionary(Of String, IDesignSurfaceExt2), R As Size)
        For Each S In Surfaces
            Save(S.Key, S.Value, R)
        Next
    End Sub
    Sub Save(FilePath As String, Surface As IDesignSurfaceExt2, R As Size)
        Dim host = Surface.GetIDesignerHost()
        Dim Form1 = DirectCast(host.RootComponent, Control)
        Dim Childs = Form1.Controls
        If Childs.Count = 0 Then Return

        Using fs As New FileStream(FilePath, FileMode.Open)
            Using Img = Image.FromStream(fs)
                Dim Scale = EditorScale(R, Img.Width, Img.Height)
                Form1.SuspendLayout()
                Form1.Scale(1 / Scale)
                Using gClone = New Bitmap(Img)

                    Using g = Graphics.FromImage(gClone)
                        For Each ctrl As Control In Childs
                            Draw(g, Img, ctrl, 1 / Scale)
                        Next
                    End Using

                    Dim Dir = Path.GetDirectoryName(FilePath)
                    Dim Name = Path.GetFileNameWithoutExtension(FilePath)
                    Dim Ext = Path.GetExtension(FilePath).TrimStart(".")
                    gClone.Save(Path.Combine(Dir, $"{Name}_saved.{Ext}"))
                End Using
                Form1.Scale(Scale)
                Form1.ResumeLayout()
            End Using
        End Using
    End Sub

    Function ScaleFont(txt As String, font As Font, Scale As Double) As Font
        Dim FontSize = font.SizeInPoints
        Dim Size = TextRenderer.MeasureText(txt, font)
        Dim W = Size.Width * Scale
        Dim H = Size.Height * Scale

        While Size.Width < W OrElse Size.Height < H
            FontSize += 1
            font = New Font(font.FontFamily, FontSize, font.Style, GraphicsUnit.Point)
            Size = TextRenderer.MeasureText(txt, font)
        End While
        FontSize -= 1
        font = New Font(font.FontFamily, FontSize, font.Style, GraphicsUnit.Point)
        Return font
    End Function


    Sub Draw(g As Graphics, Img As Bitmap, ctrl As Control, Scale As Double)
        If ctrl.GetType = GetType(Text) Then
            Dim label = CType(ctrl, Text)
            Dim text As String = label.Text
            Dim font As Font = label.Font
            Dim foreColor As Color = label.ForeColor
            Dim backColor As Color = label.BackColor
            Dim size As SizeF = g.MeasureString(text, font)
            Dim rect As New Rectangle(label.Location, label.Size)

            ' Handle text alignment
            Dim format As New StringFormat()
            Select Case label.TextAlign
                Case ContentAlignment.TopCenter
                    format.Alignment = StringAlignment.Center
                    format.LineAlignment = StringAlignment.Near
                Case ContentAlignment.TopLeft
                    format.Alignment = StringAlignment.Near
                    format.LineAlignment = StringAlignment.Near
                Case ContentAlignment.TopRight
                    format.Alignment = StringAlignment.Far
                    format.LineAlignment = StringAlignment.Near
                Case ContentAlignment.MiddleLeft
                    format.Alignment = StringAlignment.Near
                    format.LineAlignment = StringAlignment.Center
                Case ContentAlignment.MiddleCenter
                    format.Alignment = StringAlignment.Center
                    format.LineAlignment = StringAlignment.Center
                Case ContentAlignment.MiddleRight
                    format.Alignment = StringAlignment.Far
                    format.LineAlignment = StringAlignment.Center
                Case ContentAlignment.BottomLeft
                    format.Alignment = StringAlignment.Near
                    format.LineAlignment = StringAlignment.Far
                Case ContentAlignment.BottomCenter
                    format.Alignment = StringAlignment.Center
                    format.LineAlignment = StringAlignment.Far
                Case ContentAlignment.BottomRight
                    format.Alignment = StringAlignment.Far
                    format.LineAlignment = StringAlignment.Far
            End Select

            ' Draw background
            Dim backBrush As New SolidBrush(backColor)
            g.FillRectangle(backBrush, rect)

            ' Draw text
            Dim brush As New SolidBrush(foreColor)
            font = ScaleFont(text, font, Scale)
            g.DrawString(text, font, brush, rect, format)


        End If
    End Sub
End Module
