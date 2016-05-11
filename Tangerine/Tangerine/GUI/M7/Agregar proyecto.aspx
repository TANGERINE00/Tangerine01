<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Agregar proyecto.aspx.cs" Inherits="Tangerine.GUI.M7.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Proyectos</a></li>
    <li class="active">Crear Proyecto</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="row">
            <!-- left column -->
            <div class="col-md-6">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Nuevo Proyecto</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form" runat = "server">
                  <div class="box-body">

                     <div class="form-group">
                      <label for="labelPropuesta_M7">Propuetsa Aprobada *</label>
                     <select class="form-control" name="Propuesta Aprobada" > 
                     <option>sistema A</option>
                     <option> sistema B</option> </select>
                    </div>
                      
                      <div class="form-group">
                      <label for="labelNumeroFactura_M7">Nombre de proyecto *</label>
                      <input type="text" class="form-control" id="textNombreProyecto_M7" placeholder="Nombre Proyecto" name="textNombreProyecto_M7"  >
                    </div>

                    <div class="form-group">
                      <label for="labelFecha_M7">Codigo del proyecto * </label>
                      <input type="text" class="form-control" id="textCodigoProyecto_M7" placeholder="Codigo" >
                    </div>

                      <div class="form-group">
                      <label for="labelCliente_M7">Fecha de inicio *</label>
                      <input type="date" class="form-control" id="textFechaInicio_M7" placeholder="Feha de inicio"  >
                    </div>

                        <div class="form-group">
                      <label for="labelProyecto_M7">Fecha Estimada de culminación *</label>
                      <input type="date" class="form-control" id="textFechaCulminacion_M7" placeholder="Fecha fin" >
                    </div>

                      
                        <div class="form-group">
                      <la for="labelMonto_M7">Costo estimado *</label>
                      <input type="text" class="form-control" id="textCosto_M7" placeholder="0 Bs"  >
                    </div>

                       <div class="form-group">
                      <label for="labelMonto_M7">Porsentaje de realizacion *</label>
                      <input type="dropdownlist" class="form-control" id="textCosto_M7" placeholder="0 %"  > 
                    </div>
                    
                      <hr />

                      

                  </div><!-- /.box-body -->

                  <div class="box-footer">
                      
                    <asp:Button id="buttomGenerar_M7" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Generar" ></asp:Button>
               
                       </div><div>  <label>* Todos los campos son obligatorios</label></div>
                
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6">

                <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Personal del Proyecto </h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                
                  <div class="box-body">

                 <div class="form-group">
                      <label for="labelGerete_M7">Gerente de proyecto *</label>
                     <select class="form-control" name="gerenteProyecto" > 
                     <option>Pedro Perez</option>
                     <option> Ana Rodriguez</option> </select>
                    </div>

                      <hr />

                       <div class="form-group">
                      <label for="labelPersonal_M7">Personal Responsable *</label>
                     <select class="form-control" name="personalProyecto" > 
                     <option>jose</option>
                     <option> pedro</option> 
                         <option> maria</option>
                         <option> ana</option>
                     </select>
                    <asp:Button id="Button1" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Agregar"   ></asp:Button>
                  
                    </div>
                      <hr />

                       <div class="form-group">
                      <label for="labelencargado_M7">Encargado de la empresa contratante *</label>
                     <select class="form-control" name="EncargadoProyecto" > 
                     <option>Pedro Perez</option>
                     <option> Ana Rodriguez</option> </select>
                    </div>
      </form>
                    </div>
          </div>
          </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">   
</asp:Content>
