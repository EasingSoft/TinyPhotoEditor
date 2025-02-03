Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Module Img
    Public AllowedExt As String() = New String() {"png", "jpg", "jpeg"}
    Public Function Resize(ByVal image As Image, ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim destRect = New Rectangle(0, 0, width, height)
        Dim destImage = New Bitmap(width, height)
        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution)

        Using g = Graphics.FromImage(destImage)
            g.CompositingMode = CompositingMode.SourceCopy
            g.CompositingQuality = CompositingQuality.HighQuality
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.SmoothingMode = SmoothingMode.HighQuality
            g.PixelOffsetMode = PixelOffsetMode.HighQuality

            Using mode = New ImageAttributes()
                mode.SetWrapMode(WrapMode.TileFlipXY)
                g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, mode)
            End Using
        End Using

        Return destImage
    End Function
    Function EditorScale(R As Size, ImgW As Integer, imgH As Integer) As Double
        Dim W = R.Width
        Dim H = R.Height
        Dim aspectRatio As Double = ImgW / imgH
        Dim newWidth As Integer
        Dim newHeight As Integer
        If ImgW > imgH Then
            newWidth = Math.Min(W, ImgW)
            newHeight = newWidth / aspectRatio
            If newHeight > H Then
                newHeight = H
                newWidth = newHeight * aspectRatio
            End If
        Else
            newHeight = Math.Min(H, imgH)
            newWidth = newHeight * aspectRatio
            If newWidth > W Then
                newWidth = W
                newHeight = newWidth / aspectRatio
            End If
        End If
        Return newWidth / ImgW
    End Function


End Module
