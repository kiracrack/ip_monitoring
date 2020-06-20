Imports System.Globalization

Public Class frmAccountInformation
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()

        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmAccountInformation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtPosition.Text = "" Then
            MsgBox("Please update your position ", vbExclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAccountInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFullname.Text = GlobalFullname
        txtPosition.Text = GlobalPosition
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtPosition.Text = "" Then
            MsgBox("Please enter position ", vbExclamation)
            txtPosition.Focus()
            Exit Sub
        ElseIf txtpassword.Text = "" Or txtpassword.Text = "Password" Then
            MsgBox("Please enter password ", vbExclamation)
            txtpassword.Focus()
            Exit Sub

        ElseIf txtpassword.Text.Contains(" ") = True Then
            MsgBox("Please enter password without space character", vbExclamation)
            txtpassword.Focus()
            Exit Sub

        ElseIf txtpassword.Text.Length < 1 Then
            MsgBox("Please enter password atleast 1 character lenght", vbExclamation)
            txtpassword.Focus()
            Exit Sub

        ElseIf txtpassword.Text <> txtverify.Text Then
            MsgBox("Password did not match", vbExclamation)
            txtpassword.Focus()
            Exit Sub
        End If
        If MessageBox.Show("Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            com.CommandText = "UPDATE tbltechnicalsupport set position='" & rchar(txtPosition.Text) & "', password='" & EncryptTripleDES(LCase(txtFullname.Text.Replace(" ", "")) & txtpassword.Text) & "' where itname='" & GlobalFullname & "';" : com.ExecuteNonQuery()

            txtpassword.Text = "Password" : txtverify.Text = "Password" : txtpassword.Focus()
            MsgBox("Password successfully changed!", MsgBoxStyle.Information)
        End If

    End Sub
End Class
