Imports System.Data.SqlClient
Imports System.Data
Public Class Form10
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, i, currentrow As Integer
    Public balance, current As Integer


    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            If Label5.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                Label4.Text = ds.Tables("atm").Rows(i)("cust_name")

                Form9.Label4.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form9.Label5.Text = ds.Tables("atm").Rows(i)("acc_no")

                Exit While
            ElseIf i = maxrows Then
                MsgBox("ADMIN USER")
                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i, currentrow As Integer
        i = 0
        While i <> maxrows + 1
            If Label5.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                current = ds.Tables("atm").Rows(i)("amnt")
                balance = current - TextBox2.Text
                Dim cb As New OleDb.OleDbCommandBuilder(da)
                ds.Tables("atm").Rows(i).Item("amnt") = balance
                da.Update(ds, "atm")
                MsgBox("Amount Transferred")

                Exit While
            ElseIf i = maxrows Then
                MsgBox("INVALID PIN number!!!")
                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
        Form9.Show()
    End Sub
End Class