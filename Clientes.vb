Public Class Clientes
    Protected _ClienteId As Integer
    Protected _Nombre As String
    Protected _Apellidos As String
    Protected _Email As String
    Protected _Telefono As String

    Public Sub New()
        _ClienteId = 0
        _Nombre = String.Empty
        _Apellidos = String.Empty
        _Email = String.Empty
        _Telefono = String.Empty
    End Sub

    Public Sub New(clienteId As Integer, nombre As String, apellidos As String, email As String, telefono As String)
        Me.ClienteId = clienteId
        Me.Nombre = nombre
        Me.Apellidos = apellidos
        Me.Email = email
        Me.Telefono = telefono
    End Sub

    Public Function NombreCompleto() As String
        Return $"{_Nombre} {_Apellidos}"
    End Function

    Public Property ClienteId As Integer
        Get
            Return _ClienteId
        End Get
        Set(value As Integer)
            _ClienteId = value
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

    Public Property Apellidos As String
        Get
            Return _Apellidos
        End Get
        Set(value As String)
            _Apellidos = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
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
End Class
