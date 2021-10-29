Imports System.Data.OleDb
Imports System.Data
Imports Project_sav.Class1
Public Class all
    Inherits System.Web.UI.Page
    Protected log As Project_sav.Class1 = New Class1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            BindGrid()
        End If

    End Sub
    Private Sub BindGrid()
        Dim login As String = Session("Nome")

        If Not Page.IsPostBack Then
            Using myconnection As New OleDbConnection(constring)
                myconnection.Open()

                Dim selecstring As String = "select *from videodata"
                Dim cmd As OleDbDataAdapter = New OleDbDataAdapter(selecstring, myconnection)
                Dim ds As DataSet = New DataSet()

                cmd.Fill(ds, "videodata")

                DropDownList1.DataSource = ds.Tables("videodata").DefaultView
                DropDownList1.DataBind()

                myconnection.Close()
            End Using
        End If
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Using myconnection As New OleDbConnection(constring)
            myconnection.Open()

            Dim selecstring As String = "select * from videodata where id=" & DropDownList1.Text

            Dim cmd As OleDbCommand = New OleDbCommand(selecstring, myconnection)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While (reader.Read())

                Textnome.Text = reader("Nome")
                Textautor.Text = reader("autor")

            End While
            myconnection.Close()


        End Using
    End Sub

    Protected Sub apagar_Click(sender As Object, e As EventArgs) Handles apagar.Click
        Dim id As String
        id = DropDownList1.Text

        Using myconnection As New OleDbConnection(constring)
            myconnection.Open()

            Dim sqlQr1 As String = " Delete from videodata where id =@id"

            Try
                Using cmd1 As New OleDbCommand(sqlQr1, myconnection)
                    cmd1.Parameters.AddWithValue("@id", CInt(id))
                    cmd1.ExecuteNonQuery()
                End Using
            Catch
                MsgBox("Erro ao apagar")
            End Try

            Try
                log.inserirLogs(Session("Nome"), sqlQr1, Session("Nome") & "<-->" & Textnome.Text & "<-->" & Textautor.Text & "<-->")
            Catch
                MsgBox("Erro ao inserir log")
            End Try
            myconnection.Close()
        End Using
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nome, pass As String

        nome = Textnome.Text
        pass = Textautor.Text


        Using myconnection As New OleDbConnection(constring)
            myconnection.Open()
            Dim sqlQr As String = "update Utilizador Set Nome='" + Textnome.Text + "', Login=" + Textautor.Text + "' where id=" & DropDownList1.Text & ""


            Using cmd1 As New OleDbCommand(sqlQr, myconnection)

                cmd1.Parameters.AddWithValue("@nome", nome)
                cmd1.Parameters.AddWithValue("@login", pass)
                cmd1.ExecuteNonQuery()
                cmd1.Parameters.Clear()
            End Using

            MsgBox("Dados actualizados")
            Response.Redirect("all.aspx")

            myconnection.Close()
            Try
                log.inserirLogs(Session("Nome"), sqlQr, Session("Nome") & "<-->" & Textnome.Text & "<-->" & Textautor.Text & "<-->")
            Catch
                MsgBox("Erro ao inserir log")
            End Try

        End Using
    End Sub
End Class