<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true"
    CodeBehind="ConsultarContactos.aspx.cs" Inherits="Tangerine.GUI.M5.ConsultarContactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Nombre Compañía/Lead
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    <!--Lista de Contactos-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de contactos</a></li>
    <li class="active">Consultar Contactos</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="alerta" runat="server">
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-header">
                    <h3 class="box-title">Contactos Existentes</h3>
                </div>
                <form role="form" name="consultar" id="consultar">
                    <div class="box-body table-responsive">
                        <table id="example2" class="table table-bordered table-striped dataTable" accesskey="">
                            <thead>
                                <tr style="font-size:18px;">
                                    <th>Nombre</th>
                                    <th>Departamento</th>
                                    <th>Cargo</th>
                                    <th>Telefono</th>
                                    <th>Correo</th>                 
                                    <th style="width:150PX; text-align:center;">Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal runat="server" ID="tabla"></asp:Literal>
                            </tbody>
                        </table>
                        <asp:Literal runat="server" ID="volver"></asp:Literal>
                        <asp:Literal runat="server" ID="nuevocontacto"></asp:Literal>
                    </div>
                </form>
            </div>
	    </div>
    </div>

    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.0/js/bootstrap-toggle.min.js"></script>

</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
