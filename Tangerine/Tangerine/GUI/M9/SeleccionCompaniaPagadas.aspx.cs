using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;

namespace Tangerine.GUI.M9
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        public string company2
        {
            get
            {
                return this.tablaPagadas.Text;
            }

            set
            {
                this.tablaPagadas.Text = value;
            }
        }

        /// <summary>
        /// Metodo de carga de los elementos de la ventana.
        /// </summary>
        /// No recibe ningun parametro, solo muestra el listado de las companias que tiene proyectos.
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarTodasCompania();
                List<Entidad> listCompany = comando.Ejecutar();

                try
                {
                    foreach (Entidad theCompany in listCompany)
                    {
                        company2 += ResourceLogicaM9.OpenTR;

                        company2 += ResourceLogicaM9.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).NombreCompania.ToString() + ResourceLogicaM9.CloseTD;
                        company2 += ResourceLogicaM9.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).AcronimoCompania.ToString() + ResourceLogicaM9.CloseTD;
                        company2 += ResourceLogicaM9.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).RifCompania + ResourceLogicaM9.CloseTD;
                        company2 += ResourceLogicaM9.OpenTD + ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).FechaRegistroCompania.ToShortDateString() + ResourceLogicaM9.CloseTD;
                        if (((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).StatusCompania.Equals(1))
                        {
                            company2 += ResourceLogicaM9.OpenTD + ResourceLogicaM9.habilitado + ResourceLogicaM9.CloseTD;
                        }
                        else if (((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).StatusCompania.Equals(0))
                        {
                            company2 += ResourceLogicaM9.OpenTD + ResourceLogicaM9.inhabilitado + ResourceLogicaM9.CloseTD;
                        }

                        //Boton para cargar las facturas asociadas a cada compañia

                        company2 += ResourceLogicaM9.boton2 + ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).Id + ResourceLogicaM9.boton_cerrar_id;                   
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}