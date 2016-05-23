using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using LogicaTangerine.M10;
using LogicaTangerine.M5;

namespace Tangerine.GUI.M7
{
    public partial class InformacionProyecto : System.Web.UI.Page
    {
        int Proyectoid;
        List<Contacto> ContactosProyecto = new List<Contacto>();
        List<Empleado> ProgramadoresProyecto = new List<Empleado>();
        LogicaM5 LogicaM5 = new LogicaM5();
        LogicaM10 LogicaM10 = new LogicaM10();
        protected void Page_Load(object sender, EventArgs e)
        {

            Proyectoid = int.Parse(Request.QueryString["idCont"]);
           
            Proyecto Proyecto = new Proyecto();
            LogicaProyecto LogicaM7 = new LogicaProyecto();
            Proyecto = LogicaM7.consultarProyecto(Proyectoid);
            ContactosProyecto = LogicaM5.GetContactsProyect(Proyecto);
            ProgramadoresProyecto = LogicaM7.obtenerListaEmpleados(Proyecto);
            NombrePropuesta.Text = LogicaM7.ConsultarNombrePropuestaID(Proyecto.Idpropuesta);
            NombreProyecto.Text = Proyecto.Nombre;
            CodigoProyecto.Text = Proyecto.Codigo;
            FechaInicio.Text = Proyecto.Fechainicio.ToString("dd/MM/yyyy");
            FechaFin.Text = Proyecto.Fechaestimadafin.ToString("dd/MM/yyyy");
            Costo.Text = Proyecto.Costo.ToString();
            Porcentaje.Text= Proyecto.Realizacion;
            Estatus.Text = Proyecto.Estatus;
            for (int i = 0; i < ProgramadoresProyecto.Count; i++)
            {
                inputPersonal.Items.Add(ProgramadoresProyecto[i].emp_p_nombre + " " + ProgramadoresProyecto[i].emp_p_apellido);
            }

            for (int i = 0; i < ContactosProyecto.Count; i++)
            {
                inputEncargado.Items.Add(ContactosProyecto[i].Nombre + " " + ContactosProyecto[i].Apellido);
            }

        }
    }
    }
