<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Eventos.aspx.vb" Inherits="ProyectoEventos.Eventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Eventos Registrados</h2>

    <asp:GridView ID="gvEventos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Lugar" HeaderText="Lugar" />
            <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
        </Columns>
    </asp:GridView>

    <h3>Agregar Evento</h3>
    <div class="mb-2">
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
    </div>
    <div class="mb-2">
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Descripcion"></asp:TextBox>
    </div>
    <div class="mb-2">
        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" Placeholder="AAAA-MM-DD"></asp:TextBox>
    </div>
    <div class="mb-2">
        <asp:TextBox ID="txtLugar" runat="server" CssClass="form-control" Placeholder="Lugar"></asp:TextBox>
    </div>
    <div class="mb-2">
        <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control" Placeholder="Capacidad"></asp:TextBox>
    </div>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Evento" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
</asp:Content>

