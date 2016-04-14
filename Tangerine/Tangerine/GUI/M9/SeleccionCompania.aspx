<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="SeleccionCompania.aspx.cs" Inherits="Tangerine.GUI.M9.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestion de Pagos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Lista de compañias
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Pagos</a></li>
    <li class="active">Seleccion de compañia</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div class="row">
            <!-- left column -->
            <div class="col-md-12">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Compañias</h3>
                    <div class="box-tools">
                        <div class="input-group input-group-sm" style="width: 150px;">
                            <input name="table_search" class="form-control pull-right" placeholder="Search" type="text">

                            <div class="input-group-btn">
                                <button type="submit" class="btn btn-default" ><i class="fa fa-search"></i></button>
                            </div>
                        </div>
                     </div>
                </div><!-- /.box-header -->
                <!-- table start -->
                <div class="box-body table-responsive no-padding">
                    <table class="table table-hover">
                        <tbody>
                            <tr>
                                <th>Nombre</th>
                                <th>Acrónimo</th>
                                <th>RIF</th>
                                <th>Email</th>
                                <th>Fecha Registro</th>
                                <th>Status</th>
                                <th style="text-align: center;">Información</th>
                            </tr>
                            <tr>
                                <td>Tangerine Systems</td>
                                <td>TGE</td>
                                <td>J-234435634</td>
                                <td>tangerine00@gmail.com</td>
                                <td>14/04/2016</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" type="submit" runat="server" href="FacturasPorPagar.aspx"></a></th>
                            </tr>
                            <tr>
                                <td>Touch Solutions</td>
                                <td></td>
                                <td>J-8673254432</td>
                                <td>touchs@gmail.com</td>
                                <td>30/01/2005</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" type="submit" runat="server" href="FacturasPorPagar.aspx"></a></th>
                            </tr>
                            <tr>
                                <td>Universidad Católica Andrés Bello</td>
                                <td>UCAB</td>
                                <td>J-9832457896</td>
                                <td>ucab@gmail.com</td>
                                <td>13/05/2014</td>
                                <td><span class="label label-danger">Inabilitada</span></td>
                                <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" type="submit" runat="server" href="FacturasPorPagar.aspx"></a></th>
                            </tr>
                            <tr>
                                <td>International Business Machines</td>
                                <td>IBM</td>
                                <td>J-8764553432</td>
                                <td>ibm@gmail.com</td>
                                <td>22/12/2012</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;"><a class="btn btn-primary glyphicon glyphicon-info-sign" type="submit" runat="server" href="FacturasPorPagar.aspx"></a></th>
                            </tr>
                        </tbody>
                    </table>
                </div>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
          </div>
</asp:Content>
