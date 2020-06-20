<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.Imagemenu = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Imagemenu
        '
        Me.Imagemenu.ImageStream = CType(resources.GetObject("Imagemenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagemenu.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagemenu.Images.SetKeyName(0, "image-loading-4.png")
        Me.Imagemenu.Images.SetKeyName(1, "network-offline.png")
        Me.Imagemenu.Images.SetKeyName(2, "system-run-3.png")
        Me.Imagemenu.Images.SetKeyName(3, "network-workgroup.png")
        Me.Imagemenu.Images.SetKeyName(4, "mail-queue-2.png")
        Me.Imagemenu.Images.SetKeyName(5, "user3.png")
        Me.Imagemenu.Images.SetKeyName(6, "Printer.png")
        '
        'ListView3
        '
        Me.ListView3.AllowDrop = True
        Me.ListView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ListView3.GridLines = True
        Me.ListView3.Location = New System.Drawing.Point(0, 3)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(751, 372)
        Me.ListView3.TabIndex = 348
        Me.ListView3.UseCompatibleStateImageBehavior = False
        '
        'lblServer
        '
        Me.lblServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblServer.AutoSize = True
        Me.lblServer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblServer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblServer.Location = New System.Drawing.Point(3, 379)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(0, 15)
        Me.lblServer.TabIndex = 408
        Me.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblUser.Location = New System.Drawing.Point(421, 379)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(326, 15)
        Me.lblUser.TabIndex = 409
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 10000
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        Me.Timer3.Interval = 10000
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 399)
        Me.Controls.Add(Me.ListView3)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblServer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(767, 438)
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection Service Provider Management"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Imagemenu As System.Windows.Forms.ImageList
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Public WithEvents Timer3 As System.Windows.Forms.Timer

End Class
