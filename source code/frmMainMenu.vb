Imports System.Security.AccessControl
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmMainMenu
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.F12 Then

        End If
        Return ProcessCmdKey
    End Function

    Private Sub frmMainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        conn.Close()
        connclient.Close()
        End
    End Sub

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadMenu()
    End Sub

    Private Sub ListView3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView3.DoubleClick
        MenuActionPLDT()
    End Sub
   
    Public Sub loadMenu()
        With ListView3
            .LargeImageList = Imagemenu
            .Items.Add("Service Connections", 3)
            .Items.Add("Downtime Report", 1)
            .Items.Add("Provider Settings", 0)
            .Items.Add("Email Notification", 4)
            .Items.Add("Email Settings", 2)
            .Items.Add("Account Info", 5)
            .Items.Add("Service Report", 6)
        End With
    End Sub

    Public Sub MenuActionPLDT()
        Select Case ListView3.SelectedItems(0).Text
            Case "Service Connections"
                frmDSLConnections.Show(Me)

            Case "Downtime Report"
                frmPendingReports.Show(Me)

            Case "Provider Settings"
                frmProviderSettings.Show(Me)

            Case "Email Settings"
                frmEmailSettings.Show(Me)

            Case "Email Notification"
                frmEmailNotification.Show(Me)

            Case "Account Info"
                frmAccountInformation.Show(Me)

            Case "Service Report"
                frmPLDTReportTransaction.Show(Me)

        End Select
    End Sub
     
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblServer.Text = "Connected Server: " & sqlipaddress
        lblUser.Text = "IT Support: " & GlobalFullname & " - " & Format(Now)
    End Sub

End Class
