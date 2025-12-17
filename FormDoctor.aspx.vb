

Imports System.Data.SqlClient
Imports Utils


Public Class FormDoctor
    Inherits System.Web.UI.Page

    Dim dbhelper As New DatabaseHelper()
    Dim doctor As New Doctor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDoctores()
        End If
    End Sub

    Private Sub CargarDoctores()
        Dim query As String = "SELECT * FROM Doctor"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString)
            Using da As New SqlDataAdapter(query, conn)
                da.Fill(dt)
            End Using
        End Using
        gvDoctores.DataSource = dt
        gvDoctores.DataBind()
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrWhiteSpace(txt_nombre.Text) OrElse
           String.IsNullOrWhiteSpace(txt_apellido.Text) OrElse
           String.IsNullOrWhiteSpace(txt_especialidad.Text) OrElse
           String.IsNullOrWhiteSpace(txt_telefono.Text) OrElse
           String.IsNullOrWhiteSpace(txt_correo.Text) Then

                SwalUtils.ShowSwal(Me, "Atención", "Todos los campos son obligatorios", "warning")
                Exit Sub
            End If

            If Not System.Text.RegularExpressions.Regex.IsMatch(txt_telefono.Text, "^\d+$") Then
                SwalUtils.ShowSwalError(Me, "El teléfono solo puede contener números")
                Exit Sub
            End If

            doctor.Nombre = txt_nombre.Text
            doctor.Apellido = txt_apellido.Text
            doctor.Especialidad = txt_especialidad.Text
            doctor.Telefono = txt_telefono.Text
            doctor.Correo = txt_correo.Text
            doctor.Estado = Convert.ToBoolean(ddl_estado.SelectedValue)

            Dim mensaje As String = dbhelper.createDoctor(doctor)

            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, mensaje)
            Else
                SwalUtils.ShowSwal(Me, "Guardado", mensaje)
                CargarDoctores()
            End If

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, ex.Message)
        End Try
    End Sub


    Protected Sub gvDoctores_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvDoctores.DataKeys(e.RowIndex).Value)
            dbhelper.deleteDoctor(id)
            CargarDoctores()
            lbl_mensaje.Text = "Doctor eliminado correctamente."
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar: " & ex.Message
        End Try
    End Sub

    Protected Sub gvDoctores_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedId As Integer = Convert.ToInt32(gvDoctores.SelectedDataKey.Value)
        Dim dt As DataTable = dbhelper.getAllDoctors()
        Dim dr() As DataRow = dt.Select("IdDoctor = " & selectedId)

        If dr.Length > 0 Then
            Dim doctorRow As DataRow = dr(0)
            txt_nombre.Text = doctorRow("Nombre").ToString()
            txt_apellido.Text = doctorRow("Apellido").ToString()
            txt_especialidad.Text = doctorRow("Especialidad").ToString()
            txt_telefono.Text = doctorRow("Telefono").ToString()
            txt_correo.Text = doctorRow("Correo").ToString()
            ddl_estado.SelectedValue = If(Convert.ToBoolean(doctorRow("Estado")), "True", "False")
            ViewState("EditandoId") = selectedId
        End If
    End Sub

    Protected Sub btn_actualizar_Click(sender As Object, e As EventArgs)
        Try
            If ViewState("EditandoId") Is Nothing Then
                SwalUtils.ShowSwal(Me, "Atención", "Debe seleccionar un doctor", "warning")
                Exit Sub
            End If

            doctor.IdDoctor = Convert.ToInt32(ViewState("EditandoId"))
            doctor.Nombre = txt_nombre.Text
            doctor.Apellido = txt_apellido.Text
            doctor.Especialidad = txt_especialidad.Text
            doctor.Telefono = txt_telefono.Text
            doctor.Correo = txt_correo.Text
            doctor.Estado = Convert.ToBoolean(ddl_estado.SelectedValue)

            Dim mensaje As String = dbhelper.updateDoctor(doctor)

            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, mensaje)
            Else
                SwalUtils.ShowSwal(Me, "Actualizado", mensaje)
                CargarDoctores()
            End If

        Catch ex As Exception
            SwalUtils.ShowSwalError(Me, ex.Message)
        End Try
    End Sub


    Protected Sub btn_ir_citas_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormularioCitas.aspx")
    End Sub

    Protected Sub btn_ir_pacientes_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormPaciente.aspx")
    End Sub

End Class