Imports System.Data.OleDb
Imports System.Data
Imports Project_sav.Class1

Public Class Login
    Inherits System.Web.UI.Page



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Bentrar.Click

        Using myconnection As New OleDbConnection(constring)

            myconnection.Open()
            Dim selectstring As String = "select *from Utilizador where nome= '" & TextUtilizador.Text & "'and  login= '" & Textlogin.Text & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(selectstring, myconnection)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If (reader.HasRows) Then
                reader.Read()

                Session("Nome") = reader("Nome")

                MsgBox("Welcome" & Session("Nome"))
                Response.Redirect("all.aspx", "2")

            ElseIf MsgBox("Nome ou palavra passe errado") Then
                Response.AddHeader("REFRESH", "5, URL= login.aspx")

            ElseIf TextUtilizador.Text = "Kelvin" And Textlogin.Text = "101" Then
                Call adminlogin()
            Else
                MsgBox("Nome ou palavra passe errados")

            End If

        End Using
    End Sub
    Private Sub adminlogin()
        Response.Redirect("gerenciador.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




    End Sub

    Protected Sub Inserir_Click(sender As Object, e As EventArgs) Handles Inserir.Click

        Dim nome, login As String
        nome = TextUtilizador.Text
        login = Textlogin.Text
        Using myconnection As New OleDbConnection(constring)

            myconnection.Open()
            Dim sqlQr1 As String = "insert into Utilizador (nome, login) values(@nome, @login) "
            Using cmd1 As New OleDbCommand(sqlQr1, myconnection)
                cmd1.Parameters.AddWithValue("@nome", nome)
                cmd1.Parameters.AddWithValue("@login", login)
                cmd1.ExecuteNonQuery()
                cmd1.Parameters.Clear()
            End Using
            MsgBox("Utilizador adicionado")
            myconnection.Close()

        End Using

    End Sub
End Class