using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;

namespace Tangerine.GUI.M7
{
    public partial class InformacionProyecto : System.Web.UI.Page
    {
        int Proyectoid;
        protected void Page_Load(object sender, EventArgs e)
        {

            Proyectoid = int.Parse(Request.QueryString["idCont"]);
           
            Proyecto Proyecto = new Proyecto();
            LogicaProyecto LogicaM7 = new LogicaProyecto();
            Proyecto = LogicaM7.consultarProyecto(Proyectoid);
            NombrePropuesta.Text = LogicaM7.ConsultarNombrePropuestaID(Proyecto.Idpropuesta);
            NombreProyecto.Text = Proyecto.Nombre;
            CodigoProyecto.Text = Proyecto.Codigo;
            FechaInicio.Text = Proyecto.Fechainicio.ToString("dd/MM/yyyy");
            FechaFin.Text = Proyecto.Fechaestimadafin.ToString("dd/MM/yyyy");
            Costo.Text = Proyecto.Costo.ToString();
            Porcentaje.Text= Proyecto.Realizacion;
            Estatus.Text = Proyecto.Estatus;
        }
    }
    }
