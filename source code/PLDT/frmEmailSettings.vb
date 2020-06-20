Imports System.Globalization

Public Class frmEmailSettings

    Private Sub frmEmailSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        com.CommandText = "select * from tblgeneralsettings" : rst = com.ExecuteReader
        While rst.Read
            ckEnableEmailNotification.Checked = rst("enableemailnotification")
            ckEnableSSL.Checked = rst("smtpsslenable")
            txtEmailHost.Text = rst("smtphost").ToString
            txtPort.Text = rst("smptport").ToString
            txtEmailAddress.Text = rst("serveremailaddress").ToString
            txtPassword.Text = DecryptTripleDES(rst("serverpassword").ToString)
            txtEmailCC.Text = rst("emailcc").ToString
            txtHotlineNo.Text = rst("hotlineno").ToString
        End While
        rst.Close()
    End Sub
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If countRecord("tblgeneralsettings") = 0 Then
            com.CommandText = "insert into tblgeneralsettings set enableemailnotification=" & ckEnableEmailNotification.CheckState & ", smtpsslenable=" & ckEnableSSL.CheckState & ",smtphost='" & rchar(txtEmailHost.Text) & "',  smptport='" & txtPort.Text & "',serveremailaddress='" & txtEmailAddress.Text & "', serverpassword='" & EncryptTripleDES(txtPassword.Text) & "',emailcc='" & txtEmailCC.Text & "',hotlineno='" & txtHotlineNo.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "UPDATE tblgeneralsettings set enableemailnotification=" & ckEnableEmailNotification.CheckState & ", smtpsslenable=" & ckEnableSSL.CheckState & ",smtphost='" & rchar(txtEmailHost.Text) & "',  smptport='" & txtPort.Text & "',serveremailaddress='" & txtEmailAddress.Text & "', serverpassword='" & EncryptTripleDES(txtPassword.Text) & "',emailcc='" & txtEmailCC.Text & "',hotlineno='" & txtHotlineNo.Text & "'" : com.ExecuteNonQuery()
        End If
        MsgBox("Successfully Saved", MsgBoxStyle.Information)
    End Sub
    
End Class
