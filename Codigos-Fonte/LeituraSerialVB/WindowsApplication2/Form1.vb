Public Class Form1
    Dim picbfp, picdbp, pmmhd
    Dim img As New Bitmap(320, 240)
    Dim rcvbf As Byte()
    Dim picbf As Byte() = New Byte(800000) {}
    Dim picdb As Byte() = New Byte(800000) {}
    Dim cmode, smode, vmode, cspeed, picsp
    Dim cont As Integer = 0
    Dim name2 As String


    Private Sub com_open(comno As String, speed As Integer)
        If SerialPort1.IsOpen = True Then SerialPort1.Close()
        On Error Resume Next
        SerialPort1.PortName = comno
        SerialPort1.BaudRate = speed
        SerialPort1.StopBits = 1
        SerialPort1.Handshake = False
        SerialPort1.RtsEnable = False
        SerialPort1.Open()
        On Error GoTo 0
        If SerialPort1.IsOpen = False Then
            text2.ForeColor = Color.Red
        Else
            text2.ForeColor = Color.Black
        End If
    End Sub
    Private Sub espcheck()
        cspeed = 1000000
        com_open(text2.Text, cspeed)
    End Sub
    Private Sub modecheck()
        smode = 0
        vmode = 0 ' QQVGA se for 2 é 160x120, 1 é 320x240
        PictureBox1.Width = 320
        PictureBox1.Height = 240

        If SerialPort1.IsOpen = True Then
            SerialPort1.WriteLine("c" + Chr(&H30 + vmode * 4 + smode * 2 + cmode))
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'pmmhd = "P5" + Chr(10) + "320 240" + Chr(10) + "255" + Chr(10)
        'Dim bytesData As Byte()
        'bytesData = System.Text.Encoding.UTF8.GetBytes(pmmhd)
        cmode = 0 : smode = 0 : vmode = 0
        modecheck()
        espcheck()
        picsp = -1 : picbfp = 0

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        SerialPort1.Close()
    End Sub
    Delegate Sub DataDelegate(ByVal sdata As String)
    Private Sub PrintData(ByVal sdata As String)
        Text3.Text = sdata
    End Sub
    Delegate Sub DataDelegate2(ByVal sdata As String)
    Private Sub PrintData2(ByVal sdata As String)
        Dim px, py
        If vmode = 1 Then
            px = 640 : py = 480
        ElseIf vmode = 0 Then
            px = 320 : py = 240
        Else
            px = 160 : py = 120
        End If
        If cmode = 0 Then dispmono(px, py) Else dispcolor(px, py)
        PictureBox1.Image = img

        name2 = cont & ".bmp"
        img.Save(name2)
        cont = cont + 1

        'picbfp = 0
    End Sub
    Private Sub dispcolor(px, py)
        Dim r, g, b
        Dim p, q, s, i, j, k
        For i = 0 To py - 1
            s = px \ 2 ' 80
            For j = 0 To px - 1
                If vmode = 2 And smode = 1 Then

                    k = j * 2
                    If (k Mod 4) = 0 Then
                        p = i * px * 2 + k \ 4
                    Else
                        p = i * px * 2 + s : s = s + 1
                    End If
                    k = j * 2 + 1
                    If (k Mod 4) = 0 Then
                        q = i * px * 2 + k \ 4
                    Else
                        q = i * px * 2 + s : s = s + 1
                    End If
                    Debug.Print(p.ToString + " " + q.ToString)
                ElseIf smode = 1 Then
                    p = i * px * 2 + j : q = p + px
                Else
                    p = (i * px + j) * 2 : q = p + 1 ' nomal
                End If
                r = picbf(p) And &HF8
                g = (picbf(p) And &H7) * 32 + (picbf(q) And &HE0) \ 8
                b = (picbf(q) And &H1F) * 8
                Dim c As Color = Color.FromArgb(r, g, b)
                img.SetPixel(j, i, c)
            Next
        Next
    End Sub
    Private Sub dispmono(px, py)
        Dim i, j, p, s
        For i = 0 To py - 1
            s = px \ 4 ' 40
            For j = 0 To px - 1
                If vmode = 2 And smode = 1 Then
                    If (j Mod 4) = 0 Then
                        p = i * px + j \ 4
                    Else
                        p = i * px + s : s = s + 1
                    End If
                ElseIf smode = 1 Then
                    p = i * px + j \ 2 + (j Mod 2) * px \ 2
                Else
                    p = i * px + j
                End If
                Dim r = picdb(p)
                Dim g = r
                Dim b = r
                Dim c As Color = Color.FromArgb(r, g, b)
                img.SetPixel(j, i, c)
            Next
        Next
    End Sub
    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim sp, rl, rmax, teste
        rcvbf = New Byte(SerialPort1.BytesToRead - 1) {}
        rl = rcvbf.GetLength(0)
        teste = picbf
        teste = picbfp
        teste = rl
        SerialPort1.Read(picbf, picbfp, rl) ' recv to picbf
        If picsp = -1 Then
            For sp = 0 To rl - 1
                If picbf(picbfp + sp) = &HFF Then
                    Buffer.BlockCopy(picbf, picbfp + sp + 1, picbf, 0, rl - 1) ' move to top
                    picsp = sp : rl = rl - sp - 1 : picbfp = 0
                    Exit For
                End If
            Next
        End If
        picbfp = picbfp + rl
        Dim adre As New DataDelegate(AddressOf PrintData)
        Me.BeginInvoke(adre, "[" + picbfp.ToString + "]")
        If vmode = 2 Then
            rmax = 19200 * (cmode + 1)
        Else
            rmax = 76800 * (vmode * 3 + 1) * (cmode + 1)
        End If
        If (picbfp >= rmax) Then
            Buffer.BlockCopy(picbf, 0, picdb, 0, picbfp)
            picsp = -1 : picbfp = 0
            Dim adre2 As New DataDelegate(AddressOf PrintData2)
            Me.BeginInvoke(adre2, "") 'Me.Invoke(adre, "")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        SerialPort1.Close()
        End
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PrintData2("")
        picbfp = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SerialPort1.WriteLine(text1.Text)
    End Sub

    Private Sub btnFimSerial_Click(sender As Object, e As EventArgs) Handles btnFimSerial.Click
        SerialPort1.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        modecheck()
        SerialPort1.DiscardInBuffer()
        picbfp = 0
        Text3.Text = ""
        SerialPort1.WriteLine("c")
    End Sub

    Private Sub text2_TextChanged(sender As Object, e As EventArgs) Handles text2.TextChanged
        If (text2.Text.Length >= 4) Then com_open(text2.Text, cspeed)
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        'Dim i As Integer
        'Dim nome As String
        'i = 0
        'While (True)
        'nome = i & ".bmp"
        'SerialPort1.DiscardInBuffer()
        'picbfp = 0
        'SerialPort1.WriteLine("c")
        'System.Threading.Thread.Sleep(4000)
        'img.Save(nome)
        'PrintData2("")
        'i = i + 1
        'End While

        SerialPort1.WriteLine("r")

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SerialPort1.WriteLine("r")
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
        modecheck()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)
        modecheck()
    End Sub
End Class