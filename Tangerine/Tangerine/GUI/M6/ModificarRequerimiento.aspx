<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarRequerimiento.aspx.cs" Inherits="Tangerine.GUI.M6.ModificarRequerimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/Requerimiento.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
     Gestion de Requerimiento
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
   Modificar Requerimiento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuesta</a></li>
     <li><a href="#">Modificar Propuesta</a></li>
    <li class="active">Modificar Requerimiento</li>
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

    <form role="form" name="modificar_requerimiento" id="modificar_requerimiento" method="post" runat="server">

        <div class="col-md-6" runat="server">

            <div class="box box-primary" style="height: inherit !important" runat="server">

                <!-- form start -->

                <div class="box-body">
                     <div class="form-group">
                       <label for="requerimiento_id">Id de Requerimiento</label>
                        <input class="form-control" id="requerimiento_id" runat="server" disabled="disabled">
                    </div>
                   <div class ="form-group">       
                    
                       <label for="concepto">Concepto</label>
                        <input type="text" class="form-control" ID="concepto" name="concepto" runat="server" 
                                pattern="^[A-z ,.()0-9]+$" title="Introduzca un Concepto" required clientidmode="static"
                                oninvalid="setCustomValidity('Campo obligatorio, solo puede tener letras y numeros')" 
                                oninput="setCustomValidity('')" onblur="onBlurDeInputs(this.id)">

                    </div> 
                </div>

                <div class="box-footer" runat="server">
                    <asp:Button ID="btnagregar" class="btn btn-primary"
                        OnClick="btnmodificar_Click"  type="submit" runat="server"
                        Text="Modificar"></asp:Button>

                    <a href="ConsultarPropuesta.aspx" class="btn btn-default pull-right">Regresar</a>  
                </div>

            </div>
        </div>

    </form>




</asp:Content>
