<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CambiarRol.aspx.cs" Inherits="Tangerine.GUI.M2.CambiarRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Modificacion de rol de Usuario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Inicio</a></li>
    <li><a href="#">Configuración</a></li>
    <li><a href="#">Usuario</a></li>
    <li class="active">Modificar Rol</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" onload="javascript:ajaxRes()">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Selecciona el rol para el usuario</h4>
                </div>
                <form runat="server" id="form1">
                    <div class="modal-body">
                        <div class="box-body">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Usuario</label>
                                <div class="col-sm-10">
                                    <input type="email" class="form-control" id="usuarioCambiar" placeholder="" runat="server" readonly />
                                </div>
                            </div>
                            <p>&nbsp;</p>
                            <div class="form-group">
                                <label for="exampleInputPassword1" class="col-sm-2 control-label">Rol</label>
                                <div class="col-sm-10">
                                    <select class="form-control" id="rolCambiar" runat="server">
                                        <option>Administrador</option>
                                        <option>Director</option>
                                        <option>Gerente</option>
                                        <option>Programador</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <button id="botonCancelar" type="button" class="btn btn-default pull-left" data-dismiss="modal" runat="server">Cancelar</button>
                            <asp:Button runat="server" ID="botonCambiar" class="btn btn-primary pull-right" OnClick="botonCambiar_Click" Text="Cambiar" />
                            <!-- <button id="botonCambiar2" type="button" class="btn btn-primary pull-right" runat="server" OnClick="botonCambiar_Click">Cambiar</button>-->
                        </div>
                        <!-- /.box-footer -->
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <!--<div class="panel-heading">Filtrar empleados</div>-->
                <div class="box-header with-border">
                    <h3 class="box-title">Lista de empleados sin cuenta de usuario</h3>
                    <div class="box-tools">
                        <div class="input-group input-group-sm" style="width: 150px;">
                            <input name="table_search" class="form-control pull-right" placeholder="Search" type="text">

                            <div class="input-group-btn">
                                <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.box-header -->
                <div class="box-body  table-responsive no-padding">
                    <div class="box-body table-responsive">
                        <table id="example2" class="table table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Nombres</th>
                                    <th>Apellidos</th>
                                    <th>Usuario</th>
                                    <th>Rol</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <asp:Literal runat="server" ID="tablaempleados"></asp:Literal>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                    <!-- /.table-responsive -->
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function ajaxRes() {
            $('.table > tbody > tr > td:nth-child(5) > a')
              .click(function (e) {
                  e.preventDefault();
                  //var prueba = $('.table > tbody > tr > td:nth-child(3)').text();
                  var usuario = $(this).closest("tr").find("td:nth-child(3)").text();
                  var rol = $(this).closest("tr").find("td:nth-child(4)").text();
                  document.getElementById("ContentPlaceHolder1_usuarioCambiar").value = usuario;
                  document.getElementById("ContentPlaceHolder1_rolCambiar").value = rol;
              });
        }
    </script>


</asp:Content>
