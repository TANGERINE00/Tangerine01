<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="CargarPago1.aspx.cs" 
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
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Pagos</a></li>
    <li><a href="SeleccionCompania.aspx">Seleccion de compania</a></li>
    <li><a href="FacturasPorPagar.aspx">Consulta facturas por pagar</a></li>
    <li class="active">Cargar pago</li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
    <div class="col-md-6">
     
    <div class="box box-primary">

        <!-- form start -->
        <form role="form" runat="server">
            <div class="box-body">
                <div class="form-group">

                    <asp:ValidationSummary 
                         id="ValSum" 
                         DisplayMode="BulletList" 
                         ShowSummary="true"                        
                         HeaderText="Ha habido un error:"
                         runat="server"/>

                 <div>
                    <label for="input_cliente">Numero de Factura</label>
                     <input runat="server" type="text" class="form-control" id="numFactura" readonly="True"/>
                    
                </div>

                <div>
                    &nbsp;
                    <label for="input_cliente">Cliente (compañía contratante)</label>
                     <input runat="server" type="text" class="form-control" id="compCliente" readonly="True"/>
                    &nbsp;
                </div>
            

                    <div class="form-group">
                        &nbsp;
                       <label for="input_cliente">Proyecto</label>
                     <input runat="server" type="text" class="form-control" id="proyectoNombre" readonly="True"/>
                    </div>    

             
                <!-- /.box-body -->
                <label for="input_costo">Moneda Factura</label>
                <div class="input-group">
                     <input runat="server" type="text" class="form-control" id="monedaPago" readonly="True"/>
                    &nbsp;
                </div>
               <label for="input_costo">Monto Factura</label>
                <div class="input-group">
                     <input runat="server" type="text" class="form-control" id="montoFactura" readonly="True"/>
                    &nbsp;
                </div>
                

                <div class="form-group">
                    <label>Forma de Pago</label>
                    
                    <select required runat="server" class="form-control" id="formaPago" name="seccion">
                        <option></option>
                        <option data-icon="fa-heart">Deposito</option>
                        <option>Transferencia</option>
                        <option>Otro</option>
                       </select>
                </div>

                <div class="form-group">
                   
                    <label for="input_cliente">Codigo de aprobacion</label>
                    <input type="text" id="codAprobacion" class="form-control"  placeholder="Codigo de aprobacion" runat="server" required>

                    
                   <asp:RegularExpressionValidator id="RegularExpressionValidator1" 
                     ControlToValidate="codAprobacion"
                     ValidationExpression="\d{10}"
                     Display="Dynamic"
                     ErrorMessage="El código de aprobación debe ser de 10 caracteres numéricos."
                     ForeColor="red"
                     runat="server" ValidationGroup="AllValidations" />
                </div>

            <div class="box-foot">
                <asp:Button id="btnagregar" class="btn btn-primary" OnClick="btnagregar_Click" type="submit" runat="server" Text = "Agregar"></asp:Button>
                    
               
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
