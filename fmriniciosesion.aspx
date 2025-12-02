<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="formLogin.aspx.vb" Inherits="ProyectoEventos.formLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>Inicio de Sesión</title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <h2>Inicio de Sesión</h2>

            <asp:Label ID="lblUser" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblPass" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="txtPass" TextMode="Password" runat="server"></asp:TextBox><br />

            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />

            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
