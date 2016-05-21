<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Tangerine.GUI.M1.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Proyectos recientes
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
    <!-- contenido de tablas comentadas en clases -->
    <!--<div class="container-fluid">
      
      <div class="box box-default">
        <div class="container-fluid">
          <br>-->
            <asp:Literal runat="server" ID="FormViewProjects"></asp:Literal>
        <!--</div>
      </div>

    </div>-->
</asp:Content>
