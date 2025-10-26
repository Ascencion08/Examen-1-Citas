Imports System.Data
Imports System.Data.SqlClient

Public Class Eventos
    Inherits System.Web.UI.Page

    Private dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarEventos()
        End If
    End Sub


    Private Sub CargarEventos()
        Dim sql As String = "SELECT * FROM Eventos"
        Dim dt As DataTable = dbHelper.EjecutarConsulta(sql)
        gvEventos.DataSource = dt
        gvEventos.DataBind()
    End Sub


    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs)

        If txtNombre.Text = "" Or txtDescripcion.Text = "" Or txtFecha.Text = "" Or txtLugar.Text = "" Or txtCapacidad.Text = "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Todos los campos son obligatorios');", True)
            Return
        End If

        Dim sql As String = "INSERT INTO Eventos (Nombre, Descripcion, Fecha, Lugar, Capacidad) VALUES (@Nombre, @Descripcion, @Fecha, @Lugar, @Capacidad)"
        Dim parametros() As SqlParameter = {
            New SqlParameter("@Nombre", txtNombre.Text),
            New SqlParameter("@Descripcion", txtDescripcion.Text),
            New SqlParameter("@Fecha", txtFecha.Text),
            New SqlParameter("@Lugar", txtLugar.Text),
            New SqlParameter("@Capacidad", Convert.ToInt32(txtCapacidad.Text))
        }

        Dim filasAfectadas As Integer = dbHelper.EjecutarComando(sql, parametros)

        If filasAfectadas > 0 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Evento agregado correctamente');", True)
            LimpiarCampos()
            CargarEventos()
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error al agregar el evento');", True)
        End If
    End Sub


    Private Sub LimpiarCampos()
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtFecha.Text = ""
        txtLugar.Text = ""
        txtCapacidad.Text = ""
    End Sub
End Class

