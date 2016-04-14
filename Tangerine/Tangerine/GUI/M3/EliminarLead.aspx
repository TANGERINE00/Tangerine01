<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="EliminarLead.aspx.cs" Inherits="Tangerine.GUI.M3.ModificarLead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Eliminar Lead
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de lead</a></li>
    <li class="active">Eliminar Leads</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="box-body col-sm-12 col-md-12 col-lg-12 ">
      <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
          
          <div class="col-sm-3 col-md-3 col-lg-3">
            <label>Seleccione el Lead :</label>  
          </div>
          <div class="col-sm-8 col-md-8 col-lg-84">
             


              
    <div class = "dropdown">
   
   <button type = "button" class = "btn dropdown-toggle" id = "dropdownMenu1" data-toggle = "dropdown">
      Leads
      <span class = "caret"></span>
   </button>
   
   <ul class = "dropdown-menu" role = "menu" aria-labelledby = "dropdownMenu1">
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">Umbrella</a>
      </li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">Skynet</a>
      </li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">
            SquareSoft
         </a>
      </li>
      
      <li role = "presentation" class = "divider"></li>
      
      <li role = "presentation">
         <a role = "menuitem" tabindex = "-1" href = "#">Separated link</a>
      </li>
   </ul>
   
</div>






          </div>
      </div>
</div>









 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-6">
			<div id="id_otro" runat="server" class="form-group">
				<div class="icon-addon addon-lg">
					
					<input runat="server" type="text" placeholder="Nombre" class="form-control" id="nombre" name ="nombre">                    
				
                    <a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="#">Cancelar</a>
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Eliminar"   ></asp:Button>
 
 

				</div>	
			
            </div>
		</div>
        
	</div>
</div>


    <th style="text-align:center;"><a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="Listar.aspx"="#">Regresar></a></th> 

</asp:Content>