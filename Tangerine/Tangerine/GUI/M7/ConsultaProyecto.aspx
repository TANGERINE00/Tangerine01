<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultaProyecto.aspx.cs" Inherits="Tangerine.GUI.M7.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server"> 

    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#"> Proyectos </a></li>
    <li class="active"> Consulta Proyecto </li>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="form-group">
            <asp:Label ID="Label10" runat="server" Text="Proyecto" Font-Bold="True" Font-Size="Larger"></asp:Label></div>

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">

     <!-- left column -->
            <div class="col-md-6">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Consultar Proyecto</h3>
                </div><!-- /.box-header -->
      <form role="form">
          <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Codigo del Proyecto" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
            <asp:DropDownList ID="codigoProyecto" runat="server"> </asp:DropDownList>
        <div> <hr /></div>
        <div class="form-group">
            <asp:Label ID="Label11" runat="server" Text="Estatus" Font-Bold="True"></asp:Label></div>
            <div class="form-group"> 
                <asp:Label ID="estatus" runat="server" Text="-Estatus-" ></asp:Label>
            </div>
            

  
        <div class="form-group">
            <asp:Label ID="Lable2" runat="server" Text="Fecha de inicio" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
             <asp:Label ID="fechaI" runat="server" Text="-Fecha-" ></asp:Label></div>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Fecha estimada de culminación" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
             <asp:Label ID="fechaE" runat="server" Text="-Fecha-"></asp:Label></div>
        <div  class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Costo estimado" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
             <asp:Label ID="costo" runat="server" Text="-costo-" ></asp:Label> <asp:Label ID="Label5" runat="server" Text=" Bs"></asp:Label> </div>
        <div  class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Porcentaje de Realización" Font-Bold="True"></asp:Label></div>
        <div class="form-group">
             <asp:Label ID="realizacion" runat="server" Text="-Realizacion-"></asp:Label> <asp:Label ID="Label7" runat="server" Text="%"></asp:Label> </div>


        <div class="form-group">
             <asp:Label ID="Label9" runat="server" Text="Propuesta Aprobada" Font-Bold="True"></asp:Label></div>
            <asp:Label ID="propuesta" runat="server" Text="-Informacion de la propuesta-"></asp:Label>
         </div>
         <div class="form-group">
             <hr />
             <asp:Label ID="Label8" runat="server" Text="Gerente Encargado" Font-Bold="True"></asp:Label></div>
         <div>
             <asp:Label ID="gerente" runat="server" Text="-Gerente-" ></asp:Label></div>
         </form>

          <div class="form-group">
              <hr />
             <asp:Label ID="Label2" runat="server" Text=" Personal Asignado" Font-Bold="True"></asp:Label>
              
         </div>
         <div class="form-group">
              <asp:Label ID="personal" runat="server" Text=" -Lista personal Asignado-"></asp:Label>
         </div> 
           <div class="form-group"><hr /></div>

         
    </form>
                  </div><!-- /.box -->
         
            </div> 
    
    <!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6">
               <form role="form">
                   <div class="form-group">
              <asp:Label ID="Label19" runat="server" Text=" Empresa" Font-Bold="True"></asp:Label>
                       </div>
                       <div class="form-group">
              <asp:Label ID="empresa" runat="server" Text=" -Nombre de la Empresa-"></asp:Label>
         </div> 
         <div class="form-group">
              <asp:Label ID="Label20" runat="server" Text=" Persona de contacto" Font-Bold="True"></asp:Label>
             </div><div class="form-group">
              <asp:Label ID="personaC" runat="server" Text=" -Nombre persona-"></asp:Label>
                 </div>
                   <div class="form-group">
             <asp:Label ID="telefono" runat="server" Text=" -telefono-"></asp:Label>
         </div> 
               </form>
            </div>
</asp:Content>
