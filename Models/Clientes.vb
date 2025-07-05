Public Class Clientes
    Protected _ClienteId As Integer
    Protected _Nombre As String
    Protected _Apellido As String
    Protected _Apellido2 As String
    Protected _Email As String
    Protected _Telefono As String

    Public Sub New()
        ClienteId = 0
        Nombre = String.Empty
        Apellido = String.Empty
        Apellido2 = String.Empty
        Email = String.Empty
        Telefono = String.Empty
    End Sub

    Public Sub New(clienteId As Integer, nombre As String, apellido As String, apellido2 As String, email As String, telefono As String)
        Me.ClienteId = clienteId
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Apellido2 = apellido2
        Me.Email = email
        Me.Telefono = telefono
    End Sub

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

    Public Property Apellido As String
        Get
            Return _Apellido
        End Get
        Set(value As String)
            _Apellido = value
        End Set
    End Property

    Public Property Apellido2 As String
        Get
            Return _Apellido2
        End Get
        Set(value As String)
            _Apellido2 = value
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
