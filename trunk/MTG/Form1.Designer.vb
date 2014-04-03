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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.num_popolazioni = New System.Windows.Forms.MaskedTextBox()
        Me.mtgolibrarydownloader = New System.Windows.Forms.Button()
        Me.setcode = New System.Windows.Forms.MaskedTextBox()
        Me.num_carte_set = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
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
        Me.RichTextBox1.Location = New System.Drawing.Point(13, 294)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(854, 394)
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
        Me.in_num_deck.Text = "20"
        Me.in_num_deck.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'in_num_deck_test
        '
        Me.in_num_deck_test.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.in_num_deck_test.Location = New System.Drawing.Point(363, 41)
        Me.in_num_deck_test.Name = "in_num_deck_test"
        Me.in_num_deck_test.Size = New System.Drawing.Size(100, 20)
        Me.in_num_deck_test.TabIndex = 10
        Me.in_num_deck_test.Text = "10"
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
        Me.turn_log.Location = New System.Drawing.Point(651, 44)
        Me.turn_log.Name = "turn_log"
        Me.turn_log.Size = New System.Drawing.Size(70, 17)
        Me.turn_log.TabIndex = 16
        Me.turn_log.Text = "Log turns"
        Me.turn_log.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(469, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "# di popolazioni"
        '
        'num_popolazioni
        '
        Me.num_popolazioni.Location = New System.Drawing.Point(565, 41)
        Me.num_popolazioni.Name = "num_popolazioni"
        Me.num_popolazioni.Size = New System.Drawing.Size(75, 20)
        Me.num_popolazioni.TabIndex = 18
        Me.num_popolazioni.Text = "20"
        Me.num_popolazioni.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'mtgolibrarydownloader
        '
        Me.mtgolibrarydownloader.Location = New System.Drawing.Point(17, 46)
        Me.mtgolibrarydownloader.Name = "mtgolibrarydownloader"
        Me.mtgolibrarydownloader.Size = New System.Drawing.Size(132, 23)
        Me.mtgolibrarydownloader.TabIndex = 19
        Me.mtgolibrarydownloader.Text = "MTGO library"
        Me.mtgolibrarydownloader.UseVisualStyleBackColor = True
        '
        'setcode
        '
        Me.setcode.Location = New System.Drawing.Point(74, 75)
        Me.setcode.Name = "setcode"
        Me.setcode.Size = New System.Drawing.Size(75, 20)
        Me.setcode.TabIndex = 20
        Me.setcode.Text = "bng"
        Me.setcode.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'num_carte_set
        '
        Me.num_carte_set.Location = New System.Drawing.Point(74, 101)
        Me.num_carte_set.Mask = "000"
        Me.num_carte_set.Name = "num_carte_set"
        Me.num_carte_set.Size = New System.Drawing.Size(75, 20)
        Me.num_carte_set.TabIndex = 21
        Me.num_carte_set.Text = "165"
        Me.num_carte_set.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.mtgolibrarydownloader)
        Me.Panel1.Controls.Add(Me.num_carte_set)
        Me.Panel1.Controls.Add(Me.setcode)
        Me.Panel1.Location = New System.Drawing.Point(13, 108)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 180)
        Me.Panel1.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "# cards"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "set code"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 700)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.num_popolazioni)
        Me.Controls.Add(Me.Label4)
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
        Me.Controls.Add(Me.MaskedTextBox1)
        Me.Controls.Add(Me.deck)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents deck As System.Windows.Forms.RichTextBox
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents num_popolazioni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtgolibrarydownloader As System.Windows.Forms.Button
    Friend WithEvents setcode As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents num_carte_set As System.Windows.Forms.MaskedTextBox

End Class
