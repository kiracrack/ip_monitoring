Module General_Settings
    'Declaration of email settings
    Public globalEmailNotification As Boolean
    Public GlobalCompanyName As String
    Public GlobalEngineCode As String
    Public globalsmtpHost As String
    Public globalsmtpPort As String
    Public globalsslEnable As Boolean
    Public globalserverEmailAddress As String
    Public globaltargetEmailAddress As String
    Public globalemailPassword As String
 
    Public Sub LoadGeneralSettings()
        com.CommandText = "select * from tblgeneralsettings"
        rst = com.ExecuteReader
        While rst.Read
            GlobalCompanyName = rst("companyname").ToString
            globalEmailNotification = rst("enableemailnotification")
            globalsmtpHost = rst("smtphost").ToString()
            globalsmtpPort = rst("smptport").ToString()
            globalsslEnable = rst("smtpsslenable")
            globalserverEmailAddress = rst("serveremailaddress").ToString()
            globalemailPassword = DecryptTripleDES(rst("serverpassword").ToString())
        End While
        rst.Close()

    End Sub

End Module
