<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AnularFacturaM8.aspx.cs" Inherits="Tangerine.GUI.M8.AnularFacturaM8" %>

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
        <div class="col-md-6" runat="server">
            <!-- general form elements -->
            <div class="box box-primary" runat="server">
                <div class="box-header with-border" runat="server">
                    <h3 class="box-title">Anular Factura</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form" runat="server">
                    <div class="box-body" runat="server">

                        <div class="form-group" runat="server">

                            <div class="form-group" runat="server">
                                <h4>
                                    <label for="labelNumeroFactura_M8">Número Factura</label></h4>
                                <!-- <input runat="server" class="form-control" id="textNumeroFactura_M8" name="textNumeroFactura_M8" disabled="disabled">-->
                               <div> <h4>
                                    <asp:Literal runat="server" ID="NumeroFactura"> </asp:Literal></h4> </div>
                            </div>

                            <div class="form-group" runat="server">
                                <h4>
                                    <label for="labelFecha_M8">Fecha de facturación</label></h4>
                                <!--<input type="date" runat="server" class="form-control" id="textFecha_M8" name="textFecha_M8" placeholder="Fecha" disabled="disabled">-->
                               <div> <h4>
                                    <asp:Literal runat="server" ID="Fecha"> </asp:Literal></h4> </div>
                            </div>

                            <div class="form-group" runat="server">
                                <h4>
                                    <label for="labelCliente_M8">Compañía</label></h4>
                                <!--<input type="text" runat="server" class="form-control" id="textCliente_M8" name="textCliente_M8" placeholder="Cliente" disabled="disabled">-->
                              <div>  <h4>
                                    <asp:Literal runat="server" ID="Compania"> </asp:Literal></h4> </div>
                            </div>

                            <div class="form-group" runat="server">
                                <h4>
                                    <label for="labelProyecto_M8">Proyecto</label></h4>
                                <!--  <input type="text" runat="server" class="form-control" id="textProyecto_M8" name="textProyecto_M8" placeholder="Proyecto" disabled="disabled">-->
                             <div>   <h4>
                                    <asp:Literal runat="server" ID="Proyecto"> </asp:Literal></h4> </div>
                            </div>

                            <div class="form-group" runat="server">
                                <h4>
                                    <label for="labelDescripcion_M8">Descripción</label></h4>
                                <!--<input type="text" runat="server" class="form-control" id="textDescripcion_M8" name="textDescripcion_M8" placeholder="Descripción" disabled="disabled">-->
                              <div>  <h4>
                                    <asp:Literal runat="server" ID="Descripcion"> </asp:Literal></h4> </div>
                            </div>

                            <%--    <div class="form-group" runat="server">
                      <label for="labelEstatus_M8">Estatus</label>
                     <select runat="server" class="form-control" id="textEstatus_M8" name="textEstatus_M8"> 
                     <option>Por Pagar</option>
                     <option>Pagada</option>
                     <option>Anulada</option> 
                     </select>
                    </div> --%>

                            <div class="form-group" runat="server">
                                <h4>
                                    <label for="labelMonto_M8">Monto</label></h4>
                                <!--<input type="text" runat="server" class="form-control" id="textMonto_M8" name="textMonto_M8" placeholder="Monto" disabled="disabled">-->
                              <div>  <h4>
                                    <asp:Literal runat="server" ID="Monto"> </asp:Literal></h4> </div>
                            </div>

                            <div class="form-group" runat="server">
                                <asp:Button ID="buttonAnular_M8" Style="margin-top: 5%" class="btn btn-danger" type="submit" runat="server" Text="Anular" OnClick="buttonAnularFactura_Click"></asp:Button>
                            </div>
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
</asp:Content>
