<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCloseReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCloseReport))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.providerid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOfficeName = New System.Windows.Forms.TextBox()
        Me.officeid = New System.Windows.Forms.TextBox()
        Me.txtTicketNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(142, 123)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 33)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Done"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'providerid
        '
        Me.providerid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.providerid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.providerid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.providerid.ForeColor = System.Drawing.Color.Black
        Me.providerid.Location = New System.Drawing.Point(3, 189)
        Me.providerid.Margin = New System.Windows.Forms.Padding(4)
        Me.providerid.Name = "providerid"
        Me.providerid.ReadOnly = True
        Me.providerid.Size = New System.Drawing.Size(56, 22)
        Me.providerid.TabIndex = 395
        Me.providerid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.providerid.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(59, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 398
        Me.Label1.Text = "Office Name"
        '
        'txtOfficeName
        '
        Me.txtOfficeName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOfficeName.ForeColor = System.Drawing.Color.Black
        Me.txtOfficeName.Location = New System.Drawing.Point(142, 17)
        Me.txtOfficeName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOfficeName.Name = "txtOfficeName"
        Me.txtOfficeName.ReadOnly = True
        Me.txtOfficeName.Size = New System.Drawing.Size(271, 23)
        Me.txtOfficeName.TabIndex = 100
        '
        'officeid
        '
        Me.officeid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.officeid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.officeid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.officeid.ForeColor = System.Drawing.Color.Black
        Me.officeid.Location = New System.Drawing.Point(62, 189)
        Me.officeid.Margin = New System.Windows.Forms.Padding(4)
        Me.officeid.Name = "officeid"
        Me.officeid.ReadOnly = True
        Me.officeid.Size = New System.Drawing.Size(56, 22)
        Me.officeid.TabIndex = 412
        Me.officeid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.officeid.Visible = False
        '
        'txtTicketNo
        '
        Me.txtTicketNo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTicketNo.ForeColor = System.Drawing.Color.Black
        Me.txtTicketNo.Location = New System.Drawing.Point(142, 43)
        Me.txtTicketNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTicketNo.Name = "txtTicketNo"
        Me.txtTicketNo.Size = New System.Drawing.Size(140, 23)
        Me.txtTicketNo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(50, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 426
        Me.Label4.Text = "Ticket Number"
        '
        'id
        '
        Me.id.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.id.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.id.ForeColor = System.Drawing.Color.Black
        Me.id.Location = New System.Drawing.Point(3, 189)
        Me.id.Margin = New System.Windows.Forms.Padding(4)
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Size = New System.Drawing.Size(56, 22)
        Me.id.TabIndex = 427
        Me.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.id.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(80, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 429
        Me.Label3.Text = "Message"
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMessage.ForeColor = System.Drawing.Color.Black
        Me.txtMessage.Location = New System.Drawing.Point(142, 69)
        Me.txtMessage.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(271, 51)
        Me.txtMessage.TabIndex = 428
        '
        'frmCloseReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 169)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTicketNo)
        Me.Controls.Add(Me.officeid)
        Me.Controls.Add(Me.txtOfficeName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.providerid)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCloseReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Close Incendent Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents providerid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOfficeName As System.Windows.Forms.TextBox
    Friend WithEvents officeid As System.Windows.Forms.TextBox
    Friend WithEvents txtTicketNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox

End Class
