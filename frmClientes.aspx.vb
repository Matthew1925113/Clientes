Imports Microsoft.Ajax.Utilities

Public Class frmClientes
    Inherits System.Web.UI.Page
    Protected DBClientes As New DBClientes
    Protected Sub CargarClientes()
        Dim empleados As DataTable = DBClientes.CargarCliente()
        gvDatos.DataSource = empleados
        gvDatos.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarClientes()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()
    End Sub

    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim index = gvDatos.SelectedIndex
        Dim IdEmpleado As Integer = Convert.ToInt32(gvDatos.SelectedDataKey.Value)

        If index >= 0 Then
            Dim row = gvDatos.Rows(index)
            Dim cliente As New Clientes() With {
                    .Nombre = row.Cells(2).Text,
                    .Apellido = row.Cells(3).Text,
                    .Apellido2 = row.Cells(4).Text,
                    .Email = row.Cells(5).Text,
                    .Telefono = row.Cells(6).Text
                }

            IDCliente.Value = row.Cells(1).Text
            ' Asignar los valores de las celdas a los controles del formulario
            TxtNombre.Text = cliente.Nombre
            TxtApellidos.Text = cliente.Apellido
            TxtApellido2.Text = cliente.Apellido2
            txtEmail.Text = cliente.Email
            txtTelefono.Text = cliente.Telefono
        End If
    End Sub

    Protected Sub gvDatos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(gvDatos.DataKeys(e.RowIndex).Value)
        Dim resultado As String = DBClientes.EliminarCliente(id)
        ' Mostrar el mensaje de resultado en la etiqueta LblMensaje
        LblMensaje.Text = resultado
        CargarClientes()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If IDCliente.Value.IsNullOrWhiteSpace Then
            'Agregar
            Dim cliente As New Clientes() With {
                    .Nombre = TxtNombre.Text,
                    .Apellido = TxtApellidos.Text,
                    .Apellido2 = TxtApellido2.Text,
                    .Email = txtEmail.Text,
                    .Telefono = Convert.ToInt32(txtTelefono.Text).ToString()
                }
            Dim resultado As String = DBClientes.CreateClientes(cliente)
            LblMensaje.Text = resultado
            CargarClientes()
        Else
            'Actualizar
            Dim cliente As New Clientes() With {
                    .Nombre = TxtNombre.Text,
                    .Apellido = TxtApellidos.Text,
                    .Apellido2 = TxtApellido2.Text,
                    .Email = txtEmail.Text,
                    .Telefono = Convert.ToInt32(txtTelefono.Text).ToString()
                }
            Dim resultado As String = DBClientes.UpdateCliente(IDCliente.Value, cliente)
            LblMensaje.Text = resultado
            LimpiarFormulario()
            CargarClientes()
            IDCliente.Value = " "
        End If
    End Sub

    Protected Sub LimpiarFormulario()
        TxtNombre.Text = String.Empty
        TxtApellidos.Text = String.Empty
        TxtApellido2.Text = String.Empty
        txtEmail.Text = String.Empty
        txtTelefono.Text = String.Empty
    End Sub
End Class