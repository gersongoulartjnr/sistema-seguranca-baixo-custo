<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Text3 = New System.Windows.Forms.TextBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.text1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.text2 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnFimSerial = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text3
        '
        Me.Text3.Font = New System.Drawing.Font("MS Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Text3.Location = New System.Drawing.Point(338, 84)
        Me.Text3.Multiline = True
        Me.Text3.Name = "Text3"
        Me.Text3.ReadOnly = True
        Me.Text3.Size = New System.Drawing.Size(107, 20)
        Me.Text3.TabIndex = 2
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        Me.SerialPort1.PortName = "COM8"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 240)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(456, 72)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(177, 25)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Display Image In The Buffer"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'text1
        '
        Me.text1.Location = New System.Drawing.Point(456, 113)
        Me.text1.Name = "text1"
        Me.text1.Size = New System.Drawing.Size(194, 20)
        Me.text1.TabIndex = 10
        Me.text1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(456, 141)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 25)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Send Manual Command Operation"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(338, 119)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 25)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Tirar Foto"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'text2
        '
        Me.text2.Location = New System.Drawing.Point(370, 43)
        Me.text2.Name = "text2"
        Me.text2.Size = New System.Drawing.Size(47, 20)
        Me.text2.TabIndex = 13
        Me.text2.Text = "COM5"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(518, 194)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 58)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Repeat Capture"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(338, 163)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(107, 23)
        Me.btnSalvar.TabIndex = 19
        Me.btnSalvar.Text = "Iniciar capturas"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnFimSerial
        '
        Me.btnFimSerial.Location = New System.Drawing.Point(338, 208)
        Me.btnFimSerial.Name = "btnFimSerial"
        Me.btnFimSerial.Size = New System.Drawing.Size(107, 23)
        Me.btnFimSerial.TabIndex = 20
        Me.btnFimSerial.Text = "Fim"
        Me.btnFimSerial.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 264)
        Me.Controls.Add(Me.btnFimSerial)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.Text3)
        Me.Controls.Add(Me.text2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.text1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text3 As System.Windows.Forms.TextBox
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents text1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents text2 As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnFimSerial As Button
End Class