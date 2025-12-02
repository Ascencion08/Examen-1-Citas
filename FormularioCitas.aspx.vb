Imports System.Data

Public Class FormularioCitas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDoctores()
            CargarPacientes()
            CargarCitas()
        End If
    End Sub

    Private Sub CargarDoctores()
        Dim dt As DataTable = dbhelper.getAllDoctors()
        ddl_doctor.DataSource = dt
        ddl_doctor.DataTextField = "Nombre"    ' lo que ve el usuario
        ddl_doctor.DataValueField = "IdDoctor" ' lo que se envía (NUMERO)
        ddl_doctor.DataBind()
    End Sub

    Private Sub CargarPacientes()
        Dim dt As DataTable = dbhelper.getPacientes()
        ddl_paciente.DataSource = dt
        ddl_paciente.DataTextField = "Nombre"
        ddl_paciente.DataValueField = "IdPaciente" ' ESTE ES EL QUE EVITA EL ERROR
        ddl_paciente.DataBind()
    End Sub

    Private Sub CargarCitas()
        gvCitas.DataBind()
    End Sub

    Dim dbhelper As New DatabaseHelper()
    Dim Cita As New Cita()

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            Dim cita As New Cita()
            cita.IdDoctor = Convert.ToInt32(ddl_doctor.SelectedValue)
            cita.IdPaciente = Convert.ToInt32(ddl_paciente.SelectedValue)
            cita.FechaCita = Convert.ToDateTime(txt_fechaCita.Text)
            cita.Motivo = txt_motivo.Text
            cita.Estado = ddl_estado.SelectedValue

            lbl_mensaje.Text = dbhelper.createCita(cita)
            gvCitas.DataBind()

        Catch ex As Exception
            lbl_mensaje.Text = "Error al guardar la cita: " & ex.Message
        End Try
    End Sub

    Protected Sub gvCitas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvCitas.DataKeys(e.RowIndex).Value)
            dbhelper.deleteCita(id)

            e.Cancel = True
            gvCitas.DataBind()

            lbl_mensaje.Text = "Cita eliminada correctamente."

        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar la cita: " & ex.Message
        End Try
    End Sub

    Protected Sub gvCitas_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvCitas.EditIndex = e.NewEditIndex
        gvCitas.DataBind()
    End Sub

    Protected Sub gvCitas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvCitas.EditIndex = -1
        gvCitas.DataBind()
    End Sub

    Protected Sub gvCitas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvCitas.DataKeys(e.RowIndex).Value)

            Dim cita As New Cita() With {
                .IdCita = id,
                .IdDoctor = Convert.ToInt32(e.NewValues("IdDoctor")),
                .IdPaciente = Convert.ToInt32(e.NewValues("IdPaciente")),
                .FechaCita = Convert.ToDateTime(e.NewValues("FechaCita")),
                .Motivo = e.NewValues("Motivo").ToString(),
                .Estado = e.NewValues("Estado").ToString()
            }

            dbhelper.updateCita(cita)
            gvCitas.EditIndex = -1
            gvCitas.DataBind()

        Catch ex As Exception
            lbl_mensaje.Text = "Error al actualizar la cita: " & ex.Message
        End Try
    End Sub

    Protected Sub gvCitas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCitas.SelectedIndexChanged
        Dim row As GridViewRow = gvCitas.SelectedRow
        Dim id As Integer = Convert.ToInt32(gvCitas.DataKeys(row.RowIndex).Value)
        txt_fechaCita.Text = row.Cells(3).Text
        txt_motivo.Text = row.Cells(4).Text
        ddl_estado.SelectedValue = row.Cells(5).Text
        editando.Value = id
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim cita As New Cita() With {
                .IdCita = Convert.ToInt32(editando.Value),
                .IdDoctor = Convert.ToInt32(ddl_doctor.SelectedValue),
                .IdPaciente = Convert.ToInt32(ddl_paciente.SelectedValue),
                .FechaCita = Convert.ToDateTime(txt_fechaCita.Text),
                .Motivo = txt_motivo.Text,
                .Estado = ddl_estado.SelectedValue
            }

            dbhelper.updateCita(cita)
            gvCitas.DataBind()
            gvCitas.EditIndex = -1

        Catch ex As Exception
            lbl_mensaje.Text = "Error al actualizar la cita: " & ex.Message
        End Try
    End Sub

    Protected Sub btn_ir_doctores_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormDoctor.aspx")
    End Sub

    Protected Sub btn_ir_pacientes_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormPaciente.aspx")
    End Sub

End Class

