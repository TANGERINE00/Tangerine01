<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Agregar proyecto.aspx.cs" Inherits="Tangerine.GUI.M7.WebForm1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Proyectos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Proyectos</a></li>
    <li class="active">Crear Proyecto</li>
</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">

        <!-- form start -->
        <form role="form" runat="server" id="generar_proyecto" method="post">
            <!-- left column -->
            <div class="col-md-6">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Nuevo Proyecto</h3>
                    </div>
                    <!-- /.box-header -->

                    <div class="box-body" runat="server">
                        <div class="form-group" runat="server">
                            <label for="inputPropuesta">Propuesta Aprobada *</label>
                            <asp:DropDownList class="form-control" DataTextField="text" ID="inputPropuesta" name="inputPropuesta" OnSelectedIndexChanged="comboPropuesta_Click" AutoPostBack="True" runat="server">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group" runat="server">
                            <label for="InputNombreProyecto">Nombre de proyecto *</label>
                            <input runat="server" type="text" class="form-control" id="textInputNombreProyecto" placeholder="Nombre Proyecto" name="textInputNombreProyecto">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="InputCodigo">Codigo del proyecto * </label>
                            <input runat="server" type="text" class="form-control" id="textInputCodigo" name="textInputCodigo" placeholder="123456789">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="InputFechaInicio">Fecha de inicio *</label>
                            <input runat="server" type="date" class="form-control" id="textInputFechaInicio" name="textInputFechaInicio" placeholder="dd/mm/aaaa">
                        </div>

                        <div class="form-group" runat="server">
                            <label for="InputFechaEstimada">Fecha Estimada de culminación *</label>
                            <input runat="server" type="date" class="form-control" id="textInputFechaEstimada" name="textInputFechaEstimada" placeholder="dd/mm/aaaa">
                        </div>
                        <div class="form-group" runat="server">
                            <label for="InputCosto">Costo estimado *</label>
                            <input runat="server" type="text" class="form-control" id="textInputCosto" name="textInputCosto" placeholder="0 Bs" Disabled="disabled">
                        </div>
                        <div class="form-group" runat="server">
                            <asp:Button ID="btnAgregarPersonal" Style="margin-top: 5%" class="btn btn-primary" OnClick="btnAgregarPersonal_Click" type="submit" runat="server" Text="Agregar Personal"></asp:Button>
                        </div>
                        <hr />
                    </div>
                    <div class="box-footer">
                        <asp:Button ID="btnGenerar" Style="margin-top: 5%" class="btn btn-primary" OnClick="btnGenerar_Click" type="submit" runat="server" Text="Generar" Enabled="false"></asp:Button>
                    </div>
                    <div>
                        <style>
                            table.lamp {
                                width: 100%;
                                border: 1px solid #d4d4d4;
                            }

                                table.lamp th, td {
                                    padding: 10px;
                                }

                                table.lamp th {
                                    width: 40px;
                                }
                        </style>
                        <table class="lamp">
                            <tr>
                                <th>
                                    <img src="../../lamp.jpg" alt="Note" style="height: 32px; width: 32px">
                                </th>
                                <td>Todos los campos con * son obligatorios.
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>
                <!-- /.box -->

            </div>
            <!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6" id="columna2" name="columna2" runat="server" visible="False">

                <div class="box box-primary">

                    <div class="box-header with-border">
                        <h3 class="box-title">Personal del Proyecto </h3>
                    </div>

                    <!-- /.box-header -->
                    <!-- form start -->

                    <div class="box-body">

                        <div class="form-group" runat="server">
                            <label for="inputGerente">Gerente de proyecto *</label>
                            <select class="form-control" id="inputGerente" name="inputGerente" runat="server">
                            </select>
                        </div>

                        <hr />

                        <div class="form-group">
                            <label for="inputPersonal">Personal Responsable *</label>
                            <select multiple="true" class="form-control" id="inputPersonal" name="inputPersonal" runat="server">
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="inputEncargado">Encargado de la empresa contratante *</label>
                            <select multiple="true" class="form-control" datatextfield="text" id="inputEncargado" name="inputEncargado" runat="server">
                            </select>
                        </div>
                        <hr />
                       </div>
                    <div>
                        <head>
                            <style>
                                table.lamp {
                                    width: 100%;
                                    border: 1px solid #d4d4d4;
                                }

                                    table.lamp th, td {
                                        padding: 10px;
                                    }

                                    table.lamp th {
                                        width: 40px;
                                    }
                            </style>
                        </head>
                        <body>
                            <table class="lamp">
                                <tr>
                                    <th>
                                        <img src="../../lamp.jpg" alt="Note" style="height: 32px; width: 32px">
                                    </th>
                                    <td>Para seleccionar mas de un contacto o programador deje pisado Ctrl o Shitf.
                                    </td>
                                </tr>
                            </table>
                        </body>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
