<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="EjemploM7.aspx.cs" Inherits="Tangerine.GUI.M7.EjemploM7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Facturación
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Factura
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Ejemplo</a></li>
    <li class="active">Facturación</li>
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
                  <h3 class="box-title">Generar Factura</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form">
                  <div class="box-body">

                    <div class="form-group">
                      <label for="labelNumeroFactura_M8">Número Factura</label>
                      <input type="text" class="form-control" id="textNumeroFactura_M8" placeholder="Número Factura" disabled ="disabled" >
                    </div>

                    <div class="form-group">
                      <label for="labelFecha_M8">Fecha</label>
                      <input type="date" class="form-control" id="textFecha_M8" placeholder="Fecha" disabled ="disabled">
                    </div>

                      <div class="form-group">
                      <label for="labelCompañia_M8">Compañía</label>
                      <input type="text" class="form-control" id="textCompañia_M8" placeholder="Compañía" disabled ="disabled" >
                    </div>

                        <div class="form-group">
                      <label for="labelProyecto_M8">Proyecto</label>
                      <input type="text" class="form-control" id="textProyecto_M8" placeholder="Proyecto" disabled ="disabled" >
                    </div>

                      
                        <div class="form-group">
                      <label for="labelMonto_M8">Monto</label>
                      <input type="text" class="form-control" id="textMonto_M8" placeholder="Monto" disabled ="disabled" >
                    </div>

                  </div><!-- /.box-body -->

                  <div class="box-footer">
                 <a id="buttomCancela_M8" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="#">Cancelar</a>
                    <asp:Button id="buttomGenerar_M8" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Generar"   ></asp:Button>
                  </div>
                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6">
      
          </div>
</asp:Content>
