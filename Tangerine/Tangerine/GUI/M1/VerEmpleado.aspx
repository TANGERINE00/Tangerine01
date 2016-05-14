<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="VerEmpleado.aspx.cs" Inherits="Tangerine.GUI.M1.VerEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Empleados
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Ver Empleado
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Dashboard</a></li>
    <li><a href="EmpleadosAdmin.aspx" > Gestión de empleados</a></li>
    <li class="active"> Ver empleado</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="container-fluid">
      
      <div class="box box-default">
        <!--<div class="panel-heading">Ficha de empleado</div>-->
        <div class="container-fluid">
          <br>
          <!--<form role="form">
            
            
            
            
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <h4>Datos Personales</h4>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <h4>Datos de Contrato</h4>
              </div> 
            </div>
            
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="# de ficha de empleado" disabled>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="# de contrato" disabled>
                </div>
              </div> 
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="cedula" disabled>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Fecha de ingreso DD/MM/YYYY" disabled>
                </div>
              </div> 
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Nombres" disabled>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Fecha de egreso DD/MM/YYYY" disabled>
                </div>
              </div> 
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Apellidos" disabled>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Cargo" disabled>
                </div>
              </div> 
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Sexo" disabled>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Tipo de contrato" disabled>
                </div>
              </div> 
            </div>
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="edad" disabled>
                </div>
              </div>
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Salario" disabled>
                </div>
              </div> 
            </div>

            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="fecha de nacimiento" disabled>
                </div>
              </div>
            </div>


            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <h4>Datos de Domicilio</h4>
              </div>
            </div>
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Pais" disabled>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Estado" disabled>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-sm-12 col-md-6 col-lg-6">
                <div class="form-group">
                  <input type="text" class="form-control"placeholder="Direccion" disabled>
                </div>
              </div>
            </div>
            

            
          
          </form>-->
            <asp:Literal runat="server" ID="FormViewEmployee"></asp:Literal>
        </div>
      </div>

    </div>
</asp:Content>

