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
<form role="form" name="modificar_lead" id="modificar_lead" method="post"   runat="server">

 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-6">
			<div id="id_otro" runat="server" class="form-group">
				<div class="icon-addon addon-lg">
					
                    <!--Nombre-->
                        <div class="form-group" runat="server">
                            <label for="InputNombre">Nombre</label>
                            <input runat="server" type="text" class="form-control" id="nombre" name="nombre" 
                                placeholder="Introduzca nombre de la compañía" maxlength="50" required>
                        </div>
                    
                    
                     <!--RIF-->
                        <div class="form-group" runat="server">
                            <label for="InputRIF">RIF</label>
                            <input runat="server" type="text" class="form-control" 

                                pattern="^[J]+[-]+([0-9-]{9,11})+[-]+([0-9]{1,1})$"
                                id="rif" name="rif" 
                                placeholder="Introduzca RIF de la compañía.    e.g: J-23686197-6" required
                                title="e.g: J-23686197-6 ">
                        </div>
                  
                     <!--Email-->
                        <div class="form-group" runat="server">
                            <label for="InputEmail">Correo Electrónico</label>
                            <input runat="server" type="text" class="form-control"
                                pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$" 
                                id="email" name="email" 
                                placeholder="Introduzca email de la compañía.    e.g: mail@ejemplo.com" maxlength="50" required/>
                        </div>
                      

                                <!--Presupuesto-->
                        <div class="form-group" runat="server">
                            <label for="InputPresupuesto">Presupuesto Inicial de Inversion</label>
                            <input runat="server" type="number" class="form-control" 
                                id="presupuesto" name="presupuesto" 
                                placeholder="Introduzca el presupuesto anual de la Compañía" maxlength="10" required>
                        </div> 


                            <!--Numero de llamadas-->
                        <div class="form-group" runat="server">
                            <label for="InputLlamadas">Numero de llamadas</label>
                            <input runat="server" type="number" class="form-control" 
                                id="llamadas" name="llamadas" 
                                placeholder="Introduzca el numero de llamadas realizadas a la Compañía" maxlength="10" required>
                        </div>  
					
                         <!--Numero de visitas-->
                        <div class="form-group" runat="server">
                            <label for="InputPresupuesto">Numero de visitas</label>
                            <input runat="server" type="number" class="form-control" 
                                id="visitas" name="visitas" 
                                placeholder="Introduzca el numero de visitas realizadas a la Compañía" maxlength="10" required>
                        </div>  
					
                     
                   
                   
                   
                    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
    
                    </div>



            
                    
                    <asp:Button id="Button1" style="margin-top:5%" class="btn btn-primary"  OnClick="Modificar_Click" type="submit" runat="server" Text = "Modificar"   ></asp:Button>
				</div>	
			
            </div>
		</div>
        
	</div>
</div>


 

            
                 


</form>   


</asp:Content>