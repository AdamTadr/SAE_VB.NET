Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Authentication.ExtendedProtection

Public Class FormJeu
    Private Cartes() As Carte
    Private tableauLabels() As LabelCarte
    Private CartesTrouve() As Integer
    Private DernierType As Carte.TypeCarte = -1
    Const tempsDefaut As Integer = 61
    Const tempsMax As Integer = 120
    Const tempsMin As Integer = 10
    Private tempsInf As Boolean = False
    Private tempsRestant As Integer = tempsDefaut
    Private score As Integer = 0
    Private enPause As Boolean = False
    Private tempsUtilise As Integer = -1
    Private Const NB_CARTES_PAR_TYPES_DEFAULT As Integer = 4
    Private Const NB_TYPE_DEFAULT As Integer = 5
    Private nbTypeCarte As Integer = NB_TYPE_DEFAULT
    Private nbCartesParType As Integer = NB_CARTES_PAR_TYPES_DEFAULT

    Public Sub modifierTempsImpartis(temps As Integer)
        If temps > tempsMin Or temps < tempsMax Then
            tempsRestant = temps + 1
        Else
            MsgBox("Le temps doit être supérieur à" + tempsMin + " secondes et inférieur à" + tempsMax + "minutes. Temps inchangé", vbOKOnly + vbExclamation, "Erreur")
        End If
    End Sub

    Public Sub arreterTempsImpartis(B As Boolean)
        If B = True Then
            tempsInf = True
            LabelTpsRestant.Visible = False
            LabelTps.Visible = False
            tempsRestant = 1000000
            tempsUtilise = tempsMax + 1
            MsgBox("Temps Desactivé")
        Else
            tempsInf = False
            LabelTpsRestant.Visible = True
            LabelTps.Visible = True
            If optionForm.TxtTemps.Text = "" Then tempsRestant = tempsDefaut Else modifierTempsImpartis(CInt(optionForm.TxtTemps.Text))
            MsgBox("Temps Réactivé a " & tempsRestant - 1 & " secondes")
        End If

    End Sub

    Public Sub modifierNbTypeCarte(nbType As Integer)
        If nbType > 2 And nbType <= 6 Then
            nbTypeCarte = nbType
        Else
            MsgBox("Le nombre de types de cartes doit être compris entre 3 et 6. Nombre de type inchangé", vbOKOnly + vbExclamation, "Erreur")
        End If
    End Sub

    Public Sub modifierNbCartesParType(nbCartes As Integer)
        If nbCartes > 1 And nbCartes <= 6 Then
            nbCartesParType = nbCartes
        Else
            MsgBox("Le nombre de de cartes par type doit être compris entre 2 et 6. Nombre de carte inchangé", vbOKOnly + vbExclamation, "Erreur")
        End If
    End Sub


    Private Sub FormJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Label4.Text = Form1.CbNomJ.Text
        Timer1.Interval = 1000
        Timer1_Tick(Timer1, e)
        Timer1.Start()
        InstancierJeuNormal()
        MelangerPositionLabelC()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tempsRestant -= 1
        LabelTpsRestant.Text = tempsRestant.ToString()
        If tempsRestant < 20 Then LabelTpsRestant.ForeColor = Color.Red
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
        Dim nbCartes As Integer = nbTypeCarte * nbCartesParType
        For i As Integer = 0 To nbCartes - 1
            j = rnd.Next(0, nbCartes)
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
        Carte.instancierPaquetCarteNormale(Cartes, nbTypeCarte, nbCartesParType)
        ReDim CartesTrouve(nbTypeCarte - 1)
        ReDim tableauLabels(nbCartesParType * nbTypeCarte - 1)
        Panel1.AutoSize = True
        Panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Dim cpt As Integer = 0
        For i As Integer = 0 To nbTypeCarte - 1
            For j As Integer = 0 To nbCartesParType - 1
                tableauLabels(cpt) = New LabelCarte(Cartes(cpt), i, j)
                AddHandler tableauLabels(cpt).Click, AddressOf LabelCarte_Click
                Panel1.Controls.Add(tableauLabels(cpt))
                cpt += 1
            Next
        Next
        Me.ClientSize = New Size(Me.ClientSize.Width, Panel1.Bottom + 20)
    End Sub

    Private Sub LabelCarte_Click(sender As Object, e As EventArgs)
        Dim sonFlip As New System.Media.SoundPlayer(Application.StartupPath & "\sounds\Flipcard.wav")
        sonFlip.Play()
        Dim t As Carte.TypeCarte = sender.getCarteType()
        CartesTrouve(t) += 1
        sender.Enabled = False
        If t <> DernierType And DernierType <> -1 Then
            If CartesTrouve(DernierType) <> nbCartesParType Then
                CartesTrouve(t) = 0
                CartesTrouve(DernierType) = 0
                System.Threading.Thread.Sleep(1000)
                RetournerCartes(DernierType)
                RetournerCartes(t)
                DernierType = -1
                Return
            End If
        End If
        If CartesTrouve(t) = nbCartesParType Then
            BloquerCartes(t)
            score += 1
            If score = nbTypeCarte Then
                Timer1.Stop()
                MsgBox("Bravo ! Vous avez gagné !", vbOKOnly + vbInformation, "Victoire")
                Me.Close()
            End If
        End If
        DernierType = t
    End Sub

    Private Sub FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
        If Not tempsInf Then SauvegarderStatistiques(Label4.Text, score, tempsUtilise)
        If tempsInf Then SauvegarderStatistiques(Label4.Text, score, tempsUtilise)
        Form1.ChargerNom()
        LireSave()
    End Sub

    Private Sub BloquerCartes(t As Carte.TypeCarte)
        Dim sonCorrect As New System.Media.SoundPlayer(Application.StartupPath & "\sounds\good.wav")
        sonCorrect.Play()
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
                label.BackgroundImage = Image.FromFile(Application.StartupPath & "\images\BackCard.png")
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

    Private Sub BtnPause_Click(sender As Object, e As EventArgs) Handles BtnPause.Click
        If enPause = False Then
            enPause = True
            Timer1.Stop()
            For Each lab As LabelCarte In tableauLabels
                lab.Enabled = False
            Next
        Else
            enPause = False
            Timer1.Start()
            For Each lab As Label In tableauLabels
                lab.Enabled = True
            Next
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class