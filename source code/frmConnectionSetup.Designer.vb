﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnectionSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnectionSetup))
        Me.cmdset = New System.Windows.Forms.Button()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtServerhost = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdset
        '
        Me.cmdset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdset.Location = New System.Drawing.Point(124, 117)
        Me.cmdset.Name = "cmdset"
        Me.cmdset.Size = New System.Drawing.Size(170, 30)
        Me.cmdset.TabIndex = 6
        Me.cmdset.Text = "Connect"
        Me.cmdset.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtPort.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtPort.ForeColor = System.Drawing.Color.Gray
        Me.txtPort.Location = New System.Drawing.Point(296, 18)
        Me.txtPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(63, 22)
        Me.txtPort.TabIndex = 2
        Me.txtPort.Text = "port"
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(61, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 366
        Me.Label4.Text = "Password"
        '
        'txtusername
        '
        Me.txtusername.BackColor = System.Drawing.SystemColors.Window
        Me.txtusername.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtusername.ForeColor = System.Drawing.Color.Gray
        Me.txtusername.Location = New System.Drawing.Point(124, 43)
        Me.txtusername.Margin = New System.Windows.Forms.Padding(4)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(235, 22)
        Me.txtusername.TabIndex = 3
        Me.txtusername.Text = "username"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(58, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 364
        Me.Label5.Text = "Username"
        '
        'txtServerhost
        '
        Me.txtServerhost.BackColor = System.Drawing.SystemColors.Window
        Me.txtServerhost.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtServerhost.ForeColor = System.Drawing.Color.Gray
        Me.txtServerhost.Location = New System.Drawing.Point(124, 18)
        Me.txtServerhost.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServerhost.Name = "txtServerhost"
        Me.txtServerhost.Size = New System.Drawing.Size(170, 22)
        Me.txtServerhost.TabIndex = 1
        Me.txtServerhost.Text = "localhost"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(51, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 368
        Me.Label7.Text = "Server Host"
        '
        'txtpassword
        '
        Me.txtpassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtpassword.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.txtpassword.ForeColor = System.Drawing.Color.Gray
        Me.txtpassword.Location = New System.Drawing.Point(124, 68)
        Me.txtpassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtpassword.Size = New System.Drawing.Size(235, 20)
        Me.txtpassword.TabIndex = 4
        Me.txtpassword.Text = "Password"
        '
        'txtDatabase
        '
        Me.txtDatabase.BackColor = System.Drawing.SystemColors.Window
        Me.txtDatabase.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtDatabase.ForeColor = System.Drawing.Color.Gray
        Me.txtDatabase.Location = New System.Drawing.Point(124, 91)
        Me.txtDatabase.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(170, 22)
        Me.txtDatabase.TabIndex = 5
        Me.txtDatabase.Text = "database"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(63, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 370
        Me.Label1.Text = "Database"
        '
        'frmConnectionSetup
        '
        Me.AcceptButton = Me.cmdset
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(417, 167)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtServerhost)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.cmdset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConnectionSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "General Settings"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdset As System.Windows.Forms.Button
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtusername As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtServerhost As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
