<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="AdminSeguridad.Logs" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro de Auditorías</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Registro de Auditorías</h2>
        <asp:GridView ID="GridViewLogs" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Acción" HeaderText="Acción" />
                <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
