<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="Tangerine.GUI.M3.ModificarLead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"href="Listar.aspx"></i> Home </a></li>
    <li><a href="#">Gestión </a></li>
    <li class="active">Agregar </li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div id="Div1" runat="server">
    </div>
  <div class="row">
   <div class="col-xs-12">
     <div class="box">
       <div class="box-header">
           <h3 class="box-title">Clientes Potenciales</h3>
           <th style="text-align:center;"><a  class="btn btn-danger glyphicon glyphicon-plus" href="AgregarLeads.aspx"></a><a class="btn btn-default glyphicon glyphicon-upload" href="Promover.aspx"></a></th> 
        </div><!-- /.box-header -->
      <form role="form" name="consultar" id="consultar">
         
          <div class="box-body table-responsive">
             
          <table id="planillascreadas" class="table table-bordered table-striped dataTable" accesskey="">
           <thead>
            <tr>
                <th>ID</th>
                <th>Empresa</th>
                <th>RIF</th>
                <th>Telefono</th>
                <th>Email</th>
                <th style="text-align:center;">Acciones</th>
            </tr>
          </thead>
              <asp:Literal runat="server" ID="Literal1"></asp:Literal>
           <tbody>
                <th>1</th>
                <th>Umbrella</th>
                <th>J-156373</th>
                <th>675849</th>
                <th>info@umbrella.com</th>                
                <th style="text-align:center;"><a class="btn btn-primary glyphicon glyphicon-search" href="ConsultarLead.aspx"></a><a  class="btn btn-default glyphicon glyphicon-pencil" href="ModificarLead.aspx"></a><a  class="btn btn-danger glyphicon glyphicon-trash" href="EliminarLead.aspx"></a></th> 
           </tbody>
              <tbody>
                <th>2</th>
                <th>Skynet</th>
                <th>J-472521</th>
                <th>3457651</th>
                <th>info@skynet.com</th>                
                <th style="text-align:center;"><a class="btn btn-primary glyphicon glyphicon-search" href="ConsultarLead.aspx"></a><a  class="btn btn-default glyphicon glyphicon-pencil" href="ModificarLead.aspx"></a><a  class="btn btn-danger glyphicon glyphicon-trash" href="EliminarLead.aspx"></a></th> 
           </tbody>
        </table>
       </div>
      </form>
    </div>
	</div>
  </div>
      

    <div id="modal-switch" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Activaci&oacute;n/Desactivaci&oacute;n de Personal Seleccionado</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>¿Está seguro que desea cambiar el status de la planilla?</p>
                    <p id="comp"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <button type="button" class="btn btn-primary" data-dismiss="modal" >Aceptar</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div>
        </div>
      </div>
            




</asp:Content>


