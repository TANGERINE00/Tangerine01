﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarContacto.aspx.cs" Inherits="Tangerine.GUI.M5.Modificar" %>
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
					<a>Nombre</a>
					<input style="margin-bottom:3%" runat="server" type="text" value="Cesar" class="form-control" id="nombre" name ="nombre">                    
					<a>Apellido</a>
                    <input style="margin-bottom:3%" runat="server" type="text" value="Rodriguez" class="form-control" id="apellido" name ="apellido" >                   
					<a>Departamento</a>
                    <input style="margin-bottom:3%" runat="server" type="text" value="Informatica" class="form-control" id="departamento" name ="departamento" >                  
					<a>Cargo</a>
                    <input style="margin-bottom:3%" runat="server" type="text" value="Lider de Proyecto" class="form-control" id="cargo" name ="cargo" >
                    <a>Telefono</a>
                    <input style="margin-bottom:3%" runat="server" type="text" value="0412-230.03.53" class="form-control" id="telefono" name="telefono">
                    <a>Correo</a>
                    <input runat="server" type="text" value="carr235@gmail.com" class="form-control" id="Correo" name="Correo">
					
                    <a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="ConsultarContactos.aspx">Cancelar</a>
                    <!--<asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Modificar"   ></asp:Button>-->
                    <a id="btnaceptara" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" href="ConsultarContactos.aspx">Modificar</a>
				</div>	
			
            </div>
		</div>
        
	</div>
</div>
</asp:Content>