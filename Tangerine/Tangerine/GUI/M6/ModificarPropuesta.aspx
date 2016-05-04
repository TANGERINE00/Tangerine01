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

    <style>
        .main-footer {
            float:left;
            position:relative; 
            width:100%;
        }

        .content-wrapper {
            float: left;
        }

        .input-group, .form-control {
            width:95%;
        }

        .date {
            width: 48.5% !important;
            float: left;
        }

        @media only screen and (max-width: 550px) {
            .date {
                width: 100% !important;
                float: left;
            }
        }
    </style>


   

    <div class="col-md-6">

        


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
                        <textarea class="form-control" rows="3" placeholder="Escribir ..."></textarea>
                    </div>
             <!-- form end -->
                                                                      

                     <div class="form-group date">
                <label>Fecha estimada Incio:</label>

                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                  </div>
                  <input class="form-control pull-right" id="datepicker1" type="text">
                </div>
                <!-- /.input group -->
              </div>



                    <div class="form-group date">
                <label>Fecha estimada Final:</label>

                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                  </div>
                  <input class="form-control pull-right" id="datepicker2" type="text">
                </div>
                <!-- /.input group -->
              </div>


                    <!-- /.box-body -->

                    <div class="form-group">
                        <label for="input_horas">Duración del Proyecto</label>
                        <input type="input_horas" class="form-control" id="horas_id" placeholder="120 h">
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



                    <div class="form-group">
                        <label>Estatus</label>
                        <select class="form-control">
                            <option>Aprobado</option>
                            <option>Aprobado</option>
                            <option>Pendiente</option>
                            <option>En ejecucion</option>
                        </select>
                    </div>




                    <div class="box-foot">
                        <button  type="submit" class="btn btn-primary" >Modificar</button>
                        <button type="submit" class="btn btn-default pull-right">Atras</button>

                    </div>

                    </div>
            </form>
        </div>

    </div>


    



</asp:Content>
