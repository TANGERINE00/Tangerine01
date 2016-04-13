<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarContacto.aspx.cs" Inherits="Tangerine.GUI.M5.EjemploM5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de contactos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar Contactos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de contactos</a></li>
    <li class="active">Agregar Contactos</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="box-body col-sm-12 col-md-12 col-lg-12 ">
      <div class="form-group  col-sm-12 col-md-12 col-lg-12" >
          
          <div class="col-sm-3 col-md-3 col-lg-3">
            <label>Seleccione Compañía:</label>  
          </div>
          <div class="col-sm-8 col-md-8 col-lg-84">
             <div class="dropdown" runat="server" id="combo" >
                 <asp:DropDownList ID="combo1" name="dropdowlist" class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" >
                 </asp:DropDownList>
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
					<input style="margin-top:5%" runat="server" type="text" placeholder="Apellido" class="form-control" id="apellido" name ="apellido" >                   
					<input style="margin-top:5%" runat="server" type="text" placeholder="Departamento" class="form-control" id="departamento" name ="departamento" >                  
					<input style="margin-top:5%" runat="server" type="text" placeholder="Cargo" class="form-control" id="cargo" name ="cargo" >
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Telefono 1" class="form-control" id="telefono" name="telefono">
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Telefono 2" class="form-control" id="telefono2" name="telefono2">
                    <input style="margin-top:5%" runat="server" type="text" placeholder="Correo 1" class="form-control" id="Correo" name="Correo">
                    <input style="margin-top:5%" runat="server" type="text" placeholder="correo 2" class="form-control" id="Correo2" name="Correo2">
					
                    <a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="#">Cancelar</a>
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Agregar"   ></asp:Button>
				</div>	
			
            </div>
		</div>
        
	</div>
</div>
</asp:Content>