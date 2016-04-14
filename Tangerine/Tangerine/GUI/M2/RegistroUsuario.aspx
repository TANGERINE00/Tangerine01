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
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function showContent() {
            element = document.getElementById("boxCrearUsuario");
            element.style.display='block';
        }
        function hideContent() {
            element = document.getElementById("boxCrearUsuario");
            element.style.display='none';
        }
    </script>
    <div class="row">
            <!-- left column -->
            <div class="col-md-6">
              <!-- TABLE: EMPLEADOS -->
              <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title">Lista de empleados sin cuenta de usuario</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <div class="table-responsive">
                    <table class="table no-margin">
                      <thead>
                        <tr>
                          <th>Id Empleado</th>
                          <th>Nombre y Apellido</th>
                          <th>Cargo</th>
                          <th></th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR9842</a></td>
                          <td>Luis Rodríguez</td>
                          <td>Programador</td>
                          <td><a href="javascript::;" class="btn btn-sm btn-info btn-success pull-left" onclick="javascript:showContent()">Agregar Usuario</a></td>
                        </tr>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR1848</a></td>
                          <td>Carlos Lozano</td>
                          <td>Programador</td>
                          <td><a href="javascript::;" class="btn btn-sm btn-info btn-success pull-left" onclick="javascript:showContent()">Agregar Usuario</a></td>
                        </tr>
                        <tr>
                          <td><a href="pages/examples/invoice.html">OR7429</a></td>
                          <td>Gerardo Astone</td>
                          <td>Gerente</td>
                          <td><a href="javascript::;" class="btn btn-sm btn-info btn-success pull-left" onclick="javascript:showContent()">Agregar Usuario</a></td>
                        </tr>
                      </tbody>
                    </table>
                  </div><!-- /.table-responsive -->
                </div><!-- /.box-body -->
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6" id="boxCrearUsuario" style="display:none;">
              <!-- Horizontal Form -->
              <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title">Creación de cuenta de usuario</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form class="form-horizontal">
                  <div class="box-body">
                     <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Nickname</label>
                      <div class="col-sm-8">
                        <input type="email" class="form-control" id="inputEmail3" placeholder="nickname">
                      </div>
                      <a href="javascript::;" class="btn btn-sm btn-info btn-success pull-left">Verificar</a>
                    </div>
                    <p>&nbsp;</p>
                    <div class="form-group">
                      <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                      <div class="col-sm-10">
                        <input type="password" class="form-control" id="inputPassword3" placeholder="Password">
                      </div>
                    </div>
                    <p>&nbsp;</p>
                    <div class="form-group">
                      <label for="exampleInputPassword1" class="col-sm-2 control-label">Rol</label>
                      <div class="col-sm-10">
                        <select class="form-control">
                             <option>Administrador</option>
                             <option>Director</option>
                             <option>Gerente</option>
                             <option>Programador</option>
                        </select>
                      </div>
                   </div>
                  </div><!-- /.box-body -->
                  <div class="box-footer">
                    <button type="button" class="btn btn-default" onclick="javascript:hideContent()">Cancelar</button>
                    <button type="submit" class="btn btn-info pull-right">Crear</button>
                  </div><!-- /.box-footer -->
                </form>
              </div><!-- /.box -->              
            </div><!--/.col (right) -->
          </div>
</asp:Content>