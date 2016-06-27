<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" 
    CodeBehind="CargarPago1.aspx.cs" 
    Inherits="Tangerine.GUI.M9.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestion de pagos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Cargar pago
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="/GUI/M1/Dashboard.aspx"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Pagos</a></li>
    <li><a href="SeleccionCompania.aspx">Seleccion de compania</a></li>
    <li><a href="FacturasPorPagar.aspx">Consulta facturas por pagar</a></li>
    <li class="active">Cargar pago</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
   <div id="alert" runat="server">
   </div>
    <div class="col-md-6">
     
    <div class="box box-primary">

        <!-- form start -->
        <form role="form" runat="server">
             <div class="box-body">

                    <asp:ValidationSummary 
                         id="ValSum" 
                         DisplayMode="BulletList" 
                         ShowSummary="true"                        
                         HeaderText="Ha habido un error:"
                         runat="server"/>

               


                      
                     <!--NUMERO DE FACTURA -->
       
     
                       <div class="form-group" runat="server">
                            <label for="input_cliente">Numero de Factura</label>
                            <input runat="server" type="text" class="form-control" 

                                pattern="([0-9]{1,3})([^'\x22])$"
                                id="numFactura" name="numFactura" 
                                placeholder="Introduzca el numero de factura correspondiente.e.g: 1" 
                                disabled="disabled">
                        </div>


                    
                         <div class="form-group" runat="server">
                            <label for="input_cliente">Cliente (compañía contratante)</label>
                            <input runat="server" type="text" class="form-control" 
                                 pattern="([a-z0-9.%+-])([A-Z])([^'\x22]){3,20}" 
                            
                                id="compCliente" name="compCliente" 
                                placeholder="Introduzca el nombre de la compañía. " disabled="disabled">
                        </div>


                    <div class="form-group" runat="server">
                            <label for="input_cliente">Proyecto</label>
                            <input runat="server" type="text" class="form-control" 
                                 pattern="([a-z0-9.%+-])([A-Z])([^'\x22]){3,20}" 
                            
                                id="proyectoNombre" name="proyectoNombre" 
                                placeholder="Introduzca el nombre del proyecto. " disabled="disabled">
                        </div>

                    

                    <div class="form-group" runat="server">
                            <label for="input_costo">Moneda Factura</label>
                            <input runat="server" type="text" class="form-control" 
                                 pattern="([a-z0-9.%+-])([A-Z])([^'\x22]){3,20}" 
                            
                                id="monedaPago" name="monedaPago" 
                                placeholder="Introduzca el nombre del proyecto.. e.g: USD , MXN , EUR " 
                                disabled="disabled">
                        </div>


                    
                    <div class="form-group" runat="server">
                            <label for="input_costo">Monto Factura</label>
                            <input runat="server" type="text" class="form-control" 
                                 pattern="([0-9]{1,10})([^'\x22])$" 
                            
                                id="montoFactura" name="montoFactura" 
                                placeholder="Introduzca el nombre del proyecto.. e.g: USD , MXN , EUR " 
                                disabled="disabled">
                        </div>



          
                <div class="form-group">
                    <label>Forma de Pago</label><label for="Requerido" style="color: red;">*</label>
                    
                    <select required runat="server" class="form-control" id="formaPago" name="formaPago">
                        <option></option>
                        <option data-icon="fa-heart">Deposito</option>
                        <option>Transferencia</option>
                        <option>Otro</option>
                       </select>
                </div>
                    <div class="form-group" runat="server">
                            <label for="input_cliente">Codigo de aprobacion</label>
                            <label for="Requerido" style="color: red;">*</label>
                            <input runat="server" type="text" class="form-control" 
                             pattern=\d{6} 
                                
                                id="codAprobacion" name="codAprobacion" tittle="numero de seis digitos"
                                placeholder="Introduzca el codigo de aprobacion de seis (6) digitos" required>
                        </div>


                    
                   
             

            <div class="box-foot">
                <asp:Button id="btnagregar" class="btn btn-primary" OnClick="btnagregar_Click" type="submit" 
                    runat="server" Text = "Agregar"></asp:Button>
                    
               
            </div>
        </div>

        </form>
    </div>
    
</div>
    

    <script>
        $(function () {

            //Date range picker
            $('#reservation').daterangepicker();

        });
    </script>
</asp:Content>
