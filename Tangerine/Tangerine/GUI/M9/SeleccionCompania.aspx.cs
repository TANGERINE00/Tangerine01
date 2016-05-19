using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M9;
using LogicaTangerine.M4;

namespace Tangerine.GUI.M9
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        public string company
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
            LogicaM4 prueba = new LogicaM4();

            if (!IsPostBack)
            {
                List<Compania> listCompany = prueba.getCompanies();

                try
                {
                    foreach (Compania theCompany in listCompany)
                    {
                        company += ResourceLogicaM9.OpenTR;

                        company += ResourceLogicaM9.OpenTD + theCompany.NombreCompania.ToString() + ResourceLogicaM9.CloseTD;
                        company += ResourceLogicaM9.OpenTD + theCompany.AcronimoCompania.ToString() + ResourceLogicaM9.CloseTD;
                        company += ResourceLogicaM9.OpenTD + theCompany.RifCompania + ResourceLogicaM9.CloseTD;                                    
                        company += ResourceLogicaM9.OpenTD + theCompany.FechaRegistroCompania.ToShortDateString() + ResourceLogicaM9.CloseTD;
                        if (theCompany.StatusCompania.Equals(1))
                        {
                            company += ResourceLogicaM9.OpenTD + ResourceLogicaM9.habilitado + ResourceLogicaM9.CloseTD;
                        }
                        else if (theCompany.StatusCompania.Equals(0))
                        {
                            company += ResourceLogicaM9.OpenTD + ResourceLogicaM9.inhabilitado + ResourceLogicaM9.CloseTD;
                        }

                        //Acciones de cada compania  

                        company += ResourceLogicaM9.boton + theCompany.IdCompania + ResourceLogicaM9.boton_cerrar_id;                   


                    }

                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}