<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.ModificarPropuesta" %>

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


         .dropdown .btn {
            width: 95%;
        }


    </style>


   

   <form role="form" name="agregar_propuesta" id="agregar_propuesta" method="post" runat="server"> 

    <div class="col-md-6">

        <div class="box box-primary" style="height:auto">

            <!-- form start -->
            <form role="form">

                <div class="box-body">

                    <div class="form-group">
                        <label for="input_cliente">Cliente (compañía contratante)</label>
                        <input type="input_cliente" class="form-control" id="cliente_id" placeholder="Trascend" disabled="disabled">
                    </div>

                     <div class="form-group">
                        <label>Objeto del proyecto</label>
                        <textarea class="form-control" rows="3" placeholder="Escribir ..."><%=Prueba.Descripcion%></textarea>
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
			            
            <asp:Literal id="tablaR" runat="server" ></asp:Literal>
             

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
					    <input type="text" name="idreq" id="idreq_input" runat="server" placeholder="ID" class="form-control" disabled="disabled" value="TOT_RF_1"/>
				    </div>
			    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="input-group">
                            <span class="input-group-addon">El sistema deberá </span>
                            <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" runat="server" style="text-align: justify;resize:vertical;" name="requerimiento" id="input_requerimiento">El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</textarea>
                        </div>
                    </div>
                </div>
                    <br />
                


            </div>
            <div class="modal-footer">
              <button id="btn-modificarReq" disabled="disabled" class="btn btn-primary" type="submit">Modificar</button>
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
                  <input class="form-control pull-right" id="datepicker1" value ="<%=Prueba.Feincio%>" type="text">
                </div>
                <!-- /.input group -->
              </div>



                    <div class="form-group date">
                <label>Fecha estimada Final:</label>

                <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                  </div>
                  <input class="form-control pull-right" id="datepicker2" value="<%=Prueba.Fefinal %> " type="text">
                </div>
                <!-- /.input group -->
              </div>


                    <!-- /.box-body -->

                    <div class="form-group">
                        <label for="input_horas" style="width: 100%; float: left; display: block;">Duracion del Proyecto</label>

                        <div class="input-group input-group">
                            <div class="input-group-btn">

                                <asp:DropDownList ID="comboDuracion" class="btn btn-primary dropdown-toggle Comboduracion" runat="server">
                                    
                                </asp:DropDownList>

                            </div>
                            <!-- /btn-group -->
                            <input type="text" class="form-control" id="textoDuracion"  runat="server">
                        </div>

                    </div>


                     <div class="input-group input-group">
                        <label for="input_horas" style="width: 100%; float: left; display: block;">Costo del Proyecto</label>

                        <div class="input-group input-group">
                            <div class="input-group-btn">

                                <asp:DropDownList ID="comboTipoCosto" class="btn btn-primary dropdown-toggle Combotipocosto" runat="server">
                                </asp:DropDownList>

                            </div>
                            <!-- /btn-group -->
                            <input type="text" class="form-control" id="textoCosto" runat="server">
                        </div>

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


                    <div class="input-group input-group">
                        <label for="input_horas" style="width: 100%; float: left; display: block;">Estatus</label>

                        

                        <div class="dropdown" runat="server" id="contenedorEstatus">
                            
                            <asp:DropDownList ID="comboEstatus" class="btn btn-default dropdown-toggle Comboestatus" runat="server">
                            </asp:DropDownList>
                        </div>
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


    <%-- <script src="js/Modificar.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $('#table-requerimientos').DataTable();
	        var table = $('#table-requerimientos').DataTable();
	        var req;
	        var tr;

	        $('#table-requerimientos tbody').on('click', 'a', function () {
	            if ($(this).parent().hasClass('selected')) {
	                req = $(this).parent().prev().prev().prev().prev().text();
	                tr = $(this).parents('tr');//se guarda la fila seleccionada
	                $(this).parent().removeClass('selected');

	            }
	            else {
	                req = $(this).parent().prev().prev().prev().prev().text();
	                tr = $(this).parents('tr');//se guarda la fila seleccionada
	                table.$('tr.selected').removeClass('selected');
	                $(this).parent().addClass('selected');
	            }
	        });
	        $('#modal-delete').on('show.bs.modal', function (event) {
	            var modal = $(this)
	            modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
	            modal.find('#req').text(req)
	        })
	        $('#btn-eliminar').on('click', function () {
	            table.row(tr).remove().draw();//se elimina la fila de la tabla
	            $('#modal-delete').modal('hide');//se esconde el modal
	        });
	        $('#modal-update').on('show.bs.modal', function (event) {
	            var modal = $(this)
	            modal.find('.modal-title').text('Modificar requerimiento')
	        });
	    });
	</script>
    <script>
            function fillCodigoTextField() {
                var idTextField = document.getElementById("idreq_input");
            }
    </script>--%>


</asp:Content>


