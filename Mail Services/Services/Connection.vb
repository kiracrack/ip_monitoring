Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Data
Imports System.Management
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Text
Imports System.IO
Imports Microsoft.Win32
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Windows.Forms

Module Connection
    Public conn As New MySqlConnection 'for MySQLDatabase Connection
    Public msda As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dst As New DataSet 'miniature of your table - cache table to client
    Public e_msda As MySqlDataAdapter 'is use to update the dataset and datasource
    Public e_dst As New DataSet 'miniature of your table - cache table to client
    Public com As New MySqlCommand
    Public rst As MySqlDataReader
    Public cb As MySqlCommandBuilder

    ' LOCALHOST
    Public sqlserver As String
    Public sqlport As String
    Public sqluser As String
    Public sqlpass As String
    Public sqldatabase As String
    Public sqljoinbase As String
    Public conString As String
    Public file_conn As String = Application.StartupPath.ToString & "\Mail.conn"
    Public ConnectedServer As Boolean = False
     
    Public Function ConnectServer() As Boolean
        Try
            Dim strSetup As String = ""
            Dim sr As StreamReader = File.OpenText(file_conn)
            Dim br As String = sr.ReadLine() : sr.Close()
            strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
            For Each word In strSetup.Split(New Char() {","c})
                If cnt = 0 Then
                    sqlserver = word
                ElseIf cnt = 1 Then
                    sqlport = word
                ElseIf cnt = 2 Then
                    sqluser = word
                ElseIf cnt = 3 Then
                    sqlpass = word
                ElseIf cnt = 4 Then
                    sqldatabase = word
                End If
                cnt = cnt + 1
            Next

            conn = New MySql.Data.MySqlClient.MySqlConnection
            conn.ConnectionString = "server=" & sqlserver & "; Port=" & sqlport & "; user id=" & sqluser & " ; password=" & sqlpass & " ; database=" & sqldatabase & "; Connection Timeout=6000000"
            conn.Open()
            com.Connection = conn
            com.CommandTimeout = 6000000

            RecordLog("MySQL server " & sqlserver & " successfully Connected")
            LoadGeneralSettings()
        Catch errMYSQL As MySqlException
            RecordLog(errMYSQL.Message)
            CheckConnection()
        Catch errMS As Exception
            RecordLog(errMS.Message)
            CheckConnection()
        End Try
        'Catch errMYSQL As MySqlException
        '    RecordLog(errMYSQL.Message.ToArray)
        '    CheckConnection()
        'End Try
        Return True
    End Function
    Public Sub CheckConnection()
        If ConnectServer() = True Then
            Dim ServicesToRun() As System.ServiceProcess.ServiceBase
            ServicesToRun = New System.ServiceProcess.ServiceBase() {New MailServices()}
            System.ServiceProcess.ServiceBase.Run(ServicesToRun)
        Else
            CheckConnection()
        End If
    End Sub
End Module
