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
        List<Contacto> Contactos = new List<Contacto>();
        List<Contacto> ContactosProyecto = new List<Contacto>();
        List<Empleado> Gerentes = new List<Empleado>();
        List<Empleado> Programadores = new List<Empleado>();
        List<Empleado> ProgramadoresProyecto = new List<Empleado>();
        LogicaM5 LogicaM5 = new LogicaM5();
        LogicaM10 LogicaM10 = new LogicaM10();
        List<Empleado> seleccionProgramadores = new List<Empleado>();
        List<Contacto> seleccionContactos = new List<Contacto>();

        protected void Page_Load(object sender, EventArgs e)
        {
          _idProyecto = int.Parse(Request.QueryString["idCont"]);
          if (!IsPostBack)
          {
              Gerentes = LogicaM10.GetGerentes();
              Programadores = LogicaM10.GetProgramadores();
              proyecto = LogicProject.consultarProyecto(_idProyecto);
              ContactosProyecto = LogicaM5.GetContactsProyect(proyecto);
              ProgramadoresProyecto = LogicProject.obtenerListaEmpleados(proyecto);
              Contactos = LogicaM5.GetContacts(proyecto.Idcompania,1);
            
              this.textInputNombreProyecto.Value = proyecto.Nombre.ToString();
              this.textInputCodigo.Value = proyecto.Codigo.ToString();
              this.textInputCosto.Value = proyecto.Costo.ToString();
              this.textInputFechaEstimada.Value = proyecto.Fechaestimadafin.ToString("dd/MM/yyyy");
              this.textInputFechaInicio.Value = proyecto.Fechainicio.ToString("dd/MM/yyyy");
              this.textInputPorcentaje.Value = proyecto.Realizacion.ToString();
              this.inputPropuesta.Items.Add(LogicProject.ConsultarNombrePropuestaID(proyecto.Idproyecto));
              for (int i = 0; i < Gerentes.Count; i++)
              {

                  inputGerente.Items.Add(Gerentes[i].emp_p_nombre + " " + Gerentes[i].emp_p_apellido);
                  if(proyecto.Idgerente.Equals(Gerentes[i].Emp_num_ficha))
                  {
                      inputGerente.Items[i].Selected = true;
                  }
              }

              for (int i = 0; i < Programadores.Count; i++)
              {
                  inputPersonal.Items.Add(Programadores[i].emp_p_nombre + " " + Programadores[i].emp_p_apellido);
              }

              for (int i = 0; i < Contactos.Count; i++)
              {
                  inputEncargado.Items.Add(Contactos[i].Nombre + " " + Contactos[i].Apellido);
              }

              for (int j = 0; j < ProgramadoresProyecto.Count; j++)
              {
                  for (int i = 0; i < inputEncargado.Items.Count; i++)
                  {

                      if (inputPersonal.Items[i].Value.ToString().Equals(ProgramadoresProyecto[j].emp_p_nombre + " " + ProgramadoresProyecto[j].emp_p_apellido))
                      {
                          inputPersonal.Items[i].Selected = true;
                          break;
                      }
                  }
              }

              for (int j = 0; j < ContactosProyecto.Count; j++)
              { 
                  for (int i = 0; i < inputEncargado.Items.Count; i++)
                  {

                      if (inputEncargado.Items[i].Value.Equals(ContactosProyecto[j].Nombre + " " + ContactosProyecto[j].Apellido))
                      {
                          inputEncargado.Items[i].Selected = true;
                          break;
                      }
                  }
              }


          }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            proyecto = LogicProject.consultarProyecto(int.Parse(Request.QueryString["idCont"]));
            String _realizado = proyecto.Realizacion;

            if (int.Parse(textInputPorcentaje.Value) >= int.Parse(_realizado))
            {
                Gerentes = LogicaM10.GetGerentes();
                Programadores = LogicaM10.GetProgramadores();
                ContactosProyecto = LogicaM5.GetContactsProyect(proyecto);
                proyecto.Fechaestimadafin = DateTime.Parse(textInputFechaEstimada.Value);
                proyecto.Costo = Double.Parse(textInputCosto.Value);
                if (int.Parse(textInputPorcentaje.Value) > int.Parse(_realizado))
                    proyecto.Realizacion = textInputPorcentaje.Value;
                proyecto.Estatus = inputEstatus.Value;
                Contactos = LogicaM5.GetContacts(proyecto.Idcompania, 1);
                for (int i = 0; i < Gerentes.Count; i++)
                {
                    if (inputGerente.Items[inputGerente.SelectedIndex].Value.Equals(Gerentes[i].Emp_p_nombre + " " + Gerentes[i].Emp_p_apellido))
                    {
                        proyecto.Idgerente = Gerentes[i].Emp_num_ficha;
                    }
                }


                Empleado _empleado = new Empleado();
                for (int i = 0; i < inputPersonal.Items.Count; i++)
                {
                    if (inputPersonal.Items[i].Selected)
                    {
                        seleccionProgramadores.Add(Programadores[i]);
                    }
                }


                for (int i = 0; i < inputEncargado.Items.Count; i++)
                {
                    if (inputEncargado.Items[i].Selected)
                    {
                        seleccionContactos.Add(Contactos[i]);
                    }
                }

                proyecto.set_contactos(seleccionContactos);
                proyecto.set_empleados(seleccionProgramadores);

                LogicaProyecto _logica = new LogicaProyecto();

                if (_logica.modificarProyecto(proyecto))
                {
                    if (int.Parse(textInputPorcentaje.Value) > int.Parse(_realizado))
                    {
                        Server.Transfer("/GUI/M8/GenerarFacturaM8.aspx?IdPropuesta=" + proyecto.Idpropuesta + "&IdProyecto=" + proyecto.Idproyecto + "&Monto="
                            + LogicProject.calcularPago(int.Parse(_realizado), int.Parse(textInputPorcentaje.Value), double.Parse(textInputCosto.Value)));
                    }
                    Server.Transfer("ConsultaProyecto.aspx");
                    //colocar un mensaje de creacion con exito y vaciar text.
                }
                else
                {
                    //colocar  un mensaje de error en la creacion
                }
            }
            else {
                Server.Transfer("modificarProyecto.aspx?idCont="+proyecto.Idproyecto);
               
            }
        } 
    }
}