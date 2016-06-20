<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="modificarProyecto.aspx.cs" Inherits="Tangerine.GUI.M7.modificarProyecto" %>

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
                            <label for="InputPropuesta">Propuesta Aprobada *</label> </br>
                            <asp:TextBox runat="server" id="inputPropuesta" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="InputNombreProyecto">Nombre de proyecto *</label> </br>
                            <asp:TextBox runat="server" ID="textInputNombreProyecto" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="InputCodigo">Codigo del proyecto *</label> </br>
                            <asp:TextBox runat="server" ID="textInputCodigo" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="InputFechaInicio">Fecha de inicio *</label></br>
                            <asp:TextBox runat="server" ID="textInputFechaInicio" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="InputFechaEstimada">Fecha Estimada de culminación *</label> </br>
                            <asp:Calendar runat="server" ID="textInputFechaEstimada" SelectionMode="DayWeekMonth"></asp:Calendar>
                        </div>


                        <div class="form-group">
                            <label for="InputCosto">Costo estimado *</label> </br>
                            <asp:TextBox runat="server" ID="textInputCosto" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="textInputCosto" runat="server" ErrorMessage="Solo Numeros y Hasta 2 Decimales" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                        </div>

                        <div class="form-group">
                            <label for="InputPorcentaje">Porcentaje de realizacion *</label> </br>
                            <asp:TextBox runat="server" ID="textInputPorcentaje" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="textInputPorcentaje" runat="server" ErrorMessage="Solo Numeros del 1 al 100" ValidationExpression="^[1-9][0-9]?$|^100$"></asp:RegularExpressionValidator>
                        </div>

                        <hr />



                    </div>
                    <!-- /.box-body -->

                    <div class="box-footer">
                       <asp:LinkButton runat="server" ID="modificar" OnClick="Modificar_Datos" CssClass="btn btn-primary"></asp:LinkButton>
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
                        <label for="labelGerete_M7">Gerente de proyecto *</label></br>
                            <asp:DropDownList runat="server" Id="inputGerente" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <hr />
                    <hr />
                    <div class="form-group">
                        <label for="inputPersonal">Personal *</label></br>
                        <asp:ListBox runat="server" ID="inputPersonal" CssClass="form-control" SelectionMode="Multiple"></asp:ListBox>

                        <label for="inputEncargado">Encargado de la empresa contratante *</label>
                        <asp:ListBox runat="server" ID="inputEncargado" CssClass="form-control" SelectionMode="Single"></asp:ListBox>

                    </div>
                    <hr />
                    <hr />
                    <div class="form-group">
                        <label for="labelMonto_M7">Estatus del proyecto *</label></br>
                        <asp:DropDownList runat="server" Id="inputEstatus" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="labelMonto_M7">Razon de Fallos en la entrega</label></br>
                        <asp:TextBox runat="server" ID="text10" CssClass="form-control"></asp:TextBox>                  
                      </div>
                    </form>
                </div>
            </div>
        </div>
</asp:Content>


<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
