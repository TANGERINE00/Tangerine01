﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" 
    CodeBehind="FacturasPorPagar.aspx.cs" Inherits="Tangerine.GUI.M9.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestion de Pagos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Lista de facturas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="/GUI/M1/Dashboard.aspx"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Pagos</a></li>
    <li><a href="SeleccionCompania.aspx">Seleccion de compania</a></li>
    <li class="active">Consulta de facturas por pagar</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id="alert" runat="server">
   </div>
    <div class="box">
        <div class="box-header">
            <h3 class="box-title">Consulta de facturas</h3>
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
            <!-- /.box-header -->
            <div class="box-body table-responsive no-padding">
                <div style="float: right; padding-top: 5px;">
                    <a style="margin-right: 10px;">Buscador</a>
                    <input id="searchTerm" type="text" onkeyup="doSearch()" />
                </div>
                <!--<table class="table table-hover">-->
                <table id="example2" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th style="text-align: center;">N° Factura</th>
                            <th style="text-align: center;">Fecha Factura</th>
                            <th style="text-align: center;">Estatus Factura</th>
                            <th style="text-align: center;">Proyecto</th>
                            <th style="text-align: center;">Monto</th>
                            <th style="text-align: center;">Pagar</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal runat="server" ID="tabla"></asp:Literal>
                    </tbody>
                </table>
            </div>
            <!-- /.box-body -->
    </div>
    <!-- /.box -->
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
