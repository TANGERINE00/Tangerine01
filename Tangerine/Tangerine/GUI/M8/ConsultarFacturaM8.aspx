<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarFacturaM8.aspx.cs" Inherits="Tangerine.GUI.M8.ConsultarFacturaM8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Facturas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Datos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Facturas</a></li>
    <li class="active">Consultar</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main content -->

    <div class="row" runat="server">
        <div class="col-md-12" runat="server">
            <div class="box box-primary" runat="server">
                <form role="form" runat="server" method="post" name="consulta_factura" id="consulta_factura">
                    <div class="box-header with-border" runat="server">
                        <h3 class="box-title">Consulta de Datos</h3>
                        <div class="box-tools" runat="server">
                            <div class="input-group input-group-sm" style="width: 150px;" runat="server">
                                <input name="table_search" class="form-control pull-right" id="textBuscarId" placeholder="Número Factura" type="text" runat="server">

                                <div class="input-group-btn">
                                  <!--  <button type="submit" class="btn btn-default" id="BuscadorId" runat="server" Onclick="busquedaNumero_Click"><i class="fa fa-search" ></i></button>-->
                                    <asp:LinkButton type="submit" runat="server" ID="btnRun" Text="<i class='fa fa-search' ></i>" 
                                        ValidationGroup="edt" OnClick="busquedaNumero_Click" class="btn btn-default" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body table-responsive no-padding">
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Número</th>
                                    <th>Compañía</th>
                                    <th>Proyecto</th>
                                    <th>Descripción</th>
                                    <th>Fecha Registro</th>
                                    <th>Estatus</th>
                                    <th>Monto</th>
                                    <th style="text-align: center;">Acciones</th>
                                </tr>
                            </thead>
                            <asp:Literal runat="server" ID="tabla"></asp:Literal>
                            <tbody>
                            </tbody>
                        </table>

                    </div>
                    <!-- /.box-body -->
                </form>
            </div>
            <!-- /.box -->

        </div>
        <!-- /.col -->
    </div>

    <!-- /.row -->

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
