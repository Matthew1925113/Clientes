Imports System.Data.SqlClient

Public Class DBClientes
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("CLIENTESDBConnectionString").ConnectionString
    Public Function CreateClientes(cliente As Clientes) As String
        Try
            Dim query As String = "INSERT INTO CLIENTES (NOMBRES, APELLIDO1, APELLIDO2, EMAIL, TELEFONO) 
            VALUES (@Nombre, @Apellido1, @Apellido2, @Email, @Telefono)"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", cliente.Nombre),
                New SqlParameter("@Apellido1", cliente.Apellido),
                New SqlParameter("@Apellido2", cliente.Apellido2),
                New SqlParameter("@Email", cliente.Email),
                New SqlParameter("@Telefono", cliente.Telefono)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Cliente creado exitosamente."
        Catch ex As Exception
            Return "Error al crear el empleado: " & ex.Message
        End Try
    End Function

    Public Function EliminarCliente(id As Integer) As String

        Try
            Dim query As String = "DELETE FROM CLIENTES WHERE CLIENTESID = @Id"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Return "No se encontró el cliente con el ID especificado."
                    End If
                End Using
            End Using
            Return "Cliente eliminado exitosamente."
        Catch ex As Exception
            Return "Error al eliminar al cliente: " & ex.Message
        End Try
    End Function

    Friend Function UpdateCliente(id As String, cliente As Clientes) As String
        Try
            Dim query As String = "UPDATE CLIENTES SET NOMBRE = @Nombre, APELLIDO = @Apellidos, APELLIDO2 = @Apellido2, EMAIL = @Email, TELEFONO = @telefono WHERE CLIENTESID = @Id"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", cliente.Nombre),
                New SqlParameter("@Apellido1", cliente.Apellido),
                New SqlParameter("@Apellido2", cliente.Apellido2),
                New SqlParameter("@Email", cliente.Email),
                New SqlParameter("@Telefono", cliente.Telefono)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Cliente actualizado exitosamente."
        Catch ex As Exception
            Return "Error al actualizar el empleado: " & ex.Message
        End Try
    End Function

    Friend Function CargarCliente() As DataTable
        Try
            Dim query As String = "SELECT * FROM CLIENTES ORDER BY CLIENTESID DESC "

            Dim dt As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
            End Using
            Return dt
        Catch ex As Exception
            Throw New Exception("Error al cargar los clientes: " & ex.Message)
        End Try
    End Function
End Class
