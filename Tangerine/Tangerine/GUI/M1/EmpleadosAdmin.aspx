<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="EmpleadosAdmin.aspx.cs" Inherits="Tangerine.GUI.M1.CargoAdmin" %>

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

        <div class="panel panel-default">
        <div class="panel-heading">
          Resultado de busqueda
          <a href="CrearEmpleado.aspx" class="btn btn-default btn-xs pull-right"><span class="glyphicon glyphicon-plus"></span></a>
        </div>
        <!-- Table -->
        <table class="table table-hover table-striped">
          <thead>
              <th>Ficha</th>
              <th>Cedula</th>
              <th>Nombres</th>
              <th>Apellidos</th>
              <th>Cargo</th>
              <th>Fecha</th>
              <th>Estatus</th>
              <th></th>
          </thead>
          <tbody>
            <tr>
              <td>a0001</td>
              <td>20097258</td>
              <td>Edgar Rafael</td>
              <td>Landaeta Malave</td>
              <td>Desarrollador web</td>
              <td>01/03/2016</td>
              <td>Activo</td>
              <td>
                <div class="btn-group" role="group">
                  <a href="VerEmpleado.aspx" type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-search"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-pencil"></span></a>
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-check"></span></button>
                </div>
              </td>
            </tr>
            <tr>
              <td>a0002</td>
              <td>18604645</td>
              <td>Luz Marina</td>
              <td>Eljuri Risquez</td>
              <td>Risquez</td>
              <td>15/03/2016</td>
              <td>Activo</td>
              <td>
                <div class="btn-group" role="group">
                  <a href="VerEmpleado.aspx" type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-search"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-pencil"></span></a>
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-check"></span></button>
                </div>
              </td>
            </tr>
            <tr>
              <td>a0003</td>
              <td>20097260</td>
              <td>Antonio Juan</td>
              <td>Garcia</td>
              <td></td>
              <td>21/04/2016</td>
              <td>Activo</td>
              <td>
                <div class="btn-group" role="group">
                  <a href="VerEmpleado.aspx" type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-search"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-pencil"></span></a>
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-check"></span></button>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
        <nav>
          <ul class="pagination">
            <li>
              <a href="#" aria-label="Previous">
                <span aria-hidden="true">&laquo;</span>
              </a>
            </li>
            <li><a href="#">1</a></li>
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