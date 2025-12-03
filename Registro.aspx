<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="ProyectoEventos.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Usuario</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Crear Cuenta Nueva</h2>

        <asp:Label Text="Nombre de Usuario:" runat="server" />
        <asp:TextBox ID="txtUsuario" runat="server" />
        <br /><br />

        <asp:Label Text="Contraseña:" runat="server" />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
        <br /><br />

        <asp:Label Text="Nombre Completo:" runat="server" />
        <asp:TextBox ID="txtNombreCompleto" runat="server" />
        <br /><br />

        <asp:Label Text="Rol:" runat="server" />
        <asp:DropDownList ID="ddlRol" runat="server">
            <asp:ListItem Text="Usuario" Value="Usuario"></asp:ListItem>
            <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />

        <asp:Button ID="btnRegistrar" Text="Registrar Usuario" runat="server" />
        <br /><br />

        <asp:Button ID="btnVolverLogin" Text="Volver al Login" runat="server" />

        <br /><br />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

    </form>
</body>
</html>
