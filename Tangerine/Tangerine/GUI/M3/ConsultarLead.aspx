<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarLead.aspx.cs" Inherits="Tangerine.GUI.M3.ConsultarLead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Consultar Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Leads</a></li>
    <li class="active">Consultar Lead</li>
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
					
 
                    
                     <div class="box-body" runat="server">
                       <div class="row">
                          <div class="form-group col-md-6" runat="server">
                          <h4><label for="Nombre">Nombre:</label></h4>
                       <div><h5><asp:Literal runat="server" ID="Nombre"> </asp:Literal></h5></div>
                       </div> 
                        <div class="form-group col-md-6" runat="server">
                            <h4><label for="habilitado">Status:</label></h4>
                           <div><h5><asp:Literal runat="server" ID="status"> </asp:Literal></h5></div>
                        </div>    
                           </div>
                                                 
                          <div class="row">
                          <div class="form-group col-md-6" runat="server">
                            <h4><label for="Rif">RIF:</label></h4>
                            <div><h5><asp:Literal runat="server" ID="Rif"> </asp:Literal></h5></div>
                        </div>
                              <div class="form-group col-md-6" runat="server">
                            <h4><label for="presupuesto">Presupuesto Inicial:</label></h4>
                           <div><h5><asp:Literal runat="server" ID="presupuesto"> </asp:Literal></h5></div>
                        </div>
                          </div>
                        <div class="form-group" runat="server">
                            <h4><label for="correo">Correo Electrónico:</label></h4>
                      <div><h5><asp:Literal runat="server" ID="correo"> </asp:Literal></h5></div>
                        </div>
                                                 <div class="form-group" runat="server">
                            <h4><label for="llamadas">Num. Llamadas:</label></h4>
                      <div><h5><asp:Literal runat="server" ID="llamadas"> </asp:Literal></h5></div>
                        </div>
                                                 <div class="form-group" runat="server">
                            <h4><label for="visitas">Num. Visitas:</label></h4>
                      <div><h5><asp:Literal runat="server" ID="visitas"> </asp:Literal></h5></div>
                        </div>

                       
                     </div> 
                   <!-- /.box-body -->
                  <div class="box-footer" runat="server">
                        <a href="Listar.aspx" class="btn btn-default pull-left">Regresar</a>
                    </div>

   

            
                    
				</div>	
			
            </div>
		</div>
        


 
 
    


</asp:Content>
