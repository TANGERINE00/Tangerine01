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
                <form role="form" id="modificar_proyecto" method="post" runat="server">
                    <div class="box-body table-responsive no-padding">
                        <div class="box-body" runat="server">
                            <div class="row">
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="NombrePropuesta1">Nombre de la Propuesta: </label>
                                    </h4>
                                    <div>
                                        <h5>
                                            <asp:Literal runat="server" ID="NombrePropuesta"> </asp:Literal></h5>
                                    </div>
                                </div>
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="NombreProyecto1">Nombre del Proyecto</label></h4>
                                    <div>
                                        <h5>
                                            <asp:Literal runat="server" ID="NombreProyecto"> </asp:Literal></h5>
                                    </div>
                                </div>
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="CodigoProyecto1">Codigo del Proyecto</label></h4>
                                    <div>
                                        <h5>
                                            <asp:Literal runat="server" ID="CodigoProyecto"> </asp:Literal></h5>
                                    </div>
                                </div>
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="FechaInicio1">Fecha de Inicio del Proyecto</label></h4>
                                    <div>
                                        <h5>
                                            <asp:Literal runat="server" ID="FechaInicio"> </asp:Literal></h5>
                                    </div>
                                </div>
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="FechaFin1">Fecha Estimada de culminacion</label></h4>
                                    <div>
                                        <h5>
                                            <asp:Literal runat="server" ID="FechaFin"> </asp:Literal></h5>
                                    </div>
                                </div>
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="Costo1">Costo del Proyecto</label></h4>
                                    <div>
                                        <h5>
                                            <asp:Literal runat="server" ID="Costo"> </asp:Literal></h5>
                                    </div>
                                </div>
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="Porcentaje1">Porcentaje de realizacion</label></h4>
                                    <div>
                                        <h5>
                                            <asp:Literal runat="server" ID="Porcentaje"> </asp:Literal></h5>
                                    </div>
                                </div>
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="Estatus1">Estatus</label></h4>
                                    <div>
                                        <h5>
                                            <asp:Literal runat="server" ID="Estatus"> </asp:Literal></h5>
                                    </div>
                                </div>
                                <div class="form-group col-md-6" runat="server">
                                    <h4>
                                        <label for="inputPersonal">Personal</label></h4>

                                    <h5>
                                        <select class="form-control" id="inputPersonal" name="inputPersonal" runat="server">
                                        </select></h5>

                                    <h4>
                                        <label for="inputEncargado">Encargado de la empresa contratante</label></h4>
                                    <h5>
                                        <select class="form-control" datatextfield="text" id="inputEncargado" name="inputEncargado" runat="server">
                                        </select></h5>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>

    </div>
    </div>
        <!-- /.box -->

    </div>
    <!--/.col (left) -->
    </div>
</asp:Content>
