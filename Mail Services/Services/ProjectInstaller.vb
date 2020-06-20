Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.ServiceProcess


Public Class ProjectInstaller
    Shared Sub Main(ByVal cmdArgs() As String)
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New MailServices()}
        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
