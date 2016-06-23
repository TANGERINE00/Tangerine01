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
    <li><a href="EmpleadosAdmin.aspx?EmployeeId=0" > Gestión de Empleados</a></li>
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
                    <label>Cédula</label><label style="color: red;">*</label>
                           
                      <asp:TextBox id="Cedula2" runat="server"  CssClass="form-control" maxlength="9" placeholder
                          ="Introduzca cédula"></asp:TextBox>

                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                          ControlToValidate="Cedula2"
                          ErrorMessage="Por favor inserte un valor numerico" ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 

                        </asp:requiredfieldvalidator>
                                     
                         <asp:RangeValidator ID="RangeValidator2"                           
                            ControlToValidate = "Cedula2"                            
                            ErrorMessage = "La cedula tiene que ser entre 1 y 100000000" 
                            ForeColor="Red"
                            Type="Integer"
                            MaximumValue = "100000000" MinimumValue = "1" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RangeValidator>
                      
                  </div>
                  <div class="form-group ">
                    <label for="FirstName">Primer Nombre</label> <label for="Requerido" style="color: red;">*</label>
                    <asp:TextBox id="PrimerNombre" runat="server"  CssClass="form-control" maxlength="20" placeholder=
                        "Introduzca primer nombre"></asp:TextBox>
                        
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                          ControlToValidate="PrimerNombre"
                          ErrorMessage="Por favor inserte un nombre"
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 

                        </asp:requiredfieldvalidator>
                                     
                         <asp:RegularExpressionValidator 
                            ID="RegularExpression1"                           
                            ControlToValidate = "PrimerNombre"                            
                            ErrorMessage = "Por favor inserte un nombre válido" 
                            ForeColor="Red"                            
                            ValidationExpression="[a-z A-Z ñáéíóú]{2,20}" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RegularExpressionValidator>
                        
                  </div>
                  <div class="form-group ">
                    <label for="SecondName">Segundo Nombre</label>
                    <asp:TextBox id="SecondName" runat="server"  CssClass="form-control" maxlength="20" placeholder=
                        "Introduzca segundo nombre"></asp:TextBox>
                            
                      <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator2"                           
                            ControlToValidate = "SecondName"                            
                            ErrorMessage = "Por favor inserte un segundo nombre válido" 
                            ForeColor="Red"                            
                            ValidationExpression="[a-z A-Z ñáéíóú]{2,20}" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RegularExpressionValidator>
                      
                  </div>
                  <div class="form-group ">
                    <label for="FirstLastName">Primer Apellido</label> <label for="Requerido" style="color: red;">*</label>
                   
                    <asp:TextBox id="FirstLastName" runat="server"  CssClass="form-control" maxlength="20" placeholder=
                        "Introduzca primer apellido"></asp:TextBox>
                        
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                          ControlToValidate="FirstLastName"
                          ErrorMessage="Por favor inserte primer apellido"
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 

                        </asp:requiredfieldvalidator>
                                     
                         <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator4"                           
                            ControlToValidate = "FirstLastName"                            
                            ErrorMessage = "Por favor inserte un apellido válido" 
                            ForeColor="Red"                            
                            ValidationExpression="[a-z A-Z ñáéíóú]{2,20}" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RegularExpressionValidator>                  
                  
                  </div>
                  <div class="form-group ">
                    <label for="SecondLastName">Segundo Apellido</label>
                  
                    <asp:TextBox id="SecondLastName" runat="server"  CssClass="form-control" maxlength="20" placeholder=
                        "Introduzca segundo apellido"></asp:TextBox>
                            
                      <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator5"                           
                            ControlToValidate = "SecondLastName"                            
                            ErrorMessage = "Por favor inserte un segundo nombre válido" 
                            ForeColor="Red"                            
                            ValidationExpression="[a-z A-Z ñáéíóú]{2,20}" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RegularExpressionValidator>
                  
                  
                  </div>
                  <div class="form-group ">
                    <label for="SelectedListGender">Genero</label> <label for="Requerido" style="color: red;">*</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListGender">
                    </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                          ControlToValidate="SelectedListGender"
                          ErrorMessage="Por favor seleccione un genero"
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado" 
                          InitialValue = "Seleccione Genero"                    
                          runat="server">
                        </asp:requiredfieldvalidator>

                      
                  </div>
                   <div class="form-group">
                    <label for="DateEmployee">Fecha de Nacimiento</label> <label for="Requerido" style="color: red;">*</label>
                        <div class="form-control input-group date" data-provide="datepicker">
                              <asp:TextBox id="DateEmployee" runat="server"  CssClass="form-control" maxlength="10" placeholder=
                                  "fecha de nacimiento"></asp:TextBox>
                            <div class="input-group-addon">
                              <span class="glyphicon glyphicon-th"></span>
                          </div>
                        </div>
                     
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator19"
                          ControlToValidate="DateEmployee"
                          ErrorMessage="Por favor seleccione una fecha" 
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 
                        </asp:requiredfieldvalidator>

                       

                       <asp:RangeValidator ID="RangeValidator19"                           
                            ControlToValidate = "DateEmployee"                            
                            ErrorMessage = "Solo admite formato de fechas" 
                            ForeColor="Red"
                            Type="Date"
                            MinimumValue = "01-01-1916" 
                            MaximumValue = "01-01-2001"  
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RangeValidator> 

                       
                   </div>
                   <div class="form-group">
                    <label for="LevelListStudy">Nivel de estudio</label> <label for="Requerido" style="color: red;">*</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="LevelListStudy">
                        </asp:DropDownList> 

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                          ControlToValidate="LevelListStudy"
                          ErrorMessage="Por favor seleccione un nivel de estudio"
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado" 
                          InitialValue = "Seleccione Nivel"                    
                          runat="server">
                        </asp:requiredfieldvalidator>

                   </div>

               </div>
                   
                <!--columna 2-->
                <div class="col-xs-12 col-md-6 col-lg-6">
                  <h4>Datos de Contrato</h4>
                  <div class="form-group">
                    <label for="DateJob">Fecha de contratación</label> <label for="Requerido" style="color: red;">*</label>
                        <div class="form-control input-group date" data-provide="datepicker">
                          <asp:TextBox id="DateJob" runat="server"  CssClass="form-control" maxlength="10" placeholder=
                                  "fecha de contratacion"></asp:TextBox>
                            <div class="input-group-addon">
                              <span class="glyphicon glyphicon-th"></span>
                          </div>
                        </div>
                       
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator21"
                          ControlToValidate="DateJob"
                          ErrorMessage="Por favor seleccione una fecha" 
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 
                        </asp:requiredfieldvalidator>
                                            

                       <asp:RangeValidator ID="RangeValidator21"                           
                            ControlToValidate = "DateJob"                            
                            ErrorMessage = "Solo admite formato de fechas" 
                            ForeColor="Red"
                            Type="Date"
                            MinimumValue = "23-06-2016" 
                            MaximumValue = "23-06-2017"  
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RangeValidator> 


                  </div>
                  
                 <asp:ScriptManager ID="MainScriptManager" runat="server" />
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label for="SelectedListJob">Cargo</label> <label for="Requerido" style="color: red;">*</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListJob" OnTextChanged="SelectedJob_Change" AutoPostBack="true">
                                </asp:DropDownList>

                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                                      ControlToValidate="SelectedListJob"
                                      ErrorMessage="Por favor seleccione un cargo"
                                      ForeColor="Red"
                                      validationgroup="GrupoEmpleado" 
                                      InitialValue = "Seleccionar un cargo"                  
                                      runat="server">
                                </asp:requiredfieldvalidator>


                            </div>
                          <div class="form-group">
                                <textarea class="form-control" rows="3" runat="server" id="JobSummary" placeholder="Descripcion de cargo" disabled></textarea>
                          </div>
                        </ContentTemplate>
                 </asp:UpdatePanel>


                  <div class="form-group">
                    <label for="JobMode">Modalidad del Contrato</label> <label for="Requerido" style="color: red;">*</label>
