using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using LogicaTangerine;
using DominioTangerine;
using System.Threading.Tasks;
using Tangerine_Contratos.M1;


namespace Tangerine_Presentador.M1
{
    public class PresentadorDashboard
    {

        #region Variables

        private IcontratoDashboard _vista;

        int _empleadoId;

        #endregion

        public PresentadorDashboard(IcontratoDashboard vista)
        {
            _vista = vista;
        }



        /// <summary>
        /// Metodo que muestra en el dashboard los proyectos mas recientes
        /// </summary>
        public void CargarDashBoard()
        {
            try
            {


                List<Entidad> listaFinal = new List<Entidad>();


                if ((HttpContext.Current.Session["Rol"] + "" == (ResourceGUIM1.RolAdministrador)) ||
                            ((HttpContext.Current.Session["Rol"] + "" == (ResourceGUIM1.RolGerente))))
                {
                    Comando<List<Entidad>> comando =
                        LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosProyectos();
                    List<Entidad> listaEntidad = comando.Ejecutar();
                    listaFinal = listaEntidad;
                }


                else
                {
                    if (HttpContext.Current.Session["Rol"] + "" == "Programador")
                    {
                        Entidad parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
                        ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id =
                            Int32.Parse(HttpContext.Current.Session["UserID"] + "");


                        Comando<List<Entidad>> comandoConsultarEmpleados =
                            LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosProyectos();
                        List<Entidad> listaEntidad = comandoConsultarEmpleados.Ejecutar();
                        listaFinal = listaEntidad;
                    }
                }
                _vista.VistaForm.Text = LLenarLosProyectos(listaFinal);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD)
            {
                HttpContext.Current.Response.Redirect("../M1/PaginaError.aspx");
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("../M1/PaginaError.aspx");
            }
        }

        /// <summary>
        /// Metodo que llena en una lista todos los proyectos
        /// </summary>
        public string LLenarLosProyectos (List<Entidad> listaProyectos )
        {
          string _proyectos = String.Empty;
          int cantidad=0;
          foreach (Entidad theProject in listaProyectos)
           {
               if (cantidad < int.Parse(ResourceGUIM1.MaxProyectos))
               {
                             
                 _proyectos += ResourceGUIM1.PanelProyectoAbrir +
                 ResourceGUIM1.LabelNombreProyecto + ((DominioTangerine.Entidades.M7.Proyecto)theProject).Id.ToString() +
                 ResourceGUIM1.LabelNombreProyectoCerrar +
                 ((DominioTangerine.Entidades.M7.Proyecto)theProject).Nombre.ToString() +
                 ResourceGUIM1.LabelNombreProyectoCerrar2 +
                 ResourceGUIM1.LabelDescProyecto +
                 ((DominioTangerine.Entidades.M7.Proyecto)theProject).Descripcion.ToString() +
                 ResourceGUIM1.LabelFechaProyectoInicio +
                 ((DominioTangerine.Entidades.M7.Proyecto)theProject).Fechainicio.ToString(ResourceGUIM1.FormatoFecha) +
                 ResourceGUIM1.LabelFechaProyectoFin +
                 ((DominioTangerine.Entidades.M7.Proyecto)theProject).Fechaestimadafin.ToString(ResourceGUIM1.FormatoFecha) +
                 ResourceGUIM1.PanelProyectoCerrar;

                 cantidad++;

               }      

           }
            if (listaProyectos.Count == 0)
                    {
                        _proyectos += ResourceGUIM1.MensajeSinProyecto;
                    }
                
            return _proyectos;

        }




    }
}
