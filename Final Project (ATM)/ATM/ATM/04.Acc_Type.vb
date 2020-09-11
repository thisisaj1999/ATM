Imports System.Data.SqlClient
Imports System.Data
Public Class Form4
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, i, currentrow As Integer

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbprovider = "Provider=Microsoft.Jet.OLEDB.4.0;"
        dbsource = "Data Source=C:\Users\Atul\Desktop\Final Project (ATM)\ATM\ATM\Resources\atm.mdb"


        con.ConnectionString = dbprovider & dbsource
        con.Open()

        sql = "SELECT * FROM master"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "atm")
        maxrows = ds.Tables("atm").Rows.Count
        i = 0
        While i <> maxrows + 1
            If Label2.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                Label1.Text = ds.Tables("atm").Rows(i)("cust_name")

                Form3.Label4.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form3.Label1.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form5.Label1.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form5.Label2.Text = ds.Tables("atm").Rows(i)("acc_no")

                Exit While
            ElseIf i = maxrows Then
                MsgBox("ADMIN USER")
                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form5.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Form3.Show()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

End Class