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

    public partial class WebForm1 : System.Web.UI.Page
    {
        LogicaProyecto LogicaM7 = new LogicaProyecto();
        List<Propuesta> Propuestas = new List<Propuesta>();
        LogicaM5 LogicaM5 = new LogicaM5();
        LogicaM10 LogicaM10 = new LogicaM10();
        List<Empleado> Gerentes = new List<Empleado>();
        List<Empleado> Programadores = new List<Empleado>();
        List<Contacto> Contactos = new List<Contacto>();
        List<Empleado> seleccionProgramadores = new List<Empleado>();
        List<Contacto> seleccionContactos = new List<Contacto>();
        int _Gerente;

        protected void Page_Load(object sender, EventArgs e)
        {
           Propuestas = LogicaM7.ConsultarPropuestasAprobadas();
           Gerentes = LogicaM10.GetGerentes();
           Programadores = LogicaM10.GetProgramadores();

           if (!IsPostBack)
           {
               
            if( Propuestas.Count > 0 )
            {

                for (int i = 0; i < Propuestas.Count;i++ )
                {
                    inputPropuesta.Items.Add(Propuestas[i].Nombre);
                }

                Contactos = LogicaM5.GetContacts(int.Parse(Propuestas[0].IdCompañia),1); 

                for (int i = 0; i < Contactos.Count; i++) 
                {
                   inputEncargado.Items.Add(Contactos[i].Nombre + " " + Contactos[i].Apellido);
                }
                textInputCosto.Value = Propuestas[0].Costo.ToString();
            }
            for (int i = 0; i < Gerentes.Count; i++)
            {
                
                inputGerente.Items.Add(Gerentes[i].emp_p_nombre+" "+Gerentes[i].emp_p_apellido);
            }
            for (int i = 0; i < Programadores.Count; i++)
            {
                
                inputPersonal.Items.Add(Programadores[i].emp_p_nombre + " " + Programadores[i].emp_p_apellido);
            }
           }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarPersonal_Click(object sender, EventArgs e)
        {

            columna2.Visible = true;
            btnGenerar.Enabled = true;
        }

        protected void comboPropuesta_Click(object sender, EventArgs e)
        {
            inputEncargado.Items.Clear();

            Contactos = LogicaM5.GetContacts(int.Parse(Propuestas[inputPropuesta.SelectedIndex].IdCompañia), 1);

            for (int i = 0; i < Contactos.Count; i++)
            {
                inputEncargado.Items.Add(Contactos[i].Nombre + " " + Contactos[i].Apellido);
            }

            textInputCosto.Value = Propuestas[inputPropuesta.SelectedIndex].Costo.ToString();          
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Propuestas = LogicaM7.ConsultarPropuestasAprobadas();
            Gerentes = LogicaM10.GetGerentes();
            Programadores = LogicaM10.GetProgramadores();
            Contactos = LogicaM5.GetContacts(int.Parse(Propuestas[inputPropuesta.SelectedIndex].IdCompañia), 1);
            Proyecto _proyecto = new Proyecto(0,textInputNombreProyecto.Value,textInputCodigo.Value,DateTime.Parse(textInputFechaInicio.Value),
                                              DateTime.Parse(textInputFechaEstimada.Value), Double.Parse(textInputCosto.Value),
                                              Propuestas[inputPropuesta.SelectedIndex].Descripcion, "0", "En desarrollo", "",
                                              Propuestas[inputPropuesta.SelectedIndex].Acuerdopago, 5,int.Parse(Propuestas[inputPropuesta.SelectedIndex].IdCompañia),
                                              Gerentes[inputGerente.SelectedIndex].Emp_num_ficha);
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

            _proyecto.set_contactos(seleccionContactos);
            _proyecto.set_empleados(seleccionProgramadores);
           
            LogicaProyecto _logica =  new LogicaProyecto();
            if (_logica.agregarProyecto(_proyecto))
            {
                Server.Transfer("Dashboard.aspx");
                //colocar un mensaje de creacion con exito y vaciar text.
            }
            else
            { 
                //colocar  un mensaje de error en la creacion
            }
        } 
    }
}