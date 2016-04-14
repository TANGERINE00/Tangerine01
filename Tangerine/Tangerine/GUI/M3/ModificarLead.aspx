<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarLead.aspx.cs" Inherits="Tangerine.GUI.M3.ModificarLead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Leads</a></li>
    <li class="active">Modificar Lead</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
    


</div>

 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-6">
			<div id="id_otro" runat="server" class="form-group">
				<div class="icon-addon addon-lg">
					
					<input runat="server" type="text" placeholder="Nombre" class="form-control" id="nombre" name ="nombre">                    
					<input style="margin-top:5%" runat="server" type="text" placeholder="RIF" class="form-control" id="apellido" name ="apellido" >                   
					<input style="margin-top:5%" runat="server" type="text" placeholder="Direccion" class="form-control" id="departamento" name ="departamento" >                  
					<input style="margin-top:5%" runat="server" type="text" placeholder="Telefono" class="form-control" id="cargo" name ="cargo" >
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Email" class="form-control" id="telefono" name="telefono">
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Presupuesto anual de Inversion" class="form-control" id="telefono2" name="telefono2">
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Nombre del contacto" class="form-control" id="Correo" name="Correo">
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Telefono del contacto" class="form-control" id="Correo2" name="Correo2">

         		
                    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
    
                    </div>



          <div class = "dropdown">
   
   <button type = "button" class = "btn dropdown-toggle" id = "dropdownMenu1" data-toggle = "dropdown">
      Numero de Llamadas
      <span class = "caret"></span>
   </button>
   
   <ul class = "dropdown-menu" role = "menu" aria-labelledby = "dropdownMenu1">
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">0</a>
      </li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">1</a>
      </li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">2</a>     
      </li>

        <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">3</a>     
      </li>

        <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">4</a>     
      </li>

        <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">5</a>     
      </li>

        <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">Mas de 5</a>     
      </li>
      
      <li role = "presentation" class = "divider"></li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">Separated link</a>
      </li>
   </ul>
   
</div>



       <div class = "dropdown">
   
   <button type = "button" class = "btn dropdown-toggle" id = "dropdownMenu1" data-toggle = "dropdown">
      Numero de Visitas
      <span class = "caret"></span>
   </button>
   
   <ul class = "dropdown-menu" role = "menu" aria-labelledby = "dropdownMenu1">
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">0</a>
      </li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">1</a>
      </li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">2</a>     
      </li>

        <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">3</a>     
      </li>

        <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">4</a>     
      </li>

        <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">5</a>     
      </li>

        <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">Mas de 5</a>     
      </li>
      
      <li role = "presentation" class = "divider"></li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">Separated link</a>
      </li>
   </ul>
   
</div>

            
                    
                    <th style="text-align:center;"><a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="Listar.aspx"="#">Regresar></a></th> 
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Modificar"   ></asp:Button>
				</div>	
			
            </div>
		</div>
        
	</div>
</div>


   


</asp:Content>