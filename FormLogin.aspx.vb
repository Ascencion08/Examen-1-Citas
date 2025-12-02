Public Class FormLogin
    Inherits System.Web.UI.Page

    Private db As New DatabaseHelper()

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim usuario As String = txtUser.Text.Trim()
        Dim pass As String = txtPass.Text.Trim()

        If usuario = "" Or pass = "" Then
            lblError.Text = "Debe ingresar usuario y contraseña."
            Exit Sub
        End If

        ' Llamamos al helper para validar
        Dim usuarioValidado As UsuarioLogin = db.ValidarUsuario(usuario, pass)

        If usuarioValidado IsNot Nothing Then

            ' Guardar en sesión
            Session("UsuarioActual") = usuarioValidado

            ' Redirigir al inicio
            Response.Redirect("Default.aspx")

        Else
            lblError.Text = "Usuario o contraseña incorrectos."
        End If

    End Sub

End Class
