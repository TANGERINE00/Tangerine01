<%@ Page Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AsignarRol.aspx.cs" Inherits="Tangerine.GUI.M2.AsignarRol" %>

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
    <li><a href="#">Gestion Rol</a></li>
    <li class="active">Rol</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <label for="labelUsuario_M2">Usuario</label>
                            <input type="text" runat="server" class="form-control" id="textUsuario_M2" name="textUsuario_M2" placeholder="Usuario" disabled="disabled">
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
                            <asp:Button ID="buttonAsignar_M2" Style="margin-top: 5%" class="btn btn-primary" type="submit" runat="server" Text="Asignar" OnClientClick="return confirm('¿Seguro que desea este rol al usuario?');" OnClick="buttonAsignar_Click"></asp:Button>
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