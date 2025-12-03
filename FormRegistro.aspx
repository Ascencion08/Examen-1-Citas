<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FormRegistro.aspx.vb" Inherits="ProyectoEventos.FormRegistro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Usuario</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Registro de Usuario</h2>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre Completo</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtContrasena" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ddlRol" class="form-label">Rol</label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Usuario" Value="Usuario" />
                    <asp:ListItem Text="Admin" Value="Admin" />
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-success" OnClick="btnRegistrar_Click" />
            <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 text-danger"></asp:Label>

            <div class="mt-3">
                <a href="FormLogin.aspx">Volver al Login</a>
            </div>
        </div>
    </form>
</body>
</html>


