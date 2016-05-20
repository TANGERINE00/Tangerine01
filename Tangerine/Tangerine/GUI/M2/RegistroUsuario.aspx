<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="Tangerine.GUI.M2.RegistroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Registro de Usuario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Empleados sin cuenta de usuario asignada
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Ejemplo</a></li>
    <li class="active">Página en blanco</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        function ajaxRes() {
            $('.table > tbody > tr > td:nth-child(6) > a')
                .click(function (e) {
                    e.preventDefault();
                    var nombre = $(this).closest("tr").find("td:nth-child(2)").text();
                    var apellido = $(this).closest("tr").find("td:nth-child(3)").text();
                    var empleadoF = $(this).closest("tr").find("td:nth-child(1)").text();
                    document.getElementById("ContentPlaceHolder1_fichaEmp").value = empleadoF;
                    var param = "{'nombreUsuario':'" + nombre + "','apellidoUsuario':'" + apellido + "'}";
                    $.ajax({
                        type: "POST",
                        url: "RegistroUsuario.aspx/ObtenerUsuarioDefault",
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (result) {
                            var local = JSON.stringify(result);
                            var obj = JSON.parse(local);
                            document.getElementById("ContentPlaceHolder1_userDefault").value = obj.d;
                        },
                        failure: function (result) {
                            alert("_");
                        }
                    });
                });
        }
    </script>

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" onload="javascript:ajaxRes()">

        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Creación de cuenta de usuario</h4>
                </div>
                <form runat="server" ID="form1">
                <div class="modal-body">  
                    
                    <div class="box-body"> 
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-2 control-label">Ficha de empleado</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="fichaEmp" placeholder="" runat="server" readonly="true">
                            </div>
                        </div> 
                        <p>&nbsp;</p>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-2 control-label">Usuario</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="userDefault" placeholder="" runat="server" oninput="userDefault_Input()">
                            </div>
                        </div>
                        <p>&nbsp;</p>
                        <div class="form-group">
                            <label for="inputPassword3" class="col-sm-2 control-label">Contraseña</label>
                            <div class="col-sm-10">
                                <input type="password" class="form-control" id="passwordDefault" placeholder="contraseña" runat="server">
                            </div>
                        </div>
                        <p>&nbsp;</p>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Rol</label>
                            <div class="col-sm-10">
                                <select class="form-control" runat="server" id="rolDefault">
                                    <option>Administrador</option>
                                    <option>Director</option>
                                    <option>Gerente</option>
                                    <option>Programador</option>
                                </select>
                            </div>
                        </div>
                    </div><!-- /.box-body -->
                    <div class="box-footer">
                        
                            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancelar</button>
                            <!--<button id="botonCrear" type="button" class="btn btn-primary pull-right" data-dismiss="modal" runat="server" OnClick="botonCrear_Click">Crear</button>-->
                            <asp:Button runat="server" ID="btnCrear" class="btn btn-primary pull-right" OnClick="btnCrear_Click" Text="Crear"/>
                        
                    </div><!-- /.box-footer -->
                </div>
              </form>
            </div>
        </div>
    </div>
    
    <div class="container-fluid">
        <div class="box box-info">
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

            </div><!-- /.box-header -->
            <div class="box-body">
                <div class="table-responsive">
                    <table class="table no-margin">
                        <thead>
                            <tr>
                                <th>N° Empleado</th>
                                <th>Nombres</th>
                                <th>Apellidos</th>
                                <th>Cédula</th>
                                <th>Cargo</th>
                                <th></th>
                            </tr>
                        </thead>
                        <asp:Literal runat="server" ID="tablaempleados"> </asp:Literal>
                        <tbody>
                           
                        </tbody>
                    </table>
                    <nav>
                        <ul class="pagination">
                            <li>
                                <a href="#" aria-label="Previous">
                                    <span aria-hidden="true">&laquo;</span>
                                </a>
                            </li>
                            <li><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li>
                                <a href="#" aria-label="Next">
                                    <span aria-hidden="true">&raquo;</span>
                                </a>
                            </li>
                        </ul>
                    </nav>
                </div><!-- /.table-responsive -->
            </div>
        </div>
    </div>

    
</asp:Content>