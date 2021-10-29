Imports System.Data.OleDb

Public Class Class1

    Public Const constring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Jumar Sacuaia\source\repos\Project_sav\Project_sav\App_Data\Project_sav.accdb"

    Public Function inserirLogs(id_u As Integer, cn As Integer, parametros As Integer) As Integer
        Using myconnection As New OleDbConnection(constring)
            myconnection.Open()
            Dim sqlQry As String = "insert into logs (id_u , cn, parametros, data) values(@id_u, @cn, @parametros, @data)"
            Using cmd As New OleDbCommand(sqlQry, myconnection)
                cmd.Parameters.AddWithValue("@id_u", id_u)
                cmd.Parameters.AddWithValue("@cn", cn)
                cmd.Parameters.AddWithValue("@parametros", parametros)
                cmd.Parameters.AddWithValue("@data", System.DateTime.Now)
                cmd.ExecuteNonQuery()

            End Using


        End Using
        Return 1
    End Function

End Class
