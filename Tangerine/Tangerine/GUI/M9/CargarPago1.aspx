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
                    &nbsp;<asp:Literal runat="server" ID="seccion4"></asp:Literal>
                     &nbsp;
                </div>

                <div>
                    &nbsp;
                    <label for="input_cliente">Cliente (compañía contratante)</label>
                    &nbsp;<asp:Literal runat="server" ID="seccion1"></asp:Literal>
                    &nbsp;
                </div>
            

                    <div class="form-group">
                        &nbsp;
                       <label for="input_cliente">Proyecto</label>
                       <asp:Literal runat="server" ID="seccion2"></asp:Literal>
                    </div>    

             
                <!-- /.box-body -->
                &nbsp;
               <label for="input_costo">Total Factura</label>
                <div class="input-group">
                    <asp:Literal runat="server" ID="seccion3"></asp:Literal>
                    &nbsp;
                </div>
                

                <div class="form-group">
                    <label>Forma de Pago</label>
                    <select required class="form-control">
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
                     ValidationExpression="\d{5}"
                     Display="Dynamic"
                     ErrorMessage="El código de aprobación debe ser min de 5 caracteres númericos."
                     ForeColor="red"
                     runat="server" ValidationGroup="AllValidations" />
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
