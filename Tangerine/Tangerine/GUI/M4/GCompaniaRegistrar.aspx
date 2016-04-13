<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="GCompaniaRegistrar.aspx.cs" Inherits="Tangerine.GUI.M4.GCompaniaRegistrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Compañias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Registrar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Compañias</a></li>
    <li><a href="#">Inicio</a></li>
    <li class="active">Registrar</li>
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
                        <button type="submit" class="btn btn-primary">Registrar</button>
                    </div> 
                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>
</asp:Content>
