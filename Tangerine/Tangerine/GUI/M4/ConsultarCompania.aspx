<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarCompania.aspx.cs" Inherits="Tangerine.GUI.M4.ConsultarCompania" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Compañias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Datos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Compañias</a></li>
    <li class="active">Consultar</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <!-- Modal  info-->

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" style="display: height: 350px; align-content:center;" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document" style="height: 350px; align-content:center;">
                <div class="modal-content" style="height: 350px; align-content:center;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Contacto</h4>
                    </div>
                    <div class="modal-body" style="height: 350px; align-content:center;">
                       
                        <div class="box box-primary" style="height: 272px; align-content:center;">
                <div class="box-header with-border">
                  
                </div><!-- /.box-header -->
                <!-- form start -->
                
                  <div class="box-body">

                    <div class="form-group">
                      <label for="labelTelefono_M8">Teléfono</label>
                      <input type="text" class="form-control" id="textTelefono_M8" placeholder="Teléfono" disabled="disabled">
                    </div>

                     <div class="form-group">
                      <label for="labelEMail_M8">Correo Electrónico</label>
                      <input type="text" class="form-control" id="textEMail_M8" placeholder="Correo Electrónico" disabled="disabled">
                    </div>
                      <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                    </div>

                  </div><!-- /.box-body -->

                
              </div>



                    </div>
                    
                </div>
            </div>
        </div>
    
    <!-- Modal Edit-->

        <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" style="display: height: 350px; align-content:center;" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document" style="height: 350px; align-content:center;">
                <div class="modal-content" style="height: 350px; align-content:center;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Contacto</h4>
                    </div>
                    <div class="modal-body" style="height: 350px; align-content:center;">
                       
                        <div class="box box-primary" style="height: 272px; align-content:center;">
                <div class="box-header with-border">
                  
                </div><!-- /.box-header -->
                <!-- form start -->
                
                  <div class="box-body">
                    <div class="well">
                        <asp:Literal runat="server" ID="infoCom"></asp:Literal>
                    </div>
                  </div><!-- /.box-body -->

                
              </div>



                    </div>
                    
                </div>
            </div>
        </div>
    

     <!-- Main content -->
   
          <div class="row">
            <div class="col-md-12">
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Consulta de Datos</h3>
                  <div class="box-tools">
                        <div class="input-group input-group-sm" style="width: 150px;">
                            <input name="table_search" class="form-control pull-right" placeholder="Search" type="text">

                            <div class="input-group-btn">
                                <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                            </div>
                        </div>
                     </div>
                </div><!-- /.box-header -->
                <div class="box-body table-responsive no-padding">
                  <table id="example2" class="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>Nombre</th>
                        <th>RIF</th>
                        <th>Teléfono</th>
                        <th>Status</th>
                        <th style="text-align: center;">Acciones</th>
                      </tr>
                    </thead>
                  <asp:Literal runat="server" ID="tabla"></asp:Literal>
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
