Imports System.Data.SqlClient
Imports System.Data
Public Class Form11

    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, i, currentrow As Integer

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        dbprovider = "Provider=Microsoft.Jet.OLEDB.4.0;"
        dbsource = "Data Source=C:\Users\Atul\Desktop\Final Project (ATM)\ATM\ATM\Resources\atm.mdb"


        con.ConnectionString = dbprovider & dbsource
        con.Open()

        sql = "SELECT * FROM dailytrans"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "atm")
        maxrows = ds.Tables("atm").Rows.Count
        i = 0


        While i <> maxrows + 1
            If Label12.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                Label10.Text = ds.Tables("atm").Rows(i)("cust_name")

                Form3.Label4.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form3.Label1.Text = ds.Tables("atm").Rows(i)("acc_no")

                Dim dv As DataView
                dv = New DataView(ds.Tables(0), "acc_no=" & Label12.Text & " ", "acc_no", DataViewRowState.CurrentRows)
                DataGridView1.DataSource = dv

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

        If MsgBox("Proceed to Main-Menu", vbYesNo, "Continue") = vbYes Then
            Me.Close()
            Form3.Show()
        End If


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
        Form3.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

End Class