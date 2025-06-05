Public Class LabelCarte
    Inherits Label
    Private Carte As Carte

    Public Function getCarteType() As Carte.TypeCarte
        Return Carte.getTypeC()
    End Function
    Public Sub New(c As Carte, x As Integer, y As Integer)
        Carte = c
        Me.Location = New Point(x * 100 + 10, y * 131 + 50)
        Me.Size = Carte.getImage().Size
        Me.BackgroundImage = Image.FromFile(Application.StartupPath & "\images\" & FormJeu.getTheme() & "\BackCard.png")
    End Sub

    Public Sub RendreCarteGrise()
        Dim img As New Bitmap(Carte.getImage())
        Dim imgGrise As New Bitmap(img.Width, img.Height)
        For x As Integer = 0 To img.Width - 1
            For y As Integer = 0 To img.Height - 1
                Dim pixel As Color = img.GetPixel(x, y)
                Dim gris As Integer = CInt((CInt(pixel.R) + CInt(pixel.G) + CInt(pixel.B)) / 3)
                imgGrise.SetPixel(x, y, Color.FromArgb(pixel.A, gris, gris, gris))
            Next
        Next
        Me.BackgroundImage = imgGrise
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        Me.BackgroundImage = Carte.getImage()
        Me.Refresh()
        MyBase.OnClick(e)
    End Sub


End Class
