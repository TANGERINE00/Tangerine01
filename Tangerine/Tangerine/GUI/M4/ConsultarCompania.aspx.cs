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
                Compania laCompania;
                int idComp, typeHab;
                try
                {
                    typeHab = int.Parse(Request.QueryString["typeHab"]);
                    idComp = int.Parse(Request.QueryString["idComp"]);
                    laCompania = prueba.SearchCompany(idComp);
                    if (typeHab == 1)
                    {
                        prueba.EnableCompany(laCompania);
                      
                    }
                    if (typeHab == 0)
                    {
                        prueba.DisableCompany(laCompania);
                    }
                }
                catch
                  {
                      
                  }
                List<Compania> listCompany = prueba.getCompanies();
                    try
                    {
                        foreach (Compania theCompany in listCompany)
                        {

                           
                            company += ResourceGUIM4.OpenTR;

                            company += ResourceGUIM4.OpenTD + theCompany.NombreCompania.ToString() + ResourceGUIM4.CloseTD;
                            // company += ResourceGUIM4.OpenTD + theCompany.AcronimoCompania.ToString() + ResourceGUIM4.CloseTD;
                            company += ResourceGUIM4.OpenTD + theCompany.RifCompania + ResourceGUIM4.CloseTD;
                            company += ResourceGUIM4.OpenTD + theCompany.TelefonoCompania + ResourceGUIM4.CloseTD;
                            //    company += ResourceGUIM4.OpenTD + theCompany.FechaRegistroCompania.ToString() + ResourceGUIM4.CloseTD;
                        
                            if (theCompany.StatusCompania.Equals(1))
                            {                                
                                company += ResourceGUIM4.OpenTD + ResourceGUIM4.habilitado + theCompany.IdCompania + ResourceGUIM4.CloseSpanHab + ResourceGUIM4.CloseTD;
                            }
                            else if (theCompany.StatusCompania.Equals(0))
                            {                              
                                company += ResourceGUIM4.OpenTD + ResourceGUIM4.inhabilitado + theCompany.IdCompania + ResourceGUIM4.CloseSpanInhab + ResourceGUIM4.CloseTD;
                            }
                          
                          
                            //Acciones de cada compania  


                            company += ResourceGUIM4.OpenTD + ResourceGUIM4.OpenDivRow +
                                /*Boton Info */      ResourceGUIM4.OpenBotonInfo + theCompany.IdCompania +
                                /*Boton Edit */      ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonEdit + theCompany.IdCompania +
                                /*Boton Habilitar */     ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonHab + theCompany.IdCompania +
                                /*Boton Inhabilitar*/     ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonInhab + theCompany.IdCompania +
                                /*Boton Contacto*/        ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.BotonInvol + theCompany.IdCompania +
                               ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.CloseDiv +
                               ResourceGUIM4.CloseTD;




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