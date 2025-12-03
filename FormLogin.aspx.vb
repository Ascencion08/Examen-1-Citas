Imports System

Public Class FormLogin
    Inherits System.Web.UI.Page

    Dim dbhelper As New DatabaseHelper()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim usuario As String = txtUsuario.Text.Trim()
            Dim contrasena As String = txtContrasena.Text.Trim()

            Dim usuarioLogin As UsuarioLogin = dbhelper.ValidarUsuario(usuario, contrasena)

            If usuarioLogin IsNot Nothing Then
                Session("IdUsuario") = usuarioLogin.IdUsuario
                Session("Usuario") = usuarioLogin.NombreUsuario
                Session("Rol") = usuarioLogin.Rol
                Session("NombreCompleto") = usuarioLogin.NombreCompleto
                Response.Redirect("FormularioCitas.aspx")
            Else
                lblMensaje.Text = "Usuario o contraseña incorrectos."
            End If

        Catch ex As Exception
            lblMensaje.Text = "Error al iniciar sesión: " & ex.Message
        End Try
    End Sub

    Protected Sub btnRegistro_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormRegistro.aspx")
    End Sub

End Class
