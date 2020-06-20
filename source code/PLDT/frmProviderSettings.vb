Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class frmProviderSettings

    Public Sub Filter()
        MyDataGridView.DataSource = Nothing : dst = New DataSet
        msda = New MySqlDataAdapter("select providercode, Provider, Description, Email from tblprovider order by Description asc", conn)

        msda.SelectCommand.CommandTimeout = 600000
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)
        MyDataGridView.Columns("providercode").Visible = False
        GridColumnAlignment(MyDataGridView, {"Provider"}, DataGridViewContentAlignment.MiddleCenter)
    End Sub
    Private Sub MyDataGridView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MyDataGridView.CellMouseDown
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Me.MyDataGridView.CurrentCell = Me.MyDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub

    Private Sub frmProviderSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Filter()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtConnectionName.Text = "" Then
            MsgBox("Please enter connection type!", MsgBoxStyle.Exclamation, "Error Message")
            txtConnectionName.Focus()
            Exit Sub
        ElseIf txtEmail.Text = "" Then
            MsgBox("Please enter Email!", MsgBoxStyle.Exclamation, "Error Message")
            txtEmail.Focus()
            Exit Sub

        End If
        If mode.Text = "edit" Then
            com.CommandText = "UPDATE tblprovider set providercode='" & id.Text & "', provider='" & txtProvider.Text & "', description='" & rchar(txtConnectionName.Text) & "',email='" & txtEmail.Text & "' where providercode='" & id.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "insert into tblprovider set provider='" & txtProvider.Text & "', description='" & rchar(txtConnectionName.Text) & "', email='" & txtEmail.Text & "'" : com.ExecuteNonQuery()
        End If
        Filter() : mode.Text = "" : txtConnectionName.Text = "" : txtEmail.Text = ""
        MsgBox("Connection successfully save!", MsgBoxStyle.Information)
    End Sub
    
    Private Sub EditIPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditIPToolStripMenuItem.Click
        mode.Text = ""
        id.Text = MyDataGridView.Item("providercode", MyDataGridView.CurrentRow.Index).Value().ToString
        txtProvider.Text = MyDataGridView.Item("Provider", MyDataGridView.CurrentRow.Index).Value().ToString
        txtConnectionName.Text = MyDataGridView.Item("Description", MyDataGridView.CurrentRow.Index).Value().ToString
        txtEmail.Text = MyDataGridView.Item("Email", MyDataGridView.CurrentRow.Index).Value().ToString
        mode.Text = "edit"
        txtConnectionName.Focus()
    End Sub

    Private Sub ReportToPLDTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToPLDTToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to continue? " & Environment.NewLine & Environment.NewLine, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
            com.CommandText = "DELETE FROM tblprovider where providercode='" & MyDataGridView.Item("providercode", MyDataGridView.CurrentRow.Index).Value().ToString & "'" : com.ExecuteNonQuery()
            Filter()
        End If
    End Sub

    Private Sub cmdExportToExcel_Click(sender As Object, e As EventArgs) Handles cmdExportToExcel.Click
        Filter()
    End Sub
End Class
