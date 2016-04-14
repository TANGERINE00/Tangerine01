<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarLead.aspx.cs" Inherits="Tangerine.GUI.M3.ModificarLead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Consultar Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Leads</a></li>
    <li class="active">Consultar Lead</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<form class="form-horizontal">
    <div class="form-group">
        <label class="control-label col-xs-3">Nombre:</label>
        <div class="col-xs-9">
            <input type="email" class="form-control" id="inputEmail" placeholder="Umbrella">
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-3">RIF:</label>
        <div class="col-xs-9">
            <input type="password" class="form-control" id="inputPassword" placeholder="J213141415">
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-3">Direccion:</label>
        <div class="col-xs-9">
            <input type="password" class="form-control" placeholder="El Bosque, Edif Banesco ">
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-3">Telefono:</label>
        <div class="col-xs-9">
            <input type="text" class="form-control" placeholder="+585674563498">
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-3">Email:</label>
        <div class="col-xs-9">
            <input type="text" class="form-control" placeholder="Umbrella@gmail.com">
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-3" >Presupuesto Anual de Inversion:</label>
        <div class="col-xs-9">
            <input type="tel" class="form-control" placeholder="12000$">
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-3" >Nombre de Contacto:</label>
        <div class="col-xs-9">
            <input type="tel" class="form-control" placeholder="Lic Sabrina Gonzales">
        </div>
    </div>
     <div class="form-group">
        <label class="control-label col-xs-3" >Telefono de Contacto:</label>
        <div class="col-xs-9">
            <input type="tel" class="form-control" placeholder="+584129870998">
        </div>
    </div>

 
 
    <th style="text-align:center;"><a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="Listar.aspx"="#">Regresar></a></th> 


</asp:Content>
