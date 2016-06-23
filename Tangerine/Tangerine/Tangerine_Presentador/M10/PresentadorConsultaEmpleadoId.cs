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


        /// <summary>
        /// Metodo para calcular la edad del empleado 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private string EdadEmpleado(string year)
        {
            int age;
            age = Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(year);
            return age.ToString();
        }


        /// <summary>
        /// Metodo para mostrar en ventana VerEmpleado todo los datos de un empleado en especifico 
        /// </summary>
        /// <param name="Id"></param>
        public void cargarEmpleadosId(int Id)
        {
            try
            {
                Entidad parametro = DominioTangerine.Fabrica.FabricaEntidades.ConsultarEmpleados();
                ((DominioTangerine.Entidades.M10.EmpleadoM10)parametro).emp_id = Id;

                Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.ConsultarIdEmpleado(parametro);
                Entidad empleado = comando.Ejecutar();

                vista.FormViewEmployees.Text += ResourceGUIM10.OpenDivRow;

                vista.FormViewEmployees.Text += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos personales</h4>";

                //Nombres y Apellidos
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Nombre" + ResourceGUIM10.CloseLabel;

                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_cedula.ToString() +
                ResourceGUIM10.CloseInputTextDisabled +
                ResourceGUIM10.CloseDiv + ResourceGUIM10.OpenFormGroup +
                ResourceGUIM10.OpenInputText + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_p_nombre
                .ToString() +
                ResourceGUIM10.Espacio + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_s_nombre
                .ToString() +
                ResourceGUIM10.Espacio + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_p_apellido
                .ToString() +
                ResourceGUIM10.Espacio + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_s_apellido
                .ToString() +
                ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                //Genero
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Genero" + ResourceGUIM10.CloseLabel;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_genero.ToString() +
                                ResourceGUIM10.CloseInputTextDisabled +
                                ResourceGUIM10.CloseDiv;

                //Fecha Nacimiento
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Fecha de nacimiento" + ResourceGUIM10
                .CloseLabel;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_fecha_nac.
                                ToString("dd/MM/yyyy") +
                                ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                //Edad
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Edad" + ResourceGUIM10.CloseLabel;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                EdadEmpleado(((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_fecha_nac.
                                ToString("yyyy"))
                                + ResourceGUIM10.CloseInputTextDisabled +
                                ResourceGUIM10.CloseDiv;

                //Direccion
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Direccion" + ResourceGUIM10.CloseLabel;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).Emp_Direccion
                                + ResourceGUIM10.CloseInputTextDisabled +
                                ResourceGUIM10.CloseDiv;

                //cierre de col
                vista.FormViewEmployees.Text += ResourceGUIM10.CloseDiv;


                vista.FormViewEmployees.Text += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos contrato</h4>";
                //Fecha Contratacion
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Fecha contratacion" + ResourceGUIM10
                .CloseLabel;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                ((((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).jobs)).FechaIni +
                                ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                
                //FechaFin 
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                (((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).jobs).FechaFin
                                + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;
                
                //Cargo
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Cargo" + ResourceGUIM10.CloseLabel;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                (((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).jobs).Nombre
                                + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                
                //Sueldo Base
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Sueldo Base" + ResourceGUIM10.CloseLabel;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                (((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).jobs).Sueldo.ToString()
                                + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

                
                //Estatus
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenLabel + "Estatus" + ResourceGUIM10.CloseLabel;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_activo
                                + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

               
                //cierre de col
                vista.FormViewEmployees.Text += ResourceGUIM10.CloseDiv;

                
                //cierre de row
                vista.FormViewEmployees.Text += ResourceGUIM10.CloseDiv;
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenDivRow;


                vista.FormViewEmployees.Text += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos de contacto</h4>";

                //Email
                vista.FormViewEmployees.Text += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                                ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_email.ToString() +
                                ResourceGUIM10.CloseInputTextDisabled +
                                ResourceGUIM10.CloseDiv;



                //cierre de row
                vista.FormViewEmployees.Text += ResourceGUIM10.CloseDiv;

            }

            catch
            {

            }
        }



    }
}
