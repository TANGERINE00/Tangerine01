<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultaProyecto.aspx.cs" Inherits="Tangerine.GUI.M7.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Proyectos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Datos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Proyectos</a></li>
    <li class="active">Consulta Proyecto</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Main content -->
   
          <div class="row">
            <div class="col-md-12">
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Consulta de Proyectos</h3>
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
                        <th>Propuesta</th>
                        <th>Codigo</th>
                        <th>Fecha Inicio</th>
                        <th>Fecha Estimada a Culminar</th>
                        <th>Porcentaje de realizacion</th>
                        <th>Estatus</th>
                        <th style="text-align: center;">Acciones</th>
                      </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Proyecto A</td>
                            <td>Sistema A</td>
                            <td>Codigo</td>
                            <td>yyy/mm/dd</td>
                            <td>yyy/mm/dd</td>
                            <td>30%</td>
                            <td><span class="label label-success">Habilitada</span></td>
                            <th style="text-align: center;">
                                <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                        </th>
                       </tr>
                       <tr>
                            <td>Proyecto B</td>
                            <td>Sistema B</td>
                            <td>Codigo</td>
                            <td>yyy/mm/dd</td>
                            <td>yyy/mm/dd</td>
                            <td>50%</td>
                            <td><span class="label label-success">Habilitada</span></td>
                            <th style="text-align: center;">
                                <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                        </th>
                       </tr>
                    </tbody>
                  </table>
                </div><!-- /.box-body -->
              </div><!-- /.box -->

            </div><!-- /.col -->
          </div><!-- /.row -->
       
</asp:Content>