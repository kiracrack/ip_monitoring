Imports System.Globalization

Public Class frmReportConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtOfficeName.Text = "" Then
            MsgBox("Please enter office name!", MsgBoxStyle.Exclamation, "Error Message")
            txtOfficeName.Focus()
            Exit Sub
        ElseIf txtStatus.Text = "" Then
            MsgBox("Please enter report status!", MsgBoxStyle.Exclamation, "Error Message")
            txtStatus.Focus()
            Exit Sub

        End If
        ConnectionReportingEmail(officeid.Text, txtStatus.Text, txtMessage.Text, ConvertDate(GetServerdate()))
        com.CommandText = "update tbldslconnection set connectiondown=1 where id='" & officeid.Text & "'" : com.ExecuteNonQuery()
        com.CommandText = "insert into tblincedentreport set officeid='" & officeid.Text & "', provider='" & providerid.Text & "', downdate=current_date, downtime=current_time,issue='" & rchar(txtStatus.Text) & "', incidentnumber='', reporteddate=current_timestamp, reportby='" & GlobalFullname & "'" : com.ExecuteNonQuery()

        MsgBox("Office Successfully reported!", MsgBoxStyle.Information)
        Me.Close()
    End Sub
    Public Sub ClearFields()
        txtOfficeName.Text = ""
        txtOfficeName.Text = ""
        providerid.Text = ""
        officeid.Text = ""
    End Sub
End Class
