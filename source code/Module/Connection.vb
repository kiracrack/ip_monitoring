Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography

Module Connection

    Public conn As New MySqlConnection 'for MySQLDatabase Connection
    Public msda As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dst As New DataSet 'miniature of your table - cache table to client
    Public msda2 As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dst2 As New DataSet 'miniature of your table - cache table to client
    Public com As New MySqlCommand
    Public rst As MySqlDataReader
    Public GlobalFullname As String
    Public GlobalPosition As String

    Public GlobalCompanyName As String
    Public GlobalEmailCC As String
    Public GlobalHotlineno As String

    Public sqlservername As String
    Public sqlipaddress As String
    Public sqlPort As String
    Public sqlusername As String
    Public sqlpassword As String
    Public sqldatabase As String

    Public file_conn As String = Application.StartupPath.ToString & "\" & My.Application.Info.AssemblyName & ".conn"

    Public connclient As New MySqlConnection 'for MySQLDatabase Connection
    Public msdaclient As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dstclient As New DataSet 'miniature of your table - cache table to client
    Public comclient As New MySqlCommand
    Public rstclient As MySqlDataReader

    Public conngenapp As New MySqlConnection 'for MySQLDatabase Connection
    Public msdagenapp As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dstgenapp As New DataSet 'miniature of your table - cache table to client
    Public comgenapp As New MySqlCommand
    Public rstgenapp As MySqlDataReader

    Public clientserver As String
    Public clientport As String
    Public clientuser As String
    Public clientpass As String
    Public clientdatabase As String
 

    Public removechar As Char() = "\".ToCharArray()
    Public sb As New System.Text.StringBuilder
    Public imgBytes As Byte() = Nothing
    Public stream As MemoryStream = Nothing
    Public img As Image = Nothing
    Public sqlcmd As New MySqlCommand
    Public sql As String
    Public arrImage() As Byte = Nothing
    Public proFileImg As Boolean

    Public Function ConnectVerify() As Boolean
        If IO.File.Exists(file_conn) = False Then
            frmConnectionSetup.ShowDialog()
            End
        End If
        Try
            Dim strSetup As String = ""
            Dim sr As StreamReader = File.OpenText(file_conn)
            Dim br As String = sr.ReadLine() : sr.Close()
            strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
            For Each word In strSetup.Split(New Char() {","c})
                If cnt = 0 Then
                    sqlipaddress = word
                ElseIf cnt = 1 Then
                    sqlPort = word
                ElseIf cnt = 2 Then
                    sqlusername = word
                ElseIf cnt = 3 Then
                    sqlpassword = word
                ElseIf cnt = 4 Then
                    sqldatabase = word
                End If
                cnt = cnt + 1
            Next

            conn = New MySql.Data.MySqlClient.MySqlConnection
            conn.ConnectionString = "server=" & sqlipaddress & "; Port=" & sqlPort & "; user id=" & sqlusername & "; password=" & sqlpassword & "; database=" & sqldatabase & "; Connection Timeout=6000000"
            conn.Open()
            com.Connection = conn
            com.CommandTimeout = 6000000
            CreateNotExistingTable()
            LoadCompanyInfo()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ConnectVerify = False
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ConnectVerify = False
            Return False
        End Try

        Return True
    End Function

    Public Sub LoadCompanyInfo()
        com.CommandText = "select * from tblgeneralsettings" : rst = com.ExecuteReader
        While rst.Read
            GlobalCompanyName = rst("companyname").ToString
            GlobalEmailCC = rst("emailcc").ToString
            GlobalHotlineno = rst("hotlineno").ToString
        End While
        rst.Close()
    End Sub
    Public Function OpenClientServer() As Boolean
        Try
            If connclient.State = ConnectionState.Open Then
                connclient.Close()
                comclient.Connection.Close()
            End If
            connclient = New MySql.Data.MySqlClient.MySqlConnection
            connclient.ConnectionString = "server=" & clientserver & "; Port=" & clientport & "; user id=" & clientuser & "; password=" & clientpass & "; database=" & clientdatabase & "; Connection Timeout=6000000"
            connclient.Open()
            comclient.Connection = connclient
            comclient.CommandTimeout = 0
            OpenClientServer = True

        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        End Try
    End Function

    Public Function OpenCentralServer(ByVal connection_file As String) As Boolean
        Try
            Dim strSetup As String = ""
            Dim sr As StreamReader = File.OpenText(connection_file)
            Dim br As String = sr.ReadLine() : sr.Close()
            strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
            For Each word In strSetup.Split(New Char() {","c})
                If cnt = 0 Then
                ElseIf cnt = 1 Then
                    clientserver = word
                ElseIf cnt = 2 Then
                    clientport = word
                ElseIf cnt = 3 Then
                    clientuser = word
                ElseIf cnt = 4 Then
                    clientpass = word
                End If
                cnt = cnt + 1
            Next
            If connclient.State = ConnectionState.Open Then
                connclient.Close()
                comclient.Connection.Close()
            End If
            connclient = New MySql.Data.MySqlClient.MySqlConnection
            connclient.ConnectionString = "server=" & clientserver & "; Port=" & clientport & "; user id=" & clientuser & "; password=" & clientpass & "; database=master"
            connclient.Open()
            comclient.Connection = connclient
            comclient.CommandTimeout = 0
            OpenCentralServer = True

        Catch errMYSQL As MySqlException
            'MessageBox.Show("Can't connect database host " & clientserver, _
            '                 "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            OpenCentralServer = False
        Catch errMS As Exception
            OpenCentralServer = False
        End Try
    End Function
 
    Public Function countqry(ByVal tbl As String, ByVal cond As String)
        Dim cnt As Integer = 0
        Try
            com.CommandText = "select count(*) as cnt from " & tbl & " where " & cond
            rst = com.ExecuteReader
            While rst.Read
                cnt = Val(rst("cnt").ToString)
            End While
            rst.Close()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return cnt
    End Function
    Public Function countqryClient(ByVal tbl As String, ByVal cond As String)
        Dim cnt As Integer = 0
        Try
            comclient.CommandText = "select count(*) as cnt from " & tbl & " where " & cond
            rstclient = comclient.ExecuteReader
            While rstclient.Read
                cnt = Val(rstclient("cnt").ToString)
            End While
            rstclient.Close()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return cnt
    End Function
    Public Function countRecord(ByVal tbl As String)
        Dim cnt As Integer = 0
        Try
            com.CommandText = "select count(*) as cnt from " & tbl
            rst = com.ExecuteReader
            While rst.Read
                cnt = Val(rst("cnt").ToString)
            End While
            rst.Close()
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return cnt
    End Function

    Public Function ShowImage(ByVal fld As String, ByVal picbox As System.Windows.Forms.PictureBox)
        Try
            If rst(fld).ToString <> "" Then
                imgBytes = CType(rst(fld), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)
                picbox.Image = img
                proFileImg = True
            End If
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0
    End Function


    Public Function LoadToComboBox(ByVal query As String, ByVal fields As String, ByVal id As String, ByVal cb As Windows.Forms.ComboBox)
        cb.Items.Clear()
        com.CommandText = query : rst = com.ExecuteReader
        While rst.Read
            If rst(fields).ToString <> "" Then
                cb.Items.Add(New ComboBoxItem(rst(fields).ToString.Replace("_", " "), rst(id.ToString)))
            End If
        End While
        rst.Close()
        Return 0
    End Function
    Public Function LoadToComboBoxPre(ByVal query As String, ByVal fields As String, ByVal id As String, ByVal cb As Windows.Forms.ComboBox)
        cb.Items.Clear()
        com.CommandText = query : rst = com.ExecuteReader
        While rst.Read
            If rst(fields).ToString <> "" Then
                cb.Items.Add(New ComboBoxItem(rst(fields).ToString, rst(id.ToString)))
            End If
        End While
        rst.Close()
        Return 0
    End Function
    Public Class ComboBoxItem
        Private displayValue As String
        Private m_hiddenValue As String

        Public Sub New(ByVal d As String, ByVal h As String)
            displayValue = d
            m_hiddenValue = h
        End Sub

        Public ReadOnly Property HiddenValue() As String
            Get
                Return m_hiddenValue
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return displayValue
        End Function
    End Class

    Const sKey As String = "kira"

    Public Function EncryptTripleDES(ByVal sIn As String) As String
        Dim DES As New TripleDESCryptoServiceProvider()
        Dim hashMD5 As New MD5CryptoServiceProvider()

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the encryptor.
        Dim DESEncrypt As ICryptoTransform = DES.CreateEncryptor()
        ' Get a byte array of the string.
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(sIn)
        ' Transform and return the string.
        Return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function

    Public Function DecryptTripleDES(ByVal sOut As String) As String
        Dim DES As New TripleDESCryptoServiceProvider()
        Dim hashMD5 As New MD5CryptoServiceProvider()

        ' Compute the MD5 hash.
        DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey))
        ' Set the cipher mode.
        DES.Mode = CipherMode.ECB
        ' Create the decryptor.
        Dim DESDecrypt As ICryptoTransform = DES.CreateDecryptor()
        Dim Buffer As Byte() = Convert.FromBase64String(sOut)
        ' Transform and return the string.
        Return System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
    Public Function rchar(ByVal str As String)
        str = str.Replace("'", "''")
        str = str.Replace("\", "\\")
        Return str
    End Function
    Public Function qrysingledata(ByVal field As String, ByVal fqry As String, ByVal tblandqry As String)
        Dim def As String = ""
        com.CommandText = "select " & fqry & " from " & tblandqry : rst = com.ExecuteReader
        While rst.Read
            def = rst(field).ToString
        End While
        rst.Close()
        Return def
    End Function
    Public Function qrysingledataClient(ByVal field As String, ByVal fqry As String, ByVal tblandqry As String)
        Dim def As String = ""
        comclient.CommandText = "select " & fqry & " from " & tblandqry : rstclient = comclient.ExecuteReader
        While rstclient.Read
            def = rstclient(field).ToString
        End While
        rstclient.Close()
        Return def
    End Function
    Public Function ConvertDate(ByVal d As Date)
        Return d.ToString("yyyy-MM-dd")
    End Function
    Public Function ConvertDateTime(ByVal d As Date)
        Return d.ToString("yyyy-MM-dd hh:mm:ss")
    End Function

    Public Function ConvertTime(ByVal d As DateTime)
        Return d.ToString("hh:mm:ss")
    End Function

    Public Function GetServerdate()
        Dim finalstr As String = ""
        com.CommandText = "select current_timestamp as dt"
        rst = com.ExecuteReader
        While rst.Read
            finalstr = rst("dt").ToString
        End While
        rst.Close()
        Return finalstr
    End Function


    Public Function GridColumnAlignment(ByVal grdView As DataGridView, ByVal column As Array, ByVal alignment As DataGridViewContentAlignment) As DataGridView
        '   Dim array() As String = {a}
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    grdView.Columns(i).DefaultCellStyle.Alignment = alignment
                    grdView.Columns(i).HeaderCell.Style.Alignment = alignment
                End If
            Next
        Next
        Return grdView
    End Function
   
    Public Sub RunCommandCom(command As String, permanent As Boolean, minimizewindow As Boolean)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command
        pi.FileName = "cmd.exe"
        If minimizewindow = True Then
            pi.WindowStyle = ProcessWindowStyle.Minimized
        End If
        p.StartInfo = pi
        p.Start()
    End Sub

    Public Function defaultCombobox(ByVal combo As System.Windows.Forms.ComboBox, ByVal form As System.Windows.Forms.Form, ByVal showcode As Boolean)
        Dim DefaultglItemLocation As String = "" : Dim defaultCode As String = "" : Dim defaultItem As String = "" : Dim Result As String = ""
        If System.IO.File.Exists(Application.StartupPath & "\Config\default_" & form.Name & "_" & combo.Name) = True Then
            DefaultglItemLocation = Application.StartupPath & "\Config\default_" & form.Name & "_" & combo.Name
            Dim sr As StreamReader = File.OpenText(DefaultglItemLocation)
            Try
                Dim str As String = sr.ReadLine() : Dim cnt As Integer = 0
                For Each strresult In DecryptTripleDES(str).Split(New Char() {","c})
                    If cnt = 0 Then
                        defaultItem = strresult
                    ElseIf cnt = 1 Then
                        defaultCode = strresult
                    End If
                    cnt = cnt + 1
                Next
                sr.Close()
            Catch errMS As Exception
                sr.Close()
            End Try
            If showcode = True Then
                Result = defaultCode
            Else
                Result = defaultItem
            End If
            Return Result
        End If
    End Function
    Public Function getReportTemplateID()
        Dim strng = ""
        Try
            If CInt(countRecord("pcbr3.tblreporttemplate")) = 0 Then
                strng = "RPT100001"
            Else
                com.CommandText = "select rptid from pcbr3.tblreporttemplate order by right(rptid,6) desc limit 1" : rst = com.ExecuteReader()
                Dim removechar As Char() = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-".ToCharArray()
                Dim sb As New System.Text.StringBuilder
                While rst.Read
                    Dim str As String = rst("rptid").ToString
                    For Each ch As Char In str
                        If Array.IndexOf(removechar, ch) = -1 Then
                            sb.Append(ch)
                        End If
                    Next
                End While
                rst.Close()
                strng = "RPT" & Val(sb.ToString) + 1
            End If
        Catch errMYSQL As MySqlException
            MessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return strng.ToString
    End Function
    Public Function GridCurrencyColumn(ByVal grdView As DataGridView, ByVal column As Array) As DataGridView
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    ' grdView.Columns(i).ValueType = System.Type.GetType("System.Decimal")
                    grdView.Columns(i).ValueType = GetType(Decimal)
                    grdView.Columns(i).DefaultCellStyle.Format = "n2"
                    grdView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    grdView.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

                End If
            Next
        Next
        Return grdView
    End Function
    Public Function DeleteExistingFile(ByVal file As String)
        If System.IO.File.Exists(file) = True Then
            System.IO.File.Delete(file)
        End If
    End Function
    Public Function CC(ByVal m As String)
        Return Val(m.Replace(",", ""))
    End Function
    Public Sub CreateNotExistingTable()
        On Error Resume Next
        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='" & sqldatabase & "' and TABLE_NAME = 'tblgeneralsettings' AND COLUMN_NAME = 'hotlineno'") = 0 Then
            com.CommandText = "ALTER TABLE `" & sqldatabase & "`.`tblgeneralsettings` ADD COLUMN `hotlineno` VARCHAR(200) AFTER `emailcc`;" : com.ExecuteNonQuery()
        End If

        If countqry("information_schema.COLUMNS", "TABLE_SCHEMA='" & sqldatabase & "' and TABLE_NAME = 'tblgeneralsettings' AND COLUMN_NAME = 'termindated'") = 0 Then
            com.CommandText = "ALTER TABLE `" & sqldatabase & "`.`tbldslconnection` ADD COLUMN `termindated` BOOLEAN NOT NULL DEFAULT 0 AFTER `dateinstalled`;" : com.ExecuteNonQuery()
        End If

    End Sub
End Module
