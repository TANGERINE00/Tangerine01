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
<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div class="container-fluid">
        <div class="box box-success">
            <!--<div class="panel-heading">Filtrar empleados</div>-->
            <div class="panel-body">
              <div class="form-group">
                <div class="row">
                  <div class="col-xs-12 col-md-6 col-lg-6">
                    <select class="form-control">
                      <option>Tipo de filtro para empleados</option>
                      <option>filtro 1</option>
                      <option>filtro 2</option>
                      <option>filtro 3</option>
                    </select>
                  </div>
                  <div class="col-xs-12 col-md-6 col-lg-6">
                    <input type="text" class="form-control" placeholder="Parametro de filtro">
                  </div>
                </div> 
              </div>
            </div>
          </div> 
          
        <div class="box box-body table-responsive">
            <div class="panel-heading">
              Resultado de busqueda
              <asp:Literal runat="server" ID="nuevoempleado"></asp:Literal>
              
            </div><br>
            <!--table-->
            <table id="tablaempleados" class="table table-bordered table-striped dataTable" accesskey="">
              <thead>
                  <th>Nombres</th>
                  <th>Apellidos</th>
                  <th>Cedula</th>
                  <th>Cargo</th>
                  <th>Fecha</th>
                  <th>Estatus</th>
                  <th style="width:150PX; text-align:center;">Acciones</th>
              </thead>
                <asp:Literal runat="server" ID="tabla"></asp:Literal>
              <tbody>
             
              </tbody>
              <!--<tbody>
                <tr>
                  <td>Edgar Rafael</td>
                  <td>Landaeta Malave</td>
                   <td>20097258</td>
                  <td>Desarrollador web</td>
                  <td style='text-align: right;'>01/03/2016</td>
                  <td style="text-align:center;"><span class="label label-success">Activo</span></td>
                  <td style="text-align:center;">
                    <a href="VerEmpleado.aspx" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search"></span></a>
                    <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
                    <a href="ModificarEmpleado.aspx" type="button" class="btn btn-danger"><span class="glyphicon glyphicon-remove-circle"></span></a>
                  </td>
                </tr>
                <tr>
                  <td>Luz Marina</td>
                  <td>Eljuri Risquez</td>
                  <td>18604645</td>
                  <td>Desaroolador</td>
                  <td style="text-align:right;">15/03/2016</td>
                  <td style="text-align:center;"><span class="label label-danger">Inactivo</span></td>
                  <td style="text-align:center;">
                    <a href="VerEmpleado.aspx" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search"></span></a>
                    <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
                    <a href="ModificarEmpleado.aspx" type="button" class="btn btn-danger"><span class="glyphicon glyphicon-remove-circle"></span></a>
                  </td>
                </tr>
                <tr>
                  <td>Antonio Juan</td>
                  <td>Garcia</td>
                  <td>20097260</td>
                  <td>DBA</td>
                  <td style="text-align: right;">21/04/2016</td>
                  <td style="text-align:center;"><span class="label label-success">Activo</span></td>
                  <td style="text-align:center;">
                    <a href="VerEmpleado.aspx" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search"></span></a>
                    <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
                    <a href="ModificarEmpleado.aspx" type="button" class="btn btn-danger"><span class="glyphicon glyphicon-remove-circle"></span></a>
                  </td>
                </tr>
              </tbody>-->
            </table>
            <!-- table-->
            <nav>
              <ul class="pagination">
                <li>
                  <a href="#" aria-label="Previous">
                    <span aria-hidden="true">&laquo;</span>
                  </a>
                </li>
                <li class="active"><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>
                <li>
                  <a href="#" aria-label="Next">
                    <span aria-hidden="true">&raquo;</span>
                  </a>
                </li>
              </ul>
            </nav>
        </div>


    </div>



</asp:Content>