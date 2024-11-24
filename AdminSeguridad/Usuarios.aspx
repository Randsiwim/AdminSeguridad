<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="AdminSeguridad.Usuarios" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Gestión de Usuarios</title>
    <style>
       /* Estilos generales */
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f4f4f9;
}

form {
    max-width: 800px;
    margin: 20px auto;
    background-color: white;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

h2 {
    text-align: center;
    color: #003366; /* Azul más oscuro */
    margin-bottom: 20px;
}

label {
    display: block;
    margin-top: 10px;
    font-weight: bold;
    color: #555;
}

input[type="text"], input[type="email"], input[type="password"] {
    width: 100%;
    padding: 8px;
    margin: 5px 0 15px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
    font-size: 14px;
}

input[type="text"]:focus, input[type="email"]:focus, input[type="password"]:focus {
    border-color: #003366; /* Azul más oscuro */
    outline: none;
    box-shadow: 0 0 5px rgba(0, 51, 102, 0.5); /* Azul oscuro translúcido */
}

.error {
    color: red;
    font-size: 12px;
    margin-top: -10px;
}

.btn {
    display: inline-block;
    padding: 10px 20px;
    font-size: 14px;
    color: white;
    background-color: #003366; /* Azul más oscuro */
    border: none;
    border-radius: 4px;
    cursor: pointer;
    text-align: center;
    text-decoration: none;
    margin-top: 10px;
}

.btn:hover {
    background-color: #002244; 
}

table {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
}

table th, table td {
    padding: 10px;
    text-align: left;
    border: 1px solid #ddd;
}

table th {
    background-color: #003366; 
    color: white;
}

table tr:nth-child(even) {
    background-color: #f9f9f9;
}

table tr:hover {
    background-color: #f1f1f1;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Gestión de Usuarios</h2>

        <!-- Formulario para agregar usuarios -->
        <div>
            <label for="TxtUsuario">Usuario:</label>
            <asp:TextBox ID="TxtUsuario" runat="server" placeholder="Usuario"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqUsuario" runat="server" ControlToValidate="TxtUsuario" ErrorMessage="El campo Usuario es obligatorio." CssClass="error" />

            <label for="TxtRol">Rol:</label>
            <asp:TextBox ID="TxtRol" runat="server" placeholder="Rol"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqRol" runat="server" ControlToValidate="TxtRol" ErrorMessage="El campo Rol es obligatorio." CssClass="error" />

            <label for="TxtEmail">Email:</label>
            <asp:TextBox ID="TxtEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="El campo Email es obligatorio." CssClass="error" />
            <asp:RegularExpressionValidator ID="RevEmail" runat="server" ControlToValidate="TxtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Formato de Email no válido." CssClass="error" />

            <label for="TxtNombreCompleto">Nombre Completo:</label>
            <asp:TextBox ID="TxtNombreCompleto" runat="server" placeholder="Nombre Completo"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqNombreCompleto" runat="server" ControlToValidate="TxtNombreCompleto" ErrorMessage="El campo Nombre Completo es obligatorio." CssClass="error" />

            <label for="TxtClave">Clave:</label>
            <asp:TextBox ID="TxtClave" runat="server" TextMode="Password" placeholder="Clave"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqClave" runat="server" ControlToValidate="TxtClave" ErrorMessage="El campo Clave es obligatorio." CssClass="error" />

            <label for="TxtTelefono">Teléfono:</label>
<asp:TextBox ID="TxtTelefono" runat="server" placeholder="Teléfono"></asp:TextBox>
<asp:RequiredFieldValidator ID="ReqTelefono" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="El campo Teléfono es obligatorio." CssClass="error" />

<label for="TxtDireccion">Dirección:</label>
<asp:TextBox ID="TxtDireccion" runat="server" placeholder="Dirección"></asp:TextBox>
<asp:RequiredFieldValidator ID="ReqDireccion" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="El campo Dirección es obligatorio." CssClass="error" />


            <asp:Button ID="BtnGuardar" Text="Guardar" runat="server" CssClass="btn" OnClick="BtnGuardar_Click" />
        </div>

        <!-- Mensaje de error -->
        <asp:Label ID="LblError" runat="server" CssClass="error"></asp:Label>

        <!-- Tabla de usuarios -->
        <table>
            <thead>
                <tr>
                   
                </tr>
            </thead>
            <tbody>
                <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="false" OnRowCommand="GridViewUsuarios_RowCommand" DataKeyNames="UsuarioID">
                    <Columns>
                        <asp:BoundField DataField="UsuarioID" HeaderText="ID" />
                        <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="RolID" HeaderText="Rol" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" />
                        <asp:ButtonField CommandName="Editar" Text="Editar" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />

                    </Columns>
                </asp:GridView>
            </tbody>
        </table>

        <asp:HiddenField ID="HdnIDUsuario" runat="server" />
    </form>
</body>
