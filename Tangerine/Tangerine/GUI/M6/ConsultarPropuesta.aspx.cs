using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
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
                    LogicaM4 logicaCompania = new LogicaM4();


                    if (!IsPostBack)
                    {
                        List<Propuesta> listaPropuestas = logicaPropuesta.ConsultarTodasPropuestas();

                        try
                        {


                            foreach (Propuesta laPropuesta in listaPropuestas)
                            {
                                
                                Compania laCompania = logicaCompania.SearchCompany(Int32.Parse(laPropuesta.IdCompañia));
                                

                                propuesta += RecursosGUI_M6.AbrirTR;

                                propuesta += RecursosGUI_M6.AbrirTD + laPropuesta.Nombre.ToString() + RecursosGUI_M6.CerrarTD;
                                propuesta += RecursosGUI_M6.AbrirTD + laCompania.NombreCompania.ToString() +RecursosGUI_M6.CerrarTD;
                                propuesta += RecursosGUI_M6.AbrirTD + laPropuesta.Feincio.ToShortDateString() + RecursosGUI_M6.CerrarTD;
                                if (laPropuesta.Estatus.Equals("Aprobado"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.aprobado + RecursosGUI_M6.CerrarTD;
                                }
                                if (laPropuesta.Estatus.Equals("Pendiente"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.pendiente + RecursosGUI_M6.CerrarTD;
                                }
                                if (laPropuesta.Estatus.Equals("Cerrado"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.cerrado + RecursosGUI_M6.CerrarTD;
                                }



                                if (laPropuesta.Moneda.Equals("Bolivar"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.bolivar + RecursosGUI_M6.CerrarTD;
                                }
                                if (laPropuesta.Moneda.Equals("Dolar"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.dolar + RecursosGUI_M6.CerrarTD;
                                }
                                if (laPropuesta.Moneda.Equals("Euro"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.euro + RecursosGUI_M6.CerrarTD;
                                }
                                if (laPropuesta.Moneda.Equals("Bitcoin"))
                                {
                                    propuesta += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.bitcoin + RecursosGUI_M6.CerrarTD;
                                }

                                propuesta += RecursosGUI_M6.AbrirTD + laPropuesta.Costo + RecursosGUI_M6.CerrarTD;

                                //Acciones de cada propuesta


                                propuesta += RecursosGUI_M6.AbrirTD2
                                     + RecursosGUI_M6.botonConsultar + laPropuesta.Nombre.ToString() + RecursosGUI_M6.botonCerra
                                     + RecursosGUI_M6.botonModificar + laPropuesta.Nombre.ToString() + RecursosGUI_M6.botonCerra;
                                propuesta += RecursosGUI_M6.CerrarTD;
                                propuesta += RecursosGUI_M6.CerrarTR;




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