Imports System.Windows.Forms
Imports System.IO
Imports System.ServiceProcess


Public Class MailServices
    Public timer As System.Timers.Timer = New System.Timers.Timer()
    Protected Overrides Sub OnStart(ByVal args() As String)
        If ConnectServer() = True Then
            timer.Interval = 30000 ' 1 second
            AddHandler timer.Elapsed, AddressOf Me.OnTimer
            timer.Enabled = True
            timer.Start()
            RecordLog("Mail service started")
        Else
            CheckConnection()
        End If
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        RecordLog("Mail service Stop")
    End Sub
    Private Sub OnTimer(sender As Object, e As Timers.ElapsedEventArgs)
        Try
            If globalEmailNotification = True Then
                EmailAllPendingNotification()
            End If
        Catch ex As Exception
            RecordLog("Error" + ex.Message)
            CheckConnection()
        Finally
            timer.Start()
        End Try
    End Sub
    Protected Overrides Sub OnContinue()
        Application.Restart()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

End Class
