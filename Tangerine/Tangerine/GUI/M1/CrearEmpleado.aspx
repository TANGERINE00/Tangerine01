<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CrearEmpleado.aspx.cs" Inherits="Tangerine.GUI.M1.CrearEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Empleados
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Crear Empleado
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Dashboard</a></li>
    <li><a href="EmpleadosAdmin.aspx" > Gestión de Empleados</a></li>
    <li class="active"> Crear Empleado</li>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <div class="box box-default">
        <div class="container-fluid">
            <form role="form" name="agregar_empleado" id="agregar_empleado" method="post"   runat="server">
            <!--Fila 1-->
            <div class="row">
                <!--Columna 1-->
                <div class="col-xs-12 col-md-6 col-lg-6">
                  <h4>Datos Personales</h4>
                  <div class="form-group ">
                    <input type="text" runat="server" id="Cedula" class="form-control" placeholder="Cédula">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="FirstName" class="form-control" placeholder="Primer Nombre">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="SecondNamee" class="form-control" placeholder="Segundo Nombre">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="FirstLastName" class="form-control" placeholder="Primer Apellido">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="SecondLastName" class="form-control" placeholder="Segundo Apellido">
                  </div>
                  <div class="form-group ">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListGender" OnTextChanged="SelectedGender_Change" AutoPostBack="true">
                    </asp:DropDownList>
                  </div>
                   <div class="form-group">
                        <div class="form-control input-group date" data-provide="datepicker">
                          <input type="text" class="form-control" placeholder="fecha de nacimiento" id="DateEmployee" runat="server">
                          <div class="input-group-addon">
                              <span class="glyphicon glyphicon-th"></span>
                          </div>
                        </div>
                   </div>
                   <div class="form-group">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="LevelListStudy" OnTextChanged="SelectedStudy_Change" AutoPostBack="true">
                        </asp:DropDownList> 
                   </div>

               </div>
                   
                <!--columna 2-->
                <div class="col-xs-12 col-md-6 col-lg-6">
                  <h4>Datos de Contrato</h4>
                  <div class="form-group">
                        <div class="form-control input-group date" data-provide="datepicker">
                          <input type="text" class="form-control" placeholder="fecha de contratacion" id="DateJob" runat="server">
                          <div class="input-group-addon">
                              <span class="glyphicon glyphicon-th"></span>
                          </div>
                        </div>
                  </div>
                  
                 <asp:ScriptManager ID="MainScriptManager" runat="server" />
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group ">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListJob" OnTextChanged="SelectedJob_Change" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                          <div class="form-group ">
                                <textarea class="form-control" rows="3" runat="server" id="JobSummary" placeholder="Descripcion de cargo" disabled></textarea>
                          </div>
                        </ContentTemplate>
                 </asp:UpdatePanel>


                  <div class="form-group ">
                    <input type="text" runat="server" id="JobMode" class="form-control" placeholder="Modalidad de contrato">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="SalaryJob" class="form-control" placeholder="0.00">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="Email" class="form-control" placeholder="correo@dominio.com">
                  </div>
                </div>
            </div><!-- row -->
            <!--fila 2-->
            <div class="row">
                <div class="col-xs-12 col-md-6 col-lg-6">
                  <h4>Datos de Domicilio</h4>
                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListCountry" OnTextChanged="SelectedCountry_Change" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group ">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListState" OnTextChanged="SelectedState_Change" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                  <div class="form-group ">
                    <input type="text" runat="server" id="CityAddress" class="form-control" placeholder="Ciudad, parroquia 0 provincia">
                  </div>
                  <div class="form-group ">
                    <input type="text" runat="server" id="AddresEspecific" class="form-control" placeholder="Habitacion">
                  </div>       
                </div> 
                <div class="col-xs-12 col-md-6 col-lg-6">
                    <h4>Datos de Contacto</h4>
                    <div class="form-group ">
                        <input type="text" runat="server" id="EmailPerson" class="form-control" placeholder="correo@dominio.com">
                    </div> 
                    <div class="form-group ">
                        <input type="text" runat="server" id="PhonePerson" class="form-control" placeholder="Telefono">
                    </div> 
                </div>           
        </div> 
        <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary" OnClick="btnaceptar_Click" type="submit" runat="server" Text = "Agregar"   ></asp:Button><br /><br />      
    </form>
    </div>
    </div>
           
</asp:Content>
