Module EmailNotifications
    Public Function FormattingEmailBody(ByVal value As String) As String
        value = value.Replace(vbCrLf, "<br/>")
        value = value.Replace(vbCr, "")
        value = value.Replace("Ñ", "&Ntilde;")
        value = value.Replace("ñ", "&ntilde;")
        value = value.Replace("  -  ", "&nbsp; &nbsp; - &nbsp; &nbsp;")
        Return value
    End Function
    Public Sub InsertEmailNotification(ByVal trntype As String, ByVal receiver As String, ByVal cc As String, ByVal subject As String, emailbody As String)
        If receiver.Length > 5 Then
            com.CommandText = "insert into tblemailnotification set trntype='" & trntype & "',receiver='" & receiver & "', cc='" & cc & "', subject='" & Trim(rchar(subject)) & "', emailbody='" & EncryptTripleDES(FormattingEmailBody(emailbody)) & "'" : com.ExecuteNonQuery()
        End If
    End Sub

    Public Sub ConnectionReportingEmail(ByVal id As String, ByVal status As String, ByVal message As String, ByVal reportdate As String)
        Dim details As String = "" : Dim subject As String = "" : Dim ProviderEmail As String = ""
        com.CommandText = "select *,(select provider from tblprovider where providercode = tbldslconnection.provider) as providername,(select email from tblprovider where providercode = tbldslconnection.provider) as provideremail from tbldslconnection where id='" & id & "'" : rst = com.ExecuteReader
        While rst.Read
            details = "Good day " & rst("providername").ToString & " Team,<br/><br/>" _
               + " PLEASE CREATE A TICKET FOR THE FOLLOWING DETAILS:<br/><br/>" _
               + " ACCOUNT NO: " & rst("accountnumber").ToString & " <br/>" _
               + " SERVICE NO/PL: " & rst("servicenumber").ToString & "<br/>" _
               + " SERVICE TYPE:  " & rst("service").ToString & " <br/>" _
               + " CURRENT STATUS: <br/> <font color='" & If(status = "DOWN", "red", "orange") & "'><b>CONNECTION " & status & "</b></font> <br/> <br/>" _
               + " OFFICE: " & rst("officename").ToString & " " & rst("officedescription").ToString & "  <br/>" _
               + " ADDRESS: " & rst("fulladdress").ToString & " <br/>" _
               + " CONTACT PERSON: " & rst("contactperson").ToString & "  <br/>" _
               + " CONTACT NO.: " & rst("contactnumber").ToString & "  <br/>" _
               + " NO WORKING PERMIT NEEDED<br/> " _
               + " <br/><br/>" _
               + If(message.Length > 0, message & "<br/><br/>", "") _
               + " Thank you. <br/><br/><br/>" _
               + " <b>" & GlobalFullname & "</b><br/>" _
               + " " & GlobalPosition & "<br/>" _
               + " IT HOTLINE: " & GlobalHotlineno & ""

            subject = reportdate & " | " & rst("officename").ToString & " " & rst("officedescription").ToString & " | " & rst("service").ToString & " | Account No: " & rst("accountnumber").ToString & ""
            ProviderEmail = rst("provideremail").ToString
        End While
        rst.Close()

        InsertEmailNotification("Reporting", ProviderEmail, GlobalEmailCC, subject, details)
    End Sub
    Public Sub CloseReportingEmail(ByVal id As String, ByVal Ticketno As String, ByVal message As String, ByVal reportdate As String)
        Dim details As String = "" : Dim subject As String = "" : Dim ProviderEmail As String = ""
        com.CommandText = "select *,(select provider from tblprovider where providercode = tbldslconnection.provider) as providername,(select email from tblprovider where providercode = tbldslconnection.provider) as provideremail from tbldslconnection where id='" & id & "'" : rst = com.ExecuteReader
        While rst.Read
            details = "Good day " & rst("providername").ToString & " Team,<br/><br/>" _
                + " We would like to inform you that the current connection status under ticket no. " & Ticketno & " was <br/> <font color='green'><b>Successfuly Restored.</b></font><br/><br/>" _
               + " <b>REFERENCE:</b><br/>" _
               + " OFFICE: " & rst("officename").ToString & " " & rst("officedescription").ToString & "  <br/>" _
               + " ACCOUNT NO: " & rst("accountnumber").ToString & " <br/>" _
               + " SERVICE NO/PL: " & rst("servicenumber").ToString & "<br/>" _
               + " SERVICE TYPE:  " & rst("service").ToString & " <br/><br/>" _
               + If(message.Length > 0, message & "<br/><br/>", "") _
               + " Thank you. <br/><br/><br/>" _
               + " <b>" & GlobalFullname & "</b><br/>" _
               + " " & GlobalPosition & "<br/>" _
               + " IT HOTLINE: " & GlobalHotlineno & ""
            subject = reportdate & " | " & rst("service").ToString & " | Ticket No: " & Ticketno & ""
            ProviderEmail = rst("provideremail").ToString
        End While
        rst.Close()

        InsertEmailNotification("Reporting", ProviderEmail, GlobalEmailCC, subject, details)
    End Sub
End Module
