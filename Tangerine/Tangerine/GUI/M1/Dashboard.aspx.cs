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
            
            foreach (Proyecto proyecto in listaProyectos)
            {
                //Proyecto
                _proyectos += ResourceGUIM1.PanelProyectoAbrir +
                  ResourceGUIM1.LabelNombreProyecto + proyecto.Nombre +
                  ResourceGUIM1.LabelDescProyecto + proyecto.Descripcion +
                  ResourceGUIM1.LabelFechaProyectoInicio +
                    proyecto.Fechainicio.ToString(ResourceGUIM1.FormatoFecha) +
                  ResourceGUIM1.LabelFechaProyectoFin +
                    proyecto.Fechaestimadafin.ToString(ResourceGUIM1.FormatoFecha) +
                  ResourceGUIM1.LabelCostoProyecto + proyecto.Costo +
                  ResourceGUIM1.PanelProyectoCerrar;
            }

            if (listaProyectos.Count == 0)
            {
                _proyectos += ResourceGUIM1.MensajeSinProyecto;
            }
                

            return _proyectos;
        }
    }
}