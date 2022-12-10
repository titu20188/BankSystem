Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32

Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        ' Me.Close()
        Dim connection As New CONNECT()
        Dim adapter As New MySqlDataAdapter()
        Dim command As New MySqlCommand()
        Dim table As New DataTable()
        Dim username As String = UsernameTextBox.Text
        Dim pass As String = PasswordTextBox.Text
        Dim SelectQuery As String = "SELECT * FROM `users_tbl` WHERE `username`=@un AND `password`=@pass"

        'command.CommandText = SelectQuery
        'command.Connection = CONNECT.GetConnection()

        command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass

        adapter.SelectCommand = command
        '       adapter.Fill(table)
        GC.Collect()
        If (table.Rows.Count > 0) Then
            Mainform.Show()
            Me.Hide()
            GC.Collect()
        Else
            MessageBox.Show("Invalid data ", "login error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GC.Collect()
        End If
        GC.Collect()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        GC.Collect()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        GC.Collect()
        Dim iExit As DialogResult
        iExit = MessageBox.Show("Confirm you want to quit the program ", "Bank Management - Systems.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (iExit = DialogResult.Yes) Then
            Application.Exit()
        End If
    End Sub
End Class
