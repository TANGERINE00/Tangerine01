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
    <li class="active">Gestionar Cargos</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div class="panel panel-success">
        <div class="panel-heading">Filtrar Cargos</div>
        <div class="panel-body">
          <div class="form-group">
            <div class="row">
              <div class="col-xs-12 col-md-6 col-lg-6">
                <select class="form-control">
                  <option>tipo de filtro</option>
                  <option>Cargo</option>
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
          <a href="CrearCargo.aspx" class="btn btn-default btn-xs pull-right"><span class="glyphicon glyphicon-plus"></span></a>
        </div>
        <!-- Table -->
        <table class="table table-hover table-striped">
          <tr>
              <th>Cargo</th>
              <th>Descripcion</th>
          </tr>
          <tbody>
            <tr>
              <td>Desarrollador Fron End</td>
              <td>.......</td>
            </tr>
            <tr>
              <td>Desarrollador Back End</td>
              <td>........</td>
            </tr>
            <tr>
              <td>Desarrollador Full Stack</td>
              <td>.......</td>
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
