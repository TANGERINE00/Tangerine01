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
using System.Web;
using ExcepcionesTangerine.M10;

namespace Tangerine_Presentador.M10
{
    public class PresentadorConsultaEmpleado
    {
        IContratoConsultaEmpleados vista;
        private int estadoActual = 0;
        

        public PresentadorConsultaEmpleado(IContratoConsultaEmpleados vista)
        {
            this.vista = vista;
        }


        /// <summary>
        /// Metodo para la accion de consulta de empleados  
        /// </summary>
        public void cargarConsultarEmpleados()
        {

            
            try
            {
                LogicaTangerine.Comandos.M10.ComandoConsultarEmpleado comando =
                (LogicaTangerine.Comandos.M10.ComandoConsultarEmpleado)LogicaTangerine.Fabrica.FabricaComandos
                .ConsultarEmpleados();
                
                List<Entidad> listaEntidad = comando.Ejecutar();
                foreach (Entidad empleados in listaEntidad)
                {
                    DominioTangerine.Entidades.M10.EmpleadoM10 emp=
                    (DominioTangerine.Entidades.M10.EmpleadoM10)empleados;
                    
                    
                    vista.Tabla.Text += ResourceGUIM10.AbrirTR;
                    //Nombres
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_p_nombre.ToString() + ResourceGUIM10
                    .CerrarTD;

                     
                    //Apellidos
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_p_apellido.ToString() + ResourceGUIM10
                    .CerrarTD;


                    //Cedula
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_cedula.ToString() + ResourceGUIM10
                    .CerrarTD;


                    ////Cargo
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    (((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).jobs).Nombre.ToString() + ResourceGUIM10
                    .CerrarTD;


                   //Sueldo base
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    (((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_salario) + ResourceGUIM10.CerrarTD;


                   //Fecha de contratacion
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD
                    + (((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).jobs).FechaContratacion.
                    ToString("dd/MM/yyyy")
                    + ResourceGUIM10.CerrarTD;


                   //Estatus
                    if (((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_activo.ToString() == "Activo")
                                    
                                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + ResourceGUIM10.AbrirActivo
                                    + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_activo.ToString() +
                                    ResourceGUIM10.CerrarActivo + ResourceGUIM10.CerrarTD;
                    else
                                
                        
                                     vista.Tabla.Text += ResourceGUIM10.AbrirTD + ResourceGUIM10.AbrirInactivo
                                     + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_activo.ToString() +
                                     ResourceGUIM10.CerrarInactivo + ResourceGUIM10.CerrarTD;


                    //Acciones de cada empleado
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD;

                    //Ver
                    vista.Tabla.Text += ResourceGUIM10.BotonVerEmpAbrir
                    + ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_id.ToString() +
                    ResourceGUIM10.BotonVerEmpCerrar;


                    //Estatus Activo/Inactivo
                    if (HttpContext.Current.Session["Rol"] + "" != "Programador")
                        vista.Tabla.Text += ResourceGUIM10.BotonStatusHabilitarAbrir+
                        ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_id.ToString() +
                        ResourceGUIM10.BotonStatusHabilitarCerrar;
                        vista.Tabla.Text += ResourceGUIM10.BotonStatusDeshabilitarAbrir +
                        ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_id.ToString() +
                        ResourceGUIM10.BotonStatusDeshabilitarCerrar;

                    vista.Tabla.Text += ResourceGUIM10.CerrarTD;
                    vista.Tabla.Text += ResourceGUIM10.CerrarTR;
                }

                
            }
            catch (ConsultarEmpleadoException )
            {
                estadoActual = 2;
            }
            catch (BaseDatosException )
            {
                estadoActual = 3;
            }                                                                                                      
        }
                                                                                                                       
        /// <summary>
        /// Metodo para la accion del boton de activar o desactivar empelado                                           
        /// </summary>
        /// <param name="id"></param>
        public void CambiarEstatus(int id)
        {
            try
            {
                Entidad estatusId = DominioTangerine.Fabrica.FabricaEntidades.ConsultarEmpleados();
                estatusId.Id = id;

                Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.HabilitarEmpleado(estatusId);
                comando.Ejecutar();

            }

            catch (ModificarEstatusException ex)
            {
                
            }  
        }


        /// <summary>
        /// Método que contigura el div de alerta de la vista
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="typeMsg"></param>
        public void AlertaMensaje(string msj, int typeMsg)
        {
            if (typeMsg == 1)
                vista.alertaClase = ResourceGUIM10.ExitoAlerta;
            else
                vista.alertaClase = ResourceGUIM10.AlertAdvertencia;

            vista.alertaRol = ResourceGUIM10.Alerta;
            vista.alertas = ResourceGUIM10.AlertShowSu1 + msj + ResourceGUIM10.AlertShowSu2;
        }

        public void AlertasCase()
        {
            int Empleadoid = int.Parse(HttpContext.Current.Request.QueryString["EmployeeId"]);

            switch (Empleadoid)
            {
                case 1:
                    AlertaMensaje(ResourceGUIM10.EmpleadoAgregado, int.Parse(ResourceGUIM10.StatusAgregado));
                    break;
               
                case 2:
                    AlertaMensaje(ResourceGUIM10.ErrorEmpleado, 0);
                    break;
                case 3:
                    AlertaMensaje(ResourceGUIM10.ErrorBaseDeDatos, 0);
                    break;
            }
        }







    }
   
    }

