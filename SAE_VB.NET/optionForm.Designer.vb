<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class optionForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TxtNbType = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNbParType = New System.Windows.Forms.TextBox()
        Me.ButtonValider = New System.Windows.Forms.Button()
        Me.TxtTemps = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnTemps = New System.Windows.Forms.Button()
        Me.CbTheme = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TxtNbType
        '
        Me.TxtNbType.Location = New System.Drawing.Point(207, 183)
        Me.TxtNbType.Name = "TxtNbType"
        Me.TxtNbType.Size = New System.Drawing.Size(100, 20)
        Me.TxtNbType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.IndianRed
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(110, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "3<=NBTYPE<=6"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.IndianRed
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(117, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "NBparTYPE"
        '
        'TxtNbParType
        '
        Me.TxtNbParType.Location = New System.Drawing.Point(207, 222)
        Me.TxtNbParType.Name = "TxtNbParType"
        Me.TxtNbParType.Size = New System.Drawing.Size(100, 20)
        Me.TxtNbParType.TabIndex = 3
        '
        'ButtonValider
        '
        Me.ButtonValider.BackColor = System.Drawing.Color.IndianRed
        Me.ButtonValider.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ButtonValider.Location = New System.Drawing.Point(335, 301)
        Me.ButtonValider.Name = "ButtonValider"
        Me.ButtonValider.Size = New System.Drawing.Size(75, 23)
        Me.ButtonValider.TabIndex = 4
        Me.ButtonValider.Text = "✔"
        Me.ButtonValider.UseVisualStyleBackColor = False
        '
        'TxtTemps
        '
        Me.TxtTemps.Location = New System.Drawing.Point(207, 146)
        Me.TxtTemps.Name = "TxtTemps"
        Me.TxtTemps.Size = New System.Drawing.Size(100, 20)
        Me.TxtTemps.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.IndianRed
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(110, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "TEMPS REQUIT"
        '
        'BtnTemps
        '
        Me.BtnTemps.BackColor = System.Drawing.Color.IndianRed
        Me.BtnTemps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTemps.ForeColor = System.Drawing.Color.White
        Me.BtnTemps.Location = New System.Drawing.Point(335, 144)
        Me.BtnTemps.Name = "BtnTemps"
        Me.BtnTemps.Size = New System.Drawing.Size(126, 23)
        Me.BtnTemps.TabIndex = 7
        Me.BtnTemps.Text = "DESACTIVER TEMPS"
        Me.BtnTemps.UseVisualStyleBackColor = False
        '
        'CbTheme
        '
        Me.CbTheme.AutoCompleteCustomSource.AddRange(New String() {"Oiseaux", "Planete"})
        Me.CbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTheme.FormattingEnabled = True
        Me.CbTheme.Items.AddRange(New Object() {"Oiseaux", " Thème2"})
        Me.CbTheme.Location = New System.Drawing.Point(585, 175)
        Me.CbTheme.Name = "CbTheme"
        Me.CbTheme.Size = New System.Drawing.Size(121, 21)
        Me.CbTheme.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.IndianRed
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(618, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "THEME"
        '
        'optionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PeachPuff
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CbTheme)
        Me.Controls.Add(Me.BtnTemps)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtTemps)
        Me.Controls.Add(Me.ButtonValider)
        Me.Controls.Add(Me.TxtNbParType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNbType)
        Me.Name = "optionForm"
        Me.Text = "optionForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNbType As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtNbParType As TextBox
    Friend WithEvents ButtonValider As Button
    Friend WithEvents TxtTemps As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnTemps As Button
    Friend WithEvents CbTheme As ComboBox
    Friend WithEvents Label4 As Label
End Class
