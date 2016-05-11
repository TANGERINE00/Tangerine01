<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarFacturaM8.aspx.cs" Inherits="Tangerine.GUI.M8.ConsultarFacturaM8" %>

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


