Imports System.Runtime.InteropServices

Public Class optionForm

    Private tempsInf As Boolean = False
    Private Sub optionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Form1.Show()
    End Sub

    Private Sub Txt_Numeric(sender As Object, e As KeyPressEventArgs) Handles TxtNbParType.KeyPress, TxtNbType.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ButtonValider_Click(sender As Object, e As EventArgs) Handles ButtonValider.Click
        If TxtTemps.Text <> "" Then FormJeu.modifierNbTypeCarte(CInt(TxtNbType.Text))
        If TxtTemps.Text <> "" Then FormJeu.modifierNbCartesParType(CInt(TxtNbParType.Text))
        If TxtTemps.Text <> "" Then FormJeu.modifierTempsImpartis(CInt(TxtTemps.Text))
        Me.Close()
    End Sub

    Private Sub BtnTemps_Click(sender As Object, e As EventArgs) Handles BtnTemps.Click
        If tempsInf = False Then
            tempsInf = True
            FormJeu.arreterTempsImpartis(tempsInf)
            TxtTemps.Enabled = False
        Else
            TxtTemps.Enabled = True
            tempsInf = False
            FormJeu.arreterTempsImpartis(tempsInf)
        End If
    End Sub
End Class