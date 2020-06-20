<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmailSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmailSettings))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.ckEnableEmailNotification = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmailHost = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.ckEnableSSL = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmailCC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHotlineNo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(142, 278)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(177, 33)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.BackColor = System.Drawing.Color.White
        Me.txtEmailAddress.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtEmailAddress.ForeColor = System.Drawing.Color.Black
        Me.txtEmailAddress.Location = New System.Drawing.Point(144, 91)
        Me.txtEmailAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(175, 22)
        Me.txtEmailAddress.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(55, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 390
        Me.Label2.Text = "Email Address"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(79, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 411
        Me.Label7.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.Font = New System.Drawing.Font("Lucida Console", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(144, 116)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(175, 22)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.Text = "Password"
        '
        'ckEnableEmailNotification
        '
        Me.ckEnableEmailNotification.AutoSize = True
        Me.ckEnableEmailNotification.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ckEnableEmailNotification.Location = New System.Drawing.Point(144, 25)
        Me.ckEnableEmailNotification.Name = "ckEnableEmailNotification"
        Me.ckEnableEmailNotification.Size = New System.Drawing.Size(155, 17)
        Me.ckEnableEmailNotification.TabIndex = 415
        Me.ckEnableEmailNotification.Text = "Enable Email Notification"
        Me.ckEnableEmailNotification.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(72, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 417
        Me.Label3.Text = "Email Host"
        '
        'txtEmailHost
        '
        Me.txtEmailHost.BackColor = System.Drawing.Color.White
        Me.txtEmailHost.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtEmailHost.ForeColor = System.Drawing.Color.Black
        Me.txtEmailHost.Location = New System.Drawing.Point(144, 66)
        Me.txtEmailHost.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmailHost.Name = "txtEmailHost"
        Me.txtEmailHost.Size = New System.Drawing.Size(175, 22)
        Me.txtEmailHost.TabIndex = 418
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.Color.White
        Me.txtPort.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtPort.ForeColor = System.Drawing.Color.Black
        Me.txtPort.Location = New System.Drawing.Point(323, 66)
        Me.txtPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(47, 22)
        Me.txtPort.TabIndex = 419
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ckEnableSSL
        '
        Me.ckEnableSSL.AutoSize = True
        Me.ckEnableSSL.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ckEnableSSL.Location = New System.Drawing.Point(144, 45)
        Me.ckEnableSSL.Name = "ckEnableSSL"
        Me.ckEnableSSL.Size = New System.Drawing.Size(81, 17)
        Me.ckEnableSSL.TabIndex = 420
        Me.ckEnableSSL.Text = "SSL Enable"
        Me.ckEnableSSL.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(81, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 422
        Me.Label1.Text = "Email CC"
        '
        'txtEmailCC
        '
        Me.txtEmailCC.BackColor = System.Drawing.Color.White
        Me.txtEmailCC.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtEmailCC.ForeColor = System.Drawing.Color.Black
        Me.txtEmailCC.Location = New System.Drawing.Point(144, 141)
        Me.txtEmailCC.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmailCC.Multiline = True
        Me.txtEmailCC.Name = "txtEmailCC"
        Me.txtEmailCC.Size = New System.Drawing.Size(364, 89)
        Me.txtEmailCC.TabIndex = 421
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(142, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(219, 13)
        Me.Label4.TabIndex = 423
        Me.Label4.Text = "Enter separated by comma for multiple email"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(62, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 425
        Me.Label5.Text = "Hot Line No."
        '
        'txtHotlineNo
        '
        Me.txtHotlineNo.BackColor = System.Drawing.Color.White
        Me.txtHotlineNo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtHotlineNo.ForeColor = System.Drawing.Color.Black
        Me.txtHotlineNo.Location = New System.Drawing.Point(142, 251)
        Me.txtHotlineNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHotlineNo.Name = "txtHotlineNo"
        Me.txtHotlineNo.Size = New System.Drawing.Size(175, 22)
        Me.txtHotlineNo.TabIndex = 424
        '
        'frmEmailSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 342)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtHotlineNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmailCC)
        Me.Controls.Add(Me.ckEnableSSL)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtEmailHost)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ckEnableEmailNotification)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEmailAddress)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEmailSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ckEnableEmailNotification As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmailHost As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents ckEnableSSL As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmailCC As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHotlineNo As System.Windows.Forms.TextBox
End Class
