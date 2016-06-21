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
            <div class="col-md-9">
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
                        <div class="form-group col-md-7" runat="server">
                            <h4 style="display:inline-block; margin-right:5px;"><label for="Codigo">Código:</label></h4>
                            <h5 style="display:inline-block; font-size:1.2em;"><asp:Label runat="server" ID="codigo"> </asp:Label></h5>
                            <h5 style="display:inline-block; font-size:1.1em; margin-left: 10px;"><asp:Label runat="server" ID="status"> </asp:Label></h5>
                         </div>  
                         <div class="form-group" runat="server">
                            <h4 style="display:inline-block; margin-right:5px;"><label for="compania">Compañía:</label></h4>
                            <h5 style="display:inline-block; font-size:1.2em;"><asp:Label runat="server" ID="compania"> </asp:Label></h5>
                        </div>   

                        <div class="form-group col-md-8" runat="server">
                            <h4 style="margin-bottom:-2px"><label for="Descripcion">Descripción</label></h4>
                            -
                            <asp:Literal runat="server" ID="descripcion"> </asp:Literal>
                        </div>

                        <div class="form-group col-md-6" runat="server">
                            <h4 style="display:inline-block;"><label for="Requerimientos">Requerimientos</label></h4>
                            <div><h5><asp:Label runat="server" ID="requerimientos"> </asp:Label></h5></div>
                        </div>    
                       
                        <div class="form-group col-md-10" runat="server">
                            <h4 style="display:inline-block; margin-right: 5px;"><label for="duracion">Duración:</label></h4>
                            <h5 style="display:inline-block;"><asp:Label runat="server" ID="duracion"> </asp:Label></h5>
                        </div>

                        <div class="form-group col-md-3" runat="server">
                            <h4 style="display:inline-block; margin-right: 5px;"><label for="costo">Costo:</label></h4>
                            <h5 style="display:inline-block;"><asp:Label runat="server" ID="costo"> </asp:Label></h5>
                        </div>

                        <div class="form-group col-md-6" runat="server">
                            <h4 style="display:inline-block; margin-right: 5px;"><label for="acuerdopago">Acuerdo de pago:</label></h4>
                            <h5 style="display:inline-block;"><asp:Label runat="server" ID="acuerdopago"> </asp:Label></h5>
                        </div>

                       </div>  
                                                
                     </div> 
                   </div><!-- /.box-body -->
                    
                 
                    <div class="box-footer" runat="server">
                        <a href="ConsultarPropuesta.aspx" class="btn btn-default pull-left">Regresar</a>
                    </div>

                </div>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
       
</asp:Content>
