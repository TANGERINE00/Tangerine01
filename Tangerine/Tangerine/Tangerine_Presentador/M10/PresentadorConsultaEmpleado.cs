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

namespace Tangerine_Presentador.M10
{
    public class PresentadorConsultaEmpleado
    {
        IContratoConsultaEmpleados vista;

        public PresentadorConsultaEmpleado(IContratoConsultaEmpleados vista)
        {
            this.vista = vista;
        }

        public void cargarConsultarEmpleados()
        {
            try
            {
                
               // Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ConsultarEmpleados();

                LogicaTangerine.Comandos.M10.ComandoConsultarEmpleado comando =
                (LogicaTangerine.Comandos.M10.ComandoConsultarEmpleado)LogicaTangerine.Fabrica.FabricaComandos.ConsultarEmpleados();
                
                List<Entidad> listaEntidad = comando.Ejecutar();
                foreach (Entidad empleados in listaEntidad)
                {

                   
                    String hola = ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_p_nombre.ToString();

                    DominioTangerine.Entidades.M10.EmpleadoM10 emp=(DominioTangerine.Entidades.M10.EmpleadoM10)empleados;
                    
                    
                    vista.Tabla.Text += ResourceGUIM10.AbrirTR;
                    
                    //Nombres

                   
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_p_nombre.ToString() + ResourceGUIM10.CerrarTD;

                     

                    //Apellidos

                   
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_p_apellido.ToString() + ResourceGUIM10.CerrarTD;



                    //Cedula

                    
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    ((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_cedula.ToString() + ResourceGUIM10.CerrarTD;


                    ////Cargo

                    
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    (((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).jobs).Nombre.ToString() + ResourceGUIM10.CerrarTD;

                    ////Sueldo base
                  
                    
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD + 
                    (((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).emp_salario) + ResourceGUIM10.CerrarTD;


                   ////Fecha de contratacion
                   
                    
                    vista.Tabla.Text += ResourceGUIM10.AbrirTD
                     + (((DominioTangerine.Entidades.M10.EmpleadoM10)empleados).jobs).FechaContratacion.ToString("dd/MM/yyyy")
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
                   
                    //if (HttpContext.Current.Session["Rol"]+"" !="Programador")
                    //empleado += ResourceGUIM10.BotonStatusEmpAbrir + theEmpleado.emp_num_ficha +
                    //    ResourceGUIM10.BotonStatusEmpCerrar;

                    vista.Tabla.Text += ResourceGUIM10.CerrarTD;
                    vista.Tabla.Text += ResourceGUIM10.CerrarTR;
                }

                if (HttpContext.Current.Session["Rol"] + "" != "Programador")
                    vista.button += ResourceGUIM10.VentanaAgregarEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
   
     

    }

