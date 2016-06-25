<%@ Page Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CambiarUsuario.aspx.cs" Inherits="Tangerine.GUI.M2.CambiarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Cambiar Usuario
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestion Usuario</a></li>
    <li class="active">Usuario</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="alert" runat="server">
    </div>
    <div class="row">
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Cambiar Usuario</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form" runat="server" method="post" name="cambiar_usuario" id="cambiar_usuario">
                    <div class="box-body" runat="server">

                        <div class="form-group" runat="server">
                            <label for="labelFicha_M2">Ficha del Empleado</label>
                            <input type="text" runat="server" class="form-control" id="textFichaEmpleado_M2" name="textFichaEmpleado_M2" placeholder="Ficha Empleado" disabled="disabled" oninput="setCustomValidity('')" pattern="^[a-zA-Z0-9]*$" required oninvalid="setCustomValidity('Campo obligatorio, solo se admiten letras y números')">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="labelUsuario_M2">Usuario</label>
                            <input type="text" runat="server" class="form-control" id="textUsuario_M2" name="textUsuario_M2" placeholder="Usuario" oninput="setCustomValidity('')" pattern="^[a-zA-Z0-9]*$" required oninvalid="setCustomValidity('Campo obligatorio, solo se admiten letras y números')">
                        </div>

                        <div class="box-footer" runat="server">
                            <asp:Button ID="buttonAsignar_M2" Style="margin-top: 5%" class="btn btn-primary" type="submit" runat="server" Text="Asignar" OnClientClick="return confirm('¿Seguro que desea modificar el nombre de usuario?');" OnClick="buttonAsignar_Click"></asp:Button>
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
