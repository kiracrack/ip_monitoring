Imports System.IO

Module Printing
    Public Sub CreateHTMLReportTemplate(ByVal filename As String)
        Dim saveLocation As String = Application.StartupPath.ToString & "\Templates\" & filename
        If Not System.IO.Directory.Exists(Application.StartupPath.ToString & "\Templates\") = True Then
            System.IO.Directory.CreateDirectory(Application.StartupPath.ToString & "\Templates\")
        End If
        com.CommandText = "select * from tblreporthtmltemplate where filename='" & filename & "'" : rst = com.ExecuteReader
        While rst.Read
            If System.IO.File.Exists(SaveLocation) = True Then
                System.IO.File.Delete(SaveLocation)
            End If
            Dim detailsFile As StreamWriter = Nothing
            detailsFile = New StreamWriter(saveLocation, True)
            detailsFile.WriteLine(rst("htmltemplate").ToString)
            detailsFile.Close()
        End While
        rst.Close()
    End Sub
    Public Function RemoveSpecialCharacter(ByVal str As String)
        Dim removechar As Char() = "!@#$%^&*()_+-={}|[]\:;'<>?/".ToCharArray()
        Dim sb As New System.Text.StringBuilder
        For Each ch As Char In str
            If Array.IndexOf(removechar, ch) = -1 Then
                sb.Append(ch)
            End If
        Next
        Return sb.ToString
    End Function
    Public Function PrintSetupHeader()
        PrintSetupHeader += "<p align='center' ><strong>KATIPUNAN BANK INC.</strong></br>" _
                             + "Quezon Avenue corner Aguilar St., Miputak, Dipolog City<br/> " _
                             + "Tel. No. (065) 212-5019 / (065) 212-7647 <br/> "
        PrintSetupHeader += "<p align='center'><strong>IT Department</strong></br>"

        Return PrintSetupHeader
    End Function
    Public Sub PrintViaInternetExplorer(ByVal location As String, ByVal form As Windows.Forms.Form)
        Try
            'System.Diagnostics.Process.Start("iexplore.exe", location)
            System.Diagnostics.Process.Start(location)
            'form.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            MessageBox.Show("File not found!", _
                          "Error Reprint Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub PrintDatagridview(ByVal ReportTitle As String, ByVal TableTitle As String, ByVal ReportDescription As String, ByVal gv As DataGridView, ByVal form As Form)
        If gv.RowCount = 0 Then
            MessageBox.Show("No data report to print!", _
                       "Error Print", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        CreateHTMLReportTemplate("StandardReports.html")

        Dim Template As String = Application.StartupPath.ToString & "\Templates\StandardReports.html"
        Dim SaveLocation As String = Application.StartupPath.ToString & "\Transaction\REPORTS\" & RemoveSpecialCharacter(form.Text) & ".html"
        If System.IO.File.Exists(SaveLocation) = True Then
            System.IO.File.Delete(SaveLocation)
        End If
        My.Computer.FileSystem.CopyFile(Template, SaveLocation)
        If System.IO.File.Exists(Application.StartupPath.ToString & "\Logo\logo.png") = True Then
            My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[logo]", "<img style='float:left;  position: absolute;' src='" & Application.StartupPath.ToString & "\Logo\logo.png'>"), False)
        Else
            My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[logo]", ""), False)
        End If
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[report header]", PrintSetupHeader()), False)
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[title]", UCase(ReportTitle)), False)

        Dim ReportDetails As String = "<p align='left'> " & If(ReportDescription = "", "&nbsp;", ReportDescription) & " <span style='float:right'>Date Report: " & CDate(Now).ToString("MMMM dd, yyyy") & "</span></p>"
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[report details]", ReportDetails), False)
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[report table]", SetupTheGridviewPrinter(TableTitle, gv)), False)
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[prepared by]", UCase(globalfullname)), False)
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[prepared position]", UCase(globalposition)), False)
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[noted by]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"), False)
        My.Computer.FileSystem.WriteAllText(SaveLocation, My.Computer.FileSystem.ReadAllText(SaveLocation).Replace("[noted position]", "(Signature over printedname)"), False)
        ' Me.WindowState = FormWindowState.Minimized
        PrintViaInternetExplorer(SaveLocation.Replace("\", "/"), form)
    End Sub

    Public Function SetupTheGridviewPrinter(ByVal TableTitle As String, ByVal gv As DataGridView) As String
        On Error Resume Next
        Dim TableHeaderStart As String = "" : Dim TableHeaderEnd As String = "" : Dim ColumnName As String = "" : Dim rows As String = "" : Dim rowRowTableData As String = "" : Dim RowFooter As String = ""
        TableHeaderStart = "<table border='1' style='min-width:500px; margin:3px 0' cellpadding='4' cellspacing='0' style='border-collapse:collapse;'> " _
                                       + " <tr> " _
                                           + " <td colspan='" & gv.ColumnCount & "' align='center'><b>" & UCase(TableTitle) & "</b></td> " _
                                       + " </tr> " & Chr(13) _
                                       + " <tr> "
        For i = 0 To gv.ColumnCount - 1
            If gv.Columns(i).Visible = True Then
                ColumnName += "<th>" & gv.Columns(i).Name & "</th>"
            End If
        Next
        TableHeaderEnd = " </tr> "
        For i = 0 To gv.RowCount - 1
            rowRowTableData = "" : Dim rowColor As String = ""
            For x = 0 To gv.ColumnCount - 1
                If gv.Columns(x).Visible = True Then
                    Dim colalignment As String = "" : Dim strvalue As String = "" : Dim columnSize As String = ""
                    If gv.Columns(gv.Columns(x).Name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter Then
                        colalignment = "align='center'"

                        If gv.Item(gv.Columns(x).Name, i).Value() Is Nothing Then
                            strvalue = "&nbsp;"
                        Else
                            strvalue = gv.Item(gv.Columns(x).Name, i).Value().ToString
                        End If

                    ElseIf gv.Columns(gv.Columns(x).Name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                        colalignment = "align='right'"
                        If gv.Item(gv.Columns(x).Name, i).Value().ToString = "" Then
                            strvalue = "&nbsp;"
                        Else
                            strvalue = FormatNumber(gv.Item(gv.Columns(x).Name, i).Value().ToString, 2)
                        End If
                    Else
                        If gv.Item(gv.Columns(x).Name, i).Value() Is Nothing Then
                            strvalue = "&nbsp;"
                        Else
                            strvalue = gv.Item(gv.Columns(x).Name, i).Value().ToString
                        End If
                    End If
                    If gv.Columns(x).Width = 300 Then
                        columnSize = " width='" & gv.Columns(x).Width.ToString & "' "
                    End If

                    rowRowTableData += "<td " & colalignment & columnSize & ">" & strvalue.Replace("True", "YES").Replace("False", "-").Replace(Chr(13), "<br/>") & "</td> "
                End If
            Next
            If gv.Rows(i).DefaultCellStyle.ForeColor = Color.Red Then
                rowColor = "ff0000"
            ElseIf gv.Rows(i).DefaultCellStyle.ForeColor = Color.Blue Then
                rowColor = "001a7a"
            Else
                rowColor = "000000"
            End If
            rows += "<tr style='color:#" & rowColor & "'>" + rowRowTableData + "</tr>"
        Next
        SetupTheGridviewPrinter = TableHeaderStart + ColumnName + TableHeaderEnd + rows + "</table>"
        Return SetupTheGridviewPrinter
    End Function
End Module
