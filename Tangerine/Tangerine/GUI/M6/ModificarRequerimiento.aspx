<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarRequerimiento.aspx.cs" Inherits="Tangerine.GUI.M6.ModificarPropuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/Modificar.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Propuestas
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar Propuesta
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuestas</a></li>
    <li class="active">listado de propuestas</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">

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




    <form role="form" name="modificar_requerimiento" id="modificar_requerimiento" method="post" runat="server">

        <div class="col-md-6">

            <div class="box box-primary" style="height: auto">

                <div class="box-body">

                    <div class="form-group">
                       <label for="propuesta_id">Propuesta asociada</label>
                        <input class="form-control" id="propuesta_id" runat="server" disabled="disabled">
                    </div>

                    <div class="form-group">
                        <label>Descripción</label>
                        <label for="concepto">Descripción del Requerimiento</label>
                       <input class="form-control" id="concepto" runat="server">
                    </div>
 


             





  


                
                
                <div class="box-footer" runat="server">                   
                    

                    <asp:Button ID="botonModificarRe" class="btn btn-primary"
                        type="submit" runat="server"
                        Text="Modificar" OnClick="ModificarRequerimiento_Click"></asp:Button>
                 
                        <a href="ConsultarPropuesta.aspx" class="btn btn-default pull-right">Regresar</a>               
                    

                </div>

            </div>

            </div>
    </form>
    
   
</asp:Content>


