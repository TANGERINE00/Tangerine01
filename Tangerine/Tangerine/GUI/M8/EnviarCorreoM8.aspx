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
                            <input type="text" runat="server" class="form-control" id="textDestinatario_M8" name="textDestinatario_M8"
                                pattern="^[0-9a-zñA-ZÑ@-._]+$"
                                oninvalid="setCustomValidity('Campo obligatorio, no puede tener símbolosni espacios en blanco')" 
                                oninput="setCustomValidity('')">
                        </div>
                        <!--Asunto-->
                        <div id="Div6" class="form-group" runat="server">
                            <label for="labelAsunto_M8">Asunto</label>
                            <input type="text" runat="server" class="form-control" id="textAsunto_M8" name="textAsunto_M8" disabled="disabled">
                        </div>
                        <!--Mensaje-->
                        <div id="Div7" class="form-group" runat="server">
                            <label for="labelMensaje_M8">Mensaje</label>
                            <textarea type="text" runat="server" class="form-control" id="textMensaje_M8" name="textMensaje_M8" rows="4" 
                                cols="50" disabled>
                            </textarea>
                        </div>
                        <div id="Div9" class="form-group" runat="server" style="">
                                 <asp:FileUpload ID="fuImage" runat="server" /> 
                                 <asp:Label ID="Label1" runat="server"></asp:Label>
                        </div>
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

