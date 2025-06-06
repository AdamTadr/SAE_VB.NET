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
    Public Shared themeSelectionne As String = "Oiseaux"
    Private cheatTransparency As Boolean = False
    Private cheatReveal As Boolean = False
    Private originalImages As New Dictionary(Of LabelCarte, Image)
    Private revealedTypes As New List(Of Integer)

    Public Function getTheme() As String
        Return themeSelectionne
    End Function

    Public Sub setTheme(theme As String)
        themeSelectionne = theme
    End Sub
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
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Label4.Text = Form1.CbNomJ.Text
        Timer1.Interval = 1000
        Timer1_Tick(Timer1, e)
        Timer1.Start()
        InstancierJeuNormal()
        MelangerPositionLabelC()
        InitCheatSystem()
        Dim cheminFond As String = Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\Fond.png"


        If IO.File.Exists(cheminFond) Then
            Me.BackgroundImage = Image.FromFile(cheminFond)
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Panel1.BackgroundImage = Image.FromFile(Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\Fond.png")
            Panel1.BackgroundImageLayout = ImageLayout.Stretch
        End If
    End Sub

    Private Sub InitCheatSystem()
        For Each labelCarte As LabelCarte In tableauLabels
            If labelCarte IsNot Nothing Then
                originalImages.Add(labelCarte, labelCarte.BackgroundImage)
            End If
        Next
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
        Me.KeyPreview = True
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
                label.BackgroundImage = Image.FromFile(Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\BackCard.png")
                label.Refresh()
                label.Enabled = True
            End If
        Next
    End Sub
    Private Sub FormJeu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.ChargerNom()
        Timer1.Stop()
        SauvegarderStatistiques(Label4.Text, score, tempsUtilise + 1)
        LireSave()
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

    Private Sub FormJeu_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' F1 - Mode Transparence (toggle)
        If e.KeyCode = Keys.F1 Then
            cheatTransparency = Not cheatTransparency
            ApplyTransparencyCheat()

            If cheatTransparency Then
                ShowCheatNotification("Mode Transparence ACTIVÉ", Color.Green)
            Else
                ShowCheatNotification("Mode Transparence DÉSACTIVÉ", Color.Red)
            End If
        End If

        ' F2 - Révéler toutes les cartes (maintenir enfoncé)
        If e.KeyCode = Keys.F2 AndAlso Not cheatReveal Then
            cheatReveal = True
            RevealAllCards()
            ShowCheatNotification("Révélation temporaire...", Color.Orange)
        End If

        ' F3 - Menu Cheat Secret
        If e.KeyCode = Keys.F3 Then
            ShowSecretCheatMenu()
        End If
    End Sub

    Private Sub FormJeu_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        ' Quand on relâche F2, cacher les cartes
        If e.KeyCode = Keys.F2 AndAlso cheatReveal Then
            cheatReveal = False
            HideAllCards()
        End If
    End Sub


    Private Sub ApplyTransparencyCheat()
        For Each labelCarte As LabelCarte In tableauLabels
            If labelCarte IsNot Nothing AndAlso labelCarte.Enabled Then
                If cheatTransparency Then
                    ' Créer une image semi-transparente de la carte
                    Dim carte As Carte = labelCarte.getCarte()
                    If carte IsNot Nothing Then
                        Dim originalImage As Image = carte.getImage()
                        labelCarte.BackgroundImage = MakeImageTransparent(originalImage, 0.3F)
                        labelCarte.Text = (carte.getTypeC() + 1).ToString()
                        labelCarte.ForeColor = Color.Red
                        labelCarte.Font = New Font("Arial", 16, FontStyle.Bold)
                        labelCarte.TextAlign = ContentAlignment.MiddleCenter
                    End If
                Else
                    ' Restaurer l'image normale (dos de carte)
                    labelCarte.BackgroundImage = Image.FromFile(Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\BackCard.png")
                    labelCarte.Text = ""
                End If
            End If
        Next
    End Sub

    ' Révéler toutes les cartes temporairement
    Private Sub RevealAllCards()
        For Each labelCarte As LabelCarte In tableauLabels
            If labelCarte IsNot Nothing AndAlso labelCarte.Enabled Then
                Try

                    Dim typeIndex As Integer = labelCarte.getCarteType() + 1
                    Dim imagePath As String = Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\Card" & typeIndex & ".png"

                    If File.Exists(imagePath) Then
                        labelCarte.BackgroundImage = Image.FromFile(imagePath)
                        labelCarte.BackgroundImageLayout = ImageLayout.Stretch

                        labelCarte.BorderStyle = BorderStyle.Fixed3D
                        labelCarte.BackColor = Color.FromArgb(100, 255, 255, 0)
                    Else
                        ' Si l'image n'existe pas, afficher au moins le numéro
                        labelCarte.Text = typeIndex.ToString()
                        labelCarte.ForeColor = Color.Yellow
                        labelCarte.Font = New Font("Arial", 32, FontStyle.Bold)
                        labelCarte.TextAlign = ContentAlignment.MiddleCenter
                    End If
                Catch ex As Exception
                    ' En cas d'erreur, afficher le type
                    labelCarte.Text = "?"
                    labelCarte.ForeColor = Color.Red
                End Try
            End If
        Next
    End Sub



    Private Sub HideAllCards()
        For Each labelCarte As LabelCarte In tableauLabels
            If labelCarte IsNot Nothing AndAlso labelCarte.Enabled Then
                ' Remettre le dos de la carte
                labelCarte.BackgroundImage = Image.FromFile(Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\BackCard.png")
                labelCarte.BackgroundImageLayout = ImageLayout.Stretch
                labelCarte.BorderStyle = BorderStyle.None
                labelCarte.BackColor = Color.Transparent


                If cheatTransparency Then
                    ApplyTransparencyCheat()
                End If
            End If
        Next
    End Sub

    ' Fonction pour rendre une image semi-transparente
    Private Function MakeImageTransparent(img As Image, opacity As Single) As Image
        If img Is Nothing Then Return Nothing

        Dim bmp As New Bitmap(img.Width, img.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            Dim colorMatrix As New System.Drawing.Imaging.ColorMatrix()
            colorMatrix.Matrix33 = opacity

            Dim attributes As New System.Drawing.Imaging.ImageAttributes()
            attributes.SetColorMatrix(colorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap)

            g.DrawImage(img, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attributes)
        End Using

        Return bmp
    End Function


    Private Sub ShowCheatNotification(message As String, color As Color)
        Dim notifLabel As New Label()
        notifLabel.Text = message
        notifLabel.Font = New Font("Arial", 12, FontStyle.Bold)
        notifLabel.ForeColor = Color.White
        notifLabel.BackColor = color
        notifLabel.AutoSize = True
        notifLabel.Padding = New Padding(10)
        notifLabel.Location = New Point((Me.Width - notifLabel.Width) \ 2, 10)
        Me.Controls.Add(notifLabel)
        notifLabel.BringToFront()


        Dim t As New Timer()
        t.Interval = 2000
        AddHandler t.Tick, Sub()
                               Me.Controls.Remove(notifLabel)
                               t.Stop()
                               t.Dispose()
                           End Sub
        t.Start()
    End Sub


    Private Sub ShowSecretCheatMenu()
        Dim result As String = InputBox("Codes Cheat Secrets:" & vbCrLf & vbCrLf &
                              "1 - Temps infini (toggle)" & vbCrLf &
                              "2 - Révéler une paire" & vbCrLf &
                              "3 - Ralentir le temps (toggle)" & vbCrLf &
                              "4 - Révéler UN type de carte (5 sec)" & vbCrLf &
                              "5 - Mode Facile (voir numéros)" & vbCrLf &
                              "6 - Gagner instantanément" & vbCrLf & vbCrLf)

        Select Case result
            Case "1"

                If Not tempsInf Then

                    tempsInf = True
                    Timer1.Stop()
                    LabelTpsRestant.Text = "∞"
                    LabelTpsRestant.ForeColor = Color.Green
                    ShowCheatNotification("Temps infini ACTIVÉ!", Color.Blue)
                Else

                    tempsInf = False
                    Timer1.Start()
                    tempsRestant = If(tempsRestant > 10, tempsRestant, 60)
                    LabelTpsRestant.Text = tempsRestant.ToString()
                    LabelTpsRestant.ForeColor = If(tempsRestant < 20, Color.Red, Color.Black)
                    ShowCheatNotification("Temps infini DÉSACTIVÉ!", Color.Orange)
                End If

            Case "2"

                RevealRandomPair()

            Case "3"
                'ralentir le temps
                If Timer1.Interval = 1000 Then
                    Timer1.Interval = 2000
                    ShowCheatNotification("Temps ralenti x2", Color.Purple)
                Else
                    Timer1.Interval = 1000
                    ShowCheatNotification("Temps normal", Color.Gray)
                End If

            Case "4"
                RevealOneTypeOnly()

            Case "5"
                ' Mode facile - afficher les numéros
                For Each labelCarte As LabelCarte In tableauLabels
                    If labelCarte IsNot Nothing AndAlso labelCarte.Enabled Then
                        Dim carte As Carte = labelCarte.getCarte()
                        labelCarte.Text = (carte.getTypeC() + 1).ToString()
                        labelCarte.ForeColor = Color.Yellow
                        labelCarte.Font = New Font("Arial", 20, FontStyle.Bold)
                        labelCarte.TextAlign = ContentAlignment.TopLeft
                    End If
                Next
                ShowCheatNotification("Numéros affichés", Color.Green)

            Case "6"
                ' Gagner instantanément
                For i As Integer = 0 To nbTypeCarte - 1
                    CartesTrouve(i) = nbCartesParType
                    BloquerCartes(i)
                Next
                score = nbTypeCarte
                Timer1.Stop()
                ShowCheatNotification("VICTOIRE INSTANTANÉE!", Color.Gold)
                MsgBox("Bravo ! Vous avez gagné ! (avec un peu d'aide...)", vbOKOnly + vbInformation, "Victoire")
                Me.Close()

        End Select
    End Sub


    Private Sub RevealOneTypeOnly()
        Dim availableTypes As New List(Of Integer)


        For i As Integer = 0 To nbTypeCarte - 1
            If CartesTrouve(i) < nbCartesParType AndAlso Not revealedTypes.Contains(i) Then
                availableTypes.Add(i)
            End If
        Next

        If availableTypes.Count = 0 Then
            ShowCheatNotification("Tous les types ont déjà été révélés!", Color.Red)
            Return
        End If


        Dim rnd As New Random()
        Dim selectedType As Integer = availableTypes(rnd.Next(availableTypes.Count))


        revealedTypes.Add(selectedType)


        For Each labelCarte As LabelCarte In tableauLabels
            If labelCarte IsNot Nothing AndAlso labelCarte.Enabled AndAlso labelCarte.getCarteType() = selectedType Then
                Try

                    Dim typeIndex As Integer = selectedType + 1
                    Dim imagePath As String = Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\Card" & typeIndex & ".png"

                    If File.Exists(imagePath) Then
                        labelCarte.BackgroundImage = Image.FromFile(imagePath)
                        labelCarte.BackgroundImageLayout = ImageLayout.Stretch

                        labelCarte.BorderStyle = BorderStyle.Fixed3D
                        labelCarte.BackColor = Color.FromArgb(150, 0, 255, 0)
                    End If
                Catch ex As Exception

                    labelCarte.Text = (selectedType + 1).ToString()
                    labelCarte.ForeColor = Color.Lime
                End Try
            End If
        Next

        ShowCheatNotification("Type " & (selectedType + 1) & " révélé pour 5 sec", Color.Lime)


        Dim t As New Timer()
        t.Interval = 5000
        AddHandler t.Tick, Sub()

                               For Each labelCarte As LabelCarte In tableauLabels
                                   If labelCarte IsNot Nothing AndAlso labelCarte.Enabled AndAlso labelCarte.getCarteType() = selectedType Then
                                       labelCarte.BackgroundImage = Image.FromFile(Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\BackCard.png")
                                       labelCarte.BackgroundImageLayout = ImageLayout.Stretch
                                       labelCarte.BorderStyle = BorderStyle.None
                                       labelCarte.BackColor = Color.Transparent
                                       labelCarte.Text = ""


                                       If cheatTransparency Then
                                           ApplyTransparencyCheat()
                                       End If
                                   End If
                               Next
                               t.Stop()
                               t.Dispose()
                           End Sub
        t.Start()
    End Sub


    Private Sub RevealRandomPair()
        Dim availableTypes As New List(Of Integer)


        For i As Integer = 0 To nbTypeCarte - 1
            If CartesTrouve(i) < nbCartesParType Then
                availableTypes.Add(i)
            End If
        Next

        If availableTypes.Count = 0 Then
            ShowCheatNotification("Toutes les paires sont déjà trouvées!", Color.Red)
            Return
        End If


        Dim rnd As New Random()
        Dim selectedType As Integer = availableTypes(rnd.Next(availableTypes.Count))


        Dim revealedCards As New List(Of LabelCarte)

        For Each labelCarte As LabelCarte In tableauLabels
            If labelCarte IsNot Nothing AndAlso labelCarte.Enabled AndAlso labelCarte.getCarteType() = selectedType Then

                labelCarte.BackColor = Color.Yellow


                Dim typeIndex As Integer = selectedType + 1
                Dim imagePath As String = Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\Card" & typeIndex & ".png"

                If File.Exists(imagePath) Then
                    labelCarte.BackgroundImage = Image.FromFile(imagePath)
                    labelCarte.BackgroundImageLayout = ImageLayout.Stretch
                End If

                revealedCards.Add(labelCarte)
            End If
        Next

        ShowCheatNotification("Paire " & (selectedType + 1) & " révélée (" & revealedCards.Count & " cartes)", Color.Yellow)


        Dim t As New Timer()
        t.Interval = 3000
        AddHandler t.Tick, Sub()
                               For Each card In revealedCards
                                   card.BackColor = Color.Transparent
                                   Dim backPath As String = Application.StartupPath & "\images\" & FormJeu.themeSelectionne & "\BackCard.png"
                                   If File.Exists(backPath) Then
                                       card.BackgroundImage = Image.FromFile(backPath)
                                       card.BackgroundImageLayout = ImageLayout.Stretch
                                   End If
                               Next
                               t.Stop()
                               t.Dispose()
                           End Sub
        t.Start()
    End Sub
End Class
