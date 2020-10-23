Imports System
Imports System.IO.Ports
Imports System.Text
'スピーチ
Imports System.Speech.Synthesis

Public Class Form1
    Public stCurrentDir As String = System.Environment.CurrentDirectory

    Private Class BuadRateItem
        Inherits Object

        Private m_name As String = ""
        Private m_value As Integer = 0

        '表示名称
        Public Property NAME() As String
            Set(ByVal value As String)
                m_name = value
            End Set
            Get
                Return m_name
            End Get
        End Property

        'ボーレート設定値.
        Public Property BAUDRATE() As Integer
            Set(ByVal value As Integer)
                m_value = value
            End Set
            Get
                Return m_value
            End Get
        End Property

        'コンボボックス表示用の文字列取得関数.
        Public Overrides Function ToString() As String
            Return m_name
        End Function

    End Class

    Private Delegate Sub Delegate_RcvDataToTextBox(data As String)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'setting.txtの読み込み
        Dim DataSettingURL As String = stCurrentDir & "\setting.txt"
        If Dir(DataSettingURL) = "" Then
            Dim hStream As System.IO.FileStream
            hStream = System.IO.File.Create(stCurrentDir & "\setting.txt")

            hStream.Close()
        End If
        Dim sr As New System.IO.StreamReader(DataSettingURL, System.Text.Encoding.GetEncoding("UTF-8"))
        Dim myPort As String, myPort2 As String, myRate As String
        While sr.Peek() > -1
            Dim readSP As String() = Split(sr.ReadLine(), ";")
            If "port" = readSP(0) Then myPort = readSP(1)
            If "rate" = readSP(0) Then myRate = readSP(1)
            If "a" = readSP(0) Then TextBox_a.Text = readSP(1)
            If "b" = readSP(0) Then TextBox_b.Text = readSP(1)
            If "c" = readSP(0) Then TextBox_c.Text = readSP(1)
            If "d" = readSP(0) Then TextBox_d.Text = readSP(1)
            If "f" = readSP(0) Then TextBox_f.Text = readSP(1)
            If "g" = readSP(0) Then TextBox_g.Text = readSP(1)
            If "h" = readSP(0) Then TextBox_h.Text = readSP(1)
            If "e" = readSP(0) Then TextBox_e.Text = readSP(1)

            If "i" = readSP(0) Then CheckBox_i.CheckState = readSP(1)

            If "j" = readSP(0) Then TextBox_j.Text = readSP(1)
            If "port2" = readSP(0) Then myPort2 = readSP(1)
            If "haisaku" = readSP(0) Then TextBox_haisaku.Text = readSP(1)
            If "gouki" = readSP(0) Then TextBox_gouki.Text = readSP(1)
        End While
        sr.Close()
        '利用可能なシリアルポート名の配列を取得する.
        Dim PortList As String()
        PortList = SerialPort.GetPortNames()

        'シリアルポート名をコンボボックスにセットする
        cmbPortName.Items.Clear()
        cmbPortName2.Items.Clear()
        cmbPortName.Items.Add("使用しない")
        cmbPortName2.Items.Add("使用しない")
        Dim PortName As String
        For Each PortName In PortList
            cmbPortName.Items.Add(PortName)
            cmbPortName2.Items.Add(PortName)
            If PortName = myPort Then cmbPortName.Text = PortName
            If PortName = myPort2 Then cmbPortName2.Text = PortName
        Next PortName
        If cmbPortName.Text = "" Then cmbPortName.Text = "使用しない"
        If cmbPortName2.Text = "" Then cmbPortName2.Text = "使用しない"

        'If cmbPortName.Items.Count > 0 Then
        '    cmbPortName.SelectedIndex = 0
        'End If

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        'シリアルポートをオープンしている場合、クローズする.
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If

    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'ダイアログをクローズする.
        Me.Close()

    End Sub

    Private Sub ConnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If SerialPort1.IsOpen = True Then

            'シリアルポートをクローズする.
            SerialPort1.Close()

            'ボタンの表示を[切断]から[接続]に変える.
        Else

            'オープンするシリアルポートをコンボボックスから取り出す.
            SerialPort1.PortName = cmbPortName.SelectedItem.ToString()

            'ボーレートをコンボボックスから取り出す.
            'Dim baud As BuadRateItem
            'baud = cmbBaudRate.SelectedItem
            'SerialPort1.BaudRate = baud.BAUDRATE

            'データビットをセットする. (データビット = 8ビット)
            'SerialPort1.DataBits = 8

            'パリティビットをセットする. (パリティビット = なし)
            'SerialPort1.Parity = Parity.Odd

            'ストップビットをセットする. (ストップビット = 1ビット)
            'SerialPort1.StopBits = StopBits.One

            '文字コードをセットする.
            'SerialPort1.Encoding = Encoding.Unicode

            Try
                'シリアルポートをオープンする.
                SerialPort1.PortName = cmbPortName.Text
                SerialPort1.Open()
                'ボタンの表示を[接続]から[切断]に変える.
                'ConnectButton.Text = "切断"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub SndButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'シリアルポートをオープンしていない場合、処理を行わない.
        If SerialPort1.IsOpen = False Then
            Return
        End If

        'テキストボックスから、送信するテキストを取り出す.
        Dim data As String
        'data = SndTextBox.Text

        '送信するテキストがない場合、データ送信は行わない.
        If String.IsNullOrEmpty(data) Then
            Return
        End If

        Try
            'シリアルポートからテキストを送信する.
            SerialPort1.Write(CLng(data) & Chr(13))

            '送信データを入力するテキストボックスをクリアする.
            'SndTextBox.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        'シリアルポートをオープンしていない場合、処理を行わない.
        If SerialPort1.IsOpen = False Then
            Return
        End If

        Try
            '受信データを読み込む.
            Dim data As String
            data = SerialPort1.ReadExisting()

            '受信したデータをテキストボックスに書き込む.
            Dim args(0) As Object
            args(0) = data
            Invoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), args)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RcvDataToTextBox(data As String)
        '受信データをテキストボックスの最後に追記する.
        If IsNothing(data) = False Then
            'RcvTextBox.AppendText(data)
        End If
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim aa As String = MsgBox("保存しますか？", vbYesNo)
        If aa = vbYes Then
            Call setting_save()
        End If
    End Sub

    Public Function setting_save()
        'ファイルを上書きし、Shift JISで書き込む 
        Dim sw As New System.IO.StreamWriter(stCurrentDir & "\setting.txt", False, System.Text.Encoding.GetEncoding("UTF-8"))
        'TextBox1.Textの内容を1行ずつ書き込む 
        sw.WriteLine("port;" & cmbPortName.Text)
        'sw.WriteLine("rate:" & Replace(cmbBaudRate.Text, "bps", ""))
        sw.WriteLine("a;" & TextBox_a.Text)
        sw.WriteLine("b;" & TextBox_b.Text)
        sw.WriteLine("c;" & TextBox_c.Text)
        sw.WriteLine("d;" & TextBox_d.Text)
        sw.WriteLine("e;" & TextBox_e.Text)
        sw.WriteLine("f;" & TextBox_f.Text)
        sw.WriteLine("g;" & TextBox_g.Text)
        sw.WriteLine("h;" & TextBox_h.Text)
        sw.WriteLine("i;" & CheckBox_i.CheckState)
        sw.WriteLine("j;" & TextBox_j.Text)
        sw.WriteLine("port2;" & cmbPortName2.Text)
        sw.WriteLine("haisaku;" & TextBox_haisaku.Text)
        sw.WriteLine("gouki;" & TextBox_gouki.Text)
        '閉じる 
        sw.Close()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Call setting_save()
    End Sub

    Private Sub grpSetting_Enter(sender As Object, e As EventArgs) Handles grpSetting.Enter

    End Sub

    Private Sub SndTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SndTextBox_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'RcvTextBox.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If SerialPort2.IsOpen = True Then

            'シリアルポートをクローズする.
            SerialPort2.Close()

            'ボタンの表示を[切断]から[接続]に変える.
            Button3.Text = "接続"
        Else

            'オープンするシリアルポートをコンボボックスから取り出す.
            SerialPort2.PortName = cmbPortName2.SelectedItem.ToString()

            Try
                'シリアルポートをオープンする.
                SerialPort2.PortName = cmbPortName2.Text
                SerialPort2.Open()
                'ボタンの表示を[接続]から[切断]に変える.
                Button3.Text = "切断"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub RcvTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SerialPort2_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        'シリアルポートをオープンしていない場合、処理を行わない.
        If SerialPort2.IsOpen = False Then
            Return
        End If

        Try
            '受信データを読み込む.
            Dim data As String
            data = SerialPort2.ReadExisting()

            '受信したデータをテキストボックスに書き込む.
            Dim args(0) As Object
            args(0) = data
            Invoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), args)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim sp As New System.Speech.Synthesis.SpeechSynthesizer
        sp.SpeakAsync(Me.voiceTXT.Text)
    End Sub

    Private Sub voiceTXT_KeyDown(sender As Object, e As KeyEventArgs) Handles voiceTXT.KeyDown
        If e.KeyCode = 13 Then
            Call Button6_Click(sender, e)
        End If
    End Sub

    Private Sub TextBox_haisaku_TextChanged(sender As Object, e As EventArgs) Handles TextBox_haisaku.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub
End Class
