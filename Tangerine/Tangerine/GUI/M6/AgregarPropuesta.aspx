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
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuesta</a></li>
    <li class="active">Agregar Propuesta</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Modal -->
        <div class="modal fade" id="reqModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Detalle Propuesta </h4>
                    </div>
                    <div class="modal-body">


                        <!-- form start -->

                        <div id="puntosMinuta" class="list-group col-xs-12 col-md-8 col-lg-6">
                    <div id="1-pun-div" class="panel panel-default panel-punto">
                        <div class="panel-body panel-minuta">
                            <div class="col-xs-12">
                                <button type="button" id="1-pun" class="close" data-dismiss="alert" aria-label="Close" onclick="borrarPunto(this);"><span aria-hidden="true">×</span></button>
                                <input class="form-control" placeholder="Título del Punto" type="text">
                            </div>
                            <div class="col-xs-12 form-group"></div>
                            <div class="col-xs-12"><textarea name="desarrollo" placeholder="Desarrollo del Punto" class="form-control" style="text-align: justify;resize:none;" rows="3"></textarea></div>
                        </div>
                    </div>
                </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                    </div><!-- /.box-footer -->

                    </div>



                </div>
             
            </div>
        </div>
       <!-- Fin Modal -->
    

    <div class="col-md-6">

        <div class="box box-primary">

            <!-- form start -->
            <form role="form">

                <div class="box-body">

                    <div class="form-group">

                        <label>Cliente (compañía contratante)</label>
                        <select class="form-control">
                            <option>Trascend</option>
                            <option>Tebca</option>
                            <option>Trascend</option>
                            <option>Pepsi</option>
                        </select>



                    </div>

                    <div class="form-group">
                        <label>Objeto del proyecto</label>
                        <textarea class="form-control" rows="3" placeholder="Escribir ..."></textarea>
                    </div>

                    <div class="form-group">
                        <label>Requerimientos</label>
                        <input type="text" class="form-control" id="reque" placeholder="Agregar Requerimientos" data-toggle="modal" data-target="#reqModal">
                        <%--<h1 onclick="this.innerHTML='Ooops!'">Click on this text!</h1>--%>
                        <%-- <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" ></button>--%>
                    </div>



                    <!-- Date range -->
                    <div class="form-group">
                        <label>Fecha Estimada        Inicio - Fin :</label>
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
                        <input type="text" class="form-control" id="horas_id" placeholder="Horas de trabajo">
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



                </div>

                <div class="box-foot">
                    <button type="submit" class="btn btn-primary">Agregar</button>
                </div>

            </form>

        </div>

    </div>






</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
