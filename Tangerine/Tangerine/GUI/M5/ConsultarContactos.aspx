<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarContactos.aspx.cs" Inherits="Tangerine.GUI.M5.ConsultarContactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de contactos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Listado de Contactos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de contactos</a></li>
    <li class="active">Agregar Contactos</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id="alerta" runat="server">
    </div>
  <div class="row">
   <div class="col-xs-12">
     <div class="box">
       <div class="box-header">
           <h3 class="box-title">Planillas Creadas</h3>
        </div><!-- /.box-header -->
      <form role="form" name="consultar_planilla" id="consular_planillas">
         
          <div class="box-body table-responsive">
             
          <table id="planillascreadas" class="table table-bordered table-striped dataTable" accesskey="">
           <thead>
            <tr>
                <th>ID</th>
                <th>Nombre</th>
                <th>Departamento</th>
                <th>Cargo</th>
                <th>Telefono</th>
                <th>Correo</th>                 
                <th style="text-align:center;">Acciones</th>
            </tr>
          </thead>
              <asp:Literal runat="server" ID="tabla"></asp:Literal>
           <tbody>
                <th>1</th>
                <th>Cesar Rodriguez</th>
                <th>Informatica</th>
                <th>Lider de Proyecto</th>
                <th>0412-230.03.53</th>
                <th>carr235@gmail.com</th>                 
                <th style="text-align:center;"><a class="btn btn-primary glyphicon glyphicon-info-sign"></a><a  class="btn btn-default glyphicon glyphicon-edit"></a><a  class="btn btn-danger glyphicon glyphicon-remove-circle"></a></th> 
           </tbody>
        </table>
       </div>
      </form>
    </div>
	</div>
  </div>
      
       <div id="modal-switch" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Activaci&oacute;n/Desactivaci&oacute;n de Planilla Solicitada</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>¿Está seguro que desea cambiar el status de la planilla?</p>
                    <p id="comp"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <button type="button" class="btn btn-primary" data-dismiss="modal" onserverclick="CambioDeStatus_Click">Aceptar</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div>
        </div>
      </div>
            
     
     
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
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
