<%@ Page Title="Gestión de Doctores" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormDoctor.aspx.vb" Inherits="ProyectoEventos.FormDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-3">Gestión de Doctores</h2>

    <asp:TextBox ID="txt_nombre" runat="server" placeholder="Nombre" CssClass="form-control mb-2"></asp:TextBox>
    <asp:TextBox ID="txt_apellido" runat="server" placeholder="Apellido" CssClass="form-control mb-2"></asp:TextBox>
    <asp:TextBox ID="txt_especialidad" runat="server" placeholder="Especialidad" CssClass="form-control mb-2"></asp:TextBox>
    <asp:TextBox ID="txt_telefono" runat="server" placeholder="Teléfono" CssClass="form-control mb-2"></asp:TextBox>
    <asp:TextBox ID="txt_correo" runat="server" placeholder="Correo electrónico" CssClass="form-control mb-2"></asp:TextBox>
    
    <asp:DropDownList ID="ddl_estado" runat="server" CssClass="form-control mb-2">
        <asp:ListItem Text="Activo" Value="True" />
        <asp:ListItem Text="Inactivo" Value="False" />
    </asp:DropDownList>

    <div class="mb-3">
        <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-success me-2" OnClick="btn_guardar_Click" />
        <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btn_actualizar_Click" />
        <asp:Button ID="btn_ir_citas" runat="server" Text="Ir a Citas" CssClass="btn btn-info" OnClick="btn_ir_citas_Click" />
        <asp:Button ID="btn_ir_paciente" runat="server" Text="Ir a Pacientes" CssClass="btn btn-info" OnClick="btn_ir_pacientes_Click" />

    </div>
    <asp:Label ID="lbl_mensaje" runat="server" CssClass="text-info fw-bold"></asp:Label>
    <asp:GridView ID="gvDoctores" runat="server" AutoGenerateColumns="False" DataKeyNames="IdDoctor"
        CssClass="table table-bordered mt-3"
        OnRowDeleting="gvDoctores_RowDeleting"
        OnSelectedIndexChanged="gvDoctores_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-secondary btn-sm" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Eliminar" ControlStyle-CssClass="btn btn-danger btn-sm" />

            <asp:BoundField DataField="IdDoctor" HeaderText="ID" ReadOnly="True" Visible="False" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" />
            <asp:CheckBoxField DataField="Estado" HeaderText="Activo" />
        </Columns>
    </asp:GridView>
</asp:Content>
