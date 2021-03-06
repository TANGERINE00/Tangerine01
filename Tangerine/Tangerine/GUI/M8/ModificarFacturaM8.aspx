﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarFacturaM8.aspx.cs" Inherits="Tangerine.GUI.M8.ModificarFacturaM8" %>

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
    <li class="active">FacturaFacturaFacturaFacturaFactura</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="alert" runat="server">
    </div>
    <div class="row">
        <!-- left column -->
        <div class="col-md-6" runat="server">
            <!-- general form elements -->
            <div class="box box-primary" runat="server">
                <div class="box-header with-border" runat="server">
                    <h3 class="box-title">Modificar Factura</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form" runat="server">
                    <div class="box-body" runat="server">

                        <div class="form-group" runat="server">
                            <label for="labelNumeroFactura_M8">Número Factura</label>
                            <input runat="server" class="form-control" id="textNumeroFactura_M8" name="textNumeroFactura_M8" disabled="disabled">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelFecha_M8">Fecha de facturación</label>
                            <input type="text" runat="server" class="form-control" id="textFecha_M8" name="textFecha_M8" placeholder="Fecha de facturación" disabled="disabled">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelCliente_M8">Compañía</label>
                            <input type="text" runat="server" class="form-control" id="textCliente_M8" name="textCliente_M8" placeholder="Compañía" disabled="disabled">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelProyecto_M8">Proyecto</label>
                            <input type="text" runat="server" class="form-control" id="textProyecto_M8" name="textProyecto_M8" placeholder="Proyecto" disabled="disabled">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelDescripcion_M8">Descripción<a style="color:rgb(255, 0, 0);">*</a></label>
                            <input type="text" runat="server" class="form-control" pattern="^[0-9a-zA-Z ]+$" id="textDescripcion_M8" 
                                name="textDescripcion_M8" maxlength="50" required 
                                oninvalid="setCustomValidity('Campo obligatorio, no puede tener símbolos')" oninput="setCustomValidity('')">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelMonto_M8">Monto</label>
                            <input type="text" runat="server" class="form-control" id="textMonto_M8" name="textMonto_M8" placeholder="Monto" disabled="disabled">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelTipoMoneda_M8">Tipo de Moneda</label>
                            <input type="text" runat="server" class="form-control" id="textTipoMoneda_M8" name="textTipoMoneda_M8" placeholder="Tipo de Moneda" disabled="disabled">
                        </div>

                        <div class="form-group" runat="server" style="text-align:center;">
                            <asp:Button ID="buttonModificar_M8" Style="margin-top: 5%; margin-right:15px;" class="btn btn-primary" type="submit" runat="server" Text="Modificar" OnClick="buttonModificarFactura_Click"></asp:Button>
                            <a Style="margin-top: 5%; width:81px;" href="ConsultarFacturaM8.aspx" class="btn btn-default" type="submit">Cancelar</a>
                        </div>

                    </div>
                    <!-- /.box-body -->


                </form>
            </div>
            <!-- /.box -->

        </div>
        </div>
        <!--/.col (left) -->
        <!-- right column -->
        <div class="col-md-6">
        </div>
</asp:Content>
