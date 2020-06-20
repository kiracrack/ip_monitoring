Imports System.Net.Mail
Imports System.Text
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Net.NetworkInformation

Module MailModule
    Public n_EmailAddFrom As String
    Public n_EmailAddTo As String
    Public n_EmailCC As String
    Public n_EmailFromTitle As String
    Public n_Subject As String
    Public n_Message As String
    Public n_FileList() As String
    Public n_ExecuteCommand As String
    Private sc As New SmtpClient
    Public bw As BackgroundWorker = New BackgroundWorker
    Public Function customCertValidation(ByVal sender As Object, _
                                                ByVal cert As X509Certificate, _
                                                ByVal chain As X509Chain, _
                                                ByVal errors As SslPolicyErrors) As Boolean

        Return True
    End Function

    Public Function SendEmailNotification(ByVal EmailAddFrom As String, ByVal FromEmailTitle As String, ByVal EmailAddTo As String, ByVal EmailCC As String, ByVal strSubject As String, ByVal strMessage As String, ByVal fileList() As String, ByVal ExecuteCommand As String) As Boolean
        If Not bw.IsBusy Then
            bw.WorkerSupportsCancellation = True
            AddHandler bw.DoWork, AddressOf bw_DoWork
            AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
            AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

            n_EmailAddFrom = EmailAddFrom
            n_EmailFromTitle = FromEmailTitle
            n_EmailAddTo = EmailAddTo
            n_EmailCC = EmailCC
            n_Subject = strSubject
            n_Message = strMessage
            n_FileList = fileList
            n_ExecuteCommand = ExecuteCommand

            bw.RunWorkerAsync()
        End If
    End Function

    Public Function SendEmailMessage(ByVal EmailAddFrom As String, ByVal FromEmailTitle As String, ByVal EmailAddTo As String, ByVal EmailCC As String, ByVal strSubject As String, ByVal strMessage As String, ByVal fileList() As String, ByVal ExecuteCommand As String) As Boolean
        Dim MailMsg As New MailMessage
        Try
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            MailMsg.From = New MailAddress(EmailAddFrom, FromEmailTitle, System.Text.Encoding.UTF8)
            MailMsg.To.Clear()
            For Each word In EmailAddTo.Split(New Char() {","c})
                MailMsg.To.Add(New MailAddress(word))
            Next
            If EmailCC.Length > 0 Then
                For Each word In EmailCC.Split(New Char() {","c})
                    MailMsg.CC.Add(New MailAddress(word))
                Next
            End If
            MailMsg.Subject = strSubject.Trim()
            MailMsg.Body = strMessage.Trim()
            MailMsg.BodyEncoding = Encoding.Default
            MailMsg.IsBodyHtml = True

            'attach each file attachment
            If Not fileList Is Nothing Then
                For Each strfile As String In fileList
                    If Not strfile = "" Then
                        Dim MsgAttach As New Attachment(strfile)
                        MailMsg.Attachments.Add(MsgAttach)
                    End If
                Next
            End If

            'Smtpclient to send the mail message
            RecordLog("Signin to " & globalsmtpHost & " server, port " & globalsmtpPort & " with enable ssl " & globalsslEnable)
            sc = New SmtpClient(globalsmtpHost, globalsmtpPort)
            Dim netCred As New Net.NetworkCredential(globalserverEmailAddress, globalemailPassword)
            sc.EnableSsl = globalsslEnable
            sc.UseDefaultCredentials = True
            sc.Timeout = Int32.MaxValue
            sc.Credentials = netCred
            sc.Timeout = 6000000
            sc.Send(MailMsg)
            sc.Dispose()
            RecordLog(strSubject & " was successfully sent")

            If n_ExecuteCommand <> "" Then
                com.CommandText = n_ExecuteCommand : com.ExecuteNonQuery()
                bw.CancelAsync()
            End If
        Catch ex As Exception
            RecordLog(ex.Message)
            sc.Dispose()
            Return False
        End Try
        Return True
    End Function

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        If bw.CancellationPending = True Then
            e.Cancel = True
            Exit Sub
        End If
        SendEmailMessage(n_EmailAddFrom, n_EmailFromTitle, n_EmailAddTo, n_EmailCC, n_Subject, n_Message, Nothing, n_ExecuteCommand)
        System.Threading.Thread.Sleep(2000)
    End Sub
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        n_EmailAddFrom = "" : n_EmailFromTitle = "" : n_EmailAddTo = Nothing : n_Subject = "" : n_Message = "" : n_FileList = Nothing : n_ExecuteCommand = ""
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        ' Me.LinkLabel2.Text = e.ProgressPercentage.ToString() & "%"
    End Sub

    Public Function EmailAllPendingNotification()
        If Not bw.IsBusy Then
            Try
                e_dst = New DataSet
                e_msda = New MySqlDataAdapter("select * from tblemailnotification where notified=0", conn)
                e_msda.Fill(e_dst, 0)
                For cnt = 0 To e_dst.Tables(0).Rows.Count - 1
                    With (e_dst.Tables(0))
                        RecordLog("Sending " & .Rows(cnt)("subject").ToString() & " email notification to " & .Rows(cnt)("receiver").ToString())
                        SendEmailNotification(globalserverEmailAddress, GlobalCompanyName, .Rows(cnt)("receiver").ToString(), .Rows(cnt)("cc").ToString(), .Rows(cnt)("subject").ToString(), DecryptTripleDES(.Rows(cnt)("emailbody").ToString()), Nothing, "UPDATE tblemailnotification set notified=1,datenotified=current_timestamp where id='" & .Rows(cnt)("id").ToString() & "'")
                    End With
                Next
            Catch errMYSQL As MySqlException
                RecordLog("MySQL Error Message: " & errMYSQL.Message)
                CheckConnection()
            End Try
        End If
        Return True
    End Function

    Public Sub RecordLog(ByVal message As String)
        Dim fileName As String = CDate(Now).ToString("yyyy-MM-dd") & ".log"
        Dim path As String = Application.StartupPath.ToString & "\Log"
        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        If Not System.IO.File.Exists(fileName) Then
            System.IO.File.Create(fileName)
        End If

        Dim sw As StreamWriter = File.AppendText(path & "\" & fileName)
        sw.WriteLine(CDate(Now).ToString("yyyy-MM-dd hh:mm:ss tt") & Chr(9) & message)
        sw.Close()
    End Sub
    Public Function getMacAddress()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function
    Public Function ConvertDate(ByVal d As Date)
        Return d.ToString("yyyy-MM-dd")
    End Function
End Module
