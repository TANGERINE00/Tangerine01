
<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="Tangerine.GUI.M3.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/modulo6.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"href="Listar.aspx"></i> Home </a></li>
    <li><a href="#">Gestión </a></li>
    <li class="active">Agregar </li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <!-- Main content -->
   
          <div class="row">
            <div class="col-md-12">
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Consulta de Datos</h3>
                  <div class="box-tools">
                      
                     </div>
                </div><!-- /.box-header -->
                <div class="box-body table-responsive no-padding">
                <div style="float: right; padding-top: 5px;">
                        <a style="margin-right: 10px;">Buscador</a>
                        <input id="searchTerm" type="text" onkeyup="doSearch()" />
                    </div>
                  <table id="example2" class="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>Nombre</th>
                        <th>RIF</th>
                        <th>Email</th>
                        <th>Status</th>
                        <th>Presupuesto Anual</th>
                        <th>Acciones</th>
                      </tr>
                    </thead>
                  <asp:Literal runat="server" ID="Lista"></asp:Literal>
                    <tbody>
                       
                            
                    </tbody>
                  </table>

                </div><!-- /.box-body -->
              </div><!-- /.box -->

            </div><!-- /.col -->
          </div><!-- /.row -->
       
    <script type="text/javascript">
        $(document).ready(function () {
            $('#planillascreadas').DataTable();

            var table = $('#planillascreadas').DataTable();
            var planilla;
            var tr;

            $('#planillascreadas tbody').on('click', 'a', function () {
                if ($(this).parent().hasClass('selected')) {
                    req = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr');//se guarda la fila seleccionada
                    $(this).parent().removeClass('selected');

                }
                else {
                    req = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr');//se guarda la fila seleccionada
                    table.$('tr.selected').removeClass('selected');
                    $(this).parent().addClass('selected');
                }
            });

        });
        $('#dimension-switch').bootstrapSwitch('setSizeClass', 'switch-small');

        </script>

    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

</asp:Content>


