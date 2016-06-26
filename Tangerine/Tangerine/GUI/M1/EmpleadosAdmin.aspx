<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="EmpleadosAdmin.aspx.cs" Inherits="Tangerine.GUI.M1.EmpleadosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de empleados
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Dashboard</a></li>
    <li class="active">Gestión de empleados</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="alerta" runat="server">
    </div>
    <!--<div class="container-fluid">-->
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Consulta de Datos</h3>
                        <div class="box-tools">
                      
                        </div>
                </div><!-- /.box-header -->
                
                <div class="box-body table-responsive no-padding">
                    <form role="form" name="consultar" id="consultar">
                    
                        
                        <div style="float:right; padding-top:5px; padding-right:5px;">
                            <a style="margin-right:10px;">Buscador</a>
                            <input id="searchTerm" type="text" onkeyup="doSearch()"/>
                        </div>
                        <!--table-->
                        <table id="example2" class="table table-bordered table-hover">
                          <thead>
                              <tr>
                                  <th>Nombres</th>
                                  <th>Apellidos</th>
                                  <th>Cedula</th>
                                  <th>Cargo</th>
                                  <th>Sueldo base</th>
                                  <th>Fecha de Ingreso</th>
                                  <th>Estatus</th>
                                  <th style="width:150PX; text-align:center;">Acciones</th>
                              </tr>
                          </thead>
                            <asp:Literal runat="server" ID="tabla"></asp:Literal>
                          <tbody>
                          </tbody>
                        </table>
                        <!-- table-->
            
                    
                </form>
              </div>
            </div>
        </div>
    </div>

    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

    <script language="javascript">
        function doSearch() {
            var tableReg = document.getElementById('tablaempleados');
            var searchText = document.getElementById('searchTerm').value.toLowerCase();
            for (var i = 1; i < tableReg.rows.length; i++) {
                var cellsOfRow = tableReg.rows[i].getElementsByTagName('td');
                var found = false;
                for (var j = 0; j < cellsOfRow.length && !found; j++) {
                    var compareWith = cellsOfRow[j].innerHTML.toLowerCase();
                    if (searchText.length == 0 || (compareWith.indexOf(searchText) > -1)) {
                        found = true;
                    }
                }
                if (found) {
                    tableReg.rows[i].style.display = '';
                } else {
                    tableReg.rows[i].style.display = 'none';
                }
            }
        }
    </script>
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
</asp:Content>