<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="FormularioCitas.aspx.vb" Inherits="ProyectoEventos.FormularioCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2 class="text-center mb-4">Gestión de Citas</h2>

        <asp:HiddenField ID="editando" runat="server" />
        <asp:HiddenField ID="hfIdCita" runat="server" />


        <div class="card shadow-sm p-4 mb-4">
            <div class="row g-3">

                <%--Doctor--%>
                <div class="col-md-6">
                    <label class="form-label fw-bold">Doctor</label>
                    <asp:DropDownList ID="ddl_doctor" runat="server" CssClass="form-select"></asp:DropDownList>

                    <asp:RequiredFieldValidator ID="fvrDoctor" runat="server"
                      Display="Dynamic"
                      CssClass="alert alert-warning"
                    ErrorMessage="Seleccione un doctor"
                    ControlToValidate="ddl_doctor"></asp:RequiredFieldValidator>

                </div>

                <%--Paciente--%>
                <div class="col-md-6">
                    <label class="form-label fw-bold">Paciente</label>
                    <asp:DropDownList ID="ddl_paciente" runat="server" CssClass="form-select"></asp:DropDownList>

                    <asp:RequiredFieldValidator ID="fvrPaciente" runat="server"
                      Display="Dynamic"
                      CssClass="alert alert-warning"
                    ErrorMessage="Ingrese nombre del paciente"
                    ControlToValidate="ddl_paciente"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-bold">Fecha y hora</label>
                    <asp:TextBox ID="txt_fechaCita" runat="server"
                        TextMode="DateTimeLocal"
                        CssClass="form-control"
                        placeholder="Fecha y hora de la cita"></asp:TextBox>
                </div>

                <%--Motivo--%>
                <div class="col-md-6">
                    <label class="form-label fw-bold">Motivo</label>
                    <asp:TextBox ID="txt_motivo" runat="server"
                        CssClass="form-control"
                        placeholder="Motivo de la cita"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="fvrMotivo" runat="server"
                      Display="Dynamic"
                      CssClass="alert alert-warning"
                    ErrorMessage="Ingresa un motivo"
                    ControlToValidate="txt_motivo"></asp:RequiredFieldValidator>
                </div>

                <%--Estado--%>
                <div class="col-md-6">
                    <label class="form-label fw-bold">Estado</label>
                    <asp:DropDownList ID="ddl_estado" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Pendiente" Value="Pendiente" />
                        <asp:ListItem Text="Completada" Value="Completada" />
                        <asp:ListItem Text="Cancelada" Value="Cancelada" />
                    </asp:DropDownList>

                    <%--<asp:RequiredFieldValidator ID="fvrEstado" runat="server"
                        Display="Dynamic"
                        CssClass="alert alert-warning"
                        ErrorMessage="Ingresa una Estado"
                        ControlToValidate="ddl_estado"></asp:RequiredFieldValidator>--%>




                </div>

            </div>

            <div class="mt-4 d-flex gap-2 flex-wrap">
                <asp:Button ID="btn_guardar" runat="server" Text="Guardar"
                    CssClass="btn btn-success px-4" OnClick="btn_guardar_Click" />

                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
                    CssClass="btn btn-warning px-4" OnClick="btnActualizar_Click" />

                <asp:Button ID="btn_ir_doctores" runat="server" Text="Ir a Doctores"
                    CssClass="btn btn-info px-4" OnClick="btn_ir_doctores_Click" CausesValidation="false"/>

                <asp:Button ID="btnirpaciente" runat="server" Text="Ir a Pacientes"
                    CssClass="btn btn-info px-4" OnClick="btn_ir_pacientes_Click" CausesValidation="false"/>
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

             <asp:ValidationSummary ID="vsCitas" runat="server" ShowSummary="true"
     CssClass="alert alet-warning"
     HeaderText="Debe de completar lo siguiente:" />


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

    <script type="text/javascript">
        function mostrarAlerta(tipo, titulo, mensaje) {
            Swal.fire({
                icon: tipo,  
                title: titulo,
                text: mensaje,
                confirmButtonColor: '#3085d6'
            });
        }

        function confirmarEliminar(callback) {
            Swal.fire({
                title: '¿Está seguro?',
                text: 'Esta acción no se puede deshacer',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#6c757d',
                confirmButtonText: 'Sí, eliminar',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    __doPostBack(callback, '');
                }
            });
        }
    </script>

</asp:Content>
