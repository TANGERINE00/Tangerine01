<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarRequerimiento.aspx.cs" Inherits="Tangerine.GUI.M6.ModificarRequerimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/modulo6.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestion de Propuesta
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar Propuesta
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuesta</a></li>
    <li class="active">Modificar Requerimiento</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .main-footer {
            float: left;
            position: relative;
            width: 100%;
        }
        .content-wrapper {
            float: left;
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

    <div id="alert" runat="server" style="width:530px">
    </div>

    <form role="form" name="agregar_propuesta" id="agregar_propuesta" method="post" runat="server">

        <div class="col-md-6" runat="server">

            <div class="box box-primary" style="height: inherit !important" runat="server">

                <!-- form start -->

                <div class="box-body">
                          
                            <input type="text" class="form-control" ID="textoDuracion" name="duracion" runat="server" 
                                pattern="^[0-9]{1,3}$" title="Introduzca un numero" required clientidmode="static"
                                oninvalid="setCustomValidity('Campo obligatorio, solo puede tener números (maximo 3 digitos)')" 
                                oninput="setCustomValidity('')" 
                                onchange="setFechas(this.id, 'datepicker1', 'datepicker2', 'comboDuracion')">
                     
                </div>

                <div class="box-footer" runat="server">
                    <asp:Button ID="btnagregar" class="btn btn-primary"
                        OnClick="btnagregar_Click" OnClientClick="javascript:crearPrecondicionArr()" type="submit" runat="server"
                        Text="Agregar"></asp:Button>
                </div>

            </div>
        </div>

    </form>




</asp:Content>
