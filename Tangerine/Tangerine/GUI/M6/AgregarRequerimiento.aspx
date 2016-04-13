<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarRequerimiento.aspx.cs" Inherits="Tangerine.GUI.M6.AgregarRequerimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Propuestas</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="subtitulo" Runat="Server">Agregar Propuesta</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alert" runat="server">
        </div>
    </div>

    <form  class="form-horizontal" >
        <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
            <div class="form-group">
                <div id="div_nombre" class="col-sm-8 col-md-8 col-lg-8">
				    <input runat="server" type="text" id="Input_Nombre" placeholder="Nombre" onblur="fillCodigoTextField()" class="form-control" name="nombre"/>
                   
			    </div>
		        
                &nbsp;
			    <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
				    <input runat="server" type="text" id="Input_Codigo" placeholder="Codigo" class="form-control" name="codigo" maxlength="3" minlength="1"/>
			    </div>
		    </div>
            <div class="form-group">
	            <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
		            <textarea runat="server" id="Input_Descripcion" placeholder="Descripcion" class="form-control" name="descripcion" rows="3"></textarea>
		        </div>
	        </div>
            <label>Moneda</label>
            <div class="form-group">
                <div class="col-sm-1 col-md-1 col-lg-1">
                    <asp:DropDownList id="comboMoneda"  class="btn btn-default dropdown-toggle" runat="server">
                    </asp:DropDownList>
                </div>
                <%--<div id="div_precio" class="col-sm-3 col-md-3 col-lg-3">
                       <input runat="server" type="text" id="Input_Precio" placeholder="Precio" class="form-control" name="precio"/>
                </div>--%>
                
<%--                <div id="div_estado" class="col-sm-3 col-md-3 col-lg-3">
                    <asp:checkbox runat="server" id="csEstado" AutoPostBack="true" Text="" Checked="true" Enabled="false"/>
                </div>--%>
	        </div>

            <%--<div class="form-group">
	            <div id="div_cliente" class="col-sm-12 col-md-12 col-lg-12">
                    <label>Cliente</label>
                    <br>
                    <asp:DropDownList id="comboTipoCliente"  class="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged="actualizarComboCliente" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>--%>
           <%-- <div class="form-group">
	            <div id="div_clientes" class="col-sm-12 col-md-12 col-lg-12">
                    <asp:DropDownList id="dpCLientes"  class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>--%>

            <!--<div class="form-group">
	            <div id="div_nota" class="col-sm-12 col-md-12 col-lg-12">
                    <label class="note">¿No encuentra el cliente que busca? <a class="bootstrapBlue" href="../Modulo2/AgregarCliente.aspx">Haz click aqui para agregarlo.</a></label>
                </div>
            </div>-->

            <br>
            <div class="form-group">
		        <div class="col-sm-1 col-md-1 col-lg-1">
				    <button runat="Server" type="submit" class="btn btn-primary">Crear</button>
			    </div>
                <div class="col-sm-1 col-md-1 col-lg-1">
				    <button class="btn btn-default" onclick="goBack()">Cancelar</button>
			    </div>
	        </div>
        </div>
   </form>

     <script src="js/jquery.min.js"></script>
    <script src="js/Validacion.js"></script>

    <script type="text/javascript">
        $("#Input_Moneda li a").click(function () {
            $("#Input_Moneda").html($(this).text() + ' <span class="caret"></span>');
        });
    </script>
    <script type="text/javascript">
        function goBack() {
            window.history.back();
        }
    </script>
    <script type="text/javascript">
        function fillCodigoTextField() {
            var codigoTextField = document.getElementById("Codigo");
            var nombreTextField = document.getElementById("Nombre");

            var text = nombreTextField.value.trim(); // se eliminan los espacios innecesarios del comienzo y final del string
            nombreTextField.value = text;

            if (nombreTextField.value.length >= 1) { //antes de llenar el codigo revisa si al menos tiene un caracter
                codigoTextField.value = "";
                var words = text.split(" ");//crea una array de palabras del nombre del proyecto 

                //switch (words.length) { //dependiendo de la cantidad de palabras...
                //    case 1: // Agarra las 3 primeras letras de la palabra 
                //        for (i = 0; i < 3; i++) {
                //            temp = words[0];
                //            codigoTextField.value = codigoTextField.value + temp.charAt(i).toUpperCase(); // va concatenando cada una de las primeras letras mayuscula.    
                //        }
                //        break
                //    case 2: // Toma las dos primeras letras de la primera palabra y la primera de la segunda palabra
                //        for (i = 0; i < 2; i++) {
                //            temp = words[0];
                //            codigoTextField.value = codigoTextField.value + temp.charAt(i).toUpperCase(); // va concatenando cada una de las primeras letras en mayuscula.    
                //        }
                //        temp = words[1];
                //        codigoTextField.value = codigoTextField.value + temp.charAt(0).toUpperCase();

                //        break
                //    case 3: //toma la primera letra de cada palabra 
                //        for (i in words) {
                //            if (i < 3) {
                //                temp = words[i];
                //                codigoTextField.value = codigoTextField.value + temp.charAt(0).toUpperCase(); // va concatenando cada una de las primeras letras de cada palabra en mayuscula.
                //            }
                //        }
                //        break
                //    default: //por defecto usa el algoritmo del caso 3: toma la primera letra de cada palabra 
                //        for (i in words) {
                //            if (i < 3) {
                //                temp = words[i];
                //                codigoTextField.value = codigoTextField.value + temp.charAt(0).toUpperCase(); // va concatenando cada una de las primeras letras de cada palabra en mayuscula.
                //            }
                //        }
                //}
            }
        }
    </script>
    
    </asp:Content>

