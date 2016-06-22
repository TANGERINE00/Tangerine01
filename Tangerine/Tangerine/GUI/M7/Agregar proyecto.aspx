<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" 
    CodeBehind="Agregar proyecto.aspx.cs" Inherits="Tangerine.GUI.M7.AgregarProyecto" %>

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
                            <asp:DropDownList class="form-control" DataTextField="text" ID="inputPropuesta" 
                             name="inputPropuesta" OnSelectedIndexChanged="comboPropuesta_Click" 
                                AutoPostBack="True" runat="server">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group" runat="server"> 
                            <label for="InputNombreProyecto">Nombre de proyecto *</label> 
                                        <input runat="server" id="textInputNombreProyecto" required type="text"
                                            placeholder="Nombre Proyecto"  name="textInputNombreProyecto"
                                            pattern="^[a-zA-Z][a-zA-Z ]{4,20}$" class="form-control"  
                                             oninvalid="setCustomValidity('Únicamente letras. (Max.20)')" 
                                            oninput="setCustomValidity('')" />
                         </div>       
                        
                        <div class="form-group" runat="server"> 
                            <label for="InputCodigo">Codigo del proyecto *</label> 
                                        <input runat="server" id="textInputCodigo" name="textInputCodigo" required 
                                         type="text" placeholder="Proy-DS2016" class="form-control" 
                                         pattern="^[a-zA-Z][a-zA-Z0-9 -]{4,20}$"  
                                         oninvalid="setCustomValidity('Sólo letras, guiones y números. (Max.20)')" 
                                         oninput="setCustomValidity('')" />
                         </div>

                          <div class="row">
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                        <div class="form-group date">
                        <label>Fecha estimada Incio:</label>
          
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input class="form-control pull-right" id="datepicker1" type="text" runat="server"
                                 clientidmode="static" placeholder="mm/dd/yyyy" required
                                 pattern="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                 data-date-format="dd/mm/yyyy" readonly="">
                        </div>
                        <!-- /.input group -->
                    </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-10 col-xs-10">
                    <div class="form-group date">
                        <label>Fecha estimada Final:</label>

                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input class="form-control pull-right" id="datepicker2" type="text" runat="server" 
                                clientidmode="static"  placeholder="mm/dd/yyyy" required 
                                pattern="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                data-date-format="dd/mm/yyyy" readonly="" >
                        </div>
                        <!-- /.input group -->
                    </div>
                          </div>
                              </div>

                        <div class="form-group" runat="server">
                            <label for="InputCosto">Costo estimado *</label>
                            <input runat="server" type="text" class="form-control" id="textInputCosto" 
                                name="textInputCosto" placeholder="0 Bs" Disabled="disabled">
                        </div>
                        <div class="form-group" runat="server">
                            <asp:Button ID="btnAgregarPersonal" Style="margin-top: 5%" class="btn btn-primary" 
                            OnClick="btnAgregarPersonal_Click" type="submit" runat="server" Text="Agregar Personal">
                            </asp:Button>
                        </div>
                        <hr />
                    </div>
                    <div class="box-footer">
                        <asp:Button ID="btnGenerar" Style="margin-top: 5%" class="btn btn-primary" 
                        OnClick="btnGenerar_Click" type="submit" runat="server" Text="Generar" Enabled="false">
                        </asp:Button>
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
                            <asp:DropDownList class="form-control" DataTextField="text" id="inputGerente" 
                            name="inputGerente" runat="server">
                            </asp:DropDownList>
                            
                        </div>

                        <hr />

                        <div class="form-group">
                            <label for="inputPersonal">Personal Responsable *</label>

                            <select multiple="true" class="form-control" id="inputPersonal" 
                            name="inputPersonal" runat="server">
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="inputEncargado">Encargado de la empresa contratante *</label>
                          
                        </div>
                             <select multiple="true" class="form-control" id="inputEncargado" 
                             name="inputEncargado" runat="server">
                            </select>
                          
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
