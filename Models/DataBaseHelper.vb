Imports System.Data.SqlClient
Imports System.Configuration

Public Class DatabaseHelper
    Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Public Function createCita(cita As Cita) As String
        Try
            Dim sql As String = "INSERT INTO Cita (IdDoctor, IdPaciente, FechaCita, Motivo, Estado)
                                 VALUES (@IdDoctor, @IdPaciente, @FechaCita, @Motivo, @Estado)"

            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@IdDoctor", cita.IdDoctor)
                    command.Parameters.AddWithValue("@IdPaciente", cita.IdPaciente)
                    command.Parameters.AddWithValue("@FechaCita", cita.FechaCita)
                    command.Parameters.AddWithValue("@Motivo", cita.Motivo)
                    command.Parameters.AddWithValue("@Estado", cita.Estado)

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "Cita registrada correctamente."
        Catch ex As Exception
            Return " Error al registrar la cita: " & ex.Message
        End Try
    End Function

    Public Function updateCita(cita As Cita) As String
        Try
            Dim sql As String = "UPDATE Cita SET 
                                    IdDoctor = @IdDoctor, 
                                    IdPaciente = @IdPaciente, 
                                    FechaCita = @FechaCita, 
                                    Motivo = @Motivo, 
                                    Estado = @Estado
                                 WHERE IdCita = @IdCita"

            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@IdCita", cita.IdCita)
                    command.Parameters.AddWithValue("@IdDoctor", cita.IdDoctor)
                    command.Parameters.AddWithValue("@IdPaciente", cita.IdPaciente)
                    command.Parameters.AddWithValue("@FechaCita", cita.FechaCita)
                    command.Parameters.AddWithValue("@Motivo", cita.Motivo)
                    command.Parameters.AddWithValue("@Estado", cita.Estado)

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "✅ Cita actualizada correctamente."
        Catch ex As Exception
            Return "❌ Error al actualizar la cita: " & ex.Message
        End Try
    End Function

    Public Function deleteCita(idCita As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Cita WHERE IdCita = @IdCita"

            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@IdCita", idCita)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "🗑️ Cita eliminada correctamente."
        Catch ex As Exception
            Return "❌ Error al eliminar la cita: " & ex.Message
        End Try
    End Function


    Public Function createDoctor(doctor As Doctor) As String
        Try
            Using conn As New SqlConnection(ConnectionString)
                Dim sql As String = "INSERT INTO Doctor (Nombre, Apellido, Especialidad, Telefono, Correo, Estado)
                                     VALUES (@Nombre, @Apellido, @Especialidad, @Telefono, @Correo, @Estado)"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Nombre", doctor.Nombre)
                    cmd.Parameters.AddWithValue("@Apellido", doctor.Apellido)
                    cmd.Parameters.AddWithValue("@Especialidad", doctor.Especialidad)
                    cmd.Parameters.AddWithValue("@Telefono", doctor.Telefono)
                    cmd.Parameters.AddWithValue("@Correo", doctor.Correo)
                    cmd.Parameters.AddWithValue("@Estado", doctor.Estado)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return "Doctor guardado correctamente."
        Catch ex As Exception
            Return "Error al guardar el doctor: " & ex.Message
        End Try
    End Function


    Public Function updateDoctor(doctor As Doctor) As String
        Try
            Using conn As New SqlConnection(ConnectionString)
                Dim sql As String = "UPDATE Doctor SET Nombre = @Nombre, Apellido = @Apellido,
                                     Especialidad = @Especialidad, Telefono = @Telefono,
                                     Correo = @Correo, Estado = @Estado
                                     WHERE IdDoctor = @IdDoctor"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@IdDoctor", doctor.IdDoctor)
                    cmd.Parameters.AddWithValue("@Nombre", doctor.Nombre)
                    cmd.Parameters.AddWithValue("@Apellido", doctor.Apellido)
                    cmd.Parameters.AddWithValue("@Especialidad", doctor.Especialidad)
                    cmd.Parameters.AddWithValue("@Telefono", doctor.Telefono)
                    cmd.Parameters.AddWithValue("@Correo", doctor.Correo)
                    cmd.Parameters.AddWithValue("@Estado", doctor.Estado)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return "Doctor actualizado correctamente."
        Catch ex As Exception
            Return " Error al actualizar el doctor: " & ex.Message
        End Try
    End Function

    ' ELIMINAR DOCTOR
    Public Function deleteDoctor(idDoctor As Integer) As String
        Try
            Using conn As New SqlConnection(ConnectionString)
                Dim sql As String = "DELETE FROM Doctor WHERE IdDoctor = @IdDoctor"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@IdDoctor", idDoctor)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return " Doctor eliminado correctamente."
        Catch ex As Exception
            Return "Error al eliminar el doctor: " & ex.Message
        End Try
    End Function

    Public Function getAllDoctors() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As New SqlConnection(ConnectionString)
                Dim sql As String = "SELECT * FROM Doctor"
                Using da As New SqlDataAdapter(sql, conn)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener los doctores: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function getPacientes() As DataTable
        Dim query As String = "SELECT * FROM Paciente"
        Dim dt As New DataTable()

        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        Return dt
    End Function


    Public Function insertPaciente(p As Paciente) As String
        Dim query As String =
        "INSERT INTO Paciente (IdPaciente, Nombre, Apellido, FechaNacimiento, Telefono, Correo, Direccion)
         VALUES (@IdPaciente, @Nombre, @Apellido, @FechaNacimiento, @Telefono, @Correo, @Direccion)"

        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@IdPaciente", p.IdPaciente)
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre)
                cmd.Parameters.AddWithValue("@Apellido", p.Apellido)
                cmd.Parameters.AddWithValue("@FechaNacimiento", p.FechaNacimiento)
                cmd.Parameters.AddWithValue("@Telefono", p.Telefono)
                cmd.Parameters.AddWithValue("@Correo", p.Correo)
                cmd.Parameters.AddWithValue("@Direccion", p.Direccion)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        Return "Paciente registrado correctamente."
    End Function


    Public Function updatePaciente(p As Paciente) As String
        Dim query As String =
        "UPDATE Paciente SET 
            Nombre=@Nombre, 
            Apellido=@Apellido, 
            FechaNacimiento=@FechaNacimiento,
            Telefono=@Telefono, 
            Correo=@Correo, 
            Direccion=@Direccion
         WHERE IdPaciente=@IdPaciente"

        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre)
                cmd.Parameters.AddWithValue("@Apellido", p.Apellido)
                cmd.Parameters.AddWithValue("@FechaNacimiento", p.FechaNacimiento)
                cmd.Parameters.AddWithValue("@Telefono", p.Telefono)
                cmd.Parameters.AddWithValue("@Correo", p.Correo)
                cmd.Parameters.AddWithValue("@Direccion", p.Direccion)
                cmd.Parameters.AddWithValue("@IdPaciente", p.IdPaciente)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        Return "Paciente actualizado correctamente."
    End Function


    Public Function deletePaciente(idPaciente As String) As String
        Dim query As String = "DELETE FROM Paciente WHERE IdPaciente=@IdPaciente"

        Using conn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        Return "Paciente eliminado correctamente."
    End Function

    Public Function ValidarUsuario(nombreUsuario As String, contrasena As String) As UsuarioLogin
        Dim usuarioEncontrado As UsuarioLogin = Nothing

        Try
            ' 
            Dim query As String = "SELECT IdUsuario, NombreUsuario, Rol, NombreCompleto FROM UsuarioLogin WHERE NombreUsuario = @User AND Contrasena = @Pass"

            Using conn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@User", nombreUsuario)
                    cmd.Parameters.AddWithValue("@Pass", contrasena)

                    conn.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Si se encuentra el usuario, poblamos el objeto UsuarioLogin
                            usuarioEncontrado = New UsuarioLogin()
                            usuarioEncontrado.IdUsuario = reader.GetInt32(0)
                            usuarioEncontrado.NombreUsuario = reader.GetString(1)
                            usuarioEncontrado.Rol = reader.GetString(2)
                            ' Manejamos el caso de que NombreCompleto sea DBNull
                            usuarioEncontrado.NombreCompleto = If(reader.IsDBNull(3), "", reader.GetString(3))
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Error al validar credenciales en la DB: " & ex.Message)
        End Try

        Return usuarioEncontrado ' Retorna el objeto o Nothing si no se encontró
    End Function
End Class