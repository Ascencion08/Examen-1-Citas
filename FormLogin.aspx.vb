Imports System.Data.SqlClient

Public Class FormLogin
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim helper As New DatabaseHelper()
        Dim user As String = txtUser.Text.Trim()
        Dim pass As String = txtPass.Text.Trim()

        If user = "" Or pass = "" Then
            lblError.Text = "Debe ingresar usuario y contraseña."
            Exit Sub
        End If

        Dim usuario As UsuarioLogin = helper.ValidarUsuario(user, pass)

        If usuario Is Nothing Then
            lblError.Text = "Credenciales incorrectas."
        Else
            Session("Usuario") = usuario.NombreUsuario
            Session("Rol") = usuario.Rol
            Session("NombreCompleto") = usuario.NombreCompleto

            Response.Redirect("FormPaciente.aspx")
        End If

    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Response.Redirect("Registro.aspx")
    End Sub

End Class
