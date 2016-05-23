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
                    <label for="Cedula">Cédula</label> <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="Cedula" class="form-control" maxlength="20" placeholder="Introduzca cédula" required>
                      <asp:RegularExpressionValidator id="RegularExpressionValidator1"
                            ControlToValidate="Cedula"
                            ValidationExpression="\d+"
                            Display="Static"
                            EnableClientScript="true"
                            ErrorMessage="Por favor inserte un valor numerico"
                            runat="server"/>
                  </div>
                  <div class="form-group ">
                    <label for="FirstName">Primer Nombre</label> <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="FirstName" class="form-control" maxlenght="20" placeholder="Introduzca primer nombre" required>
                  </div>
                  <div class="form-group ">
                    <label for="SecondName">Segundo Nombre</label>
                    <input type="text" runat="server" id="SecondNamee" class="form-control" maxlenght="20" placeholder="Segundo Nombre">
                  </div>
                  <div class="form-group ">
                    <label for="FirstLastName">Primer Nombre</label> <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="FirstLastName" class="form-control" maxlenght="20" placeholder="Primer Apellido" required>
                  </div>
                  <div class="form-group ">
                    <label for="SecondName">Segundo Nombre</label>
                    <input type="text" runat="server" id="SecondLastName" class="form-control" maxlenght="20" placeholder="Segundo Apellido">
                  </div>
                  <div class="form-group ">
                    <label for="SelectedListGender">Genero</label> <label for="Requerido" style="color: red;">*</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListGender">
                    </asp:DropDownList>
                  </div>
                   <div class="form-group">
                    <label for="DateEmployee">Fecha de Nacimiento</label> <label for="Requerido" style="color: red;">*</label>
                        <div class="form-control input-group date" data-provide="datepicker">
                          <input type="text" class="form-control" placeholder="fecha de nacimiento" id="DateEmployee" runat="server" required>
                          <div class="input-group-addon">
                              <span class="glyphicon glyphicon-th"></span>
                          </div>
                        </div>
                       <asp:CompareValidator
                            id="dateValidator" runat="server" 
                            Type="Date"
                            Operator="DataTypeCheck"
                            ControlToValidate="DateEmployee" 
                            ErrorMessage="Por favor introduzca una fecha válida.">
                        </asp:CompareValidator>
                   </div>
                   <div class="form-group">
                    <label for="LevelListStudy">Nivel de estudio</label> <label for="Requerido" style="color: red;">*</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="LevelListStudy">
                        </asp:DropDownList> 
                   </div>

               </div>
                   
                <!--columna 2-->
                <div class="col-xs-12 col-md-6 col-lg-6">
                  <h4>Datos de Contrato</h4>
                  <div class="form-group">
                    <label for="DateJob">Fecha de contratación</label> <label for="Requerido" style="color: red;">*</label>
                        <div class="form-control input-group date" data-provide="datepicker">
                          <input type="text" class="form-control" placeholder="fecha de contratacion" id="DateJob" runat="server" required>
                          <div class="input-group-addon">
                              <span class="glyphicon glyphicon-th"></span>
                          </div>
                        </div>
                       <asp:CompareValidator
                            id="CompareValidator2" runat="server" 
                            Type="Date"
                            Operator="DataTypeCheck"
                            ControlToValidate="DateJob" 
                            ErrorMessage="Por favor introduzca una fecha válida.">
                        </asp:CompareValidator>
                  </div>
                  
                 <asp:ScriptManager ID="MainScriptManager" runat="server" />
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label for="SelectedListJob">Cargo</label> <label for="Requerido" style="color: red;">*</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListJob" OnTextChanged="SelectedJob_Change" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                          <div class="form-group">
                                <textarea class="form-control" rows="3" runat="server" id="JobSummary" placeholder="Descripcion de cargo" disabled></textarea>
                          </div>
                        </ContentTemplate>
                 </asp:UpdatePanel>


                  <div class="form-group">
                    <label for="JobMode">Modalidad del Contrato</label> <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="JobMode" class="form-control" placeholder="Ej: Medio tiempo, tiempo completo, etc" required>
                  </div>
                  <div class="form-group">
                    <label for="SalaryJob">Sueldo base</label> <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="SalaryJob" class="form-control" placeholder="BsF." required>
                      
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
                                <label for="SelectedListCountry">País</label> <label for="Requerido" style="color: red;">*</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListCountry" OnTextChanged="SelectedCountry_Change" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group ">
                                <label for="SelectedListState">Estado</label> <label for="Requerido" style="color: red;">*</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListState">
                                </asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                  <div class="form-group ">
                    <label for="CityAddress">Ciudad</label> <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="CityAddress" class="form-control" maxlenght="30" placeholder="Ciudad, parroquia o provincia" required>
                  </div>
                  <div class="form-group ">
                    <label for="AddressEspecific">Dirección de habitación</label> <label for="Requerido" style="color: red;">*</label>
                    <input type="text" runat="server" id="AddresEspecific" class="form-control" maxlenght="50" placeholder="Habitacion" required>
                  </div>       
                </div> 
                <div class="col-xs-12 col-md-6 col-lg-6">
                    <h4>Datos de Contacto</h4>
                    <div class="form-group ">
                        <label for="EmailPerson">Correo personal</label> <label for="Requerido" style="color: red;">*</label>
                        <input type="text" runat="server" id="EmailPerson" maxlenght="15" class="form-control" placeholder="correo@dominio.com" required>
                        <asp:RegularExpressionValidator 
                            ID="regexEmailValid" 
                            runat="server" 
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ControlToValidate="EmailPerson" 
                            ErrorMessage="Formato de correo invalido" 
                            ForeColor="White">
                        </asp:RegularExpressionValidator>
                    </div> 
                    <div class="form-group ">
                        <label for="PhonePerson">Teléfono</label> <label for="Requerido" style="color: red;">*</label>
                        <input type="text" runat="server" id="PhonePerson" class="form-control" maxlenght="20" placeholder="Telefono" required>
                    </div> 
                </div>           
        </div> 
        <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary" OnClick="btnaceptar_Click" type="submit" runat="server" Text = "Agregar"   ></asp:Button><br /><br />      
    </form>
    </div>
    </div>
           
</asp:Content>
