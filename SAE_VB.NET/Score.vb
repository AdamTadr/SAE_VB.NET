Public Class Score

    Private Croissant As Boolean
    Private Sub Score_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        ComboBoxNom.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxNom.AutoCompleteSource = AutoCompleteSource.ListItems
        ButtonOrdre.Text = "Afficher Ordre Croissant"
        Dim stats = listeStats()
        setListeCroissant(True)
    End Sub


    Public Sub setListeCroissant(value As Boolean)
        clearListBox()
        Croissant = value
        Dim stats = listeStats()
        If Croissant Then
            For i As Integer = 0 To stats.Count - 1
                Dim nom As String = stats(i).Item1
                ListBoxNom.Items.Add(nom)
                ComboBoxNom.Items.Add(nom)
                ListBoxScore.Items.Add(getScore(nom))
                ListBoxTpsC.Items.Add(getScoreC(nom))
                ListBoxTemps.Items.Add(getTemps(nom))
                ListBoxNbPartie.Items.Add(getNbPartieJ(nom))
            Next
        Else
            For i As Integer = 0 To stats.Count - 1
                Dim nom As String = stats(stats.Count - 1 - i).Item1
                ListBoxNom.Items.Add(nom)
                ListBoxScore.Items.Add(getScore(nom))
                ListBoxTpsC.Items.Add(getScoreC(nom))
                ListBoxTemps.Items.Add(getTemps(nom))
                ListBoxNbPartie.Items.Add(getNbPartieJ(nom))
            Next
        End If

    End Sub

    Private Sub Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Form1.Show()
    End Sub

    Private Sub ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxNom.SelectedIndexChanged, ListBoxNbPartie.SelectedIndexChanged,
            ListBoxScore.SelectedIndexChanged, ListBoxTpsC.SelectedIndexChanged, ListBoxTemps.SelectedIndexChanged, ComboBoxNom.SelectedIndexChanged
        Dim index As Integer = sender.SelectedIndex
        If index <> -1 Then
            ListBoxNom.SelectedIndex = index
            ListBoxScore.SelectedIndex = index
            ListBoxTpsC.SelectedIndex = index
            ListBoxTemps.SelectedIndex = index
            ListBoxNbPartie.SelectedIndex = index
            ComboBoxNom.Text = ListBoxNom.Items(index)
        End If
    End Sub

    Public Sub clearListBox()
        ListBoxNom.Items.Clear()
        ListBoxScore.Items.Clear()
        ListBoxTpsC.Items.Clear()
        ListBoxTemps.Items.Clear()
        ListBoxNbPartie.Items.Clear()
    End Sub

    Private Sub ButtonOrdre_Click(sender As Object, e As EventArgs) Handles ButtonOrdre.Click
        clearListBox()
        If Croissant Then
            ButtonOrdre.Text = "Afficher Ordre Décroissant"
            setListeCroissant(False)
        Else
            ButtonOrdre.Text = "Afficher Ordre Croissant"
            setListeCroissant(True)
        End If
    End Sub

    Private Sub ButtonStats_Click(sender As Object, e As EventArgs) Handles ButtonStats.Click
        If Not ListBoxNom.Items.Contains(ComboBoxNom.Text) Then
            MsgBox("Veuillez saisir un joueur valide", MsgBoxStyle.Critical, "Joueur indisponible")
        Else
            MsgBox("Nom :" & ComboBoxNom.Text & vbCrLf &
                   "Score : " & getScore(ComboBoxNom.Text) & vbCrLf &
                   "Temps cumulés : " & getScoreC(ComboBoxNom.Text) & vbCrLf &
                   "Temps Minimum : " & getTemps(ComboBoxNom.Text) & vbCrLf &
                   "Nombre de parties jouées : " & getNbPartieJ(ComboBoxNom.Text), MsgBoxStyle.Information, "Statistiques du joueur")
        End If
    End Sub

    Private Sub ButtonQuit_Click(sender As Object, e As EventArgs) Handles ButtonQuit.Click
        Me.Close()
    End Sub

    Private Sub ButtonSuppr_Click(sender As Object, e As EventArgs) Handles ButtonSuppr.Click
        Dim reponse = MsgBox("Voulez vous supprimer les statistiques ?",
               MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Suppression des statistiques")
        If reponse = vbYes Then
            Data.SupprimerStats()
            MsgBox("Donnée supprimé")
        End If
        Me.Close()
    End Sub

End Class