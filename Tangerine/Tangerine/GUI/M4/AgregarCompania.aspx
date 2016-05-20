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
                        <div class="form-group" runat="server">
                            <label for="InputNombre">Nombre</label>
                            <input runat="server" type="text" class="form-control" id="InputNombre1" name="InputNombre1" placeholder="Introduzca nombre de la compañía">
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputAcronimo">Acrónimo (opcional)</label>
                            <input runat="server" type="text" class="form-control" id="InputAcronimo1" name="InputAcronimo1" placeholder="Introduzca acrónimo de la compañía">
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputRIF">RIF</label>
                            <input runat="server" type="text" class="form-control" id="InputRIF1" name="InputRIF1" placeholder="Introduzca RIF de la compañía">
                        </div>


                        <div class="form-group" runat="server">
                            <label for="InputLugar">Dirección</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="336px">
                            </asp:DropDownList>
                        </div>



                        <div class="form-group" runat="server">
                            <label for="InputLugar">Dirección</label>
                            <select runat="server" class="form-control" id="InputDireccion1" name="InputDireccion1"></select>
                        </div>




                        <div class="form-group" runat="server">
                            <label for="InputEmail">Correo Electrónico</label>
                            <input runat="server" type="text" class="form-control" id="InputEmail1" name="InputEmail1" placeholder="Introduzca correo electrónico de la compañía">
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputTelefono">Teléfono</label>
                            <input runat="server" type="text" class="form-control" id="InputTelefono1" name="InputTelefono1" placeholder="Introduzca teléfono de la compañía">
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputFechaRegistro">Fecha de Registro</label>
                            <input runat="server" type="text" class="form-control" id="InputFechaRegistro1" name="InputFechaRegistro1" placeholder="dd/mm/aaaa">
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
