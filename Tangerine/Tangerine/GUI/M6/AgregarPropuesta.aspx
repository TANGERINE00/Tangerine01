<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.AgregarPropuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/modulo6.js") %>"></script>
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

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

        #div-precondiciones {
            margin-bottom: 20px;
        }

            #div-precondiciones .form-group {
                padding: 15px 0;
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



    <form role="form" name="agregar_propuesta" id="agregar_propuesta" method="post" runat="server">

        <div class="col-md-6" runat="server">

            <div class="box box-primary" style="height: inherit !important" runat="server">

                <!-- form start -->

                <div class="box-body">

                    <div class="form-group">

                        <label>Cliente (compañía contratante)</label>

                        <div class="dropdown" runat="server" id="contenedorCompañias">
                            <asp:DropDownList ID="comboCompañia" class="btn btn-default dropdown-toggle" runat="server">
                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="form-group">
                        <label>Objeto del proyecto</label>
                        
                        <textarea  rows="3" placeholder="Escribir ..." runat="server" pattern="^[A-z ,.()]+$"  class="form-control" 
                            id="descripcion" name="descripcion" required oninvalid="setCustomValidity('Campo obligatorio')" 
                            oninput="setCustomValidity()" onchange="validarTextArea(this.id)"></textarea>
			
                    </div>

                    <div class="form-group">
                        <label>Alcance del Proyecto</label>
                        <div class="form-group">
                            <div id="div-precondiciones" class="col-sm-12 col-md-12 col-lg-12">

                                <div class="form-group">
                                    <div class="col-sm-11 col-md-11 col-lg-11" style="margin-left:-30px;">  
                                        <input runat="server" placeholder="Requerimiento" type="text" title="Descripcion"
                                            pattern="^[A-z ,.()]+$" class="form-control precondicion" id="precondicion_0" 
                                            name="precondicion_0" required 
                                            oninvalid="setCustomValidity('Campo obligatorio, no puede tener números ni símbolos')" 
                                            oninput="setCustomValidity('')" />
                                    </div>            
                                    <div class="col-sm-1 col-md-1 col-lg-1" style="margin-left:-20px;">     
                                        <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" 
                                            onclick="agregarPrecondicion()"></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <input id="arrPrecondicion" type="hidden" class="arrPrecondicion" runat="server" />
                        <%-- <button type="button" onclick="crearPrecondicionArr()">crear </button>--%>
                    </div>

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
                                onchange="setFechas(this.id, 'datepicker1', 'datepicker2', 'comboDuracion')">
                        </div>

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



                    <div class="form-group">
                        <label for="input_horas" style="width: 100%; float: left; display: block;">Costo del Proyecto</label>

                        <div class="input-group input-group">
                            <div class="input-group-btn">

                                <asp:DropDownList ID="comboTipoCosto" class="btn btn-primary dropdown-toggle" runat="server">
                                </asp:DropDownList>

                            </div>
                            <!-- /btn-group -->
                            <input type="text" class="form-control" id="textoCosto" name="costo" runat="server" 
                                pattern="^[0-9]{1,10}$" title="Costo de la propuesta" required 
                                oninvalid="setCustomValidity('Campo obligatorio, solo puede tener números (maximo 10 digitos)')" 
                                oninput="setCustomValidity('')">
                        </div>

                    </div>

                    <div class="form-group">
                        <label>Forma de Pago</label>
                        <div class="dropdown" runat="server" id="fpago">
                            <select ID="formaPago" class="btn btn-default dropdown-toggle" runat="server" 
                                onchange="setCuotas()" clientidmode="static">
                                <option value="Mensual">Mensual</option>
                                <option value="Por cuotas">Por Cuotas</option>
                            </select>
                        </div>
                    </div>



                    <div class="form-group">
                        <label>Cantidad Cuotas</label>
                        <div class="dropdown" runat="server" id="cuota">
                            <input type="text" pattern="^[0-9]{1,2}$" title="Numero de cuotas (maximo 2 numeros)" class="form-control" 
                                id="cantidadCuotas" name="cantidadCuotas" runat="server" clientidmode="static">
                        </div>
                    </div>



                    <div class="form-group">
                        <label>Estatus</label>
                        <div class="dropdown" runat="server" id="contenedorEstatus">
                            <asp:DropDownList ID="comboEstatus" class="btn btn-default dropdown-toggle" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="box-footer" runat="server">
                    <asp:Button ID="btnagregar" class="btn btn-primary"
                        OnClick="btnagregar_Click" OnClientClick="javascript:crearPrecondicionArr()" type="submit" runat="server"
                        Text="Agregar"></asp:Button>
                </div>

            </div>
        </div>

    </form>




</asp:Content>
