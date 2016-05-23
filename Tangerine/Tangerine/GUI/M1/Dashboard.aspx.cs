using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using LogicaTangerine.M10;

namespace Tangerine.GUI.M1
{
    public partial class Dashboard : System.Web.UI.Page
    {
        LogicaProyecto logicaM7 = new LogicaProyecto();
        int _empleadoId;
        List<Proyecto> listaProyectos = new List<Proyecto>();

        private String dataProyecto
        {
            get
            {
                return this.FormViewProjects.Text;
            }
            set
            {
                this.FormViewProjects.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((HttpContext.Current.Session["Rol"] + "" == (ResourceGUIM1.RolAdministrador)) ||
                        ((HttpContext.Current.Session["Rol"] + "" == (ResourceGUIM1.RolGerente))))
                    listaProyectos = logicaM7.consultarProyectos();
                else
                {
                    if (HttpContext.Current.Session["Rol"] + "" == "Programador")
                    {
                        _empleadoId = Int32.Parse(HttpContext.Current.Session["UserID"] + "");
                        listaProyectos = logicaM7.consultarProyectosDeUnTrabajador(_empleadoId);
                    }
                }
                dataProyecto = LlenarProyectos(listaProyectos);
            }
        }

        public string LlenarProyectos(List<Proyecto> listaProyectos)
        {
            string _proyectos = String.Empty;
            int cantidad=0;
            List<Proyecto> listaProyectosOrdenada = listaProyectos.OrderByDescending(o => o.Fechainicio).ToList();
            
            foreach (Proyecto proyecto in listaProyectosOrdenada)
            {
                //Proyecto
                if (cantidad < int.Parse(ResourceGUIM1.MaxProyectos))
                {
                    _proyectos += ResourceGUIM1.PanelProyectoAbrir +
                      ResourceGUIM1.LabelNombreProyecto + proyecto.Idproyecto +
                      ResourceGUIM1.LabelNombreProyectoCerrar + proyecto.Nombre +
                      ResourceGUIM1.LabelNombreProyectoCerrar2 +
                      ResourceGUIM1.LabelDescProyecto + proyecto.Descripcion +
                      ResourceGUIM1.LabelFechaProyectoInicio +
                        proyecto.Fechainicio.ToString(ResourceGUIM1.FormatoFecha) +
                      ResourceGUIM1.LabelFechaProyectoFin +
                        proyecto.Fechaestimadafin.ToString(ResourceGUIM1.FormatoFecha) +
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