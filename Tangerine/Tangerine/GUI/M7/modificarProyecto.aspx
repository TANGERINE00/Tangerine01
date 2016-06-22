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

    <div id="alert" runat="server">
    </div>

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
                            <asp:TextBox runat="server" id="idPropuesta" ReadOnly="true" Visible="false"></asp:TextBox>
                            <asp:TextBox runat="server" id="descripcion" ReadOnly="true" Visible="false"></asp:TextBox>
                            <asp:TextBox runat="server" id="acuerdoPago" ReadOnly="true" Visible="false"></asp:TextBox>
                            <asp:TextBox runat="server" id="idCompania" ReadOnly="true" Visible="false"></asp:TextBox>

                        </div>

                        <div class="form-group">
                            <label for="InputNombreProyecto">Nombre de proyecto *</label> </br>
                            <asp:TextBox runat="server" ID="textInputNombreProyecto" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            <asp:TextBox runat="server" ID="idProyecto" ReadOnly="true" visible="false"></asp:TextBox>
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
                            <label for="InputFechaEstimada">Fecha Estimada de culminación *</label> <br />
                            <asp:Calendar runat="server" ID="textInputFechaEstimada" SelectionMode="DayWeekMonth" OnDayRender="textInputFechaEstimada_DayRender"></asp:Calendar>
                        </div>

                        <div class="form-group">
                            <label for="InputCosto">Costo estimado *</label> <br />
                            <asp:TextBox runat="server" ID="textInputCosto" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="textInputCosto" runat="server" ErrorMessage="Solo Numeros y Hasta 2 Decimales" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="ValidarCostoEstimado" runat="server" ControlToValidate="textInputCosto" ErrorMessage="Debe ingresar un costo" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label for="InputPorcentaje">Porcentaje de realizacion *</label> <br />
                            <asp:TextBox runat="server" ID="textInputPorcentaje" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="textInputPorcentaje" runat="server" ErrorMessage="Solo Numeros del 1 al 100" ValidationExpression="^[1-9][0-9]?$|^100$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="ValidarPorcentaje" runat="server" ControlToValidate="textInputPorcentaje" ErrorMessage="Debe ingresar un porcentaje de realizacion" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Personal del Proyecto *</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->

                <div class="box-body">
                    <div class="form-group">
                        <label for="labelGerete_M7">Gerente de proyecto *</label><br />
                        <asp:DropDownList runat="server" Id="inputGerente" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="labelGeretePasado_M7">Gerentes Anteriores</label><br />
                        <asp:ListBox runat="server" Id="GerentesPasados" CssClass="form-control" SelectionMode="Single" Enabled="false" ></asp:ListBox>
                    </div>
                    <hr />

                    <div class="inline">
                        <label for="inputPersonal">Personal*</label><br />
                        <asp:ListBox runat="server" ID="inputPersonal" CssClass="form-control" SelectionMode="Multiple"></asp:ListBox>

                        <label for="inputPersonal">Personal No Activo</label><br />
                        <asp:ListBox runat="server" ID="inputPersonalNoActivo" CssClass="form-control" SelectionMode="Multiple"></asp:ListBox>
                        <br />

                        <asp:LinkButton ID="bIzquierdo" runat="server" CssClass="btn btn-primary" OnClick="bIzquierdo_Click">
                            <span aria-hidden="true" class="glyphicon glyphicon-chevron-down"></span>
                        </asp:LinkButton>

                        <asp:LinkButton ID="bDerecho" runat="server" CssClass="btn btn-primary" OnClick="bDerecho_Click">
                            <span aria-hidden="true" class="glyphicon glyphicon-chevron-up"></span>
                        </asp:LinkButton>
                    </div>
                    <hr />

                    <div class="form-group">
                        <label for="inputEncargado">Encargado de la empresa contratante *</label>
                        <asp:ListBox runat="server" ID="inputEncargado" CssClass="form-control" SelectionMode="Single"></asp:ListBox>
                    </div>
                    <hr />
              
                </div>
            </div>
        </div>
</div>
        <div class="box-footer">                      
          <div class="form-group">
            <label for="labelMonto_M7">Estatus del proyecto *</label><br />
            <asp:DropDownList runat="server" Id="inputEstatus" CssClass="form-control"></asp:DropDownList>
          </div>
          <div class="form-group">
            <label for="labelMonto_M7">Comentario</label><br />
            <asp:TextBox runat="server" ID="text10" CssClass="form-control"></asp:TextBox>                  
          </div>
          <hr />
          <asp:LinkButton runat="server" ID="modificar" OnClick="Modificar_Datos" CssClass="btn btn-primary">Modificar</asp:LinkButton><br />
          <label>* Todos los campos son obligatorios</label>
        </div>
    </form>


</asp:Content>