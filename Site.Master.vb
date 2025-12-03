Imports System

Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("Usuario") IsNot Nothing Then
            lblUsuario.Text = "Hola, " & Session("Usuario").ToString()
        Else
            Response.Redirect("FormLogin.aspx")
        End If
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()
        Response.Redirect("FormLogin.aspx")
    End Sub
End Class
