using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M10;
using LogicaTangerine;
using DominioTangerine;
using Tangerine_Contratos;
using Tangerine_Presentador.M10;

namespace Tangerine_Presentador.M10
{
    public class PresentadorConsultaEmpleadoId
    {

        IContratoVerEmpleados vista;
        
          public PresentadorConsultaEmpleadoId(IContratoVerEmpleados vista)
        {
            this.vista = vista;
        }


         
        
        
        
        
        
        public void cargarEmpleadosId(int Id) 
          {
              try
              {
                  Entidad parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
                  ((DominioTangerine.Entidades.M10.EmpleadoM10)parametro).Id = Id;

                  Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.ConsultarIdEmpleado(parametro);
                  Entidad empleado = comando.Ejecutar();

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenDivRow;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos personales</h4>";

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Nombre" + ResourceGUIM10.CloseLabel;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                    ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_cedula.ToString() +
                    ResourceGUIM10.CloseInputTextDisabled +
                    ResourceGUIM10.CloseDiv + ResourceGUIM10.OpenFormGroup +
                    ResourceGUIM10.OpenInputText + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_p_nombre.ToString() +
                    ResourceGUIM10.Espacio + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_s_nombre.ToString() +
                    ResourceGUIM10.Espacio + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_p_apellido.ToString() +
                    ResourceGUIM10.Espacio + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_s_apellido.ToString() +
                    ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Genero" + ResourceGUIM10.CloseLabel;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_genero.ToString() +
                                  ResourceGUIM10.CloseInputTextDisabled +
                                  ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Fecha de nacimiento" + ResourceGUIM10.CloseLabel;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_fecha_nac.ToString("dd/MM/yyyy") +
                                  ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Edad" + ResourceGUIM10.CloseLabel;

                  //vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                  //                EmployeeAge(empleado.Emp_fecha_nac.ToString("yyyy")).ToString() + ResourceGUIM10.CloseInputTextDisabled +
                  //                ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Direccion" + ResourceGUIM10.CloseLabel;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).Adrress
                                  + ResourceGUIM10.CloseInputTextDisabled +
                                  ResourceGUIM10.CloseDiv;

                  //cierre de col
                  vista.FormViewEmployee.Text += ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos contrato</h4>";

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Fecha contratacion" + ResourceGUIM10.CloseLabel;
                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  Convert.ToDateTime((((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).jobs).FechaContratacion.ToString("dd/MM/yyyy"))+
                                  ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;


                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  (((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).jobs).FechaFin
                                  + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Cargo" + ResourceGUIM10.CloseLabel;
                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  (((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).jobs).Nombre
                                  + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Sueldo Base" + ResourceGUIM10.CloseLabel;
                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  (((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).jobs).Sueldo.ToString()
                                  + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenLabel + "Estatus" + ResourceGUIM10.CloseLabel;
                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_activo 
                                  + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                  //cierre de col
                  vista.FormViewEmployee.Text += ResourceGUIM10.CloseDiv;

                  //cierre de row
                  vista.FormViewEmployee.Text += ResourceGUIM10.CloseDiv;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenDivRow;

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos de contacto</h4>";

                  vista.FormViewEmployee.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                  ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_email.ToString() + ResourceGUIM10.CloseInputTextDisabled +
                                  ResourceGUIM10.CloseDiv;

                  //cierre de row
                  vista.FormViewEmployee.Text += ResourceGUIM10.CloseDiv;


                  //return vista.FormViewEmployee.Text; REVISAR!!!!

              }

              catch 
              {

              }
          }
          


    }
}
