<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarLeads.aspx.cs" Inherits="Tangerine.GUI.M3.AgregarLeads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Leads</a></li>
    <li class="active">Agregar Leads</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<div class="row">
    <div class="container-fluid">
        <div id="alert" runat="server" style="width:100%"></div>
    </div>
    <div class="col-lg-6 col-md-6 col-xs-12">
        <div class="box box-info">
            <div class="box-header with-border">
                    <h3 class="box-title">Datos del Cliente</h3> 
            </div>
            <br /><br />
            <form role="form" name="modificar_lead" id="modificar_lead" method="post"   runat="server">
            <div class="container-fluid">
                <!--Nombre-->
                <div id="Div1" class="form-group" runat="server">
                    <label for="InputNombre">Nombre</label>
                    <label for="Requerido" style="color: red;">*</label>
                    <input runat="server" type="text" class="form-control" 
                        pattern="^[a-zA-Z'.\s]{1,40}$" 
                        id="nombre" name="nombre" placeholder="Introduzca nombre de la compañía" 
                        maxlength="30" title="Utilice caracteres alfanuméricos" required>
                </div>
                    
                <!--RIF-->
                <div id="Div2" class="form-group" runat="server">
                    <label for="InputRIF">RIF</label>
                    <label for="Requerido" style="color: red;">*</label>
                    <input runat="server" type="text" class="form-control"
                        pattern="^[J]+[-]+([0-9]{7,10})+[-]+([0-9]{1,1})$" 
                        id="rif" name="rif" title="Ej: J-23232343-5"
                        placeholder="Introduzca RIF de la compañía.    e.g: J-236861967-6" required>
                </div>
                  
                <!--Email-->
                <div id="Div3" class="form-group" runat="server">
                    <label for="InputEmail">Correo Electrónico</label>
                    <label for="Requerido" style="color: red;">*</label>
                    <input runat="server" type="text" class="form-control"
                        pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" 
                        id="email" name="email" title="Ej: correo@gmail.com"
                        placeholder="Introduzca email de la compañía.  e.g: mail@ejemplo.com" maxlength="50" required/>
                </div>
                                      
	            <!--Presupuesto-->
                <div id="Div4" class="form-group" runat="server">
                    <label for="InputPresupuesto">Presupuesto Inicial de Inversion</label>
                    <label for="Requerido" style="color: red;">*</label>
                    <input runat="server" type="number" class="form-control" 
                                id="presupuesto" name="presupuesto" 
                                placeholder="Introduzca el presupuesto anual de la Compañía" maxlength="10" required>
               </div>

               <asp:Button id="Button1" style="margin-top:5%" class="btn btn-primary" OnClick="btnaceptar_Click" type="submit" runat="server" Text = "Agregar"   ></asp:Button><br /><br />
            </div>
            </form>
        </div>
    </div>
</div>
    
</asp:Content>