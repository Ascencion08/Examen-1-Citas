Public Class Doctor


    Private _IdDoctor As Integer
    Private _Nombre As String
    Private _Apellido As String
    Private _Especialidad As String
    Private _Telefono As String
    Private _Correo As String
    Private _Estado As Boolean


    Public Sub New()
    End Sub

    Public Sub New(idDoctor As Integer, nombre As String, apellido As String, especialidad As String, telefono As String, correo As String, estado As Boolean)
        Me.IdDoctor = idDoctor
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Especialidad = especialidad
        Me.Telefono = telefono
        Me.Correo = correo
        Me.Estado = estado
    End Sub

    Public Property IdDoctor As Integer
        Get
            Return _IdDoctor
        End Get
        Set(value As Integer)
            _IdDoctor = value
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

    Public Property Especialidad As String
        Get
            Return _Especialidad
        End Get
        Set(value As String)
            _Especialidad = value
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

    Public Property Estado As Boolean
        Get
            Return _Estado
        End Get
        Set(value As Boolean)
            _Estado = value
        End Set
    End Property
End Class
