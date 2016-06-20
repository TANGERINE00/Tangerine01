<%@ Page Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AccionRegistrar.aspx.cs" Inherits="Tangerine.GUI.M2.AccionRegistrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Rol
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestion Registro Usuario</a></li>
    <li class="active">Usuario</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function validacion() {
            var nombreuser = ContentPlaceHolder1_userDefault.value;
            var param = "{'usuario':'" + nombreuser + "'}";
            $.ajax({
                type: "POST",
                url: "AccionRegistrar.aspx/validarUsuario",
                data: param,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    var local = JSON.stringify(result);
                    var obj = JSON.parse(local);

                    if (obj.d == "Disponible") {
                        document.getElementById("ContentPlaceHolder1_userDefault").style.borderColor = "#00FF00";
                        document.getElementById("ContentPlaceHolder1_btnCrear").disabled = false;
                    } else {
                        document.getElementById("ContentPlaceHolder1_userDefault").style.borderColor = "#FF0000";
                        document.getElementById("ContentPlaceHolder1_btnCrear").disabled = true;
                    }
                },
                failure: function (result) {
                    alert("_");
                }
            });
        }
    </script>

    <div class="row">
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Asignar Rol</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form" runat="server" method="post" name="asignar_rol" id="asignar_rol">
                    <div class="box-body" runat="server">

                        <div class="form-group" runat="server">
                            <label for="labelFicha_M2">Ficha Usuario</label>
                            <input type="text" runat="server" class="form-control" id="textFicha_M2" name="textFicha_M2" placeholder="Ficha" disabled="disabled" required>
                        </div>

                        <div class="form-group">
                            <label for="labelUsuario_M2">Usuario</label>
                            <input type="text" class="form-control" id="userDefault" placeholder="Usuario" runat="server" oninput="javascript:validacion(); setCustomValidity('')" pattern="^[a-zA-Z0-9_.-]*$" required oninvalid="setCustomValidity('Campo inválido o vacío')">
                        </div>

                        <div class="form-group">
                            <label for="labelContraseña_M2">Contraseña</label>
                            <input type="password" class="form-control" id="passwordDefault" placeholder="contraseña" runat="server" oninput="javascript:validacion(); setCustomValidity('')" pattern="^[a-zA-Z0-9_.-]*$" required oninvalid="setCustomValidity('Campo inválido o vacío')">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelRol_M2">Rol</label>
                            <select runat="server" class="form-control" id="textRol_M2" name="textRol_M2" placeholder="Rol">
                                <option>Administrador</option>
                                <option>Director</option>
                                <option>Gerente</option>
                                <option>Programador</option>
                            </select>
                        </div>

                        <div class="box-footer" runat="server">
                            <asp:Button ID="btnCrear" runat="server" Style="margin-top: 5%" class="btn btn-primary" Text="Crear" OnClientClick="return confirm('¿Seguro que desea crear este usuario?');" OnClick="btnCrear_Click"></asp:Button>
                        </div>


                    </div>
                    <!-- /.box-body -->

                    <div class="box-footer" runat="server">
                    </div>
                </form>
            </div>
            <!-- /.box -->

        </div>
        <!--/.col (left) -->
        <!-- right column -->
        <div class="col-md-6" runat="server">
        </div>
    </div>



</asp:Content>
