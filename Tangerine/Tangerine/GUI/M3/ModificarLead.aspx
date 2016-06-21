<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ModificarLead.aspx.cs" Inherits="Tangerine.GUI.M3.ModificarLead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Modificar Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Leads</a></li>
    <li class="active">Modificar Lead</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="row">
    <div class="col-lg-6 col-md-6 col-xs-12">
        <div class="box box-default">
            <form role="form" name="modificar_lead" id="modificar_lead" method="post"   runat="server">
            <div class="container-fluid">

                <br /><br />
                <!-- Etiqueta -->
                <div class="form-group ">
                    <label for="nombre">Nombe</label> 
                    <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="nombre" class="form-control" maxlength="20" placeholder="Nombre de etiqueta" required>
                </div>

                <!--Rif-->
                <div class="form-group ">
                    <label for="rif">Rif</label> 
                    <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="rif" class="form-control" maxlength="20" placeholder="# de rif" required>
                </div>

                <!--Correo-->
                <div class="form-group ">
                    <label for="email">Correo</label> 
                    <label for="Requerido" style="color: red;">*</label>
                    <input type="email" runat="server" id="correo" class="form-control" maxlength="100" placeholder="Direccion de correo" required>
                </div>

                <!--Presupuesto-->
                <div class="form-group ">
                    <label for="presupuesto">Presupuesto Anual</label> 
                    <label for="Requerido" style="color: red;">*</label>
                    <input type="number" runat="server" id="presupuesto" class="form-control" maxlength="20" placeholder="Presupuesto" required>
                </div>
                <!--Numero de llamadas-->
                <div class="form-group ">
                    <label for="llamadas"># LLamadas</label> 
                    <label for="Requerido" style="color: red;">*</label>
                    <input type="number" runat="server" id="numLlamadas" class="form-control" maxlength="20" placeholder="# de llamadas" required>
                </div>

                <!--Numero de visitas-->
                <div class="form-group ">
                    <label for="visitas"># Visitas</label> 
                    <label for="Requerido" style="color: red;">*</label>
                    <input type="number" runat="server" id="visitas" class="form-control" maxlength="20" placeholder="# de visitas" required>
               </div>

                <asp:Button id="Button1" style="margin-top:5%" class="btn btn-primary"  OnClick="Modificar_Click" type="submit" runat="server" Text = "Modificar"   ></asp:Button>

            </div>
            <br /><br />
            </form>
        </div>
    </div>
</div>


  
        


</asp:Content>