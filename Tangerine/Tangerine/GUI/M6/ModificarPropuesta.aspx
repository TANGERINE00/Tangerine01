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


   <form role="form" name="agregar_propuesta" id="agregar_propuesta" method="post" runat="server"> 

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

                    <div class="table-responsive">
	    <table id="table-requerimientos" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>ID</th>
					<th style="width: 530px">Requerimiento</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">TOT_RF_1</td>
					<td>El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
			</tbody>


            <tbody>
				<tr>
					<td class="id">TOT_RF_1</td>
					<td>El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
			</tbody>

            <tbody>
				<tr>
					<td class="id">TOT_RF_1</td>
					<td>El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
			</tbody>



		</table>
        <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacute;n de Requerimiento</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el requerimiento:</p>
                    <p id="req"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarRequerimiento()" href="ListarRequerimientos.aspx?success=3">Eliminar</a>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div><!-- /.modal-delete-content -->
        </div><!-- /.modal-delete-dialog -->
      </div><!-- /.modal-delete -->
      <div id="modal-update" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <form id="modificar_requerimientos" class="form-horizontal" method="post" action="Reportes.aspx?success=2">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Modificaci&oacute;n de Requerimiento</h4>
            </div>

            <div class="modal-body">

                <div class="container-fluid">
                <div class="form-group">
				    <div id="div-id" class="col-sm-5 col-md-5 col-lg-5">
					    <input type="text" name="idreq" id="idreq_input" placeholder="ID" class="form-control" disabled="disabled" value="TOT_RF_1"/>
				    </div>
			    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="input-group">
                            <span class="input-group-addon">El sistema deberá </span>
                            <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" style="text-align: justify;resize:vertical;" name="requerimiento" id="input_requerimiento">El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</textarea>
                        </div>
                    </div>
                </div>
                    <br />
                    <div class="form-group">
                        <div class="col-sm-10 col-md-10 col-lg-10">
                            <p><b>Prioridad:</b></p>
                            <label class="radio-inline">
                            <input type="radio" name="radioPrioridad" id="input_prioridad_baja"/>Baja</label>
                            <label class="radio-inline">
                            <input type="radio" name="radioPrioridad" checked="checked" id="input_prioridad_media"/>Media</label>
                            <label class="radio-inline">
                            <input type="radio" name="radioPrioridad" id="input_prioridad_alta"/>Alta</label>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div class="col-sm-10 col-md-10 col-lg-10">
                            <p><b>Status:</b></p>
                            <label class="radio-inline">
                            <input type="radio" name="radioStatus" checked="checked" id="input_status_aprobado"/>Aprobado</label>
                            <label class="radio-inline">
                            <input type="radio" name="radioStatus" id="input_status_pendiente"/>Pendiente</label>
                             <label class="radio-inline">
                            <input type="radio" name="radioStatus" id="input_status_enejecucion"/>En ejecucion</label>
                        </div>
                    </div>

            </div>
            <div class="modal-footer">
              <button id="btn-modificarReq" disabled="disabled" class="btn btn-primary" type="submit" onclick="return checkform();">Modificar</button>
              <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            </div>
          </div><!-- /.modal-update-content -->
        </div><!-- /.modal-update-dialog -->
        </form>
      </div><!-- /.modal-update -->
    </div><!-- table-responsive -->
    <!-- Data tables init -->

                                                                      
             <!-- form estimated date -->
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
                        <label for="input_horas" style="width: 100%; float: left; display: block;">Duracion del Proyecto</label>

                        <div class="input-group input-group">
                            <div class="input-group-btn">

                                <asp:DropDownList ID="comboDuracion" class="btn btn-primary dropdown-toggle" runat="server">
                                </asp:DropDownList>

                            </div>
                            <!-- /btn-group -->
                            <input type="text" class="form-control" id="textoDuracion" runat="server">
                        </div>

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
                      <button type="submit" class="btn btn-primary">Modificar</button>
                      <button type="submit" class="btn btn-default pull-right">Atras</button>

                    </div>
                    
                    </div>
               
                
            </form>

             

        </div>

    </div>


    </form>



</asp:Content>


