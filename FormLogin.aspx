<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FormLogin.aspx.vb" Inherits="ProyectoEventos.FormLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Inicio de Sesión</title>
</head>

<body>
    <form id="form1" runat="server">
        <div style="width:300px; margin:auto; padding-top:60px;">

            <h2>Inicio de Sesión</h2>

            <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label><br />
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label><br />
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox><br /><br />

            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" /><br /><br />

            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

            <asp:Button ID="btnRegistrar" runat="server" Text="Crear cuenta nueva" />


        </div>
    </form>
</body>
</html>