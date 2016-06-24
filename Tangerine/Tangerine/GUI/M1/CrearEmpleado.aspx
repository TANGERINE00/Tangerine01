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



                 
                <%--<Cedula de identidad>--%>            
                 <div class="form-group ">
                  <label for="Cedula">Cédula</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="text" runat="server" id="Cedula" class="form-control" maxlength="9" 
                      placeholder="Introduzca cédula Ej. 12345678" oninput="setCustomValidity('')" pattern="[^0][0-9]{1,9}" 
                      required oninvalid="setCustomValidity('Campo inválido o vacío')">                  
               </div>




                <%--<Primer Nombre>--%> 
            
             <div class="form-group ">
                  <label for="FirstName">Primer Nombre</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="text" runat="server" id="FirstName" class="form-control" maxlenght="20" placeholder="Introduzca primer nombre" oninput="setCustomValidity('')" pattern="^[a-zA-Záéíóúñ\s]*$" 
                      required oninvalid="setCustomValidity('Campo inválido o vacío')">
               </div>




               <%--<Segundo Nombre>--%> 
             <div class="form-group ">
                  <label for="SecondName">Segundo Nombre</label>
                  <input type="text" runat="server" id="SecondNamee" class="form-control" maxlenght="20" placeholder="Segundo Nombre">
               </div>


                <%--<Primer Apellido>--%> 
               
                 <div class="form-group ">
                  <label for="FirstLastName">Primer Apellido</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="text" runat="server" id="FirstLastName" class="form-control" maxlenght="20" 
                      placeholder="Primer Apellido" oninput="setCustomValidity('')" pattern="^[a-zA-Záéíóúñ\s]*$" 
                      required oninvalid="setCustomValidity('Campo inválido o vacío')">
               </div>
                


                <%--<Segundo Apellido>--%> 
               <div class="form-group ">
                  <label for="SecondName">Segundo Nombre</label>
                  <input type="text" runat="server" id="SecondLastName" class="form-control" maxlenght="20" placeholder="Segundo Apellido">
               </div>

                <%--<Seleccionar Genero Combo Box >--%> 
               <div class="form-group ">
                  <label for="SelectedListGender">Genero</label> <label for="Requerido" style="color: red;">*</label>
                  <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListGender">
                  </asp:DropDownList>
               </div>

               <%--<Fecha de Nacimiento>--%> 
             <div class="form-group date">
                  <label for="DateEmployee">Fecha de Nacimiento</label> <label for="Requerido" style="color: red;">*</label>
                  <div class="form-control input-group date">
                     <input type="date" class="form-control" placeholder="fecha de nacimiento" id="DateEmployee"
                         runat="server" min="1916-01-01" max="2001-01-01" oninput="setCustomValidity('')"
                         required oninvalid="setCustomValidity('Porfavor colocar una fecha entre 1916 y 2001')">
                     <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                     </div>
                  </div>
                 </div>



               <%--<Nivel de Estudio>--%> 
               <div class="form-group">
                  <label for="LevelListStudy">Nivel de estudio</label> <label for="Requerido" style="color: red;">*</label>
                  <asp:DropDownList runat="server" CssClass="form-control" ID="LevelListStudy">
                  </asp:DropDownList>
               </div>
            </div>



            <%--<Datos de Contrato>--%> 
            <div class="col-xs-12 col-md-6 col-lg-6">
               <h4>Datos de Contrato</h4>
                <%--<Fecha de Contratación>--%> 
              <div class="form-group">
                  <label for="DateJob">Fecha de contratación</label> <label for="Requerido" style="color: red;">*</label>
                  <div class="form-control input-group date">
                     <input type="date" class="form-control" placeholder="fecha de contratacion" id="DateJob" 
                         runat="server"  min="1976-01-01" max="2016-12-31" oninput="setCustomValidity('')"
                         required oninvalid="setCustomValidity('Porfavor colocar una fecha entre 1976 y 2016')">
                     <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                     </div>
                  </div>
                 </div>

                


                <%--<Seleccionar Lista de Cargo>--%> 
               <asp:ScriptManager ID="MainScriptManager" runat="server" />
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
                    <div class="form-group">
                        <label for="SelectedListJob">Cargo</label> <label for="Requerido" style="color: red;">*</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListJob" AutoPostBack="true">
                        </asp:DropDownList>
                     </div>
                    
                      <%--<Descripcion del cargo>--%> 
                       <%-- <div class="form-group">
                        <textarea class="form-control" rows="3" runat="server" id="JobSummary" placeholder="Descripcion de cargo" disabled></textarea>
                        </div>--%>
                  </ContentTemplate>
               </asp:UpdatePanel>




               <%--<Modalidad de Contrato>--%> 
               <div class="form-group">
                  <label for="JobMode">Modalidad del Contrato</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="text" runat="server" id="JobMode" class="form-control" maxlenght="20" 
                      placeholder="Ej: Medio tiempo, tiempo completo, etc" oninput="setCustomValidity('')" pattern="^[a-zA-Záéíóúñ\s]*$" 
                      required oninvalid="setCustomValidity('Campo inválido o vacío')">
               </div>
               
               <%--<Salario>--%>
              
                 <div class="form-group">
                  <label for="SalaryJob">Sueldo base</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="text" runat="server" id="SalaryJob" class="form-control" placeholder="BsF." maxlenght="8"
                        oninput="setCustomValidity('')" pattern="^[0-9]*$" required 
                        oninvalid ="setCustomValidity('Campo inválido o vacío')">
               </div>
               
             

       

                <%--<Datos de Contacto>--%>
               <h4>Datos de Contacto</h4>
                <%--<Email>--%>
                <div class="form-group ">
                  <label for="EmailPerson">Correo personal</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="email" runat="server" id="EmailPerson" maxlenght="15" class="form-control" 
                  placeholder="Introduzca una direccion email Ej: correo@dominio.com" required>
                  <%--<asp:RegularExpressionValidator 
                     ID="regexEmailValid" 
                     runat="server" 
                     ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                     ControlToValidate="EmailPerson" 
                     ErrorMessage="Formato de correo invalido" 
                     ForeColor="White">
                  </asp:RegularExpressionValidator>--%>
               </div>
               
          
                <%--<Telefono>--%>
             <div class="form-group ">
                  <label for="PhonePerson">Teléfono</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="text" runat="server" id="PhonePerson" class="form-control"  
                      pattern="^([0-9]{4}\-[0-9]{7})?(\+[0-9]{1,2}\ [0-9]{3}\-[0-9]{7})?$" 
                      placeholder="Introduzca un numero de teléfono Ej: 0212-7537598" 
                      maxlength="15" required>
               </div>
               </div>

             </div>
      
           
        
         <%--<Datos de Domicilio>--%>
         <div class="row">
            <div class="col-xs-12 col-md-6 col-lg-6">
               <h4>Datos de Domicilio</h4>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                      <%--<Seleccionar Lista de Paises>--%>
                     <div class="form-group">
                        <label for="SelectedListCountry">País</label> <label for="Requerido" style="color: red;">*</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListCountry" OnTextChanged="SelectedCountry_Change" AutoPostBack="true">
                        </asp:DropDownList>
                     </div>

                     <%--<Seleccionar Lista de Estado>--%>
                    <div class="form-group ">
                        <label for="SelectedListState">Estado</label> <label for="Requerido" style="color: red;">*</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="SelectedListState">
                        </asp:DropDownList>
                     </div>
                  </ContentTemplate>
               </asp:UpdatePanel>
               
                <%--<Ciudad>--%>
              <div class="form-group ">
                  <label for="CityAddress">Ciudad</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="text" runat="server" id="CityAddress" class="form-control" maxlenght="20" 
                      placeholder="Ciudad, parroquia o provincia" oninput="setCustomValidity('')" pattern="^[a-zA-Záéíóúñ\s]*$" 
                      required oninvalid="setCustomValidity('Campo inválido o vacío')">
               </div>

              <%--<Dirección>--%>
               <div class="form-group ">
                  <label for="AddressEspecific">Dirección de habitación</label> <label for="Requerido" style="color: red;">*</label>
                  <input type="text" runat="server" id="AddresEspecific" class="form-control" maxlenght="50" 
                      placeholder="Habitacion" pattern="^[-.,0-9a-zA-Záéíóúñ\s]*$"
                      required oninvalid="setCustomValidity('Campo inválido o vacío')">
               </div>


            </div>
         </div>
         <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary" causesvalidation="true"  validationgroup="GrupoEmpleado" OnClick="btnaceptar_Click" type="submit"  runat="server" Text = "Agregar" ></asp:Button>
         <br /><br />  
      </form>
   </div>
</div>           
</asp:Content>
