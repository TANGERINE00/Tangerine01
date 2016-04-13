<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ListarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.EjemploM6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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




    <div class="box">
        <div class="box-header">
            <h3 class="box-title">Propuestas</h3>

            <div class="box-tools">
                <div class="input-group input-group-sm" style="width: 150px;">
                    <input name="table_search" class="form-control pull-right" placeholder="Search" type="text">

                    <div class="input-group-btn">
                        <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.box-header -->
        <div class="box-body table-responsive no-padding">
            <table class="table table-hover">
                <tbody>
                    <tr>
                        <th>N° Referencia</th>
                        <th>Cliente</th>
                        <th>Fecha de Registro</th>
                        <th>Estatus</th>
                        <th>Descripcion</th>
                        <th>Moneda/Pago</th>
                        <th style="text-align: center;">Acciones</th>
                    </tr>
                    <tr>
                        <td>TRSC012016</td>
                        <td>Trascend</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-success">Aprobado</span></td>
                        <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                        <th style="text-align: center;"><a class="glyphicon glyphicon-euro"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign"></a><a class="btn btn-default glyphicon glyphicon-edit" href="ModificarContacto.aspx"></a><a class="btn btn-danger glyphicon glyphicon-remove-circle"></a></th>
                    </tr>
                    <tr>
                        <td>PPSI022016</td>
                        <td>Pepsi</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-warning">En ejecucion</span></td>
                        <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                        <th style="text-align: center;"><a class="glyphicon glyphicon-usd"></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign"></a><a class="btn btn-default glyphicon glyphicon-edit" href="ModificarContacto.aspx"></a><a class="btn btn-danger glyphicon glyphicon-remove-circle"></a></th>
                    </tr>
                    <tr>
                        <td>GGLE012016</td>
                        <td>Google</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-warning">En ejecucion</span></td>
                        <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                        <th style="text-align: center;"><a class="glyphicon glyphicon-bitcoin" ></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign"></a><a class="btn btn-default glyphicon glyphicon-edit" href="ModificarContacto.aspx"></a><a class="btn btn-danger glyphicon glyphicon-remove-circle"></a></th>
                    </tr>
                    <tr>
                        <td>TBCA012016</td>
                        <td>Tebca</td>
                        <td>13-04-2016</td>
                        <td><span class="label label-danger">Cerrado</span></td>
                        <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                        <th style="text-align: center;"><a class="glyphicon glyphicon-usd" ></a></th>
                        <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign"></a><a class="btn btn-default glyphicon glyphicon-edit" href="ModificarContacto.aspx"></a><a class="btn btn-danger glyphicon glyphicon-remove-circle"></a></th>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-- /.box-body -->
    </div>
    <!-- /.box -->




</asp:Content>
