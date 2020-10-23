Imports System
Imports System.IO.Ports
Imports System.Text
'�X�s�[�`
Imports System.Speech.Synthesis

Public Class Form1
    Public stCurrentDir As String = System.Environment.CurrentDirectory

    Private Class BuadRateItem
        Inherits Object

        Private m_name As String = ""
        Private m_value As Integer = 0

        '�\������
        Public Property NAME() As String
            Set(ByVal value As String)
                m_name = value
            End Set
            Get
                Return m_name
            End Get
        End Property

        '�{�[���[�g�ݒ�l.
        Public Property BAUDRATE() As Integer
            Set(ByVal value As Integer)
                m_value = value
            End Set
            Get
                Return m_value
            End Get
        End Property

        '�R���{�{�b�N�X�\���p�̕�����擾�֐�.
        Public Overrides Function ToString() As String
            Return m_name
        End Function

    End Class

    Private Delegate Sub Delegate_RcvDataToTextBox(data As String)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'setting.txt�̓ǂݍ���
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
        '���p�\�ȃV���A���|�[�g���̔z����擾����.
        Dim PortList As String()
        PortList = SerialPort.GetPortNames()

        '�V���A���|�[�g�����R���{�{�b�N�X�ɃZ�b�g����
        cmbPortName.Items.Clear()
        cmbPortName2.Items.Clear()
        cmbPortName.Items.Add("�g�p���Ȃ�")
        cmbPortName2.Items.Add("�g�p���Ȃ�")
        Dim PortName As String
        For Each PortName In PortList
            cmbPortName.Items.Add(PortName)
            cmbPortName2.Items.Add(PortName)
            If PortName = myPort Then cmbPortName.Text = PortName
            If PortName = myPort2 Then cmbPortName2.Text = PortName
        Next PortName
        If cmbPortName.Text = "" Then cmbPortName.Text = "�g�p���Ȃ�"
        If cmbPortName2.Text = "" Then cmbPortName2.Text = "�g�p���Ȃ�"

        'If cmbPortName.Items.Count > 0 Then
        '    cmbPortName.SelectedIndex = 0
        'End If

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        '�V���A���|�[�g���I�[�v�����Ă���ꍇ�A�N���[�Y����.
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If

    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '�_�C�A���O���N���[�Y����.
        Me.Close()

    End Sub

    Private Sub ConnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If SerialPort1.IsOpen = True Then

            '�V���A���|�[�g���N���[�Y����.
            SerialPort1.Close()

            '�{�^���̕\����[�ؒf]����[�ڑ�]�ɕς���.
        Else

            '�I�[�v������V���A���|�[�g���R���{�{�b�N�X������o��.
            SerialPort1.PortName = cmbPortName.SelectedItem.ToString()

            '�{�[���[�g���R���{�{�b�N�X������o��.
            'Dim baud As BuadRateItem
            'baud = cmbBaudRate.SelectedItem
            'SerialPort1.BaudRate = baud.BAUDRATE

            '�f�[�^�r�b�g���Z�b�g����. (�f�[�^�r�b�g = 8�r�b�g)
            'SerialPort1.DataBits = 8

            '�p���e�B�r�b�g���Z�b�g����. (�p���e�B�r�b�g = �Ȃ�)
            'SerialPort1.Parity = Parity.Odd

            '�X�g�b�v�r�b�g���Z�b�g����. (�X�g�b�v�r�b�g = 1�r�b�g)
            'SerialPort1.StopBits = StopBits.One

            '�����R�[�h���Z�b�g����.
            'SerialPort1.Encoding = Encoding.Unicode

            Try
                '�V���A���|�[�g���I�[�v������.
                SerialPort1.PortName = cmbPortName.Text
                SerialPort1.Open()
                '�{�^���̕\����[�ڑ�]����[�ؒf]�ɕς���.
                'ConnectButton.Text = "�ؒf"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub SndButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '�V���A���|�[�g���I�[�v�����Ă��Ȃ��ꍇ�A�������s��Ȃ�.
        If SerialPort1.IsOpen = False Then
            Return
        End If

        '�e�L�X�g�{�b�N�X����A���M����e�L�X�g�����o��.
        Dim data As String
        'data = SndTextBox.Text

        '���M����e�L�X�g���Ȃ��ꍇ�A�f�[�^���M�͍s��Ȃ�.
        If String.IsNullOrEmpty(data) Then
            Return
        End If

        Try
            '�V���A���|�[�g����e�L�X�g�𑗐M����.
            SerialPort1.Write(CLng(data) & Chr(13))

            '���M�f�[�^����͂���e�L�X�g�{�b�N�X���N���A����.
            'SndTextBox.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        '�V���A���|�[�g���I�[�v�����Ă��Ȃ��ꍇ�A�������s��Ȃ�.
        If SerialPort1.IsOpen = False Then
            Return
        End If

        Try
            '��M�f�[�^��ǂݍ���.
            Dim data As String
            data = SerialPort1.ReadExisting()

            '��M�����f�[�^���e�L�X�g�{�b�N�X�ɏ�������.
            Dim args(0) As Object
            args(0) = data
            Invoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), args)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RcvDataToTextBox(data As String)
        '��M�f�[�^���e�L�X�g�{�b�N�X�̍Ō�ɒǋL����.
        If IsNothing(data) = False Then
            'RcvTextBox.AppendText(data)
        End If
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim aa As String = MsgBox("�ۑ����܂����H", vbYesNo)
        If aa = vbYes Then
            Call setting_save()
        End If
    End Sub

    Public Function setting_save()
        '�t�@�C�����㏑�����AShift JIS�ŏ������� 
        Dim sw As New System.IO.StreamWriter(stCurrentDir & "\setting.txt", False, System.Text.Encoding.GetEncoding("UTF-8"))
        'TextBox1.Text�̓��e��1�s���������� 
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
        '���� 
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

            '�V���A���|�[�g���N���[�Y����.
            SerialPort2.Close()

            '�{�^���̕\����[�ؒf]����[�ڑ�]�ɕς���.
            Button3.Text = "�ڑ�"
        Else

            '�I�[�v������V���A���|�[�g���R���{�{�b�N�X������o��.
            SerialPort2.PortName = cmbPortName2.SelectedItem.ToString()

            Try
                '�V���A���|�[�g���I�[�v������.
                SerialPort2.PortName = cmbPortName2.Text
                SerialPort2.Open()
                '�{�^���̕\����[�ڑ�]����[�ؒf]�ɕς���.
                Button3.Text = "�ؒf"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub RcvTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SerialPort2_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        '�V���A���|�[�g���I�[�v�����Ă��Ȃ��ꍇ�A�������s��Ȃ�.
        If SerialPort2.IsOpen = False Then
            Return
        End If

        Try
            '��M�f�[�^��ǂݍ���.
            Dim data As String
            data = SerialPort2.ReadExisting()

            '��M�����f�[�^���e�L�X�g�{�b�N�X�ɏ�������.
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
