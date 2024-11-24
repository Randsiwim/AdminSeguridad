<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AdminSeguridad.Dashboard" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard</title>
    <style>
       /* Estilos generales */
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f4f4f9;
}

/* Estilo del header */
.header {
    background-color: #003366; 
    color: white;
    padding: 20px;
    text-align: center;
}

.header h1 {
    margin: 0;
    font-size: 24px;
}

.header nav {
    margin-top: 10px;
}

.header .nav-link {
    color: white;
    text-decoration: none;
    margin: 0 10px;
    font-weight: bold;
    transition: color 0.3s ease;
}

.header .nav-link:hover {
    color: #ffdd57;
}

/* Contenido principal */
.content {
    padding: 20px;
    max-width: 1200px;
    margin: 0 auto;
    background-color: white;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.content h2 {
    font-size: 28px;
    margin-bottom: 20px;
    color: #003366; 
}

.content h3 {
    margin-top: 40px;
    font-size: 20px;
    color: #666;
}

/* Estilo de la tabla */
.table {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
    font-size: 16px;
}

.table th,
.table td {
    border: 1px solid #ddd;
    padding: 10px;
    text-align: left;
}

.table th {
    background-color: #003366; 
    color: white;
}

.table tr:nth-child(even) {
    background-color: #f9f9f9;
}

.table tr:hover {
    background-color: #f1f1f1;
}

/* Footer */
.footer {
    text-align: center;
    padding: 10px;
    background-color: #333;
    color: white;
    font-size: 14px;
    margin-top: 20px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header de la página -->
        <div class="header">
            <h1>Administración de Seguridad</h1>
            <nav>
                <a href="Dashboard.aspx" class="nav-link">Inicio</a>
                <a href="Usuarios.aspx" class="nav-link">Usuarios</a>
                <a href="Roles.aspx" class="nav-link">Roles</a>
                <a href="Permisos.aspx" class="nav-link">Permisos</a>
                <a href="Menus.aspx" class="nav-link">Menús</a>
                <a href="Login.aspx" class="nav-link">Salir</a>
            </nav>
        </div>

        <!-- Contenido principal -->
        <div class="content">
            <h2>Bienvenido al Dashboard</h2>
            <asp:Label ID="LblBienvenida" runat="server" Text="Hola, Admin!" />

            
        </div>

        <!-- Footer -->
        <div class="footer">
            <p>© 2024 Administración de Seguridad. Todos los derechos reservados.</p>
        </div>
    </form>
</body>
</html>
