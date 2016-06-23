<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="EnviarCorreoM8.aspx.cs" Inherits="Tangerine.GUI.M8.EnviarCorreoM8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Sistema de Contacto
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Envío de Correos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestion Factura</a></li>
    <li class="active">Contactar</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Factura N° <asp:Literal runat="server" ID="textNumeroFactura"></asp:Literal>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="alert" runat="server">
    </div>
    <div class="row">
        <!-- left column -->
        <div id="Div1" class="col-md-6" runat="server">
            <!-- general form elements -->
            <div id="Div2" class="box box-primary" runat="server">
                <div id="Div3" class="box-header with-border" runat="server">
                    <h3 class="box-title">Redactar Correo</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form id="Form1" role="form" runat="server">
                    <div id="Div4" class="box-body" runat="server">
                        <!--Destinatario-->
                        <div id="Div5" class="form-group" runat="server">
                            <label for="labelDestinatario_M8">Para</label>
                            <input type="text" runat="server" class="form-control" id="textDestinatario_M8" name="textDestinatario_M8">
                        </div>
                        <!--Asunto-->
                        <div id="Div6" class="form-group" runat="server">
                            <label for="labelAsunto_M8">Asunto</label>
                            <input type="text" runat="server" class="form-control" id="textAsunto_M8" name="textAsunto_M8" disabled="disabled">
                        </div>
                        <!--Mensaje-->
                        <div id="Div7" class="form-group" runat="server">
                            <label for="labelMensaje_M8">Mensaje</label>
                            <%--<input type="text" runat="server" class="form-control" id="textMensaje_M8" name="textMensaje_M8" placeholder="Ingrese el Mensaje">--%>
                            <textarea type="text" runat="server" class="form-control" id="textMensaje_M8" name="textMensaje_M8" rows="4" cols="50">
                            </textarea>
                        </div>

                        <%-- <div class="form-group" runat="server">
                            <label for="labelProyecto_M8">Proyecto</label>
                            <input type="text" runat="server" class="form-control" id="textProyecto_M8" name="textProyecto_M8" placeholder="Proyecto" disabled="disabled">
                        </div> --%>

                        <%-- <div class="form-group" runat="server">
                            <label for="labelDescripcion_M8">Descripción</label>
                            <input type="text" runat="server" class="form-control"
                                   pattern="^[0-9a-zñA-ZÑ.- ]+$"
                                   id="textDescripcion_M8" name="textDescripcion_M8" 
                                   placeholder="Descripción" maxlength="50" required>
                        </div> --%>

                        <%--    <div class="form-group" runat="server">
                      <label for="labelEstatus_M8">Estatus</label>
                     <select runat="server" class="form-control" id="textEstatus_M8" name="textEstatus_M8"> 
                     <option>Por Pagar</option>
                     <option>Pagada</option>
                     <option>Anulada</option> 
                     </select>
                    </div> --%>

                        <%-- <div class="form-group" runat="server">
                            <label for="labelMonto_M8">Monto</label>
                            <input type="text" runat="server" class="form-control" id="textMonto_M8" name="textMonto_M8" placeholder="Monto" disabled="disabled">
                        </div> --%>

                        <div id="Div8" class="form-group" runat="server" style="text-align:center;">
                            <asp:Button ID="buttonEnviar_M8" Style="margin-top: 5%; margin-right:15px;" class="btn btn-primary" type="submit" runat="server" Text="Enviar Correo" OnClick="buttonEnviarCorreo_Click"></asp:Button>
                            <a Style="margin-top: 5%; width:105px;" href="ConsultarFacturaM8.aspx" class="btn btn-default" type="submit">Cancelar</a>
                        </div>

                    </div>
                    <!-- /.box-body -->


                </form>
            </div>
            <!-- /.box -->

        </div>
</div>
        <!--/.col (left) -->
        <!-- right column -->
        <div class="col-md-6">
        </div>
</asp:Content>

