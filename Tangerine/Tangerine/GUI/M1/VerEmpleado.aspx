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
    <li><a href="EmpleadosAdmin.aspx?EmployeeId=0" > Gestión de empleados</a></li>
    <li class="active"> Ver empleado</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="container-fluid">
      
      <div class="box box-default">
        <div class="container-fluid">
          <br>
            <asp:Literal runat="server" ID="FormViewEmployee"></asp:Literal>
        </div>
      </div>

    </div>
</asp:Content>

