Imports System.Data
Imports System.Globalization
Imports Utils

Public Class FormularioCitas
    Inherits System.Web.UI.Page

    Dim dbhelper As New DatabaseHelper()
    Dim Cita As New Cita()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDoctores()
            CargarPacientes()
            CargarCitas()
        End If

        If Session("Rol") Is Nothing Then
            Response.Redirect("FormLogin.aspx")
            Exit Sub
        End If

        Dim rol As String = Session("Rol").ToString()
        If rol = "Usuario" Then
            btn_ir_doctores.Visible = False
            btnirpaciente.Visible = False
            ddl_paciente.Enabled = True
            If Session("IdUsuario") IsNot Nothing Then
                Dim val As String = Session("IdUsuario").ToString()
                If ddl_paciente.Items.FindByValue(val) IsNot Nothing Then
                    ddl_paciente.SelectedValue = val
                End If
            End If
            ddl_doctor.Enabled = True
        ElseIf rol = "Admin" Then
            btn_ir_doctores.Visible = True
            btnirpaciente.Visible = True
            ddl_doctor.Enabled = True
            ddl_paciente.Enabled = True
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

    ' Guardar cita
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            Dim cita As New Cita() With {
            .IdDoctor = ddl_doctor.SelectedValue,
            .IdPaciente = ddl_paciente.SelectedValue,
            .FechaCita = Date.Parse(txt_fechaCita.Text),
            .Motivo = txt_motivo.Text,
            .Estado = ddl_estado.SelectedValue
        }

            Dim mensaje = dbhelper.createCita(cita)

            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, mensaje)
            Else
                SwalUtils.ShowSwal(Me, "Éxito", mensaje)
                gvCitas.DataBind()
            End If

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, ex.Message)
        End Try
    End Sub

    ' Seleccionar cita
    Protected Sub gvCitas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCitas.SelectedIndexChanged
        Dim row As GridViewRow = gvCitas.SelectedRow
        Dim fecha As DateTime

        If DateTime.TryParse(row.Cells(5).Text, fecha) Then
            txt_fechaCita.Text = fecha.ToString("yyyy-MM-ddTHH:mm")
        Else
            txt_fechaCita.Text = ""
        End If

        txt_motivo.Text = row.Cells(6).Text
        ddl_estado.SelectedValue = row.Cells(7).Text

        If ddl_doctor.Items.FindByValue(row.Cells(2).Text) IsNot Nothing Then
            ddl_doctor.SelectedValue = row.Cells(2).Text
        End If
        If ddl_paciente.Items.FindByValue(row.Cells(3).Text) IsNot Nothing Then
            ddl_paciente.SelectedValue = row.Cells(3).Text
        End If

        editando.Value = gvCitas.DataKeys(row.RowIndex).Value.ToString()

    End Sub

    ' Actualizar cita
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(editando.Value) Then
                SwalUtils.ShowSwal(Me, "Atención", "Debe seleccionar una cita", "warning")
                Exit Sub
            End If

            Dim cita As New Cita() With {
            .IdCita = Convert.ToInt32(editando.Value),
            .IdDoctor = ddl_doctor.SelectedValue,
            .IdPaciente = ddl_paciente.SelectedValue,
            .FechaCita = Date.Parse(txt_fechaCita.Text),
            .Motivo = txt_motivo.Text,
            .Estado = ddl_estado.SelectedValue
        }

            Dim mensaje = dbhelper.updateCita(cita)

            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, mensaje)
            Else
                SwalUtils.ShowSwal(Me, "Actualizado", mensaje)
                gvCitas.DataBind()
            End If

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, ex.Message)
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

    Protected Sub btn_ir_doctores_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormDoctor.aspx")
    End Sub

    Protected Sub btn_ir_pacientes_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormPaciente.aspx")
    End Sub
End Class
