<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.ModificarPropuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Propuestas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar Propuesta
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuestas</a></li>
    <li class="active">listado de propuestas</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">

    <div class="col-md-6">

        <script type="text/javascript" language="javascript">
            $(document).ready(function () {
                $("#success-alert").hide();
                $("#myWish").click(function showAlert() {
                    $("#success-alert").alert();
                    $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                        $("#success-alert").alert('close');
                    });
                });
            });

        </script>


        <div class="box box-primary">

            <!-- form start -->
            <form role="form">

                <div class="box-body">

                    <div class="form-group">
                        <label for="input_cliente">Cliente (compañía contratante)</label>
                        <input type="input_cliente" class="form-control" id="cliente_id" placeholder="Trascend" disabled="disabled">
                    </div>

                    <div class="form-group">
                        <label>Objeto del proyecto</label>
                        <textarea class="form-control" rows="3" placeholder="Lorem Ipsum"></textarea>
                    </div>

                    <div class="form-group">
                        <label>Alcance del proyecto ( Breve resumen de  requerimientos)</label>
                        <textarea class="form-control" rows="3" placeholder="Requerimiento 1: Lorem Ipsum"></textarea>
                    </div>




                    <!-- Date range -->
                    <div class="form-group">
                        <label>Periodo de realizacion:</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input type="text" class="form-control pull-right" id="reservation" placeholder="04/14/2016 - 06/15/2016">
                        </div>
                        <!-- /.input group -->
                    </div>
                    <!-- /.form group -->


                    <!-- /.box-body -->

                    <div class="form-group">
                        <label for="input_horas">Horas Trabajadas</label>
                        <input type="input_horas" class="form-control" id="horas_id" placeholder="120 h">
                    </div>

                    <div class="form-group">
                        <label>Estatus</label>
                        <select class="form-control">
                            <option>Aprobado</option>
                            <option>Aprobado</option>
                            <option>Pendiente</option>
                            <option>En ejecucion</option>
                        </select>
                    </div>



                    <label for="input_costo">Costo del Proyecto</label>
                    <div class="input-group">

                        <span class="input-group-addon">$</span>
                        <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)" placeholder="12000">
                        <span class="input-group-addon">.00</span>
                    </div>

                    <div class="form-group">
                        <label>Moneda</label>
                        <select class="form-control">
                            <option>Dolares</option>
                            <option>Dolares</option>
                            <option>Bolivares</option>
                            <option>Bitcoin</option>
                        </select>
                    </div>

                    <div class="form-group">
                        <label>Forma de Pago</label>
                        <select class="form-control">
                            <option>Transferencia</option>
                            <option data-icon="fa-heart">Deposito</option>
                            <option>Transferencia</option>
                            <option>Otro</option>
                        </select>
                    </div>




                    <div class="box-foot">
                        <button  type="submit" class="btn btn-primary" >Modificar</button>
                        <button type="submit" class="btn btn-default pull-right">Atras</button>

                    </div>


            </form>
        </div>

    </div>





</asp:Content>
