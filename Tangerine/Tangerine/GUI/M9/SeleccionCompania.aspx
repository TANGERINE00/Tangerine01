<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" 
    CodeBehind="SeleccionCompania.aspx.cs" Inherits="Tangerine.GUI.M9.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestion de Pagos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Lista de compañias
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="/GUI/M1/Dashboard.aspx"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Pagos</a></li>
    <li class="active">Seleccion de compañia</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
   <div id="alert" runat="server">
   </div>
    <div class="row">
            <!-- left column -->
            <div class="col-md-12">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Compañias</h3>
                    <div class="box-tools"></div>
                </div>
                  <form role="form" name="consultar" id="consultar">
                    <script language="javascript">
                        function doSearch() {
                            var tableReg = document.getElementById('example2');
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

                <div class="box-body table-responsive no-padding">
                    <div style="float:right; padding-top:5px;">
                            <a style="margin-right:10px;">Buscador</a>
                            <input id="searchTerm" type="text" onkeyup="doSearch()"/>
                    </div>
                    <table id="example2" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th style="text-align: center;">Nombre</th>
                                <th style="text-align: center;">Acrónimo</th>
                                <th style="text-align: center;">RIF</th>
                                <th style="text-align: center;">Fecha Registro</th>
                                <th style="text-align: center;">Status</th>
                                <th style="text-align: center;">Facturas</th>
                                <th style="text-align: center;">Pagos</th>
                            </tr>
                        </thead>
                        <asp:Literal runat="server" ID="tabla"></asp:Literal>
                        </tbody> 
                            <!-- <tr>
                                <td>International Business Machines</td>
                                <td>IBM</td>
                                <td>J-8764553432</td>
                                <td>ibm@gmail.com</td>
                                <td>22/12/2012</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" 
                                type="submit" runat="server" href="FacturasPorPagar.aspx"></a></th>
                            </tr> -->
 
                    </table>
                </div>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>

    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

</asp:Content>
