<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestion de Propuesta
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar Propuesta
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Propuesta</a></li>
    <li class="active">Agregar Propuesta</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="col-md-6">
     
    <div class="box box-primary">

        <!-- form start -->
        <form role="form">

            <div class="box-body">

                <div class="form-group">
                    <label for="input_cliente">Cliente (compañía contratante)</label>
                    <input type="input_cliente" class="form-control" id="cliente_id" placeholder="Nombre del Cliente">
                </div>

                <div class="form-group">
                    <label>Objeto del proyecto</label>
                    <textarea class="form-control" rows="3" placeholder="Escribir ..."></textarea>
                </div>

                <div class="form-group">
                    <label>Alcance del proyecto ( Breve resumen de  requerimientos)</label>
                    <textarea class="form-control" rows="3" placeholder="Escribir ..."></textarea>
                </div>


            

                    <!-- Date range -->
                    <div class="form-group">
                        <label>Date range:</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input type="text" class="form-control pull-right" id="reservation">
                        </div>
                        <!-- /.input group -->
                    </div>
                    <!-- /.form group -->

             
                <!-- /.box-body -->

                <div class="form-group">
                    <label for="input_horas">Horas de trabajo</label>
                    <input type="input_horas" class="form-control" id="horas_id" placeholder="Horas de trabajo">
                </div>

                <div class="form-group">
                    <label>Estatus</label>
                    <select class="form-control">
                        <option></option>
                        <option>Aprobado</option>
                        <option>Pendiente</option>
                        <option>En ejecucion</option>
                    </select>
                </div>

                

                <label for="input_costo">Costo del Proyecto</label>
                <div class="input-group">
                    
                    <span class="input-group-addon">$</span>
                    <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)">
                    <span class="input-group-addon">.00</span>
                </div>
                
                <div class="form-group">
                    <label>Moneda</label>
                    <select class="form-control">
                        <option></option>
                        <option>Dolares</option>
                        <option>Bolivares</option>
                        <option>Bitcoin</option>
                    </select>
                </div>

                <div class="form-group">
                    <label>Forma de Pago</label>
                    <select class="form-control">
                        <option></option>
                        <option data-icon="fa-heart">Deposito</option>
                        <option>Transferencia</option>
                        <option>Otro</option>
                    </select>
                </div>
                

            <div class="box-foot">
                <button type="submit" class="btn btn-primary" >Agregar</button>
            </div>

        </form>
    </div>
    
</div>

    <script>
        $(function () {

            //Date range picker
            $('#reservation').daterangepicker();

        });
    </script>



    


</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
