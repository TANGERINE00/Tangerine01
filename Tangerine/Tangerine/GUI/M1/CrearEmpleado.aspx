<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CrearEmpleado.aspx.cs" Inherits="Tangerine.GUI.M1.CrearEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Empleados
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Crear Empleado
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Dashboard</a></li>
    <li><a href="EmpleadosAdmin.aspx" > Gestión de Empleados</a></li>
    <li class="active"> Crear Empleado</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="container-fluid">
      
      <div class="box box-default">
        <!--<div class="panel-heading">Nuevo empleado</div>-->
        <div class="container-fluid">
          <br>
          <form role="form">
            
            
            <!-- <button type="submit" class="btn btn-default">Enviar</button>-->
            
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <h4>Datos Personales</h4>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <h4>Datos de Domicilio</h4>
              </div> 
            </div>
            <!--  seccion de datos -->
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="# de ficha de empleado" disabled>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="País">
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Cédula">
                </div>
              </div> 
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Estado">
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Nombres">
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Direccion">
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Apellidos">
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Sexo">
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="input-group date" data-provide="datepicker">
                  <input type="text" class="form-control" placeholder="Fecha de nacimiento">
                  <div class="input-group-addon">
                      <span class="glyphicon glyphicon-th"></span>
                  </div>
                </div>
              </div>
            </div><br>
            <!--  seccion de datos -->
            <button class="btn btn-default" type="submit">Aceptar</button><br><br>
          </form>
        </div>
      </div>

    </div>
</asp:Content>
