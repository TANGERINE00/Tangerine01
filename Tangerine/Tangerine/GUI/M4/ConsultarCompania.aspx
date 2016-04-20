<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultarCompania.aspx.cs" Inherits="Tangerine.GUI.M4.ConsultarCompania" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Compañias
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Datos
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Compañias</a></li>
    <li class="active">Consultar</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Main content -->
   
          <div class="row">
            <div class="col-md-12">
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Consulta de Datos</h3>
                  <div class="box-tools">
                        <div class="input-group input-group-sm" style="width: 150px;">
                            <input name="table_search" class="form-control pull-right" placeholder="Search" type="text">

                            <div class="input-group-btn">
                                <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                            </div>
                        </div>
                     </div>
                </div><!-- /.box-header -->
                <div class="box-body table-responsive no-padding">
                  <table id="example2" class="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>Nombre</th>
                        <th>Acrónimo</th>
                        <th>RIF</th>
                        <th>Teléfono</th>
                        <th>Fecha Registro</th>
                        <th>Status</th>
                        <th style="text-align: center;">Acciones</th>
                      </tr>
                    </thead>
                    <tbody>
                        <tr>
                                <td>Tangerine Systems</td>
                                <td>TGE</td>
                                <td>J-234435634</td>
                                <td>+584122362151</td>
                                <td>2016/07/12</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>Touch Solutions</td>
                                <td></td>
                                <td>J-8673254432</td>
                                <td>+582129764901</td>
                                <td>2005/03/30</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>Universidad Católica Andrés Bello</td>
                                <td>UCAB</td>
                                <td>J-9832457896</td>
                                <td>+582126659375</td>
                                <td>2014/05/13</td>
                                <td><span class="label label-danger">Inabilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>International Business Machines</td>
                                <td>IBM</td>
                                <td>J-8764553432</td>
                                <td>+582129774543</td>
                                <td>2012/12/22</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                        <tr>
                                <td>Tangerine Systems</td>
                                <td>TGE</td>
                                <td>J-234435634</td>
                                <td>+584122362151</td>
                                <td>2016/07/12</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>Touch Solutions</td>
                                <td></td>
                                <td>J-8673254432</td>
                                <td>+582129764901</td>
                                <td>2005/03/30</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>Universidad Católica Andrés Bello</td>
                                <td>UCAB</td>
                                <td>J-9832457896</td>
                                <td>+582126659375</td>
                                <td>2014/05/13</td>
                                <td><span class="label label-danger">Inabilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>International Business Machines</td>
                                <td>IBM</td>
                                <td>J-8764553432</td>
                                <td>+582129774543</td>
                                <td>2012/12/22</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                        <tr>
                                <td>Tangerine Systems</td>
                                <td>TGE</td>
                                <td>J-234435634</td>
                                <td>+584122362151</td>
                                <td>2016/07/12</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>Touch Solutions</td>
                                <td></td>
                                <td>J-8673254432</td>
                                <td>+582129764901</td>
                                <td>2005/03/30</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>Universidad Católica Andrés Bello</td>
                                <td>UCAB</td>
                                <td>J-9832457896</td>
                                <td>+582126659375</td>
                                <td>2014/05/13</td>
                                <td><span class="label label-danger">Inabilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>International Business Machines</td>
                                <td>IBM</td>
                                <td>J-8764553432</td>
                                <td>+582129774543</td>
                                <td>2012/12/22</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                        <tr>
                                <td>Tangerine Systems</td>
                                <td>TGE</td>
                                <td>J-234435634</td>
                                <td>+584122362151</td>
                                <td>2016/07/12</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>Touch Solutions</td>
                                <td></td>
                                <td>J-8673254432</td>
                                <td>+582129764901</td>
                                <td>2005/03/30</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>Universidad Católica Andrés Bello</td>
                                <td>UCAB</td>
                                <td>J-9832457896</td>
                                <td>+582126659375</td>
                                <td>2014/05/13</td>
                                <td><span class="label label-danger">Inabilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr>
                            <tr>
                                <td>International Business Machines</td>
                                <td>IBM</td>
                                <td>J-8764553432</td>
                                <td>+582129774543</td>
                                <td>2012/12/22</td>
                                <td><span class="label label-success">Habilitada</span></td>
                                <th style="text-align: center;">
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-primary glyphicon glyphicon-pencil" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-success glyphicon glyphicon-ok" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-danger glyphicon glyphicon-remove" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-warning glyphicon glyphicon-list-alt" data-toggle="modal" data-target="#myModal"></a>
                                    <a class="btn btn-info glyphicon glyphicon-user" data-toggle="modal" data-target="#myModal"></a>
                                </th>
                            </tr> 
                    </tbody>
                  </table>
                </div><!-- /.box-body -->
              </div><!-- /.box -->

            </div><!-- /.col -->
          </div><!-- /.row -->
       
</asp:Content>
