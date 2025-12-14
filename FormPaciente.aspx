<%@ Page Title="Pacientes" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormPaciente.aspx.vb" Inherits="ProyectoEventos.FormPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblMensaje" runat="server" CssClass="text-success fw-bold"></asp:Label>

<div class="col-md-4 d-none">
    <label class="form-label">ID Paciente</label>

    <asp:TextBox ID="txtIdPaciente" runat="server" CssClass="form-control"></asp:TextBox>
</div>



    <div class="container mt-4">
        <h2 class="text-center mb-4">Gestión de Pacientes</h2>

        <!-- FORMULARIO -->
        <%--Nombre--%>
        <div class="card shadow p-4 mb-4">
            <div class="row g-3">
                <div class="col-md-4">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="fvrNombre" runat="server"
                        Display="Dynamic"
                        CssClass="alert alert-warning"
                        ErrorMessage="Ingresa el Nombre"
                        ControlToValidate="txtNombre"></asp:RequiredFieldValidator>

                </div>

                <%--Apellidos--%>
                <div class="col-md-4">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="fvrApellido" runat="server"
                        Display="Dynamic"
                        CssClass="alert alert-warning"
                        ErrorMessage="Ingresa el apellido"
                        ControlToValidate="txtApellido"></asp:RequiredFieldValidator>

                </div>


                <%--Fecha de Nacimiento--%>
                <div class="col-md-4">
                    <label class="form-label">Fecha de Nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="fvrFechaNacimiento" runat="server"
                        Display="Dynamic"
                        CssClass="alert alert-warning"
                        ErrorMessage="Ingresa la Fecha de Nacimiento"
                        ControlToValidate="txtFechaNacimiento"></asp:RequiredFieldValidator>

                </div>

                <%--Teléfono--%>
                <div class="col-md-6">
                    <label class="form-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="fvrTelefono" runat="server"
                        Display="Dynamic"
                        CssClass="alert alert-warning"
                        ErrorMessage="Ingresa un numero de Telefono"
                        ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>

                </div>

                <%--Correo--%>
                <div class="col-md-6">
                    <label class="form-label">Correo</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="fvrCorreo" runat="server"
                        Display="Dynamic"
                        CssClass="alert alert-warning"
                        ErrorMessage="Ingresa un Correo"
                        ControlToValidate="txtCorreo"></asp:RequiredFieldValidator>

                </div>

                <%--Dirección--%>
                <div class="col-md-6">
                    <label class="form-label">Dirección</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="fvrDireccion" runat="server"
                        Display="Dynamic"
                        CssClass="alert alert-warning"
                        ErrorMessage="Ingresa una Dirección"
                        ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>

                </div>

                <div class="col-12 text-center mt-3">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success px-4 m-2" Text="Guardar"  />
                    <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary px-4 m-2" Text="Actualizar" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger px-4 m-2" Text="Eliminar" />
                    <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-secondary px-4 m-2" Text="Limpiar" />
                    <asp:Button ID="btnIrDoctores" runat="server" CssClass="btn btn-info px-4 m-2" Text="Ir a Doctores" CausesValidation="false"/>   
                    <asp:Button ID="btnIrCitas" runat="server" CssClass="btn btn-info px-4 m-2" Text="Ir a Citas" CausesValidation="false"/>
                </div>
            </div>
        </div>

        <h3 class="text-center mb-3">Listado de Pacientes</h3>

        <asp:GridView ID="gridPacientes" runat="server"
            CssClass="table table-striped table-bordered"
            AutoGenerateColumns="False"
            DataKeyNames="IdPaciente">
            <Columns>
                 <asp:BoundField DataField="IdPaciente" HeaderText="ID" />
                 <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                 <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                 <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                 <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                 <asp:BoundField DataField="Correo" HeaderText="Correo" />
                 <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
            </Columns>
        </asp:GridView>

         <asp:ValidationSummary ID="vsPaciemte" runat="server" ShowSummary="true"
     CssClass="alert alet-warning"
     HeaderText="Debe de completar los siguientes campos:" />

    </div>

</asp:Content>

