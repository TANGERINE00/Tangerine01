<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="ConsultaProyecto.aspx.cs" Inherits="Tangerine.GUI.M7.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server"> 

    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#"> Proyectos </a></li>
    <li class="active"> Consulta Proyecto </li>

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
                <form role="form">
                  <div class="box-body">

                     <div class="form-group">
                      <label for="labelPropuesta_M7">Propuetsa Aprobada</label> </div><div>
                     <label name="propuestaAprobada" > sistema A </label>
                    </div>
                      
                      <div class="form-group">
                      <label for="labelNumeroFactura_M7">Nombre de proyecto</label>
                  </div><div>
                     <label name="nombreProyecto" > -Nombre del proyecto- </label>
                    </div>

                    <div class="form-group">
                      <label for="labelFecha_M7">Codigo del proyecto</label>
                      </div><div>
                     <label name="codigoProyecto" > Codigo </label>
                    </div>

                      <div class="form-group">
                      <label for="labelCliente_M7">Fecha de inicio</label>
                          </div><div>
                     <label name="fechaInicio" > dd/mm/yyy </label>
                    </div>

                        <div class="form-group">
                      <label for="labelProyecto_M7">Fecha Estimada de culminación</label></div><div>
                     <label name="fechaFin" > dd/mm/yyy </label>
                    </div>

                      
                        <div class="form-group">
                      <label for="labelMonto_M7">Costo estimado</label>
                      </div><div>
                     <label name="montoEstimado" > 100000 bs </label>
                    </div>

                       <div class="form-group">
                      <label for="labelMonto_M7">Porsentaje de realizacion</label>
                      </div><div>
                     <label name="realizacion" > 30 %</label>
                    </div>
                    
                      <hr />

                      

                  </div><!-- /.box-body -->

                </form>
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6">

                <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Personal del Proyecto</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form">
                  <div class="box-body">

                 <div class="form-group">
                      <label for="labelGerete_M7">Gerente de proyecto</label>
                     </div><div>
                     <label name="gerenteResponsable" >  Pedro Perez </label>
                    
                    </div>

                      <hr />

                       <div class="form-group">
                      <label for="labelPersonal_M7">Personal Responsable</label>
                      </div><div>
                     <label name="gerenteResponsablea" >  jose </label></div><div>
                     <label name="gerenteResponsableb" >  pedro </label></div><div>
                     <label name="gerenteResponsablec" >  ana </label>
                    
                     
                   
                    </div>
                      <hr />

                       <div class="form-group">
                      <label for="labelencargado_M7">Encargado de la empresa contratante</label>
                     </div><div>
                     <label name="Responsable" >  juan Rodriguez </label>
                         </div><div>
                     <label name="TelfResponsable" >  - Tlefono - </label>
                             </div><div>
                     <label name="Empresa" >  -Nombre Empresa- </label>


                    </div>
      </form>
                    </div>
          </div>
          </div>
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
