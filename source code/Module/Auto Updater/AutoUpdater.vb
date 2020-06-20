Imports System.IO
Imports System.Net

Module AutoUpdater
    Dim detailsFile As StreamWriter = Nothing
    Public WebclientDownloader As WebClient = New WebClient
    Public provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
    Public FileProperties As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
    Public fversion As String = FileProperties.FileVersion.ToString.Remove(FileProperties.FileVersion.ToString.Length - 2, 2)
    Public dversion As Date = Date.ParseExact(fversion, "yy.M.d", provider)
    Public ArchivedLocation As String = Application.StartupPath.ToString & "\UpdateVersion\"
    Public Function AvailableNewUpdate() As Boolean
        com.CommandText = "select *, date_format(str_to_date(version, '%Y.%m.%d'), '%Y-%m-%d') as dt from tblclientsystemupdate where date_format(str_to_date(version, '%Y.%m.%d'), '%Y-%m-%d') > '" & ConvertDate(dversion) & "' and server=1  order by date_format(str_to_date(version, '%Y.%m.%d'), '%Y-%m-%d') asc limit 1" : rst = com.ExecuteReader
        If rst.Read Then
            If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
                MessageBox.Show("There are another instance running, make sure all system are completely closed then try again.", "Update error occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End
            End If

            frmLoginAccount.NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            frmLoginAccount.NotifyIcon1.BalloonTipTitle = "New update available."
            frmLoginAccount.NotifyIcon1.BalloonTipText = "System now downloading update v" & rst("version").ToString & " and your transaction will disable temporarily.."
            frmLoginAccount.NotifyIcon1.ShowBalloonTip(1000)

            frmLoginAccount.txtUpdateUrl.Text = rst("downloadurl").ToString
            frmLoginAccount.txtversion.Text = rst("version").ToString
            AvailableNewUpdate = True
        Else
            AvailableNewUpdate = False
        End If
        rst.Close()
    End Function
    

#Region "GET OS NAME"
    Dim Full_Os_Name As String = My.Computer.Info.OSFullName
    Public Function Get_os_name() As String
        Get_os_name = ""
        If Full_Os_Name.Contains("Windows 7") Then
            Get_os_name = "Windows 7"
        ElseIf Full_Os_Name.Contains("Windows Vista") Then
            Get_os_name = "Windows Vista"
        ElseIf Full_Os_Name.Contains("Windows XP") Then
            Get_os_name = "Windows XP"
        Else
            Get_os_name = Full_Os_Name.ToString()
        End If
        Return Get_os_name
    End Function
#End Region

End Module
