<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="AdminSeguridad.Menus" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Gestión de Menús</title>
    <style>
      /* Estilo general */
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f4f6f9;
    color: #333;
}

/* Contenedor principal */
.container {
    max-width: 1200px;
    margin: 40px auto;
    padding: 20px;
    background-color: #fff;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    border-radius: 8px;
}

/* Título */
h2 {
    font-size: 24px;
    color: #003366; 
    text-align: center;
    margin-bottom: 30px;
}

/* Contenedor de los menús */
.menu-container {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 20px;
}


.menu-item {
    display: block;
    width: 220px;
    padding: 15px;
    text-align: center;
    background-color: #003366; 
    color: white;
    font-size: 16px;
    text-decoration: none;
    border-radius: 6px;
    transition: background-color 0.3s ease, transform 0.3s ease;
}


.menu-item:hover {
    background-color: #001f4d; /* Azul aún más oscuro */
    transform: translateY(-5px);
}

/* Estilo para pantallas pequeñas */
@media (max-width: 768px) {
    .menu-item {
        width: 180px;
        font-size: 14px;
    }
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Gestión de Menús</h2>
            <div class="menu-container">
                
                <asp:Repeater ID="RepeaterMenus" runat="server">
                    <ItemTemplate>
                        <a href='<%# Eval("URL") %>' class="menu-item">
                            <%# Eval("Nombre") %>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
