<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarCompania.aspx.cs" Inherits="Tangerine.GUI.M4.AgregarCompania" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Compañias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Registrar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Compañias</a></li>
    <li class="active">Registrar</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <!-- left column -->
            <div class="col-md-6">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Datos de la Compañía</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form" name="agregar_compania" id="agregar_compania" method="post" runat="server">
                    <div class="box-body" runat="server">
                        <!--Nombre-->
                        <div class="form-group" runat="server">
                            <label for="InputNombre">Nombre</label>
                            <input runat="server" type="text" class="form-control" id="InputNombre1" name="InputNombre1" 
                                placeholder="Introduzca nombre de la compañía" maxlength="50" required>
                        </div>
                        <!--Acronimo-->
                        <div class="form-group" runat="server">
                            <label for="InputAcronimo">Acrónimo (opcional)</label>
                            <input runat="server" type="text" class="form-control" id="InputAcronimo1" name="InputAcronimo1" 
                                placeholder="Introduzca acrónimo de la compañía" maxlength="10">
                        </div>
                        <!--RIF-->
                        <div class="form-group" runat="server">
                            <label for="InputRIF">RIF</label>
                            <input runat="server" type="text" class="form-control" 
                                pattern="^(\J\-[0-9]{9,13})$"
                                id="InputRIF1" name="InputRIF1" 
                                placeholder="Introduzca RIF de la compañía.    e.g: J-23686197-6" required>
                        </div>
                        <!--Direccion-->
                        <div class="form-group" runat="server">
                            <label for="InputLugar">Dirección</label>
                            <select runat="server" class="form-control" id="InputDireccion1" name="InputDireccion1"></select>
                        </div>
                        <!--Email-->
                        <div class="form-group" runat="server">
                            <label for="InputEmail">Correo Electrónico</label>
                            <input runat="server" type="text" class="form-control"
                                pattern="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" 
                                id="InputEmail1" name="InputEmail1" 
                                placeholder="Introduzca email de la compañía.    e.g: mail@ejemplo.com" maxlength="50" required/>
                        </div>
                        <!--Telefono-->
                        <div class="form-group" runat="server">
                            <label for="InputTelefono">Teléfono</label>
                            <input runat="server" type="text" class="form-control" 
                                pattern="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$" id="InputTelefono1" name="InputTelefono1" 
                                placeholder="Introduzca teléfono de la compañía     e.g: 0212-9774183" maxlength="12"required>
                        </div>
                        <!--Fecha Registro-->
                        <div class="form-group" runat="server">
                            <label for="InputFechaRegistro">Fecha de Registro</label>
                            <input runat="server" type="text" class="form-control" title="Fecha Inválida"
                                pattern="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" 
                                id="InputFechaRegistro1" name="InputFechaRegistro1" 
                                placeholder="dd/mm/aaaa" maxlength="10"required>
                        </div>
                        <!--Presupuesto-->
                        <div class="form-group" runat="server">
                            <label for="InputPresupuesto">Presupuesto Anual</label>
                            <input runat="server" type="number" class="form-control" id="InputPresupuesto1" name="InputPresupuesto1" 
                                placeholder="Introduzca el presupuesto anual de la Compañía" maxlength="10"required>
                        </div>
                        <!--Plazo de Pagos-->
                        <div class="form-group" runat="server">
                            <label for="InputPlazoPago">Plazo de Pagos (días)</label>
                            <input runat="server" type="text" class="form-control" id="InputPlazoPago1" name="InputPlazoPago1" 
                                placeholder="Introduzca el plazo para los pagos de la compañía" maxlength="4"required>
                        </div>
                     </div><!-- /.box-body -->

                    <div class="box-footer" runat="server">
                        <asp:Button id="btnagregar" class="btn btn-primary" OnClick="btnagregar_Click" type="submit" runat="server" Text = "Registrar"></asp:Button>
                    </div>
                </form>
              </div><!-- /.box -->
            </div><!--/.col (left) -->
          </div>
</asp:Content>
