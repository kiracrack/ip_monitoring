<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginAccount
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginAccount))
        Me.cmdset = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtITName = New System.Windows.Forms.ComboBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.txtUpdateUrl = New System.Windows.Forms.TextBox()
        Me.txtversion = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblDownload = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtDownloadLocation = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdset
        '
        Me.cmdset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdset.Location = New System.Drawing.Point(210, 66)
        Me.cmdset.Name = "cmdset"
        Me.cmdset.Size = New System.Drawing.Size(109, 30)
        Me.cmdset.TabIndex = 5
        Me.cmdset.Text = "Login"
        Me.cmdset.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(41, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 366
        Me.Label4.Text = "Password"
        '
        'txtpassword
        '
        Me.txtpassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtpassword.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtpassword.ForeColor = System.Drawing.Color.Gray
        Me.txtpassword.Location = New System.Drawing.Point(104, 42)
        Me.txtpassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtpassword.Size = New System.Drawing.Size(215, 20)
        Me.txtpassword.TabIndex = 1
        Me.txtpassword.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(20, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "User Account"
        '
        'txtITName
        '
        Me.txtITName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtITName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtITName.FormattingEnabled = True
        Me.txtITName.Location = New System.Drawing.Point(104, 17)
        Me.txtITName.Name = "txtITName"
        Me.txtITName.Size = New System.Drawing.Size(215, 23)
        Me.txtITName.TabIndex = 0
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Coffeecup System"
        Me.NotifyIcon1.Visible = True
        '
        'txtUpdateUrl
        '
        Me.txtUpdateUrl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUpdateUrl.ForeColor = System.Drawing.Color.Black
        Me.txtUpdateUrl.Location = New System.Drawing.Point(23, 138)
        Me.txtUpdateUrl.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUpdateUrl.Name = "txtUpdateUrl"
        Me.txtUpdateUrl.ReadOnly = True
        Me.txtUpdateUrl.Size = New System.Drawing.Size(304, 23)
        Me.txtUpdateUrl.TabIndex = 369
        '
        'txtversion
        '
        Me.txtversion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtversion.ForeColor = System.Drawing.Color.Black
        Me.txtversion.Location = New System.Drawing.Point(23, 160)
        Me.txtversion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtversion.Name = "txtversion"
        Me.txtversion.ReadOnly = True
        Me.txtversion.Size = New System.Drawing.Size(304, 23)
        Me.txtversion.TabIndex = 370
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.lblDownload)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(347, 116)
        Me.Panel1.TabIndex = 371
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ProgressBar1.Location = New System.Drawing.Point(88, 38)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(169, 10)
        Me.ProgressBar1.TabIndex = 361
        '
        'lblDownload
        '
        Me.lblDownload.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDownload.BackColor = System.Drawing.Color.Transparent
        Me.lblDownload.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.lblDownload.ForeColor = System.Drawing.Color.Black
        Me.lblDownload.Location = New System.Drawing.Point(22, 51)
        Me.lblDownload.Name = "lblDownload"
        Me.lblDownload.Size = New System.Drawing.Size(301, 12)
        Me.lblDownload.TabIndex = 360
        Me.lblDownload.Text = "Downloading Update"
        Me.lblDownload.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'txtDownloadLocation
        '
        Me.txtDownloadLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDownloadLocation.ForeColor = System.Drawing.Color.Black
        Me.txtDownloadLocation.Location = New System.Drawing.Point(23, 184)
        Me.txtDownloadLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDownloadLocation.Name = "txtDownloadLocation"
        Me.txtDownloadLocation.ReadOnly = True
        Me.txtDownloadLocation.Size = New System.Drawing.Size(304, 23)
        Me.txtDownloadLocation.TabIndex = 372
        '
        'frmLoginAccount
        '
        Me.AcceptButton = Me.cmdset
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(352, 122)
        Me.Controls.Add(Me.txtDownloadLocation)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtversion)
        Me.Controls.Add(Me.txtUpdateUrl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtITName)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLoginAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login Admin Control"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdset As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtITName As System.Windows.Forms.ComboBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents txtUpdateUrl As System.Windows.Forms.TextBox
    Friend WithEvents txtversion As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDownload As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtDownloadLocation As System.Windows.Forms.TextBox
End Class
