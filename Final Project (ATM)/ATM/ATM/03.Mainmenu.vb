Imports System.Data.SqlClient
Imports System.Data
Public Class Form3
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, i, currentrow As Integer


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If Label1.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                Label4.Text = ds.Tables("atm").Rows(i)("cust_name")

                Form4.Label1.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form4.Label2.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form6.Label1.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form6.Label2.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form7.Label4.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form7.Label2.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form8.Label4.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form8.Label5.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form11.Label10.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form11.Label12.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form12.Label7.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form12.Label6.Text = ds.Tables("atm").Rows(i)("acc_no")

                Exit While
            ElseIf i = maxrows Then
                MsgBox("ADMIN USER")
                Exit While
            End If
            i += 1
        End While
        currentrow = i

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form6.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form4.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form7.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form8.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Form12.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Form11.Show()
    End Sub
End Class