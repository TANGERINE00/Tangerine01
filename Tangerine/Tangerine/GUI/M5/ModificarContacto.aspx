<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarContacto.aspx.cs" Inherits="Tangerine.GUI.M5.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de contactos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar Contactos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de contactos</a></li>
    <li class="active">Modificar Contactos</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Modificar"   ></asp:Button>
				</div>	
			
            </div>
		</div>
        
	</div>
</div>
</asp:Content>