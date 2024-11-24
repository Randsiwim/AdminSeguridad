<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actividades.aspx.cs" Inherits="AdminSeguridad.Actividades" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Actividades</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Gestión de Actividades</h2>
        <asp:GridView ID="GridViewActividades" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </form>
</body>
</html>

