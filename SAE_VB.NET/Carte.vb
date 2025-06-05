Imports System.IO

Public Class Carte
    Public Enum TypeCarte
        Type1 = 0
        Type2
        Type3
        Type4
        Type5
        Type6
    End Enum

    Private typeC As TypeCarte
    Dim image As Image
    Dim CarteRetourne As Boolean

    Public Sub instancierCarte(t As TypeCarte, im As Image)
        typeC = t
        image = im
    End Sub

    Public Function getImage() As Image
        Return image
    End Function

    Public Function getTypeC() As TypeCarte
        Return typeC
    End Function

    Public Shared Sub instancierPaquetCarteNormale(ByRef cartes As Carte(), nbType As Integer, nbCartesParType As Integer)
        ReDim cartes(nbType * nbCartesParType - 1)
        Dim images As New ArrayList()
        instancierSetImage(images, "Card1.png", "Card2.png", "Card3.png", "Card4.png", "Card5.png", "Card6.png")
        Dim cpt As Integer = 0
        For i As Integer = 0 To nbType - 1
            For j As Integer = 0 To nbCartesParType - 1
                cartes(cpt) = New Carte()
                cartes(cpt).instancierCarte(CType(i, TypeCarte), images(i))
                cpt += 1
            Next
        Next
    End Sub

    Private Shared Sub instancierSetImage(images As ArrayList, ref1 As String, ref2 As String, ref3 As String, Optional ref4 As String = Nothing,
                                   Optional ref5 As String = Nothing, Optional ref6 As String = Nothing)
        Dim basePath As String = Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\"
        images.Add(Image.FromFile(basePath & ref1))
        images.Add(Image.FromFile(basePath & ref2))
        images.Add(Image.FromFile(basePath & ref3))
        If ref4 IsNot Nothing Then images.Add(Image.FromFile(basePath & ref4))
        If ref5 IsNot Nothing Then images.Add(Image.FromFile(basePath & ref5))
        If ref6 IsNot Nothing Then images.Add(Image.FromFile(basePath & ref6))
    End Sub
End Class

