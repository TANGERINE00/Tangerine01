using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine;
using DominioTangerine;
using LogicaTangerine.M10;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using LogicaTangerine.M7;

namespace Tangerine.GUI.M7
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        public string project
        {
            get
            {
                return this.tabla.Text;
            }

            set
            {
                this.tabla.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaProyecto pruebaM7 = new LogicaProyecto();
            LogicaM4 pruebaM4 = new LogicaM4();
            LogicaPropuesta pruebaM6 = new LogicaPropuesta();
            if (!IsPostBack)
            {
                List<Proyecto> listProject = pruebaM7.consultarProyectos();
                try 
                { 
                    foreach(Proyecto theProject in listProject )
                    {
                        project += ResourceGUIM7.OpenTr;

                        project += ResourceGUIM7.OpenTD + theProject.Nombre.ToString() + ResourceGUIM7.CloseTd;
                        project += ResourceGUIM7.OpenTD + pruebaM7.ConsultarNombrePropuestaID(theProject.Idpropuesta) + ResourceGUIM7.CloseTd; // Acomodar debe mostrar el nombre y muestra el id
                        //project += ResourceGUIM7.OpenTD + "" + ResourceGUIM7.CloseTd;
                        project += ResourceGUIM7.OpenTD + theProject.Codigo + ResourceGUIM7.CloseTd;
                        project += ResourceGUIM7.OpenTD + theProject.Fechainicio + ResourceGUIM7.CloseTd;
                        project += ResourceGUIM7.OpenTD + theProject.Fechaestimadafin + ResourceGUIM7.CloseTd;
                        project += ResourceGUIM7.OpenTD + theProject.Realizacion.ToString() + ResourceGUIM7.CloseTd;
                        if (theProject.Estatus.ToString().Equals("En desarrollo")) 
                        {
                            project += ResourceGUIM7.OpenTD + ResourceGUIM7.Desarrollo + ResourceGUIM7.CloseTd;
                        }
                        if (theProject.Estatus.ToString().Equals("Completado"))
                        {
                            project += ResourceGUIM7.OpenTD + ResourceGUIM7.Completado + ResourceGUIM7.CloseTd;
                        }
                        if (theProject.Estatus.ToString().Equals("A destiempo"))
                        {
                            project += ResourceGUIM7.OpenTD + ResourceGUIM7.CompletadoAdestiempo + ResourceGUIM7.CloseTd;
                        }
                        if (theProject.Estatus.ToString().Equals("Cancelado"))
                        {
                            project += ResourceGUIM7.OpenTD + ResourceGUIM7.Cancelado + ResourceGUIM7.CloseTd;
                        }
                        project += ResourceGUIM7.OpenTD + ResourceGUIM7.OpenBotonInfo + theProject.Idproyecto + ResourceGUIM7.CloseBoton
                                 + ResourceGUIM7.OpenBotonPersonal + theProject.Idproyecto + ResourceGUIM7.CloseBoton + ResourceGUIM7.CloseTd;

                        project += ResourceGUIM7.CloseTr;
                    }//Fin del Foreach
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}