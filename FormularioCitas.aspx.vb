Imports System.Data

Public Class FormularioCitas
    Inherits System.Web.UI.Page

    Dim dbhelper As New DatabaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Session("Rol") Is Nothing Then
            Response.Redirect("FormLogin.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            CargarDoctores()
            CargarPacientes()
            CargarCitas()
        End If

        Dim rol As String = Session("Rol").ToString()

        If rol = "Usuario" Then
            btn_ir_doctores.Visible = False
            btnirpaciente.Visible = False

            ddl_paciente.Enabled = True
            ddl_doctor.Enabled = True

            If Session("IdUsuario") IsNot Nothing Then
                ddl_paciente.SelectedValue = Session("IdUsuario").ToString()
            End If

        ElseIf rol = "Admin" Then
            btn_ir_doctores.Visible = True
            btnirpaciente.Visible = True
        End If

    End Sub

    Private Sub CargarDoctores()
        Dim dt As DataTable = dbhelper.getAllDoctors()
        ddl_doctor.DataSource = dt
        ddl_doctor.DataTextField = "Nombre"
        ddl_doctor.DataValueField = "IdDoctor"
        ddl_doctor.DataBind()
    End Sub

    Private Sub CargarPacientes()
        Dim dt As DataTable = dbhelper.getPacientes()
        ddl_paciente.DataSource = dt
        ddl_paciente.DataTextField = "Nombre"
        ddl_paciente.DataValueField = "IdPaciente"
        ddl_paciente.DataBind()
    End Sub

    Private Sub CargarCitas()
        gvCitas.DataBind()
    End Sub

    '----- GUARDAR -----
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            Dim cita As New Cita()
            cita.IdDoctor = ddl_doctor.SelectedValue
            cita.IdPaciente = ddl_paciente.SelectedValue
            cita.FechaCita = Convert.ToDateTime(txt_fechaCita.Text)
            cita.Motivo = txt_motivo.Text
            cita.Estado = ddl_estado.SelectedValue

            lbl_mensaje.Text = dbhelper.createCita(cita)
            CargarCitas()

        Catch ex As Exception
            lbl_mensaje.Text = "Error al guardar la cita: " & ex.Message
        End Try
    End Sub

    '----- ELIMINAR -----
    Protected Sub gvCitas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvCitas.DataKeys(e.RowIndex).Value)
            dbhelper.deleteCita(id)

            e.Cancel = True
            CargarCitas()

            lbl_mensaje.Text = "Cita eliminada correctamente."

        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar la cita: " & ex.Message
        End Try
    End Sub

    '----- SELECCIONAR -----
    Protected Sub gvCitas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCitas.SelectedIndexChanged
        Dim row As GridViewRow = gvCitas.SelectedRow

        txt_fechaCita.Text = Convert.ToDateTime(row.Cells(5).Text).ToString("yyyy-MM-ddTHH:mm")
        txt_motivo.Text = row.Cells(6).Text
        ddl_estado.SelectedValue = row.Cells(7).Text

        Dim idDoctor As String = row.Cells(3).Text
        If ddl_doctor.Items.FindByValue(idDoctor) IsNot Nothing Then
            ddl_doctor.SelectedValue = idDoctor
        End If

        Dim idPaciente As String = row.Cells(4).Text
        If ddl_paciente.Items.FindByValue(idPaciente) IsNot Nothing Then
            ddl_paciente.SelectedValue = idPaciente
        End If

        editando.Value = row.Cells(2).Text
    End Sub

    '----- ACTUALIZAR -----
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim cita As New Cita()
            cita.IdCita = Convert.ToInt32(editando.Value)
            cita.IdDoctor = ddl_doctor.SelectedValue
            cita.IdPaciente = ddl_paciente.SelectedValue
            cita.FechaCita = Convert.ToDateTime(txt_fechaCita.Text)
            cita.Motivo = txt_motivo.Text
            cita.Estado = ddl_estado.SelectedValue

            dbhelper.updateCita(cita)
            CargarCitas()

        Catch ex As Exception
            lbl_mensaje.Text = "Error al actualizar la cita: " & ex.Message
        End Try
    End Sub

    ' Navegación
    Protected Sub btn_ir_doctores_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormDoctor.aspx")
    End Sub

    Protected Sub btn_ir_pacientes_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormPaciente.aspx")
    End Sub

End Class