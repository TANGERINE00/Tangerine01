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

                    <asp:ValidationSummary ID="ValidationSummary1" runat=server headertext="Hubo un error en la página:" />

                    <label for="input_cliente">Cliente (compañía contratante)
                    </label>
                    &nbsp;<asp:Literal runat="server" ID="seccion1"></asp:Literal>
                    <input type="text" class="form-control" id="cliente_id" placeholder="Nombre del Cliente" disabled>
                </div>
            

                    <!-- Date range -->
                    <div class="form-group">
                       <asp:Literal runat="server" ID="seccion2"></asp:Literal>
                    </div>    

             
                <!-- /.box-body -->

               <label for="input_costo">Total Factura</label>
                <div class="input-group">
                    
                    <span class="input-group-addon">$</span>
                    <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)" placeholder="24.230,00" disabled>
                </div>
                
                <div class="form-group">
                    <label>Moneda</label>
                    <select class="form-control">
                        <option></option>
                        <option>Dolares</option>
                        <option>Bolivares</option>
                        <option>Bitcoin</option>
                    </select>
                </div>

                <div class="form-group">
                    <label>Forma de Pago</label>
                    <select required class="form-control" disabled>
                        <option></option>
                        <option data-icon="fa-heart">Deposito</option>
                        <option>Transferencia</option>
                        <option>Otro</option>
                       </select>
                </div>

                <div class="form-group">
                   
                    <label for="input_cliente">Codigo de aprobacion</label>
                    <input type="text" id="codAprobacion" class="form-control"  placeholder="Codigo de aprobacion" runat="server"> 
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="codAprobacion" Display="Dynamic"  
                     runat="server" ErrorMessage="Debe ingresar un código de aprobación."></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="codAprobacion" ValidationExpression="\d{5}"
                     Display="Dynamic" runat="server" ErrorMessage="El código de aprobración debe ser de al menos 5 dígitos.">*</asp:RegularExpressionValidator>

                   
                </div>

            <div class="box-foot">
                <button type="submit" class="btn btn-primary" >Agregar</button>
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
