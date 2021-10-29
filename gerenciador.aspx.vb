Imports System.Data.OleDb
Imports System.Data
Imports Project_sav.Class1
Public Class gerenciador
    Inherits System.Web.UI.Page
    Protected log As Project_sav.Class1 = New Class1


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, DropDownList1.SelectedIndexChanged
        Dim timestamp As String = DateTime.Now.ToString("yyyMMddhhmmss")
        If Session("Nome") <> "Kelvin" Then

            MsgBox("Sem autenticação vai ser redirecionado para outra pagina !!! ")
            Response.Redirect("login.aspx")

            Label1.Visible = False
            Label2.Visible = False
            Textnome.Visible = False
            TextPass.Visible = False
            Button2.Visible = False
            apagar.Visible = False
            DropDownList1.Visible = False

        ElseIf MsgBox("Olá Admin") Then

        End If



        If Not Page.IsPostBack Then
            Using myconnection As New OleDbConnection(constring)
                myconnection.Open()

                Dim selecstring As String = "select *from Utilizador"
                Dim cmd As OleDbDataAdapter = New OleDbDataAdapter(selecstring, myconnection)
                Dim ds As DataSet = New DataSet()

                cmd.Fill(ds, "Utilizador")

                DropDownList1.DataSource = ds.Tables("Utilizador").DefaultView
                DropDownList1.DataBind()

                myconnection.Close()
            End Using
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("all.aspx")
    End Sub


    Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        Using myconnection As New OleDbConnection(constring)
            myconnection.Open()

            Dim selecstring As String = "select * from Utilizador where id=" & DropDownList1.Text

            Dim cmd As OleDbCommand = New OleDbCommand(selecstring, myconnection)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While (reader.Read())

                Textnome.Text = reader("Nome")
                TextPass.Text = reader("Login")

            End While
            myconnection.Close()


        End Using
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nome, pass As String

        nome = Textnome.Text
        pass = TextPass.Text


        Using myconnection As New OleDbConnection(constring)
            myconnection.Open()
            Dim sqlQr As String = "update Utilizador Set Nome='" + Textnome.Text + "', Login=" + TextPass.Text + "' where id=" & DropDownList1.Text & ""
            Using cmd1 As New OleDbCommand(sqlQr, myconnection)

                cmd1.Parameters.AddWithValue("@nome", nome)
                cmd1.Parameters.AddWithValue("@login", pass)
                cmd1.ExecuteNonQuery()
                cmd1.Parameters.Clear()
            End Using

            MsgBox("Dados actualizados")
            Response.Redirect("all.aspx")

            Try
                log.inserirLogs(Session("Nome"), sqlQr, Textnome.Text & "<-->" & TextPass.Text)
            Catch
                MsgBox("Erro ao inserir log")
            End Try
            myconnection.Close()
        End Using
    End Sub

    Protected Sub apagar_Click(sender As Object, e As EventArgs) Handles Apagar.Click
        Dim id As String
        id = DropDownList1.Text

        Using myconnection As New OleDbConnection(constring)
            myconnection.Open()

            Dim sqlQr1 As String = " Delete from Utilizador where id =@id"

            Try
                Using cmd1 As New OleDbCommand(sqlQr1, myconnection)
                    cmd1.Parameters.AddWithValue("@id", CInt(id))
                    cmd1.ExecuteNonQuery()
                End Using
            Catch
                MsgBox("Erro ao apagar utilizador")
            End Try

            Try
                log.inserirLogs(Session("Nome"), sqlQr1, CInt(id))
            Catch
                MsgBox("Erro ao inserir log")
            End Try
            myconnection.Close()
        End Using
    End Sub
End Class