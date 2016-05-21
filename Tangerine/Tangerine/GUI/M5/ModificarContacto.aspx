<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarContacto.aspx.cs" Inherits="Tangerine.GUI.M5.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de contactos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar Contacto
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="row">
            <!-- left column -->
            <div class="col-md-6">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Datos del Contacto</h3>
                    <label style="color:rgb(255, 0, 0); float:right;">* Campos Obligatorios</label> 
                </div>
			<div id="id_otro" runat="server" class="form-group">
				<div class="icon-addon addon-lg" style="margin-left: 10px;">
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
					<div style="text-align:center;">
                        <asp:Literal runat="server" ID="volver"></asp:Literal>
                        <a id="btnaceptara" type="submit" style="margin-top:20px; margin-left:10px; width:120px; float:none !important; "
                            class="btn btn-primary pull-right" runat="server" href="ConsultarContactos.aspx">Modificar</a>
                    </div>
                 </div>	
			
            </div>
		</div>
        
	</div>
</div>
</asp:Content>