Imports System.Data.SqlClient

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim helper As New DatabaseHelper()

        Dim usuario As New UsuarioLogin()
        usuario.NombreUsuario = txtUsuario.Text.Trim()
        usuario.NombreCompleto = txtNombreCompleto.Text.Trim()
        usuario.Rol = ddlRol.SelectedValue

        Dim contrasena As String = txtPassword.Text.Trim()

        If usuario.NombreUsuario = "" Or contrasena = "" Then
            lblMensaje.Text = "Debe completar todos los campos."
            Exit Sub
        End If

        Dim resultado As String = helper.RegistrarUsuario(usuario, contrasena)

        lblMensaje.Text = resultado

        If resultado.Contains("correctamente") Then
            txtUsuario.Text = ""
            txtPassword.Text = ""
            txtNombreCompleto.Text = ""
        End If

    End Sub

    Protected Sub btnVolverLogin_Click(sender As Object, e As EventArgs) Handles btnVolverLogin.Click
        Response.Redirect("FormLogin.aspx")
    End Sub

End Class
