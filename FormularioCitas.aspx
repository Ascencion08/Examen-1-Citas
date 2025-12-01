<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="FormularioCitas.aspx.vb" Inherits="ProyectoEventos.FormularioCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="editando" runat="server" />

    <asp:DropDownList ID="ddl_doctor" runat="server" />
    <asp:DropDownList ID="ddl_paciente" runat="server" />

    <asp:TextBox ID="txt_fechaCita" runat="server" 
                 TextMode="DateTimeLocal" 
                 placeholder="Fecha y hora de la cita" />

    <asp:TextBox ID="txt_motivo" runat="server" 
                 placeholder="Motivo de la cita" />

    <asp:DropDownList ID="ddl_estado" runat="server">
        <asp:ListItem Text="Pendiente" Value="Pendiente" />
        <asp:ListItem Text="Completada" Value="Completada" />
        <asp:ListItem Text="Cancelada" Value="Cancelada" />
    </asp:DropDownList>

    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" 
                OnClick="btn_guardar_Click" />

    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                OnClick="btnActualizar_Click" />

    <asp:Button ID="btn_ir_doctores" runat="server" Text="Ir a Doctores" 
                CssClass="btn btn-info" 
                OnClick="btn_ir_doctores_Click" />

    <asp:Label ID="lbl_mensaje" runat="server" />

    <asp:GridView ID="gvCitas" runat="server"
                  AutoGenerateColumns="False"
                  DataKeyNames="IdCita"
                  DataSourceID="SqlDataSourceCitas"
                  OnRowDeleting="gvCitas_RowDeleting"
                  OnRowEditing="gvCitas_RowEditing"
                  OnRowCancelingEdit="gvCitas_RowCancelingEdit"
                  OnRowUpdating="gvCitas_RowUpdating"
                  OnSelectedIndexChanged="gvCitas_SelectedIndexChanged">

        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowEditButton="True" />

            <asp:BoundField DataField="IdCita" HeaderText="ID" 
                            ReadOnly="True" Visible="false" />

            <asp:BoundField DataField="IdDoctor" HeaderText="Doctor" />
            <asp:BoundField DataField="IdPaciente" HeaderText="Paciente" />

            <asp:BoundField DataField="FechaCita" HeaderText="Fecha Cita" 
                            DataFormatString="{0:dd/MM/yyyy HH:mm}" />

            <asp:BoundField DataField="Motivo" HeaderText="Motivo" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
        </Columns>

    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSourceCitas" runat="server"
                       ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
                       SelectCommand="SELECT * FROM Cita">
    </asp:SqlDataSource>

</asp:Content>
