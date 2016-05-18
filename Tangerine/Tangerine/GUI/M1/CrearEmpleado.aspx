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

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
      
      <div class="box box-default">
        
        <div class="container-fluid">
            <div class="container-fluid">
              <div class="row">
                <div class="col-xs-12 col-md-6 col-lg-6">
                  <h4>Datos Personales</h4>
                  <div class="form-group ">
                    <input type="text" runat="server" id="cedula" class="form-control" placeholder="Cédula">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="primer_nombre" class="form-control" placeholder="Primer Nombre">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="segundo_nombre" class="form-control" placeholder="Segundo Nombre">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="primer_apellido" class="form-control" placeholder="Primer Apellido">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="segundo_apellido" class="form-control" placeholder="Segundo Apellido">
                  </div>
                  <div class="form-group ">
                    <select class="form-control" id="genero">
                        <option value="Masculino">Masculino</option>
                        <option value="Femenino">Femenino</option>
                    </select>
                  </div>
                  <div class="form-group">
                      <div class="input-group date" data-provide="datepicker">
                          <input type="text" class="form-control" placeholder="fecha de nacimiento">
                          <div class="input-group-addon">
                              <span class="glyphicon glyphicon-th"></span>
                          </div>
                      </div>
                  </div>
                 
                </div>
               <!-- <div class="col-xs-12 col-md-4 col-lg-4">
                  <h4>Datos Dmicilio</h4>
                  <div class="form-group ">
                    <input type="text" class="form-control" placeholder="Username" aria-describedby="sizing-addon2">
                  </div>
                  <div class="form-group ">
                    <input type="text" class="form-control" placeholder="Username" aria-describedby="sizing-addon2">
                  </div>
                </div>-->
              </div>
            </div>
        </div>
           
</asp:Content>
