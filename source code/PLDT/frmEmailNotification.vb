Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Drawing.Printing

Public Class frmEmailNotification
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmEmailNotification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Filter()
    End Sub
    Public Sub Filter()
        MyDataGridView.DataSource = Nothing : dst = New DataSet
        msda = New MySqlDataAdapter("select REPLACE(receiver,',','\n') as 'Receiver', Subject, if(notified=1,'Sent','Sending') as 'Status', datenotified as 'Date Sent' from tblemailnotification where Subject like '%" & rchar(txtServer.Text) & "%'  order by datenotified desc", conn)
        msda.SelectCommand.CommandTimeout = 600000
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)
        MyDataGridView.Columns("Receiver").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        MyDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        GridColumnAlignment(MyDataGridView, {"Status"}, DataGridViewContentAlignment.MiddleCenter)
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
End Class