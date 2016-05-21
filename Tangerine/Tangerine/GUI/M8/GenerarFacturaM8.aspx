<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="GenerarFacturaM8.aspx.cs" Inherits="Tangerine.GUI.M8.GenerarFacturaM8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Facturación
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Factura
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestion Factura</a></li>
    <li class="active">Factura</li>
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
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form" runat="server" method="post" name="generar_factura" id="generar_factura">
                    <div class="box-body" runat="server">

                        <%--<div class="form-group" runat ="server">
                      <label for="labelNumeroFactura_M8">Número Factura</label>
                      <input type="text" runat="server" class="form-control" id="textNumeroFactura_M8" name="textNumeroFactura_M8" placeholder="Número Factura"  >
                    </div>--%>

                        <div class="form-group" runat="server">
                            <label for="labelFecha_M8">Fecha</label>
                            <input type="text" runat="server" class="form-control" id="textFecha_M8" name="textFecha_M8" placeholder="dd/mm/yyyy" disabled="disabled">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelCliente_M8">Compañía</label>
                            <input type="text" runat="server" class="form-control" id="textCompania_M8" name="textCompania_M8" placeholder="Compañía" disabled ="disabled">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelProyecto_M8">Proyecto</label>
                            <input type="text" runat="server" class="form-control" id="textProyecto_M8" name="textProyecto_M8" placeholder="Proyecto" disabled ="disabled">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelDescripcion_M8">Descripción</label>
                            <input type="text" runat="server" class="form-control" id="textDescripcion_M8" name="textDescripcion_M8" placeholder="Descripción">
                        </div>


                        <div class="form-group" runat="server">
                            <label for="labelMonto_M8">Monto</label>
                            <input type="text" runat="server" class="form-control" id="textMonto_M8" name="textMonto_M8" placeholder="Monto" disabled ="disabled">
                        </div>
                        <div class="box-footer" runat="server">
                            <asp:Button ID="buttonGenerar_M8" Style="margin-top: 5%" class="btn btn-primary" type="submit" runat="server" Text="Generar" OnClick="buttonGenerarFactura_Click"></asp:Button>
                        </div>


                    </div>
                    <!-- /.box-body -->

                    <div class="box-footer" runat="server">
                    </div>
                </form>
            </div>
            <!-- /.box -->

        </div>
        <!--/.col (left) -->
        <!-- right column -->
        <div class="col-md-6" runat="server">
        </div>
    </div>
</asp:Content>
