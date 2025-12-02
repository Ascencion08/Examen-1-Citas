<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="fmrLogin.aspx.vb" Inherits="ProyectoEventos.fmrLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>🔑 Inicio de Sesión</h2>
    
    <asp:Label ID="lblUsuario" runat="server" Text="Nombre de Usuario:"></asp:Label><br />
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox><br /><br />
    
    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label><br />
    <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox><br /><br />
    
    <asp:Button ID="BtnLogin" runat="server" Text="Entrar" OnClick="BtnLogin_Click" /><br /><br />
    
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
</asp:Content> 