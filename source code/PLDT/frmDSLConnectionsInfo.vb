Imports System.Globalization

Public Class frmDSLConnectionsInfo

    Private Sub frmDSLConnectionsInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If mode.Text <> "edit" Then
            FillComboBoxData()
        End If

    End Sub
    Public Sub FillComboBoxData()
        LoadToComboBox("select * from tblprovider", "description", "providercode", txtProvider)
        LoadToComboBox("select distinct officetype from tbldslconnection", "officetype", "officetype", txtOfficeType)
        LoadToComboBox("select distinct officedescription from tbldslconnection", "officedescription", "officedescription", txtOfficeDescription)
        LoadToComboBox("select distinct contactperson from tbldslconnection", "contactperson", "contactperson", txtContactPerson)
        LoadToComboBox("select distinct service from tbldslconnection", "service", "service", txtServiceType)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtProvider.Text = "" Then
            MsgBox("Please select provider!", MsgBoxStyle.Exclamation, "Error Message")
            txtProvider.Focus()
            Exit Sub
        ElseIf txtOfficeName.Text = "" Then
            MsgBox("Please enter office name!", MsgBoxStyle.Exclamation, "Error Message")
            txtOfficeName.Focus()
            Exit Sub
        ElseIf txtFullAddress.Text = "" Then
            MsgBox("Please enter office address!", MsgBoxStyle.Exclamation, "Error Message")
            txtFullAddress.Focus()
            Exit Sub
        ElseIf txtOfficeType.Text = "" Then
            MsgBox("Please enter office type!", MsgBoxStyle.Exclamation, "Error Message")
            txtOfficeType.Focus()
            Exit Sub
        ElseIf txtContactPerson.Text = "" Then
            MsgBox("Please enter contact person name!", MsgBoxStyle.Exclamation, "Error Message")
            txtContactPerson.Focus()
            Exit Sub
        ElseIf txtContactNumber.Text = "" Then
            MsgBox("Please enter contact person number!", MsgBoxStyle.Exclamation, "Error Message")
            txtContactNumber.Focus()
            Exit Sub
        ElseIf txtAccountNumber.Text = "" Then
            MsgBox("Please enter Acct number!", MsgBoxStyle.Exclamation, "Error Message")
            txtAccountNumber.Focus()
            Exit Sub
        ElseIf txtServiceNumber.Text = "" Then
            MsgBox("Please enter service number!", MsgBoxStyle.Exclamation, "Error Message")
            txtServiceNumber.Focus()
            Exit Sub
        ElseIf txtServiceType.Text = "" Then
            MsgBox("Please enter service type!", MsgBoxStyle.Exclamation, "Error Message")
            txtServiceType.Focus()
            Exit Sub
        ElseIf txtIpAddress.Text = "" Then
            MsgBox("Please enter ip address!", MsgBoxStyle.Exclamation, "Error Message")
            txtIpAddress.Focus()
            Exit Sub
        ElseIf txtBandWidth.Text = "" Then
            MsgBox("Please enter bandwidth!", MsgBoxStyle.Exclamation, "Error Message")
            txtBandWidth.Focus()
            Exit Sub
        ElseIf Val(CC(txtMRC.Text)) = 0 Then
            MsgBox("Please enter MRC!", MsgBoxStyle.Exclamation, "Error Message")
            txtMRC.Focus()
            Exit Sub
        ElseIf Val(CC(txtVat.Text)) = 0 Then
            MsgBox("Please enter VAT!", MsgBoxStyle.Exclamation, "Error Message")
            txtVat.Focus()
            Exit Sub
        ElseIf Val(CC(txtTotal.Text)) = 0 Then
            MsgBox("Please enter Total!", MsgBoxStyle.Exclamation, "Error Message")
            txtTotal.Focus()
            Exit Sub
        End If
        If mode.Text = "edit" Then
            com.CommandText = "UPDATE tbldslconnection set serviceid='" & txtServiceId.Text & "', officetype='" & txtOfficeType.Text & "',  officename='" & txtOfficeName.Text & "', officedescription='" & rchar(txtOfficeDescription.Text) & "', fulladdress='" & rchar(txtFullAddress.Text) & "', service='" & txtServiceType.Text & "', provider='" & providercode.Text & "',servicenumber='" & txtServiceNumber.Text & "', accountnumber='" & txtAccountNumber.Text & "',ipaddress='" & txtIpAddress.Text & "',  contactperson='" & txtContactPerson.Text & "', contactnumber='" & txtContactNumber.Text & "', bandwidth='" & txtBandWidth.Text & "',mrc='" & Val(CC(txtMRC.Text)) & "',vat='" & Val(CC(txtVat.Text)) & "',total='" & Val(CC(txtTotal.Text)) & "',dateinstalled='" & ConvertDate(txtDateInstalled.Value) & "',terminationdate='" & ConvertDate(txtTerminationDate.Value) & "',termindated=" & ckTerminated.CheckState & ",term='" & txtTerm.Text & "' where id='" & id.Text & "'" : com.ExecuteNonQuery()
            MsgBox("Office Successfully Updated!", MsgBoxStyle.Information)
            frmDSLConnections.FilterOffice()
        Else
            com.CommandText = "insert into tbldslconnection set serviceid='" & txtServiceId.Text & "', officetype='" & txtOfficeType.Text & "',  officename='" & txtOfficeName.Text & "', officedescription='" & rchar(txtOfficeDescription.Text) & "', fulladdress='" & rchar(txtFullAddress.Text) & "', service='" & txtServiceType.Text & "', provider='" & providercode.Text & "',servicenumber='" & txtServiceNumber.Text & "', accountnumber='" & txtAccountNumber.Text & "',ipaddress='" & txtIpAddress.Text & "',  contactperson='" & txtContactPerson.Text & "', contactnumber='" & txtContactNumber.Text & "', bandwidth='" & txtBandWidth.Text & "',mrc='" & Val(CC(txtMRC.Text)) & "',vat='" & Val(CC(txtVat.Text)) & "',total='" & Val(CC(txtTotal.Text)) & "',dateinstalled='" & ConvertDate(txtDateInstalled.Value) & "',terminationdate='" & ConvertDate(txtTerminationDate.Value) & "',termindated=" & ckTerminated.CheckState & ",term='" & txtTerm.Text & "'" : com.ExecuteNonQuery()
            MsgBox("Office Successfully Added!", MsgBoxStyle.Information)
            frmDSLConnections.FilterOffice()
        End If
    End Sub
    
    Private Sub txtOfficeName_TextChanged(sender As Object, e As EventArgs) Handles txtOfficeName.TextChanged, txtOfficeType.SelectedIndexChanged, txtProvider.SelectedIndexChanged, txtServiceType.SelectedIndexChanged
        txtServiceId.Text = LCase(txtOfficeName.Text & "-" & txtOfficeType.Text & "-" & txtProvider.Text & "-" & txtServiceType.Text)
    End Sub

     
    Private Sub id_TextChanged(sender As Object, e As EventArgs) Handles id.TextChanged
        If id.Text = "" Then Exit Sub
        FillComboBoxData()
        com.CommandText = "select *,(select description from tblprovider where providercode=tbldslconnection.provider) as 'providerdesc' from tbldslconnection where id='" & id.Text & "'" : rst = com.ExecuteReader
        While rst.Read
            txtServiceId.Text = rst("serviceid").ToString
            txtProvider.Text = rst("providerdesc").ToString
            providercode.Text = rst("provider").ToString
            txtOfficeName.Text = rst("officename").ToString
            txtFullAddress.Text = rst("fulladdress").ToString
            txtOfficeType.Text = rst("officetype").ToString
            txtOfficeDescription.Text = rst("officedescription").ToString
            txtServiceType.Text = rst("service").ToString
            txtServiceNumber.Text = rst("servicenumber").ToString
            txtAccountNumber.Text = rst("accountnumber").ToString
            txtIpAddress.Text = rst("ipaddress").ToString
            txtContactPerson.Text = rst("contactperson").ToString
            txtContactNumber.Text = rst("contactnumber").ToString
            txtBandWidth.Text = rst("bandwidth").ToString
            txtMRC.Text = FormatNumber(rst("mrc").ToString, 2)
            txtVat.Text = FormatNumber(rst("vat").ToString, 2)
            txtTotal.Text = FormatNumber(rst("total").ToString, 2)
            txtDateInstalled.Text = rst("dateinstalled").ToString
            ckTerminated.Checked = rst("termindated")
            If ckTerminated.Checked = True Then
                txtTerminationDate.Text = rst("terminationdate").ToString
            End If

            txtTerm.Text = rst("term").ToString
        End While
        rst.Close()
    End Sub
 
    Private Sub txtProvider_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtProvider.SelectedValueChanged
        providercode.Text = DirectCast(txtProvider.SelectedItem, ComboBoxItem).HiddenValue()
    End Sub
     
    Private Sub ckTerminated_CheckedChanged(sender As Object, e As EventArgs) Handles ckTerminated.CheckedChanged
        If ckTerminated.Checked = True Then
            txtTerminationDate.Enabled = True
        Else
            txtTerminationDate.Enabled = False
        End If
    End Sub
End Class
