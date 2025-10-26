Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DataBaseHelper
    Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString


    Public Sub New()

    End Sub


    Public Function EjecutarConsulta(ByVal sql As String) As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function


    Public Function EjecutarComando(ByVal sql As String, Optional ByVal parametros As SqlParameter() = Nothing) As Integer
        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                If parametros IsNot Nothing Then
                    cmd.Parameters.AddRange(parametros)
                End If
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function
End Class

