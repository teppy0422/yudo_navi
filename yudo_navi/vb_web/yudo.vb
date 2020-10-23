'スピーチ
Imports System.IO.Ports
Imports System.Speech.Synthesis


Public Class yudo
    'ディスプレイの高さ
    Public h As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
    'ディスプレイの幅
    Public w As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
    Public strBeforeHTML As String
    Public stCurrentDir As String = System.Environment.CurrentDirectory
    Public hinban As String = Form0.TextBox1.Text
    Public mySpeak As String 'これにテキストを入れるとspeakして""にする
    Public myYudo As String 'これにhtmlの値を入れるとtimerで表示して""にする
    Public myVal As Integer 'ONSWの順番を保持
    Public readSPyudo As String() 'yudo.txtで参照した行を保持
    Public swCount As Integer '引張確認SWの回数を保持
    'モード選択
    Public myMode As String = "" '後ハメ図⇔端末経路
    'ここから下はオプションに移動済み
    Public myPort As String, myPort2 As String
    Public myRate As String
    Public MonitorWidth As Long
    Public MonitorLeft As Long
    Public MortorDiameter As Single
    Public MortorStepMax As Long
    Public MAXmm As Long
    Public mmStep As Single = MortorDiameter * 3.141592 / MortorStepMax '1stepあたりの移動mm
    Public xStep As Long = 666666
    Public xLED As String, LEDWmm As Integer = 5000, LEDcount As Integer = 300, LEDleft As Integer = 325
    Public LEDpitch As Single = LEDWmm / LEDcount
    Public myWidth As Long '冶具の幅mm
    Public myFlip As Boolean '左右反転させるならtrue
    Public myHaisaku As String '誘導データの参照ディレクトリ
    Public noPictureCount As Long '写真が無いコネクタの数
    Public myPushDir As String
    Public gouki As String
    Public AnnouncePath As String

    '教育ナビ用の変数
    Public myEducation As String = ""

    Private Sub yudo_Load(sender As Object, e As EventArgs) Handles Me.Load
        'シリアルポートをオープンしている場合、クローズする.
        If SerialPort1.IsOpen Then SerialPort1.Close()
        If SerialPort2.IsOpen Then SerialPort2.Close()
        'setting.txtの読み込み
        Dim DataSettingURL As String = stCurrentDir & "\setting.txt"
        Dim sr As New System.IO.StreamReader(DataSettingURL, System.Text.Encoding.GetEncoding("UTF-8"))
        While sr.Peek() > -1
            Dim readSP As String() = Split(sr.ReadLine(), ";")
            If "port" = readSP(0) Then myPort = readSP(1)
            If "rate" = readSP(0) Then myRate = readSP(1)
            If "a" = readSP(0) Then MonitorWidth = readSP(1)
            If "b" = readSP(0) Then MonitorLeft = readSP(1)
            If "c" = readSP(0) Then MortorDiameter = readSP(1)
            If "d" = readSP(0) Then MortorStepMax = readSP(1)
            If "e" = readSP(0) Then MAXmm = readSP(1)
            If "f" = readSP(0) Then LEDWmm = readSP(1)
            If "g" = readSP(0) Then LEDcount = readSP(1)
            If "h" = readSP(0) Then LEDleft = readSP(1)
            If "port2" = readSP(0) Then myPort2 = readSP(1)
            If "haisaku" = readSP(0) Then myHaisaku = readSP(1)
            If "i" = readSP(0) Then myFlip = readSP(1)
            If "j" = readSP(0) Then AnnouncePath = readSP(1)
            If "gouki" = readSP(0) Then gouki = readSP(1)
        End While
        If InStr(myHaisaku, "\") > 0 Then myPushDir = Mid(myHaisaku, 1, InStrRev(myHaisaku, "\")) & "号機\"

        mmStep = MortorDiameter * 3.141592 / MortorStepMax
        sr.Close()
        '冶具の幅mmを取得_左右反転させる用
        'width.txtの読み込み
        Dim sentaku As String = Form0.TextBox1.Text
        DataSettingURL = myHaisaku & "\" & sentaku & "\xMove\width.txt"
        If System.IO.File.Exists(DataSettingURL) = True Then
            sr = New System.IO.StreamReader(DataSettingURL, System.Text.Encoding.GetEncoding("UTF-8"))
            While sr.Peek() > -1
                myWidth = sr.ReadLine
            End While
            sr.Close()
        Else
            myWidth = 0
        End If

        'index.htmlを開く
        'Dim url As String = myHaisaku & "\" & sentaku & "\index.html"
        'WebBrowser1.Navigate(url)
        Call gamen_kousin("index")
        'メニューバー
        'Me.FormBorderStyle = FormBorderStyle.None '完全に消す
        'Me.ControlBox = False
        'Me.Text = ""
        'フルスクリーン
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        '先ハメ内職誘導用 todo
        Dim tempMode As Boolean = True
        If tempMode = True Then
            WebBrowser1.Dock = Left
            WebBrowser1.Width = Me.Width / 2
            WebBrowser1.Height = Me.Height
            WebBrowser2.Dock = Right
            WebBrowser2.Width = Me.Width / 2
            WebBrowser2.Height = Me.Height
        Else
            WebBrowser2.Visible = False
        End If
        'タイマーの開始
        Timer1.Start()
        Timer2.Start()
        Label2.Top = h - Label2.Height
        Label2.Left = w - Label2.Width - 2
        Label3.Top = h - Label3.Height '- Label2.Height
        Label3.Left = w - Label3.Width - 2
        Label1.Top = h - Label1.Height - Label2.Height - Label3.Height
        Label1.Left = w - Label1.Width - 2

        'シリアル接続temp
        If myPort <> "使用しない" Then
            'オープンするシリアルポートをコンボボックスから取り出す.
            SerialPort1.PortName = myPort
            'ボーレートをコンボボックスから取り出す.
            'SerialPort1.BaudRate = CLng(myRate)
            'パリティビットをセットする. (パリティビット = なし)
            'SerialPort1.Parity = IO.Ports.Parity.None
            'ストップビットをセットする. (ストップビット = 1ビット)
            'SerialPort1.StopBits = IO.Ports.StopBits.None
            '文字コードをセットする.
            'SerialPort1.Encoding = Encoding.Unicode
            Try
                'シリアルポートをオープンする.
                SerialPort1.PortName = myPort
                SerialPort1.Open()

                SerialPort1.NewLine = Chr(13)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        'シリアル接続temp
        If myPort2 <> "使用しない" Then
            'オープンするシリアルポートをコンボボックスから取り出す.
            SerialPort2.PortName = myPort2
            Try
                'シリアルポートをオープンする.
                SerialPort2.PortName = myPort2
                SerialPort2.Open()
                SerialPort2.NewLine = Chr(13)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub yudo_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Label2.Top = h - Label2.Height
        'Label2.Left = w - Label2.Width - 2
        'Label1.Top = h - Label1.Height - Label2.Height
        'Label1.Left = w - Label1.Width - 2
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call gamen_kousin(sender.text)
        End If
    End Sub
    Public Function gamen_kousin(sender As String)
        '誘導画面の更新
        Dim senderSTR As String = sender, mySTR As String
        Dim myURL As String, mySkip As Boolean = False, educationURL As String
        '教育ナビ用のファイル読み込み
        If InStr("previous_follow", senderSTR) > 0 Then
            educationURL = myHaisaku & "\" & hinban & "\Edu\education.csv"
            senderSTR = read_myEduication(myEducation, educationURL, senderSTR)
            myEducation = senderSTR
        End If
        If InStr("index_detail_change_exit", senderSTR) > 0 Then
            If senderSTR = "change" Then If myMode = "" Then Label3.Text = "端末経路" : myMode = "-" Else Label3.Text = "後ハメ図" : myMode = ""
            If senderSTR = "change" Then mySpeak = "モードを切り替えました"
            If senderSTR = "detail" Then mySpeak = "詳細図を表示しました。":pushProgress("結き")
            If senderSTR = "exit" Then pushProgress("終了") : Me.Close() : Exit Function
            myURL = myHaisaku & "\" & hinban & "\" & senderSTR & ".html"
            mySkip = True
        Else
            Select Case Len(senderSTR)
                Case <= 3
                    mySTR = senderSTR
                    myURL = myHaisaku & "\" & hinban & "\" & mySTR & myMode & ".html"
                Case 4
                    mySTR = senderSTR
                    myURL = myHaisaku & "\" & hinban & "\" & mySTR & ".html"
                Case Else
                    mySTR = Mid(senderSTR, 12, 4)
                    myURL = myHaisaku & "\" & hinban & "\" & mySTR & ".html"
            End Select
        End If

        If senderSTR = "index" Then
            noPictureCount = checkVer("noPictureCount")
            If noPictureCount > 0 Then
                mySpeak = "登録されていない端末が " & noPictureCount & " 点あります。"
            ElseIf noPictureCount = -1 Then
                mySpeak = "登録されていない端末スウは不明です。最新の生産準備ぷらすで再作成してください。"
            Else
                mySpeak = "スベテの端末が登録されています。"
            End If
            If checkVer("後ハメのみ") = "1" Then
                mySpeak = mySpeak & "。ジグが登録されていない為、あとハメ図のみの表示となります。"
            End If

            Call pushProgress("配索")
        End If
        'WebBrowser1.Url = New Uri(myURL)
        'WebBrowser1.Navigate(myURL)
        'Application.DoEvents()
        'WebBrowser1.Update()
        'Application.DoEvents()
        WebBrowser1.Navigate(myURL)
        Application.DoEvents()
        WebBrowser1.Update()
        Application.DoEvents()
        TextBox1.Text = ""
        If mySkip = True Then Exit Function

        Dim xMoveURL As String
        If Len(Replace(mySTR, "-", "")) <= 3 Then
            xMoveURL = myHaisaku & "\" & hinban & "\xMove\後ハメ図.csv"
        Else
            If Dir(myHaisaku & "\" & hinban & "\xMove\構成.csv", vbDirectory) <> "" Then
                xMoveURL = myHaisaku & "\" & hinban & "\xMove\構成.csv"
            Else '先ハメ誘導の場合
                xMoveURL = myHaisaku & "\" & hinban & "\ssc\xMove.csv"
            End If
        End If

        Call read_xMoveURL(mySTR, xMoveURL)
    End Function
    '教育ナビ用のファイル読み込み
    Public Function read_myEduication(myEducation As String, educationURL As String, senderStr As String)
        Dim sr As New System.IO.StreamReader(educationURL, System.Text.Encoding.GetEncoding("UTF-8"))
        Dim readBak As String, nextConfirm As Boolean
        While sr.Peek() > -1
            Dim readSP As String() = Split(sr.ReadLine(), ",")
            If myEducation = "" Or nextConfirm = True Then
                read_myEduication = readSP(0)
                Exit Function
            ElseIf myEducation = readSP(0) Then
                If senderStr = "previous" Then
                    read_myEduication = readBak
                    Exit Function
                ElseIf senderStr = "follow" Then
                    nextConfirm = True
                End If
            End If
            readBak = readSP(0)
        End While
        sr.Close()
    End Function
    Public Function read_xMoveURL(myStr As String, xMoveURL As String)
        If System.IO.File.Exists(xMoveURL) = True Then
            Dim sr As New System.IO.StreamReader(xMoveURL, System.Text.Encoding.GetEncoding("UTF-8"))
            While sr.Peek() > -1
                Dim readSP As String() = Split(sr.ReadLine(), ",")
                If Replace(myStr, "-", "") = readSP(0) Then
                    Dim mm As Long = CSng(readSP(1))
                    If myFlip = True Then mm = myWidth - mm '左右反転するにチェックを入れてる場合、治具サイズから引く
                    If mm < 0 Then mm = myWidth '値がマイナスになる場合、冶具サイズに置き換える
                    If mm > MAXmm Then mm = MAXmm '移動距離を超える場合、値を移動距離に置き換える
                    xStep = ((mm - (MonitorWidth / 2)) - MonitorLeft) 'ステップ数に変換
                    If xStep < 0 Then xStep = 0
                    xStep = xStep / mmStep
                    'If MortorCW = "CCW" Then xStep = -xStep
                    If InStr(xMoveURL, "後ハメ図") > 0 Then
                        If readSP(2) <> "" Then
                            mySpeak = "端末 " & readSP(0) & "は成型方向の指示があります。"
                        Else
                            mySpeak = ""
                        End If
                    End If
                    xLED = ""
                    If InStr(xMoveURL, "構成") > 0 Then
                        Dim tempInt As Integer, ledStart As Long, ledEnd As Long, ledTemp As Long
                        ledStart = readSP(2)
                        ledEnd = readSP(3)
                        '左右反対の場合
                        If myFlip = True Then
                            ledTemp = ledStart
                            ledStart = myWidth - ledEnd
                            ledEnd = myWidth - ledTemp
                        End If

                        tempInt = (ledStart - LEDleft + 11.5) / LEDpitch
                        xLED = tempInt
                        tempInt = (ledEnd - LEDleft + 11.5) / LEDpitch
                        xLED = xLED & "," & tempInt
                        tempInt = readSP(4) Mod 256
                        xLED = xLED & "," & tempInt
                        tempInt = Int(readSP(4) / 256) Mod 256
                        xLED = xLED & "," & tempInt
                        tempInt = Int(readSP(4) / 256 / 256)
                        xLED = xLED & "," & tempInt
                        If UBound(readSP) >= 5 Then
                            mySpeak = readSP(5)
                        End If
                    End If
                    Exit While
                End If
            End While
            sr.Close()
        End If
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Date.Now.ToString("HH:mm:ss")
        Me.ActiveControl = Me.TextBox1 'JavaScript実行でフォーカスをHtmlに取られるからフォーカスをtextbox1に移す
        '誘導モニタの移動
        If myPort <> "使用しない" Then
            If xStep <> 666666 Then
                Me.SerialPort1.WriteLine(xStep & "," & xLED) 'ArduinoにStep数を送る
                xStep = 666666
                xLED = 0
            End If
        End If
        If mySpeak <> "" Then
            Dim sp As New System.Speech.Synthesis.SpeechSynthesizer
            sp.SpeakAsync(mySpeak)
            mySpeak = ""
        End If
        If myYudo <> "" Then
            Call gamen_kousin(myYudo)
            myYudo = ""
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        'WindowsFormの場合の簡単な例
        'フォームにツールボックスからSerialPortを貼り付け。
        '追加されたSerialPortを選択して、プロパティウィンドウでDataReceivedイベントを作ります。
        'あとは以下のようなコードでTextBoxに表示できます。
        'Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        System.Threading.Thread.Sleep(500)
        Dim Data As String = SerialPort1.ReadExisting()
        '   'イベントは別スレッドで発生するのでフォームのスレッドに同期させる必要があります。
        '   Dim action As Action(Of String) = AddressOf AppendTextBox
        '   Me.Invoke(action, strReceiveData)
        'End Sub
        Debug.Print(Data)
        If myPort2 <> "使用しない" Then
            'Navi40用_挿入確認SWが押された時の処理
            If Data Like "*next*" Then
                swCount = swCount + 1
                If swCount >= 1 Then
                    myVal = myVal + 1
                    If myVal > UBound(readSPyudo) Then myVal = 1
                    myYudo = readSPyudo(myVal)
                    swCount = 0
                End If
            End If
        Else
            'Navi教育用_SWが押された時の処理_ttttt_このクラスからyudo.textbox1.textを扱えない
            'If Data Like "*follow*" Then
            '    'Me.TextBox1.Text = "follow"
            '    My.Forms.yudo.TextBox1.Text = "follow"
            'End If
        End If
    End Sub

    Private Sub SerialPort2_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        'CBからのシリアル受信
        System.Threading.Thread.Sleep(100)
        Dim data As String = SerialPort2.ReadExisting()
        Dim yudoURL As String = myHaisaku & "\" & hinban & "\ssc\yudo.csv"
        Dim sr As New System.IO.StreamReader(yudoURL, System.Text.Encoding.GetEncoding("UTF-8"))
        While sr.Peek() > -1
            Dim readSP() As String = Split(sr.ReadLine(), ",")
            If data Like "*" & readSP(0) & "*" Then
                myYudo = readSP(1)
                myVal = 1
                'TextBox1.Text = readSP(1) & Chr(34)
                '受信したデータをテキストボックスに書き込む
                'Dim args(0) As Object
                'args(0) = readSP(1)
                'Invoke(New Delegate_RcvDataToTextBox(AddressOf Me.RcvDataToTextBox), args)
                'Call gamen_kousin(readSP(1))
                'completeFlg = False
                readSPyudo = readSP
                PlaySound(stCurrentDir & "\sound\se_amb07.wav")
                Exit While
            End If
        End While
        sr.Close()
    End Sub
    Private Delegate Sub Delegate_RcvDataToTextBox(data As String)
    Private player As System.Media.SoundPlayer = Nothing
    Private Sub RcvDataToTextBox(data As String)
        '受信データをテキストボックスの最後に追記する.
        If IsNothing(data) = False Then
            TextBox1.AppendText(data)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim announceFullPath = AnnouncePath & "\" & gouki & "\導通担当名.txt"
        If System.IO.File.Exists(announceFullPath) Then
            Dim myAnnounce As String
            Dim fi As New System.IO.FileInfo(announceFullPath)
            Dim ts1 As New TimeSpan(0, 0, 2, 0)
            Dim ts2 As Date = fi.CreationTime + ts1
            If ts2 < Now Then
                Dim sr As New System.IO.StreamReader(announceFullPath, System.Text.Encoding.GetEncoding("shift-jis"))
                While sr.Peek() > -1
                    myAnnounce = myAnnounce & "," & sr.ReadLine()
                End While
                myAnnounce = Mid(myAnnounce, 2)
                sr.Close()
                Dim sp As New System.Speech.Synthesis.SpeechSynthesizer
                sp.SpeakAsync(myAnnounce)
                System.IO.File.Delete(announceFullPath)
            End If
        End If
    End Sub
    'WAVEファイルを再生する
    Private Sub PlaySound(ByVal waveFile As String)
        '再生されているときは止める
        If Not (player Is Nothing) Then
            StopSound()
        End If

        '読み込む
        player = New System.Media.SoundPlayer(waveFile)
        '非同期再生する
        player.Play()

        '次のようにすると、ループ再生される
        'player.PlayLooping()

        '次のようにすると、最後まで再生し終えるまで待機する
        'player.PlaySync()
    End Sub

    '再生されている音を止める
    Private Sub StopSound()
        If Not (player Is Nothing) Then
            player.Stop()
            player.Dispose()
            player = Nothing
        End If
    End Sub
    Public Function checkVer(ByVal val As String) As String
        'version.txtの読み込み
        checkVer = -1
        Dim DataSettingURL As String = myHaisaku & "\" & hinban & "\version.txt"
        If System.IO.File.Exists(DataSettingURL) = False Then Exit Function
        Dim sr As New System.IO.StreamReader(DataSettingURL, System.Text.Encoding.GetEncoding("shift-jis"))
        While sr.Peek() > -1
            Dim readSP As String() = Split(sr.ReadLine(), ":")
            If val = readSP(0) Then checkVer = readSP(1)
        End While
        sr.Close()
    End Function

    Sub pushProgress(ByVal proGress)

        If System.IO.Directory.Exists(myPushDir) = False Then MkDir(myPushDir)

        Dim pushFile As String = myPushDir & gouki & ".txt"
        If proGress = "終了" Then
            System.IO.File.Delete(pushFile)
        Else
            Dim sw As New System.IO.StreamWriter(pushFile, False, System.Text.Encoding.GetEncoding("shift-jis"))
            'TextBox1.Textの内容を1行ずつ書き込む 
            sw.WriteLine(hinban & "," & proGress)
            '閉じる 
            sw.Close()
        End If

    End Sub
End Class

