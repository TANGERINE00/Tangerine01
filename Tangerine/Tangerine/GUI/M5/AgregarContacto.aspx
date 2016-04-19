<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarContacto.aspx.cs" Inherits="Tangerine.GUI.M5.AgregarContacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Nombre Compañía/Lead
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar nuevo contacto
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
            <label style="color:rgb(255, 0, 0);">* Campos Obligatorios</label>  
          </div>
      </div>
</div>

 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-6">
			<div id="id_otro" runat="server" class="form-group">
				<div class="icon-addon addon-lg">
					<label>Nombre <a style="color:rgb(255, 0, 0);">*</a></label>
					<input style="margin-bottom:3%" runat="server" type="text" placeholder="Cesar" class="form-control" id="nombre" name ="nombre" required>                    
					<label>Apellido <a style="color:rgb(255, 0, 0);">*</a></label>
                    <input style="margin-bottom:3%" runat="server" type="text" placeholder="Rodriguez" class="form-control" id="apellido" name ="apellido" required>                   
					<label>Departamento <a style="color:rgb(255, 0, 0);">*</a></label>
                    <input style="margin-bottom:3%" runat="server" type="text" placeholder="Informatica" class="form-control" id="departamento" name ="departamento" required>                  
					<label>Cargo <a style="color:rgb(255, 0, 0);">*</a></label>
                    <input style="margin-bottom:3%" runat="server" type="text" placeholder="Lider de Proyecto" class="form-control" id="cargo" name ="cargo" required>
                    <label>Telefono</label>
                    <input style="margin-bottom:3%" runat="server" type="text" placeholder="0412-230.03.53" class="form-control" id="telefono" name="telefono">
                    <label>Correo</label>
                    <input runat="server" type="text" placeholder="carr235@gmail.com" class="form-control" id="Correo" name="Correo">
					<!--<asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Modificar"   ></asp:Button>-->
                    <a id="btnaceptara" type="submit" style="margin-top:5%" class="btn btn-primary pull-right" runat="server" href="ConsultarContactos.aspx">Agregar</a>
				    <a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default" href="ConsultarContactos.aspx">Cancelar</a>
                </div>	
			
            </div>
		</div>
        
	</div>
</div>
</asp:Content>