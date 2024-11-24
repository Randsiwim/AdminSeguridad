<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permisos.aspx.cs" Inherits="AdminSeguridad.Permisos" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>Gestión de Permisos</title>
   <style>
    /* Estilo general */
    body {
        font-family: Arial, sans-serif;
        margin: 0;
        padding: 0;
        background-color: #f4f4f9;
        color: #333;
    }

    .container {
        max-width: 1200px;
        margin: 0 auto;
        padding: 20px;
    }

    .page-title {
        text-align: center;
        font-size: 2.5rem;
        color: #003366; 
        margin-bottom: 20px;
    }

    .message {
        display: block;
        margin: 10px 0;
        font-size: 1rem;
        color: #003366; 
        text-align: center;
    }

    /* Botones */
    .btn {
        padding: 10px 20px;
        font-size: 1rem;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        text-decoration: none;
    }

    .btn-primary {
        background-color: #003366; 
        color: white;
    }

    .btn-primary:hover {
        background-color: #002244; 
    }

    .btn-success {
        background-color: #28a745;
        color: white;
    }

    .btn-success:hover {
        background-color: #218838;
    }

    .btn-secondary {
        background-color: #6c757d;
        color: white;
    }

    .btn-secondary:hover {
        background-color: #5a6268;
    }

    /* Tabla */
    .table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
        background-color: white;
        border-radius: 5px;
        overflow: hidden;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    .table th, .table td {
        padding: 12px 15px;
        text-align: left;
    }

    .table th {
        background-color: #003366; 
        color: white;
    }

    .table tr:nth-child(even) {
        background-color: #f3f3f3;
    }

    .table tr:hover {
        background-color: #e0f7fa;
    }

    
    .modal {
        display: none;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.4);
        justify-content: center;
        align-items: center;
    }

    .modal-content {
        background-color: white;
        padding: 20px;
        border-radius: 10px;
        max-width: 400px;
        box-shadow: 0 5px 15px rgba(0, 0, 0, 0.3);
        text-align: center;
    }

    .label {
        display: block;
        margin-bottom: 5px;
        font-weight: bold;
    }

    .input {
        width: 100%;
        padding: 10px;
        margin-bottom: 20px;
        font-size: 1rem;
        border: 1px solid #ccc;
        border-radius: 5px;
    }

    .input:focus {
        border-color: #003366; 
        outline: none;
        box-shadow: 0 0 5px rgba(0, 51, 102, 0.5); 
    }

    .modal-buttons {
        display: flex;
        justify-content: space-between;
    }
</style>

    <script>
        function showModal() {
            document.getElementById('modalForm').style.display = 'flex';
        }

        function hideModal() {
            document.getElementById('modalForm').style.display = 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="page-title">Gestión de Permisos</h1>

            <!-- Mensajes de error/éxito -->
            <asp:Label ID="lblMensaje" runat="server" CssClass="message"></asp:Label>

            <!-- Botón para crear un nuevo permiso -->
            <button type="button" class="btn btn-primary" onclick="showModal()">Crear Nuevo Permiso</button>

            <!-- GridView para mostrar los permisos -->
            <asp:GridView ID="GridViewPermisos" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewPermisos_RowCommand" DataKeyNames="ID" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Permiso" />
                    <asp:ButtonField CommandName="Editar" Text="Editar" ButtonType="Button" />
                    <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" />
                </Columns>
            </asp:GridView>

            <!-- Modal para crear/editar permisos -->
            <div id="modalForm" class="modal">
                <div class="modal-content">
                    <h3>Formulario de Permisos</h3>
                    <asp:HiddenField ID="HiddenFieldPermisoID" runat="server" />
                    <asp:Label Text="Nombre del Permiso:" AssociatedControlID="txtNombrePermiso" runat="server" CssClass="label" />
                    <asp:TextBox ID="txtNombrePermiso" runat="server" CssClass="input" />

                    <!-- Botones de acción -->
                    <div class="modal-buttons">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
                        <button type="button" class="btn btn-secondary" onclick="hideModal()">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

