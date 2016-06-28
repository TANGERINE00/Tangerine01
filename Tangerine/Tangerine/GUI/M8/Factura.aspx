<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="Tangerine.GUI.M8.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="Javascript">
        function imprSelec(nombre) {
            var ficha = document.getElementById(nombre);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            ventimp.print();
            ventimp.close();
        }
	</script>
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
    <div id="alert" runat="server">
    </div>
    <div class="row">
        <!-- left column -->
        <div id="Div1" class="col-md-6">
            <!-- general form elements -->
            <div id="Div2" class="box box-primary" style="height:350px !important;">



                <div id="imprimirbody" class="box" style="text-align:center;">

                    <div id="Div3" class="box-header" style="text-align:center;">
                        <h3 class="box-title">TANGERINE CA</h3>
                    </div>



                    <!-- /.box-header -->
                        <div id="Div4" class="box-body with-border">
                            <div style="width:80%; height:70px; margin-left:10%;">
                                <div style="float:left;">
                                    <div id="Div5">
                                        <label for="labelNumeroFactura_M8">Factura N°</label>
                                        <asp:Literal runat="server" ID="textNumeroFactura_M8"></asp:Literal>
                                    </div>
                                    <div id="Div6">
                                        <label for="labelFecha_M8">Fecha:</label>
                                        <asp:Literal runat="server" ID="textFecha_M8"></asp:Literal>
                                    </div>
                                </div>
                                <div style="float:right;">
                                    <div id="Div7">
                                        <label for="labelCliente_M8">Compañía:</label>
                                        <asp:Literal runat="server" ID="textCliente_M8"></asp:Literal>
                                    </div>
                                    <div>
                                        <label for="labelCliente_M8">Rif: </label>
                                        <asp:Literal runat="server" ID="textRif_M8"></asp:Literal>
                                    </div>
                                    <div>
                                        <label for="labelCliente_M8">Telefono: </label>
                                        <asp:Literal runat="server" ID="textDireccion_M8"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="box-body">
                                <table class="table-bordered">
                                    <tbody>
                                        <tr>
                                            <th style="width: 30px;text-align:center;">#</th>
                                            <th style="width: 150px;text-align:center;">Proyecto</th>
                                            <th style="width: 500px;text-align:center;">Descripción</th>
                                            <th style="width: 80px;text-align:center;">Precio</th>
                                        </tr>
                                        <tr>
                                            <td>1.</td>
                                            <td><asp:Literal runat="server" ID="textProyecto_M8"></asp:Literal></td>
                                            <td><asp:Literal runat="server" ID="textDescripcion_M8"></asp:Literal></td>
                                            <td><asp:Literal runat="server" ID="textMonto_M8"></asp:Literal></td>
                                        </tr>
                                        <tr>
                                            <td>2.</td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>3.</td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="4" style="text-align:right;">
                                                <asp:Literal runat="server" ID="textIva_M8"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align:right;">
                                                <asp:Literal runat="server" ID="textTipoMoneda_M8"></asp:Literal>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>

                            

                            

                            


                        </div>
                    <!-- /.box-header -->


                </div>





                    <div id="Div12" style="text-align:center; ">
                        <a id="imprimir" href="javascript:imprSelec('imprimirbody')" class="btn btn-primary" style="margin-right:15px;">Imprimir</a>
                        <a class="btn btn-default" href="ConsultarFacturaM8.aspx" style="width:77px;">Volver</a>
                    </div>
            </div>
            <!-- /.box -->

        </div>
    </div>
        <!--/.col (left) -->
        <!-- right column -->
        <div class="col-md-6">
        </div>
</asp:Content>
