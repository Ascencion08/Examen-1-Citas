Imports ProyectoEventos
Imports Utils
Imports System.Globalization

Public Class FormPaciente
    Inherits System.Web.UI.Page

    Dim db As New DatabaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPacientes()
        End If
    End Sub

    Private Sub CargarPacientes()
        gridPacientes.DataSource = db.getPacientes()
        gridPacientes.DataBind()
    End Sub

    Private Function CrearPaciente() As Paciente
        Dim p As New Paciente()

        If Not String.IsNullOrWhiteSpace(txtIdPaciente.Text) Then
            p.IdPaciente = Convert.ToInt32(txtIdPaciente.Text)
        End If

        p.Nombre = txtNombre.Text
        p.Apellido = txtApellido.Text

        Dim fecha As DateTime
        If Not DateTime.TryParse(txtFechaNacimiento.Text, fecha) Then
            Throw New Exception("Formato de fecha inválido")
        End If
        p.FechaNacimiento = fecha

        p.Telefono = txtTelefono.Text
        p.Correo = txtCorreo.Text
        p.Direccion = txtDireccion.Text

        Return p
    End Function

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim paciente = CrearPaciente()
            Dim mensaje As String = db.insertPaciente(paciente)

            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, mensaje)
            Else
                SwalUtils.ShowSwal(Me, "Guardado", mensaje)
                CargarPacientes()
                btnLimpiar_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, ex.Message)
        End Try
    End Sub


    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If String.IsNullOrWhiteSpace(txtIdPaciente.Text) Then
                SwalUtils.ShowSwal(Me, "Atención", "Debe seleccionar un paciente", "warning")
                Exit Sub
            End If

            Dim paciente = CrearPaciente()
            Dim mensaje As String = db.updatePaciente(paciente)

            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, mensaje)
            Else
                SwalUtils.ShowSwal(Me, "Actualizado", mensaje)
                CargarPacientes()
                btnLimpiar_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, ex.Message)
        End Try
    End Sub



    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If gridPacientes.SelectedIndex = -1 Then
                SwalUtils.ShowSwal(Me, "Atención", "Debe seleccionar un paciente", "warning")
                Exit Sub
            End If

            Dim id As Integer = Convert.ToInt32(gridPacientes.SelectedValue)
            Dim mensaje As String = db.deletePaciente(id)

            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, mensaje)
            Else
                SwalUtils.ShowSwal(Me, "Eliminado", mensaje)
                CargarPacientes()
                btnLimpiar_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, ex.Message)
        End Try
    End Sub

    Protected Sub gridPacientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridPacientes.SelectedIndexChanged
        Dim row = gridPacientes.SelectedRow

        txtIdPaciente.Text = Server.HtmlDecode(row.Cells(0).Text)
        txtNombre.Text = Server.HtmlDecode(row.Cells(1).Text)
        txtApellido.Text = Server.HtmlDecode(row.Cells(2).Text)
        txtFechaNacimiento.Text = Server.HtmlDecode(row.Cells(3).Text)
        txtTelefono.Text = Server.HtmlDecode(row.Cells(4).Text)
        txtDireccion.Text = Server.HtmlDecode(row.Cells(5).Text)
        txtCorreo.Text = Server.HtmlDecode(row.Cells(6).Text)
    End Sub





    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIdPaciente.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtFechaNacimiento.Text = ""
        txtTelefono.Text = ""
        txtDireccion.Text = ""
        txtCorreo.Text = ""

        ' También limpiamos la selección del Grid
        gridPacientes.SelectedIndex = -1
    End Sub

    Protected Sub btnIrCitas_Click(sender As Object, e As EventArgs) Handles btnIrCitas.Click
        Response.Redirect("FormularioCitas.aspx")
    End Sub

    Protected Sub btnIrDoctores_Click(sender As Object, e As EventArgs) Handles btnIrDoctores.Click
        Response.Redirect("FormDoctor.aspx")

    End Sub


End Class
