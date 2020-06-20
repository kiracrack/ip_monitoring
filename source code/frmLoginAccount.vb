Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Net
Imports System.Reflection

Public Class frmLoginAccount

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmRequestType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler WebclientDownloader.DownloadProgressChanged, AddressOf client_ProgressChanged
        AddHandler WebclientDownloader.DownloadFileCompleted, AddressOf client_DownloadCompleted
        If System.IO.File.Exists(file_conn) = False Then
            frmConnectionSetup.ShowDialog()
            End
        End If
        ConnectVerify()
        If AvailableNewUpdate() = True Then
            Panel1.Visible = True
            lblDownload.Text = "Downloading.."
            Timer1.Enabled = True
        Else
            Panel1.Visible = False
            CreateNotExistingTable()
            LoadToComboBox("SELECT * FROM `tbltechnicalsupport` order by itname asc;", "itname", "itname", txtITName)
        End If

    End Sub

    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        If txtITName.Text = "" Then
            MessageBox.Show("Please select user!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtITName.Focus()
            Exit Sub

        ElseIf txtpassword.Text = "" Then
            MessageBox.Show("Please enter password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtpassword.Focus()
            Exit Sub
        End If

        Try
            If countqry("tbltechnicalsupport", "itname='" & rchar(txtITName.Text) & "' and password='" & rchar(txtpassword.Text) & "'") > 0 Then
                'MessageBox.Show("Your password currently not encripted! Please change your password after login!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If countqry("tbltechnicalsupport", "itname='" & rchar(txtITName.Text) & "' and password='" & EncryptTripleDES(LCase(txtITName.Text.Replace(" ", "")) & txtpassword.Text) & "'") = 0 Then
                    MessageBox.Show("Login not authorized!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtpassword.Focus()
                    Exit Sub
                End If
            End If
            loadAccounts(txtITName.Text)
            If GlobalPosition = "" Then
                MessageBox.Show("Please update your account for better reporting!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmAccountInformation.ShowDialog(Me)
            End If
            Me.Hide()
            frmMainMenu.Show()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message, vbCrLf _
                            & "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Public Function loadAccounts(ByVal fullname As String)
        com.CommandText = "select * from tbltechnicalsupport where itname ='" & txtITName.Text & "'" : rst = com.ExecuteReader
        While rst.Read
            GlobalFullname = rst("itname").ToString
            GlobalPosition = rst("position")
        End While
        rst.Close()
        Return 0
    End Function

    Private Sub txtSolveby_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtITName.SelectedValueChanged
        txtpassword.Focus()
    End Sub

#Region "AUTO UPDATE"

    Public Sub StartDownload()
        If Not System.IO.Directory.Exists(Application.StartupPath.ToString & "\UpdateVersion") = True Then
            System.IO.Directory.CreateDirectory(Application.StartupPath.ToString & "\UpdateVersion")
        End If
        Dim filename = ArchivedLocation & Me.txtUpdateUrl.Text.Split("/"c)(Me.txtUpdateUrl.Text.Split("/"c).Length - 1)
        txtDownloadLocation.Text = filename
        WebclientDownloader.DownloadFileAsync(New Uri(txtUpdateUrl.Text), txtDownloadLocation.Text)
    End Sub
    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        lblDownload.Text = "Downloading " & Int32.Parse(Math.Truncate(percentage).ToString()) & "%"
        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim ass As Assembly = Assembly.GetExecutingAssembly()
        Dim updateFileInfo As String = Application.StartupPath.ToString & "\UpdateVersion" & "\UpdateInfo.txt"
        If System.IO.File.Exists(updateFileInfo) = True Then
            System.IO.File.Delete(updateFileInfo)
        End If
        Dim detailsFile As StreamWriter = Nothing
        detailsFile = New StreamWriter(updateFileInfo, True)
        detailsFile.WriteLine(Path.GetFileName(ass.Location) & "|" & System.IO.Path.GetDirectoryName(ass.Location) & "|" & txtDownloadLocation.Text & "|" & txtversion.Text)
        detailsFile.Close()
        Process.Start(Application.StartupPath.ToString & "\SystemUpdater.exe")
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop() : Timer1.Enabled = False
        StartDownload()
    End Sub
#End Region

End Class