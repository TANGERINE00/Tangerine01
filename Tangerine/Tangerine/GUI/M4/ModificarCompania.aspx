<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarCompania.aspx.cs" Inherits="Tangerine.GUI.M4.ModificarCompania" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Compañias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Compañias</a></li>
    <li class="active">Modificar</li>
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
                <form role="form" name="modificar_compania" id="modificar_compania" method="post" runat="server">
                    <div class="box-body" runat="server">
                        <div class="form-group" runat="server">
                            <label for="InputNombre">Nombre</label>
                            <input runat="server" type="text" class="form-control" id="InputNombre1" name="InputNombre1" 
                                placeholder="Introduzca nombre de la compañía" required>
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputAcronimo">Acrónimo (opcional)</label>
                            <input runat="server" type="text" class="form-control" id="InputAcronimo1" name="InputAcronimo1" 
                                placeholder="Introduzca acrónimo de la compañía">
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputRIF">RIF</label>
                            <input runat="server" type="text" class="form-control" id="InputRIF1" name="InputRIF1" 
                                placeholder="Introduzca RIF de la compañía.    e.g: J-23686197-6" required>
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputLugar">Dirección</label>
                            <select runat="server" class="form-control" id="InputDireccion1" name="InputDireccion1"></select>
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputEmail">Correo Electrónico</label>
                            <input runat="server" type="text" class="form-control"
                                pattern="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" 
                                id="InputEmail1" name="InputEmail1" 
                                placeholder="Introduzca email de la compañía.    e.g: mail@ejemplo.com" required/>
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputTelefono">Teléfono</label>
                            <input runat="server" type="text" class="form-control" id="InputTelefono1" name="InputTelefono1" 
                                placeholder="Introduzca teléfono de la compañía     e.g: 0212-9774183" required>
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputFechaRegistro">Fecha de Registro</label>
                            <input runat="server" type="text" class="form-control" title="Fecha Inválida"
                                pattern="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" 
                                id="InputFechaRegistro1" name="InputFechaRegistro1" 
                                placeholder="dd/mm/aaaa" required>
                        </div>
                     </div><!-- /.box-body -->

                    <div class="box-footer">
                        <asp:Button id="btnmodificar" class="btn btn-primary" OnClick="btnmodificar_Click" type="submit" 
                            runat="server" Text = "Modificar"></asp:Button>
                        <a class="btn btn-default" href="ConsultarCompania.aspx" style="margin-left: 3px"  >Regresar</a>

                    </div>
                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>
</asp:Content>
