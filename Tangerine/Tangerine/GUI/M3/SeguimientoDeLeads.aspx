<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="SeguimientoDeLeads.aspx.cs" Inherits="Tangerine.GUI.M3.SeguimientoDeLeads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Historico de llamadas y  visitas de Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Leads</a></li>
    <li class="active">Seguimiento de llamadas y visitas Lead</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--informacion del cliente potencial-->
<div class="row">
    <div class="col-lg-12 col-md-12 col-xs-12">
        <div class="box box-default">
            <div class="container-fluid">
                <br />
                <div class="row">
                    <div id="Div1" class="form-group col-md-3 col-lg-3 col-xs-12" runat="server">
                        <h5><label for="Nombre">Nombre:</label></h5>
                        <div><h5><asp:Literal runat="server" ID="nombre"> </asp:Literal></h5></div>
                    </div> 
                    <div id="Div2" class="form-group col-md-3 col-lg-3 col-xs-12" runat="server">
                        <h5><label for="habilitado">rif:</label></h5>
                        <div><h5><asp:Literal runat="server" ID="rif"> </asp:Literal></h5></div>
                    </div>
                    <div id="Div3" class="form-group col-md-3 col-lg-3 col-xs-12" runat="server">
                        <h5><label for="habilitado">Correo:</label></h5>
                        <div><h5><asp:Literal runat="server" ID="email"> </asp:Literal></h5></div>
                    </div>
                    <div id="Div7" class="form-group col-md-3 col-lg-3 col-xs-12" runat="server">
                        <h5><label for="Nombre">presupuesto</label></h5>
                        <div><h5><asp:Literal runat="server" ID="presupuesto"> </asp:Literal></h5></div>
                    </div>                    
                </div>
                <div class="row">
                    <div id="Div5" class="form-group col-md-3 col-lg-3 col-xs-12" runat="server">
                        <h5><label for="Nombre">estatus</label></h5>
                        <div><h5><asp:Literal runat="server" ID="estatus"> </asp:Literal></h5></div>
                    </div> 
                    <div id="Div4" class="form-group col-md-3 col-lg-3 col-xs-12" runat="server">
                        <h5><label for="Nombre">Numero de llamadas</label></h5>
                        <div><h5><asp:Literal runat="server" ID="llamadas"> </asp:Literal></h5></div>
                    </div>
                    <div id="Div8" class="form-group col-md-3 col-lg-3 col-xs-12" runat="server">
                        <h5><label for="Nombre">Numero de visitas</label></h5>
                        <div><h5><asp:Literal runat="server" ID="visitas"> </asp:Literal></h5></div>
                    </div> 
                </div>
            </div>
        </div>
    </div>
</div>

 <!--Panel para el historico de seguimiento seguimiento -->
<div class="row">
    <!--Panel para el seguimiento de llamadas del cliente-->
    <div class="col-lg-6 col-md-6 col-xs-12">
        <div class="box box-default">
            <div class="container-fluid">
                <br />
                <div class="box-header with-border">
                  <h3 class="box-title">Seguimiento de llamadas</h3>
                </div><!-- /.box-header -->
                <div class="box-body table-responsive no-padding">
                    <div style="float: right; padding-top: 5px;">
                        <a style="margin-right: 10px;">Buscador</a>
                        <input id="searchTerm" type="text" onkeyup="doSearch()" />
                    </div>
                  <table id="example2" class="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>fecha</th>
                        <th>Motivo</th>
                      </tr>
                    </thead>
                    <asp:Literal runat="server" ID="ListaLlamadas"></asp:Literal>
                    <tbody>       
                    </tbody>
                  </table>
                </div><!-- /.box-body -->
            </div>
        </div>
    </div>

    <!--Panel para el seguimiento de visitas del cliente-->
    <div class="col-lg-6 col-md-6 col-xs-12">
        <div class="box box-default">
            <div class="container-fluid">
                <br />
                <div class="box-header with-border">
                  <h3 class="box-title">Seguimiento de visitas</h3>
                </div><!-- /.box-header -->
                <div class="box-body table-responsive no-padding">
                    <div style="float: right; padding-top: 5px;">
                        <a style="margin-right: 10px;">Buscador</a>
                        <input id="Text1" type="text" onkeyup="doSearch()" />
                    </div>
                  <table id="example3" class="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>fecha</th>
                        <th>Motivo</th>
                      </tr>
                    </thead>
                    <asp:Literal runat="server" ID="ListaVisitas"></asp:Literal>
                    <tbody>       
                    </tbody>
                  </table>
                </div><!-- /.box-body -->
            </div>
        </div>
    </div>
</div> 

</asp:Content>