<%--                    <input type="text" runat="server" id="JobMode" class="form-control" placeholder="Ej: Medio tiempo, tiempo completo, etc" >--%>
                    <asp:TextBox id="JobMode" runat="server"  CssClass="form-control" maxlength="20" placeholder
                          ="Ej: Medio tiempo, tiempo completo, etc" ></asp:TextBox>
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                          ControlToValidate="JobMode"
                          ErrorMessage="Por favor inserte un modo de empleo"
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 

                        </asp:requiredfieldvalidator>
                                     
                         <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator13"                           
                            ControlToValidate = "JobMode"                            
                            ErrorMessage = "Por favor inserte un modo de emleo válido" 
                            ForeColor="Red"                            
                            ValidationExpression="[a-z A-Z ñáéíóú]{2,20}" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RegularExpressionValidator>
                  </div>
                  <div class="form-group">
                    <label for="SalaryJob">Sueldo base</label> <label for="Requerido" style="color: red;">*</label>
                   

                      <asp:TextBox id="SalaryJob" runat="server"  CssClass="form-control" maxlength="9" placeholder
                          ="BsF." ></asp:TextBox>

                      <asp:RequiredFieldValidator ID="RequiredFieldValidator18"
                          ControlToValidate="SalaryJob"
                          ErrorMessage="Por favor inserte un valor numerico" ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 

                        </asp:requiredfieldvalidator>
                                     
                         <asp:RangeValidator ID="RangeValidator18"                           
                            ControlToValidate = "SalaryJob"                            
                            ErrorMessage = "El salario tiene que ser entre 1 y 100.000.000" 
                            ForeColor="Red"
                            Type="Integer"
                            MaximumValue = "100000000" MinimumValue = "1" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RangeValidator>




                      
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

                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                      ControlToValidate="SelectedListCountry"
                                      ErrorMessage="Por favor seleccione un país"
                                      ForeColor="Red"
                                      validationgroup="GrupoEmpleado" 
                                      InitialValue =  "Seleccionar un país"                    
                                      runat="server">
                                </asp:requiredfieldvalidator>

                            </div>
                            <div class="form-group ">
                                <label for="SelectedListState">Estado</label> <label for="Requerido" style="color: red;">*</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListState">
                                 </asp:DropDownList>

                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                      ControlToValidate="SelectedListState"
                                      ErrorMessage="Por favor seleccione un estado"
                                      ForeColor="Red"
                                      validationgroup="GrupoEmpleado" 
                                      InitialValue =  "Seleccionar un estado"                    
                                      runat="server">
                                </asp:requiredfieldvalidator>

                                
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                  <div class="form-group ">
                    <label for="CityAddress">Ciudad</label> <label for="Requerido" style="color: red;">*</label>
