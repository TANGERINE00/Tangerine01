<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="InformacionProyecto.aspx.cs" Inherits="Tangerine.GUI.M7.InformacionProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Proyecto
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Información de Proyecto
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Proyectos</a></li>
    <li class="active">Informacion Proyecto</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Información de Proyecto</h3>
                    <div class="box-tools">
                    </div>
                </div>
                <!-- /.box-header -->
                <!-- table start -->
                <div class="box-body table-responsive no-padding">

                    <div class="box-body" runat="server">
                        <div class="form-group" runat="server">
                            <h3>
                                <label for="NombrePropuesta1">Nombre de la Propuesta</label></h3>
                            <div>
                                <h4>
                                    <asp:Literal runat="server" ID="NombrePropuesta"> </asp:Literal></h4>
                            </div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3>
                                <label for="NombreProyecto1">Nombre del Proyecto</label></h3>
                            <div>
                                <h4>
                                    <asp:Literal runat="server" ID="NombreProyecto"> </asp:Literal></h4>
                            </div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3>
                                <label for="CodigoProyecto1">Codigo del Proyecto</label></h3>
                            <div>
                                <h4>
                                    <asp:Literal runat="server" ID="CodigoProyecto"> </asp:Literal></h4>
                            </div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3>
                                <label for="FechaInicio1">Fecha de Inicio del Proyecto</label></h3>
                            <div>
                                <h4>
                                    <asp:Literal runat="server" ID="FechaInicio"> </asp:Literal></h4>
                            </div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3>
                                <label for="FechaFin1">Fecha Estimada de culminacion</label></h3>
                            <div>
                                <h4>
                                    <asp:Literal runat="server" ID="FechaFin"> </asp:Literal></h4>
                            </div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3>
                                <label for="Costo1">Costo del Proyecto</label></h3>
                            <div>
                                <h4>
                                    <asp:Literal runat="server" ID="Costo"> </asp:Literal></h4>
                            </div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3>
                                <label for="Porcentaje1">Porcentaje de realizacion</label></h3>
                            <div>
                                <h4>
                                    <asp:Literal runat="server" ID="Porcentaje"> </asp:Literal></h4>
                            </div>
                        </div>
                        <div class="form-group" runat="server">
                            <h3>
                                <label for="Estatus1">Estatus</label></h3>
                            <div>
                                <h4>
                                    <asp:Literal runat="server" ID="Estatus"> </asp:Literal></h4>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->


                <div class="box-footer" runat="server">
                    <a href="ConsultaProyecto.aspx" class="btn btn-default pull-left">Regresar</a>
                </div>

            </div>
        </div>
        <!-- /.box -->

    </div>
    <!--/.col (left) -->
    </div>
</asp:Content>
