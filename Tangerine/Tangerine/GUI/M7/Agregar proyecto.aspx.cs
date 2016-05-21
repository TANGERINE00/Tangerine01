using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using LogicaTangerine.M5;

namespace Tangerine.GUI.M7
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LogicaProyecto LogicaM7 = new LogicaProyecto();
        List<Propuesta> Propuestas = new List<Propuesta>();
        LogicaM5 LogicaM5 = new LogicaM5();
        List<Contacto> Contactos = new List<Contacto>();

        protected void Page_Load(object sender, EventArgs e)
        {
           Propuestas = LogicaM7.ConsultarPropuestasAprobadas();

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
                   inputEncargado.Items.Add(Contactos[i].Nombre+" "+Contactos[i].Apellido);
                }
           
            } 
            
           }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            inputEncargado.Items.Clear();
            btnGenerar.Enabled = true;
        }

        protected void 
            
            btnAgregarPersonal_Click(object sender, EventArgs e)
        {

            columna2.Visible = true;
        }

        protected void comboPropuesta_Click(object sender, EventArgs e)
        {

            
                inputEncargado.Items.Clear();

                Contactos = LogicaM5.GetContacts(int.Parse(Propuestas[inputPropuesta.SelectedIndex].IdCompañia), 1);

                for (int i = 0; i < Contactos.Count; i++)
                {
                    inputEncargado.Items.Add(Contactos[i].Nombre + " " + Contactos[i].Apellido);
                }

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            //inputPropuesta.SelectedIndex();
            Proyecto _proyecto = new Proyecto(0, textInputNombreProyecto.Value, textInputCodigo.Value, DateTime.Parse(textInputFechaInicio.Value),
                                              DateTime.Parse(textInputFechaEstimada.Value),Double.Parse(textInputCosto.Value), "", "", "En curso",
                                              "","", 0, 0, 0);  //OSCAR EDITE AQUI EL CONSTRUCTOR... EL DATO DESPUES DE RAZON ES ACUERDO DE PAGO QUE HAY 
            LogicaProyecto _logica =  new LogicaProyecto();
            if (_logica.agregarProyecto(_proyecto))
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