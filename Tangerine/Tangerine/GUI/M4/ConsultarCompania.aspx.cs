using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M4;

namespace Tangerine.GUI.M4
{
    public partial class ConsultarCompania : System.Web.UI.Page
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
                //Aqui ejecuto el filltable de la clase creada en logica para probar la conexion a la bd
                //los parametros son tipo de empresa 1 (Compania), id de la empresa 1.
                //prueba.fillTable(1,1);
                List<Compania> listCompany = prueba.getCompanies();

                try
                {
                    foreach (Compania theCompany in listCompany)
                    {
                        company += ResourceGUIM4.OpenTR;

                        company += ResourceGUIM4.OpenTD + theCompany.NombreCompania.ToString() + ResourceGUIM4.CloseTD;
                        company += ResourceGUIM4.OpenTD + theCompany.AcronimoCompania.ToString() + ResourceGUIM4.CloseTD;
                        company += ResourceGUIM4.OpenTD + theCompany.RifCompania + ResourceGUIM4.CloseTD;
                        company += ResourceGUIM4.OpenTD + "040401234" + ResourceGUIM4.CloseTD;
                        company += ResourceGUIM4.OpenTD + theCompany.FechaRegistroCompania.ToString() + ResourceGUIM4.CloseTD;
                        if (theCompany.StatusCompania.Equals(1))
                        {
                            company += ResourceGUIM4.OpenTD + ResourceGUIM4.habilitado + ResourceGUIM4.CloseTD;
                        }
                        else if (theCompany.StatusCompania.Equals(0))
                        {
                            company += ResourceGUIM4.OpenTD + ResourceGUIM4.inhabilitado + ResourceGUIM4.CloseTD;
                        }                        
                        
                        //Acciones de cada compania

                        company += ResourceGUIM4.OpenTD + ResourceGUIM4.BotonInfo + ResourceGUIM4.BotonModif + 
                            ResourceGUIM4.BotonHab + ResourceGUIM4.BotonInhab + ResourceGUIM4.BotonContac + 
                            ResourceGUIM4.BotonInvol + ResourceGUIM4.CloseTD;  
                        
                        company += ResourceGUIM4.CloseTR;
                    }

                }
                catch (Exception ex)
                {

                }
            }
            
        }
    }
}