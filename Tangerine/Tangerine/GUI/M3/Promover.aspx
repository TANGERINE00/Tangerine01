<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Promover.aspx.cs" Inherits="Tangerine.GUI.M3.ModificarLead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Promover Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestion de Promocion de Leads </a></li>
    <li class="active">Promover Leads </li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="checkbox">
  <label><input type="checkbox" value="">Umbrella</label>
</div>
<div class="checkbox">
  <label><input type="checkbox" value="">Skynet</label>
</div>
    <div class="checkbox">
  <label><input type="checkbox" value="">SquareSoft</label>
</div>
    <div class="checkbox">
  <label><input type="checkbox" value="">Ubisoft</label>
</div>
  
<div class="checkbox disabled">
  <label><input type="checkbox" value="" disabled>SquareEnix</label>
</div>






      <th style="text-align:center;"><a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="Listar.aspx"="#">Regresar></a></th> 
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Promover"   ></asp:Button>
				

</asp:Content>


