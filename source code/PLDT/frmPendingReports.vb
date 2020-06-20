Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Drawing.Printing

Public Class frmPendingReports
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmPendingReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Filter()
    End Sub
    Public Sub Filter()
        MyDataGridView.DataSource = Nothing : dst = New DataSet
        msda = New MySqlDataAdapter("select id,officeid, provider,(select accountnumber from tbldslconnection where id=tblincedentreport.officeid) as 'Account No.', (select servicenumber from tbldslconnection where id=tblincedentreport.officeid) as 'Service No.', (select concat(officename,' ',officedescription) from tbldslconnection where id=tblincedentreport.officeid) as 'Office Name', date_format(downdate,'%Y-%m-%d') as 'Down Date',date_format(downtime,'%r') as 'Down Time', Issue,date_format(reporteddate,'%Y-%m-%d %r') as 'Date Reported', ReportBy as 'Reported By' from tblincedentreport where closed=0 and ((select concat(officename,' ',officedescription) from tbldslconnection where id=tblincedentreport.officeid)  like '%" & txtServer.Text & "%' or  date_format(downdate,'%Y-%m-%d') like '%" & txtServer.Text & "%' or date_format(reporteddate,'%Y-%m-%d %r') like '%" & txtServer.Text & "%') order by reporteddate asc", conn)
        msda.SelectCommand.CommandTimeout = 600000
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)
        MyDataGridView.Columns("id").Visible = False
        MyDataGridView.Columns("provider").Visible = False
        MyDataGridView.Columns("officeid").Visible = False
        GridColumnAlignment(MyDataGridView, {"Account No.", "Service No.", "Down Date", "Down Time", "Date Reported", "Issue"}, DataGridViewContentAlignment.MiddleCenter)
    End Sub

    Private Sub MyDataGridView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MyDataGridView.CellMouseDown
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Me.MyDataGridView.CurrentCell = Me.MyDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub

    Private Sub txtServer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtServer.KeyPress
        If e.KeyChar() = Chr(13) Then
            Filter()
        End If
    End Sub

    Private Sub ReportToPLDTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToPLDTToolStripMenuItem.Click
        frmCloseReport.id.Text = MyDataGridView.Item("id", MyDataGridView.CurrentRow.Index).Value().ToString
        frmCloseReport.officeid.Text = MyDataGridView.Item("officeid", MyDataGridView.CurrentRow.Index).Value().ToString
        frmCloseReport.providerid.Text = MyDataGridView.Item("provider", MyDataGridView.CurrentRow.Index).Value().ToString
        frmCloseReport.txtOfficeName.Text = MyDataGridView.Item("Office Name", MyDataGridView.CurrentRow.Index).Value().ToString
        frmCloseReport.Show(Me)
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        PrintDatagridview(Me.Text, "SERVICE PROVIDER", "", MyDataGridView, Me)
    End Sub
End Class