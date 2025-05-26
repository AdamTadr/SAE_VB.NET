Imports System.ComponentModel
Imports System.IO
Imports System.Security.Authentication.ExtendedProtection

Public Class FormJeu
    Private Cartes() As Carte
    Private tableauLabels() As LabelCarte
    Private CartesTrouve() As Integer
    Private DernierType As Carte.TypeCarte = -1
    Private tempsRestant As Integer
    Private score As Integer = 0
    Private tempsUtilise As Integer = -1

    Private Sub FormJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Label4.Text = Form1.CbNomJ.Text
        Timer1.Interval = 1000
        tempsRestant = 61
        Timer1_Tick(Timer1, e)
        Timer1.Start()
        InstancierJeuNormal()
        MelangerPositionLabelC()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tempsRestant -= 1
        Label1.Text = tempsRestant.ToString()
        If tempsRestant < 20 Then Label1.ForeColor = Color.Red
        If tempsRestant = 0 Then
            Timer1.Stop()
            MsgBox("Perdu ! Vous avez perdu !", vbOKOnly + vbCritical, "Temps écoulé")
            Me.Close()
        End If
        tempsUtilise += 1
    End Sub
    Private Sub MelangerPositionLabelC()
        Dim rnd As New Random()
        Dim j As Integer
        Dim nouvelleLocation As Point
        Const NOMBRE_CARTES As Integer = 20
        For i As Integer = 0 To NOMBRE_CARTES - 1
            j = rnd.Next(0, NOMBRE_CARTES)
            nouvelleLocation = tableauLabels(j).Location
            If Not CarteDejaPresente(nouvelleLocation, j) Then
                tableauLabels(j).Location = tableauLabels(i).Location
                tableauLabels(i).Location = nouvelleLocation
                tableauLabels(i).Refresh()
            End If
        Next
    End Sub

    Function CarteDejaPresente(p As Point, j As Integer) As Boolean
        For i As Integer = 0 To tableauLabels.Length - 1
            If tableauLabels(i).Location = p And i <> j Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub InstancierJeuNormal()
        Carte.instancierPaquetCarteNormale(Cartes)
        ReDim CartesTrouve(4)
        ReDim tableauLabels(19)
        Panel1.AutoSize = True
        Panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Dim cpt As Integer = 0
        For i As Integer = 0 To 4
            For j As Integer = 0 To 3
                tableauLabels(cpt) = New LabelCarte(Cartes(cpt), i, j)
                AddHandler tableauLabels(cpt).Click, AddressOf LabelCarte_Click
                Panel1.Controls.Add(tableauLabels(cpt))
                cpt += 1
            Next
        Next
        Me.ClientSize = New Size(Me.ClientSize.Width, Panel1.Bottom + 20)
    End Sub

    Private Sub LabelCarte_Click(sender As Object, e As EventArgs)
        Dim t As Carte.TypeCarte = sender.getCarteType()
        CartesTrouve(t) += 1
        sender.Enabled = False
        If t <> DernierType And DernierType <> -1 Then
            If CartesTrouve(DernierType) <> 4 Then
                CartesTrouve(t) = 0
                CartesTrouve(DernierType) = 0
                System.Threading.Thread.Sleep(1000)
                RetournerCartes(DernierType)
                RetournerCartes(t)
                DernierType = -1
                Return
            End If
        End If
        If CartesTrouve(t) = 4 Then
            BloquerCartes(t)
            score += 1
            If score = 5 Then
                Timer1.Stop()
                MsgBox("Bravo ! Vous avez gagné !", vbOKOnly + vbInformation, "Victoire")
                Me.Close()
            End If
        End If
        DernierType = t
    End Sub

    Private Sub FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
        SauvegarderStatistiques(Label4.Text, score, tempsUtilise)
        Form1.ChargerNom()
        LireSave()
    End Sub

    Private Sub BloquerCartes(t As Carte.TypeCarte)
        For Each label In tableauLabels
            If label.getCarteType() = t Then
                label.Enabled = False
                label.RendreCarteGrise()
            End If
        Next
    End Sub

    Private Sub RetournerCartes(t As Carte.TypeCarte)
        For Each label In tableauLabels
            If label.getCarteType() = t Then
                label.BackgroundImage = Image.FromFile("BackCard.png")
                label.Refresh()
                label.Enabled = True
            End If
        Next
    End Sub
    Private Sub FormJeu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim res As MsgBoxResult = MsgBox("Voulez-vous vraiment quitter le jeu ?", vbYesNo + vbQuestion, "Quitter le jeu")
        If res = vbYes Then
            Me.Close()
        End If
    End Sub
End Class