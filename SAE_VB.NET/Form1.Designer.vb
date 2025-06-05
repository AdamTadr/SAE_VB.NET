<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.CbNomJ = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnPartie = New System.Windows.Forms.Button()
        Me.BtnQuit = New System.Windows.Forms.Button()
        Me.BtnScore = New System.Windows.Forms.Button()
        Me.BtnOpt = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CbNomJ
        '
        Me.CbNomJ.FormattingEnabled = True
        Me.CbNomJ.Location = New System.Drawing.Point(332, 165)
        Me.CbNomJ.Name = "CbNomJ"
        Me.CbNomJ.Size = New System.Drawing.Size(121, 21)
        Me.CbNomJ.TabIndex = 0
        Me.CbNomJ.Text = "Joueur1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(250, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nom du joueur"
        '
        'BtnPartie
        '
        Me.BtnPartie.Location = New System.Drawing.Point(332, 209)
        Me.BtnPartie.Name = "BtnPartie"
        Me.BtnPartie.Size = New System.Drawing.Size(121, 23)
        Me.BtnPartie.TabIndex = 2
        Me.BtnPartie.Text = "Nouvelle Partie 🕹️"
        Me.BtnPartie.UseVisualStyleBackColor = True
        '
        'BtnQuit
        '
        Me.BtnQuit.Location = New System.Drawing.Point(332, 295)
        Me.BtnQuit.Name = "BtnQuit"
        Me.BtnQuit.Size = New System.Drawing.Size(121, 23)
        Me.BtnQuit.TabIndex = 3
        Me.BtnQuit.Text = "Quitter"
        Me.BtnQuit.UseVisualStyleBackColor = True
        '
        'BtnScore
        '
        Me.BtnScore.Location = New System.Drawing.Point(332, 252)
        Me.BtnScore.Name = "BtnScore"
        Me.BtnScore.Size = New System.Drawing.Size(121, 23)
        Me.BtnScore.TabIndex = 4
        Me.BtnScore.Text = "Score 📊"
        Me.BtnScore.UseVisualStyleBackColor = True
        '
        'BtnOpt
        '
        Me.BtnOpt.Location = New System.Drawing.Point(503, 209)
        Me.BtnOpt.Name = "BtnOpt"
        Me.BtnOpt.Size = New System.Drawing.Size(75, 23)
        Me.BtnOpt.TabIndex = 5
        Me.BtnOpt.Text = "Options 🛠️"
        Me.BtnOpt.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Agency FB", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(351, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 31)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "MEMORY."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SAE_VB.NET.My.Resources.Resources.ExK_qcgVIAIOLwR
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnOpt)
        Me.Controls.Add(Me.BtnScore)
        Me.Controls.Add(Me.BtnQuit)
        Me.Controls.Add(Me.BtnPartie)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbNomJ)
        Me.Name = "Form1"
        Me.Text = "Memory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CbNomJ As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnPartie As Button
    Friend WithEvents BtnQuit As Button
    Friend WithEvents BtnScore As Button
    Friend WithEvents BtnOpt As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Label2 As Label
End Class
