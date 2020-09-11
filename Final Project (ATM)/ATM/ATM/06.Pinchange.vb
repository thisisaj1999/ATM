Imports System.Data.SqlClient
Imports System.Data
Public Class Form6
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, i, currentrow As Integer
    Public balance, current As Integer

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If Label2.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                If TextBox2.Text = TextBox3.Text Then

                    Dim cb As New OleDb.OleDbCommandBuilder(da)
                    ds.Tables("atm").Rows(i).Item("pin") = TextBox2.Text

                    da.Update(ds, "atm")
                    MsgBox("Pin Changed")


                End If
                MsgBox("Check your Pin Number")
                Exit While

            ElseIf i = maxrows Then
                MsgBox("INVALID Pin Number!!!")
                Exit While
            End If
            i += 1
        End While
        currentrow = i

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        Form3.Show()
    End Sub

End Class