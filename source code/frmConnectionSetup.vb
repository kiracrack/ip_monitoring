﻿Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO

Public Class frmConnectionSetup

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmRequestType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clientserver = ""
        clientport = ""
        clientuser = ""
        clientpass = ""
    End Sub
   
    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
          If txtServerhost.Text = "" Then
            MessageBox.Show("Please enter Server host!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtServerhost.Focus()
            Exit Sub
        ElseIf txtusername.Text = "" Then
            MessageBox.Show("Please enter username!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtusername.Focus()
            Exit Sub
        ElseIf txtpassword.Text = "" Then
            MessageBox.Show("Please enter password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtpassword.Focus()
            Exit Sub
        ElseIf txtDatabase.Text = "" Then
            MessageBox.Show("Please enter database name!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDatabase.Focus()
            Exit Sub
        End If
        clientserver = txtServerhost.Text
        clientport = txtPort.Text
        clientuser = txtusername.Text
        clientpass = txtpassword.Text
        clientdatabase = txtDatabase.Text

        OpenClientServer()
        If connclient.State <> 0 Then
            Try

                Dim detailsFile As StreamWriter = Nothing
                If System.IO.File.Exists(file_conn) = True Then
                    System.IO.File.Delete(file_conn)
                End If
                detailsFile = Nothing
                detailsFile = New StreamWriter(file_conn, True)
                detailsFile.WriteLine(EncryptTripleDES(txtServerhost.Text & "," & txtPort.Text & "," & txtusername.Text & "," & txtpassword.Text & "," & txtDatabase.Text))
                detailsFile.Close()
                MessageBox.Show("Connection Successfully Added", "PCBR3", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch errMYSQL As MySqlException
                MessageBox.Show("Message:" & errMYSQL.Message, vbCrLf _
                                & "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Catch errMS As Exception
                MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
 

    End Sub
End Class