<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AdminContrato.aspx.cs" Inherits="Tangerine.GUI.M10.AdminContrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Contratos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Consultar contrato
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Dashboard</a></li>
    <li class="active">Gestión Contratos</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="container-fluid">
      <div class="panel panel-success">
        <div class="panel-heading">Filtrar Contratos</div>
        <div class="panel-body">
          <div class="form-group">
            <div class="row">
              <div class="col-xs-12 col-md-6 col-lg-6">
                <select class="form-control">
                  <option>tipo de filtro</option>
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
          <a href="CrearContrato.aspx" class="btn btn-default btn-xs pull-right"><span class="glyphicon glyphicon-plus"></span></a>
        </div>
        <!-- Table -->
        <table class="table table-hover table-striped">
          <thead>
              <th># contrato</th>
              <th>Fecha inicio</th>
              <th>Fecha Fin</th>
              <th>Tipo</th>
              <th></th>
          </thead>
          <tbody>
            <tr>
              <td>a0001</td>
              <td>01/03/2016</td>
              <td>01/03/2016</td>
              <td>Fijo</td>
              <td>
                <div class="btn-group" role="group">
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-search"></span></button>
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-remove"></span></button>
                </div>
              </td>
            </tr>
            <tr>
              <td>a0002</td>
              <td>01/03/2016</td>
              <td>01/03/2016</td>
              <td>Fijo</td>
              <td>
                <div class="btn-group" role="group">
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-search"></span></button>
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-remove"></span></button>
                </div>
              </td>
            </tr>
            <tr>
              <td>a0003</td>
              <td>01/03/2016</td>
              <td>01/03/2016</td>
              <td>Fijo</td>
              <td>
                <div class="btn-group" role="group">
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-search"></span></button>
                  <button type="button" class="btn btn-default btn-xs"><span class="glyphicon glyphicon-remove"></span></button>
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