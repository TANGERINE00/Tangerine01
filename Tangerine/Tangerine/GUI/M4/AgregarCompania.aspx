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
    <li><a href="InicioCompania.aspx">Gestión de Compañias</a></li>
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
                <form role="form">
                    <div class="box-body">
                        <div class="form-group">
                            <label for="InputNombre">Nombre</label>
                            <input type="text" class="form-control" id="InputNombre1" placeholder="Introduzca nombre de la compañía">
                        </div>
                        <div class="form-group">
                            <label for="InputAcronimo">Acrónimo (opcional)</label>
                            <input type="text" class="form-control" id="InputAcronimo1" placeholder="Introduzca acrónimo de la compañía">
                        </div>
                        <div class="form-group">
                            <label for="InputRIF">RIF</label>
                            <input type="text" class="form-control" id="InputRIF1" placeholder="Introduzca RIF de la compañía">
                        </div>
                        <div class="form-group">
                            <label for="InputEmail">Correo Electrónico</label>
                            <input type="text" class="form-control" id="InputEmail1" placeholder="Introduzca correo electrónico de la compañía">
                        </div>
                        <div class="form-group">
                            <label for="InputFechaRegistro">Fecha de Registro</label>
                            <input type="text" class="form-control" id="InputFechaRegistro1" placeholder="dd/mm/aaaa">
                        </div>
                     </div><!-- /.box-body -->

                    <div class="box-footer">
                        <button type="submit" class="btn btn-primary">Registrar</button>
                    </div>
                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>
</asp:Content>
