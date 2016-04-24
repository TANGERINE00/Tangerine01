<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ListarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.EjemploM6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Consulta de facturas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Lista de facturas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Factura</a></li>
    <li class="active">Consulta de facturas</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="box">
        <div class="box-header">
            <h3 class="box-title">Consulta de facturas</h3>

            <div class="box-tools">
                <div class="input-group input-group-sm" style="width: 150px;">
                    <input name="table_search" class="form-control pull-right" placeholder="# Factura" type="text">

                    <div class="input-group-btn">
                        <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Consulta</h4>
                    </div>
                    <div class="modal-body">
                       
                        <div class="box box-primary">
                <div class="box-header with-border">
                  
                </div><!-- /.box-header -->
                <!-- form start -->
                
                  <div class="box-body">

                    <div class="form-group">
                      <label for="labelNumeroFactura_M8">Número Factura </label>
                      <input type="text" class="form-control" id="textNumeroFactura_M8"  disabled="disabled">
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




                  </div><!-- /.box-body -->

                
              </div>



                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                        
                    </div>
                </div>
            </div>
        </div>
        <!-- /.box-header -->
        <div class="box-body table-responsive no-padding">
            <table class="table table-hover">
                <tbody>
                    <tr>
                        <th>N° Factura</th>
                        <th>Cliente</th>
                        <th>Fecha Factura</th>
                        <th>Estatus Factura</th>
                        <th>Proyecto</th>
                        <th>Monto</th>
                        <th style="text-align: center;">Contacto</th>
                    </tr>
                    <tr>
                        <td>00000000001</td>
                        <td>Trascend</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-success">Pagada</span></td>
                        <td>Conexión de usuarios en la planta de Guarenas.</td>
                        <th style="text-align: center;">20<a class="glyphicon glyphicon-euro"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a></th>
                    </tr>
                    <tr>
                        <td>00000000002</td>
                        <td>Pepsi</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-warning">Anulada</span></td>
                        <td>Base de datos para el departamento A.</td>
                        <th style="text-align: center;">40<a class="glyphicon glyphicon-usd"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a></th>
                    </tr>
                    <tr>
                        <td>00000000003</td>
                        <td>Google</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-warning">Anulada</span></td>
                        <td>Página web para el soporte técnico.</td>
                        <th style="text-align: center;">50<a class="glyphicon glyphicon-bitcoin"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a></th>
                    </tr>
                    <tr>
                        <td>00000000004</td>
                        <td>Tebca</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-danger">No pagada</span></td>
                        <td>Página web para el uso publicitario.</td>
                        <th style="text-align: center;">10<a class="glyphicon glyphicon-usd"></a></th>
                         <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a></th>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-- /.box-body -->
    </div>
    <!-- /.box -->




</asp:Content>
