Imports System.Data
Imports System.Data.SqlClient
Imports ProyectoEventos.UsuarioLogin       ' Tu modelo
Imports ProyectoEventos.DatabaseHelper    ' Tu helper
Imports System.Web.Security

Namespace ProyectoEventos

    Public Class fmrLogin
        Inherits System.Web.UI.Page

        ' Los controles (txtUsuario, lblMensaje, etc.) son accesibles gracias a fmrLogin.aspx.designer.vb

        Dim dbHelper As New DatabaseHelper()

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then

                lblMensaje.Text = ""
            End If
        End Sub

        Protected Sub BtnLogin_Click(sender As Object, e As EventArgs)

            Dim user As String = txtUsuario.Text.Trim()
            Dim pass As String = txtContrasena.Text

            ' 1. Validar campos básicos
            If String.IsNullOrWhiteSpace(user) OrElse String.IsNullOrWhiteSpace(pass) Then
                lblMensaje.Text = "Por favor, ingrese su nombre de usuario y contraseña."
                Exit Sub
            End If

            Try
                ' 2. Llamar al Helper para validar credenciales
                Dim usuarioValidado As UsuarioLogin = dbHelper.ValidarUsuario(user, pass)

                If usuarioValidado IsNot Nothing Then

                    ' 3. AUTENTICACIÓN EXITOSA
                    Session("UsuarioId") = usuarioValidado.IdUsuario
                    Session("NombreUsuario") = usuarioValidado.NombreUsuario
                    Session("Rol") = usuarioValidado.Rol

                    ' Redireccionar
                    Response.Redirect("MenuPrincipal.aspx")

                Else
                    ' 4. AUTENTICACIÓN FALLIDA
                    lblMensaje.Text = "Credenciales incorrectas. Verifique su nombre de usuario y contraseña."
                End If

            Catch ex As Exception
                lblMensaje.Text = "Error al iniciar sesión: " & ex.Message
            End Try
        End Sub

    End Class
End Namespace