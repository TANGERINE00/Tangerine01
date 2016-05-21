<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="InformacionCompania.aspx.cs" Inherits="Tangerine.GUI.M4.HabilitarCompania" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Compañias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Información de Compañia
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Compañias</a></li>
    <li class="active">Información de Compañia</li>
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
                    <h3 class="box-title">Información de Compañías</h3>
                    <div class="box-tools">    
                     </div>
                </div><!-- /.box-header -->
                <!-- table start -->
                <div class="box-body table-responsive no-padding">
                    
                     <div class="box-body" runat="server">
                       <div class="row">
                          <div class="form-group col-md-6" runat="server">
                          <h3><label for="Nombre">Nombre:</label></h3>
                       <div><h4><asp:Literal runat="server" ID="Nombre"> </asp:Literal></h4></div>
                       </div> 
                        <div class="form-group col-md-6" runat="server">
                            <h3><label for="habilitado">Status:</label></h3>
                           <div><h4><asp:Literal runat="server" ID="habilitado"> </asp:Literal></h4></div>
                        </div>    
                           </div>
                           <div class="row">
                          <div class="form-group col-md-6" runat="server">
                         <h3><label for="Acronimo">Acrónimo (opcional):</label></h3>
                       <div><h4><asp:Literal runat="server" ID="Acronimo"> </asp:Literal></h4></div>
                        </div>
                            <div class="form-group col-md-6" runat="server">
                            <h3><label for="plazo">Plazo para pagos:</label></h3>
                           <div><h4><asp:Literal runat="server" ID="plazo"> </asp:Literal></h4></div>
                        </div>
                        </div>
                         
                          <div class="row">
                          <div class="form-group col-md-6" runat="server">
                            <h3><label for="Rif">RIF:</label></h3>
                            <div><h4><asp:Literal runat="server" ID="Rif"> </asp:Literal></h4></div>
                        </div>
                              <div class="form-group col-md-6" runat="server">
                            <h3><label for="presupuesto">Presupuesto Actual:</label></h3>
                           <div><h4><asp:Literal runat="server" ID="presupuesto"> </asp:Literal></h4></div>
                        </div>
                          </div>
                        <div class="form-group" runat="server">
                            <h3><label for="direccion">Dirección:</label></h3>
                      <div><h4><asp:Literal runat="server" ID="direccion"> </asp:Literal></h4></div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3><label for="correo">Correo Electrónico:</label></h3>
                      <div><h4><asp:Literal runat="server" ID="correo"> </asp:Literal></h4></div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3><label for="telefono">Teléfono:</label></h3>
                            <div><h4><asp:Literal runat="server" ID="telefono"> </asp:Literal></h4></div>
                       </div>
                        <div class="form-group" runat="server">
                            <h3><label for="fecha">Fecha de Registro:</label></h3>
                           <div><h4><asp:Literal runat="server" ID="fecha"> </asp:Literal></h4></div>
                        </div>                        
                     </div> 
                   </div><!-- /.box-body -->
                    
                 
                    <div class="box-footer" runat="server">
 <a href="ConsultarCompania.aspx" class="btn btn-default pull-left">Regresar</a>
                     </div>

                </div>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>
</asp:Content>
