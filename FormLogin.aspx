<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FormLogin.aspx.vb" Inherits="ProyectoEventos.FormLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Iniciar Sesión</h2>

            <div class="mb-3">
                <label class="form-label">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div class="d-flex gap-2">
                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" CssClass="btn btn-secondary" OnClick="btnRegistro_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 text-danger"></asp:Label>
        </div>
    </form>
</body>
</html>
