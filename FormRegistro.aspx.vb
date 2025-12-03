Imports System

Public Class FormRegistro
    Inherits System.Web.UI.Page

    Dim dbhelper As New DatabaseHelper()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Nada adicional al cargar la página
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        Try
            Dim usuario As New UsuarioLogin() With {
                .NombreCompleto = txtNombre.Text.Trim(),
                .NombreUsuario = txtUsuario.Text.Trim(),
                .Rol = ddlRol.SelectedValue
            }

            ' Usa DatabaseHelper para insertar el usuario en la tabla UsuarioLogin
            Dim resultado As String = dbhelper.RegistrarUsuario(usuario, txtContrasena.Text.Trim())
            lblMensaje.Text = resultado

            If resultado.Contains("correctamente") Then
                ' Limpiar campos después de registrar
                txtNombre.Text = ""
                txtUsuario.Text = ""
                txtContrasena.Text = ""
                ddlRol.SelectedIndex = 0
            End If

        Catch ex As Exception
            lblMensaje.Text = "Error al registrar usuario: " & ex.Message
        End Try
    End Sub
End Class
