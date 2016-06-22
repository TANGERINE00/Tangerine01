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
    <li><a href="#"><i class="fa fa-home"></i></a></li>
    <li><a href="#">Ejemplo</a></li>
    <li class="active">Página en blanco</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="alert" runat="server">
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Contactos Existentes</h3>
                    <div class="box-tools"></div>
                </div>
                <form role="form" name="consultar" id="consultar">
                    <script language="javascript">
                        function doSearch() {
                            var tableReg = document.getElementById('example2');
                            var searchText = document.getElementById('searchTerm').value.toLowerCase();
                            for (var i = 1; i < tableReg.rows.length; i++) {
                                var cellsOfRow = tableReg.rows[i].getElementsByTagName('td');
                                var found = false;
                                for (var j = 0; j < cellsOfRow.length && !found; j++) {
                                    var compareWith = cellsOfRow[j].innerHTML.toLowerCase();
                                    if (searchText.length == 0 || (compareWith.indexOf(searchText) > -1)) {
                                        found = true;
                                    }
                                }
                                if (found) {
                                    tableReg.rows[i].style.display = '';
                                } else {
                                    tableReg.rows[i].style.display = 'none';
                                }
                            }
                        }
                    </script>
                    <div class="box-body table-responsive no-padding">
                        <div style="float: right; padding-top: 5px;">
                            <a style="margin-right: 10px;">Buscador</a>
                            <input id="searchTerm" type="text" onkeyup="doSearch()" />
                        </div>
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr style="font-size: 18px;">
                                    <th>Número Ficha</th>
                                    <th>Nombre</th>
                                    <th>Apellido</th>
                                    <th>Cédula</th>
                                    <th>Cargo</th>
                                    <th style="width: 150PX; text-align: center;">Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal runat="server" ID="tabla"></asp:Literal>
                            </tbody>
                        </table>
                        <div style="text-align: center;">
                            <asp:Literal runat="server" ID="volver"></asp:Literal>
                            <asp:Literal runat="server" ID="nuevocontacto"></asp:Literal>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
