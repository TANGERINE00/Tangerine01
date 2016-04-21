<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AdminCargo.aspx.cs" Inherits="Tangerine.GUI.M1.CargoAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Cargos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Consultar cargos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Dashboard</a></li>
    <li class="active">Gestión de Cargos</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div class="box box-success">
        <!--<div class="panel-heading">Filtrar Cargos</div>-->
        <div class="panel-body">
          <div class="form-group">
            <div class="row">
              <div class="col-xs-12 col-md-12 col-lg-12" >
                <input type="text" class="form-control" placeholder="Filtrar cargos">
              </div>
            </div> 
          </div>
        </div>
      </div> 

      <div class="box box-body table-responsive">
        <div class="panel-heading">
            Resultado de busqueda
            <button class="btn btn-success pull-right"><span class="glyphicon glyphicon-plus"></span></button>
        </div><br>
        <!-- Table -->
        <table class="table table-hover table-bordered table-striped">
          <thead>
              <th>Cargo</th>
              <th>Descripcion</th>
              <th></th>
          </thead>
          <tbody>
            <tr>
              <td>Desarrollador Fron End</td>
              <td>.......</td>
              <td style="text-align:center;">
                  <a href="VerEmpleado.aspx" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-danger"><span class="glyphicon glyphicon-remove-circle"></span></a>
              </td>
            </tr>
            <tr>
              <td>Desarrollador Back End</td>
              <td>........</td>
              <td style="text-align:center;">
                  <a href="VerEmpleado.aspx" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-danger"><span class="glyphicon glyphicon-remove-circle"></span></a>
              </td>
            </tr>
            <tr>
              <td>Desarrollador Full Stack</td>
              <td>.......</td>
              <td style="text-align:center;">
                  <a href="VerEmpleado.aspx" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
                  <a href="ModificarEmpleado.aspx" type="button" class="btn btn-danger"><span class="glyphicon glyphicon-remove-circle"></span></a>
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

</asp:Content>
