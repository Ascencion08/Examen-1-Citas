<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="FormularioCitas.aspx.vb" Inherits="ProyectoEventos.FormularioCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2 class="text-center mb-4">Gestión de Citas</h2>

        <asp:HiddenField ID="editando" runat="server" />

        <!-- FORMULARIO -->
        <div class="card shadow-sm p-4 mb-4">
            <div class="row g-3">

                <!-- Doctor -->
                <div class="col-md-6">
                    <label class="form-label fw-bold">Doctor</label>
                    <asp:DropDownList ID="ddl_doctor" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <!-- Paciente -->
                <div class="col-md-6">
                    <label class="form-label fw-bold">Paciente</label>
                    <asp:DropDownList ID="ddl_paciente" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <!-- Fecha y hora -->
                <div class="col-md-6">
                    <label class="form-label fw-bold">Fecha y hora</label>
                    <asp:TextBox ID="txt_fechaCita" runat="server"
                        TextMode="DateTimeLocal"
                        CssClass="form-control"
                        placeholder="Fecha y hora de la cita"></asp:TextBox>
                </div>

                <!-- Motivo -->
                <div class="col-md-6">
                    <label class="form-label fw-bold">Motivo</label>
                    <asp:TextBox ID="txt_motivo" runat="server"
                        CssClass="form-control"
                        placeholder="Motivo de la cita"></asp:TextBox>
                </div>

                <!-- Estado -->
                <div class="col-md-6">
                    <label class="form-label fw-bold">Estado</label>
                    <asp:DropDownList ID="ddl_estado" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Pendiente" Value="Pendiente" />
                        <asp:ListItem Text="Completada" Value="Completada" />
                        <asp:ListItem Text="Cancelada" Value="Cancelada" />
                    </asp:DropDownList>
                </div>

            </div>

            <!-- BOTONES -->
            <div class="mt-4 d-flex gap-2 flex-wrap">
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar"
                    CssClass="btn btn-success px-4" OnClick="btn_guardar_Click" />

                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
                    CssClass="btn btn-warning px-4" OnClick="btnActualizar_Click" />

                <asp:Button ID="btn_ir_doctores" runat="server" Text="Ir a Doctores"
                    CssClass="btn btn-info px-4" OnClick="btn_ir_doctores_Click" />
                 <asp:Button ID="btnirpaciente" runat="server" Text="Ir a Pacientes" CssClass="btn btn-info" OnClick="btn_ir_pacientes_Click" />
            </div>

            <asp:Label ID="lbl_mensaje" runat="server"
                       CssClass="mt-3 d-block fw-bold text-primary"></asp:Label>
        </div>




        <!-- TABLA -->
        <div class="card shadow-sm p-3">
            <h4 class="mb-3 fw-bold">Listado de Citas</h4>

            <asp:GridView ID="gvCitas" runat="server"
                          CssClass="table table-striped table-bordered"
                          HeaderStyle-CssClass="table-dark"
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

        </div>

        <asp:SqlDataSource ID="SqlDataSourceCitas" runat="server"
                           ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
                           SelectCommand="SELECT * FROM Cita">
        </asp:SqlDataSource>

    </div>

</asp:Content>





