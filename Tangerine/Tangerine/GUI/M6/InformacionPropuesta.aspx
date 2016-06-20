<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="InformacionPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.InformacionPropuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Propuestas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Información de Propuesta
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Propuesta</a></li>
    <li class="active">Información de Propuesta</li>
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
                    <h3 class="box-title">Información de Propuesta</h3>
                    <div class="box-tools">    
                     </div>
                </div><!-- /.box-header -->
                <!-- table start -->
                <div class="box-body table-responsive no-padding">
                    
                     <div class="box-body" runat="server">
                       <div class="row">
                          <div class="form-group col-md-6" runat="server">
                          <h4><label for="Nombre">Código:</label></h4>
                       <div><h5><asp:Label runat="server" ID="Nombre"> </asp:Label></h5></div>
                       </div> 
                        <div class="form-group col-md-6" runat="server">
                            <h4><label for="habilitado">Status:</label></h4>
                           <div><h5><asp:Label runat="server" ID="habilitado"> </asp:Label></h5></div>
                        </div>    
                           </div>
                           <div class="row">
                          <div class="form-group col-md-6" runat="server">
                         <h4><label for="Acronimo">Acrónimo:</label></h4>
                       <div><h5><asp:Label runat="server" ID="acronimo"> </asp:Label></h5></div>
                        </div>
                            <div class="form-group col-md-6" runat="server">
                            <h4><label for="plazo">Plazo para pagos:</label></h4>
                           <div><h5><asp:Label runat="server" ID="plazo"> </asp:Label></h5></div>
                        </div>
                        </div>
                         
                          <div class="row">
                          <div class="form-group col-md-6" runat="server">
                            <h4><label for="Rif">RIF:</label></h4>
                            <div><h5><asp:Label runat="server" ID="Rif"> </asp:Label></h5></div>
                        </div>
                              <div class="form-group col-md-6" runat="server">
                            <h4><label for="presupuesto">Presupuesto Actual:</label></h4>
                           <div><h5><asp:Label runat="server" ID="presupuesto"> </asp:Label></h5></div>
                        </div>
                          </div>
                        <div class="form-group" runat="server">
                            <h4><label for="direccion">Dirección:</label></h4>
                      <div><h5><asp:Label runat="server" ID="direccion"> </asp:Label></h5></div>
                        </div>
                        <div class="form-group" runat="server">
                            <h4><label for="correo">Correo Electrónico:</label></h4>
                      <div><h5><asp:Label runat="server" ID="correo"> </asp:Label></h5></div>
                        </div>
                        <div class="form-group" runat="server">
                            <h4><label for="telefono">Teléfono:</label></h4>
                            <div><h5><asp:Label runat="server" ID="telefono"> </asp:Label></h5></div>
                       </div>
                        <div class="form-group" runat="server">
                            <h4><label for="fecha">Fecha de Registro:</label></h4>
                           <div><h5><asp:Label runat="server" ID="fecha"> </asp:Label></h5></div>
                        </div>                        
                     </div> 
                   </div><!-- /.box-body -->
                    
                 
                    <div class="box-footer" runat="server">
                        <a href="ConsultarCompania.aspx" class="btn btn-default pull-left">Regresar</a>
                    </div>

                </div>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
       
</asp:Content>
