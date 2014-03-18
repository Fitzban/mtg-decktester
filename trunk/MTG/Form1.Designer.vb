<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.deck = New System.Windows.Forms.RichTextBox()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.in_num_deck = New System.Windows.Forms.MaskedTextBox()
        Me.in_num_deck_test = New System.Windows.Forms.MaskedTextBox()
        Me.l1 = New System.Windows.Forms.Label()
        Me.l3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_num_iterazioni_max = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.turn_log = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(13, 43)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "start"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(13, 73)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(854, 615)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'deck
        '
        Me.deck.Location = New System.Drawing.Point(873, 73)
        Me.deck.Name = "deck"
        Me.deck.Size = New System.Drawing.Size(256, 615)
        Me.deck.TabIndex = 3
        Me.deck.Text = ""
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(95, 15)
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.MaskedTextBox1.TabIndex = 4
        Me.MaskedTextBox1.Text = "100"
        Me.MaskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(201, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Capodanno"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1090, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Label1"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(646, 15)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Genetico"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'in_num_deck
        '
        Me.in_num_deck.Location = New System.Drawing.Point(363, 15)
        Me.in_num_deck.Name = "in_num_deck"
        Me.in_num_deck.Size = New System.Drawing.Size(100, 20)
        Me.in_num_deck.TabIndex = 9
        Me.in_num_deck.Text = "100"
        Me.in_num_deck.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'in_num_deck_test
        '
        Me.in_num_deck_test.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.in_num_deck_test.Location = New System.Drawing.Point(363, 41)
        Me.in_num_deck_test.Name = "in_num_deck_test"
        Me.in_num_deck_test.Size = New System.Drawing.Size(100, 20)
        Me.in_num_deck_test.TabIndex = 10
        Me.in_num_deck_test.Text = "20"
        Me.in_num_deck_test.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'l1
        '
        Me.l1.AutoSize = True
        Me.l1.Location = New System.Drawing.Point(305, 15)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(52, 13)
        Me.l1.TabIndex = 11
        Me.l1.Text = "# di deck"
        '
        'l3
        '
        Me.l3.AutoSize = True
        Me.l3.Location = New System.Drawing.Point(306, 44)
        Me.l3.Name = "l3"
        Me.l3.Size = New System.Drawing.Size(34, 13)
        Me.l3.TabIndex = 12
        Me.l3.Text = "# test"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(469, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "# di iterazioni"
        '
        'in_num_iterazioni_max
        '
        Me.in_num_iterazioni_max.Location = New System.Drawing.Point(540, 15)
        Me.in_num_iterazioni_max.Name = "in_num_iterazioni_max"
        Me.in_num_iterazioni_max.Size = New System.Drawing.Size(100, 20)
        Me.in_num_iterazioni_max.TabIndex = 14
        Me.in_num_iterazioni_max.Text = "20"
        Me.in_num_iterazioni_max.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1011, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Status:"
        '
        'turn_log
        '
        Me.turn_log.AutoSize = True
        Me.turn_log.Checked = True
        Me.turn_log.CheckState = System.Windows.Forms.CheckState.Checked
        Me.turn_log.Location = New System.Drawing.Point(1047, 39)
        Me.turn_log.Name = "turn_log"
        Me.turn_log.Size = New System.Drawing.Size(70, 17)
        Me.turn_log.TabIndex = 16
        Me.turn_log.Text = "Log turns"
        Me.turn_log.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 700)
        Me.Controls.Add(Me.turn_log)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.in_num_iterazioni_max)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.l3)
        Me.Controls.Add(Me.l1)
        Me.Controls.Add(Me.in_num_deck_test)
        Me.Controls.Add(Me.in_num_deck)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.Controls.Add(Me.deck)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents deck As System.Windows.Forms.RichTextBox
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents in_num_deck As System.Windows.Forms.MaskedTextBox
    Friend WithEvents in_num_deck_test As System.Windows.Forms.MaskedTextBox
    Friend WithEvents l1 As System.Windows.Forms.Label
    Friend WithEvents l3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_num_iterazioni_max As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents turn_log As System.Windows.Forms.CheckBox

End Class
