<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdminSeguridad.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Iniciar Sesión</title>
    <style>
       /* Estilos generales */
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f2f2f2;
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
}

/* Contenedor de la caja de login */
.login-container {
    width: 100%;
    max-width: 400px;
    padding: 40px;
    background-color: white;
    border-radius: 8px;
    box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1);
    text-align: center;
}

/* Título */
.login-container h2 {
    font-size: 28px;
    color: #333;
    margin-bottom: 20px;
}

/* Campos de texto */
.login-input {
    width: 100%;
    padding: 12px;
    margin: 10px 0;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
    box-sizing: border-box;
}

/* Estilo para el botón de inicio de sesión */
.login-input[type="submit"] {
    background-color: #003366; 
    color: white;
    border: none;
    cursor: pointer;
    font-weight: bold;
    transition: background-color 0.3s ease;
}

/* Hover del botón de inicio de sesión */
.login-input[type="submit"]:hover {
    background-color: #002244; 
}

/* Estilo para el mensaje de error */
.error-message {
    color: red;
    margin-top: 15px;
    font-size: 14px;
}

/* Responsividad para dispositivos móviles */
@media (max-width: 600px) {
    .login-container {
        padding: 20px;
    }
    .login-container h2 {
        font-size: 24px;
    }
    .login-input {
        padding: 10px;
    }
}



    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            
            <!-- Campo para el usuario -->
            <label for="txtUsuario">Usuario:</label>
            <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario" CssClass="login-input" required="required" />
            
            <!-- Campo para la contraseña -->
            <label for="txtContrasena">Contraseña:</label>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="login-input" required="required" />
            
            <!-- Botón de inicio de sesión -->
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" CssClass="login-input" />
            
            <!-- Mensaje de error -->
            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>


        </div>
    </form>
</body>
   


</html>
