Imports ProyectoEventos

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
        p.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text)
        p.Telefono = txtTelefono.Text
        p.Correo = txtCorreo.Text
        p.Direccion = txtDireccion.Text

        Return p
    End Function



    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim paciente = CrearPaciente()
        lblMensaje.Text = db.insertPaciente(paciente)
        CargarPacientes()
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Dim paciente As New Paciente()

            paciente.IdPaciente = txtIdPaciente.Text   ' 
            paciente.Nombre = txtNombre.Text
            paciente.Apellido = txtApellido.Text
            paciente.FechaNacimiento = Date.Parse(txtFechaNacimiento.Text)
            paciente.Telefono = txtTelefono.Text
            paciente.Correo = txtCorreo.Text
            paciente.Direccion = txtDireccion.Text

            Dim db As New DatabaseHelper()
            db.updatePaciente(paciente)

            lblMensaje.Text = "Paciente actualizado correctamente."
            lblMensaje.CssClass = "text-success"

            CargarPacientes()

        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
            lblMensaje.CssClass = "text-danger"
        End Try
    End Sub


    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim id = Convert.ToInt32(gridPacientes.SelectedValue)
        lblMensaje.Text = db.deletePaciente(id)
        CargarPacientes()
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
