<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.ModificarPropuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/Modificar.js") %>"></script>
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
            float: left;
            position: relative;
            width: 100%;
        }

        .content-wrapper {
            float: left;
        }

        .input-group, .form-control {
            width: 95%;
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


        .dropdown .btn {
            width: 95%;
        }
    </style>




    <form role="form" name="modificar_propuesta" id="modificar_propuesta" method="post" runat="server">

        <div class="col-md-6">

            <div class="box box-primary" style="height: auto">

                <div class="box-body">

                    <div class="form-group">
                       <label for="cliente_id">Cliente (compañía contratante)</label>
                        <input class="form-control" id="cliente_id" runat="server" disabled="disabled">
                    </div>

                 <div class="form-group">
                        <label>Objeto del proyecto</label>
                        
                        <textarea  rows="3" placeholder="Escribir ..." runat="server" pattern="^[A-z ,.()]+$"  class="form-control" 
                            id="descripcion" name="descripcion" required oninvalid="setCustomValidity('Campo obligatorio')" 
                            oninput="setCustomValidity()" onchange="validarTextArea(this.id)"></textarea>
			
                    </div>
                  

                    <div class="table-responsive">
                        <table id="table-requerimientos" class="table table-striped table-hover">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th style="width: 530px">Requerimiento</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <asp:Literal runat="server" ID="requerimientos"> </asp:Literal>>
                        </table>
                    </div>

                


                <!-- /.box-body -->

                <div class="form-group">
                    <label for="input_horas" style="width: 100%; float: left; display: block;">Duracion del Proyecto</label>

                    <div class="input-group input-group">
                        <div class="input-group-btn">


                                <select ID="comboDuracion" class="btn btn-primary dropdown-toggle" runat="server" 
                                    AutoPostBack="true" clientidmode="static"
                                    onchange="enableDeFechas(this.id, 'datepicker1', 'datepicker2', 'textoDuracion')">
                                    <option value="Meses">Meses</option>
                                    <option value="Dias">Dias</option>
                                    <option value="Custom">Custom</option>
                                </select>

                        </div>
                        <!-- /btn-group -->
                           <input type="text" class="form-control" ID="textoDuracion" name="duracion" runat="server" 
                                pattern="^[0-9]{1,3}$" title="Introduzca un numero" required clientidmode="static"
                                oninvalid="setCustomValidity('Campo obligatorio, solo puede tener números (maximo 3 digitos)')" 
                                oninput="setCustomValidity('')" 
                                onchange="setFechas(this.id, 'datepicker1', 'datepicker2', 'comboDuracion')"> </div>

                </div>


                    <div class="form-group date">
                        <label>Fecha estimada Incio:</label>

                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input class="form-control pull-right" id="datepicker1" type="text" runat="server" 
                                onchange="setFechasMesesYDias()" clientidmode="static">
                        </div>
                    <!-- /.input group -->
                </div>



               <div class="form-group date">
                        <label>Fecha estimada Final:</label>

                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input class="form-control pull-right" id="datepicker2" type="text" runat="server" 
                                onchange="setFechasCustom()" clientidmode="static" >
                        </div>
                        <!-- /.input group -->
                    </div>


                <div class="input-group input-group">
                    <label for="comboTipoCosto" style="width: 100%; float: left; display: block;">Costo del Proyecto</label>

                    <div class="input-group input-group">
                        <div class="input-group-btn">
                              <select ID="comboTipoCosto" class="btn btn-primary dropdown-toggle" runat="server" 
                                    AutoPostBack="true" clientidmode="static">
                                    <option value="Bolivar">Bolivar</option>
                                    <option value="Euro">Euro</option>
                                    <option value="Dolar">Dolar</option>
                                    <option value="Bitcoin">Bitcoin</option>
                                </select>
                        </div>
                        <!-- /btn-group -->
                         <input type="text" class="form-control" id="textoCosto" name="costo" runat="server" 
                                pattern="^[0-9]{1,10}$" title="Costo de la propuesta" required 
                                oninvalid="setCustomValidity('Campo obligatorio, solo puede tener números (maximo 10 digitos)')" 
                                oninput="setCustomValidity('')">
                     </div>

                </div>




                <%-- Forma de pago combo--%>

                <div class="form-group">
                    <label>Forma de Pago</label>
                    <div class="dropdown" runat="server" id="fpago2">
                       <div class="dropdown" runat="server" id="fpago">
                            <select ID="formaPago" class="btn btn-default dropdown-toggle" runat="server" 
                                onchange="setCuotas()" clientidmode="static">
                                <option value="Mensual">Mensual</option>
                                <option value="Por cuotas">Por Cuotas</option>
                            </select>
                        </div>
                    </div>
                </div>

                <%-- Cuota combo--%>

                <div class="form-group">
                        <label>Cantidad Cuotas</label>
                        <div class="dropdown" runat="server" id="cuota">
                            <input type="text" pattern="^[0-9]{1,2}$" title="Numero de cuotas (maximo 2 numeros)" class="form-control" 
                                id="cantidadCuotas" name="cantidadCuotas" runat="server" clientidmode="static">
                        </div>
                    </div>



                <%-- Estatus combo--%>
                <div class="input-group input-group">
                    <label for="comboEstatus" style="width: 100%; float: left; display: block;">Estatus</label>
                    <div class="dropdown" runat="server" id="contenedorEstatus">
                         <select ID="comboEstatus" class="btn btn-default dropdown-toggle" runat="server" 
                                 clientidmode="static">
                                <option value="Pendiente">Pendiente</option>
                                <option value="Aprobado">Aprobado</option>
                             <option value="Cerrado">Cerrado</option>
                            </select>

                    </div>
                </div>
                
                <Br>
                <Br>
                
                
                <div class="box-footer" runat="server">                   
                    

                    <asp:Button ID="botonModificarPro" class="btn btn-primary"
                        type="submit" runat="server"
                        Text="Modificar" OnClick="ModificarPropuesta_Click"></asp:Button>
                 
                        <a href="ConsultarPropuesta.aspx" class="btn btn-default pull-right">Regresar</a>               
                    

                </div>

            </div>

            </div>
    </form>
    
   
</asp:Content>


