Public Class Cita
    Public Sub New(idCita As Integer, idDoctor As Integer, idPaciente As Integer, fechaCita As Date, motivo As String, estado As String)
        Me.IdCita = idCita
        Me.IdDoctor = idDoctor
        Me.IdPaciente = idPaciente
        Me.FechaCita = fechaCita
        Me.Motivo = motivo
        Me.Estado = estado
    End Sub

    Public Sub New()
    End Sub

    Private _IdCita As Integer
    Private _IdDoctor As Integer
    Private _IdPaciente As Integer
    Private _FechaCita As Date
    Private _Motivo As String
    Private _Estado As String

    Public Property IdCita As Integer
        Get
            Return _IdCita
        End Get
        Set(value As Integer)
            _IdCita = value
        End Set
    End Property

    Public Property IdDoctor As Integer
        Get
            Return _IdDoctor
        End Get
        Set(value As Integer)
            _IdDoctor = value
        End Set
    End Property

    Public Property IdPaciente As Integer
        Get
            Return _IdPaciente
        End Get
        Set(value As Integer)
            _IdPaciente = value
        End Set
    End Property

    Public Property FechaCita As Date
        Get
            Return _FechaCita
        End Get
        Set(value As Date)
            _FechaCita = value
        End Set
    End Property

    Public Property Motivo As String
        Get
            Return _Motivo
        End Get
        Set(value As String)
            _Motivo = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property
End Class
