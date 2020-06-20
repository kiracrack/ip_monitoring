Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Drawing.Printing

Public Class frmDSLConnections
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmPLDTOffices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FilterOffice()
    End Sub

    Public Sub FilterOffice()
        MyDataGridView.DataSource = Nothing : dst = New DataSet
        msda = New MySqlDataAdapter("select id,provider,(select description from tblprovider where providercode=tbldslconnection.provider) as 'Provider', " _
                                    + " officename as 'Office Name', " _
                                    + " officedescription as 'Office Description', " _
                                    + " officetype as 'Office Type', " _
                                    + " fulladdress as 'Address', " _
                                    + " service as 'Service Type', " _
                                    + " servicenumber as 'Service Number', " _
                                    + " accountnumber as 'Account Number', " _
                                    + " ipaddress as 'IP Address', " _
                                    + " contactperson as 'Contact Person', " _
                                    + " contactnumber as 'Contact Number', " _
                                    + " Bandwidth, MRC, Vat, Total, " _
                                    + " dateinstalled as 'Date installed', " _
                                    + " terminationdate as 'Termination Date', " _
                                    + " Term from tbldslconnection where " _
                                    + " officename like '%" & rchar(txtServer.Text) & "%' or fulladdress like '%" & rchar(txtServer.Text) & "%' or contactnumber like '%" & rchar(txtServer.Text) & "%' or contactperson like '%" & rchar(txtServer.Text) & "%'  or accountnumber like '%" & rchar(txtServer.Text) & "%' or servicenumber like '%" & rchar(txtServer.Text) & "%' order by officename", conn)

        msda.SelectCommand.CommandTimeout = 600000
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)
        'MyDataGridView.Columns("Details").Width = 300
        MyDataGridView.Columns("id").Visible = False
        MyDataGridView.Columns("provider").Visible = False
        GridColumnAlignment(MyDataGridView, {"Provider", "Office Type", "Service Type", "IP Address", "Contact Person", "Contact Number", "Account Number", "Service Number", "IP Address", "Term", "Bandwidth"}, DataGridViewContentAlignment.MiddleCenter)
        GridCurrencyColumn(MyDataGridView, {"MRC", "Vat", "Total"})
    End Sub


    Private Sub cmdExportToExcel_Click(sender As Object, e As EventArgs) Handles cmdExportToExcel.Click
        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                dst.WriteXml(f.SelectedPath & "\" & Me.Text & ".xls")
                MessageBox.Show("Export done successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    
    Private Sub MyDataGridView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MyDataGridView.CellMouseDown
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Me.MyDataGridView.CurrentCell = Me.MyDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub

    Private Sub cmdPending_Click(sender As Object, e As EventArgs) Handles cmdPending.Click
        frmDSLConnectionsInfo.Show(Me)
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs)
        cmdPending.PerformClick()
    End Sub

    Private Sub EditIPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditIPToolStripMenuItem.Click
        frmDSLConnectionsInfo.id.Text = MyDataGridView.Item("id", MyDataGridView.CurrentRow.Index).Value().ToString
        frmDSLConnectionsInfo.mode.Text = "edit"
        If frmDSLConnectionsInfo.Visible = True Then
            frmDSLConnectionsInfo.Focus()
        Else
            frmDSLConnectionsInfo.Show(Me)
        End If
    End Sub

    Private Sub ReportToPLDTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToPLDTToolStripMenuItem.Click
        If MyDataGridView.Item("Office Name", MyDataGridView.CurrentRow.Index).Value().ToString = "" Then
            MsgBox("Please update office name first to continue!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        ElseIf MyDataGridView.Item("Address", MyDataGridView.CurrentRow.Index).Value().ToString = "" Then
            MsgBox("Please update office address first to continue!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        ElseIf MyDataGridView.Item("Service Number", MyDataGridView.CurrentRow.Index).Value().ToString = "" Then
            MsgBox("Please update Service Number first to continue!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        ElseIf MyDataGridView.Item("Account Number", MyDataGridView.CurrentRow.Index).Value().ToString = "" Then
            MsgBox("Please update Account Number first to continue!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        ElseIf MyDataGridView.Item("Contact Person", MyDataGridView.CurrentRow.Index).Value().ToString = "" Then
            MsgBox("Please update Contact Person first to continue!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        ElseIf MyDataGridView.Item("Contact Number", MyDataGridView.CurrentRow.Index).Value().ToString = "" Then
            MsgBox("Please update Contact Number first to continue!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        ElseIf MyDataGridView.Item("Service Type", MyDataGridView.CurrentRow.Index).Value().ToString = "" Then
            MsgBox("Please update Service Type first to continue!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        End If
        frmReportConnection.officeid.Text = MyDataGridView.Item("id", MyDataGridView.CurrentRow.Index).Value().ToString
        frmReportConnection.providerid.Text = MyDataGridView.Item("provider", MyDataGridView.CurrentRow.Index).Value().ToString
        frmReportConnection.txtOfficeName.Text = MyDataGridView.Item("Office Name", MyDataGridView.CurrentRow.Index).Value().ToString & " " & MyDataGridView.Item("Office Description", MyDataGridView.CurrentRow.Index).Value().ToString
        frmReportConnection.Show(Me)
    End Sub

    Private Sub txtServer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtServer.KeyPress
        If e.KeyChar() = Chr(13) Then
            FilterOffice()
        End If
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        PrintDatagridview(Me.Text, "SERVICE PROVIDER", "", MyDataGridView, Me)
    End Sub

    Private Sub ToolStripSeparator2_Click(sender As Object, e As EventArgs) Handles ToolStripSeparator2.Click

    End Sub
End Class