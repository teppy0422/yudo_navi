Imports System.IO

Public Class Form0
    Public myHaisaku As String '誘導データの参照ディレクトリ
    Private mousePoint As Point

    Private Sub line_top_MouseDown(sender As Object, e As MouseEventArgs) Handles line_top.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub line_top_MouseMove(sender As Object, e As MouseEventArgs) Handles line_top.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
            'または、つぎのようにする
            'Me.Location = New Point( _
            '    Me.Location.X + e.X - mousePoint.X, _
            '    Me.Location.Y + e.Y - mousePoint.Y)
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'タイトルバーを無しにする
        FormBorderStyle = FormBorderStyle.None
        'タイトルバー
        line_top.Width = Me.Width
        line_top.Left = 0
        line_top.Top = 0
        line_top.Text = ""
        line_top.BackColor = Color.FromArgb(64, 64, 64)
        '背景色
        Me.BackColor = Color.FromArgb(64, 64, 64)

        Dim r As New System.Random(1000)
        Dim rNumber As Integer = r.Next(100)
        If rNumber Mod 2 = 0 Then
            PictureBox1.Visible = False
            PictureBox3.Visible = True
        Else
            PictureBox1.Visible = True
            PictureBox3.Visible = False
        End If
        'ListView
        'setting.txtの読み込み
        Dim stCurrentDir As String = System.Environment.CurrentDirectory
        Dim DataSettingURL As String = stCurrentDir & "\setting.txt"
        If Dir(DataSettingURL) = "" Then
            Dim hStream As System.IO.FileStream
            hStream = System.IO.File.Create(stCurrentDir & "\setting.txt")
            hStream.Close()
        End If
        Dim sr As New System.IO.StreamReader(DataSettingURL, System.Text.Encoding.GetEncoding("UTF-8"))
        While sr.Peek() > -1
            Dim readSP As String() = Split(sr.ReadLine(), ";")
            If "haisaku" = readSP(0) Then myHaisaku = readSP(1)
        End While
        If myHaisaku = Nothing Then myHaisaku = ""
        sr.Close()
        'ListViewにアイテム追加
        With ListView1

            '項目を表示する方法を設定
            '各項目に関する詳しい情報が各列に配置されます。(詳細表示）
            .View = View.Details
            'ラベルが下に付いているフルサイズのアイコンとして表示されます(縮小表示)
            '.View = View.LargeIcon
            'ヘッダー部の追加（幅100ピクセルで左寄せで表示）
            'ヘッダー部のテキストの配置を設定
            .Columns.Add("製品品番_設変", 250, HorizontalAlignment.Left)
            .Columns.Add("更新日時", 250, HorizontalAlignment.Left)
            '.Columns.Add("", 30, HorizontalAlignment.Left)
            Dim a As String, b As String
            Dim myCount As Long
            If System.IO.Directory.Exists(myHaisaku) = False Then System.IO.Directory.CreateDirectory(myHaisaku)
            For Each path As String In Directory.GetDirectories(myHaisaku, "*")
                a = InStrRev(path, "\")
                a = Mid(path, a + 1)
                b = System.IO.Directory.GetLastWriteTime(path)
                b = Mid(b, 1, InStrRev(b, " ") - 1)
                b = Mid(b, 3)
                Dim item() As String = {a, b}
                .Items.Add(New ListViewItem(item))
                myCount = myCount + 1
            Next
            '1行目をセレクト
            'If myCount > 0 Then
            '    .Items(0).Selected = True
            '    .Select()
            'End If
            'Bitmap.MakeTransparent(Bitmap.GetPixel(0, 0))
            Label_count.Text = "登録点数:" & myCount
        End With
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            TextBox1.Text = ListView1.SelectedItems(0).Text
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then Call Button1_Click(sender, e)
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If TextBox1.Text <> "" Then
            Dim url As String = myHaisaku & "\" & TextBox1.Text & "\index.html"
            If System.IO.File.Exists(url) = True Then
                Dim f As New yudo
                f.Owner = Me
                f.Show()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TextBox1.Text) = 36 Then
                Dim hinban As String = Replace(Mid(TextBox1.Text, 1, 15), " ", "") & "_" & Mid(TextBox1.Text, 16, 3)
                TextBox1.Text = hinban
            End If
            Call Button1_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Form0_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout

    End Sub

    Private Sub Form0_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        TextBox1.Text = ""
        Me.ActiveControl = Me.TextBox1
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub line_top_Click(sender As Object, e As EventArgs) Handles line_top.Click

    End Sub

    Private Sub close_Btn_Click(sender As Object, e As EventArgs) Handles close_Btn.Click
        Me.Close()
    End Sub
End Class