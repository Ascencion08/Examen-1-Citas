Imports System.Data.SqlClient

Public Class fmriniciosesion
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuario As String = txtUser.Text.Trim()
        Dim pass As String = txtPass.Text.Trim()

        If ValidarUsuario(usuario, pass) Then
            Response.Redirect("Default.aspx")
        Else
            lblError.Text = "Usuario o contraseña incorrectos."
        End If
    End Sub

    Private Function ValidarUsuario(user As String, pass As String) As Boolean
        Dim conexion As New SqlConnection("TU CADENA DE CONEXIÓN")
        Dim cmd As New SqlCommand("SELECT IdUsuario, NombreUsuario, NombreCompleto, Rol 
                                   FROM Usuarios 
                                   WHERE NombreUsuario=@user AND Contrasena=@pass", conexion)

        cmd.Parameters.AddWithValue("@user", user)
        cmd.Parameters.AddWithValue("@pass", pass)

        conexion.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            Dim u As New UsuarioLogin With {
                .IdUsuario = reader("IdUsuario"),
                .NombreUsuario = reader("NombreUsuario").ToString(),
                .NombreCompleto = reader("NombreCompleto").ToString(),
                .Rol = reader("Rol").ToString()
            }

            ' GUARDAR USUARIO EN SESIÓN
            Session("UsuarioActual") = u

            conexion.Close()
            Return True
        End If

        conexion.Close()
        Return False
    End Function
End Class
