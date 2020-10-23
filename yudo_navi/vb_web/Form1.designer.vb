<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.cmbPortName = New System.Windows.Forms.ComboBox()
        Me.grpSetting = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox_a = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_e = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox_h = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox_g = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_f = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_d = New System.Windows.Forms.TextBox()
        Me.TextBox_c = New System.Windows.Forms.TextBox()
        Me.TextBox_b = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.RcvTextBox2 = New System.Windows.Forms.TextBox()
        Me.cmbPortName2 = New System.Windows.Forms.ComboBox()
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.voiceTXT = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TextBox_haisaku = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CheckBox_i = New System.Windows.Forms.CheckBox()
        Me.TextBox_gouki = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TextBox_j = New System.Windows.Forms.TextBox()
        Me.grpSetting.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'cmbPortName
        '
        Me.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortName.FormattingEnabled = True
        Me.cmbPortName.Location = New System.Drawing.Point(15, 46)
        Me.cmbPortName.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.cmbPortName.Name = "cmbPortName"
        Me.cmbPortName.Size = New System.Drawing.Size(203, 32)
        Me.cmbPortName.TabIndex = 2
        '
        'grpSetting
        '
        Me.grpSetting.Controls.Add(Me.Label10)
        Me.grpSetting.Controls.Add(Me.cmbPortName)
        Me.grpSetting.Location = New System.Drawing.Point(26, 270)
        Me.grpSetting.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.grpSetting.Name = "grpSetting"
        Me.grpSetting.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.grpSetting.Size = New System.Drawing.Size(1337, 114)
        Me.grpSetting.TabIndex = 3
        Me.grpSetting.TabStop = False
        Me.grpSetting.Text = "シリアル設定_Arduino"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(256, 50)
        Me.Label10.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 24)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "9600,8,none,1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(971, 316)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(323, 188)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'TextBox_a
        '
        Me.TextBox_a.Location = New System.Drawing.Point(52, 36)
        Me.TextBox_a.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_a.Name = "TextBox_a"
        Me.TextBox_a.Size = New System.Drawing.Size(160, 31)
        Me.TextBox_a.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBox_e)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBox_h)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextBox_g)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBox_f)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox_d)
        Me.GroupBox1.Controls.Add(Me.TextBox_c)
        Me.GroupBox1.Controls.Add(Me.TextBox_b)
        Me.GroupBox1.Controls.Add(Me.TextBox_a)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 396)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(1339, 518)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ディスプレイ移動設定"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(225, 222)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "e_最大距離mm"
        '
        'TextBox_e
        '
        Me.TextBox_e.Location = New System.Drawing.Point(52, 216)
        Me.TextBox_e.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_e.Name = "TextBox_e"
        Me.TextBox_e.Size = New System.Drawing.Size(160, 31)
        Me.TextBox_e.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 278)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 24)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "LEDテープ"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(221, 412)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 24)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "h_LEDleft"
        '
        'TextBox_h
        '
        Me.TextBox_h.Location = New System.Drawing.Point(50, 402)
        Me.TextBox_h.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_h.Name = "TextBox_h"
        Me.TextBox_h.Size = New System.Drawing.Size(160, 31)
        Me.TextBox_h.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(221, 364)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 24)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "g_LEDの数"
        '
        'TextBox_g
        '
        Me.TextBox_g.Location = New System.Drawing.Point(50, 354)
        Me.TextBox_g.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_g.Name = "TextBox_g"
        Me.TextBox_g.Size = New System.Drawing.Size(160, 31)
        Me.TextBox_g.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(223, 316)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 24)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "f_長さ"
        '
        'TextBox_f
        '
        Me.TextBox_f.Location = New System.Drawing.Point(50, 306)
        Me.TextBox_f.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_f.Name = "TextBox_f"
        Me.TextBox_f.Size = New System.Drawing.Size(160, 31)
        Me.TextBox_f.TabIndex = 8
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(971, 16)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(323, 284)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(223, 180)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 24)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "d_Step数/1回転"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(223, 136)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "c_直径mm"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 92)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 24)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "b_モニタleftmm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(223, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 24)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "a_モニタ幅mm"
        '
        'TextBox_d
        '
        Me.TextBox_d.Location = New System.Drawing.Point(52, 170)
        Me.TextBox_d.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_d.Name = "TextBox_d"
        Me.TextBox_d.Size = New System.Drawing.Size(160, 31)
        Me.TextBox_d.TabIndex = 6
        '
        'TextBox_c
        '
        Me.TextBox_c.Location = New System.Drawing.Point(52, 124)
        Me.TextBox_c.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_c.Name = "TextBox_c"
        Me.TextBox_c.Size = New System.Drawing.Size(160, 31)
        Me.TextBox_c.TabIndex = 5
        '
        'TextBox_b
        '
        Me.TextBox_b.Location = New System.Drawing.Point(52, 80)
        Me.TextBox_b.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_b.Name = "TextBox_b"
        Me.TextBox_b.Size = New System.Drawing.Size(160, 31)
        Me.TextBox_b.TabIndex = 4
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(405, 16)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(514, 488)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.cmbPortName2)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 970)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox2.Size = New System.Drawing.Size(1339, 128)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "シリアル設定_CB100"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1161, 46)
        Me.Button3.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 48)
        Me.Button3.TabIndex = 2
        Me.Button3.TabStop = False
        Me.Button3.Text = "接続"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.RcvTextBox2)
        Me.GroupBox4.Location = New System.Drawing.Point(269, 16)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox4.Size = New System.Drawing.Size(854, 100)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "受信データ"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(724, 36)
        Me.Button5.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(108, 42)
        Me.Button5.TabIndex = 7
        Me.Button5.TabStop = False
        Me.Button5.Text = "リセット"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'RcvTextBox2
        '
        Me.RcvTextBox2.AcceptsReturn = True
        Me.RcvTextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.RcvTextBox2.Location = New System.Drawing.Point(17, 40)
        Me.RcvTextBox2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.RcvTextBox2.Multiline = True
        Me.RcvTextBox2.Name = "RcvTextBox2"
        Me.RcvTextBox2.ReadOnly = True
        Me.RcvTextBox2.Size = New System.Drawing.Size(689, 38)
        Me.RcvTextBox2.TabIndex = 6
        Me.RcvTextBox2.TabStop = False
        '
        'cmbPortName2
        '
        Me.cmbPortName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortName2.FormattingEnabled = True
        Me.cmbPortName2.Location = New System.Drawing.Point(48, 56)
        Me.cmbPortName2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.cmbPortName2.Name = "cmbPortName2"
        Me.cmbPortName2.Size = New System.Drawing.Size(203, 32)
        Me.cmbPortName2.TabIndex = 12
        '
        'SerialPort2
        '
        Me.SerialPort2.Parity = System.IO.Ports.Parity.Even
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 1110)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox3.Size = New System.Drawing.Size(1339, 132)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "合成音声"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.voiceTXT)
        Me.GroupBox5.Controls.Add(Me.Button6)
        Me.GroupBox5.Location = New System.Drawing.Point(464, 18)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox5.Size = New System.Drawing.Size(854, 100)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "メッセージ"
        '
        'voiceTXT
        '
        Me.voiceTXT.AcceptsReturn = True
        Me.voiceTXT.BackColor = System.Drawing.SystemColors.Window
        Me.voiceTXT.Location = New System.Drawing.Point(17, 36)
        Me.voiceTXT.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.voiceTXT.Multiline = True
        Me.voiceTXT.Name = "voiceTXT"
        Me.voiceTXT.Size = New System.Drawing.Size(689, 38)
        Me.voiceTXT.TabIndex = 13
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(724, 36)
        Me.Button6.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(108, 42)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "再生"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TextBox_haisaku
        '
        Me.TextBox_haisaku.AcceptsReturn = True
        Me.TextBox_haisaku.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_haisaku.Location = New System.Drawing.Point(17, 44)
        Me.TextBox_haisaku.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.TextBox_haisaku.Multiline = True
        Me.TextBox_haisaku.Name = "TextBox_haisaku"
        Me.TextBox_haisaku.Size = New System.Drawing.Size(1046, 38)
        Me.TextBox_haisaku.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TextBox_haisaku)
        Me.GroupBox6.Location = New System.Drawing.Point(26, 24)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox6.Size = New System.Drawing.Size(1081, 114)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "誘導データ参照アドレス"
        '
        'CheckBox_i
        '
        Me.CheckBox_i.AutoSize = True
        Me.CheckBox_i.Location = New System.Drawing.Point(43, 926)
        Me.CheckBox_i.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.CheckBox_i.Name = "CheckBox_i"
        Me.CheckBox_i.Size = New System.Drawing.Size(424, 28)
        Me.CheckBox_i.TabIndex = 11
        Me.CheckBox_i.Text = "ディスプレイの原点を左右反対(右)にする"
        Me.CheckBox_i.UseVisualStyleBackColor = True
        '
        'TextBox_gouki
        '
        Me.TextBox_gouki.AcceptsReturn = True
        Me.TextBox_gouki.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_gouki.Location = New System.Drawing.Point(22, 44)
        Me.TextBox_gouki.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.TextBox_gouki.Multiline = True
        Me.TextBox_gouki.Name = "TextBox_gouki"
        Me.TextBox_gouki.Size = New System.Drawing.Size(197, 38)
        Me.TextBox_gouki.TabIndex = 1
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TextBox_gouki)
        Me.GroupBox7.Location = New System.Drawing.Point(1120, 24)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox7.Size = New System.Drawing.Size(243, 114)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "号機"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TextBox_j)
        Me.GroupBox8.Location = New System.Drawing.Point(26, 150)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox8.Size = New System.Drawing.Size(1081, 114)
        Me.GroupBox8.TabIndex = 5
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "アナウンス参照アドレス"
        '
        'TextBox_j
        '
        Me.TextBox_j.AcceptsReturn = True
        Me.TextBox_j.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_j.Location = New System.Drawing.Point(17, 44)
        Me.TextBox_j.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.TextBox_j.Multiline = True
        Me.TextBox_j.Name = "TextBox_j"
        Me.TextBox_j.Size = New System.Drawing.Size(1046, 38)
        Me.TextBox_j.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1374, 1246)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.CheckBox_i)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpSetting)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Name = "Form1"
        Me.Text = "設定"
        Me.grpSetting.ResumeLayout(False)
        Me.grpSetting.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents cmbPortName As System.Windows.Forms.ComboBox
    Friend WithEvents grpSetting As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox_a As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_d As TextBox
    Friend WithEvents TextBox_c As TextBox
    Friend WithEvents TextBox_b As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents RcvTextBox2 As TextBox
    Friend WithEvents cmbPortName2 As ComboBox
    Friend WithEvents SerialPort2 As IO.Ports.SerialPort
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Button6 As Button
    Friend WithEvents voiceTXT As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox_f As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox_g As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox_h As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_e As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox_haisaku As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents CheckBox_i As CheckBox
    Friend WithEvents TextBox_gouki As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents TextBox_j As TextBox
End Class
