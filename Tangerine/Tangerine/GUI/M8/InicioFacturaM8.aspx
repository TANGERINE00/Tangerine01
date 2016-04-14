<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="InicioFacturaM8.aspx.cs" Inherits="Tangerine.GUI.M8.InicioFacturaM8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Facturas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Facturas</a></li>
    <li class="active">Inicio</li>
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
                  <h3 class="box-title">Seleccione la acción a realizar</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form">
                    <div class="box-footer">
                        <button type="submit" class="btn btn-primary">Consultar</button>
                    </div>
                    <div class="box-footer">
                        <button type="submit" class="btn btn-primary">Modificar</button>
                    </div>
                    <div class="box-footer">
                        <button type="submit" class="btn btn-primary">Anular</button>
                    </div>

                   

                    <!-- 
                    <div class="box-footer">
                        <a href="#">Consultar datos de una compañía</a>
                    </div>
                    <div class="box-footer">
                        <a href="#">Registrar nueva compañía</a>
                    </div>
                    <div class="box-footer">
                        <a href="#">Modificar datos de una compañía</a>
                    </div>
                    <div class="box-footer">
                        <a href="#">Habilitar o Inhabilitar una compañía registrada</a>
                    </div>
                    -->
                    
                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>
</asp:Content>
