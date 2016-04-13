<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CrearContrato.aspx.cs" Inherits="Tangerine.GUI.M10.CrearContrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Contratos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Crear Contrato
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Dashboard</a></li>
    <li><a href="AdminContrato.aspx" > Gestión de Contratos</a></li>
    <li class="active"> Crear contrato</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="container-fluid">
      <div class="panel panel-default">
        <div class="panel-heading">Crear Contrato</div>
        <div class="container-fluid">
          <br>
          <form role="form">
            
            <!-- <button type="submit" class="btn btn-default">Enviar</button>-->
            
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <h4>Datos de Contrato</h4>
              </div>
            </div>
            <!--  seccion de datos -->
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="# de contrato" disabled>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Sueldo">
                </div>
              </div> 
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <select class="form-control">
                    <option>Tipo de contrato</option>
                    <option>2</option>
                  </select>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="input-group date" data-provide="datepicker">
                  <input type="text" class="form-control" placeholder="fecha de inicio">
                  <div class="input-group-addon">
                      <span class="glyphicon glyphicon-th"></span>
                  </div>
                </div>
              </div> 
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <select class="form-control">
                    <option>Cargo</option>
                    <option>2</option>
                  </select>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="input-group date" data-provide="datepicker">
                  <input type="text" class="form-control" placeholder="fecha fin">
                  <div class="input-group-addon">
                      <span class="glyphicon glyphicon-th"></span>
                  </div>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <select class="form-control">
                    <option>Jornada</option>
                    <option>2</option>
                  </select>
                </div>
              </div>
            </div>

            <!--  seccion de datos -->
            <button class="btn btn-default" type="submit">Aceptar</button><br><br>
          </form>
        </div>
      </div>

    </div>
</asp:Content>