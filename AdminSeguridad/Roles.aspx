<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="AdminSeguridad.Roles" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>Gestión de Roles</title>
    <style>
        /* Estilos internos para la página */
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f4f7fc;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 900px;
            margin: 40px auto;
            padding: 20px;
            background: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .page-title {
            text-align: center;
            font-size: 28px;
            color: #333;
            margin-bottom: 20px;
        }

        .message {
            margin: 10px 0;
            padding: 10px;
            border-radius: 5px;
        }

        .message-success {
            background-color: #d4edda;
            color: #155724;
        }

        .message-error {
            background-color: #f8d7da;
            color: #721c24;
        }

        .actions {
            text-align: right;
            margin-bottom: 20px;
        }

        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
        }

        .btn-primary {
            background-color: #007bff;
            color: white;
        }

        .btn-success {
            background-color: #28a745;
            color: white;
        }

        .btn-secondary {
            background-color: #6c757d;
            color: white;
        }

        /* Estilos para el GridView */
        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table th, .table td {
            padding: 12px;
            border: 1px solid #ddd;
            text-align: center;
        }

        .table th {
            background-color: #007bff;
            color: white;
        }

        /* Estilos para el Modal */
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            display: flex;
            justify-content: center;
            align-items: center;
            z-index: 1000;
        }

        .modal-content {
            background-color: #fff;
            padding: 20px;
            width: 400px;
            border-radius: 8px;
            text-align: center;
        }

        .modal-buttons {
            margin-top: 20px;
        }

        .label {
            font-size: 16px;
            color: #333;
        }

        .input {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 14px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Contenedor principal -->
        <div class="container">
            <h1 class="page-title">Gestión de Roles</h1>

            <!-- Mensajes de éxito o error -->
            <asp:Label ID="lblMensaje" runat="server" CssClass="message"></asp:Label>

           <div class="actions">
    <asp:Button ID="btnNuevoRol" runat="server" Text="Crear Nuevo Rol" OnClick="btnNuevoRol_Click" CssClass="btn btn-primary" />
</div>


            <!-- GridView para mostrar los roles -->
            <asp:GridView ID="GridViewRoles" runat="server" AutoGenerateColumns="False" DataKeyNames="RolID" CssClass="table" OnRowCommand="GridViewRoles_RowCommand">
                <Columns>
                    <asp:BoundField DataField="RolID" HeaderText="ID" SortExpression="RolID" />
                    <asp:BoundField DataField="NombreRol" HeaderText="Nombre del Rol" SortExpression="NombreRol" />
                    <asp:ButtonField CommandName="Editar" Text="Editar" ButtonType="Button" HeaderText="Acciones" />
                    <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" />
                </Columns>
            </asp:GridView>

            <!-- Panel de formulario para crear/editar un rol -->
            <asp:Panel ID="PanelForm" runat="server" Visible="false" CssClass="modal">
                <div class="modal-content">
                    <h3>Formulario de Roles</h3>
                    <asp:HiddenField ID="HiddenFieldRolID" runat="server" />
                    <div class="form-group">
                        <asp:Label Text="Nombre del Rol:" AssociatedControlID="txtNombreRol" runat="server" CssClass="label" />
                        <asp:TextBox ID="txtNombreRol" runat="server" CssClass="input" />
                    </div>

                    <div class="modal-buttons">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />

                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>

    <script>
        // Funciones de JavaScript si son necesarias
    </script>
</body>
</html>