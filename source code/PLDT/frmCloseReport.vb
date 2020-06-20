Imports System.Globalization

Public Class frmCloseReport
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtTicketNo.Text = "" Then
            MsgBox("Please enter ticket no!", MsgBoxStyle.Exclamation, "Error Message")
            txtTicketNo.Focus()
            Exit Sub
        ElseIf txtTicketNo.Text.Length < 3 Then
            MsgBox("Please enter valid ticket no. check provider email and copy ticket number. ayaw pag tinapulan!", MsgBoxStyle.Exclamation, "Error Message")
            txtTicketNo.Focus()
            Exit Sub
        End If
        CloseReportingEmail(officeid.Text, txtTicketNo.Text, txtMessage.Text, ConvertDate(GetServerdate()))
        com.CommandText = "update tbldslconnection set connectiondown=0 where id='" & officeid.Text & "'" : com.ExecuteNonQuery()
        com.CommandText = "UPDATE tblincedentreport set incidentnumber='" & txtTicketNo.Text & "', upconnection=1,  upconnectiondate=current_timestamp, closed=1, dateclosed=current_timestamp, closeby='" & GlobalFullname & "' where id='" & id.Text & "'" : com.ExecuteNonQuery()
        frmPendingReports.Filter()
        MsgBox("Office Successfully Closed!", MsgBoxStyle.Information)
        Me.Close()
    End Sub
    Public Sub ClearFields()
        txtOfficeName.Text = ""
        txtOfficeName.Text = ""
        providerid.Text = ""
        officeid.Text = ""
    End Sub
End Class
