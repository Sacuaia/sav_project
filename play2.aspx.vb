Imports System.Data.OleDb
Imports Project_sav.Class1



Public Class play2
    Inherits System.Web.UI.Page
    Protected log As Project_sav.Class1 = New Class1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim timestamp As String = DateTime.Now.ToString("yyyMMddhhmmss")
        Dim login As String = Session("Nome")
        If String.IsNullOrEmpty(login) Then
            MsgBox("Tem que se autenticar primeiro")
            Response.AddHeader("REFRESH", "1, URL= login.aspx")
            Textitulo.Visible = False
            TextSinopse.Visible = False
            FileUpload1.Visible = False
            sinopse.Visible = False
            Label1.Visible = False

            Inserir.Visible = False
            HyperLink1.Visible = False
        End If
    End Sub
    Protected Sub Inserir_Click(sender As Object, e As EventArgs) Handles Inserir.Click

        Using myconnection As New OleDbConnection(constring)
            myconnection.Open()

            Dim link As String = System.IO.Path.GetFileName(FileUpload1.FileName)
            link = link.Replace(" ", "")
            FileUpload1.SaveAs(Server.MapPath("~/media/") + link)
            Dim co As String = ("~/media") + link
            co = "<Video width=400 Controls><Source src=" + link + "
    type=video/mp4></video>"


            Dim sqlQr As String = "Insert into videodata(nome,autor,videolink) values('" +
Textitulo.Text + "','" + TextSinopse.Text + "','" + link + "')"
            Using cmd As New OleDbCommand(sqlQr, myconnection)
                cmd.ExecuteNonQuery()

            End Using
            resultado.Text = String.Format(
                "Upload file: {0}<br />" &
                "File size (in bytes): {1:N0}<br />" &
                "Content-type: {2}",
                FileUpload1.FileName,
              FileUpload1.FileBytes.Length,
           FileUpload1.PostedFile.ContentType)
            Textitulo.Text = ""
            TextSinopse.Text = ""


            Try
                log.inserirLogs(Session("ID"), sqlQr, Textitulo.Text & "<-->" & TextSinopse.Text & "<-->" & link)
            Catch
                MsgBox("Erro ao inserir log")
            End Try
            myconnection.Close()
        End Using
    End Sub
End Class