Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Data.LireSave()
        ChargerNom()
        CbNomJ.DropDownStyle = ComboBoxStyle.DropDown
        AutoCompleteCb()
    End Sub

    Public Sub ChargerNom()
        Dim nom As String
        For i As Integer = 0 To Data.nbNom() - 1
            nom = getNom(i)
            If Not CbNomJ.Items.Contains(nom) Then CbNomJ.Items.Add(nom)
        Next
    End Sub
    Private Sub AutoCompleteCb()
        CbNomJ.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CbNomJ.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub BtnPartie_Click(sender As Object, e As EventArgs) Handles BtnPartie.Click
        If CbNomJ.Text.Length > 2 Then
            FormJeu.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub BtnQuit_Click(sender As Object, e As EventArgs) Handles BtnQuit.Click
        Me.Close()
    End Sub

    Private Sub BtnScore_Click(sender As Object, e As EventArgs) Handles BtnScore.Click
        Score.Show()
        Me.Hide()
    End Sub

End Class
