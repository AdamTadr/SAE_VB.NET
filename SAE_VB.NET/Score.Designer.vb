<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Score
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBoxNom = New System.Windows.Forms.ListBox()
        Me.ListBoxScore = New System.Windows.Forms.ListBox()
        Me.ListBoxTpsC = New System.Windows.Forms.ListBox()
        Me.ComboBoxNom = New System.Windows.Forms.ComboBox()
        Me.ListBoxTemps = New System.Windows.Forms.ListBox()
        Me.ListBoxNbPartie = New System.Windows.Forms.ListBox()
        Me.LabelNom = New System.Windows.Forms.Label()
        Me.LabelScore = New System.Windows.Forms.Label()
        Me.LabelTpsCumul = New System.Windows.Forms.Label()
        Me.LabelTemps = New System.Windows.Forms.Label()
        Me.LabelNbPJ = New System.Windows.Forms.Label()
        Me.ButtonOrdre = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonStats = New System.Windows.Forms.Button()
        Me.ButtonQuit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBoxNom
        '
        Me.ListBoxNom.FormattingEnabled = True
        Me.ListBoxNom.Location = New System.Drawing.Point(49, 134)
        Me.ListBoxNom.Name = "ListBoxNom"
        Me.ListBoxNom.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxNom.TabIndex = 0
        '
        'ListBoxScore
        '
        Me.ListBoxScore.FormattingEnabled = True
        Me.ListBoxScore.Location = New System.Drawing.Point(203, 134)
        Me.ListBoxScore.Name = "ListBoxScore"
        Me.ListBoxScore.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxScore.TabIndex = 1
        '
        'ListBoxTpsC
        '
        Me.ListBoxTpsC.FormattingEnabled = True
        Me.ListBoxTpsC.Location = New System.Drawing.Point(663, 134)
        Me.ListBoxTpsC.Name = "ListBoxTpsC"
        Me.ListBoxTpsC.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxTpsC.TabIndex = 2
        '
        'ComboBoxNom
        '
        Me.ComboBoxNom.FormattingEnabled = True
        Me.ComboBoxNom.Location = New System.Drawing.Point(358, 279)
        Me.ComboBoxNom.Name = "ComboBoxNom"
        Me.ComboBoxNom.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxNom.TabIndex = 3
        '
        'ListBoxTemps
        '
        Me.ListBoxTemps.FormattingEnabled = True
        Me.ListBoxTemps.Location = New System.Drawing.Point(359, 134)
        Me.ListBoxTemps.Name = "ListBoxTemps"
        Me.ListBoxTemps.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxTemps.TabIndex = 4
        '
        'ListBoxNbPartie
        '
        Me.ListBoxNbPartie.FormattingEnabled = True
        Me.ListBoxNbPartie.Location = New System.Drawing.Point(510, 134)
        Me.ListBoxNbPartie.Name = "ListBoxNbPartie"
        Me.ListBoxNbPartie.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxNbPartie.TabIndex = 5
        '
        'LabelNom
        '
        Me.LabelNom.AutoSize = True
        Me.LabelNom.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LabelNom.ForeColor = System.Drawing.Color.DarkOrange
        Me.LabelNom.Location = New System.Drawing.Point(49, 93)
        Me.LabelNom.Name = "LabelNom"
        Me.LabelNom.Size = New System.Drawing.Size(32, 13)
        Me.LabelNom.TabIndex = 6
        Me.LabelNom.Text = "NOM"
        '
        'LabelScore
        '
        Me.LabelScore.AutoSize = True
        Me.LabelScore.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LabelScore.ForeColor = System.Drawing.Color.DarkOrange
        Me.LabelScore.Location = New System.Drawing.Point(200, 93)
        Me.LabelScore.Name = "LabelScore"
        Me.LabelScore.Size = New System.Drawing.Size(81, 13)
        Me.LabelScore.TabIndex = 7
        Me.LabelScore.Text = "Score maximum"
        '
        'LabelTpsCumul
        '
        Me.LabelTpsCumul.AutoSize = True
        Me.LabelTpsCumul.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LabelTpsCumul.ForeColor = System.Drawing.Color.DarkOrange
        Me.LabelTpsCumul.Location = New System.Drawing.Point(660, 93)
        Me.LabelTpsCumul.Name = "LabelTpsCumul"
        Me.LabelTpsCumul.Size = New System.Drawing.Size(76, 13)
        Me.LabelTpsCumul.TabIndex = 8
        Me.LabelTpsCumul.Text = "Temps cumulé"
        '
        'LabelTemps
        '
        Me.LabelTemps.AutoSize = True
        Me.LabelTemps.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LabelTemps.ForeColor = System.Drawing.Color.DarkOrange
        Me.LabelTemps.Location = New System.Drawing.Point(356, 93)
        Me.LabelTemps.Name = "LabelTemps"
        Me.LabelTemps.Size = New System.Drawing.Size(82, 13)
        Me.LabelTemps.TabIndex = 9
        Me.LabelTemps.Text = "Temps minimum"
        '
        'LabelNbPJ
        '
        Me.LabelNbPJ.AutoSize = True
        Me.LabelNbPJ.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LabelNbPJ.ForeColor = System.Drawing.Color.DarkOrange
        Me.LabelNbPJ.Location = New System.Drawing.Point(507, 93)
        Me.LabelNbPJ.Name = "LabelNbPJ"
        Me.LabelNbPJ.Size = New System.Drawing.Size(111, 13)
        Me.LabelNbPJ.TabIndex = 10
        Me.LabelNbPJ.Text = "Nombre de partie joué"
        '
        'ButtonOrdre
        '
        Me.ButtonOrdre.ForeColor = System.Drawing.Color.DarkOrange
        Me.ButtonOrdre.Location = New System.Drawing.Point(622, 279)
        Me.ButtonOrdre.Name = "ButtonOrdre"
        Me.ButtonOrdre.Size = New System.Drawing.Size(187, 43)
        Me.ButtonOrdre.TabIndex = 11
        Me.ButtonOrdre.Text = "Inverser Ordre D'affichage"
        Me.ButtonOrdre.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label1.Location = New System.Drawing.Point(225, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Rechercher Joueur"
        '
        'ButtonStats
        '
        Me.ButtonStats.ForeColor = System.Drawing.Color.DarkOrange
        Me.ButtonStats.Location = New System.Drawing.Point(622, 340)
        Me.ButtonStats.Name = "ButtonStats"
        Me.ButtonStats.Size = New System.Drawing.Size(187, 43)
        Me.ButtonStats.TabIndex = 13
        Me.ButtonStats.Text = "Afficher statistiques"
        Me.ButtonStats.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonQuit.ForeColor = System.Drawing.Color.SandyBrown
        Me.ButtonQuit.Location = New System.Drawing.Point(755, 21)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonQuit.TabIndex = 14
        Me.ButtonQuit.Text = "❌"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'Score
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(882, 450)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonStats)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonOrdre)
        Me.Controls.Add(Me.LabelNbPJ)
        Me.Controls.Add(Me.LabelTemps)
        Me.Controls.Add(Me.LabelTpsCumul)
        Me.Controls.Add(Me.LabelScore)
        Me.Controls.Add(Me.LabelNom)
        Me.Controls.Add(Me.ListBoxNbPartie)
        Me.Controls.Add(Me.ListBoxTemps)
        Me.Controls.Add(Me.ComboBoxNom)
        Me.Controls.Add(Me.ListBoxTpsC)
        Me.Controls.Add(Me.ListBoxScore)
        Me.Controls.Add(Me.ListBoxNom)
        Me.Name = "Score"
        Me.Text = "TempsRestant"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBoxNom As ListBox
    Friend WithEvents ListBoxScore As ListBox
    Friend WithEvents ListBoxTpsC As ListBox
    Friend WithEvents ComboBoxNom As ComboBox
    Friend WithEvents ListBoxTemps As ListBox
    Friend WithEvents ListBoxNbPartie As ListBox
    Friend WithEvents LabelNom As Label
    Friend WithEvents LabelScore As Label
    Friend WithEvents LabelTpsCumul As Label
    Friend WithEvents LabelTemps As Label
    Friend WithEvents LabelNbPJ As Label
    Friend WithEvents ButtonOrdre As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonStats As Button
    Friend WithEvents ButtonQuit As Button
End Class
