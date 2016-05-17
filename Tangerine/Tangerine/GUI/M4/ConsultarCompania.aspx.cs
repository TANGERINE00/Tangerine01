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
        public string infoCompany
        {
            get
            {
                return this.infoCom.Text;
            }

            set
            {
                this.infoCom.Text = value;
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
                       // company += ResourceGUIM4.OpenTD + theCompany.AcronimoCompania.ToString() + ResourceGUIM4.CloseTD;
                        company += ResourceGUIM4.OpenTD + theCompany.RifCompania + ResourceGUIM4.CloseTD;
                        company += ResourceGUIM4.OpenTD + "040401234" + ResourceGUIM4.CloseTD;
                    //    company += ResourceGUIM4.OpenTD + theCompany.FechaRegistroCompania.ToString() + ResourceGUIM4.CloseTD;
                        if (theCompany.StatusCompania.Equals(1))
                        {
                            company += ResourceGUIM4.OpenTD + ResourceGUIM4.habilitado + ResourceGUIM4.CloseTD;
                        }
                        else if (theCompany.StatusCompania.Equals(0))
                        {
                            company += ResourceGUIM4.OpenTD + ResourceGUIM4.inhabilitado + ResourceGUIM4.CloseTD;
                        } 
                        
                        //Acciones de cada compania  
                         
                        
                        company += ResourceGUIM4.OpenTD + 
     /*Boton Info */       ResourceGUIM4.OpenBotonInfo + theCompany.IdCompania
     /*Boton Edit */     + ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonEdit + theCompany.IdCompania
 /*Boton Habilitar */    + ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonHab + theCompany.IdCompania
/*Boton Inhabilitar*/    + ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonInhab + theCompany.IdCompania
/*Boton Contacto*/       + ResourceGUIM4.CloseBotonParametro 
/*Boton Involucrado*/    + ResourceGUIM4.BotonContac + ResourceGUIM4.BotonInvol + ResourceGUIM4.CloseTD;  
                           
                        
                        company += ResourceGUIM4.CloseTR;

                        
                    }

                }
                catch (Exception ex)
                {

                }
            }
            
        }

        void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string tipoBoton;
            string idCompany;
            LogicaM4 lm4 = new LogicaM4();
            List<Compania> listCompany = lm4.getCompanies();
           
            
            if (button != null)
            {
                string buttonId = button.ID;      //Obtengo el id del boton presionado
                tipoBoton = buttonId.Substring(0, 3);
                idCompany = buttonId.Substring(2, buttonId.Length-2);

                foreach (Compania theCompany in listCompany)
                {
                    if (theCompany.IdCompania.Equals(idCompany))
                    {
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh3 + ResourceGUIM4.Nombre + ResourceGUIM4.Closeh3;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh4 + theCompany.NombreCompania.ToString() + ResourceGUIM4.Closeh4;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh3 + ResourceGUIM4.Acronimo + ResourceGUIM4.Closeh3;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh4 + theCompany.AcronimoCompania.ToString() + ResourceGUIM4.Closeh4;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh3 + ResourceGUIM4.Rif + ResourceGUIM4.Closeh3;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh4 + theCompany.RifCompania.ToString() + ResourceGUIM4.Closeh4;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh3 + ResourceGUIM4.Email + ResourceGUIM4.Closeh3;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh4 + theCompany.EmailCompania.ToString() + ResourceGUIM4.Closeh4;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh3 + ResourceGUIM4.Telefono + ResourceGUIM4.Closeh3;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh4 + theCompany.TelefonoCompania.ToString() + ResourceGUIM4.Closeh4;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh3 + ResourceGUIM4.Status + ResourceGUIM4.Closeh3;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh4 + theCompany.StatusCompania.ToString() + ResourceGUIM4.Closeh4;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh3 + ResourceGUIM4.Fecha + ResourceGUIM4.Closeh3;
                        infoCompany += ResourceGUIM4.OpenDivRow + ResourceGUIM4.Openh4 + theCompany.FechaRegistroCompania.ToString() + ResourceGUIM4.Closeh4;
                   
                    }
                }
                
     
              
            }
        }
        


     


    }
}