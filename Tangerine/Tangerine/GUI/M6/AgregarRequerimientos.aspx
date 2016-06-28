<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarRequerimientos.aspx.cs" Inherits="Tangerine.GUI.M6.AgregarRequerimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/AgregarReq.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
     Gestion de Requerimiento
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
   Agregar Requerimientos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuesta</a></li>
     <li><a href="#">Modificar Propuesta</a></li>
    <li class="active">Agregar Requerimiento</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .box-body {
        

        }
        .main-footer {
            float: left;
            position: relative;
            width: 100%;
        }
        .content-wrapper {
            float: left;
            width: 85%;
        }
        .input-group, .form-control {
            width: 95%;
        }
        .date {
            width: 48.5% !important;
            float: left;
        }
        #div-precondiciones {
            margin-bottom: 20px;
        }
        #div-precondiciones .form-group {
                padding: 15px 0;
            }
        @media only screen and (max-width: 550px) {
            .date {
                width: 100% !important;
                float: left;
            }
        }
        .dropdown .btn {
            width: 95%;
        }
    </style>

    <div id="alert" runat="server" style="width:100%">
    </div>

    <form role="form" name="agregar_requerimiento" id="agregar_requerimiento" method="post" runat="server">

        <div class="col-md-6" runat="server">

            <div class="box box-primary" style="height: inherit !important" runat="server">

                <!-- form start -->
                <div class="box-body">
                
                <div class="form-group">
                        <label>Alcance del Proyecto</label><label style="color: red; font-size:18px; margin-left:10px;"> * </label>
                        <div class="form-group">
                            <div id="div-precondiciones" class="col-sm-12 col-md-12 col-lg-12">

                                <div class="form-group">
                                    <div class="col-sm-12 col-md-12 col-lg-12" style="margin-left:-30px;">  
                                        <input runat="server" placeholder="Requerimiento" type="text" title="Descripcion"
                                            pattern="^[A-z ,.()0-9]+$" class="form-control precondicion" id="precondicion_0" 
                                            name="precondicion_0" required 
                                            oninvalid="setCustomValidity('Campo obligatorio, no puede tener números ni símbolos')" 
                                            oninput="setCustomValidity('')" onblur="onBlurDeInputs(this.id)" />
                                    </div>            
                                    <div class="col-sm-1 col-md-1 col-lg-1" style="margin-left:-20px;">     
                                        <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" 
                                            onclick="agregarPrecondicion()"></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <input id="arrPrecondicion" type="hidden" class="arrPrecondicion" runat="server" />
                        <%-- <button type="button" onclick="crearPrecondicionArr()">crear </button>--%>
                    </div>
                </div>

                <div class="box-footer" runat="server">
                    <asp:Button ID="btnagregar" class="btn btn-primary"
                        OnClick="btnagregar_Click"  
                        OnClientClick="javascript:crearPrecondicionArr()"
                        type="submit" runat="server"
                        Text="Agregar"></asp:Button>

                    <a href="ConsultarPropuesta.aspx" class="btn btn-default pull-right">Regresar</a>  
                </div>

            </div>
        </div>
    </form>
</asp:Content>
