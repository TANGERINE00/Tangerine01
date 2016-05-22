<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.ConsultarPropuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/modulo6.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Propuestas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    listado de propuestas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuestas</a></li>
    <li class="active">listado de propuestas</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Propuestas</h3>
                    <%-- <div class="box-tools">
            <div class="input-group input-group-sm" style="width: 150px;">
                <input name="table_search" class="form-control pull-right" placeholder="Search" type="text">

                <div class="input-group-btn">
                    <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                </div>
            </div>
        </div>--%>
                </div>
                <!-- /.box-header -->


                <!-- Modal -->
                <%-- <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Detalle Propuesta </h4>
                </div>
                <div class="modal-body">




                    <div class="box-body">

                        <div class="form-group">
                            <label for="labelNumeroFactura_M8">Numero de Referencia</label>
                            <input type="text" class="form-control" id="textNumeroFactura_M8" disabled="disabled">
                        </div>

                        <div class="form-group">
                            <label for="labelFecha_M8">Fecha de registro</label>
                            <div class="input-group date">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" class="form-control pull-right" id="datepicker" disabled="disabled">
                            </div>

                        </div>

                        <div class="form-group">
                            <label for="labelCompañia_M8">Compañía</label>
                            <input type="text" class="form-control" id="textCompañia_M8" placeholder="Compañía" disabled="disabled">
                        </div>

                        <div class="form-group">
                            <label for="labelProyecto_M8">Proyecto</label>
                            <input type="text" class="form-control" id="textProyecto_M8" placeholder="Proyecto" disabled="disabled">
                        </div>


                        <div class="form-group">
                            <label for="labelMonto_M8">Monto</label>
                            <input type="text" class="form-control" id="textMonto_M8" placeholder="Monto" disabled="disabled">
                        </div>




                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                    </div>
                    <!-- /.box-footer -->

                </div>



            </div>

        </div>
    </div>--%>
                <!-- Fin Modal -->
                <form role="form" name="consultar" id="consultar">

                    <div class="box-body table-responsive no-padding">
                        <div style="float: right; padding-top: 5px;">
                            <a style="margin-right: 10px;">Buscador</a>
                            <input id="searchTerm" type="text" onkeyup="doSearch()" />
                        </div>
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Codigo Propuesta</th>
                                    <th>Cliente</th>
                                    <th>Fecha Estimada Inicio</th>
                                    <th>Estatus</th>
                                    <th>Moneda</th>
                                    <th>Costo</th>
                                    <th style="text-align: center;">Acciones</th>
                                </tr>
                            </thead>
                            <asp:Literal ID="tablaP" runat="server"></asp:Literal>
                        </table>

                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>


</asp:Content>
