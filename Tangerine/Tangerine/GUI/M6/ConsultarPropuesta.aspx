<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.ConsultarPropuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/modulo6.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Propuestas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    listado de propuestas
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuestas</a></li>
    <li class="active">listado de propuestas</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Propuestas</h3>
                </div>
                
                <form role="form" name="consultar" id="consultar">

                    <div class="box-body table-responsive no-padding">
                        <div style="float: right; padding-top: 5px;">
                            <a style="margin-right: 10px;">Buscador</a>
                            <input id="searchTerm" type="text" onkeyup="doSearch()" />
                        </div>
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Codigo Propuesta</th>
                                    <th>Cliente</th>
                                    <th>Fecha Estimada Inicio</th>
                                    <th>Estatus</th>
                                    <th>Moneda</th>
                                    <th>Costo</th>
                                    <th style="text-align: center;">Acciones</th>
                                </tr>
                            </thead>
                            <asp:Literal ID="tablaP" runat="server"></asp:Literal>
                        </table>

                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>


</asp:Content>
