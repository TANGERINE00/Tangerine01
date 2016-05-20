using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M6;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class ConsultarPropuesta : System.Web.UI.Page
    {

        public string propuesta
        {
            get
            {
                return this.tablaP.Text;
            }

            set
            {
                this.tablaP.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                {
                    LogicaPropuesta logicaPropuesta = new LogicaPropuesta();

                    if (!IsPostBack)
                    {
                        List<Propuesta> listaPropuestas = logicaPropuesta.ConsultarTodasPropuestas();

                        try
                        {


                            foreach (Propuesta laPropuesta in listaPropuestas)
                            {
                                propuesta += RecursosGUI_M6.AbrirTR;

                                propuesta += RecursosGUI_M6.AbrirTD + laPropuesta.Nombre.ToString() + RecursosGUI_M6.CerrarTD;
                                propuesta += RecursosGUI_M6.AbrirTD + laPropuesta.Feincio.ToShortDateString() + RecursosGUI_M6.CerrarTD;
                                propuesta += RecursosGUI_M6.AbrirTD + laPropuesta.Estatus + RecursosGUI_M6.CerrarTD;
                                propuesta += RecursosGUI_M6.AbrirTD + laPropuesta.Costo + RecursosGUI_M6.CerrarTD;
                                if (laPropuesta.Estatus.Equals("Aprobada"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.aprobado + RecursosGUI_M6.CerrarTD;
                                }
                                else if (laPropuesta.Estatus.Equals("Pendiente"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.pendiente + RecursosGUI_M6.CerrarTD;
                                }

                                //Acciones de cada propuesta 

                                propuesta += RecursosGUI_M6.botonModificar + laPropuesta.Nombre.ToString() + RecursosGUI_M6.boton_cerrar_id;


                            }

                        }
                        catch (Exception ex)
                        {

                        }
                    }

                }

            }

        }

        public void btn_Elimina(String idPropuesta)
        {

            LogicaPropuesta logicaPropuesta = new LogicaPropuesta();
            Boolean siBorro;

            siBorro = logicaPropuesta.BorrarPropuesta(idPropuesta);

        }


    }
}