<%--                    <input type="text" runat="server" id="CityAddress" class="form-control" maxlenght="30" placeholder="Ciudad, parroquia o provincia" >--%>
                    
                      <asp:TextBox id="CityAddress" runat="server"  CssClass="form-control" maxlength="20" placeholder
                          ="Ciudad, parroquia o provincia" ></asp:TextBox>
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                          ControlToValidate="CityAddress"
                          ErrorMessage="Por favor inserte una ciudad"
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 

                        </asp:requiredfieldvalidator>
                                     
                         <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator14"                           
                            ControlToValidate = "CityAddress"                            
                            ErrorMessage = "Por favor inserte una ciudad válida" 
                            ForeColor="Red"                            
                            ValidationExpression="[a-z A-Z ñáéíóú]{2,20}" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RegularExpressionValidator>  
                      
                       </div>
                  <div class="form-group ">
                    <label for="AddressEspecific">Dirección de habitación</label> <label for="Requerido" style="color: red;">*</label>
                     
                      <asp:TextBox id="AddresEspecific" runat="server"  CssClass="form-control" maxlength="50" placeholder
                          ="Habitacion" ></asp:TextBox>
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator15"
                          ControlToValidate="AddresEspecific"
                          ErrorMessage="Por favor inserte una dirección"
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 
                        </asp:requiredfieldvalidator>
                                     
                         <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator15"                           
                            ControlToValidate = "AddresEspecific"                            
                            ErrorMessage = "Por favor inserte una dirección válida" 
                            ForeColor="Red"                            
                            ValidationExpression="[a-z A-Z ñáéíóú]{2,50}" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RegularExpressionValidator>               
                  
                  
                  </div>       
                </div> 
                <div class="col-xs-12 col-md-6 col-lg-6">
                    <h4>Datos de Contacto</h4>
                    <div class="form-group ">
                        <label for="EmailPerson">Correo personal</label> <label for="Requerido" style="color: red;">*</label>

                        <asp:TextBox id="EmailPerson" runat="server"  CssClass="form-control" maxlength="50" placeholder
                          ="correo@dominio.com" ></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16"
                          ControlToValidate="EmailPerson"
                          ErrorMessage="Por favor inserte un correo"
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 
                        </asp:requiredfieldvalidator>

                         <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator16"                           
                            ControlToValidate = "EmailPerson"                            
                            ErrorMessage = "Por favor inserte un correo válido" 
                            ForeColor="Red"                            
                            ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RegularExpressionValidator>  
                        
                    </div> 
                    <div class="form-group ">
                        <label for="PhonePerson">Teléfono</label> <label for="Requerido" style="color: red;">*</label>
                        <%--<input type="text" runat="server" id="PhonePerson" class="form-control" maxlenght="11" placeholder="Telefono" >--%>
                        
                         <asp:TextBox id="PhonePerson" runat="server"  CssClass="form-control" maxlength="11" placeholder
                          ="Telefono" ></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17"
                          ControlToValidate="PhonePerson"
                          ErrorMessage="Por favor inserte un valor numerico" 
                          ForeColor="Red"
                          validationgroup="GrupoEmpleado"                         
                          runat="server"> 
                        </asp:requiredfieldvalidator>

                         <asp:RangeValidator ID="RangeValidator17"                           
                            ControlToValidate = "PhonePerson"                            
                            ErrorMessage = "El teléfono tiene que ser entre 1 y 99999999999" 
                            ForeColor="Red"
                            Type="Double"
                            MaximumValue = "99999999999" MinimumValue = "1" 
                            validationgroup="GrupoEmpleado"
                            runat = "server">                        
                        </asp:RangeValidator> 
                        
                   </div> 
                </div>           
        </div> 
        <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary" causesvalidation="true"  validationgroup="GrupoEmpleado" OnClick="btnaceptar_Click" type="submit"  runat="server" Text = "Agregar" ></asp:Button><br /><br />  
          
    </form>
    </div>
    </div>
           
</asp:Content>
