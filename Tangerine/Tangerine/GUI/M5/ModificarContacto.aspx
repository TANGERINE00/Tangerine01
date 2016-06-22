<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarContacto.aspx.cs" Inherits="Tangerine.GUI.M5.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Contactos
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
                <form role="form" name="agregar_contacto" id="agregar_contacto" method="post"   runat="server">
			        <div id="id_otro" runat="server" class="form-group">
				        <div class="icon-addon addon-lg" style="margin-left: 10px;">
					        <label>Nombre <a style="color:rgb(255, 0, 0);">*</a></label>
					        <input style="margin-bottom:3%" runat="server" type="text" pattern="^[A-z]+$" class="form-control" id="nombre" name ="nombre" required oninvalid="setCustomValidity('Campo obligatorio, no puede tener números ni símbolos')" oninput="setCustomValidity('')">               
					        <label>Apellido <a style="color:rgb(255, 0, 0);">*</a></label>
                            <input style="margin-bottom:3%" runat="server" type="text" pattern="^[A-z]+$" class="form-control" id="apellido" name ="apellido" required oninvalid="setCustomValidity('Campo obligatorio, no puede tener números ni símbolos')" oninput="setCustomValidity('')">
					        <label>Departamento <a style="color:rgb(255, 0, 0);">*</a></label>
                            <input style="margin-bottom:3%" runat="server" type="text" pattern="^[0-9a-zA-Z ]+$" class="form-control" id="departamento" name ="departamento" required oninvalid="setCustomValidity('Campo obligatorio, no puede tener números ni símbolos')" oninput="setCustomValidity('')">
					        <label>Cargo <a style="color:rgb(255, 0, 0);">*</a></label>
                            <select style="margin-bottom:3%" runat="server" class="form-control" id="cargoLB" name="cargosLB">
                                <option>Gerente</option>
                                <option>Director</option>
                                <option>Programador</option>
                            </select>
                            <label>Telefono <a style="color:rgb(255, 0, 0);">*</a></label>
                            <input style="margin-bottom:3%" runat="server" type="text" pattern="^[0-9]*$" class="form-control" id="telefono" name="telefono" required oninvalid="setCustomValidity('Campo obligatorio, introduzca solo números. Ej: 02129876543')" oninput="setCustomValidity('')">
                            <label>Correo <a style="color:rgb(255, 0, 0);">*</a></label>
                            <input runat="server" type="text" pattern="[a-zA-Z0-9._-]+@[a-z0-9._-]+\.[a-z]{2,4}$" class="form-control" id="correo" name="correo" required oninvalid="setCustomValidity('Campo obligatorio, debe tener un formato de correo. Ej: micorreo@yahoo.com, otrocorreo@gmail.com')" oninput="setCustomValidity('')">
                        </div>	
                    </div>
                    <div id="Div1" class="box-footer" runat="server">
				        <div style="text-align:center;">
                            <asp:Literal runat="server" ID="volver"></asp:Literal>
                            <asp:Button id="btnmodificar" style="margin-top:20px; margin-left:10px; width:120px; float:none !important; " 
                                class="btn btn-primary pull-right" OnClick="btnmodificar_Click" type="submit" runat="server" Text = "Modificar"></asp:Button>
                        </div>
                    </div>
                </form>
		</div>
        
	</div>
</div>
</asp:Content>