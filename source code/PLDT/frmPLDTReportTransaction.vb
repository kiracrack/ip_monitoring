Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Drawing.Printing

Public Class frmPLDTReportTransaction
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmPLDTOffices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtdatefrom.Text = Format(Now)
        txtdateto.Text = Format(Now)
        FilterClosed()
    End Sub
   
    Public Sub FilterClosed()
        MyDataGridView.DataSource = Nothing : dst = New DataSet
        msda = New MySqlDataAdapter("select id,officeid, provider, (select concat(officename,' ',officedescription) from tbldslconnection where id=tblincedentreport.officeid) as 'Office Name', date_format(downdate,'%Y-%m-%d') as 'Down Date',date_format(downtime,'%r') as 'Down Time', Issue,date_format(reporteddate,'%Y-%m-%d %r') as 'Date Reported', ReportBy as 'Reported By', incidentnumber as 'Incident Number',if(upconnection=1,'UP','DOWN') as 'Status',date_format(upconnectiondate,'%Y-%m-%d %r') as 'UP Connection Date',if(closed=1,'YES','NO') as 'Closed',closeby as 'Closed By',date_format(dateclosed,'%Y-%m-%d %r') as 'Date Closed' from tblincedentreport where closed=0 and date_format(reporteddate,'%Y-%m-%d') between '" & ConvertDate(txtdatefrom.Text) & "' and '" & ConvertDate(txtdateto.Text) & "' and ((select concat(officename,' ',officedescription) from tbldslconnection where id=tblincedentreport.officeid)  like '%" & txtServer.Text & "%' or  date_format(downdate,'%Y-%m-%d') like '%" & txtServer.Text & "%' or date_format(reporteddate,'%Y-%m-%d %r') like '%" & txtServer.Text & "%') order by reporteddate asc ", conn)
        msda.SelectCommand.CommandTimeout = 600000
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)

        MyDataGridView.Columns("id").Visible = False
        MyDataGridView.Columns("officeid").Visible = False
        MyDataGridView.Columns("provider").Visible = False
        GridColumnAlignment(MyDataGridView, {"Incendent Number", "Down Date", "Down Time", "Up Date", "Up Time", "Incident Number", "Status", "UP Connection Date", "Closed", "Closed By"}, DataGridViewContentAlignment.MiddleCenter)
    End Sub
    
   
    Private Sub txtServer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtServer.KeyPress
        If e.KeyChar() = Chr(13) Then
            FilterClosed()
        End If
    End Sub

    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        FilterClosed()
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        PrintDatagridview(Me.Text, "SERVICE REPORT", "Report Period from " & txtdatefrom.Text & " to " & txtdateto.Text, MyDataGridView, Me)
    End Sub
End Class