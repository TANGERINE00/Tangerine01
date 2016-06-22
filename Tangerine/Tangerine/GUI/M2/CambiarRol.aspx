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

    <div class="row" runat="server">
        <div class="col-md-12" runat="server">
            <div class="box box-primary" runat="server">
                <form role="form" runat="server" method="post" name="consulta_factura" id="consulta_factura">
                    <div class="box-header with-border" runat="server">
                        <h3 class="box-title">Modificacion de Roles</h3>
                        <div class="box-tools" runat="server">
                        <div class="input-group input-group-sm" style="width: 150px;" runat="server">
                            <input name="table_search" class="form-control pull-right" id="textBuscarNombre" placeholder="Nombre Usuario" type="text" runat="server">

                                <div class="input-group-btn">
                                    <asp:LinkButton type="submit" runat="server" ID="btnRun" Text="<i class='fa fa-search' ></i>" 
                                        ValidationGroup="edt" OnClick="busquedaNombre_Click" class="btn btn-default" />
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
                </form>
            </div>
        </div>
    </div>

</asp:Content>
