<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="InicioCompania.aspx.cs" Inherits="Tangerine.GUI.M4.InicioCompania" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Compañias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li class="active">Gestión de Compañias</li>
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
                  <h3 class="box-title">Seleccione la acción a realizar</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form">
                    <div class="box-footer">
                        <asp:Button 
                          ID="Button1" 
                          type="submit" class="btn btn-primary col-md-4"
                          PostBackUrl="ConsultarCompania.aspx"
                          runat="server"
                          Text="Consultar" 
                            />  
                    </div>
                    <div class="box-footer">
                         <asp:Button 
                          ID="Button2" 
                          type="submit" class="btn btn-primary col-md-4"
                          PostBackUrl="AgregarCompania.aspx"
                          runat="server"
                          Text="Agregar" 
                            />  
                    </div>
                    <div class="box-footer">
                        <asp:Button 
                          ID="Button3" 
                          type="submit" class="btn btn-primary col-md-4"
                          PostBackUrl="ModificarCompania.aspx"
                          runat="server"
                          Text="Modificar" 
                            />  
                    </div>
                    <div class="box-footer">
                         <asp:Button 
                          ID="Button4" 
                          type="submit" class="btn btn-primary col-md-4"
                          PostBackUrl="HabilitarCompania.aspx"
                          runat="server"
                          Text="Habilitar/Inhabilitar" 
                            />  
                    </div>

                    <!-- 
                    <div class="box-footer">
                        <a href="#">Consultar datos de una compañía</a>
                    </div>
                    <div class="box-footer">
                        <a href="#">Registrar nueva compañía</a>
                    </div>
                    <div class="box-footer">
                        <a href="#">Modificar datos de una compañía</a>
                    </div>
                    <div class="box-footer">
                        <a href="#">Habilitar o Inhabilitar una compañía registrada</a>
                    </div>
                    -->
                    
                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>
</asp:Content>
