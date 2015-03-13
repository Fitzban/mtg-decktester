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
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.ButtonRefreshPrices = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bot_black_list = New System.Windows.Forms.RichTextBox()
        Me.CheckBoxTHS = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBNG = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRTR = New System.Windows.Forms.CheckBox()
        Me.CheckBoxM13 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxM11 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxGTC = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDGM = New System.Windows.Forms.CheckBox()
        Me.CheckBoxALL = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.RichTextBox1.Size = New System.Drawing.Size(537, 394)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'deck
        '
        Me.deck.Location = New System.Drawing.Point(565, 125)
        Me.deck.Name = "deck"
        Me.deck.Size = New System.Drawing.Size(256, 563)
        Me.deck.TabIndex = 3
        Me.deck.Text = "Levitation" & Global.Microsoft.VisualBasic.ChrW(10) & "Elite Vanguard"
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
        Me.mtgolibrarydownloader.Location = New System.Drawing.Point(192, 92)
        Me.mtgolibrarydownloader.Name = "mtgolibrarydownloader"
        Me.mtgolibrarydownloader.Size = New System.Drawing.Size(132, 23)
        Me.mtgolibrarydownloader.TabIndex = 19
        Me.mtgolibrarydownloader.Text = "MTGO library"
        Me.mtgolibrarydownloader.UseVisualStyleBackColor = True
        '
        'setcode
        '
        Me.setcode.Location = New System.Drawing.Point(249, 121)
        Me.setcode.Name = "setcode"
        Me.setcode.Size = New System.Drawing.Size(75, 20)
        Me.setcode.TabIndex = 20
        Me.setcode.Text = "m12"
        Me.setcode.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'num_carte_set
        '
        Me.num_carte_set.Location = New System.Drawing.Point(249, 147)
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
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Button3)
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
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(17, 39)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(132, 23)
        Me.ButtonStop.TabIndex = 26
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ButtonRefreshPrices
        '
        Me.ButtonRefreshPrices.Location = New System.Drawing.Point(17, 14)
        Me.ButtonRefreshPrices.Name = "ButtonRefreshPrices"
        Me.ButtonRefreshPrices.Size = New System.Drawing.Size(132, 23)
        Me.ButtonRefreshPrices.TabIndex = 25
        Me.ButtonRefreshPrices.Text = "Refresh prices"
        Me.ButtonRefreshPrices.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(17, 94)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 23)
        Me.Button3.TabIndex = 24
        Me.Button3.Text = "Find bots"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(189, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "# cards"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(189, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "set code"
        '
        'bot_black_list
        '
        Me.bot_black_list.Location = New System.Drawing.Point(827, 125)
        Me.bot_black_list.Name = "bot_black_list"
        Me.bot_black_list.Size = New System.Drawing.Size(256, 563)
        Me.bot_black_list.TabIndex = 23
        Me.bot_black_list.Text = "mojosupernova" & Global.Microsoft.VisualBasic.ChrW(10) & "angelicsupernova" & Global.Microsoft.VisualBasic.ChrW(10) & "thesadbluedoli"
        '
        'CheckBoxTHS
        '
        Me.CheckBoxTHS.AutoSize = True
        Me.CheckBoxTHS.Location = New System.Drawing.Point(456, 108)
        Me.CheckBoxTHS.Name = "CheckBoxTHS"
        Me.CheckBoxTHS.Size = New System.Drawing.Size(48, 17)
        Me.CheckBoxTHS.TabIndex = 24
        Me.CheckBoxTHS.Text = "THS"
        Me.CheckBoxTHS.UseVisualStyleBackColor = True
        '
        'CheckBoxBNG
        '
        Me.CheckBoxBNG.AutoSize = True
        Me.CheckBoxBNG.Location = New System.Drawing.Point(456, 131)
        Me.CheckBoxBNG.Name = "CheckBoxBNG"
        Me.CheckBoxBNG.Size = New System.Drawing.Size(49, 17)
        Me.CheckBoxBNG.TabIndex = 25
        Me.CheckBoxBNG.Text = "BNG"
        Me.CheckBoxBNG.UseVisualStyleBackColor = True
        '
        'CheckBoxRTR
        '
        Me.CheckBoxRTR.AutoSize = True
        Me.CheckBoxRTR.Location = New System.Drawing.Point(456, 154)
        Me.CheckBoxRTR.Name = "CheckBoxRTR"
        Me.CheckBoxRTR.Size = New System.Drawing.Size(49, 17)
        Me.CheckBoxRTR.TabIndex = 26
        Me.CheckBoxRTR.Text = "RTR"
        Me.CheckBoxRTR.UseVisualStyleBackColor = True
        '
        'CheckBoxM13
        '
        Me.CheckBoxM13.AutoSize = True
        Me.CheckBoxM13.Location = New System.Drawing.Point(456, 177)
        Me.CheckBoxM13.Name = "CheckBoxM13"
        Me.CheckBoxM13.Size = New System.Drawing.Size(47, 17)
        Me.CheckBoxM13.TabIndex = 27
        Me.CheckBoxM13.Text = "M13"
        Me.CheckBoxM13.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(400, 108)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(47, 17)
        Me.CheckBox4.TabIndex = 28
        Me.CheckBox4.Text = "M12"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBoxM11
        '
        Me.CheckBoxM11.AutoSize = True
        Me.CheckBoxM11.Location = New System.Drawing.Point(400, 131)
        Me.CheckBoxM11.Name = "CheckBoxM11"
        Me.CheckBoxM11.Size = New System.Drawing.Size(47, 17)
        Me.CheckBoxM11.TabIndex = 29
        Me.CheckBoxM11.Text = "M11"
        Me.CheckBoxM11.UseVisualStyleBackColor = True
        '
        'CheckBoxGTC
        '
        Me.CheckBoxGTC.AutoSize = True
        Me.CheckBoxGTC.Location = New System.Drawing.Point(400, 154)
        Me.CheckBoxGTC.Name = "CheckBoxGTC"
        Me.CheckBoxGTC.Size = New System.Drawing.Size(48, 17)
        Me.CheckBoxGTC.TabIndex = 30
        Me.CheckBoxGTC.Text = "GTC"
        Me.CheckBoxGTC.UseVisualStyleBackColor = True
        '
        'CheckBoxDGM
        '
        Me.CheckBoxDGM.AutoSize = True
        Me.CheckBoxDGM.Location = New System.Drawing.Point(400, 177)
        Me.CheckBoxDGM.Name = "CheckBoxDGM"
        Me.CheckBoxDGM.Size = New System.Drawing.Size(51, 17)
        Me.CheckBoxDGM.TabIndex = 31
        Me.CheckBoxDGM.Text = "DGM"
        Me.CheckBoxDGM.UseVisualStyleBackColor = True
        '
        'CheckBoxALL
        '
        Me.CheckBoxALL.AutoSize = True
        Me.CheckBoxALL.Location = New System.Drawing.Point(418, 206)
        Me.CheckBoxALL.Name = "CheckBoxALL"
        Me.CheckBoxALL.Size = New System.Drawing.Size(45, 17)
        Me.CheckBoxALL.TabIndex = 32
        Me.CheckBoxALL.Text = "ALL"
        Me.CheckBoxALL.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(562, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Enter here the list of cards to trade"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(824, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Enter here the list of bots to exclude"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonStop)
        Me.GroupBox1.Controls.Add(Me.ButtonRefreshPrices)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 83)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "This downloads the prices from MTGO Library"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 700)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CheckBoxALL)
        Me.Controls.Add(Me.CheckBoxDGM)
        Me.Controls.Add(Me.CheckBoxGTC)
        Me.Controls.Add(Me.CheckBoxM11)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBoxM13)
        Me.Controls.Add(Me.CheckBoxRTR)
        Me.Controls.Add(Me.CheckBoxBNG)
        Me.Controls.Add(Me.CheckBoxTHS)
        Me.Controls.Add(Me.bot_black_list)
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
        Me.GroupBox1.ResumeLayout(False)
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
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents bot_black_list As System.Windows.Forms.RichTextBox
    Friend WithEvents CheckBoxTHS As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxBNG As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRTR As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxM13 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxM11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxGTC As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDGM As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxALL As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonRefreshPrices As System.Windows.Forms.Button
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
