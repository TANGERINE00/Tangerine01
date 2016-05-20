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
					<label>Nombre <a style="color:rgb(255, 0, 0);">*</a></label>
					<input style="margin-bottom:3%" runat="server" type="text" class="form-control" id="nombre" name ="nombre" required>                    
					<label>Apellido <a style="color:rgb(255, 0, 0);">*</a></label>
                    <input style="margin-bottom:3%" runat="server" type="text" class="form-control" id="apellido" name ="apellido" required>                   
					<label>Departamento <a style="color:rgb(255, 0, 0);">*</a></label>
                    <input style="margin-bottom:3%" runat="server" type="text" class="form-control" id="departamento" name ="departamento" required>                  
					<label>Cargo <a style="color:rgb(255, 0, 0);">*</a></label>
                    <input style="margin-bottom:3%" runat="server" type="text" class="form-control" id="cargo" name ="cargo" required>
                    <label>Telefono</label>
                    <input style="margin-bottom:3%" runat="server" type="text" class="form-control" id="telefono" name="telefono">
                    <label>Correo</label>
                    <input runat="server" type="text" class="form-control" id="correo" name="correo">
					
                    <asp:Literal runat="server" ID="volver"></asp:Literal>
                    <!--<a id="btnaceptara" type="submit" style="margin-top:5%" class="btn btn-primary pull-right" runat="server" href="ConsultarContactos.aspx">Modificar</a>-->
				    </div>	
			
            </div>
		</div>
        
	</div>
</div>
</asp:Content>