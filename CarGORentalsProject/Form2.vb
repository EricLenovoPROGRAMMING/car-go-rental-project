Imports System.Data.OleDb

Public Class Form2
    Dim conn As OleDbConnection
    Dim connString As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=|DataDirectory|\login.mdb"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim s As New OleDbCommand("SELECT * FROM login", conn)
            Dim ad As OleDbDataReader = s.ExecuteReader
            'While ad.Read
            'Throw New Exception(ad.GetString(ad.GetOrdinal("username")))
            'Debug.WriteLine(ad.GetString(ad.GetOrdinal("username")))
            'End While
            If (ad.Read) Then
                If (ad.GetString(ad.GetOrdinal("password")) = TextBox2.Text) Then
                    MessageBox.Show("Hello, " & ad.GetString(ad.GetOrdinal("username")) & "!")
                Else
                    MessageBox.Show("Wrong Password, " & ad.GetString(ad.GetOrdinal("username")) & "!")
                End If
            End If

        Catch es As Exception
            MessageBox.Show(es.Message)
        End Try
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn = New OleDbConnection(connString)
            conn.Open()
        Catch es As Exception
            MessageBox.Show(es.Message)
        End Try
    End Sub
End Class