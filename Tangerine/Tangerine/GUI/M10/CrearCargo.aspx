<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CrearCargo.aspx.cs" Inherits="Tangerine.GUI.M1.CrearCargo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Cargos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Crear cargo
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Dashboard</a></li>
    <li><a href="AdminCargo.aspx" >Gestionar Cargos</a></li>
    <li class="active">Crear Cargo</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="container-fluid">
      <div class="box box-default">
        <!--<div class="panel-heading">Crear Cargo</div>-->
        <div class="container-fluid">
          <br>
          <form role="form">               
            <!-- <button type="submit" class="btn btn-default">Enviar</button>-->
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <h4>Datos del cargo</h4>
              </div>
            </div>
            <!--  seccion de datos -->
            <div class="row">
              <div class="col-sm-12 col-md-12 col-lg-12">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Nombre del Cargo">
                </div>
              </div>
              <div class="col-sm-12 col-md-12 col-lg-12">
                <div class="form-group">
                  <textarea class="form-control" rows="5" placeholder="Descripcion del cargo"></textarea>
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