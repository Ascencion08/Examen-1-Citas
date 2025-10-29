Public Class Paciente

    Private _IdPaciente As Integer
    Private _Nombre As String
    Private _Apellido As String
    Private _FechaNacimiento As Date
    Private _Telefono As String
    Private _Correo As String
    Private _Direccion As String

    Public Sub New()
    End Sub

    Public Sub New(idPaciente As Integer, nombre As String, apellido As String, fechaNacimiento As Date, telefono As String, correo As String, direccion As String)
        Me.IdPaciente = idPaciente
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.FechaNacimiento = fechaNacimiento
        Me.Telefono = telefono
        Me.Correo = correo
        Me.Direccion = direccion
    End Sub

    Public Property IdPaciente As Integer
        Get
            Return _IdPaciente
        End Get
        Set(value As Integer)
            _IdPaciente = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return _Apellido
        End Get
        Set(value As String)
            _Apellido = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
        Set(value As Date)
            _FechaNacimiento = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            _Correo = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property
End Class
