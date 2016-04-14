<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="modificarProyecto.aspx.cs" Inherits="Tangerine.GUI.M7.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Proyectos</a></li>
    <li class="active">Modificar Proyecto</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="form-group">
            <asp:Label ID="Label10" runat="server" Text="Modificación de un proyecto" Font-Bold="True" Font-Size="Larger"></asp:Label></div>
   
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
    
    <div role="form">
          <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Codigo del Proyecto" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
            <asp:DropDownList ID="codigoProyecto" runat="server"> </asp:DropDownList>
        <div> <hr /></div>
        <div class="form-group">
            <asp:Label ID="Label11" runat="server" Text="Estatus" Font-Bold="True"></asp:Label></div>
            <div class="form-group"> <asp:RadioButton ID="RadioButton1" runat="server"  Text="En Desarrollo"/>
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Finalizado" />
            </div>
            

  
        <div class="form-group">
            <asp:Label ID="Lable2" runat="server" Text="Fecha de inicio" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
            <asp:TextBox ID="fechaInicio" runat="server" placeholder="Fecha" Width="351px"></asp:TextBox></div>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Fecha estimada de culminación" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
            <asp:TextBox ID="fechaCulminacion" runat="server" placeholder="Fecha culminación" Width="351px"></asp:TextBox></div>
        <div  class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Costo estimado" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
            <asp:TextBox ID="costoProyecto" runat="server" Width="198px">0</asp:TextBox> <asp:Label ID="Label5" runat="server" Text=" Bs"></asp:Label> </div>
        <div  class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Porcentaje de Realización" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
            <asp:TextBox ID="porcentajeRealizacion" runat="server" Width="119px">0</asp:TextBox> <asp:Label ID="Label7" runat="server" Text="%"></asp:Label> </div>


        <div class="form-group">
             <asp:Label ID="Label9" runat="server" Text="Propuesta Aprobada" Font-Bold="True"></asp:Label></div>
            <div class="form-group"><asp:DropDownList ID="propuetaAprobada" runat="server"></asp:DropDownList>
         </div>
         <div class="form-group">
             <hr />
             <asp:Label ID="Label8" runat="server" Text="Gerente Encargado" Font-Bold="True"></asp:Label></div>
         <div>
             <asp:DropDownList ID="gerenteResponsable" runat="server"></asp:DropDownList>
         </div>

          <div class="form-group">
              <hr />
             <asp:Label ID="Label2" runat="server" Text=" Personal Asignado" Font-Bold="True"></asp:Label>
              
         </div>
         <div class="form-group">
             <asp:DropDownList ID="personalTrabajo" runat="server"> </asp:DropDownList>
             <asp:Button ID="Button1" class="btn btn-info pull-right" runat="server" Text="Eliminar" />
         </div> 
            <asp:Label ID="Label12" runat="server" Text="Asignar nuevo personal" Font-Bold="True"></asp:Label>
              
         </div>
          <div class="form-group">
             <asp:DropDownList ID="personalNoAsignado" runat="server"> </asp:DropDownList>
             <asp:Button ID="Button2" class="btn btn-info pull-right" runat="server" Text="Asignar" />
         </div>
         <div class="form-group"></div>
         <div style="height: 49px; width: 822px;">  <button type="submit" class="btn btn-info pull-right">Crear</button></div>
    </div>
</asp:Content>
