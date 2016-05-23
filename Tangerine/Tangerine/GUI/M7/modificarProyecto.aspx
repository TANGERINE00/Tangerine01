<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="modificarProyecto.aspx.cs" Inherits="Tangerine.GUI.M7.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Proyectos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Proyectos</a></li>
    <li class="active">Modificar Proyecto</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Proyecto</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form" id="modificar_proyecto" method="post" runat="server">
                    <div class="box-body">
                        <div class="form-group">
                            <label for="InputPropuesta">Propuesta Aprobada *</label>
                            <select class="form-control" id="inputPropuesta" name="inputPropuesta" runat="server" disabled="disabled">
                            </select>
                        </div>

                        <div class="form-group">
                            <label for="InputNombreProyecto">Nombre de proyecto *</label>
                            <input runat="server" type="text" class="form-control" id="textInputNombreProyecto" placeholder="Nombre Proyecto" name="textInputNombreProyecto" disabled="disabled">
                        </div>

                        <div class="form-group">
                            <label for="InputCodigo">Codigo del proyecto *</label>
                            <input runat="server" type="text" class="form-control" id="textInputCodigo" name="textInputCodigo" placeholder="123456789" disabled="disabled">
                        </div>

                        <div class="form-group">
                            <label for="InputFechaInicio">Fecha de inicio *</label>
                            <input runat="server" type="datetime" class="form-control" id="textInputFechaInicio" name="textInputFechaInicio" placeholder="dd/mm/aaaa" disabled="disabled">
                        </div>

                        <div class="form-group">
                            <label for="InputFechaEstimada">Fecha Estimada de culminación *</label>
                            <input runat="server" type="datetime" class="form-control" id="textInputFechaEstimada" name="textInputFechaEstimada" placeholder="dd/mm/aaaa">
                        </div>


                        <div class="form-group">
                            <label for="InputCosto">Costo estimado *</label>
                            <input runat="server" type="text" class="form-control" id="textInputCosto" name="textInputCosto" placeholder="0 Bs">
                        </div>

                        <div class="form-group">
                            <label for="InputPorcentaje">Porcentaje de realizacion *</label>
                            <input runat="server" type="text" class="form-control" id="textInputPorcentaje" name="textInputPorcentaje" placeholder="0 %">
                        </div>

                        <hr />



                    </div>
                    <!-- /.box-body -->

                    <div class="box-footer">
                        <asp:Button ID="btnGuardar" Style="margin-top: 5%" class="btn btn-primary" OnClick="btnGenerar_Click" type="submit" runat="server" Text="Modificar"></asp:Button>
                    </div>
                    <div>
                        <label>* Todos los campos son obligatorios</label></div>
            </div>
            <!-- /.box -->

        </div>
        <!--/.col (left) -->
        <!-- right column -->
        <div class="col-md-6">

            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Personal del Proyecto *</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->

                <div class="box-body">

                    <div class="form-group">
                        <label for="labelGerete_M7">Gerente de proyecto *</label>
                        <select class="form-control" id="inputGerente" name="inputGerente" runat="server">
                        </select>
                    </div>

                    <hr />
                    <hr />
                    <div class="form-group">
                        <label for="inputPersonal">Personal *</label>
                        <select multiple="true" class="form-control" id="inputPersonal" name="inputPersonal" runat="server">
                        </select>


                        <label for="inputEncargado">Encargado de la empresa contratante *</label>
                        <select multiple="true" class="form-control" datatextfield="text" id="inputEncargado" name="inputEncargado" runat="server">
                        </select>

                    </div>
                    <hr />
                    <hr />
                    <div class="form-group">
                        <label for="labelMonto_M7">Estatus del proyecto *</label>
                        <select class="form-control" id="inputEstatus" runat="server" name="inputEstatus">
                            <option>En desarrollo</option>
                            <option>Completado</option>
                            <option>Completado a destiempo</option>
                            <option>Cancelado</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <input runat="server" type="text" class="form-control" id="text10" name="textFallasProyecto_M7" placeholder="Razon de fallos en la entrga">                    
                      </div>
                    </form>
                </div>
            </div>
        </div>
</asp:Content>


<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
