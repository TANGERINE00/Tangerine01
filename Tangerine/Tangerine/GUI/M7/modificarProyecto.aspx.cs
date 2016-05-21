using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using LogicaTangerine.M5;
using LogicaTangerine.M10;

namespace Tangerine.GUI.M7
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        int _idProyecto;
        LogicaProyecto LogicProject = new LogicaProyecto();
        Proyecto proyecto = new Proyecto();
        List<Empleado> Gerentes = new List<Empleado>();
        List<Empleado> Programadores = new List<Empleado>();
        LogicaM5 LogicaM5 = new LogicaM5();
        LogicaM10 LogicaM10 = new LogicaM10();
        protected void Page_Load(object sender, EventArgs e)
        {
          _idProyecto = int.Parse(Request.QueryString["idCont"]);
          if (!IsPostBack)
          {
              Gerentes = LogicaM10.GetGerentes();
              Programadores = LogicaM10.GetProgramadores();
              proyecto = LogicProject.consultarProyecto(_idProyecto);
              
              this.textInputNombreProyecto.Value = proyecto.Nombre.ToString();
              this.textInputCodigo.Value = proyecto.Codigo.ToString();
              this.textInputCosto.Value = proyecto.Costo.ToString();
              this.textInputFechaEstimada.Value = proyecto.Fechaestimadafin.ToString("dd/MM/yyyy");
              this.textInputFechaInicio.Value = proyecto.Fechainicio.ToString("dd/MM/yyyy");
              this.textInputPorcentaje.Value = proyecto.Realizacion.ToString();
              this.inputPropuesta.Items.Add(proyecto.Idproyecto.ToString());
              for (int i = 0; i < Gerentes.Count; i++)
              {

                  inputGerente.Items.Add(Gerentes[i].emp_p_nombre + " " + Gerentes[i].emp_p_apellido);
              }

              for (int i = 0; i < Programadores.Count; i++)
              {
                  inputPersonal.Items.Add(Programadores[i].emp_p_nombre + " " + Programadores[i].emp_p_apellido);
              }
    
          }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Proyecto _proyecto = new Proyecto(0, textInputNombreProyecto.Value, textInputCodigo.Value, DateTime.Parse(textInputFechaInicio.Value),
                                              DateTime.Parse(textInputFechaEstimada.Value), Double.Parse(textInputCosto.Value), "", "", "En curso",
                                              "", "", 0, 0, 0);  //OSCAR EDITE AQUI EL CONSTRUCTOR... EL DATO DESPUES DE RAZON ES ACUERDO DE PAGO QUE HAY 
            LogicaProyecto _logica = new LogicaProyecto();
            if (_logica.modificarProyecto(_proyecto))
            {
                //colocar un mensaje de creacion con exito y vaciar text.
            }
            else
            {
                //colocar  un mensaje de error en la creacion
            }
        } 
    }
}