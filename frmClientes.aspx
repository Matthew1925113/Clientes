<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmClientes.aspx.vb" Inherits="Clientes.frmClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <div class="row mb-3">
        <div class="col-md-4">

            <div class="form-group mb-3">
                <label for="TxtNombre">Nombre</label>
                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="form-group mb-3">
                <label for="TxtApellido">Apellido</label>
                <asp:TextBox ID="TxtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label for="TxtApellido">Apellido</label>
                <asp:TextBox ID="TxtApellido2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


            <div class="form-group mb-3">
                <label for="txtEmail">Puestos</label>
                <asp:TextBox TextMode ="Email" ID="txtEmail" runat="server"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label for="txtTelefono">Sueldo</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>

            <div class="form-group md-4">
                <asp:Button ID="btnCancelar" CssClass="btn btn-secundary" runat="server" Text="Canselar" OnClick="btnCancelar_Click" />
            </div>
        </div>
        
        <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
    </div>
    <asp:GridView ID="gvDatos" runat="server" DataSourceID="SqlDataSource2" 
        OnSelectedIndexChanged ="gvDatos_SelectedIndexChanged"
        OnRowDeleting ="gvDatos_RowDeleting"
        AllowPaging ="true" AutoGenerateColumns="False" DataKeyNames="CLIENTESID" Width="794px">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="CLIENTESID" HeaderText="CLIENTESID" InsertVisible="False" ReadOnly="True" SortExpression="CLIENTESID" />
            <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" SortExpression="NOMBRES" />
            <asp:BoundField DataField="APELLIDO1" HeaderText="APELLIDO1" SortExpression="APELLIDO1" />
            <asp:BoundField DataField="APELLIDO2" HeaderText="APELLIDO2" SortExpression="APELLIDO2" />
            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" SortExpression="TELEFONO" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CLIENTESDBConnectionString %>" ProviderName="<%$ ConnectionStrings:CLIENTESDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [CLIENTES]"></asp:SqlDataSource>






</asp:Content>
