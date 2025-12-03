<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="FormularioCitas.aspx.vb" Inherits="ProyectoEventos.FormularioCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2 class="text-center mb-4">Gestión de Citas</h2>

        <asp:HiddenField ID="editando" runat="server" />

        <div class="card shadow-sm p-4 mb-4">
            <div class="row g-3">

                <div class="col-md-6">
                    <label class="form-label fw-bold">Doctor</label>
                    <asp:DropDownList ID="ddl_doctor" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-bold">Paciente</label>
                    <asp:DropDownList ID="ddl_paciente" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-bold">Fecha y hora</label>
                    <asp:TextBox ID="txt_fechaCita" runat="server"
                        TextMode="DateTimeLocal"
                        CssClass="form-control"
                        placeholder="Fecha y hora de la cita"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-bold">Motivo</label>
                    <asp:TextBox ID="txt_motivo" runat="server"
                        CssClass="form-control"
                        placeholder="Motivo de la cita"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-bold">Estado</label>
                    <asp:DropDownList ID="ddl_estado" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Pendiente" Value="Pendiente" />
                        <asp:ListItem Text="Completada" Value="Completada" />
                        <asp:ListItem Text="Cancelada" Value="Cancelada" />
                    </asp:DropDownList>
                </div>

            </div>

            <div class="mt-4 d-flex gap-2 flex-wrap">
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar"
                    CssClass="btn btn-success px-4" OnClick="btn_guardar_Click" />

                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
                    CssClass="btn btn-warning px-4" OnClick="btnActualizar_Click" />

                <asp:Button ID="btn_ir_doctores" runat="server" Text="Ir a Doctores"
                    CssClass="btn btn-info px-4" OnClick="btn_ir_doctores_Click" />

                <asp:Button ID="btnirpaciente" runat="server" Text="Ir a Pacientes"
                    CssClass="btn btn-info px-4" OnClick="btn_ir_pacientes_Click" />
            </div>

            <asp:Label ID="lbl_mensaje" runat="server"
                       CssClass="mt-3 d-block fw-bold text-primary"></asp:Label>
        </div>

        <!-- TABLA -->
        <div class="card shadow-sm p-3">
            <h4 class="mb-3 fw-bold">Listado de Citas</h4>

            <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="False"
    DataSourceID="SqlDataSourceCitas"
    DataKeyNames="IdCita"
    CssClass="table table-bordered table-striped"
    OnSelectedIndexChanged="gvCitas_SelectedIndexChanged"
    OnRowDeleting="gvCitas_RowDeleting">

    <Columns>
        <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
        <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
        <asp:BoundField DataField="IdCita" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="IdDoctor" HeaderText="Doctor" />
        <asp:BoundField DataField="IdPaciente" HeaderText="Paciente" />
        <asp:BoundField DataField="FechaCita" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
        <asp:BoundField DataField="Motivo" HeaderText="Motivo" />
        <asp:BoundField DataField="Estado" HeaderText="Estado" />
    </Columns>
</asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server"
    ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
    SelectCommand="SELECT * FROM Cita">
</asp:SqlDataSource>

        </div>

        <asp:SqlDataSource ID="SqlDataSourceCitas" runat="server"
                           ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
                           SelectCommand="SELECT * FROM Cita">
        </asp:SqlDataSource>

    </div>

</asp:Content>
