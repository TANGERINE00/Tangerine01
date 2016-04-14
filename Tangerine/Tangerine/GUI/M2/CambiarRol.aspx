<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CambiarRol.aspx.cs" Inherits="Tangerine.GUI.M2.CambiarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Modificacion de rol de Usuario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
   
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
        function showContent(nick,rol) {
            
            element = document.getElementById("boxCambiarRol");
            element.style.display = 'block';
            element2 = document.getElementById("inputEmail3");
            element2.placeholder = nick;

        }
        function hideContent() {
            element = document.getElementById("boxCambiarRol");
            element.style.display='none';
        }
    </script>
    <div class="row">
            <!-- left column -->
            <div class="col-md-6">
              <!-- TABLE: USUARIOS -->
              <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title">Lista de usuarios del sistema</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <div class="table-responsive">
                    <table class="table no-margin">
                      <thead>
                        <tr>
                          <th>NickName</th>
                          <th>Nombre y Apellido</th>
                          <th>Rol</th>
                          <th></th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td>luarropa</td>
                          <td>Luis Rodríguez</td>
                          <td>Gerente</td>
                          <td><a href="javascript::;" class="btn btn-sm btn-info btn-success pull-left" onclick="javascript:showContent('luarropa','Gerente')">Cambiar Rol</a></td>
                        </tr>
                          <tr>
                          <td>gerastone</td>
                          <td>Gerardo Astone</td>
                          <td>Director</td>
                          <td><a href="javascript::;" class="btn btn-sm btn-info btn-success pull-left" onclick="javascript:showContent('gerastone','Director')">Cambiar Rol</a></td>
                        </tr>
                        <tr>
                          <td>Craloz</td>
                          <td>Carlos Lozano</td>
                          <td>Administrador</td>
                          <td><a href="javascript::;" class="btn btn-sm btn-info btn-success pull-left" onclick="javascript:showContent('Craloz','Administrador')">Cambiar Rol</a></td>
                        </tr>
                      </tbody>
                    </table>
                  </div><!-- /.table-responsive -->
                </div><!-- /.box-body -->
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6" id="boxCambiarRol" style="display:none;">
              <!-- Horizontal Form -->
              <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title">Selecciona el Rol para el usuario</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form class="form-horizontal">
                  <div class="box-body">
                     <div class="form-group">
                      <label for="inputEmail3" class="col-sm-2 control-label">Nickname</label>
                      <div class="col-sm-8">
                        <input type="email" class="form-control" id="inputEmail3" placeholder="nickname" disabled>
                      </div>
                    </div>
                    <p>&nbsp;</p>
                    <div class="form-group">
                      <div class="col-sm-10">
                        <select class="form-control" id="SelecRol">
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
                    <button type="submit" class="btn btn-info pull-right">Cambiar</button>
                  </div><!-- /.box-footer -->
                </form>
              </div><!-- /.box -->              
            </div><!--/.col (right) -->
          </div>
</asp:Content>